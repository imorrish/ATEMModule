using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyFlyKeyFrame")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyFlyKeyFrame : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public AtemClient ATEMref { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MEID { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int KeyerIndex { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int KeyFrameID { get; set; }        
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int SizeX { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int SizeY { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int PositionX { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int PositionY { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Rotation { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int OuterWidth { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int InnerWidth { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int OuterSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int InnerSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BevelSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BevelPosition { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderOpacity { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderHue { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderSaturation { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderLuma { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int LightSourceDirection { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int LightSourceAltitude { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskTop { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskBottom { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskLeft { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskRight { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeY")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, SizeY=SizeY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("PositionX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.PositionX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, PositionX=PositionX});
            }
            if(MyInvocation.BoundParameters.ContainsKey("PositionY")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.PositionY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, PositionY=PositionY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Rotation")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.Rotation, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Rotation=Rotation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("OuterWidth")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.OuterWidth, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, OuterWidth=OuterWidth});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}