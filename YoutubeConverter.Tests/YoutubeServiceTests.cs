namespace YoutubeConverter.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class YoutubeServiceTests
    {
        private readonly MockRepository _mockRepository;

        private readonly Mock<IFileService> _mockFileService;

        public YoutubeServiceTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);

            this._mockFileService = this._mockRepository.Create<IFileService>();
        }

        [Fact]
        public void Ctor_NullFileService_Throws()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new YoutubeService(null));

            Assert.Equal("Value cannot be null. (Parameter 'fileService')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Ctor_ValidParams_CreatesInstance()
        {
            YoutubeService service = this.CreateService();

            Assert.NotNull(service);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertToMp3Async_UrlNull_ThrowsAsync()
        {
            string savePath = "testSavePath";
            CancellationToken cancellationToken = new(false);
            OutputType outputType = OutputType.mp3;

            YoutubeService service = this.CreateService();

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.DownloadVideoAsync(null, savePath, outputType, cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("Value cannot be null. (Parameter 'url')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertToMp3Async_UrlEmpty_ThrowsAsync()
        {
            string savePath = "testSavePath";
            CancellationToken cancellationToken = new(false);
            OutputType outputType = OutputType.mp3;

            YoutubeService service = this.CreateService();

            ArgumentEmptyException exception = await Assert.ThrowsAsync<ArgumentEmptyException>(async () => await service.DownloadVideoAsync(string.Empty, savePath, outputType, cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("url", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertToMp3Async_SavePathNull_ThrowsAsync()
        {
            string url = "https://google.com/";
            CancellationToken cancellationToken = new(false);
            OutputType outputType = OutputType.mp3;

            YoutubeService service = this.CreateService();

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.DownloadVideoAsync(url, null, outputType, cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("Value cannot be null. (Parameter 'savePath')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertToMp3Async_SavePathEmpty_ThrowsAsync()
        {
            string url = "https://google.com/";
            CancellationToken cancellationToken = new(false);
            OutputType outputType = OutputType.mp3;

            YoutubeService service = this.CreateService();

            ArgumentEmptyException exception = await Assert.ThrowsAsync<ArgumentEmptyException>(async () => await service.DownloadVideoAsync(url, string.Empty, outputType, cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("savePath", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertToMp3Async_DirectoryDoesNotExist_ThrowsAsync()
        {
            string url = "https://google.com/";
            string savePath = "testSavePath";
            CancellationToken cancellationToken = new(false);
            OutputType outputType = OutputType.mp3;

            this._mockFileService.Setup(x => x.DirectoryExists(It.Is<string>(y => y == savePath))).Returns(false);

            YoutubeService service = this.CreateService();
            DirectoryNotFoundException exception = await Assert.ThrowsAsync<DirectoryNotFoundException>(async () => await service.DownloadVideoAsync(url, savePath, outputType, cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal($"The specified save path does not exist: {savePath}", exception.Message);

            this._mockRepository.VerifyAll();
        }

        private YoutubeService CreateService()
        {
            return new YoutubeService(
                this._mockFileService.Object);
        }
    }
}
