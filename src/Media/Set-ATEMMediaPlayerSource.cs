using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Common;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMediaPlayerSource")]
        [OutputType(typeof(bool))]
public class ATEMMediaPlayerSource : PSCmdlet
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
        public int PlayerIndex { get; set; }
        [ValidateSet("Still","Clip", IgnoreCase = true)]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public MediaPlayerSource SourceType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint StillIndex { get; set; }
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public uint ClipIndex { get; set; }
                
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            //ATEMref.SendCommand(new MediaPlayerSourceSetCommand {SourceType = (MediaPlayerSource)SourceType});
            //ATEMref.SendCommand(new MediaPlayerSourceSetCommand {Index = (MediaPlayerId)PlayerIndex, SourceType=(MediaPlayerSource)SourceType});
            if(MyInvocation.BoundParameters.ContainsKey("StillIndex")) {                
                ATEMref.SendCommand(new MediaPlayerSourceSetCommand {Mask = MediaPlayerSourceSetCommand.MaskFlags.StillIndex, Index = (MediaPlayerId)PlayerIndex, StillIndex = StillIndex});
            }
            
            if(MyInvocation.BoundParameters.ContainsKey("ClipIndex")) {
                ATEMref.SendCommand(new MediaPlayerSourceSetCommand {Mask = MediaPlayerSourceSetCommand.MaskFlags.ClipIndex, Index = (MediaPlayerId)PlayerIndex, ClipIndex=ClipIndex});
            }
            
            WriteObject(true);
        }
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}