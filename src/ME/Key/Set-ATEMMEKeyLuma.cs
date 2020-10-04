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
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyLuma")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyLuma : PSCmdlet
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
        public bool PreMultiplied { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Clip { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Gain { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool Invert { get; set; }
                protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("PreMultiplied")) {
                ATEMref.SendCommand(new MixEffectKeyLumaSetCommand {Mask = MixEffectKeyLumaSetCommand.MaskFlags.PreMultiplied, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  PreMultiplied=PreMultiplied});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Clip")) {
                ATEMref.SendCommand(new MixEffectKeyLumaSetCommand {Mask = MixEffectKeyLumaSetCommand.MaskFlags.Clip, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Clip=Clip});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Gain")) {
                ATEMref.SendCommand(new MixEffectKeyLumaSetCommand {Mask = MixEffectKeyLumaSetCommand.MaskFlags.Gain, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Gain=Gain});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Invert")) {
                ATEMref.SendCommand(new MixEffectKeyLumaSetCommand {Mask = MixEffectKeyLumaSetCommand.MaskFlags.Invert, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Invert=Invert});
            }
            
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}