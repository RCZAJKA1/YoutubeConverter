namespace YoutubeConverter
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using MediaToolkit;
    using MediaToolkit.Model;

    using VideoLibrary;

    /// <inheritdoc cref="IYoutubeService"/>
    public sealed class YoutubeService : IYoutubeService
    {
        /// <inheritdoc />
        public async Task ConvertToMp3Async(string url, string savePath)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("The argument cannot be empty or only contain white space.", nameof(url));
            }
            if (savePath == null)
            {
                throw new ArgumentNullException(nameof(savePath));
            }
            if (string.IsNullOrWhiteSpace(savePath))
            {
                throw new ArgumentException("The argument cannot be empty or only contain white space.", nameof(savePath));
            }
            if (!Directory.Exists(savePath))
            {
                throw new InvalidOperationException("The specified save path does not exist.");
            }

            YouTube youtube = YouTube.Default;
            YouTubeVideo vid = await youtube.GetVideoAsync(url).ConfigureAwait(false);
            string filePathMp4 = Path.Combine(savePath, vid.FullName);
            byte[] videoBytes = await vid.GetBytesAsync().ConfigureAwait(false);

            // Write .mp4 file to disk
            await File.WriteAllBytesAsync(filePathMp4, videoBytes).ConfigureAwait(false);

            MediaFile inputFile = new MediaFile { Filename = filePathMp4 };
            string filePathWithoutExtension = filePathMp4.Substring(0, filePathMp4.Length - 4);
            MediaFile outputFile = new MediaFile { Filename = $"{filePathWithoutExtension}.mp3" };

            using Engine engine = new Engine();
            engine.GetMetadata(inputFile);

            // Convert .mp4 file into new .mp3 file and write to disk
            engine.Convert(inputFile, outputFile);

            // TODO: create separate file service
            File.Delete(filePathMp4);
        }
    }
}
