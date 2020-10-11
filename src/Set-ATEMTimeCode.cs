using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Common;
using LibAtem.Net;


namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMTimeCode")]
        [OutputType(typeof(bool))]
public class ATEMTimeCode : PSCmdlet
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
        public UInt16 Hour { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Minute { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Second { get; set; }
        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public UInt16 Frame { get; set; } =0;
        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool IsDropFrame { get; set; } =false;
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {

                ATEMref.SendCommand(new TimeCodeCommand {Hour=Hour, Minute=Minute, Second=Second, Frame=Frame, IsDropFrame=IsDropFrame});
            
                        
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    [Cmdlet(VerbsCommon.Set,"ATEMTimeCodeConfig")]
        [OutputType(typeof(bool))]
public class ATEMTimeCodeConfig : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public AtemClient ATEMref { get; set; }
        [ValidateSet("FreeRun","TimeOfDay", IgnoreCase = true)]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public TimeCodeMode Mode { get; set; }
        
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {

                ATEMref.SendCommand(new TimeCodeConfigSetCommand {Mode=Mode});
            
                        
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}