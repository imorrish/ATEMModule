# ATEMModule

ATEMModule is a PowerShell binary module (compiled C# cmdlets) that controls Blackmagic ATEM video switchers. It's a thin PowerShell-facing wrapper over LibAtem (a vendored git submodule at LibAtem/), which implements the ATEM network protocol over UDP.

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

### Media still uploads

The image passed to `Set-ATEMMediaPoolStillFrame` must match the switcher's
video resolution exactly. The `-Resolution` parameter defaults to `_1080`
(1920 x 1080); specify the switcher's actual resolution for other video modes.
Resize or pad an image before uploading if its dimensions do not match.
Use the same resolution when downloading a still.

```powershell
Set-ATEMMediaPoolStillFrame -ATEMref $AtemMini -stillID 0 -FilePath '.\still.png' -Resolution _1080
Get-ATEMMediaPoolStillFrame -ATEMref $AtemMini -stillID 0 -FilePath '.\downloaded.png' -Resolution _1080
```

For a hardware transfer check, run
`.\Tests\test-media-still-transfer.ps1 -UploadPath '.\still.png' -Resolution _1080 -AtemIp '192.168.1.10'`.
This overwrites the selected still slot; compare the downloaded image with the
original, allowing for colour-conversion differences.

### License

LibAtem is distributed under the GNU Lesser General Public License LGPLv3 or higher, see the file LICENSE for details.
