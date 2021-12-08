namespace SmartHomeUI
{
    partial class FormSwitchSettings
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
            this.labelWorkingDayBegin = new System.Windows.Forms.Label();
            this.timePickerWorkingDayBegin = new System.Windows.Forms.DateTimePicker();
            this.timePickerOffDayBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWorkingDayBegin
            // 
            this.labelWorkingDayBegin.AutoSize = true;
            this.labelWorkingDayBegin.Location = new System.Drawing.Point(12, 16);
            this.labelWorkingDayBegin.Name = "labelWorkingDayBegin";
            this.labelWorkingDayBegin.Size = new System.Drawing.Size(112, 15);
            this.labelWorkingDayBegin.TabIndex = 0;
            this.labelWorkingDayBegin.Text = "工作日打开时间";
            // 
            // timePickerWorkingDayBegin
            // 
            this.timePickerWorkingDayBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerWorkingDayBegin.Location = new System.Drawing.Point(140, 9);
            this.timePickerWorkingDayBegin.Name = "timePickerWorkingDayBegin";
            this.timePickerWorkingDayBegin.ShowUpDown = true;
            this.timePickerWorkingDayBegin.Size = new System.Drawing.Size(120, 25);
            this.timePickerWorkingDayBegin.TabIndex = 1;
            // 
            // timePickerOffDayBegin
            // 
            this.timePickerOffDayBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerOffDayBegin.Location = new System.Drawing.Point(140, 60);
            this.timePickerOffDayBegin.Name = "timePickerOffDayBegin";
            this.timePickerOffDayBegin.ShowUpDown = true;
            this.timePickerOffDayBegin.Size = new System.Drawing.Size(120, 25);
            this.timePickerOffDayBegin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "休息日打开时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "持续时间(分钟)";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(140, 114);
            this.numDuration.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(120, 25);
            this.numDuration.TabIndex = 5;
            this.numDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(68, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 31);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSwitchSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(347, 208);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timePickerOffDayBegin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timePickerWorkingDayBegin);
            this.Controls.Add(this.labelWorkingDayBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSwitchSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "电源开关设置";
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWorkingDayBegin;
        private System.Windows.Forms.DateTimePicker timePickerWorkingDayBegin;
        private System.Windows.Forms.DateTimePicker timePickerOffDayBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}