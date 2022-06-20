namespace YoutubeConverter
{
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc cref="IMainFormView"/>
    [ExcludeFromCodeCoverage]
    internal sealed class MainFormView : IMainFormView
    {
        /// <inheritdoc />
        public string TextBoxUrl { get; set; }

        /// <inheritdoc />
        public string TextBoxOutput { get; set; }

        /// <inheritdoc />
        public bool ButtonConvertEnabled { get; set; }
    }
}
