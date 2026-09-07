<#
Build and exercise the real DLL in an isolated .NET Framework process.
Requires the same local Valheim/BepInEx references as the main project and
the .NET Framework 4.8 targeting pack. Does not launch or deploy to the game.

Examples:
  ./tests/RunRegressionTests.ps1
  ./tests/RunRegressionTests.ps1 -Configuration Release
  ./tests/RunRegressionTests.ps1 -AssemblyPath C:/path/to/baseline/LoadTimeProfiler.dll
#>
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Debug',
    [string]$AssemblyPath
)

$ErrorActionPreference = 'Stop'
$projectPath = Join-Path $PSScriptRoot '../LoadTimeProfiler.csproj'
$testDirectory = Join-Path ([IO.Path]::GetTempPath()) ('LoadTimeProfiler-tests-' + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $testDirectory | Out-Null
Write-Host "Test artifacts: $testDirectory"

$propertyJson = & dotnet msbuild $projectPath -nologo '-getProperty:BepInExPath,CorlibPath,PublicizedAssembliesPath'
if ($LASTEXITCODE -ne 0) { throw 'Could not evaluate project references.' }
$referencePaths = ($propertyJson -join [Environment]::NewLine | ConvertFrom-Json).Properties

if (-not $AssemblyPath) {
    & dotnet msbuild $projectPath -nologo -t:Rebuild "-p:Configuration=$Configuration" '-p:CopyOutputDLLPath=' '-p:SkipReleasePackage=true' "-p:OutputPath=$testDirectory/bin/" "-p:IntermediateOutputPath=$testDirectory/obj/" -v:minimal
    if ($LASTEXITCODE -ne 0) { throw 'Product build failed.' }
    $AssemblyPath = Join-Path $testDirectory 'bin/LoadTimeProfiler.dll'
}
$AssemblyPath = (Resolve-Path -LiteralPath $AssemblyPath).Path

$frameworkReferences = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8'
$bepInExCore = Join-Path $referencePaths.BepInExPath 'core'
$sdkVersion = (& dotnet --version).Trim()
$compiler = Join-Path (Split-Path (Get-Command dotnet).Source) "sdk/$sdkVersion/Roslyn/bincore/csc.dll"
$executable = Join-Path $testDirectory 'RegressionTests.exe'
$references = @(
    (Join-Path $frameworkReferences 'mscorlib.dll'),
    (Join-Path $frameworkReferences 'System.dll'),
    (Join-Path $frameworkReferences 'System.Core.dll'),
    (Join-Path $frameworkReferences 'Facades/netstandard.dll'),
    (Join-Path $bepInExCore 'BepInEx.dll'),
    (Join-Path $bepInExCore '0Harmony.dll'),
    (Join-Path $referencePaths.PublicizedAssembliesPath 'assembly_valheim_publicized.dll'),
    (Join-Path $referencePaths.CorlibPath 'assembly_guiutils.dll'),
    (Join-Path $referencePaths.CorlibPath 'UnityEngine.dll'),
    (Join-Path $referencePaths.CorlibPath 'UnityEngine.CoreModule.dll')
)
$compilerArguments = @('-nologo', '-noconfig', '-nostdlib+', '-target:exe', '-platform:x64', '-optimize+', "-out:$executable")
$compilerArguments += $references | ForEach-Object { "-reference:$_" }
$compilerArguments += Join-Path $PSScriptRoot 'RegressionTests.cs'
& dotnet $compiler @compilerArguments
if ($LASTEXITCODE -ne 0) { throw 'Regression harness compilation failed.' }

# Downloaded BepInEx dependencies may retain a zone marker. This applies only
# to the disposable test executable; no game or machine configuration changes.
[IO.File]::WriteAllText("$executable.config", '<configuration><runtime><loadFromRemoteSources enabled="true" /></runtime></configuration>')
& $executable $AssemblyPath $bepInExCore $referencePaths.CorlibPath $referencePaths.PublicizedAssembliesPath $testDirectory
if ($LASTEXITCODE -ne 0) { throw 'Regression tests failed. See individual failures above.' }
