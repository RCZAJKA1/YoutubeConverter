namespace YoutubeConverter.Winforms.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class MainFormTests
    {
        private readonly MockRepository _mockRepository;

        public MainFormTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [Fact]
        public void Ctor_NullConverterController_Throws()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new MainForm(null));

            Assert.Equal("Value cannot be null. (Parameter 'converterController')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        // Further testing the UI would ecapsulate framework testing
        // This is outside the scope of unit testing
    }
}
