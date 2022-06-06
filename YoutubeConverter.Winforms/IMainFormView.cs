namespace YoutubeConverter
{
    /// <summary>
    ///     The main form view that provides access to form controls.
    /// </summary>
    internal interface IMainFormView
    {
        /// <summary>
        ///     Gets and sets the URL of the YouTube video to convert.
        /// </summary>
        public string TextBoxUrl { get; set; }

        /// <summary>
        ///     Gets and sets the text in the output window.
        /// </summary>
        public string TextBoxOutput { get; set; }

        /// <summary>
        ///     Gets and sets the convert button enabled.
        /// </summary>
        public bool ButtonConvertEnabled { get; set; }
    }
}
