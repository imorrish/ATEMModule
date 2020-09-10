using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Net;
namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMETransitionPosition")]
        [OutputType(typeof(bool))]
    public class ATEMMEPositionSetCommand : PSCmdlet
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
        public int MEID { get; set; } =0;
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Position { get; set; }
        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            {
                ATEMref.SendCommand(new TransitionPositionSetCommand { Index = (MixEffectBlockId)MEID, HandlePosition=Position });
            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }    
    }
}