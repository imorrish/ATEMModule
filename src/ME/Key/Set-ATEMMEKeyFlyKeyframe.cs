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
        public uint OuterSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint InnerSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BevelSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BevelPosition { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BorderOpacity { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BorderHue { get; set; }
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
        public uint LightSourceAltitude { get; set; }
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
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, SizeX=SizeX});// KeyFrame=(FlyKeyKeyFrameId)KeyFrameID});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeY")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.SizeY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, SizeY=SizeY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("PositionX")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.PositionX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, PositionX=PositionX});
            }
            if(MyInvocation.BoundParameters.ContainsKey("PositionY")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.PositionY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, PositionY=PositionY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Rotation")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.Rotation, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, Rotation=Rotation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("OuterWidth")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.OuterWidth, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, OuterWidth=OuterWidth});
            }
            if(MyInvocation.BoundParameters.ContainsKey("InnerWidth")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.InnerWidth, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, InnerWidth=InnerWidth});
            }
            if(MyInvocation.BoundParameters.ContainsKey("OuterSoftness")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.OuterSoftness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, OuterSoftness=OuterSoftness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("InnerSoftness")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.InnerSoftness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, InnerSoftness=InnerSoftness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BevelSoftness")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.BevelSoftness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, BevelSoftness=BevelSoftness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BevelPosition")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.BevelPosition, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, BevelPosition=BevelPosition});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderOpacity")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.BorderOpacity, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, BorderOpacity=BorderOpacity});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderHue")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.BorderHue, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, BorderHue=BorderHue});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderSaturation")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.BorderSaturation, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, BorderSaturation=BorderSaturation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderLuma")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.BorderLuma, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, BorderLuma=BorderLuma});
            }
            if(MyInvocation.BoundParameters.ContainsKey("LightSourceDirection")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.LightSourceDirection, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, LightSourceDirection=LightSourceDirection});
            }
            if(MyInvocation.BoundParameters.ContainsKey("LightSourceAltitude")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.LightSourceAltitude, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, LightSourceAltitude=LightSourceAltitude});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskTop")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.MaskTop, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, MaskTop=MaskTop});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskBottom")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.MaskBottom, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, MaskBottom=MaskBottom});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskLeft")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.MaskLeft, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, MaskLeft=MaskLeft});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskRight")) {
                ATEMref.SendCommand(new MixEffectKeyFlyKeyframeSetCommand {Mask = MixEffectKeyFlyKeyframeSetCommand.MaskFlags.MaskRight, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,KeyFrame=(FlyKeyKeyFrameId)KeyFrameID, MaskRight=MaskRight});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}