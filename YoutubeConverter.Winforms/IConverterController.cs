namespace YoutubeConverter
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Handles requests with user input to convert Youtube links to raw audio files.
    /// </summary>
    public interface IConverterController
    {
        /// <summary>
        ///     Downloads the specified YouTube video to the local machine.
        /// </summary>
        /// <param name="url">The URL of the YouTube video to convert.</param>
        /// <param name="savePath">The folder path to save the resulting mp3 file to.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="outputType">The output file type.</param>
        /// <returns>The <see cref="Task"/> that completed converting the URL to MP3.</returns>
        Task ConvertUrlToVideoAsync(string url, string savePath, string fileName = null, OutputType outputType = OutputType.mp3);

        /// <summary>
        ///     Verifies if the request is to cancel and cancels the conversion if necessary.
        /// </summary>
        void VerifyCancelConversion();

        /// <summary>
        ///     Cancels the currently running conversion.
        /// </summary>
        void CancelConversion();

        /// <summary>
        ///     Ensures that the specified URL is in the correct format and is a valid YouTube URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns><c>true</c> if the URL is a valid and correct URL, otherwise <c>false</c>.</returns>
        bool IsValidYoutubeUrl(string url);
    }
}
