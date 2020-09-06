#Add-Type -Path .\bin\Debug\netstandard2.0\LibAtem.dll # use for testing LibATEM commands
Import-Module '.\src\bin\Debug\netstandard2.0\ATEMModule.dll'
Import-Module ".\Output\ATEMModule\bin\ATEMModule.dll"

$AtemTVSHD = Add-ATEMSwitch -IPAddress "192.168.1.8"
$AtemMini = Add-ATEMSwitch -IPAddress "192.168.1.10"
$AtemMini = Add-ATEMSwitch -IPAddress "192.168.1.71"
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


$cmdCaptureStill=[LibAtem.Commands.Media.MediaPoolCaptureStillCommand]::new()
$AtemMini.SendCommand($cmdCaptureStill)

$streamingService=[LibAtem.Commands.Streaming.StreamingServiceSetCommand]::new()
$streamingService.Key = "234567890"
$streamingService.ServiceName="Facebook"
$streamingService.Url="https://facebook.com"
$streamingService.Bitrates=(4000,5000)

$streamingService=[LibAtem.Commands.Streaming.StreamingStatusSetCommand]::new()
$streamingService.IsStreaming =1
$AtemMini.SendCommand($streamingService)

Set-ATEMMECut -ATEMref $AtemMini -MEID 0
Set-ATEMMEAutoTransition -ATEMref $AtemMini -MEID 0
Set-ATEMMEAutoTransition $AtemMini 0

Set-ATEMMETransitionType $AtemMini 1 xxx

#program and preview testing
Set-AtemProgramSource -ATEMref $AtemMini -MEID 0 -InputID 1
Set-ATEMMEProgramSource $AtemMini 0 2

set-ATEMMEPreviewSource $AtemMini 0 2

Set-ATEMMEFadeToBlack $AtemMini 0

Get-ATEMMEProgramSource $AtemMini 0


$inputid = [LibAtem.Commands.MixEffects.ProgramInputGetCommand]::new()
$inputid.Index=0
$inputid.Source
$AtemMini.SendCommand($inputid)
$input2.GetType()
Set-ATEMMETransitionType $AtemMini 0 Wipe

Set-ATEMMEWipeParameters $AtemMini 0 TopToBottomBar
Set-ATEMStreaming -ATEMref $AtemMini -StreamKey "34565543"
Set-ATEMStreamingStatus -ATEMref $AtemMini -StreamStatus $false

Set-ATEMAuxSource $AtemMini 0 2

Get-ATEMMEProgramSource $AtemMini 0