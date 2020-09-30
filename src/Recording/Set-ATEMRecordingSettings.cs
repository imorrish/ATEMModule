using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Recording;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
[Cmdlet(VerbsCommon.Set,"ATEMRecordingSettings")]
        [OutputType(typeof(bool))]
    public class ATEMRecordingSettings : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public AtemClient ATEMref { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public string Filename { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public UInt32 WorkingSet1DiskId { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public UInt32 WorkingSet2DiskId { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,            
            ValueFromPipelineByPropertyName = true)]
        public bool RecordInAllCameras { get; set; }
        protected override void BeginProcessing()
            {
                WriteVerbose("Begin!");
            }
        protected override void ProcessRecord()
            { try{
                if(MyInvocation.BoundParameters.ContainsKey("Filename")) {
                    ATEMref.SendCommand(new RecordingSettingsSetCommand {Mask = RecordingSettingsSetCommand.MaskFlags.Filename, Filename=Filename});
                }
                if(MyInvocation.BoundParameters.ContainsKey("WorkingSet1DiskId")) {
                    ATEMref.SendCommand(new RecordingSettingsSetCommand {Mask = RecordingSettingsSetCommand.MaskFlags.WorkingSet1DiskId, WorkingSet1DiskId=WorkingSet1DiskId});
                }
                if(MyInvocation.BoundParameters.ContainsKey("WorkingSet2DiskId")) {
                    ATEMref.SendCommand(new RecordingSettingsSetCommand {Mask = RecordingSettingsSetCommand.MaskFlags.WorkingSet2DiskId, WorkingSet2DiskId=WorkingSet2DiskId});
                }
                if(MyInvocation.BoundParameters.ContainsKey("RecordInAllCameras")) {
                    
                    ATEMref.SendCommand(new RecordingSettingsSetCommand {Mask = RecordingSettingsSetCommand.MaskFlags.RecordInAllCameras, RecordInAllCameras=RecordInAllCameras});
                }
                WriteObject(true);
            }catch{
                WriteObject(false);
            }

            }
        protected override void EndProcessing()
            {
                WriteVerbose("End!");
            }
    }    
}