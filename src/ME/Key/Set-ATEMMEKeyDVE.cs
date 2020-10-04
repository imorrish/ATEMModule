using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyDve")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyDve : PSCmdlet
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
        public bool BorderEnabled { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool BorderShadowEnabled { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderBevel { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderOuterWidth { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int BorderInnerWidth { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BorderOuterSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BorderInnerSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BorderBevelSoftness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint BorderBevelPosition { get; set; }
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
        public uint LightSourceAltitude { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool MaskEnabled { get; set; }
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
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint Rate { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("SizeX")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.SizeX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  SizeX=SizeX});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SizeY")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.SizeY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, SizeY=SizeY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("PositionX")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.PositionX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, PositionX=PositionX});
            }
            if(MyInvocation.BoundParameters.ContainsKey("PositionY")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.PositionY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, PositionY=PositionY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Rotation")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.Rotation, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Rotation=Rotation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderEnabled")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderEnabled, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderEnabled=BorderEnabled});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderShadowEnabled")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderShadowEnabled, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderShadowEnabled=BorderShadowEnabled});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderBevel")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevel, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderBevel=(BorderBevel)BorderBevel});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderOuterWidth")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevel, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderOuterWidth=BorderOuterWidth});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderInnerWidth")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderInnerWidth, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderOuterWidth=BorderOuterWidth});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderOuterSoftness")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderOuterSoftness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderOuterSoftness=BorderOuterSoftness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderInnerSoftness")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderInnerSoftness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderInnerSoftness=BorderInnerSoftness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderBevelSoftness")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevelSoftness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderBevelSoftness=BorderBevelSoftness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderBevelPosition")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderBevelPosition, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderBevelPosition=BorderBevelPosition});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderHue")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderHue, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderHue=BorderHue});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderSaturation")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderSaturation, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderSaturation=BorderSaturation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderLuma")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.BorderLuma, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BorderLuma=BorderLuma});
            }
            if(MyInvocation.BoundParameters.ContainsKey("LightSourceDirection")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.LightSourceDirection, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, LightSourceDirection=LightSourceDirection});
            }
            if(MyInvocation.BoundParameters.ContainsKey("LightSourceAltitude")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.LightSourceAltitude, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, LightSourceAltitude=LightSourceAltitude});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskEnabled")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskEnabled, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskEnabled=MaskEnabled});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskTop")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskTop, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskTop=MaskTop});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskBottom")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskBottom, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskBottom=MaskBottom});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskLeft")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskLeft, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskLeft=MaskLeft});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskRight")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.MaskRight, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskRight=MaskRight});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Rate")) {
                ATEMref.SendCommand(new MixEffectKeyDVESetCommand {Mask = MixEffectKeyDVESetCommand.MaskFlags.Rate, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Rate=Rate});
            }

            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}