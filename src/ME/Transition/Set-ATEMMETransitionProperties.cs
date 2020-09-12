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
    // Set transition Type
    [Cmdlet(VerbsCommon.Set,"ATEMMETransitionProperties")]
        [OutputType(typeof(bool))]
        public class ATEMMETransitionType : PSCmdlet
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
        public int MEID { get; set; }=0;
        [ValidateSet("Mix", "Dip", "Wipe", "Stinger","DVE", IgnoreCase = true)]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public string TransitionType { get; set; }
        [ValidateSet("Background", "Key1", "Key2", "Key3","Key4", IgnoreCase = true)]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true
        )]
        public string NextSelection {get; set;}
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(TransitionType != null){
                TransitionStyle myEnum = (TransitionStyle)Enum.Parse(typeof(TransitionStyle), TransitionType);
                ATEMref.SendCommand(new TransitionPropertiesSetCommand {Mask= TransitionPropertiesSetCommand.MaskFlags.NextStyle, Index = (MixEffectBlockId)MEID, NextStyle=myEnum});
            }
            if(MyInvocation.BoundParameters.ContainsKey("NextSelection")){
                TransitionLayer layerEnum = (TransitionLayer)Enum.Parse(typeof(TransitionLayer), NextSelection);
                ATEMref.SendCommand(new TransitionPropertiesSetCommand {Mask= TransitionPropertiesSetCommand.MaskFlags.NextSelection, Index = (MixEffectBlockId)MEID, NextSelection=layerEnum});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}