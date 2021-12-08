namespace WinformDemo
{
  partial class NumberTimeExtForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeExt4 = new WinformControlLibraryExtension.NumberTimeExt();
            this.timeExt3 = new WinformControlLibraryExtension.NumberTimeExt();
            this.timeExt1 = new WinformControlLibraryExtension.NumberTimeExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeExt4
            // 
            this.timeExt4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.timeExt4.CausesValidation = false;
            this.timeExt4.HourLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt4.LineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.timeExt4.LineShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.timeExt4.Location = new System.Drawing.Point(555, 123);
            this.timeExt4.MillisecondLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt4.MinuteLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt4.Name = "timeExt4";
            this.timeExt4.SecondLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt4.ShadowShow = false;
            this.timeExt4.Size = new System.Drawing.Size(265, 90);
            this.timeExt4.TabIndex = 0;
            this.timeExt4.TabStop = false;
            this.timeExt4.Text = "timeExt4";
            this.timeExt4.Value = new System.DateTime(((long)(0)));
            // 
            // timeExt3
            // 
            this.timeExt3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.timeExt3.CausesValidation = false;
            this.timeExt3.HourLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt3.LineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.timeExt3.LineShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.timeExt3.Location = new System.Drawing.Point(372, 123);
            this.timeExt3.MillisecondLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt3.MinuteLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt3.Name = "timeExt3";
            this.timeExt3.SecondLineHighlightColor = System.Drawing.Color.Empty;
            this.timeExt3.Size = new System.Drawing.Size(169, 90);
            this.timeExt3.TabIndex = 0;
            this.timeExt3.TabStop = false;
            this.timeExt3.Text = "timeExt3";
            this.timeExt3.TimeTypeFormat = WinformControlLibraryExtension.NumberTimeExt.NumberTimeFormats.HourMinute;
            this.timeExt3.Value = new System.DateTime(((long)(0)));
            // 
            // timeExt1
            // 
            this.timeExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.timeExt1.CausesValidation = false;
            this.timeExt1.HourLineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.timeExt1.LineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(130)))), ((int)(((byte)(238)))));
            this.timeExt1.LineShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.timeExt1.Location = new System.Drawing.Point(372, 27);
            this.timeExt1.MillisecondLineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.timeExt1.MinuteLineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.timeExt1.Name = "timeExt1";
            this.timeExt1.SecondLineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(128)))), ((int)(((byte)(114)))));
            this.timeExt1.Size = new System.Drawing.Size(385, 90);
            this.timeExt1.TabIndex = 0;
            this.timeExt1.TabStop = false;
            this.timeExt1.Text = "timeExt1";
            this.timeExt1.TimeTypeFormat = WinformControlLibraryExtension.NumberTimeExt.NumberTimeFormats.HourMinuteSecondMillisecond;
            this.timeExt1.Value = new System.DateTime(((long)(0)));
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.timeExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 490);
            this.propertyGrid1.TabIndex = 16;
            // 
            // NumberTimeExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(853, 491);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.timeExt4);
            this.Controls.Add(this.timeExt3);
            this.Controls.Add(this.timeExt1);
            this.Name = "NumberTimeExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数字时间控件";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
    private WinformControlLibraryExtension.NumberTimeExt timeExt1;
    private WinformControlLibraryExtension.NumberTimeExt timeExt3;
    private WinformControlLibraryExtension.NumberTimeExt timeExt4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}