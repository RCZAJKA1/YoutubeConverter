namespace YoutubeConverter.Winforms.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public sealed class ControlHelperTests
    {
        private readonly MockRepository _mockRepository;

        public ControlHelperTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [Fact]
        public void EnsureControlThreadSynchronization_NullControl_Throws()
        {
            Label? label = null;
            Action action = () =>
            {
                if (label != null)
                {
                    label.Text = "add text";
                }
            };

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => label.EnsureControlThreadSynchronization(action));

            Assert.Equal("Value cannot be null. (Parameter 'control')", exception.Message);

            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void EnsureControlThreadSynchronization_InvokeNotRequired_InvokesActionFromMainThread()
        {
            Label label = new Label();
            Action action = () =>
            {
                label.Text = "add text";
            };

            label.EnsureControlThreadSynchronization(action);

            Assert.NotNull(label.Text);
            Assert.NotEmpty(label.Text);
            Assert.Equal("add text", label.Text);

            this._mockRepository.VerifyAll();
        }
    }
}
