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
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelUrl = new System.Windows.Forms.Label();
            this.labelOutputType = new System.Windows.Forms.Label();
            this.comboBoxOutputType = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxUrl, 6);
            this.textBoxUrl.Location = new System.Drawing.Point(159, 54);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.PlaceholderText = "https://www.youtube.com/watch?v=";
            this.textBoxUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUrl.Size = new System.Drawing.Size(462, 23);
            this.textBoxUrl.TabIndex = 0;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.buttonConvert.BackColor = System.Drawing.Color.LightGreen;
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonConvert, 2);
            this.buttonConvert.Location = new System.Drawing.Point(315, 373);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(150, 37);
            this.buttonConvert.TabIndex = 1;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = false;
            this.buttonConvert.Click += this.ButtonConvert_Click;
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
            this.tableLayoutPanelMain.Controls.Add(this.label2, 0, 9);
            this.tableLayoutPanelMain.Controls.Add(this.statusStripMain, 0, 9);
            this.tableLayoutPanelMain.Controls.Add(this.labelUrl, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxUrl, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConvert, 4, 8);
            this.tableLayoutPanelMain.Controls.Add(this.labelOutputType, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxOutputType, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.labelFileName, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxFileName, 2, 3);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 10;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.49675F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.27983F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.71367F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.761388F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.639913F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutPanelMain.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 0;
            // 
            // statusStripMain
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.statusStripMain, 10);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabelMain });
            this.statusStripMain.Location = new System.Drawing.Point(0, 439);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(784, 22);
            this.statusStripMain.TabIndex = 4;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMain
            // 
            this.toolStripStatusLabelMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            this.toolStripStatusLabelMain.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelMain.Text = "Ready";
            // 
            // labelUrl
            // 
            this.labelUrl.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.labelUrl.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelUrl, 2);
            this.labelUrl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUrl.Location = new System.Drawing.Point(3, 53);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(150, 25);
            this.labelUrl.TabIndex = 5;
            this.labelUrl.Text = "YouTube URL";
            this.labelUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOutputType
            // 
            this.labelOutputType.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.labelOutputType.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelOutputType, 2);
            this.labelOutputType.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOutputType.Location = new System.Drawing.Point(3, 97);
            this.labelOutputType.Name = "labelOutputType";
            this.labelOutputType.Size = new System.Drawing.Size(150, 25);
            this.labelOutputType.TabIndex = 6;
            this.labelOutputType.Text = "Output Type";
            this.labelOutputType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxOutputType
            // 
            this.comboBoxOutputType.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelMain.SetColumnSpan(this.comboBoxOutputType, 2);
            this.comboBoxOutputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutputType.FormattingEnabled = true;
            this.comboBoxOutputType.Location = new System.Drawing.Point(159, 98);
            this.comboBoxOutputType.Name = "comboBoxOutputType";
            this.comboBoxOutputType.Size = new System.Drawing.Size(150, 23);
            this.comboBoxOutputType.TabIndex = 7;
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.labelFileName.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelFileName, 2);
            this.labelFileName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFileName.Location = new System.Drawing.Point(3, 141);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(150, 25);
            this.labelFileName.TabIndex = 6;
            this.labelFileName.Text = "File Name";
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxFileName, 6);
            this.textBoxFileName.Location = new System.Drawing.Point(159, 142);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.PlaceholderText = "Artist - Song";
            this.textBoxFileName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFileName.Size = new System.Drawing.Size(462, 23);
            this.textBoxFileName.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
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
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMain;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelOutputType;
        private System.Windows.Forms.ComboBox comboBoxOutputType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textBoxFileName;
    }
}
