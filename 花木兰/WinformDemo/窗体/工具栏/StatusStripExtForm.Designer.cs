namespace WinformDemo
{
    partial class StatusStripExtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusStripExtForm));
            this.statusStripExt1 = new WinformControlLibraryExtension.StatusStripExt();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripExt1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripExt1
            // 
            this.statusStripExt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.statusStripExt1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStripExt1.Location = new System.Drawing.Point(1, 271);
            this.statusStripExt1.Name = "statusStripExt1";
            this.statusStripExt1.Size = new System.Drawing.Size(623, 22);
            this.statusStripExt1.TabIndex = 0;
            this.statusStripExt1.Text = "statusStripExt1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::WinformDemo.Properties.Resources.statusstrip_versions;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::WinformDemo.Properties.Resources.statusstrip_versions;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::WinformDemo.Properties.Resources.statusstrip_versions;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // StatusStripExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(208)))), ((int)(((byte)(188)))));
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
            this.ClientSize = new System.Drawing.Size(625, 294);
            this.Controls.Add(this.statusStripExt1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatusStripExtForm";
            this.Padding = new System.Windows.Forms.Padding(1, 25, 1, 1);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "状态栏";
            this.Load += new System.EventHandler(this.StatusStripExtForm_Load);
            this.statusStripExt1.ResumeLayout(false);
            this.statusStripExt1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private WinformControlLibraryExtension.StatusStripExt statusStripExt1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}