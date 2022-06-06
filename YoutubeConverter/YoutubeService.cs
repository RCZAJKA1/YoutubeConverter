namespace YoutubeConverter
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using MediaToolkit;
    using MediaToolkit.Model;

    using VideoLibrary;

    /// <inheritdoc cref="IYoutubeService"/>
    public sealed class YoutubeService : IYoutubeService
    {
        /// <summary>
        ///     The file service.
        /// </summary>
        private readonly IFileService _fileService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="YoutubeService"/> class.
        /// </summary>
        /// <param name="fileService">The file service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public YoutubeService(IFileService fileService)
        {
            this._fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        /// <inheritdoc />
        public async Task ConvertToMp3Async(string url, string savePath, CancellationToken cancellationToken = default)
        {
            url.ThrowIfNull(nameof(url));
            url.ThrowIfEmpty(nameof(url));
            savePath.ThrowIfNull(nameof(savePath));
            savePath.ThrowIfEmpty(nameof(savePath));

            if (!this._fileService.DirectoryExists(savePath))
            {
                throw new InvalidOperationException("The specified save path does not exist.");
            }

            YouTube youtube = YouTube.Default;
            YouTubeVideo vid = await youtube.GetVideoAsync(url).ConfigureAwait(false);
            string filePathMp4 = Path.Combine(savePath, vid.FullName);
            byte[] videoBytes = await vid.GetBytesAsync().ConfigureAwait(false);

            // Write .mp4 file to disk
            await this._fileService.WriteAllBytesAsync(filePathMp4, videoBytes, cancellationToken).ConfigureAwait(false);

            MediaFile inputFile = new MediaFile { Filename = filePathMp4 };
            string filePathWithoutExtension = filePathMp4[..^4];
            MediaFile outputFile = new MediaFile { Filename = $"{filePathWithoutExtension}.mp3" };

            using Engine engine = new Engine();
            engine.GetMetadata(inputFile);

            // Convert .mp4 file into new .mp3 file and write to disk
            engine.Convert(inputFile, outputFile);

            this._fileService.DeleteFile(filePathMp4);
        }
    }
}
