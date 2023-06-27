namespace YoutubeConverter.Winforms.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class ConverterControllerTests
    {
        private readonly MockRepository _mockRepository;

        private readonly Mock<IMainFormView> _mockMainFormView;
        private readonly Mock<IYoutubeService> _mockYoutubeService;
        private readonly Mock<IFileService> _mockFileService;

        public ConverterControllerTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);

            this._mockMainFormView = this._mockRepository.Create<IMainFormView>();
            this._mockYoutubeService = this._mockRepository.Create<IYoutubeService>();
            this._mockFileService = this._mockRepository.Create<IFileService>();
        }

        [Fact]
        public void Ctor_NullMainFormView_Throws()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new ConverterController(null, this._mockYoutubeService.Object, this._mockFileService.Object));

            Assert.Equal("Value cannot be null. (Parameter 'mainFormView')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Ctor_NullYoutubeService_Throws()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new ConverterController(this._mockMainFormView.Object, null, this._mockFileService.Object));

            Assert.Equal("Value cannot be null. (Parameter 'youtubeService')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Ctor_NullFileService_Throws()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new ConverterController(this._mockMainFormView.Object, this._mockYoutubeService.Object, null));

            Assert.Equal("Value cannot be null. (Parameter 'fileService')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Ctor_ValidParams_CreatesInstance()
        {
            ConverterController controller = this.CreateConverterController();

            Assert.NotNull(controller);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_UrlNull_ThrowsAsync()
        {
            string savePath = "testSavePath";

            ConverterController controller = this.CreateConverterController();

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.ConvertUrlToVideoAsync(null, savePath).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("Value cannot be null. (Parameter 'url')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_UrlEmpty_ThrowsAsync()
        {
            string savePath = "testSavePath";

            ConverterController controller = this.CreateConverterController();

            ArgumentEmptyException exception = await Assert.ThrowsAsync<ArgumentEmptyException>(async () => await controller.ConvertUrlToVideoAsync(string.Empty, savePath).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("url", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_SavePathNull_ThrowsAsync()
        {
            string url = "https://google.com/";

            ConverterController controller = this.CreateConverterController();

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.ConvertUrlToVideoAsync(url, null).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("Value cannot be null. (Parameter 'savePath')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_SavePathEmpty_ThrowsAsync()
        {
            string url = "https://google.com/";

            ConverterController controller = this.CreateConverterController();

            ArgumentEmptyException exception = await Assert.ThrowsAsync<ArgumentEmptyException>(async () => await controller.ConvertUrlToVideoAsync(url, string.Empty).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal("savePath", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_UrlNotYoutubeFormatted_ThrowsAsync()
        {
            string url = "https://google.com/";
            string savePath = "testSavePath";

            ConverterController controller = this.CreateConverterController();

            FormatException exception = await Assert.ThrowsAsync<FormatException>(async () => await controller.ConvertUrlToVideoAsync(url, savePath).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal($"The specified URL is not in the correct format or is not a valid YouTube URL: '{url}'", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_DirectoryDoesNotExist_ThrowsAsync()
        {
            string url = "https://www.youtube.com/watch?v=";
            string savePath = "testSavePath";

            this._mockFileService.Setup(x => x.DirectoryExists(It.Is<string>(y => y == savePath))).Returns(false);

            ConverterController controller = this.CreateConverterController();

            DirectoryNotFoundException exception = await Assert.ThrowsAsync<DirectoryNotFoundException>(async () => await controller.ConvertUrlToVideoAsync(url, savePath).ConfigureAwait(false)).ConfigureAwait(false);

            Assert.Equal($"The specified save path does not exist: '{savePath}'", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ConvertUrlToVideoAsync_DirectoryExists_ConvertsToMp3Async()
        {
            string url = "https://www.youtube.com/watch?v=";
            string savePath = "testSavePath";
            string fileName = "testFileName";
            OutputType outputType = OutputType.mp3;

            this._mockFileService.Setup(x => x.DirectoryExists(It.Is<string>(y => y == savePath))).Returns(true);

            this._mockYoutubeService.Setup(x => x.DownloadVideoAsync(It.Is<string>(y => y == url), It.Is<string>(y => y == savePath), It.Is<string>(y => y == fileName), It.Is<OutputType>(y => y == outputType), It.IsAny<CancellationToken>())).ReturnsAsync("test");

            ConverterController controller = this.CreateConverterController();
            await controller.ConvertUrlToVideoAsync(url, savePath).ConfigureAwait(false);

            this._mockRepository.VerifyAll();
        }

        private ConverterController CreateConverterController()
        {
            return new ConverterController(
                this._mockMainFormView.Object,
                this._mockYoutubeService.Object,
                this._mockFileService.Object);
        }
    }
}
