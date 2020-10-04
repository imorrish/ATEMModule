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
    [Cmdlet(VerbsCommon.Set,"ATEMMEKeyType")]
        [OutputType(typeof(bool))]
        public class ATEMMEKeyType : PSCmdlet
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
                [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int KeyerIndex { get; set; }
        [ValidateSet("Mix", "Dip", "Wipe", "Stinger","DVE", IgnoreCase = true)]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public string KeyType { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool FlyEnabled { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(KeyType != null){
                MixEffectKeyType keyTypeEnum = (MixEffectKeyType)Enum.Parse(typeof(MixEffectKeyType), KeyType);
                ATEMref.SendCommand(new MixEffectKeyTypeSetCommand {Mask= MixEffectKeyTypeSetCommand.MaskFlags.KeyType, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, KeyType=keyTypeEnum});
            }
            if(MyInvocation.BoundParameters.ContainsKey("FlyEnabled")){

                ATEMref.SendCommand(new MixEffectKeyTypeSetCommand {Mask= MixEffectKeyTypeSetCommand.MaskFlags.FlyEnabled, MixEffectIndex = (MixEffectBlockId)MEID, KeyerIndex=(UpstreamKeyId)KeyerIndex, FlyEnabled=FlyEnabled});
            }
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}