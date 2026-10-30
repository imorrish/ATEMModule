# Hardware-free upload resolution regression checks. Build the module first.
# Windows specific setup for testing media still resolution checks

$ErrorActionPreference = 'Stop'
$binPath = Join-Path $PSScriptRoot '..\output\ATEMModule\bin'
Import-Module (Join-Path $binPath 'ATEMModule.dll') -Force
Add-Type -Path (Join-Path $binPath 'SixLabors.ImageSharp.dll')
Add-Type -Path (Join-Path $binPath 'LibAtem.dll')

$paths = @()
try {
    foreach ($dimensions in @(@(1890, 1080), @(1920, 1079), @(1920, 1080), @(1280, 720))) {
        $path = [System.IO.Path]::GetTempFileName()
        $paths += $path
        $image = [SixLabors.ImageSharp.Image[SixLabors.ImageSharp.PixelFormats.Rgba32]]::new($dimensions[0], $dimensions[1])
        try {
            [SixLabors.ImageSharp.ImageExtensions]::SaveAsPng($image, $path)
        }
        finally {
            $image.Dispose()
        }
    }

    function Assert-UploadError {
        param([string] $Path, [string] $Expected, [hashtable] $ExtraParameters)

        $client = [LibAtem.Net.AtemClient]::new('127.0.0.1', $false)
        try {
            try {
                Set-ATEMMediaPoolStillFrame -ATEMref $client -stillID 0 -FilePath $Path -TimeoutSeconds 1 @ExtraParameters
                throw 'Expected the upload to fail.'
            }
            catch {
                if ($_.Exception.Message -notlike "*$Expected*") {
                    throw
                }
            }
        }
        finally {
            $client.Dispose()
        }
    }

    Assert-UploadError $paths[0] 'Image is 1890x1080, but resolution _1080 requires 1920x1080' @{}
    Assert-UploadError $paths[1] 'Image is 1920x1079, but resolution _1080 requires 1920x1080' @{}
    Assert-UploadError $paths[2] 'Image is 1920x1080, but resolution _720 requires 1280x720' @{ Resolution = '_720' }
    Assert-UploadError $paths[2] 'Timed out uploading media still' @{}
    Assert-UploadError $paths[3] 'Timed out uploading media still' @{ Resolution = '_720' }
    Assert-UploadError $paths[2] 'Invalid video resolution: 42' @{
        Resolution = [System.Enum]::ToObject([LibAtem.Common.VideoModeResolution], 42)
    }
    Write-Host 'Media still resolution checks passed.'
}
finally {
    foreach ($path in $paths) {
        Remove-Item -LiteralPath $path -ErrorAction Stop
    }
}
