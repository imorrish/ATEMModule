using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMediaPoolClear")]
        [OutputType(typeof(bool))]
    public class ATEMMediaPoolClear : PSCmdlet
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
        public uint Index { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new MediaPoolClearStillCommand {Index = Index});
                        
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}