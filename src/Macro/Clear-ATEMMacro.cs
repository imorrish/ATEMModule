using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Macro;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
[Cmdlet(VerbsCommon.Clear,"ATEMMEMacro")]
        [OutputType(typeof(bool))]
        
    public class ATEMClearMacro : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public AtemClient ATEMref { get; set; }
        [Parameter(
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint MacroID { get; set; } =0;
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new MacroActionCommand {Index = MacroID, Action=(MacroActionCommand.MacroAction)5});
            WriteObject(true);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}