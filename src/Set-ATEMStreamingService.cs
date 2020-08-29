using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Streaming;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
[Cmdlet(VerbsCommon.Set,"ATEMStreamingService")]
        [OutputType(typeof(bool))]
    public class ATEMStreamingService : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public AtemClient ATEMref { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public string StreamKey { get; set; }
        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            {
                if(MyInvocation.BoundParameters.ContainsKey("StreamKey")) {
                    ATEMref.SendCommand(new StreamingServiceSetCommand {Mask = StreamingServiceSetCommand.MaskFlags.Key, Key=StreamKey});
                }
            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }
    }    
}