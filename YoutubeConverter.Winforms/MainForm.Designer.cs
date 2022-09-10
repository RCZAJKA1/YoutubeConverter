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
			this.SuspendLayout();
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(12, 15);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(31, 15);
			this.labelUrl.TabIndex = 0;
			this.labelUrl.Text = "URL:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(12, 33);
			this.textBoxUrl.Multiline = true;
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxUrl.Size = new System.Drawing.Size(357, 177);
			this.textBoxUrl.TabIndex = 0;
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Right;
			this.textBoxOutput.Location = new System.Drawing.Point(396, 0);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.ReadOnly = true;
			this.textBoxOutput.Size = new System.Drawing.Size(404, 450);
			this.textBoxOutput.TabIndex = 2;
			// 
			// buttonConvert
			// 
			this.buttonConvert.Location = new System.Drawing.Point(12, 391);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size(119, 47);
			this.buttonConvert.TabIndex = 3;
			this.buttonConvert.Text = "Convert";
			this.buttonConvert.UseVisualStyleBackColor = true;
			this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonConvert);
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.textBoxUrl);
			this.Controls.Add(this.labelUrl);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Youtube Converter";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonConvert;
    }
}
