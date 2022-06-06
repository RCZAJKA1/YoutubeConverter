namespace YoutubeConverter
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Handles requests with user input to convert Youtube links to raw audio files.
    /// </summary>
    public interface IConverterController
    {
        /// <summary>
        ///     Converts the specified Youtube URL to an mp3 file.
        /// </summary>
        /// <param name="url">The URL of the YouTube video to convert.</param>
        /// <param name="savePath">The folder path to save the resulting mp3 file to.</param>
        Task ConvertUrlToMp3Async(string url, string savePath);
    }
}
