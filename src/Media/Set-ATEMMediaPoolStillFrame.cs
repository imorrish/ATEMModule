using System;
using System.IO;
using System.Threading.Tasks;
using System.Management.Automation;
using LibAtem.Common;
using LibAtem.Net;
using LibAtem.Net.DataTransfer;
using LibAtem.Util.Media;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set, "ATEMMediaPoolStillFrame")]
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
        public string FilePath { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string FileName { get; set; }

        [Parameter()]
        public VideoModeResolution Resolution { get; set; } = VideoModeResolution._1080;

        [Parameter()]
        public int TimeoutSeconds { get; set; } = 10;

        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }

        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                throw new PSArgumentNullException(nameof(FilePath), "A file path is required.");

            string imageName = string.IsNullOrWhiteSpace(FileName)
                ? Path.GetFileNameWithoutExtension(FilePath)
                : FileName;

            using var image = Image.Load<Rgba32>(FilePath);
            if (!Enum.IsDefined(typeof(VideoModeResolution), Resolution))
                throw new PSArgumentException($"Invalid video resolution: {Resolution}.", nameof(Resolution));

            var size = Resolution.GetSize();
            if (image.Width != size.Item1 || image.Height != size.Item2)
            {
                throw new PSArgumentException(
                    $"Image is {image.Width}x{image.Height}, but resolution {Resolution} requires {size.Item1}x{size.Item2}. Resize or pad the image before uploading.",
                    nameof(FilePath));
            }

            var rgbaBytes = new byte[image.Width * image.Height * 4];
            image.CopyPixelDataTo(rgbaBytes);

            var frame = AtemFrame.FromRGBA(imageName, rgbaBytes, ColourSpace.BT709);
            var completion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var timeout = TimeSpan.FromSeconds(TimeoutSeconds);

            var job = new UploadMediaStillJob(stillID, frame, success => completion.TrySetResult(success), timeout);
            ATEMref.DataTransfer.QueueJob(job);

            if (!completion.Task.Wait(timeout))
            {
                throw new TimeoutException($"Timed out uploading media still '{imageName}' to ATEM still index {stillID}.");
            }

            if (!completion.Task.Result)
            {
                throw new RuntimeException($"Upload of media still '{imageName}' to ATEM still index {stillID} failed.");
            }

            WriteObject(true);
        }

        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
}