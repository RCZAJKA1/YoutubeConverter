namespace YoutubeConverter
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc cref="IConverterController"/>
    internal sealed class ConverterController : IConverterController
    {
        private const string CONVERT = "Convert";
        private const string CANCEL = "Cancel";

        /// <summary>
        ///     The main form view.
        /// </summary>
        private readonly IMainFormView _mainFormView;

        /// <summary>
        ///     The YouTube service.
        /// </summary>
        private readonly IYoutubeService _youtubeService;

        /// <summary>
        ///     The file service.
        /// </summary>
        private readonly IFileService _fileService;

        /// <summary>
        ///     The cancellation token source.
        /// </summary>
        internal CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        ///     Creates a new instance of the <see cref="ConverterController"/> class.
        /// </summary>
        /// <param name="mainFormView">The main form view.</param>
        /// <param name="youtubeService">The youtube service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ConverterController(IMainFormView mainFormView, IYoutubeService youtubeService, IFileService fileService)
        {
            this._mainFormView = mainFormView ?? throw new ArgumentNullException(nameof(mainFormView));
            this._youtubeService = youtubeService ?? throw new ArgumentNullException(nameof(youtubeService));
            this._fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));

            this._cancellationTokenSource = new CancellationTokenSource();

            //this._mainFormView.ConvertButtonText = CONVERT;
        }

        /// <inheritdoc />
        public async Task ConvertUrlToVideoAsync(string url, string savePath, OutputType outputType = OutputType.mp3)
        {
            url.ThrowIfNull(nameof(url));
            url.ThrowIfEmpty(nameof(url));
            savePath.ThrowIfNull(nameof(savePath));
            savePath.ThrowIfEmpty(nameof(savePath));

            if (!this.IsValidYoutubeUrl(url))
            {
                throw new FormatException($"The specified URL is not in the correct format or is not a valid YouTube URL: '{url}'");
            }

            if (!this._fileService.DirectoryExists(savePath))
            {
                throw new DirectoryNotFoundException($"The specified save path does not exist: '{savePath}'");
            }

            string resultFilePath = await this._youtubeService.DownloadVideoAsync(url, savePath, outputType, this._cancellationTokenSource.Token).ConfigureAwait(false);
            this._fileService.VerifySuccessfulDownload(resultFilePath);
        }

        /// <inheritdoc />
        public void VerifyCancelConversion()
        {
            if (this._mainFormView.ConvertButtonText == "Cancel")
            {
                this.CancelConversion();
                this._mainFormView.TextBoxUrlReadOnly = false;
                this.UpdateConvertButtonText();
                return;
            }
        }

        /// <inheritdoc />
        public void CancelConversion()
        {
            this._cancellationTokenSource.Cancel();
            this._cancellationTokenSource.Dispose();
            this._cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        ///     Ensures that the specified URL is in the correct format and is a valid YouTube URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns><c>true</c> if the URL is a valid and correct URL, otherwise <c>false</c>.</returns>
        public bool IsValidYoutubeUrl(string url)
        {
            bool isUrl = Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            bool isYoutube = url.StartsWith("https://www.youtube.com/watch?v=", StringComparison.Ordinal);

            return isUrl && isYoutube;
        }

        /// <summary>
        ///     Updates the convert button text based on the current value.
        /// </summary>
        private void UpdateConvertButtonText()
        {
            this._mainFormView.ConvertButtonText = this._mainFormView.ConvertButtonText switch
            {
                CONVERT => CANCEL,
                CANCEL => CONVERT,
                _ => throw new InvalidOperationException("The convert button has an invalid text value."),
            };
        }
    }
}
