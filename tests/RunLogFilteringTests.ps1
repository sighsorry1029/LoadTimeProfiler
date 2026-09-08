<#
Build and test LoadTimeProfiler in a disposable .NET Framework process, then measure
the managed logging paths. Requires Windows, .NET Framework 4.8 references,
a current .NET SDK, and the BepInEx references configured by LoadTimeProfiler.csproj.
Does not launch, patch on disk, or deploy to Valheim. ShutUp is not loaded.

Examples:
  ./tests/RunLogFilteringTests.ps1
  ./tests/RunLogFilteringTests.ps1 -Configuration Debug -Iterations 10000
  ./tests/RunLogFilteringTests.ps1 -AssemblyPath C:/path/to/LoadTimeProfiler.dll -SkipBenchmark
#>
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release',
    [string]$AssemblyPath,
    [string]$BepInExPath,
    [string]$CorlibPath,
    [switch]$SkipBenchmark,
    [ValidateRange(1000, 1000000)]
    [int]$Iterations = 20000
)

$ErrorActionPreference = 'Stop'
if ([Environment]::OSVersion.Platform -ne [PlatformID]::Win32NT) {
    throw 'These tests require the Windows .NET Framework runtime.'
}
$projectPath = Join-Path $PSScriptRoot '../LoadTimeProfiler.csproj'
$scratch = Join-Path ([IO.Path]::GetTempPath()) ('LoadTimeProfiler-logging-tests-' + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $scratch | Out-Null
Write-Host "Test artifacts: $scratch"

$referenceArguments = @()
if ($BepInExPath) { $referenceArguments += "-p:BepInExPath=$BepInExPath" }
if ($CorlibPath) { $referenceArguments += "-p:CorlibPath=$CorlibPath" }
$propertyJson = & dotnet msbuild $projectPath -nologo "-p:Configuration=$Configuration" @referenceArguments '-getProperty:BepInExPath,CorlibPath,MSBuildToolsPath'
if ($LASTEXITCODE -ne 0) { throw 'Could not evaluate the LoadTimeProfiler build references.' }
$properties = ($propertyJson -join [Environment]::NewLine | ConvertFrom-Json).Properties
if (-not $AssemblyPath) {
    & dotnet msbuild $projectPath -nologo -restore -t:Rebuild "-p:Configuration=$Configuration" @referenceArguments '-p:CopyOutputDLLPath=' '-p:SkipReleasePackage=true' "-p:OutputPath=$scratch/bin/" "-p:IntermediateOutputPath=$scratch/obj/" "-p:BaseIntermediateOutputPath=$scratch/obj/" -v:minimal
    if ($LASTEXITCODE -ne 0) { throw 'LoadTimeProfiler build failed.' }
    $AssemblyPath = Join-Path $scratch 'bin/LoadTimeProfiler.dll'
}
$AssemblyPath = (Resolve-Path -LiteralPath $AssemblyPath).Path

$framework = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8'
$core = Join-Path $properties.BepInExPath 'core'
$compiler = Join-Path $properties.MSBuildToolsPath 'Roslyn/bincore/csc.dll'
$executable = Join-Path $scratch 'LoadTimeProfiler.LoggingTests.exe'
$references = @(
    (Join-Path $framework 'mscorlib.dll'),
    (Join-Path $framework 'System.dll'),
    (Join-Path $framework 'System.Core.dll'),
    (Join-Path $framework 'Facades/netstandard.dll'),
    (Join-Path $core 'BepInEx.dll'),
    (Join-Path $core '0Harmony.dll'),
    (Join-Path $core 'Mono.Cecil.dll'),
    (Join-Path $properties.CorlibPath 'UnityEngine.CoreModule.dll')
)
$arguments = @('-nologo', '-noconfig', '-nostdlib+', '-target:exe', '-platform:x64', '-optimize+', "-out:$executable")
$arguments += $references | ForEach-Object { "-reference:$_" }
$arguments += Join-Path $PSScriptRoot 'LogFilteringTests.cs'
& dotnet $compiler @arguments
if ($LASTEXITCODE -ne 0) { throw 'LoadTimeProfiler test harness compilation failed.' }
[IO.File]::WriteAllText("$executable.config", '<configuration><runtime><loadFromRemoteSources enabled="true" /></runtime></configuration>')
$runtimeArguments = @($AssemblyPath, $core, $properties.CorlibPath, $scratch, $Iterations)
if ($SkipBenchmark) { $runtimeArguments += '--skip-benchmark' }
& $executable @runtimeArguments
if ($LASTEXITCODE -ne 0) { throw 'LoadTimeProfiler tests failed. See the individual failures above.' }
