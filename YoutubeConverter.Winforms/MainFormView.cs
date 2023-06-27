namespace YoutubeConverter
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    /// <inheritdoc cref="IMainFormView"/>
    [ExcludeFromCodeCoverage]
    internal sealed class MainFormView : IMainFormView
    {
        /// <inheritdoc />
        public string TextBoxUrl { get; set; }

        /// <inheritdoc />
        public bool TextBoxUrlReadOnly { get; set; }

        /// <inheritdoc />
        public string TextBoxOutput { get; set; }

        /// <inheritdoc />
        public string ConvertButtonText { get; set; }

        /// <inheritdoc />
        public Color ConvertButtonBackgroundColor { get; set; }

        /// <inheritdoc />
        public string StatusLabelText { get; set; }

        /// <inheritdoc />
        public OutputType OutputType { get; set; }

        /// <inheritdoc />
        public string FileName { get; set; }
    }
}
