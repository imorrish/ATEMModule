using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.DownstreamKey;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
[Cmdlet(VerbsCommon.Set,"ATEMDskMask")]
        [OutputType(typeof(bool))]
        
    public class ATEMSetDskMask : PSCmdlet
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
        public int DskID { get; set; }
        [Parameter(
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool MaskEnabled { get; set; }
        [Parameter(
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskTop { get; set; }
        [Parameter(
            Position = 4,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskBottom { get; set; }
        [Parameter(
            Position = 5,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskLeft { get; set; }
        [Parameter(
            Position = 6,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MaskRight { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("MaskEnabled")) {
                ATEMref.SendCommand(new DownstreamKeyMaskSetCommand {Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskEnabled, Index= (DownstreamKeyId)DskID, MaskEnabled=MaskEnabled});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskTop")) {
                ATEMref.SendCommand(new DownstreamKeyMaskSetCommand {Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskTop, Index= (DownstreamKeyId)DskID, MaskTop=MaskTop});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskBottom")) {
                ATEMref.SendCommand(new DownstreamKeyMaskSetCommand {Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskBottom, Index= (DownstreamKeyId)DskID, MaskBottom=MaskBottom});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskLeft")) {
                ATEMref.SendCommand(new DownstreamKeyMaskSetCommand {Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskLeft, Index= (DownstreamKeyId)DskID, MaskLeft=MaskLeft});
            }
            if(MyInvocation.BoundParameters.ContainsKey("MaskRight")) {
                ATEMref.SendCommand(new DownstreamKeyMaskSetCommand {Mask = DownstreamKeyMaskSetCommand.MaskFlags.MaskRight, Index= (DownstreamKeyId)DskID, MaskRight=MaskRight});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}