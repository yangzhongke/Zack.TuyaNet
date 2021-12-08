namespace WinformDemo
{
    partial class GroupPanelExtForm
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
            this.groupPanelExt2 = new WinformControlLibraryExtension.GroupPanelExt();
            this.groupPanelExt1 = new WinformControlLibraryExtension.GroupPanelExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // groupPanelExt2
            // 
            this.groupPanelExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(205)))));
            this.groupPanelExt2.Location = new System.Drawing.Point(380, 146);
            this.groupPanelExt2.Name = "groupPanelExt2";
            this.groupPanelExt2.Size = new System.Drawing.Size(200, 100);
            this.groupPanelExt2.TabIndex = 0;
            this.groupPanelExt2.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(205)))));
            this.groupPanelExt2.TitleImage = global::WinformDemo.Properties.Resources.GroupPanelTitle;
            this.groupPanelExt2.TitleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // groupPanelExt1
            // 
            this.groupPanelExt1.Location = new System.Drawing.Point(380, 26);
            this.groupPanelExt1.Name = "groupPanelExt1";
            this.groupPanelExt1.Size = new System.Drawing.Size(200, 100);
            this.groupPanelExt1.TabIndex = 0;
            this.groupPanelExt1.TitleImage = global::WinformDemo.Properties.Resources.GroupPanelTitle;
            this.groupPanelExt1.TitleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.groupPanelExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 492);
            this.propertyGrid1.TabIndex = 8;
            // 
            // GroupPanelExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(636, 492);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.groupPanelExt2);
            this.Controls.Add(this.groupPanelExt1);
            this.Name = "GroupPanelExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupPanel美化扩展";
            this.ResumeLayout(false);

    }

    #endregion

    private WinformControlLibraryExtension.GroupPanelExt groupPanelExt1;
    private WinformControlLibraryExtension.GroupPanelExt groupPanelExt2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}