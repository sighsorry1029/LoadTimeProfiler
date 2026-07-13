param(
    [Parameter(Mandatory = $true)]
    [string]$ProjectDir,

    [Parameter(Mandatory = $true)]
    [string]$TargetPath,

    [Parameter(Mandatory = $true)]
    [string]$PackageName
)

$ErrorActionPreference = "Stop"

$version = [System.Reflection.AssemblyName]::GetAssemblyName($TargetPath).Version.ToString(3)
$thunderstoreDir = Join-Path $ProjectDir "Thunderstore"
$manifestPath = Join-Path $thunderstoreDir "manifest.json"
$readmePath = Join-Path $ProjectDir "README.md"
$changelogPath = Join-Path $thunderstoreDir "CHANGELOG.md"
$iconPath = Join-Path $thunderstoreDir "icon.png"

foreach ($requiredPath in @($manifestPath, $readmePath, $changelogPath, $iconPath)) {
    if (-not (Test-Path -LiteralPath $requiredPath -PathType Leaf)) {
        throw "Required package file was not found: $requiredPath"
    }
}

$manifest = Get-Content -LiteralPath $manifestPath -Raw | ConvertFrom-Json
$manifest.version_number = $version
$manifestJson = $manifest | ConvertTo-Json -Depth 16
$utf8WithoutBom = New-Object System.Text.UTF8Encoding($false)
[System.IO.File]::WriteAllText($manifestPath, $manifestJson + [Environment]::NewLine, $utf8WithoutBom)

Get-ChildItem -LiteralPath $thunderstoreDir -Filter "$PackageName-*.zip" -File -ErrorAction SilentlyContinue |
    Remove-Item -Force

$stagingDir = Join-Path ([System.IO.Path]::GetTempPath()) ($PackageName + "-Thunderstore-" + [Guid]::NewGuid().ToString("N"))
try {
    $patchersDir = Join-Path $stagingDir "patchers"
    New-Item -ItemType Directory -Path $patchersDir -Force | Out-Null

    Copy-Item -LiteralPath $TargetPath -Destination (Join-Path $patchersDir ([System.IO.Path]::GetFileName($TargetPath))) -Force
    Copy-Item -LiteralPath $readmePath -Destination (Join-Path $stagingDir "README.md") -Force
    Copy-Item -LiteralPath $changelogPath -Destination (Join-Path $stagingDir "CHANGELOG.md") -Force
    Copy-Item -LiteralPath $iconPath -Destination (Join-Path $stagingDir "icon.png") -Force
    [System.IO.File]::WriteAllText(
        (Join-Path $stagingDir "manifest.json"),
        $manifestJson + [Environment]::NewLine,
        $utf8WithoutBom)

    $zipPath = Join-Path $thunderstoreDir ($PackageName + "-" + $version + ".zip")
    Compress-Archive -Path (Join-Path $stagingDir "*") -DestinationPath $zipPath -Force
    Write-Host "Created Thunderstore package: $zipPath"
}
finally {
    Remove-Item -LiteralPath $stagingDir -Recurse -Force -ErrorAction SilentlyContinue
}
