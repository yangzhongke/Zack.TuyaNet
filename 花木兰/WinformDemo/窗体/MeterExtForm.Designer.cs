namespace WinformDemo
{
    partial class MeterExtForm
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
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem1 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem2 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem3 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem4 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem5 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem6 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem7 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            WinformControlLibraryExtension.MeterExt.ColorItem colorItem8 = new WinformControlLibraryExtension.MeterExt.ColorItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.meterBarExt5 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt3 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt4 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt8 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt7 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt6 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt2 = new WinformControlLibraryExtension.MeterExt();
            this.meterBarExt1 = new WinformControlLibraryExtension.MeterExt();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.meterBarExt5;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 523);
            this.propertyGrid1.TabIndex = 4;
            // 
            // meterBarExt5
            // 
            this.meterBarExt5.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.meterBarExt5.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.meterBarExt5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt5.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt5.CausesValidation = false;
            this.meterBarExt5.ForeColor = System.Drawing.Color.Black;
            colorItem1.Color = System.Drawing.Color.Blue;
            colorItem2.Color = System.Drawing.Color.Red;
            colorItem2.Position = 1F;
            this.meterBarExt5.GradualColorItems.Add(colorItem1);
            this.meterBarExt5.GradualColorItems.Add(colorItem2);
            this.meterBarExt5.GradualShow = true;
            this.meterBarExt5.Location = new System.Drawing.Point(365, 23);
            this.meterBarExt5.Name = "meterBarExt5";
            this.meterBarExt5.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt5.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt5.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt5.ScaleInterval = 20F;
            this.meterBarExt5.Size = new System.Drawing.Size(205, 222);
            this.meterBarExt5.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt5.TabIndex = 0;
            this.meterBarExt5.TabStop = false;
            this.meterBarExt5.Text = "meterBarExt5";
            this.meterBarExt5.Value = 30F;
            this.meterBarExt5.ValueDistance = 40;
            this.meterBarExt5.ValueShow = true;
            // 
            // meterBarExt3
            // 
            this.meterBarExt3.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.meterBarExt3.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.meterBarExt3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt3.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt3.BackShow = false;
            this.meterBarExt3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt3.CausesValidation = false;
            this.meterBarExt3.ForeColor = System.Drawing.Color.Black;
            colorItem3.Color = System.Drawing.Color.Blue;
            colorItem4.Color = System.Drawing.Color.Red;
            colorItem4.Position = 1F;
            this.meterBarExt3.GradualColorItems.Add(colorItem3);
            this.meterBarExt3.GradualColorItems.Add(colorItem4);
            this.meterBarExt3.GradualShow = true;
            this.meterBarExt3.Location = new System.Drawing.Point(777, 42);
            this.meterBarExt3.Name = "meterBarExt3";
            this.meterBarExt3.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt3.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt3.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt3.ScaleInterval = 20F;
            this.meterBarExt3.Size = new System.Drawing.Size(167, 169);
            this.meterBarExt3.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt3.TabIndex = 0;
            this.meterBarExt3.TabStop = false;
            this.meterBarExt3.Text = "meterBarExt3";
            this.meterBarExt3.Value = 50F;
            this.meterBarExt3.ValueShow = true;
            // 
            // meterBarExt4
            // 
            this.meterBarExt4.ArcAngle = 140;
            this.meterBarExt4.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.meterBarExt4.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.meterBarExt4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt4.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt4.BackShow = false;
            this.meterBarExt4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt4.CausesValidation = false;
            this.meterBarExt4.ForeColor = System.Drawing.Color.Black;
            colorItem5.Color = System.Drawing.Color.Blue;
            colorItem6.Color = System.Drawing.Color.Red;
            colorItem6.Position = 1F;
            this.meterBarExt4.GradualColorItems.Add(colorItem5);
            this.meterBarExt4.GradualColorItems.Add(colorItem6);
            this.meterBarExt4.GradualShow = true;
            this.meterBarExt4.Location = new System.Drawing.Point(947, 67);
            this.meterBarExt4.Name = "meterBarExt4";
            this.meterBarExt4.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt4.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt4.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt4.ScaleInterval = 20F;
            this.meterBarExt4.Size = new System.Drawing.Size(163, 144);
            this.meterBarExt4.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt4.SplitScaleCount = 2;
            this.meterBarExt4.TabIndex = 0;
            this.meterBarExt4.TabStop = false;
            this.meterBarExt4.Text = "meterBarExt4";
            this.meterBarExt4.Value = 30F;
            this.meterBarExt4.ValueShow = true;
            // 
            // meterBarExt8
            // 
            this.meterBarExt8.ArcAngle = 140;
            this.meterBarExt8.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt8.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.meterBarExt8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt8.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt8.BackShow = false;
            this.meterBarExt8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt8.CausesValidation = false;
            this.meterBarExt8.ForeColor = System.Drawing.Color.Black;
            this.meterBarExt8.Location = new System.Drawing.Point(947, 259);
            this.meterBarExt8.Name = "meterBarExt8";
            this.meterBarExt8.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt8.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt8.ScaleInterval = 20F;
            this.meterBarExt8.Size = new System.Drawing.Size(145, 172);
            this.meterBarExt8.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt8.SplitScaleCount = 2;
            this.meterBarExt8.TabIndex = 0;
            this.meterBarExt8.TabStop = false;
            this.meterBarExt8.Text = "meterBarExt8";
            this.meterBarExt8.Value = 30F;
            this.meterBarExt8.ValueShow = true;
            // 
            // meterBarExt7
            // 
            this.meterBarExt7.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt7.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.meterBarExt7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt7.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt7.BackShow = false;
            this.meterBarExt7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt7.CausesValidation = false;
            this.meterBarExt7.ForeColor = System.Drawing.Color.Black;
            this.meterBarExt7.Location = new System.Drawing.Point(788, 250);
            this.meterBarExt7.Name = "meterBarExt7";
            this.meterBarExt7.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt7.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt7.ScaleInterval = 20F;
            this.meterBarExt7.Size = new System.Drawing.Size(139, 181);
            this.meterBarExt7.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt7.TabIndex = 0;
            this.meterBarExt7.TabStop = false;
            this.meterBarExt7.Text = "meterBarExt7";
            this.meterBarExt7.Value = 90F;
            this.meterBarExt7.ValueShow = true;
            // 
            // meterBarExt6
            // 
            this.meterBarExt6.ArcAngle = 180;
            this.meterBarExt6.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.meterBarExt6.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.meterBarExt6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt6.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt6.CausesValidation = false;
            this.meterBarExt6.ForeColor = System.Drawing.Color.Black;
            colorItem7.Color = System.Drawing.Color.Blue;
            colorItem8.Color = System.Drawing.Color.Red;
            colorItem8.Position = 1F;
            this.meterBarExt6.GradualColorItems.Add(colorItem7);
            this.meterBarExt6.GradualColorItems.Add(colorItem8);
            this.meterBarExt6.GradualShow = true;
            this.meterBarExt6.Location = new System.Drawing.Point(572, 31);
            this.meterBarExt6.Name = "meterBarExt6";
            this.meterBarExt6.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt6.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.meterBarExt6.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt6.ScaleInterval = 20F;
            this.meterBarExt6.Size = new System.Drawing.Size(203, 180);
            this.meterBarExt6.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.meterBarExt6.TabIndex = 0;
            this.meterBarExt6.TabStop = false;
            this.meterBarExt6.Text = "meterBarExt6";
            this.meterBarExt6.Value = 70F;
            // 
            // meterBarExt2
            // 
            this.meterBarExt2.ArcAngle = 180;
            this.meterBarExt2.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt2.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.meterBarExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt2.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt2.CausesValidation = false;
            this.meterBarExt2.ForeColor = System.Drawing.Color.Black;
            this.meterBarExt2.Location = new System.Drawing.Point(572, 250);
            this.meterBarExt2.Name = "meterBarExt2";
            this.meterBarExt2.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt2.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt2.ScaleInterval = 20F;
            this.meterBarExt2.Size = new System.Drawing.Size(180, 181);
            this.meterBarExt2.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt2.TabIndex = 0;
            this.meterBarExt2.TabStop = false;
            this.meterBarExt2.Text = "meterBarExt2";
            this.meterBarExt2.Value = 60F;
            // 
            // meterBarExt1
            // 
            this.meterBarExt1.ArcBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt1.ArcValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.meterBarExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.meterBarExt1.BackInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.meterBarExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.meterBarExt1.CausesValidation = false;
            this.meterBarExt1.ForeColor = System.Drawing.Color.Black;
            this.meterBarExt1.Location = new System.Drawing.Point(372, 231);
            this.meterBarExt1.Name = "meterBarExt1";
            this.meterBarExt1.PointerCapColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt1.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(142)))), ((int)(((byte)(35)))));
            this.meterBarExt1.ScaleInterval = 20F;
            this.meterBarExt1.Size = new System.Drawing.Size(180, 200);
            this.meterBarExt1.SplitScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.meterBarExt1.TabIndex = 0;
            this.meterBarExt1.TabStop = false;
            this.meterBarExt1.Text = "meterBarExt1";
            this.meterBarExt1.Value = 30F;
            // 
            // MeterExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1139, 523);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.meterBarExt3);
            this.Controls.Add(this.meterBarExt4);
            this.Controls.Add(this.meterBarExt8);
            this.Controls.Add(this.meterBarExt7);
            this.Controls.Add(this.meterBarExt5);
            this.Controls.Add(this.meterBarExt6);
            this.Controls.Add(this.meterBarExt2);
            this.Controls.Add(this.meterBarExt1);
            this.Name = "MeterExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仪表控件";
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControlLibraryExtension.MeterExt meterBarExt1;
        private WinformControlLibraryExtension.MeterExt meterBarExt2;
        private WinformControlLibraryExtension.MeterExt meterBarExt3;
        private WinformControlLibraryExtension.MeterExt meterBarExt4;
        private WinformControlLibraryExtension.MeterExt meterBarExt5;
        private WinformControlLibraryExtension.MeterExt meterBarExt6;
        private WinformControlLibraryExtension.MeterExt meterBarExt7;
        private WinformControlLibraryExtension.MeterExt meterBarExt8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}