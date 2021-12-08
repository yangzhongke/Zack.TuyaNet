namespace WinformDemo
{
    partial class FormExtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExtForm));
            this.SuspendLayout();
            // 
            // FormExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageCaption = false;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CaptionBox.BackColor = System.Drawing.Color.Empty;
            this.CaptionBox.CloseBtn.EnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.CloseBtn.NormalBackColor = System.Drawing.Color.Empty;
            this.CaptionBox.CloseBtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.CloseBtn.TipText1 = "关闭";
            this.CaptionBox.CloseBtn.TipText2 = "关闭";
            this.CaptionBox.MaxBtn.EnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MaxBtn.NormalBackColor = System.Drawing.Color.Empty;
            this.CaptionBox.MaxBtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MaxBtn.TipText1 = "最大化";
            this.CaptionBox.MaxBtn.TipText2 = "向下还原";
            this.CaptionBox.MinBtn.EnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MinBtn.NormalBackColor = System.Drawing.Color.Empty;
            this.CaptionBox.MinBtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MinBtn.TipText1 = "最小化";
            this.CaptionBox.MinBtn.TipText2 = "最小化";
            this.ClientSize = new System.Drawing.Size(582, 485);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormExtForm";
            this.ResumeLayout(false);

        }

        #endregion
    }
}