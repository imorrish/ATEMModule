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
    // set program input
    [Cmdlet(VerbsCommon.Set,"ATEMMEProgramSource")]
        [OutputType(typeof(bool))]
    public class ATEMMEProgramSource : PSCmdlet
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
        public int MEID { get; set; }
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
            ATEMref.SendCommand(new ProgramInputSetCommand {Index = (MixEffectBlockId)MEID,Source = (VideoSource)InputID});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
// set program input
    [Cmdlet(VerbsCommon.Get,"ATEMMEProgramSource")]
        [OutputType(typeof(int))]
    public class ATEMMEProgramSourceGet : PSCmdlet
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
        public int MEID { get; set; }

        public int InputID { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            
            ATEMref.SendCommand(new ProgramInputGetCommand {Index = (MixEffectBlockId)MEID});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }

 // set preview input
    [Cmdlet(VerbsCommon.Set,"ATEMMEPreviewSource")]
        [OutputType(typeof(bool))]
    public class ATEMMEPreviewSource : PSCmdlet
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
        public int MEID { get; set; }
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
            ATEMref.SendCommand(new PreviewInputSetCommand {Index = (MixEffectBlockId)MEID,Source = (VideoSource)InputID});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
// FTB
    [Cmdlet(VerbsCommon.Set,"ATEMMEFadeToBlack")]
        [OutputType(typeof(bool))]
public class ATEMMEFTB : PSCmdlet
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
        public int MEID { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new FadeToBlackAutoCommand {Index = (MixEffectBlockId)MEID});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }


    [Cmdlet(VerbsCommon.Set,"ATEMMEAutoTransition")]
        [OutputType(typeof(bool))]
public class ATEMMEAutotransition : PSCmdlet
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
        public int MEID { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            ATEMref.SendCommand(new MixEffectAutoCommand {Index = (MixEffectBlockId)MEID});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    // Set transition Type
    [Cmdlet(VerbsCommon.Set,"ATEMMETransitionType")]
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
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            
            ValueFromPipelineByPropertyName = true)]
        public string TransitionType { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            TransitionStyle myEnum = (TransitionStyle)Enum.Parse(typeof(TransitionStyle), TransitionType);
            ATEMref.SendCommand(new TransitionPropertiesSetCommand {Index = (MixEffectBlockId)MEID, NextStyle=myEnum});
            
            //ATEMref.SendCommand(new TransitionPropertiesSetCommand {Index = (MixEffectBlockId)MEID, NextStyle=TransitionStyle.Dip});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    // Wipe transition settings

    
}
