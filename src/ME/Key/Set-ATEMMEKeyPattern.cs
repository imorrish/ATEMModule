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
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyPattern")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyPattern : PSCmdlet
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
        public int KeyerIndex { get; set; }
        [ValidateSet("LeftToRightBar", "TopToBottomBar", "HorizontalBarnDoor", "VerticalBarnDoor","CornersInFourBox","RectangleIris","DiamondIris","CircleIris","TopLeftBox","TopRightBox","BottomRightBox","BottomLeftBox","TopCentreBox","RightCentreBox","BottomCentreBox","LeftCentreBox","TopLeftDiagonal","TopRightDiagonal", IgnoreCase = true)]
        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Pattern { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Size { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Symmetry { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Softness { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 7,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 XPosition { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 8,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 YPosition { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 9,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool Inverse { get; set; }
        
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {

            if(Pattern != null){
                Pattern myEnum = (Pattern)Enum.Parse(typeof(Pattern), Pattern);
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.Pattern, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Pattern=myEnum});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Size")) {
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.Size, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  Size=Size});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Symmetry")) {
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.Symmetry, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  Symmetry=Symmetry});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Softness")) {
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.Softness, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  Softness=Softness});
            }
            if(MyInvocation.BoundParameters.ContainsKey("XPosition")) {
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.XPosition, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  XPosition=XPosition});
            }
            if(MyInvocation.BoundParameters.ContainsKey("YPosition")) {
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.YPosition, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  YPosition=YPosition});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Inverse")) {
                ATEMref.SendCommand(new MixEffectKeyPatternSetCommand {Mask = MixEffectKeyPatternSetCommand.MaskFlags.Inverse, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  Inverse=Inverse});
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}