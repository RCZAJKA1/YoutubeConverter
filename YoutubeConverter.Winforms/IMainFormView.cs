namespace YoutubeConverter
{
    using System.Drawing;

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
        ///     Gets and sets if the url textbox is editable.
        /// </summary>
        bool TextBoxUrlReadOnly { get; set; }

        /// <summary>
        ///     Gets and sets the convert button text.
        /// </summary>
        string ConvertButtonText { get; set; }

        /// <summary>
        ///     Gets and sets the convert button background color.
        /// </summary>
        Color ConvertButtonBackgroundColor { get; set; }

        /// <summary>
        ///     Gets and sets the status label text.
        /// </summary>
        string StatusLabelText { get; set; }

        /// <summary>
        ///     Gets and sets the file output type.
        /// </summary>
        OutputType OutputType { get; set; }

        /// <summary>
        ///     Gets and sets the file name.
        /// </summary>
        string FileName { get; set; }
    }
}
