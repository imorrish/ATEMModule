using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMEAdvKeyChromaSample")]
        [OutputType(typeof(bool))]
public class ATEMMEAdvKeyChromaSample : PSCmdlet
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

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool EnableCursor { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool Preview { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double CursorX { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double CursorY { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double CursorSize { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double SampledY { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double SampledCb { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public double SampledCr { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("EnableCursor")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.EnableCursor, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex,  EnableCursor=EnableCursor});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Preview")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.Preview, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, Preview=Preview});
            }
            if(MyInvocation.BoundParameters.ContainsKey("CursorX")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.CursorX, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, CursorX=CursorX});
            }
            if(MyInvocation.BoundParameters.ContainsKey("CursorY")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.CursorY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, CursorY=CursorY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("CursorSize")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.CursorSize, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, CursorSize=CursorSize});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SampledY")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.SampledY, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, SampledY=SampledY});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SampledCb")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.SampledCb, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, SampledCb=SampledCb});
            }
            if(MyInvocation.BoundParameters.ContainsKey("SampledCr")) {
                ATEMref.SendCommand(new MixEffectKeyAdvancedChromaSampleSetCommand {Mask = MixEffectKeyAdvancedChromaSampleSetCommand.MaskFlags.SampledCr, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, SampledCr=SampledCr});
            }
            
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}