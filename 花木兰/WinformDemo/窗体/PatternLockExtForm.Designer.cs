namespace WinformDemo
{
    partial class PatternLockExtForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.patternLockExt2 = new WinformControlLibraryExtension.PatternLockExt();
            this.patternLockExt1 = new WinformControlLibraryExtension.PatternLockExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(505, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(681, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "---";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(752, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "生成密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(731, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "验证密码";
            // 
            // patternLockExt2
            // 
            this.patternLockExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.patternLockExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.patternLockExt2.CausesValidation = false;
            this.patternLockExt2.Location = new System.Drawing.Point(647, 64);
            this.patternLockExt2.Name = "patternLockExt2";
            this.patternLockExt2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.patternLockExt2.Size = new System.Drawing.Size(220, 220);
            this.patternLockExt2.TabIndex = 0;
            this.patternLockExt2.TabStop = false;
            this.patternLockExt2.Text = "patternLockExt2";
            this.patternLockExt2.UnLock += new WinformControlLibraryExtension.PatternLockExt.UnLockEventHandler(this.patternLockExt2_UnLock);
            // 
            // patternLockExt1
            // 
            this.patternLockExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.patternLockExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.patternLockExt1.CausesValidation = false;
            this.patternLockExt1.Location = new System.Drawing.Point(384, 64);
            this.patternLockExt1.Name = "patternLockExt1";
            this.patternLockExt1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.patternLockExt1.Size = new System.Drawing.Size(220, 220);
            this.patternLockExt1.TabIndex = 0;
            this.patternLockExt1.TabStop = false;
            this.patternLockExt1.Text = "patternLockExt1";
            this.patternLockExt1.Type = WinformControlLibraryExtension.PatternLockExt.FunctionTypes.Create;
            this.patternLockExt1.UnLock += new WinformControlLibraryExtension.PatternLockExt.UnLockEventHandler(this.patternLockExt1_UnLock);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.patternLockExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 549);
            this.propertyGrid1.TabIndex = 15;
            // 
            // PatternLockExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(888, 549);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.patternLockExt2);
            this.Controls.Add(this.patternLockExt1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "PatternLockExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图案滑屏解锁控件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private WinformControlLibraryExtension.PatternLockExt patternLockExt1;
        private WinformControlLibraryExtension.PatternLockExt patternLockExt2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}