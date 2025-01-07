using System;
using System.IO;
using System.Threading;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Common;
using LibAtem.Net;
using LibAtem.Net.DataTransfer;
using LibAtem.Util.Media;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set,"ATEMMediaPoolStillFrame")]
        [OutputType(typeof(bool))]
        public class ATEMMediaPoolStillFrame : PSCmdlet
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
        public uint stillID { get; set; }
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public String FileName { get; set; }
         [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string FilePath { get; set; }

         
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }

        
        protected override void ProcessRecord()
        {
            //Image = new Image<RGBA32>;
            //Image.Load<Rgba32>(FilePath);
            using Image image = SixLabors.ImageSharp.Image.Load<Rgba32>(FilePath);
            var ms = new MemoryStream();
            image.Save(ms, image.Metadata.DecodedImageFormat);
        
            
            //byte[] rawBytes = Convert.FromBase64String(base64Image);

            //using Image<Rgba32> image = Image.Load(rawBytes);
            //byte[] rgbaBytes = GetBytes(image);
            
            //byte[] rgbaBytes = image.GetPixelSpan().ToArray();
            
            var frame = AtemFrame.FromRGBA(FileName, ms.ToArray(), ColourSpace.BT709);
            //var frame = AtemFrame.FromRGBA(FileName, rgbaBytes, ColourSpace.BT709); 
            var completion = new TaskCompletionSource<bool>();
            var job = new UploadMediaStillJob(stillID, frame,
                (success) =>
                {                    
                    completion.SetResult(success);
                });
            ATEMref.DataTransfer.QueueJob(job);          
// some way to wait for the job to complete using completion result
        Thread.Sleep(10000);
            WriteObject(true);
        }
    
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}