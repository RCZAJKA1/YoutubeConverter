namespace YoutubeConverter.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class ArgumentEmptyExceptionTests
    {
        [Fact]
        public void ArgumentEmptyException_NoParams_Verify()
        {
            try
            {
                throw new ArgumentEmptyException();
            }
            catch (ArgumentEmptyException exception)
            {
                Assert.Equal("The argument cannot be empty or only contain white space.", exception.Message);
            }
        }

        [Fact]
        public void ArgumentEmptyException_Message_Verify()
        {
            try
            {
                throw new ArgumentEmptyException("testMessage");
            }
            catch (ArgumentEmptyException exception)
            {
                Assert.Equal("testMessage", exception.Message);
            }
        }

        [Fact]
        public void ArgumentEmptyException_MessageAndInnerException_Verify()
        {
            try
            {
                throw new ArgumentEmptyException("testMessage", new Exception("inner exception"));
            }
            catch (ArgumentEmptyException exception)
            {
                Assert.Equal("testMessage", exception.Message);
                Exception? innerException = exception.InnerException;
                Assert.NotNull(innerException);
                Assert.Equal("inner exception", innerException?.Message);
            }
        }

        [Fact]
        public void ArgumentEmptyException_MessageAndParam_Verify()
        {
            try
            {
                throw new ArgumentEmptyException("testMessage", "testParam");
            }
            catch (ArgumentEmptyException exception)
            {
                Assert.Equal("testMessage (Parameter 'testParam')", exception.Message);
                Assert.Equal("testParam", exception.ParamName);
            }
        }

        [Fact]
        public void ArgumentEmptyException_MessageAndParamAndInner_Verify()
        {
            try
            {
                throw new ArgumentEmptyException("testMessage", "testParam", new Exception("inner exception"));
            }
            catch (ArgumentEmptyException exception)
            {
                Assert.Equal("testMessage (Parameter 'testParam')", exception.Message);
                Assert.Equal("testParam", exception.ParamName);

                Exception? innerException = exception.InnerException;
                Assert.NotNull(innerException);
                Assert.Equal("inner exception", innerException?.Message);
            }
        }
    }
}
