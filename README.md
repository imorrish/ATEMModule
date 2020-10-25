# ATEMModule

This is a PowerShell module for controling Blackmagic ATEM video switches using LibATEM https://github.com/LibAtem/LibAtem

It is written for .Net Core 3.0 and has been tested on Windows, Mac OSx and Linux (including Raspberry Pi)

## Very alpha. No version number and lots of trial and error in the code.

Download a version from https://1drv.ms/u/s!ApGpqMMpRLhik5E1tVgBIJ0eq5wx2A?e=3jgAVQ

### Prerequisite

Install .net runtime or framework for Mac, Linux or Windows
from https://dotnet.microsoft.com/download

### Functionality

You can connect to multiple ATEM's. E.g.  
$AtemMini = Add-ATEMSwitch -IPAddress "192.168.1.10"  
$AtemISO = Add-ATEMSwitch -IPAddress "192.168.1.71"

Using Mix Effect commands:  
Set-ATEMMEProgramSource -ATEMref $AtemMini -MEID 0 -InputID 1

Where parameters are required, they are positional so the -directive can be omitted. E.g.  
Set-ATEMMEProgramSource $AtemMini 0 1

Set-ATEMMETransitionProperties $AtemMini 0 -TransitionType DIP # or Mix, Dip, Wipe & Stinger

Set-ATEMMEWipeParameters $AtemMini 0 TopToBottomBar

Other commands:  
Set-ATEMMEPreviewSource  
Set-ATEMMEAutoTransition  
Set-ATEMMECut  
Set-ATEMMEFadeToBlack  

Set-ATEMAuxSource  
Set-ATEMStreamingStatus -ATEMref $AtemMini -StreamStatus $true  

### License

LibAtem is distributed under the GNU Lesser General Public License LGPLv3 or higher, see the file LICENSE for details.
