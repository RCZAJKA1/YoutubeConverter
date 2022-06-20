namespace YoutubeConverter.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class GuardTests
    {
        private readonly MockRepository _mockRepository;

        public GuardTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [Fact]
        public void ThrowIfNull_ObjectNull_Throws()
        {
            int? test = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => test.ThrowIfNull(nameof(test)));

            Assert.Equal("Value cannot be null. (Parameter 'test')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void ThrowIfNull_ObjectNotNull_DoesNotThrow()
        {
            int? test = 123;

            test.ThrowIfNull(nameof(test));

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void ThrowIfEmpty_StringEmpty_Throws()
        {
            string empty = " ";
            ArgumentEmptyException exception = Assert.Throws<ArgumentEmptyException>(() => empty.ThrowIfEmpty(nameof(empty)));

            Assert.Equal("empty", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void ThrowIfEmpty_StringNotEmpty_DoesNotThrow()
        {
            string notEmpty = " test";
            notEmpty.ThrowIfEmpty(nameof(notEmpty));

            this._mockRepository.VerifyAll();
        }
    }
}
