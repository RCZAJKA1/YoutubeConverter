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
        public async Task<string> DownloadVideoAsync(string url, string savePath, OutputType outputType = OutputType.mp3, CancellationToken cancellationToken = default)
        {
            url.ThrowIfNull(nameof(url));
            url.ThrowIfEmpty(nameof(url));
            savePath.ThrowIfNull(nameof(savePath));
            savePath.ThrowIfEmpty(nameof(savePath));

            if (!this._fileService.DirectoryExists(savePath))
            {
                throw new DirectoryNotFoundException($"The specified save path does not exist: {savePath}");
            }

            YouTube youtube = YouTube.Default;
            YouTubeVideo youtubeVideo = await youtube.GetVideoAsync(url).ConfigureAwait(false);
            string filePathMp4 = Path.Combine(savePath, youtubeVideo.FullName);
            byte[] videoBytes = await youtubeVideo.GetBytesAsync().ConfigureAwait(false);

            // Write .mp4 file to disk
            await this._fileService.WriteAllBytesAsync(filePathMp4, videoBytes, cancellationToken).ConfigureAwait(false);

            MediaFile inputFile = new MediaFile { Filename = filePathMp4 };
            string filePathWithoutExtension = filePathMp4[..^4];

            // TODO: avoid direct file type conversion to prevent potential file corruption
            string desiredFilePath;
            switch (outputType)
            {
                case OutputType.mp4:
                    return filePathMp4;
                case OutputType.wav:
                    desiredFilePath = $"{filePathWithoutExtension}.wav";
                    break;
                default:
                    desiredFilePath = $"{filePathWithoutExtension}.mp3";
                    break;
            }

            MediaFile outputFile = new MediaFile { Filename = desiredFilePath };

            using Engine engine = new Engine();
            engine.GetMetadata(inputFile);

            // Convert original .mp4 file into desired file type
            engine.Convert(inputFile, outputFile);

            this._fileService.DeleteFile(filePathMp4);

            return Path.Combine(savePath, desiredFilePath);
        }
    }
}
