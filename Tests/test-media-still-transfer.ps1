# Test script for media still upload/download support.
# Update the ATEM IP to match your switch before running.
#
# Example:
#   pwsh ./Tests/test-media-still-transfer.ps1
#
# Requires the module to be built first:
#   dotnet build src -o output/ATEMModule/bin

$ErrorActionPreference = 'Stop'

$modulePath = Join-Path $PSScriptRoot '..\output\ATEMModule\bin\ATEMModule.dll'
if (-not (Test-Path $modulePath)) {
    throw "ATEMModule.dll not found at '$modulePath'. Build the module first with: dotnet build src -o output/ATEMModule/bin"
}

Import-Module $modulePath -Force

$atemIp = '192.168.1.8'
$stillIndex = 0
$uploadPath = Join-Path $env:TEMP 'atem-media-still-upload.png'
$downloadPath = Join-Path $env:TEMP 'atem-media-still-download.png'

# Create a small 32x32 test PNG without depending on external image tooling.
$pngBase64 = 'iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAF' +
             'cicLAAAAAklEQVR42mP8z8AARQAB6wZ9qQAAAABJRU5ErkJggg=='
[System.IO.File]::WriteAllBytes($uploadPath, [System.Convert]::FromBase64String($pngBase64))

if (Test-Path $downloadPath) {
    Remove-Item $downloadPath -Force
}

$atem = Add-ATEMSwitch -IPAddress $atemIp

Write-Host "Uploading still at index $stillIndex from $uploadPath"
Set-ATEMMediaPoolStillFrame -ATEMref $atem -stillID $stillIndex -FilePath $uploadPath -TimeoutSeconds 60 | Out-Null

Write-Host "Downloading still at index $stillIndex to $downloadPath"
Get-ATEMMediaPoolStillFrame -ATEMref $atem -stillID $stillIndex -FilePath $downloadPath -TimeoutSeconds 60 | Out-Null

if (-not (Test-Path $downloadPath)) {
    throw "Download did not create '$downloadPath'."
}

Get-Item $downloadPath | Select-Object FullName, Length
Write-Host "Media still upload/download test completed successfully."
