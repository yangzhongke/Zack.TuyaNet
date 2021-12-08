namespace WinformDemo
{
  partial class ThermometerExtForm
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.thermometerExt1 = new WinformControlLibraryExtension.ThermometerExt();
            this.thermometerExt5 = new WinformControlLibraryExtension.ThermometerExt();
            this.thermometerExt4 = new WinformControlLibraryExtension.ThermometerExt();
            this.thermometerExt3 = new WinformControlLibraryExtension.ThermometerExt();
            this.thermometerExt2 = new WinformControlLibraryExtension.ThermometerExt();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.thermometerExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 655);
            this.propertyGrid1.TabIndex = 1;
            // 
            // thermometerExt1
            // 
            this.thermometerExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.thermometerExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.thermometerExt1.CausesValidation = false;
            this.thermometerExt1.ForeColor = System.Drawing.Color.DimGray;
            this.thermometerExt1.Location = new System.Drawing.Point(386, 38);
            this.thermometerExt1.Name = "thermometerExt1";
            this.thermometerExt1.ScaleCutCount = 1;
            this.thermometerExt1.ScaleTextShow = false;
            this.thermometerExt1.Size = new System.Drawing.Size(80, 220);
            this.thermometerExt1.TabIndex = 0;
            this.thermometerExt1.TabStop = false;
            this.thermometerExt1.TcaleCutLineColor = System.Drawing.Color.Gray;
            this.thermometerExt1.Text = "-20-100";
            this.thermometerExt1.ValueBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.thermometerExt1.ValueChanged += new WinformControlLibraryExtension.ThermometerExt.ValueChangedEventHandler(this.thermometerExt_ValueChanged);
            // 
            // thermometerExt5
            // 
            this.thermometerExt5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.thermometerExt5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.thermometerExt5.CausesValidation = false;
            this.thermometerExt5.ForeColor = System.Drawing.Color.DimGray;
            this.thermometerExt5.Location = new System.Drawing.Point(806, 38);
            this.thermometerExt5.Name = "thermometerExt5";
            this.thermometerExt5.ScaleDirectionType = WinformControlLibraryExtension.ThermometerExt.ScaleDirection.Right;
            this.thermometerExt5.Size = new System.Drawing.Size(80, 220);
            this.thermometerExt5.TabIndex = 0;
            this.thermometerExt5.TabStop = false;
            this.thermometerExt5.TcaleCutLineColor = System.Drawing.Color.Gray;
            this.thermometerExt5.Text = "-20-100";
            this.thermometerExt5.ValueBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.thermometerExt5.ValueChanged += new WinformControlLibraryExtension.ThermometerExt.ValueChangedEventHandler(this.thermometerExt_ValueChanged);
            // 
            // thermometerExt4
            // 
            this.thermometerExt4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.thermometerExt4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.thermometerExt4.CausesValidation = false;
            this.thermometerExt4.ForeColor = System.Drawing.Color.DimGray;
            this.thermometerExt4.Location = new System.Drawing.Point(701, 38);
            this.thermometerExt4.Name = "thermometerExt4";
            this.thermometerExt4.ScaleCutCount = 1;
            this.thermometerExt4.ScaleDirectionType = WinformControlLibraryExtension.ThermometerExt.ScaleDirection.Right;
            this.thermometerExt4.Size = new System.Drawing.Size(80, 220);
            this.thermometerExt4.TabIndex = 0;
            this.thermometerExt4.TabStop = false;
            this.thermometerExt4.TcaleCutLineColor = System.Drawing.Color.Gray;
            this.thermometerExt4.Text = "-20-100";
            this.thermometerExt4.ValueBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.thermometerExt4.ValueChanged += new WinformControlLibraryExtension.ThermometerExt.ValueChangedEventHandler(this.thermometerExt_ValueChanged);
            // 
            // thermometerExt3
            // 
            this.thermometerExt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.thermometerExt3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.thermometerExt3.CausesValidation = false;
            this.thermometerExt3.ForeColor = System.Drawing.Color.DimGray;
            this.thermometerExt3.Location = new System.Drawing.Point(596, 38);
            this.thermometerExt3.Name = "thermometerExt3";
            this.thermometerExt3.Size = new System.Drawing.Size(80, 220);
            this.thermometerExt3.TabIndex = 0;
            this.thermometerExt3.TabStop = false;
            this.thermometerExt3.TcaleCutLineColor = System.Drawing.Color.Gray;
            this.thermometerExt3.Text = "-20-100";
            this.thermometerExt3.ValueBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.thermometerExt3.ValueChanged += new WinformControlLibraryExtension.ThermometerExt.ValueChangedEventHandler(this.thermometerExt_ValueChanged);
            // 
            // thermometerExt2
            // 
            this.thermometerExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.thermometerExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.thermometerExt2.CausesValidation = false;
            this.thermometerExt2.ForeColor = System.Drawing.Color.DimGray;
            this.thermometerExt2.Location = new System.Drawing.Point(491, 38);
            this.thermometerExt2.Name = "thermometerExt2";
            this.thermometerExt2.ScaleCutCount = 1;
            this.thermometerExt2.Size = new System.Drawing.Size(80, 220);
            this.thermometerExt2.TabIndex = 0;
            this.thermometerExt2.TabStop = false;
            this.thermometerExt2.TcaleCutLineColor = System.Drawing.Color.Gray;
            this.thermometerExt2.Text = "-20-100";
            this.thermometerExt2.ValueBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.thermometerExt2.ValueChanged += new WinformControlLibraryExtension.ThermometerExt.ValueChangedEventHandler(this.thermometerExt_ValueChanged);
            // 
            // ThermometerExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(929, 655);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.thermometerExt5);
            this.Controls.Add(this.thermometerExt4);
            this.Controls.Add(this.thermometerExt3);
            this.Controls.Add(this.thermometerExt2);
            this.Controls.Add(this.thermometerExt1);
            this.Name = "ThermometerExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "温度计控件";
            this.ResumeLayout(false);

    }

    #endregion

    private WinformControlLibraryExtension.ThermometerExt thermometerExt1;
    private System.Windows.Forms.Timer timer1;
    private WinformControlLibraryExtension.ThermometerExt thermometerExt2;
    private WinformControlLibraryExtension.ThermometerExt thermometerExt3;
    private WinformControlLibraryExtension.ThermometerExt thermometerExt4;
    private WinformControlLibraryExtension.ThermometerExt thermometerExt5;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}