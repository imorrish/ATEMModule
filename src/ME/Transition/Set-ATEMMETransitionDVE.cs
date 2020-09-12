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
    [Cmdlet(VerbsCommon.Set,"ATEMMETransitionDVE")]
        [OutputType(typeof(bool))]
    public class ATEMMEDVESetCommand : PSCmdlet
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
        [ValidateSet("SwooshTopLeft", "SwooshTop", "SwooshLeft", "SwooshRight","SwooshBottomLeft","SwooshBottom","SwooshBottomRight","SpinCCWTopRight","SpinCWTopLeft","SpinCCWBottomRight","SpinCWBottomLeft","SpinCWTopRight","SpinCCWTopLeft","SpinCWBottomRight","SpinCCWBottomLeft","SqueezeTopLeft","SqueezeTop","SqueezeTopRight","SqueezeLeft","SqueezeRight","SqueezeBottomLeft","SqueezeBottom","SqueezeBottomRight","PushTopLeft","PushTop","PushTopRight","PushLeft","PushRight","PushBottomLeft","PushBottom","PushBottomRight","GraphicCWSpin","GraphicCCWSpin","GraphicLogoWipe", IgnoreCase = true)]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Style { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int FillSource { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int KeySource { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint Rate { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint LogoRate { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool EnableKey { get; set; }
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
        public bool Reverse { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool FlipFlop { get; set; }

        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            {                
                if(MyInvocation.BoundParameters.ContainsKey("Rate")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.Rate, Index =(MixEffectBlockId)MEID, Rate=Rate});
                }
                if(MyInvocation.BoundParameters.ContainsKey("LogoRate")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.LogoRate, Index =(MixEffectBlockId)MEID, LogoRate=LogoRate});
                }
                if(MyInvocation.BoundParameters.ContainsKey("EnableKey")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.EnableKey, Index =(MixEffectBlockId)MEID, EnableKey=EnableKey});
                }
                if(MyInvocation.BoundParameters.ContainsKey("PreMultiplied")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.PreMultiplied, Index =(MixEffectBlockId)MEID, PreMultiplied=PreMultiplied});
                }
                if(MyInvocation.BoundParameters.ContainsKey("InvertKey")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.InvertKey, Index =(MixEffectBlockId)MEID, InvertKey=InvertKey});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Clip")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.Clip, Index =(MixEffectBlockId)MEID, Clip=Clip});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Gain")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.Gain, Index =(MixEffectBlockId)MEID, Gain=Gain});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Reverse")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.Reverse, Index =(MixEffectBlockId)MEID, Reverse=Reverse});
                }
                if(MyInvocation.BoundParameters.ContainsKey("FlipFlop")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.FlipFlop, Index =(MixEffectBlockId)MEID, FlipFlop=FlipFlop});
                }
                if(MyInvocation.BoundParameters.ContainsKey("FillSource")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.FillSource, Index =(MixEffectBlockId)MEID, FillSource=(VideoSource)FillSource});
                }
                if(MyInvocation.BoundParameters.ContainsKey("KeySource")) {
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.KeySource, Index =(MixEffectBlockId)MEID, KeySource=(VideoSource)KeySource});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Style")) {
                    DVEEffect styleEnum = (DVEEffect)Enum.Parse(typeof(DVEEffect), Style);
                    ATEMref.SendCommand(new TransitionDVESetCommand {Mask = TransitionDVESetCommand.MaskFlags.Style, Index =(MixEffectBlockId)MEID, Style = styleEnum});
                }
            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }    
    }
}
