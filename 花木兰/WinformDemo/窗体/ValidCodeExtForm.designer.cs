namespace WinformDemo
{
  partial class ValidCodeExtForm
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.validCodeExt1 = new WinformControlLibraryExtension.ValidCodeExt();
            this.validCodeExt2 = new WinformControlLibraryExtension.ValidCodeExt();
            this.validCodeExt3 = new WinformControlLibraryExtension.ValidCodeExt();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(507, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "刷新验证码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.validCodeExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 516);
            this.propertyGrid1.TabIndex = 7;
            // 
            // validCodeExt1
            // 
            this.validCodeExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.validCodeExt1.Font = new System.Drawing.Font("微软雅黑", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.validCodeExt1.Location = new System.Drawing.Point(372, 28);
            this.validCodeExt1.Name = "validCodeExt1";
            this.validCodeExt1.Size = new System.Drawing.Size(120, 50);
            this.validCodeExt1.TabIndex = 0;
            this.validCodeExt1.TabStop = false;
            // 
            // validCodeExt2
            // 
            this.validCodeExt2.AnimationType = WinformControlLibraryExtension.ValidCodeExt.VerificationCode.GifFrameType.FullFrame;
            this.validCodeExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.validCodeExt2.Font = new System.Drawing.Font("微软雅黑", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.validCodeExt2.Location = new System.Drawing.Point(498, 28);
            this.validCodeExt2.Name = "validCodeExt2";
            this.validCodeExt2.Size = new System.Drawing.Size(120, 50);
            this.validCodeExt2.TabIndex = 0;
            this.validCodeExt2.TabStop = false;
            this.validCodeExt2.ValidCodeType = WinformControlLibraryExtension.ValidCodeExt.ValidCodeTypes.Arithmetic;
            // 
            // validCodeExt3
            // 
            this.validCodeExt3.AnimationShow = false;
            this.validCodeExt3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.validCodeExt3.BorderShow = true;
            this.validCodeExt3.Font = new System.Drawing.Font("微软雅黑", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.validCodeExt3.Location = new System.Drawing.Point(624, 28);
            this.validCodeExt3.Name = "validCodeExt3";
            this.validCodeExt3.Size = new System.Drawing.Size(120, 50);
            this.validCodeExt3.TabIndex = 0;
            this.validCodeExt3.TabStop = false;
            this.validCodeExt3.ValidCodeType = WinformControlLibraryExtension.ValidCodeExt.ValidCodeTypes.Chinese;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(498, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 21);
            this.textBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(574, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "验证";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(501, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "---";
            // 
            // ValidCodeExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(765, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.validCodeExt3);
            this.Controls.Add(this.validCodeExt2);
            this.Controls.Add(this.validCodeExt1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.button1);
            this.Name = "ValidCodeExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验证码控件";
            this.Load += new System.EventHandler(this.ValidCodeExtForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private WinformControlLibraryExtension.ValidCodeExt validCodeExt1;
        private WinformControlLibraryExtension.ValidCodeExt validCodeExt2;
        private WinformControlLibraryExtension.ValidCodeExt validCodeExt3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}