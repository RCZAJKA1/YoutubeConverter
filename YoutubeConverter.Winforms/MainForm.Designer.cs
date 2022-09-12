namespace YoutubeConverter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.buttonConvert = new System.Windows.Forms.Button();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanelMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelUrl
			// 
			this.labelUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUrl.AutoSize = true;
			this.labelUrl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.labelUrl.Location = new System.Drawing.Point(3, 58);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(72, 21);
			this.labelUrl.TabIndex = 0;
			this.labelUrl.Text = "URL:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanelMain.SetColumnSpan(this.textBoxUrl, 4);
			this.textBoxUrl.Location = new System.Drawing.Point(81, 57);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxUrl.Size = new System.Drawing.Size(306, 23);
			this.textBoxUrl.TabIndex = 0;
			// 
			// textBoxOutput
			// 
			this.tableLayoutPanelMain.SetColumnSpan(this.textBoxOutput, 5);
			this.textBoxOutput.Location = new System.Drawing.Point(393, 49);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.ReadOnly = true;
			this.tableLayoutPanelMain.SetRowSpan(this.textBoxOutput, 8);
			this.textBoxOutput.Size = new System.Drawing.Size(388, 382);
			this.textBoxOutput.TabIndex = 2;
			// 
			// buttonConvert
			// 
			this.buttonConvert.BackColor = System.Drawing.Color.LightGreen;
			this.tableLayoutPanelMain.SetColumnSpan(this.buttonConvert, 2);
			this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonConvert.Location = new System.Drawing.Point(3, 371);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size(150, 60);
			this.buttonConvert.TabIndex = 3;
			this.buttonConvert.Text = "Convert";
			this.buttonConvert.UseVisualStyleBackColor = false;
			this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 10;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.Controls.Add(this.labelUrl, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.buttonConvert, 0, 8);
			this.tableLayoutPanelMain.Controls.Add(this.textBoxUrl, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.textBoxOutput, 5, 1);
			this.tableLayoutPanelMain.Controls.Add(this.statusStripMain, 0, 9);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 10;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.53362F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.639913F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(784, 461);
			this.tableLayoutPanelMain.TabIndex = 4;
			// 
			// statusStripMain
			// 
			this.tableLayoutPanelMain.SetColumnSpan(this.statusStripMain, 10);
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMain});
			this.statusStripMain.Location = new System.Drawing.Point(0, 439);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new System.Drawing.Size(784, 22);
			this.statusStripMain.TabIndex = 4;
			this.statusStripMain.Text = "statusStrip1";
			// 
			// toolStripStatusLabelMain
			// 
			this.toolStripStatusLabelMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
			this.toolStripStatusLabelMain.Size = new System.Drawing.Size(41, 17);
			this.toolStripStatusLabelMain.Text = "Ready";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.tableLayoutPanelMain);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Youtube Converter";
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonConvert;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMain;
	}
}
