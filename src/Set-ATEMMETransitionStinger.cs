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
    [Cmdlet(VerbsCommon.Set,"ATEMMETransitionStinger")]
        [OutputType(typeof(bool))]
    public class ATEMMEStingerSetCommand : PSCmdlet
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
        public int Source { get; set; }    
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public bool PreMultipliedKey{ get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public bool PreMultiplied { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool InvertKey { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint Clip { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint Gain { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool Invert { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public uint Preroll;
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint ClipDuration { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint TriggerPoint { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint MixRate { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("Source")) {
                    ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.Source, Index =(MixEffectBlockId)MEID, Source=(StingerSource)Source});
                }
            if(MyInvocation.BoundParameters.ContainsKey("SetRate")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.PreMultipliedKey, Index =(MixEffectBlockId)MEID, PreMultipliedKey=PreMultipliedKey});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderInput")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.Clip, Index =(MixEffectBlockId)MEID, Clip=Clip});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderWidth")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.Gain, Index =(MixEffectBlockId)MEID, Gain=Gain});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Symmetry")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.Invert, Index =(MixEffectBlockId)MEID, Invert=Invert});
            }
            if(MyInvocation.BoundParameters.ContainsKey("BorderSoftness")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.Preroll, Index =(MixEffectBlockId)MEID, Preroll=Preroll});
            }
            if(MyInvocation.BoundParameters.ContainsKey("XPosition")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.ClipDuration, Index =(MixEffectBlockId)MEID, ClipDuration=ClipDuration});
            }
            if(MyInvocation.BoundParameters.ContainsKey("YPosition")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.TriggerPoint, Index =(MixEffectBlockId)MEID, TriggerPoint=TriggerPoint});
            }
            if(MyInvocation.BoundParameters.ContainsKey("ReverseDirection")) {
                ATEMref.SendCommand(new TransitionStingerSetCommand {Mask = TransitionStingerSetCommand.MaskFlags.MixRate, Index =(MixEffectBlockId)MEID, MixRate=MixRate});
            }
            
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }

    }
}