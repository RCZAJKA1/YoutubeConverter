/*
 *  Open source package used to download Youtube videos
 *  https://github.com/omansak/libvideo
 */

namespace YoutubeConverter
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Converts YouTube links into various downloadable file formats.
    /// </summary>
    public interface IYoutubeService
    {
        /// <summary>
        ///     Downloads the YouTube video to the specified folder path.
        /// </summary>
        /// <param name="url">The URL of the video to convert..</param>
        /// <param name="savePath">The folder path to save the video.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="string"/> containing the downloaded mp3 file path.</returns>
        Task<string> DownloadVideoAsync(string url, string savePath, string fileName = null, OutputType outputType = OutputType.mp3, CancellationToken cancellationToken = default);
    }
}
