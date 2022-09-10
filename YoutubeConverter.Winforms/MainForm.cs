namespace YoutubeConverter
{
    using System;
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
                if (this.ConvertButtonText == CANCEL)
                {
                    this._converterController.CancelConversion();
                    this.TextBoxOutput += $"The operation was cancelled.";
                    this.TextBoxUrlReadOnly = false;
                    this.UpdateConvertButtonText();
                    return;
                }

                if (string.IsNullOrEmpty(this.TextBoxUrl))
                {
                    throw new ArgumentEmptyException("The URL cannot be empty.", nameof(this.TextBoxUrl));
                }

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    this.TextBoxOutput += $"The operation was cancelled.{Environment.NewLine}";
                    return;
                }

                this.UpdateConvertButtonText();
                this.TextBoxUrlReadOnly = true;
                this.TextBoxOutput = string.Empty;
                this.TextBoxOutput += $"Request to convert URL '{this.textBoxUrl.Text}' and save to path '{folderBrowserDialog.SelectedPath}'.{Environment.NewLine}{Environment.NewLine}";

                await this._converterController.ConvertUrlToMp3Async(this.TextBoxUrl, folderBrowserDialog.SelectedPath).ConfigureAwait(false);

                this.TextBoxOutput += $"Success!{Environment.NewLine}{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                this.TextBoxOutput += $"Failed to perform operation:{Environment.NewLine}";
                this.TextBoxOutput += $"{ex.Message}{Environment.NewLine}";
            }
            finally
            {
                this.TextBoxUrl = string.Empty;
            }
        }

        /// <summary>
        ///     Updates the convert button text based on the current value.
        /// </summary>
        private void UpdateConvertButtonText()
        {
            this.ConvertButtonText = this.ConvertButtonText switch
            {
                CONVERT => CANCEL,
                CANCEL => CONVERT,
                _ => throw new InvalidOperationException("The convert button has an invalid text value."),
            };
        }
    }
}
