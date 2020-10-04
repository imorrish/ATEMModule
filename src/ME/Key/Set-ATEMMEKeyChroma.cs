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
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyChroma")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyChroma : PSCmdlet
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
        public int Hue { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Gain { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int YSuppress { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Lift { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool Narrow { get; set; }
                protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("Hue")) {
                ATEMref.SendCommand(new MixEffectKeyChromaSetCommand {Mask = MixEffectKeyChromaSetCommand.MaskFlags.Hue, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  Hue=Hue});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Gain")) {
                ATEMref.SendCommand(new MixEffectKeyChromaSetCommand {Mask = MixEffectKeyChromaSetCommand.MaskFlags.Gain, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Gain=Gain});
            }
            if(MyInvocation.BoundParameters.ContainsKey("YSuppress")) {
                ATEMref.SendCommand(new MixEffectKeyChromaSetCommand {Mask = MixEffectKeyChromaSetCommand.MaskFlags.YSuppress, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, YSuppress=YSuppress});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Lift")) {
                ATEMref.SendCommand(new MixEffectKeyChromaSetCommand {Mask = MixEffectKeyChromaSetCommand.MaskFlags.Lift, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Lift=Lift});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Narrow")) {
                ATEMref.SendCommand(new MixEffectKeyChromaSetCommand {Mask = MixEffectKeyChromaSetCommand.MaskFlags.Narrow, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Narrow=Narrow});
            }
            
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}