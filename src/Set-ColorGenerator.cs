using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMColorGenerator")]
        [OutputType(typeof(bool))]
public class ATEMColorGenerator : PSCmdlet
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
        public int ColorGeneratorId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Hue { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Saturation { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int Luma { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            if(MyInvocation.BoundParameters.ContainsKey("Hue")) {
                ATEMref.SendCommand(new ColorGeneratorSetCommand {Mask = ColorGeneratorSetCommand.MaskFlags.Hue, Index = (ColorGeneratorId)ColorGeneratorId, Hue=Hue});
            }
            if(MyInvocation.BoundParameters.ContainsKey("Gain")) {
                ATEMref.SendCommand(new ColorGeneratorSetCommand {Mask = ColorGeneratorSetCommand.MaskFlags.Saturation, Index = (ColorGeneratorId)ColorGeneratorId, Saturation=Saturation});
            }
            if(MyInvocation.BoundParameters.ContainsKey("YSuppress")) {
                ATEMref.SendCommand(new ColorGeneratorSetCommand {Mask = ColorGeneratorSetCommand.MaskFlags.Luma, Index = (ColorGeneratorId)ColorGeneratorId, Luma=Luma});
            }
                        
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}