namespace YoutubeConverter
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    /// <inheritdoc cref="IConverterController"/>
    internal sealed class ConverterController : IConverterController
    {
        /// <summary>
        ///     The main form view.
        /// </summary>
        private readonly IMainFormView _mainFormView;

        /// <summary>
        ///     The YouTube service.
        /// </summary>
        private readonly IYoutubeService _youtubeService;

        /// <summary>
        ///     Creates a new instance of the <see cref="ConverterController"/> class.
        /// </summary>
        /// <param name="mainFormView">The main form view.</param>
        /// <param name="youtubeService">The youtube service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ConverterController(IMainFormView mainFormView, IYoutubeService youtubeService)
        {
            this._mainFormView = mainFormView ?? throw new ArgumentNullException(nameof(mainFormView));
            this._youtubeService = youtubeService ?? throw new ArgumentNullException(nameof(youtubeService));
        }

        /// <inheritdoc />
        public async Task ConvertUrlToMp3Async(string url, string savePath)
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

            bool isValidUrl = this.IsValidYoutubeUrl(url);
            if (!isValidUrl)
            {
                throw new FormatException("The specified URL is not in the correct format or is not a valid YouTube URL.");
            }

            if (!Directory.Exists(savePath))
            {
                throw new InvalidOperationException("The specified save path does not exist.");
            }

            this._mainFormView.TextBoxOutput += $"Starting conversion to mp3...{Environment.NewLine}";

            await this._youtubeService.ConvertToMp3Async(url, savePath).ConfigureAwait(false);
        }

        /// <summary>
        ///     Ensures that the specified URL is in the correct format and is a valid YouTube URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns><c>true</c> if the URL is a valid and correct URL, otherwise <c>false</c>.</returns>
        private bool IsValidYoutubeUrl(string url)
        {
            bool isUrl = Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            bool isYoutube = url.StartsWith("https://www.youtube.com/watch?v=", StringComparison.Ordinal);

            return isUrl && isYoutube;
        }
    }
}
