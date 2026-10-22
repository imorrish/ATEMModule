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
    [Cmdlet(VerbsCommon.Get, "ATEMMediaPoolStillFrame")]
    [OutputType(typeof(string))]
    public class GetATEMMediaPoolStillFrame : PSCmdlet
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

        [Parameter()]
        public VideoModeResolution Resolution { get; set; } = VideoModeResolution._1080;

        [Parameter()]
        public int TimeoutSeconds { get; set; } = 30;

        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                throw new PSArgumentNullException(nameof(FilePath), "A file path is required.");

            string directory = Path.GetDirectoryName(FilePath);
            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            var completion = new TaskCompletionSource<AtemFrame>(TaskCreationOptions.RunContinuationsAsynchronously);
            var timeout = TimeSpan.FromSeconds(TimeoutSeconds);

            var job = new DownloadMediaStillJob(stillID, Resolution, frame => completion.TrySetResult(frame), timeout);
            ATEMref.DataTransfer.QueueJob(job);

            if (!completion.Task.Wait(timeout))
            {
                throw new TimeoutException($"Timed out downloading media still '{stillID}' from ATEM still index {stillID}.");
            }

            AtemFrame frame = completion.Task.Result;
            if (frame == null)
            {
                throw new RuntimeException($"Download of media still at index {stillID} failed.");
            }

            var size = Resolution.GetSize();
            byte[] rgba = frame.GetRGBA(ColourSpace.BT709);

            using var image = Image.LoadPixelData<Rgba32>(rgba, (int)size.Item1, (int)size.Item2);
            image.Save(FilePath);

            WriteObject(FilePath);
        }
    }
}
