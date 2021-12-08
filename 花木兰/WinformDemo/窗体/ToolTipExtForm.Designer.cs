namespace WinformDemo
{
  partial class ToolTipExtForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.上下左右 = new WinformControlLibraryExtension.ToolTipExt();
            this.无标题 = new WinformControlLibraryExtension.ToolTipExt();
            this.上标题 = new WinformControlLibraryExtension.ToolTipExt();
            this.下标题 = new WinformControlLibraryExtension.ToolTipExt();
            this.左标题 = new WinformControlLibraryExtension.ToolTipExt();
            this.右标题 = new WinformControlLibraryExtension.ToolTipExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(456, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "上";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(456, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "下";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(373, 179);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "左";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(541, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "右";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(373, 85);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "无标题";
            this.无标题.SetToolTip(this.button5, "ToolTip提示美化扩展");
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Location = new System.Drawing.Point(465, 85);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "上标题";
            this.上标题.SetToolTip(this.button6, "ToolTip提示美化扩展");
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Location = new System.Drawing.Point(558, 85);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "下标题";
            this.下标题.SetToolTip(this.button7, "ToolTip提示美化扩展");
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.Location = new System.Drawing.Point(648, 85);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "左标题";
            this.左标题.SetToolTip(this.button8, "ToolTip提示美化扩展");
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button9.Location = new System.Drawing.Point(740, 85);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "右标题";
            this.右标题.SetToolTip(this.button9, "ToolTip提示美化扩展");
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button10.Location = new System.Drawing.Point(456, 274);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 9;
            this.button10.Text = "隐藏";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // 上下左右
            // 
            this.上下左右.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.上下左右.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.上下左右.MinSize = new System.Drawing.Size(100, 50);
            this.上下左右.OwnerDraw = true;
            this.上下左右.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.上下左右.TitleShow = true;
            this.上下左右.ToolTipTitle = "标题";
            // 
            // 无标题
            // 
            this.无标题.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.无标题.ForeColor = System.Drawing.Color.White;
            this.无标题.MinSize = new System.Drawing.Size(100, 50);
            this.无标题.OwnerDraw = true;
            this.无标题.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.无标题.ToolTipTitle = "标题";
            // 
            // 上标题
            // 
            this.上标题.BackColor = System.Drawing.Color.White;
            this.上标题.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.上标题.MinSize = new System.Drawing.Size(100, 50);
            this.上标题.OwnerDraw = true;
            this.上标题.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.上标题.TitleShow = true;
            this.上标题.ToolTipTitle = "标题";
            // 
            // 下标题
            // 
            this.下标题.BackColor = System.Drawing.Color.White;
            this.下标题.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.下标题.MinSize = new System.Drawing.Size(100, 50);
            this.下标题.OwnerDraw = true;
            this.下标题.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.下标题.TitleShow = true;
            this.下标题.TitleStation = WinformControlLibraryExtension.ToolTipExt.TitleAnchor.Bottom;
            this.下标题.ToolTipTitle = "标题";
            // 
            // 左标题
            // 
            this.左标题.BackColor = System.Drawing.Color.White;
            this.左标题.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.左标题.MinSize = new System.Drawing.Size(100, 50);
            this.左标题.OwnerDraw = true;
            this.左标题.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.左标题.TitleShow = true;
            this.左标题.TitleStation = WinformControlLibraryExtension.ToolTipExt.TitleAnchor.Left;
            this.左标题.ToolTipTitle = "标题";
            // 
            // 右标题
            // 
            this.右标题.BackColor = System.Drawing.Color.White;
            this.右标题.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(168)))), ((int)(((byte)(154)))));
            this.右标题.MinSize = new System.Drawing.Size(100, 50);
            this.右标题.OwnerDraw = true;
            this.右标题.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.右标题.TitleShow = true;
            this.右标题.TitleStation = WinformControlLibraryExtension.ToolTipExt.TitleAnchor.Right;
            this.右标题.ToolTipTitle = "标题";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.上下左右;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 476);
            this.propertyGrid1.TabIndex = 10;
            // 
            // ToolTipExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(825, 477);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ToolTipExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToolTip美化扩展";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private WinformControlLibraryExtension.ToolTipExt 上下左右;
    private System.Windows.Forms.Button button5;
    private WinformControlLibraryExtension.ToolTipExt 无标题;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private WinformControlLibraryExtension.ToolTipExt 上标题;
    private WinformControlLibraryExtension.ToolTipExt 下标题;
    private WinformControlLibraryExtension.ToolTipExt 左标题;
    private WinformControlLibraryExtension.ToolTipExt 右标题;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}