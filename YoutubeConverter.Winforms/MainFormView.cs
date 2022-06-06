namespace YoutubeConverter
{
    /// <inheritdoc cref="IMainFormView"/>
    internal sealed class MainFormView : IMainFormView
    {
        /// <inheritdoc />
        public string Url { get; set; }

        /// <inheritdoc />
        public string OutputText { get; set; }

        /// <inheritdoc />
        public bool ConvertButtonEnabled { get; set; }
    }
}
