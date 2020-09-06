$module = 'ATEMModule'
Push-Location $PSScriptroot

dotnet build $PSScriptRoot\src -o $PSScriptRoot\output\$module\bin
Copy-Item "$PSScriptRoot\$module\*" "$PSScriptRoot\output\$module" -Recurse -Force

# start a new PS Session and load module
#Import-Module "$PSScriptRoot\Output\$module\$module.psd1"


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