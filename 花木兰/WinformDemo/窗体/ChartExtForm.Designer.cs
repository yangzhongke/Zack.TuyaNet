namespace WinformDemo
{
  partial class ChartExtForm
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
            WinformControlLibraryExtension.ChartExt.ColorItem colorItem1 = new WinformControlLibraryExtension.ChartExt.ColorItem();
            WinformControlLibraryExtension.ChartExt.ColorItem colorItem2 = new WinformControlLibraryExtension.ChartExt.ColorItem();
            WinformControlLibraryExtension.ChartExt.ColorItem colorItem3 = new WinformControlLibraryExtension.ChartExt.ColorItem();
            WinformControlLibraryExtension.ChartExt.ColorItem colorItem4 = new WinformControlLibraryExtension.ChartExt.ColorItem();
            WinformControlLibraryExtension.ChartExt.ColorItem colorItem5 = new WinformControlLibraryExtension.ChartExt.ColorItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chartExt2 = new WinformControlLibraryExtension.ChartExt();
            this.chartExt1 = new WinformControlLibraryExtension.ChartExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // chartExt2
            // 
            this.chartExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chartExt2.CausesValidation = false;
            this.chartExt2.Font = new System.Drawing.Font("宋体", 11F);
            this.chartExt2.LineBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt2.LineDotColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chartExt2.LineDotShow = true;
            this.chartExt2.Location = new System.Drawing.Point(365, 216);
            this.chartExt2.Name = "chartExt2";
            this.chartExt2.Size = new System.Drawing.Size(660, 165);
            this.chartExt2.TabIndex = 0;
            this.chartExt2.TabStop = false;
            this.chartExt2.Text = "chartExt2";
            this.chartExt2.TipBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(193)))));
            this.chartExt2.TipShow = true;
            // 
            // chartExt1
            // 
            this.chartExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chartExt1.CausesValidation = false;
            colorItem1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(205)))), ((int)(((byte)(139)))));
            colorItem2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(199)))), ((int)(((byte)(182)))));
            colorItem2.Position = 0.22F;
            colorItem3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(152)))), ((int)(((byte)(120)))));
            colorItem3.Position = 0.34F;
            colorItem4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(123)))), ((int)(((byte)(91)))));
            colorItem4.Position = 0.46F;
            colorItem5.Color = System.Drawing.Color.Indigo;
            colorItem5.Position = 1F;
            this.chartExt1.ColorItems.Add(colorItem1);
            this.chartExt1.ColorItems.Add(colorItem2);
            this.chartExt1.ColorItems.Add(colorItem3);
            this.chartExt1.ColorItems.Add(colorItem4);
            this.chartExt1.ColorItems.Add(colorItem5);
            this.chartExt1.ColorType = WinformControlLibraryExtension.ChartExt.ChartColorType.Gradient;
            this.chartExt1.Font = new System.Drawing.Font("宋体", 11F);
            this.chartExt1.HLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(158)))));
            this.chartExt1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(123)))), ((int)(((byte)(91)))));
            this.chartExt1.LineDotColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(112)))), ((int)(((byte)(219)))));
            this.chartExt1.Location = new System.Drawing.Point(365, 28);
            this.chartExt1.Name = "chartExt1";
            this.chartExt1.Size = new System.Drawing.Size(660, 165);
            this.chartExt1.TabIndex = 0;
            this.chartExt1.TabStop = false;
            this.chartExt1.Text = "chartExt1";
            this.chartExt1.TipBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(158)))));
            this.chartExt1.TipShow = true;
            this.chartExt1.VLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(171)))), ((int)(((byte)(207)))), ((int)(((byte)(158)))));
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.chartExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 513);
            this.propertyGrid1.TabIndex = 9;
            // 
            // ChartExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1036, 514);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.chartExt2);
            this.Controls.Add(this.chartExt1);
            this.Name = "ChartExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实时速度分析图控件";
            this.ResumeLayout(false);

    }

    #endregion

    private WinformControlLibraryExtension.ChartExt chartExt1;
    private WinformControlLibraryExtension.ChartExt chartExt2;
    private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}