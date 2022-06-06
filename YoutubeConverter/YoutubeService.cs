/*
 *  Open source package used to download Youtube videos
 *  https://github.com/omansak/libvideo
 */

namespace YoutubeConverter
{
    using System;
    using System.IO;

    using MediaToolkit;
    using MediaToolkit.Model;

    using VideoLibrary;

    /// <inheritdoc cref="IYoutubeService"/>
    public sealed class YoutubeService : IYoutubeService
    {
        /// <inheritdoc />
        public void ConvertToMp3(string url, string savePath)
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
            YouTubeVideo vid = youtube.GetVideo(url);
            File.WriteAllBytes(savePath + vid.FullName, vid.GetBytes());

            MediaFile inputFile = new MediaFile { Filename = savePath + vid.FullName };

            string filePathWithoutExtension = Path.GetFileNameWithoutExtension(savePath + vid.FullName);
            MediaFile outputFile = new MediaFile { Filename = $"{filePathWithoutExtension}.mp3" };

            using Engine engine = new Engine();
            engine.GetMetadata(inputFile);
            engine.Convert(inputFile, outputFile);
        }
    }
}
