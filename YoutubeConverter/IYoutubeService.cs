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
        ///     Converts the specified YouTube into an mp3 and saves to the specified folder path.
        /// </summary>
        /// <param name="url">The URL of the video to convert..</param>
        /// <param name="savePath">The folder path to save the mp3.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="string"/> containing the downloaded mp3 file path.</returns>
        Task<string> ConvertToMp3Async(string url, string savePath, CancellationToken cancellationToken = default);
    }
}
