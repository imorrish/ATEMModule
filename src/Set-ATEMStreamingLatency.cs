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
    [Cmdlet(VerbsCommon.Set,"ATEMStreamingLatency")]
        [OutputType(typeof(bool))]
    public class ATEMStreamingLatency : PSCmdlet
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
        public bool Enabled { get; set; }
        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            {
                    ATEMref.SendCommand(new StreamingLatencyCommand { LowLatency=Enabled});
            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }
    }    

}