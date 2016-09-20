namespace XmlFiller.Views
{
    partial class SelectTop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topkandidater = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // topkandidater
            // 
            this.topkandidater.Dock = System.Windows.Forms.DockStyle.Left;
            this.topkandidater.FormattingEnabled = true;
            this.topkandidater.Location = new System.Drawing.Point(0, 0);
            this.topkandidater.Name = "topkandidater";
            this.topkandidater.Size = new System.Drawing.Size(191, 268);
            this.topkandidater.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(214, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SelectTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.topkandidater);
            this.Name = "SelectTop";
            this.Text = "SelectTop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox topkandidater;
        private System.Windows.Forms.Button btnOK;
    }
}