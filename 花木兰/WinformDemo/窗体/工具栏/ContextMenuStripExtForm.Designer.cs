namespace WinformDemo
{
    partial class ContextMenuStripExtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextMenuStripExtForm));
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripExt1 = new WinformControlLibraryExtension.ContextMenuStripExt();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox4 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripExt1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ContextMenuStrip = this.contextMenuStripExt1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(190, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "右键菜单";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripExt1
            // 
            this.contextMenuStripExt1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.contextMenuStripExt1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripSeparator4,
            this.toolStripMenuItem20,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22,
            this.toolStripMenuItem23,
            this.toolStripMenuItem24,
            this.toolStripMenuItem25});
            this.contextMenuStripExt1.Name = "contextMenuStripExt1";
            this.contextMenuStripExt1.Size = new System.Drawing.Size(200, 208);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Checked = true;
            this.toolStripMenuItem17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem17.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem17.Text = "toolStripMenuItem17";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem5.Text = "toolStripMenuItem5";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox4,
            this.toolStripTextBox4});
            this.toolStripMenuItem18.Image = global::WinformDemo.Properties.Resources.menu;
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem18.Text = "toolStripMenuItem18";
            // 
            // toolStripComboBox4
            // 
            this.toolStripComboBox4.Items.AddRange(new object[] {
            "fdsfsdfdsf",
            "dsfsdfsdf",
            "dfdsfsdf",
            "dsfdsfsdfd"});
            this.toolStripComboBox4.Name = "toolStripComboBox4";
            this.toolStripComboBox4.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem19.Text = "toolStripMenuItem19";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem20.Text = "toolStripMenuItem20";
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem21.Text = "toolStripMenuItem21";
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem22.Text = "toolStripMenuItem22";
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem23.Text = "toolStripMenuItem23";
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem24.Text = "toolStripMenuItem24";
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItem25.Text = "toolStripMenuItem25";
            // 
            // ContextMenuStripExtForm
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
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.ContextMenuStrip = this.contextMenuStripExt1;
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContextMenuStripExtForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "右键菜单";
            this.Load += new System.EventHandler(this.ContextMenuStripExtForm_Load);
            this.contextMenuStripExt1.ResumeLayout(false);
            this.ResumeLayout(false);

        }





        #endregion
        private System.Windows.Forms.Button button1;
        private WinformControlLibraryExtension.ContextMenuStripExt contextMenuStripExt1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem23;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem24;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}