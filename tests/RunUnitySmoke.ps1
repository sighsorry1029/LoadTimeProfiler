<#
Run a native headless Valheim client or guarded dedicated-runtime smoke test.
ConfigManager is included only when its DLL is explicitly provided.
Copies the executable/loader/core into a unique temporary directory and links
the installed read-only game assets. Config, BepInEx output, player log, and
Valheim savedir stay in that directory; normal native engine preference access
still occurs. No existing mod/profile deployment or world/server startup.

Temporary artifacts and asset junctions are deliberately retained, never
recursively deleted. The timeout terminates only the process this script owns.

Examples:
  ./tests/RunUnitySmoke.ps1 -PrepareOnly
  ./tests/RunUnitySmoke.ps1 -AssemblyPath C:/path/to/LoadTimeProfiler.dll
  ./tests/RunUnitySmoke.ps1 -DisableStartupFeatures
  ./tests/RunUnitySmoke.ps1 -ConfigManagerAssemblyPath C:/path/to/ConfigManager.dll
  ./tests/RunUnitySmoke.ps1 -ConfigManagerAssemblyPath C:/path/to/ConfigManager.dll -ShutUpConflictFixture
  ./tests/RunUnitySmoke.ps1 -EnableConfigAutoReload -DisableStartupFeatures
  ./tests/RunUnitySmoke.ps1 -DedicatedRuntime -GameExecutable D:/path/to/valheim_server.exe -LoaderDirectory C:/path/to/Valheim -EnableConfigAutoReload

Uses the existing Release DLL by default and only compiles the probe. The
default mode enables profiling, startup acceleration and timeout protection.
The second mode disables those features while keeping independent log policies.
Both modes use two same-name plugin fixtures with different GUIDs. Initial
fixture A groups are Errors, Warnings and fixture B has all four groups.
Unconfigured plugin GUIDs default to Errors, Warnings. Unowned loggers and
Unity output always pass. All 16 group combinations use the real reload timer.
The optional Manager checks exercise real collected settings and callbacks;
headless execution does not validate the visible OnGUI rendering or controls.
They also edit isolated cfg documents containing unrelated unknown sections,
invalid sibling values and old-shaped sections without migrating those names.
ShutUpConflictFixture loads a no-op test assembly named ShutUp to exercise the
production conflict detector and read-only Manager rows. It does not execute
the original ShutUp mod or validate that mod's filtering behavior.
DedicatedRuntime requires the actual server executable and uses probe-only
Harmony guards to stop FejdStartup/ZNet Awake before platform login or world
startup. It validates server Mono/Unity/BepInEx execution, not a listening
server, multiplayer synchronization or world gameplay. Startup features stay off.
#>
param(
    [string]$AssemblyPath,
    [string]$ConfigManagerAssemblyPath,
    [string]$GameExecutable = 'C:/Program Files (x86)/Steam/steamapps/common/Valheim/valheim.exe',
    [string]$LoaderDirectory,
    [string]$BepInExCorePath = (Join-Path $env:APPDATA 'com.kesomannen.gale/valheim/profiles/worldtest/BepInEx/core'),
    [ValidateRange(10, 180)]
    [int]$TimeoutSeconds = 120,
    [switch]$PrepareOnly,
    [switch]$DisableStartupFeatures,
    [switch]$EnableConfigAutoReload,
    [switch]$DedicatedRuntime,
    [switch]$ShutUpConflictFixture
)

$ErrorActionPreference = 'Stop'
if ([Environment]::OSVersion.Platform -ne [PlatformID]::Win32NT) {
    throw 'The native smoke runner requires Windows.'
}
$GameExecutable = (Resolve-Path -LiteralPath $GameExecutable).Path
$BepInExCorePath = (Resolve-Path -LiteralPath $BepInExCorePath).Path
if (-not $AssemblyPath) { $AssemblyPath = Join-Path $PSScriptRoot '../bin/Release/LoadTimeProfiler.dll' }
$AssemblyPath = (Resolve-Path -LiteralPath $AssemblyPath).Path
if ($ConfigManagerAssemblyPath) {
    $ConfigManagerAssemblyPath = (Resolve-Path -LiteralPath $ConfigManagerAssemblyPath).Path
}
$gameSource = Split-Path $GameExecutable
$gameName = [IO.Path]::GetFileNameWithoutExtension($GameExecutable)
if ($DedicatedRuntime) {
    if ($gameName -ne 'valheim_server') { throw 'DedicatedRuntime requires valheim_server.exe.' }
    if ($ConfigManagerAssemblyPath) { throw 'DedicatedRuntime intentionally excludes the client ConfigManager UI.' }
    $DisableStartupFeatures = $true
} elseif ($gameName -eq 'valheim_server') {
    throw 'Use -DedicatedRuntime for the server executable so isolation guards are installed.'
}
if (!$LoaderDirectory) { $LoaderDirectory = $gameSource }
$LoaderDirectory = (Resolve-Path -LiteralPath $LoaderDirectory).Path
$doorstopVersion = [IO.File]::ReadAllText((Join-Path $LoaderDirectory '.doorstop_version')).Trim()
if ($doorstopVersion -ne '4.4.0') { throw "Doorstop $doorstopVersion has not been validated by this runner." }

$scratch = Join-Path ([IO.Path]::GetTempPath()) ('LoadTimeProfiler-unity-' + [Guid]::NewGuid().ToString('N'))
$game = Join-Path $scratch 'Game'
$bepRoot = Join-Path $scratch 'BepInEx'
$core = Join-Path $bepRoot 'core'
$config = Join-Path $bepRoot 'config'
$plugins = Join-Path $bepRoot 'plugins'
$patchers = Join-Path $bepRoot 'patchers'
$saves = Join-Path $scratch 'saves'
foreach ($directory in @($scratch, $game, $core, $config, $plugins, $patchers, $saves)) {
    New-Item -ItemType Directory -Path $directory | Out-Null
}
Write-Host "Native smoke artifacts: $scratch"

# Copy file contents so Gale's linked core entries do not stay linked to a profile.
foreach ($file in Get-ChildItem -LiteralPath $BepInExCorePath -File) {
    [IO.File]::Copy($file.FullName, (Join-Path $core $file.Name))
}
foreach ($name in @([IO.Path]::GetFileName($GameExecutable), 'UnityPlayer.dll', 'steam_appid.txt')) {
    [IO.File]::Copy((Join-Path $gameSource $name), (Join-Path $game $name))
}
foreach ($name in @('winhttp.dll', 'doorstop_config.ini', '.doorstop_version')) {
    [IO.File]::Copy((Join-Path $LoaderDirectory $name), (Join-Path $game $name))
}
if (Test-Path -LiteralPath (Join-Path $gameSource 'UnityCrashHandler64.exe')) {
    [IO.File]::Copy((Join-Path $gameSource 'UnityCrashHandler64.exe'), (Join-Path $game 'UnityCrashHandler64.exe'))
}
foreach ($name in @(($gameName + '_Data'), 'MonoBleedingEdge')) {
    $source = (Resolve-Path -LiteralPath (Join-Path $gameSource $name)).Path
    New-Item -ItemType Junction -Path (Join-Path $game $name) -Target $source | Out-Null
}
$temporaryExecutable = Join-Path $game ([IO.Path]::GetFileName($GameExecutable))
$preloaderPath = Join-Path $core 'BepInEx.Preloader.dll'

# Metadata only: do not execute or initialize the preloader while auditing paths.
Add-Type -Path (Join-Path $core 'Mono.Cecil.dll')
$preloader = [Mono.Cecil.AssemblyDefinition]::ReadAssembly($preloaderPath)
$bepAssembly = [Mono.Cecil.AssemblyDefinition]::ReadAssembly((Join-Path $core 'BepInEx.dll'))
try {
    $runnerType = $preloader.MainModule.Types | Where-Object FullName -eq 'BepInEx.Preloader.PreloaderRunner'
    $runner = $runnerType.Methods | Where-Object Name -eq 'PreloaderPreMain'
    $envType = $preloader.MainModule.Types | Where-Object FullName -eq 'BepInEx.Preloader.EnvVars'
    $envMethod = $envType.Methods | Where-Object Name -eq 'LoadVars'
    $entryType = $preloader.MainModule.Types | Where-Object FullName -eq 'Doorstop.Entrypoint'
    $entryMethod = $entryType.Methods | Where-Object Name -eq 'Start'
    $pathsType = $bepAssembly.MainModule.Types | Where-Object FullName -eq 'BepInEx.Paths'
    $pathsMethod = $pathsType.Methods | Where-Object Name -eq 'SetExecutablePath'
    if (!$runner -or !$envMethod -or !$entryMethod -or !$pathsMethod) { throw 'Required preloader path methods are absent.' }
    $runnerIl = @($runner.Body.Instructions | ForEach-Object ToString)
    $envIl = @($envMethod.Body.Instructions | ForEach-Object ToString)
    $pathsIl = @($pathsMethod.Body.Instructions | ForEach-Object ToString)
    $entryIl = @($entryMethod.Body.Instructions | ForEach-Object ToString)
    $runnerText = $runnerIl -join "`n"
    $envText = $envIl -join "`n"
    $pathsText = $pathsIl -join "`n"
    if ($runnerText -notmatch '(?s)get_DOORSTOP_INVOKE_DLL_PATH\(\).*GetFullPath\(System.String\).*ldc.i4.2.*ParentDirectory\(System.String,System.Int32\).*SetExecutablePath\(System.String,System.String,System.String,System.String\[\]\)' -or
        $envText -notmatch '(?s)ldstr "DOORSTOP_INVOKE_DLL_PATH".*GetEnvironmentVariable\(System.String\).*set_DOORSTOP_INVOKE_DLL_PATH' -or
        $pathsText -notmatch '(?s)ldarg.1.*brtrue.*set_BepInExRootPath\(System.String\).*set_ConfigPath\(System.String\).*set_PluginPath\(System.String\).*set_PatcherPluginPath\(System.String\)') {
        throw 'Preloader target-to-root isolation could not be verified. No native process was launched.'
    }
    if ([IO.Path]::GetDirectoryName([IO.Path]::GetDirectoryName($preloaderPath)) -ne $bepRoot) {
        throw 'Target preloader does not resolve to the temporary BepInEx root.'
    }
    $audit = @("BepInEx: $($bepAssembly.Name.FullName)", "Doorstop: $doorstopVersion", "Executable: $temporaryExecutable", "Target: $preloaderPath", "Expected BepInEx root: $bepRoot", '', 'PreloaderRunner:') + $runnerIl + @('', 'EnvVars:') + $envIl + @('', 'Paths:') + $pathsIl + @('', 'Emergency log path (temporary executable directory):') + $entryIl
    [IO.File]::WriteAllLines((Join-Path $scratch 'isolation-audit.txt'), [string[]]$audit)
}
finally {
    $preloader.Dispose()
    $bepAssembly.Dispose()
}

$projectPath = Join-Path $PSScriptRoot '../LoadTimeProfiler.csproj'
$propertyJson = & dotnet msbuild $projectPath -nologo '-getProperty:MSBuildToolsPath,TargetFrameworkVersion'
if ($LASTEXITCODE -ne 0) { throw 'Could not evaluate compiler paths.' }
$properties = ($propertyJson -join [Environment]::NewLine | ConvertFrom-Json).Properties
# The product may be built against publicized reference assemblies. Runtime
# assets come only from the installed game's normal data directory junction.
# Never run the main project's deployment/package targets from this runner.
[IO.File]::Copy($AssemblyPath, (Join-Path $patchers 'LoadTimeProfiler.dll'))
$managerCopyPath = $null
if ($ConfigManagerAssemblyPath) {
    $managerCopyPath = Join-Path $plugins 'ConfigManager.dll'
    [IO.File]::Copy($ConfigManagerAssemblyPath, $managerCopyPath)
}

$framework = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8'
$managed = Join-Path $game ($gameName + '_Data/Managed')
$compiler = Join-Path $properties.MSBuildToolsPath 'Roslyn/bincore/csc.dll'
$probePath = Join-Path $plugins 'LoadTimeProfiler.UnitySmokeProbe.dll'
$references = @(
    (Join-Path $framework 'mscorlib.dll'),
    (Join-Path $framework 'System.dll'),
    (Join-Path $framework 'System.Core.dll'),
    (Join-Path $framework 'Facades/netstandard.dll'),
    (Join-Path $core 'BepInEx.dll'),
    (Join-Path $core '0Harmony.dll'),
    (Join-Path $managed 'UnityEngine.dll'),
    (Join-Path $managed 'UnityEngine.CoreModule.dll')
)
$compilerArguments = @('-nologo', '-noconfig', '-nostdlib+', '-target:library', '-platform:x64', '-optimize+', "-out:$probePath")
$compilerArguments += $references | ForEach-Object { "-reference:$_" }
$compilerArguments += Join-Path $PSScriptRoot 'UnitySmokeProbe.cs'
& dotnet $compiler @compilerArguments
if ($LASTEXITCODE -ne 0) { throw 'Unity smoke probe compilation failed.' }

$utf8 = New-Object Text.UTF8Encoding($false)
if ($ShutUpConflictFixture) {
    $fixtureSourcePath = Join-Path $scratch 'ShutUpIdentityFixture.cs'
    $fixtureAssemblyPath = Join-Path $patchers 'ShutUp.dll'
    # Name-only conflict detection is the product contract. This fixture has
    # no log patches, and must not be mistaken for the original ShutUp mod.
    $fixtureSource = @'
using System.Collections.Generic;
using Mono.Cecil;
public static class ShutUpIdentityFixture
{
    public static IEnumerable<string> TargetDLLs { get { return new string[0]; } }
    public static void Initialize() { }
    public static void Patch(AssemblyDefinition assembly) { }
}
'@
    [IO.File]::WriteAllText($fixtureSourcePath, $fixtureSource, $utf8)
    $fixtureArguments = @('-nologo', '-noconfig', '-nostdlib+', '-target:library', '-platform:x64', '-optimize+', "-out:$fixtureAssemblyPath")
    $fixtureArguments += $references | ForEach-Object { "-reference:$_" }
    $fixtureArguments += "-reference:$(Join-Path $core 'Mono.Cecil.dll')"
    $fixtureArguments += $fixtureSourcePath
    & dotnet $compiler @fixtureArguments
    if ($LASTEXITCODE -ne 0) { throw 'ShutUp identity fixture compilation failed.' }
}
$bepConfig = @'
[Logging]
UnityLogListening = true
LogConsoleToUnityLog = false
[Logging.Console]
Enabled = false
[Logging.Disk]
Enabled = true
AppendLog = false
WriteUnityLog = true
LogLevels = All
[Preloader]
DumpAssemblies = false
LoadDumpedAssemblies = false
'@
[IO.File]::WriteAllText((Join-Path $config 'BepInEx.cfg'), $bepConfig, $utf8)
$startupEnabled = if ($DisableStartupFeatures) { 'false' } else { 'true' }
$connectionTimeout = if ($DisableStartupFeatures) { '0' } else { '120' }
$autoReloadEnabled = if ($EnableConfigAutoReload) { 'true' } else { 'false' }
$productConfig = @"
[General]
ProfilingEnabled = $startupEnabled
LocalizationCacheEnabled = $startupEnabled
ConfigWriteCoalescingEnabled = $startupEnabled
ConfigAutoReloadEnabled = $autoReloadEnabled
TimeoutProtectionSeconds = $connectionTimeout

[Logging.Mods]
sighsorry.LoadTimeProfiler.SmokeA = Errors, Warnings
sighsorry.LoadTimeProfiler.SmokeB = Errors, Warnings, Information, Debug
sighsorry.LoadTimeProfiler.SavedUnloaded = None
"@
[IO.File]::WriteAllText((Join-Path $config 'sighsorry.LoadTimeProfiler.cfg'), $productConfig, $utf8)
$doorstopConfigPath = Join-Path $game 'doorstop_config.ini'
$doorstopConfig = [IO.File]::ReadAllText($doorstopConfigPath)
$doorstopConfig = [regex]::Replace($doorstopConfig, '(?m)^target_assembly\s*=.*$', ('target_assembly=' + $preloaderPath))
[IO.File]::WriteAllText($doorstopConfigPath, $doorstopConfig, $utf8)

$launchArguments = @('-batchmode', '-nographics', '-savedir', $saves, '-logFile', (Join-Path $scratch 'Player.log'), '--doorstop-target-assembly', $preloaderPath)
$plan = [ordered]@{
    Executable = $temporaryExecutable
    Arguments = $launchArguments
    WorkingDirectory = $game
    BepInExRoot = $bepRoot
    ProductAssembly = $AssemblyPath
    ProductSha256 = (Get-FileHash -LiteralPath (Join-Path $patchers 'LoadTimeProfiler.dll') -Algorithm SHA256).Hash
    ProductConfig = Join-Path $config 'sighsorry.LoadTimeProfiler.cfg'
    ConfigManagerAssembly = $ConfigManagerAssemblyPath
    ConfigManagerSha256 = $(if ($managerCopyPath) { (Get-FileHash -LiteralPath $managerCopyPath -Algorithm SHA256).Hash } else { $null })
    StartupFeaturesEnabled = !$DisableStartupFeatures
    ConfigAutoReloadEnabled = [bool]$EnableConfigAutoReload
    ShutUpConflictFixture = [bool]$ShutUpConflictFixture
    ConflictScope = $(if ($ShutUpConflictFixture) { 'No-op assembly identity fixture, not the original ShutUp mod' } else { 'No conflict fixture' })
    TimeoutSeconds = $TimeoutSeconds
    Mode = $(if ($DedicatedRuntime) { 'actual dedicated runtime; probe guards prevent platform login/world/network startup' } else { 'headless client, not dedicated server' })
    LoaderDirectory = $LoaderDirectory
}
[IO.File]::WriteAllText((Join-Path $scratch 'launch-plan.json'), ($plan | ConvertTo-Json -Depth 4), $utf8)
if ($PrepareOnly) { Write-Host 'Prepared and inspected only; no Valheim process launched.'; return }

$start = New-Object Diagnostics.ProcessStartInfo
$start.FileName = $temporaryExecutable
$start.WorkingDirectory = $game
$start.UseShellExecute = $false
$start.CreateNoWindow = $true
$start.WindowStyle = [Diagnostics.ProcessWindowStyle]::Hidden
$start.Arguments = ($launchArguments | ForEach-Object {
    if ($_.Contains('"') -or $_.EndsWith('\')) { throw 'Unexpected unsafe process argument.' }
    '"' + $_ + '"'
}) -join ' '
foreach ($key in @($start.EnvironmentVariables.Keys)) {
    if ($key.StartsWith('DOORSTOP_', [StringComparison]::OrdinalIgnoreCase) -or $key -eq 'MONO_PATH' -or $key -eq 'MONO_ENV_OPTIONS') {
        $start.EnvironmentVariables.Remove($key)
    }
}
$start.EnvironmentVariables['LOADTIMEPROFILER_SMOKE_ROOT'] = $bepRoot
$start.EnvironmentVariables['LOADTIMEPROFILER_SMOKE_STARTUP'] = if ($DisableStartupFeatures) { 'disabled' } else { 'enabled' }
$start.EnvironmentVariables['LOADTIMEPROFILER_SMOKE_AUTO_RELOAD'] = if ($EnableConfigAutoReload) { 'enabled' } else { 'disabled' }
$start.EnvironmentVariables['LOADTIMEPROFILER_SMOKE_DEDICATED'] = if ($DedicatedRuntime) { 'enabled' } else { 'disabled' }
$start.EnvironmentVariables['LOADTIMEPROFILER_SMOKE_SHUTUP_FIXTURE'] = if ($ShutUpConflictFixture) { 'enabled' } else { 'disabled' }
if ($managerCopyPath) {
    $start.EnvironmentVariables['LOADTIMEPROFILER_SMOKE_CONFIG_MANAGER'] = $managerCopyPath
} else {
    $start.EnvironmentVariables.Remove('LOADTIMEPROFILER_SMOKE_CONFIG_MANAGER')
}
$process = New-Object Diagnostics.Process
$process.StartInfo = $start
$started = $false
try {
    if (!$process.Start()) { throw 'Could not launch the isolated Valheim process.' }
    $started = $true
    Write-Host "Launched isolated native smoke PID $($process.Id). DedicatedRuntime=$DedicatedRuntime"
    $deadline = [DateTime]::UtcNow.AddSeconds($TimeoutSeconds)
    while (!$process.WaitForExit(1000)) {
        if ([DateTime]::UtcNow -ge $deadline) {
            $process.Kill()
            $process.WaitForExit(5000) | Out-Null
            throw "Native smoke timed out; terminated only owned PID $($process.Id). Artifacts: $scratch"
        }
    }
    # Persist the actual owned native process exit before any result parsing.
    [IO.File]::WriteAllText((Join-Path $scratch 'process-exit-code.txt'), [string]$process.ExitCode, $utf8)
    Write-Host "Native process exit code: $($process.ExitCode)"
    $resultPath = Join-Path $bepRoot 'UnitySmokeResult.txt'
    if (!(Test-Path -LiteralPath $resultPath)) { throw "Probe did not produce a result. Exit=$($process.ExitCode); inspect $scratch" }
    $results = [IO.File]::ReadAllText($resultPath)
    Write-Host $results
    if ($process.ExitCode -ne 0 -or $results -notmatch '(?m)^STATUS=PASS\r?$') {
        throw "Native Unity smoke failed. Exit=$($process.ExitCode); inspect $scratch"
    }
    Write-Host "Native smoke passed. DedicatedRuntime=$DedicatedRuntime. No server-world or multiplayer validation."
    [IO.File]::WriteAllText((Join-Path $scratch 'runner-status.txt'), 'PASS; native process exit=0; runner completed successfully', $utf8)
}
finally {
    if ($started -and !$process.HasExited) {
        $process.Kill()
        $process.WaitForExit(5000) | Out-Null
    }
    $process.Dispose()
}
