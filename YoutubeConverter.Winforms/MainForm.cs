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
        public string TextBoxOutput
        {
            get => this.textBoxOutput.Text;
            set => this.textBoxOutput.EnsureControlThreadSynchronization(() => this.textBoxOutput.Text = value);
        }

        /// <inheritdoc />
        public bool ButtonConvertEnabled
        {
            get => this.buttonConvert.Enabled;
            set => this.textBoxOutput.EnsureControlThreadSynchronization(() => this.buttonConvert.Enabled = value);
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
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowDialog();

                this.TextBoxOutput = string.Empty;
                this.ButtonConvertEnabled = false;
                this.TextBoxOutput += $"Request to convert URL {this.TextBoxUrl} and save to path {folderBrowserDialog.SelectedPath}.{Environment.NewLine}";

                await this._converterController.ConvertUrlToMp3Async(this.TextBoxUrl, folderBrowserDialog.SelectedPath).ConfigureAwait(false);

                this.TextBoxOutput += $"Success!{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                this.TextBoxOutput += $"Failed to convert file.{Environment.NewLine}{Environment.NewLine}";
                this.TextBoxOutput += ex.Message;
            }
            finally
            {
                this.ButtonConvertEnabled = true;
                this.TextBoxUrl = string.Empty;
            }
        }
    }
}
