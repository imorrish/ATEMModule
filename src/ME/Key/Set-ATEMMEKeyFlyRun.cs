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
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyFlyRunTo")]
        [OutputType(typeof(bool))]
public class ATEMMEKeyFlyRunTo : PSCmdlet
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
        //[ValidateSet("One","Two","Three","Four")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int KeyerIndex { get; set; }
        [ValidateSet("None","A","B","Full","RunToInfinite")]
        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string KeyFrame { get; set; }
        [ValidateSet("CentreOfKey","TopLeft","TopCentre","TopRight","MiddleLeft","MiddleCentre","MiddleRight","BottomLeft","BottomCentre","BottomRight")]
        [Parameter(
            Mandatory = true,
            Position = 4,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string RunToInfinite { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            //UpstreamKeyId enumKeyerIndex = (UpstreamKeyId)Enum.Parse(typeof(UpstreamKeyId), KeyerIndex);
            FlyKeyKeyFrameType enumKeyFrame = (FlyKeyKeyFrameType)Enum.Parse(typeof(FlyKeyKeyFrameType), KeyFrame);
            FlyKeyLocation enumKeyFrameRunTo = (FlyKeyLocation)Enum.Parse(typeof(FlyKeyLocation), RunToInfinite);
            ATEMref.SendCommand(new MixEffectKeyFlyRunSetCommand {MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex = (UpstreamKeyId)KeyerIndex,KeyFrame=enumKeyFrame,RunToInfinite=enumKeyFrameRunTo});
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}