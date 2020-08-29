# ATEMModule

This is a PowerShell module for controling Blackmagic ATEM video switches using LibATEM https://github.com/LibAtem/LibAtem

It is written for .Net Core 3.0 and has been tested on Windows, Mac OSx and Linux (including Raspberry Pi)

### Functionality

You can connect to multiple ATEM's. E.g.
$AtemMini = Add-ATEMSwitch -IPAddress "192.168.1.10"
$AtemISO = Add-ATEMSwitch -IPAddress "192.168.1.71"

Using Mix Effect commands:
Set-AtemProgramSource -ATEMref $AtemMini -MEID 0 -InputID 1

Where parameters are requires, they are positional so the -directive can be omitted. E.g.
Set-ATEMMEProgramSource $AtemMini 0 1

Other commands:
Set-AtemPreviewSource
Set-ATEMMEAutoTransition
Set-ATEMMECut
Set-ATEMMEFadeToBlack

Set-ATEMAuxSource
Set-ATEMStreamingStatus -ATEMref $AtemMini -StreamStatus $true

### License

LibAtem is distributed under the GNU Lesser General Public License LGPLv3 or higher, see the file LICENSE for details.
