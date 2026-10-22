$module = 'ATEMModule'
Push-Location $PSScriptroot

$buildOutput = Join-Path $PSScriptRoot 'output\ATEMModule\bin'
New-Item -ItemType Directory -Force -Path $buildOutput | Out-Null

dotnet build "$PSScriptRoot\src\ATEMModule.csproj" -o $buildOutput

$moduleFiles = @(
    (Join-Path $PSScriptRoot 'src\ATEMModule.psd1'),
    (Join-Path $PSScriptRoot 'src\ATEMModule.psm1')
)

foreach ($file in $moduleFiles) {
    if (Test-Path $file) {
        Copy-Item $file (Join-Path $PSScriptRoot 'output\ATEMModule') -Force
    }
}

# start a new PS Session and load module
#Import-Module "$PSScriptRoot\Output\$module\$module.psd1"

# Debug module
# https://docs.microsoft.com/en-us/powershell/scripting/dev-cross-plat/vscode/using-vscode-for-debugging-compiled-cmdlets?view=powershell-7.1

#Invoke-Pester "$PSScriptRoot\Tests"

# For help files - look into https://github.com/red-gate/XmlDoc2CmdletDoc

# Create Module manifest (one time. Need to update exported functions)
$manifestSplat = @{
    Path              = ".\$module\$module.psd1"
    Author            = 'Ian Morrish'
    NestedModules     = @('bin\ATEMModule.dll')
    RootModule        = "$module.psm1"
    FunctionsToExport = @()
}