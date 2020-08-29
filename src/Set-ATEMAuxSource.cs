using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    // set program input
    [Cmdlet(VerbsCommon.Set,"ATEMAuxSource")]
        [OutputType(typeof(bool))]
    public class ATEMAuxSource : PSCmdlet
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
        public uint AuxID { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int InputID { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new AuxSourceSetCommand {Id = AuxID,Source = (VideoSource)InputID});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    [Cmdlet(VerbsCommon.Get,"ATEMAuxSource")]
        [OutputType(typeof(uint))]
    public class ATEMAuxSourceGet : PSCmdlet
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
        public uint AuxID { get; set; }
        public uint currentInput { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            uint currentInput = 1;
            
            WriteObject(currentInput);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}