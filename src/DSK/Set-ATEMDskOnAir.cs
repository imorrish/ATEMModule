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
[Cmdlet(VerbsCommon.Set,"ATEMDskOnAir")]
        [OutputType(typeof(bool))]
        
    public class ATEMSetDskOnAir : PSCmdlet
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
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool OnAir { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new DownstreamKeyOnAirSetCommand {Index = (DownstreamKeyId)DskID, OnAir=OnAir});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}