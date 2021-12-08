namespace SmartHomeUI
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowForm = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerTokenRefresh = new System.Windows.Forms.Timer(this.components);
            this.ctxMenuNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.ctxMenuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Smart Home";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // ctxMenuNotifyIcon
            // 
            this.ctxMenuNotifyIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowForm,
            this.miExit});
            this.ctxMenuNotifyIcon.Name = "ctxMenuNotifyIcon";
            this.ctxMenuNotifyIcon.Size = new System.Drawing.Size(154, 52);
            // 
            // miShowForm
            // 
            this.miShowForm.Name = "miShowForm";
            this.miShowForm.Size = new System.Drawing.Size(153, 24);
            this.miShowForm.Text = "显示主窗口";
            this.miShowForm.Click += new System.EventHandler(this.miShowForm_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(153, 24);
            this.miExit.Text = "退出";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 32000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerTokenRefresh
            // 
            this.timerTokenRefresh.Enabled = true;
            this.timerTokenRefresh.Interval = 3600000;
            this.timerTokenRefresh.Tick += new System.EventHandler(this.timerTokenRefresh_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(994, 578);
            this.Name = "FormMain";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ctxMenuNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip ctxMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem miShowForm;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerTokenRefresh;
    }
}

