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
 [Cmdlet(VerbsCommon.Set,"ATEMMETransitionDip")]
        [OutputType(typeof(bool))]
    public class ATEMMEDipSetCommand : PSCmdlet
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
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Input { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint Rate { get; set; } =1;

        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            {
                
                if(MyInvocation.BoundParameters.ContainsKey("Rate")) {
                    ATEMref.SendCommand(new TransitionDipSetCommand {Mask = TransitionDipSetCommand.MaskFlags.Rate, Index =(MixEffectBlockId)MEID, Rate=Rate});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Input")) {
                    ATEMref.SendCommand(new TransitionDipSetCommand {Mask = TransitionDipSetCommand.MaskFlags.Input, Index =(MixEffectBlockId)MEID, Input=(VideoSource)Input});
                }
            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }    
    }
}