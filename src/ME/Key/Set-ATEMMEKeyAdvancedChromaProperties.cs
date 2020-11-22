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
    [Cmdlet(VerbsCommon.Set,"ATEMMEAdvKeyChroma")]
        [OutputType(typeof(bool))]
public class ATEMMEAdvKeyChroma : PSCmdlet
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
        public double ForegroundLevel { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double BackgroundLevel { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double KeyEdge { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double SpillSuppression { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double FlareSuppression { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double Brightness { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double Contrast { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double Saturation { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double Red { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double Green { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double Blue { get; set; }
                protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("ForegroundLevel")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.ForegroundLevel, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  ForegroundLevel=ForegroundLevel});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BackgroundLevel")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.BackgroundLevel, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, BackgroundLevel=BackgroundLevel});
            }
            if(MyInvocation.BoundParameters.ContainsKey("KeyEdge")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.KeyEdge, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyEdge=KeyEdge});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SpillSuppression")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.SpillSuppression, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, SpillSuppression=SpillSuppression});
            }
            if(MyInvocation.BoundParameters.ContainsKey("FlareSuppression")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.FlareSuppression, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, FlareSuppression=FlareSuppression});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Brightness")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.Brightness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Brightness=Brightness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Contrast")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.Contrast, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Contrast=Contrast});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Saturation")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.Saturation, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Saturation=Saturation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Red")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.Red, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Red=Red});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Green")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.Green, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Green=Green});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Blue")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaPropertiesSetCommand {Mask = MixEffectKeyAdvancedChromaPropertiesSetCommand.MaskFlags.Blue, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Blue=Blue});
            }
            
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}