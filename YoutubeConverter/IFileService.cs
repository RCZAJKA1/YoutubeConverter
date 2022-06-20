namespace YoutubeConverter
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Handles file I/O operations.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        ///     Synchronously creates a new file, writes the specified byte array to the file,
        ///     and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="bytes">The bytes to download.</param>
        void WriteAllBytes(string filePath, byte[] bytes);

        /// <summary>
        ///     Asynchronously creates a new file, writes the specified byte array to the file,
        ///     and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="bytes">The bytes to download.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        Task WriteAllBytesAsync(string filePath, byte[] bytes, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        void DeleteFile(string filePath);

        /// <summary>
        ///     Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns><c>true</c> if the directory exists, otherwise <c>false</c>.</returns>
        bool DirectoryExists(string directoryPath);
    }
}
