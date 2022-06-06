namespace YoutubeConverter
{
    /// <inheritdoc cref="IMainFormView"/>
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
