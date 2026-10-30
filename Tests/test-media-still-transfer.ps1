# Test script for media still upload/download support.
# Update the ATEM IP to match your switch before running.
#
# Example:
#   pwsh ./Tests/test-media-still-transfer.ps1 -UploadPath ./image-1920x1080.png -Resolution _1080
#
# Requires the module to be built first:
#   dotnet build src -o output/ATEMModule/bin

param(
    [Parameter(Mandatory = $true)]
    [string] $UploadPath,

    [ValidateSet('NTSC', 'PAL', '_720', '_1080', '_4K', '_8K')]
    [string] $Resolution = '_1080',

    [string] $AtemIp = '192.168.1.124',
    [uint32] $StillIndex = 12
)

$ErrorActionPreference = 'Stop'

$modulePath = Join-Path $PSScriptRoot '..\output\ATEMModule\bin\ATEMModule.dll'
if (-not (Test-Path $modulePath)) {
    $modulePath = "e:\Git\ATEMModule\output\ATEMModule\bin\ATEMModule.dll"
    #throw "ATEMModule.dll not found at '$modulePath'. Build the module first with: dotnet build src -o output/ATEMModule/bin"
}

# $uploadPath = "C:\Users\imorrish\Documents\ATEM Media Pool\Design.png"
Import-Module $modulePath -Force
$downloadPath = Join-Path ([System.IO.Path]::GetTempPath()) "atem-media-still-download-$([guid]::NewGuid()).png"

$atem = Add-ATEMSwitch -IPAddress $AtemIp

Write-Host "Uploading still at index $StillIndex from $UploadPath"
Set-ATEMMediaPoolStillFrame -ATEMref $atem -stillID $StillIndex -FilePath $UploadPath -Resolution $Resolution -TimeoutSeconds 10 | Out-Null
# Set-ATEMMediaPoolStillFrame -ATEMref $atem -stillID $StillIndex -FilePath $UploadPath -Resolution $Resolution -TimeoutSeconds 10 | Out-Null

Write-Host "Downloading still at index $StillIndex to $downloadPath"
Get-ATEMMediaPoolStillFrame -ATEMref $atem -stillID $StillIndex -FilePath $downloadPath -Resolution $Resolution -TimeoutSeconds 60 | Out-Null

if (-not (Test-Path $downloadPath)) {
    throw "Download did not create '$downloadPath'."
}

Get-Item $downloadPath | Select-Object FullName, Length
Write-Host "Transfer completed. Compare the downloaded image with the original."
