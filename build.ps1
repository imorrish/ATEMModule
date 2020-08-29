$module = 'ATEMModule'
Push-Location $PSScriptroot

dotnet build $PSScriptRoot\src -o $PSScriptRoot\output\$module\bin
Copy-Item "$PSScriptRoot\$module\*" "$PSScriptRoot\output\$module" -Recurse -Force

Import-Module "$PSScriptRoot\Output\$module\$module.psd1"
#Invoke-Pester "$PSScriptRoot\Tests"

# For help files - look into https://github.com/red-gate/XmlDoc2CmdletDoc

# Create Module manifest
$manifestSplat = @{
    Path              = ".\$module\$module.psd1"
    Author            = 'Ian Morrish'
    NestedModules     = @('bin\ATEMModule.dll')
    RootModule        = "$module.psm1"
    FunctionsToExport = @()
}