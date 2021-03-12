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
    [Cmdlet(VerbsCommon.Set,"ATEMMediaPoolStillFileName")]
        [OutputType(typeof(bool))]
    public class ATEMMediaPoolStillFileName : PSCmdlet
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
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public String FileName { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new MediaPoolStillSetFilenameCommand {Index = Index, Filename = FileName});
                        
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}