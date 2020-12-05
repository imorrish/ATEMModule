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
    [Cmdlet(VerbsCommon.Set,"ATEMMediaPlayerSource")]
        [OutputType(typeof(bool))]
public class ATEMMediaPlayerSource : PSCmdlet
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
        public int PlayerIndex { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int SourceType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool StillIndex { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int ClipIndex { get; set; }
                
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("PreMultiplied")) {
                ATEMref.SendCommand(new MediaPlayerSourceSetCommand {Mask = MixEffectKeyMaskSetCommand.MaskFlags.MaskEnabled, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  MaskEnabled=MaskEnabled});
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