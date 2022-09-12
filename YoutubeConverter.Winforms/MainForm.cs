namespace YoutubeConverter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using YoutubeConverter.Winforms;

    /// <summary>
    ///     The main form.
    /// </summary>
    public partial class MainForm : Form, IMainFormView
    {
        private const string CONVERT = "Convert";
        private const string CANCEL = "Cancel";

        /// <summary>
        ///     The converter controller.
        /// </summary>
        private readonly IConverterController _converterController;

        /// <summary>
        ///     Creates a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="converterController">The converter controller.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MainForm(IConverterController converterController)
        {
            this._converterController = converterController ?? throw new ArgumentNullException(nameof(converterController));

            this.InitializeComponent();
        }

        #region IMainFormView

        /// <inheritdoc />
        public string TextBoxUrl
        {
            get => this.textBoxUrl.Text;
            set => this.textBoxUrl.EnsureControlThreadSynchronization(() => this.textBoxUrl.Text = value);
        }

        /// <inheritdoc />
        public bool TextBoxUrlReadOnly
        {
            get => this.textBoxUrl.ReadOnly;
            set => this.textBoxUrl.EnsureControlThreadSynchronization(() => this.textBoxUrl.ReadOnly = value);
        }

        /// <inheritdoc />
        public string TextBoxOutput
        {
            get => this.textBoxOutput.Text;
            set => this.textBoxOutput.EnsureControlThreadSynchronization(() => this.textBoxOutput.Text = value);
        }

        /// <inheritdoc />
        public string ConvertButtonText
        {
            get => this.buttonConvert.Text;
            set => this.buttonConvert.EnsureControlThreadSynchronization(() => this.buttonConvert.Text = value);
        }

        /// <inheritdoc />
        public Color ConvertButtonBackgroundColor
        {
            get => this.buttonConvert.BackColor;
            set => this.buttonConvert.EnsureControlThreadSynchronization(() => this.buttonConvert.BackColor = value);
        }

        /// <inheritdoc />
        public string StatusLabelText
        {
            get => this.toolStripStatusLabelMain.Text;
            set => this.toolStripStatusLabelMain.Text = value;
        }

        #endregion IMainFormView

        /// <summary>
        ///     The clicked event for the 'Convert' button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void ButtonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripStatusLabel test = new ToolStripStatusLabel();

                if (this.ConvertButtonText == CANCEL)
                {
                    this._converterController.CancelConversion();
                    this.TextBoxOutput += $"The operation was cancelled.";
                    this.StatusLabelText = "The operation was cancelled.";
                    this.TextBoxUrlReadOnly = false;
                    this.UpdateConvertButtonStatus();
                    return;
                }

                if (string.IsNullOrEmpty(this.TextBoxUrl) || !this._converterController.IsValidYoutubeUrl(this.TextBoxUrl))
                {
                    this.StatusLabelText = "Please enter a valid Youtube URL.";
                    return;
                }

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    this.TextBoxOutput += $"The operation was cancelled.{Environment.NewLine}";
                    this.StatusLabelText = "The operation was cancelled.";
                    this.UpdateConvertButtonStatus();
                    return;
                }

                this.UpdateConvertButtonStatus();
                this.TextBoxUrlReadOnly = true;
                this.TextBoxOutput = string.Empty;
                this.TextBoxOutput += $"Request to convert URL '{this.textBoxUrl.Text}' and save to path '{folderBrowserDialog.SelectedPath}'.{Environment.NewLine}{Environment.NewLine}";
                this.StatusLabelText = "Converting...";

                await this._converterController.ConvertUrlToMp3Async(this.TextBoxUrl, folderBrowserDialog.SelectedPath).ConfigureAwait(false);

                this.TextBoxOutput += $"Success!{Environment.NewLine}{Environment.NewLine}";
                this.StatusLabelText = "Conversion successful.";
                this.UpdateConvertButtonStatus();
            }
            catch (Exception ex)
            {
                this.TextBoxOutput += $"Failed to perform operation:{Environment.NewLine}";
                this.TextBoxOutput += $"{ex.Message}{Environment.NewLine}";
                this.StatusLabelText = $"Error: {ex.Message}";
                this.UpdateConvertButtonStatus();
            }
            finally
            {
                this.TextBoxUrl = string.Empty;
            }
        }

        /// <summary>
        ///     Updates the convert button status based on the current text.
        /// </summary>
        private void UpdateConvertButtonStatus()
        {
            // TODO: refactor to not rely on the text value
            switch (this.ConvertButtonText)
            {
                case CONVERT:
                    this.ConvertButtonText = CANCEL;
                    this.ConvertButtonBackgroundColor = Color.Red;
                    break;
                case CANCEL:
                    this.ConvertButtonText = CONVERT;
                    this.ConvertButtonBackgroundColor = Color.LightGreen;
                    break;
                default:
                    throw new InvalidOperationException("The convert button has an invalid text value.");
            }
        }
    }
}
