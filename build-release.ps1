param(
    [string] $OutputPath = (Join-Path $PSScriptRoot 'artifacts\releases'),
    [switch] $Force
)

$ErrorActionPreference = 'Stop'
$manifest = Import-PowerShellDataFile (Join-Path $PSScriptRoot 'src\ATEMModule.psd1')
$version = $manifest.ModuleVersion
$outputDirectory = [System.IO.Path]::GetFullPath($OutputPath)
$platforms = @('windows', 'linux', 'macos')
$archives = foreach ($platform in $platforms) {
    Join-Path $outputDirectory "ATEMModule-$version-$platform.zip"
}

foreach ($archive in $archives) {
    if ((Test-Path -LiteralPath $archive) -and -not $Force) {
        throw "Archive already exists: $archive. Use -Force to replace it."
    }
}

$staging = Join-Path ([System.IO.Path]::GetTempPath()) "ATEMModule-release-$([guid]::NewGuid())"
try {
    $buildOutput = Join-Path $staging 'build'
    $moduleDirectory = Join-Path $staging 'package\ATEMModule'
    $binDirectory = Join-Path $moduleDirectory 'bin'
    New-Item -ItemType Directory -Path $buildOutput, $binDirectory, $outputDirectory -Force | Out-Null

    dotnet build (Join-Path $PSScriptRoot 'src\ATEMModule.csproj') --configuration Release --no-restore --output $buildOutput
    if ($LASTEXITCODE -ne 0) {
        throw "Release build failed with exit code $LASTEXITCODE."
    }

    Get-ChildItem -LiteralPath $buildOutput -File |
        Where-Object { $_.Extension -ne '.pdb' -and $_.Name -ne 'System.Management.Automation.dll' } |
        Copy-Item -Destination $binDirectory
    Get-ChildItem -LiteralPath $buildOutput -Directory |
        Copy-Item -Destination $binDirectory -Recurse
    Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'src\ATEMModule.psd1'), (Join-Path $PSScriptRoot 'src\ATEMModule.psm1'), (Join-Path $PSScriptRoot 'README.md'), (Join-Path $PSScriptRoot 'LICENSE') -Destination $moduleDirectory
    Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'LibAtem\LICENSE') -Destination (Join-Path $moduleDirectory 'LICENSE.LibAtem')

    $assets = Get-Content -LiteralPath (Join-Path $PSScriptRoot 'src\obj\project.assets.json') -Raw | ConvertFrom-Json
    $imageSharp = @($assets.libraries.PSObject.Properties | Where-Object { $_.Name -like 'SixLabors.ImageSharp/*' })
    if ($imageSharp.Count -ne 1) {
        throw 'Could not identify the restored ImageSharp package.'
    }
    $imageSharpLicense = $null
    foreach ($packageFolder in $assets.packageFolders.PSObject.Properties.Name) {
        $candidate = Join-Path (Join-Path $packageFolder $imageSharp[0].Value.path) 'LICENSE'
        if (Test-Path -LiteralPath $candidate) {
            $imageSharpLicense = $candidate
            break
        }
    }
    if (-not $imageSharpLicense) {
        throw 'Could not find the restored ImageSharp license.'
    }
    Copy-Item -LiteralPath $imageSharpLicense -Destination (Join-Path $moduleDirectory 'LICENSE.ImageSharp')

    foreach ($archive in $archives) {
        Compress-Archive -Path $moduleDirectory -DestinationPath $archive -Force:$Force
        Write-Host "Created $archive"
    }
}
finally {
    if (Test-Path -LiteralPath $staging) {
        Remove-Item -LiteralPath $staging -Recurse -Force
    }
}
