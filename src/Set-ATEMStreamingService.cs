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
        public string ServiceName { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public string Url { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public string Key { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public uint[] Bitrates { get; set; }
        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            {
                if(MyInvocation.BoundParameters.ContainsKey("ServiceName")) {
                    ATEMref.SendCommand(new StreamingServiceSetCommand {Mask = StreamingServiceSetCommand.MaskFlags.ServiceName, ServiceName=ServiceName});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Url")) {
                    ATEMref.SendCommand(new StreamingServiceSetCommand {Mask = StreamingServiceSetCommand.MaskFlags.Url, Url=Url});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Key")) {
                    ATEMref.SendCommand(new StreamingServiceSetCommand {Mask = StreamingServiceSetCommand.MaskFlags.Key, Key=Key});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Bitrates")) {
                    List<uint> list = new List<uint> { Bitrates[0], Bitrates[1]};
                    ATEMref.SendCommand(new StreamingServiceSetCommand {Mask = StreamingServiceSetCommand.MaskFlags.Bitrates, Bitrates=list});
                }
            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }
    }    
}