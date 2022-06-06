namespace YoutubeConverter
{
    using System;
    using System.Windows.Forms;

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

        /// <inheritdoc />
        public string Url
        {
            get => this.textBoxUrl.Text;
            set => this.textBoxUrl.Text = value;
        }

        /// <inheritdoc />
        public string OutputText
        {
            get => this.textBoxOutput.Text;
            set => this.textBoxOutput.Text = value;
        }

        /// <inheritdoc />
        public bool ConvertButtonEnabled
        {
            get => this.buttonConvert.Enabled;
            set => this.buttonConvert.Enabled = value;
        }

        /// <summary>
        ///     The clicked event for the 'Convert' button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            // Sample video https://www.youtube.com/watch?v=4Iany6mSfHM

            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowDialog();

                this.textBoxOutput.Clear();
                this.buttonConvert.Enabled = false;
                this.textBoxOutput.Text += $"Request to convert URL {this.Url} and save to path {folderBrowserDialog.SelectedPath}.{Environment.NewLine}";

                this._converterController.ConvertUrlToMp3(this.Url, folderBrowserDialog.SelectedPath);
            }
            catch (Exception ex)
            {
                this.textBoxOutput.Text = ex.Message;
            }
            finally
            {
                this.buttonConvert.Enabled = true;
            }
        }
    }
}
