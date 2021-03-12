#Add-Type -Path .\bin\Debug\netstandard2.0\LibAtem.dll # use for testing LibATEM commands
# Add-Type -Path .\bin\Debug\netstandard2.0\LibAtem.Discovery.dll

Import-Module '.\src\bin\Debug\netstandard2.0\ATEMModule.dll'
Import-Module ".\Output\ATEMModule\bin\ATEMModule.dll"

$AtemTVSHD = Add-ATEMSwitch -IPAddress "192.168.1.8"
$AtemMini = Add-ATEMSwitch -IPAddress "192.168.1.10"
$AtemISO = Add-ATEMSwitch -IPAddress "192.168.1.126"

#program and preview testing
Set-AtemProgramSource -ATEMref $AtemMini -MEID 0 -InputID 1
Set-ATEMMEProgramSource $AtemISO 0 2
set-ATEMMEPreviewSource $AtemMini 0 2

Set-ATEMMECut -ATEMref $AtemMini -MEID 0

Set-ATEMMEAutoTransition -ATEMref $AtemMini -MEID 0
Set-ATEMMEAutoTransition $AtemMini 0

Set-ATEMMEFadeToBlack $AtemMini 0

#DSK
Set-ATEMDskFillSource $AtemISO 0 1
Set-ATEMDskOnAir $AtemISO 0 $true
Set-ATEMDskTie $AtemISO
#Keyer - USK

Set-ATEMMEKeyOnAir $AtemISO 0 -OnAir $true
Set-ATEMMEKeyFlyRunTo -ATEMRef $AtemISO -MEID 0 -KeyerIndex 0 -KeyFrame B -RunToInfinite TopRight #must speciy RunToInfinite param even if going to A or B

#Transitions
Set-ATEMMETransitionProperties $AtemISO 0 -TransitionType Dip #Mix Dip Wipe Stinger
Set-ATEMMETransitionProperties $AtemISO 0 -NextSelection Background #Key1 Key2
Set-ATEMMETransitionProperties $AtemISO 0 -TransitionType Mix -NextSelection Key1

Set-ATEMMETransitionDVE $AtemISO 0 -Style PushBottom

Set-ATEMMETransitionWipe $AtemISO 0 -SelectPattern CircleIris

#Aux
Set-ATEMAuxSource $AtemMini 0 2

#Streaming
Set-ATEMStreaming -ATEMref $Atemiso -Url "https://localhost"
Set-ATEMStreamingService -ATEMref $AtemIso -ServiceName "Facebook"
Set-ATEMStreamingService -ATEMref $AtemIso -Key "abcd"
Set-ATEMStreamingStatus -ATEMref $AtemIso -StreamStatus $false

#Recording
Set-ATEMRecordingSettings -ATEMref $AtemISO -Filename "Test123"
Set-ATEMRecordingSettings -ATEMref $AtemISO -RecordInAllCameras $true

#Color Generator
Set-ATEMColorGenerator $AtemISO 0 -Hue 220  -Saturation 20 -Luma 80

#TimeCode
Set-ATEMTimeCodeConfig  $AtemISO -Mode FreeRun
Set-ATEMTimeCode -ATEMref $AtemISO -Hour 00 -Minute 10  -Second 00 -Frame 00 -IsDropFrame $false
start-sleep 5
Set-ATEMTimeCodeConfig  $AtemISO -Mode TimeOfDay

# Startup state
Set-ATEMStartupState $AtemISO

# Capture still
Set-ATEMMediaPlayerSource -ATEMref $AtemISO -PlayerIndex 0 -StillIndex 2

# Capture still
new-ATEMMediaPoolCaptureStill -ATEMref $AtemISO
# Ignore everything below

$AuxiliaryInputMacroOp = [LibAtem.MacroOperations.AuxiliaryInputMacroOp]::new()
$AuxiliaryInputMacroOp.Index =0
$AuxiliaryInputMacroOp.Source=4
$AuxiliaryInputMacroOp
[LibAtem.MacroOperations.MacroOpExtensions]::ToByteArray($AuxiliaryInputMacroOp)


$AtemFTB = [LibAtem.MacroOperations.MixEffects.FadeToBlackAutoMacroOp]::new()
$AtemFTB.Index =0 #ME1
[LibAtem.MacroOperations.MacroOpExtensions]::ToByteArray($AtemFTB)


$devices = [LibAtem.Discovery.AtemDiscoveryService]::new()


function Set-AtemProgramInput([int]$source)
{
    $AtemProgSet = [LibAtem.Commands.MixEffects.ProgramInputSetCommand]::New()
    $atemProgSet.Source=$source
    $AtemMini.SendCommand($atemProgSet)
}
Set-AtemProgramInput 1

function Set-AtemPreviewInput([int]$source)
{
    $AtemPrevSet = [LibAtem.Commands.MixEffects.PreviewInputSetCommand]::New()
    $AtemPrevSet.Source=$source
    $AtemMini.SendCommand($AtemPrevSet)
}
Set-AtemPreviewInput 3

$DIP= [LibAtem.Commands.MixEffects.Transition.TransitionDipSetCommand]::new()
$dip.mask=1
$dip.Index = 0
$dip.Input = 3
$dip.Rate =25
$dip
$AtemMini.SendCommand($DIP)

$transition= [LibAtem.Commands.MixEffects.Transition.TransitionPropertiesSetCommand]::new()
$transition.Index=0
$transition.NextSelection=2
$AtemMini.SendCommand($transition)

$HD=[LibAtem.Commands.Settings.HyperDeck.HyperDeckSettingsSetCommand]::new()
$HD.NetworkAddressStr = "192.168.1.11"
$HD.Mask=15
$HD.Source = 3
$AtemMini.SendCommand($HD)


$atemProgSet.Source=3
$atemresult= $AtemMini.SendCommand($atemProgSet)
$atemresult |Get-Member


$Audio=[LibAtem.Commands.Audio.Fairlight.FairlightMixerAnalogAudioSetCommand]::new()
$audio.Index=6
$audio.InputLevel=0
$Audio=[LibAtem.Commands.Audio.Fairlight.FairlightMixerSourceLevelsCommand]::new()
$audio.Index=1
$audio.InputRightLevel -100
$audio.LimiterGainReduction
$audio| Get-Member
$Audio=[LibAtem.Commands.Audio.Fairlight.FairlightMixerSourceSetCommand]::new()
$audio.SourceId=1
$audio.FaderGain=100
$audio.Gain=100111
$AtemMini.SendCommand($Audio)



$AudioFollowVideo=[LibAtem.Commands.Audio.Fairlight.FairlightMixerMasterPropertiesSetCommand]::new()
$AudioFollowVideo
$AudioFollowVideo.AudioFollowVideoCrossfadeTransitionEnabled =0
$AtemMini.SendCommand($AudioFollowVideo)