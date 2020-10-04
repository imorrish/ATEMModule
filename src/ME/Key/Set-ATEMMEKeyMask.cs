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
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyMask")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyMask : PSCmdlet
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
        
                protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("PreMultiplied")) {
                ATEMref.SendCommand(new MixEffectKeyMaskSetCommand {Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskEnabled, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  MaskEnabled=MaskEnabled});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskTop")) {
                ATEMref.SendCommand(new MixEffectKeyMaskSetCommand {Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskTop, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskTop=MaskTop});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskBottom")) {
                ATEMref.SendCommand(new MixEffectKeyMaskSetCommand {Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskBottom, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskBottom=MaskBottom});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskLeft")) {
                ATEMref.SendCommand(new MixEffectKeyMaskSetCommand {Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskLeft, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskLeft=MaskLeft});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskRight")) {
                ATEMref.SendCommand(new MixEffectKeyMaskSetCommand {Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskRight, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, MaskRight=MaskRight});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}