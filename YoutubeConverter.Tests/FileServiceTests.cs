namespace YoutubeConverter.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class FileServiceTests
    {
        private readonly MockRepository _mockRepository;

        public FileServiceTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [Fact]
        public void WriteAllBytes_FilePathNull_Throws()
        {
            byte[] bytes = new byte[1] { 1 };
            FileService service = CreateService();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => service.WriteAllBytes(null, bytes));

            Assert.Equal("Value cannot be null. (Parameter 'filePath')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void WriteAllBytes_FilePathEmpty_Throws()
        {
            byte[] bytes = new byte[1] { 1 };
            FileService service = CreateService();

            ArgumentEmptyException exception = Assert.Throws<ArgumentEmptyException>(() => service.WriteAllBytes(string.Empty, bytes));

            Assert.Equal("filePath", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void WriteAllBytes_BytesNull_Throws()
        {
            FileService service = CreateService();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => service.WriteAllBytes("testFilePath", null));

            Assert.Equal("Value cannot be null. (Parameter 'bytes')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void WriteAllBytes_ValidParams_WritesBytes()
        {
            string tempFile = Path.GetTempFileName();
            string contents = "test";
            byte[] bytes = Encoding.UTF8.GetBytes(contents);

            FileService service = CreateService();
            try
            {
                // I/O test creates tmp file on disk
                service.WriteAllBytes(tempFile, bytes);

                // The file may already exist,
                // so we only assert it exists after writing
                Assert.True(File.Exists(tempFile));

                string readContent = File.ReadAllText(tempFile);
                Assert.NotNull(readContent);
                Assert.NotEmpty(readContent);
                Assert.Equal(contents, readContent);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task WriteAllBytesAsync_FilePathNull_ThrowsAsync()
        {
            CancellationToken cancellationToken = new(false);
            byte[] bytes = new byte[1] { 1 };
            FileService service = CreateService();

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.WriteAllBytesAsync(null, bytes, cancellationToken)).ConfigureAwait(false);

            Assert.Equal("Value cannot be null. (Parameter 'filePath')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task WriteAllBytesAsync_FilePathEmpty_ThrowsAsync()
        {
            CancellationToken cancellationToken = new(false);
            byte[] bytes = new byte[1] { 1 };
            FileService service = CreateService();

            ArgumentEmptyException exception = await Assert.ThrowsAsync<ArgumentEmptyException>(async () => await service.WriteAllBytesAsync(String.Empty, bytes, cancellationToken)).ConfigureAwait(false);

            Assert.Equal("filePath", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task WriteAllBytesAsync_BytesNull_ThrowsAsync()
        {
            CancellationToken cancellationToken = new(false);
            FileService service = CreateService();

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.WriteAllBytesAsync("testFilePath", null, cancellationToken)).ConfigureAwait(false);

            Assert.Equal("Value cannot be null. (Parameter 'bytes')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task WriteAllBytesAsync_ValidParams_WritesBytesAsync()
        {
            CancellationToken cancellationToken = new(false);
            string tempFile = Path.GetTempFileName();
            string contents = "test";
            byte[] bytes = Encoding.UTF8.GetBytes(contents);

            FileService service = CreateService();
            try
            {
                // I/O test creates tmp file on disk
                await service.WriteAllBytesAsync(tempFile, bytes);

                // The file may already exist,
                // so we only assert it exists after writing
                Assert.True(File.Exists(tempFile));

                string readContent = await File.ReadAllTextAsync(tempFile, cancellationToken).ConfigureAwait(false);
                Assert.NotNull(readContent);
                Assert.NotEmpty(readContent);
                Assert.Equal(contents, readContent);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteFile_FilePathNull_Throws()
        {
            FileService service = CreateService();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => service.DeleteFile(null));

            Assert.Equal("Value cannot be null. (Parameter 'filePath')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteFile_FilePathEmpty_Throws()
        {
            FileService service = CreateService();

            ArgumentEmptyException exception = Assert.Throws<ArgumentEmptyException>(() => service.DeleteFile(String.Empty));

            Assert.Equal("filePath", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteFile_FilePathValid_DeletesFile()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, $"test content");

            FileService service = CreateService();

            try
            {
                service.DeleteFile(tempFile);
                Assert.False(File.Exists(tempFile));
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void DirectoryExists_FilePathNull_Throws()
        {
            FileService service = CreateService();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => service.DirectoryExists(null));

            Assert.Equal("Value cannot be null. (Parameter 'directoryPath')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void DirectoryExists_FilePathEmpty_Throws()
        {
            FileService service = CreateService();

            ArgumentEmptyException exception = Assert.Throws<ArgumentEmptyException>(() => service.DirectoryExists(string.Empty));

            Assert.Equal("directoryPath", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void DirectoryExists_FilePathExists_VerifiesTrue()
        {
            FileService service = CreateService();

            bool result = service.DirectoryExists(Directory.GetCurrentDirectory());

            Assert.True(result);

            this._mockRepository.VerifyAll();
        }

        private static FileService CreateService()
        {
            return new FileService();
        }
    }
}
