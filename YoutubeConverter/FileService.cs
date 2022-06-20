namespace YoutubeConverter
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc cref="IFileService"/>
    public sealed class FileService : IFileService
    {
        /// <inheritdoc />
        public void WriteAllBytes(string filePath, byte[] bytes)
        {
            filePath.ThrowIfNull(nameof(filePath));
            filePath.ThrowIfEmpty(nameof(filePath));
            bytes.ThrowIfNull(nameof(bytes));

            File.WriteAllBytes(filePath, bytes);
        }

        /// <inheritdoc />
        public async Task WriteAllBytesAsync(string filePath, byte[] bytes, CancellationToken cancellationToken = default)
        {
            filePath.ThrowIfNull(nameof(filePath));
            filePath.ThrowIfEmpty(nameof(filePath));
            bytes.ThrowIfNull(nameof(bytes));

            await File.WriteAllBytesAsync(filePath, bytes, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void DeleteFile(string filePath)
        {
            filePath.ThrowIfNull(nameof(filePath));
            filePath.ThrowIfEmpty(nameof(filePath));

            File.Delete(filePath);
        }

        /// <inheritdoc />
        public bool DirectoryExists(string directoryPath)
        {
            directoryPath.ThrowIfNull(nameof(directoryPath));
            directoryPath.ThrowIfEmpty(nameof(directoryPath));

            return Directory.Exists(directoryPath);
        }
    }
}
