namespace YoutubeConverter
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
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

            this.InitializeData();
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
            set => this.statusStripMain.EnsureControlThreadSynchronization(() => this.toolStripStatusLabelMain.Text = value);
        }

        /// <inheritdoc />
        public OutputType OutputType
        {
            get
            {
                Enum.TryParse(this.comboBoxOutputType.SelectedValue.ToString(), out OutputType outputType);
                return outputType;
            }
            set => this.comboBoxOutputType.EnsureControlThreadSynchronization(() =>
            {
                this.comboBoxOutputType.SelectedValue = value;
                this.comboBoxOutputType.Text = value.ToString();
            });
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
                    this.StatusLabelText = "The operation was cancelled.";
                    this.TextBoxUrlReadOnly = false;
                    this.UpdateConvertButtonStatus();
                    return;
                }

                string validationMessage = this.ValidateUserInput();
                if (validationMessage != null)
                {
                    this.StatusLabelText = validationMessage;
                    return;
                }

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    this.StatusLabelText = "The operation was cancelled.";
                    this.UpdateConvertButtonStatus();
                    return;
                }

                this.UpdateConvertButtonStatus();
                this.TextBoxUrlReadOnly = true;
                this.StatusLabelText = "Converting...";

                await this._converterController.ConvertUrlToVideoAsync(this.TextBoxUrl, folderBrowserDialog.SelectedPath, this.OutputType).ConfigureAwait(false);

                this.StatusLabelText = "Conversion successful.";
                this.UpdateConvertButtonStatus();
            }
            catch (Exception ex)
            {
                this.StatusLabelText = $"Error: {ex.Message}";
                this.UpdateConvertButtonStatus();
            }
            finally
            {
                this.TextBoxUrl = string.Empty;
                this.TextBoxUrlReadOnly = false;
            }
        }

        /// <summary>
        ///     Verifies that all required UI fields are fulfilled prior to starting conversion.
        /// </summary>
        /// <returns>Invalid messages if any required fields are missing. Otherwise, null.</returns>
        private string ValidateUserInput()
        {
            if (string.IsNullOrEmpty(this.TextBoxUrl) || !this._converterController.IsValidYoutubeUrl(this.TextBoxUrl))
            {
                return "Please enter a valid Youtube URL.";
            }

            string[] allOutputTypes = Enum.GetNames(typeof(OutputType));
            if (!allOutputTypes.Contains(this.comboBoxOutputType.Text))
            {
                return "Please select a valid output type.";
            }

            return null;
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

        /// <summary>
        ///     Populates component data sources and sets default values.
        /// </summary>
        private void InitializeData()
        {
            this.comboBoxOutputType.DataSource = Enum.GetValues(typeof(OutputType));
        }
    }
}
