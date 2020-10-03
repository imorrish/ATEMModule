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
[Cmdlet(VerbsCommon.Set,"ATEMDskProperties")]
        [OutputType(typeof(bool))]
        
    public class ATEMSetDskProperties : PSCmdlet
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
        public bool PreMultipliedKey { get; set; }
        [Parameter(
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Clip { get; set; }
        [Parameter(
            Position = 4,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Gain { get; set; }
        [Parameter(
            Position = 5,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool Invert { get; set; }

        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("PreMultipliedKey")) {
                ATEMref.SendCommand(new DownstreamKeyGeneralSetCommand {Mask = DownstreamKeyGeneralSetCommand.MaskFlags.PreMultipliedKey, Index= (DownstreamKeyId)DskID, PreMultipliedKey=PreMultipliedKey});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Clip")) {
                ATEMref.SendCommand(new DownstreamKeyGeneralSetCommand {Mask = DownstreamKeyGeneralSetCommand.MaskFlags.Clip, Index= (DownstreamKeyId)DskID, Clip=Clip});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Gain")) {
                ATEMref.SendCommand(new DownstreamKeyGeneralSetCommand {Mask = DownstreamKeyGeneralSetCommand.MaskFlags.Gain, Index= (DownstreamKeyId)DskID, Gain=Gain});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Invert")) {
                ATEMref.SendCommand(new DownstreamKeyGeneralSetCommand {Mask = DownstreamKeyGeneralSetCommand.MaskFlags.Invert, Index= (DownstreamKeyId)DskID, Invert=Invert});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}