namespace YoutubeConverter
{
    /// <summary>
    ///     The main form view that provides access to form controls.
    /// </summary>
    public interface IMainFormView
    {
        /// <summary>
        ///     Gets and sets the URL of the YouTube video to convert.
        /// </summary>
        string TextBoxUrl { get; set; }

        /// <summary>
        ///     Gets and sets the text in the output window.
        /// </summary>
        string TextBoxOutput { get; set; }

        /// <summary>
        ///     Gets and sets the convert button enabled.
        /// </summary>
        bool ButtonConvertEnabled { get; set; }
    }
}
