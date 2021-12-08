namespace WinformDemo
{
  partial class RadarScanExtForm
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
            this.radarExt2 = new WinformControlLibraryExtension.RadarScanExt();
            this.radarExt1 = new WinformControlLibraryExtension.RadarScanExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // radarExt2
            // 
            this.radarExt2.AreaColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(213)))), ((int)(((byte)(138)))));
            this.radarExt2.AreaCrossColor = System.Drawing.Color.DarkKhaki;
            this.radarExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radarExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(183)))), ((int)(((byte)(107)))));
            this.radarExt2.CausesValidation = false;
            this.radarExt2.Location = new System.Drawing.Point(581, 41);
            this.radarExt2.Name = "radarExt2";
            this.radarExt2.PointColor = System.Drawing.Color.Coral;
            this.radarExt2.ScanColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(213)))), ((int)(((byte)(138)))));
            this.radarExt2.Size = new System.Drawing.Size(174, 174);
            this.radarExt2.TabIndex = 0;
            this.radarExt2.TabStop = false;
            this.radarExt2.Text = "radarExt2";
            // 
            // radarExt1
            // 
            this.radarExt1.AreaColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(202)))), ((int)(((byte)(230)))));
            this.radarExt1.AreaCrossColor = System.Drawing.SystemColors.ActiveCaption;
            this.radarExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radarExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarExt1.BorderShow = true;
            this.radarExt1.CausesValidation = false;
            this.radarExt1.Location = new System.Drawing.Point(376, 41);
            this.radarExt1.Name = "radarExt1";
            this.radarExt1.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(123)))), ((int)(((byte)(169)))));
            this.radarExt1.PointFlickerActive = false;
            this.radarExt1.ScanColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(202)))), ((int)(((byte)(230)))));
            this.radarExt1.Size = new System.Drawing.Size(174, 174);
            this.radarExt1.TabIndex = 0;
            this.radarExt1.TabStop = false;
            this.radarExt1.Text = "radarExt1";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.radarExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 609);
            this.propertyGrid1.TabIndex = 12;
            // 
            // RadarScanExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(780, 607);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.radarExt2);
            this.Controls.Add(this.radarExt1);
            this.Name = "RadarScanExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "雷达扫描控件";
            this.Load += new System.EventHandler(this.RadarExtForm_Load);
            this.ResumeLayout(false);

    }

    #endregion

    private WinformControlLibraryExtension.RadarScanExt radarExt1;
    private WinformControlLibraryExtension.RadarScanExt radarExt2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}