using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
//TransitionWipeSetCommand
    [Cmdlet(VerbsCommon.Set,"ATEMMETransitionWipe")]
        [OutputType(typeof(bool))]
    public class ATEMMEWipeSetCommand : PSCmdlet
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
            [ValidateSet("LeftToRightBar", "TopToBottomBar", "HorizontalBarnDoor", "VerticalBarnDoor","CornersInFourBox","RectangleIris","DiamondIris","CircleIris","TopLeftBox","TopRightBox","BottomRightBox","BottomLeftBox","TopCentreBox","RightCentreBox","BottomCentreBox","LeftCentreBox","TopLeftDiagonal","TopRightDiagonal", IgnoreCase = true)]
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public string SelectPattern { get; set; }
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public uint SetRate{ get; set; }
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public Int16 BorderWidth;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public int BorderInput;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public Int16 Symmetry;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public Int16 BorderSoftness;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public Int16 XPosition;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public Int16 YPosition;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public bool ReverseDirection;
            [Parameter(
                Mandatory = false,
                ValueFromPipeline = true,            
                ValueFromPipelineByPropertyName = true)]
            public bool FlipFlop;
            protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
            protected override void ProcessRecord()
            {
                if(SelectPattern != null){
                    Pattern myEnum = (Pattern)Enum.Parse(typeof(Pattern), SelectPattern);
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.Pattern, Index = (MixEffectBlockId)MEID, Pattern=myEnum});
                }
                if(MyInvocation.BoundParameters.ContainsKey("SetRate")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.Rate, Index =(MixEffectBlockId)MEID, Rate=SetRate});
                }
                if(MyInvocation.BoundParameters.ContainsKey("BorderInput")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.BorderInput, Index =(MixEffectBlockId)MEID, BorderInput=(VideoSource)BorderInput});
                }
                if(MyInvocation.BoundParameters.ContainsKey("BorderWidth")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.BorderWidth, Index =(MixEffectBlockId)MEID, BorderWidth=BorderWidth});
                }
                if(MyInvocation.BoundParameters.ContainsKey("Symmetry")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.Symmetry, Index =(MixEffectBlockId)MEID, Symmetry=Symmetry});
                }
                if(MyInvocation.BoundParameters.ContainsKey("BorderSoftness")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.BorderSoftness, Index =(MixEffectBlockId)MEID, BorderSoftness=BorderSoftness});
                }
                if(MyInvocation.BoundParameters.ContainsKey("XPosition")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.XPosition, Index =(MixEffectBlockId)MEID, XPosition=XPosition});
                }
                if(MyInvocation.BoundParameters.ContainsKey("YPosition")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.YPosition, Index =(MixEffectBlockId)MEID, YPosition=YPosition});
                }
                if(MyInvocation.BoundParameters.ContainsKey("ReverseDirection")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.ReverseDirection, Index =(MixEffectBlockId)MEID, ReverseDirection=ReverseDirection});
                }
                if(MyInvocation.BoundParameters.ContainsKey("FlipFlop")) {
                    ATEMref.SendCommand(new TransitionWipeSetCommand {Mask = TransitionWipeSetCommand.MaskFlags.FlipFlop, Index =(MixEffectBlockId)MEID, FlipFlop=FlipFlop});
                }
                WriteObject(true);
            }
            protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }

    }
}