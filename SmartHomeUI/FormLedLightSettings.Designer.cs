namespace SmartHomeUI
{
    partial class FormLedLightSettings
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.timePickerSleep = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.timePickerWakeUp = new System.Windows.Forms.DateTimePicker();
            this.labe1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(227, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 31);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(91, 115);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 31);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timePickerSleep
            // 
            this.timePickerSleep.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerSleep.Location = new System.Drawing.Point(161, 74);
            this.timePickerSleep.Name = "timePickerSleep";
            this.timePickerSleep.ShowUpDown = true;
            this.timePickerSleep.Size = new System.Drawing.Size(120, 25);
            this.timePickerSleep.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "睡觉时间";
            // 
            // timePickerWakeUp
            // 
            this.timePickerWakeUp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerWakeUp.Location = new System.Drawing.Point(161, 23);
            this.timePickerWakeUp.Name = "timePickerWakeUp";
            this.timePickerWakeUp.ShowUpDown = true;
            this.timePickerWakeUp.Size = new System.Drawing.Size(120, 25);
            this.timePickerWakeUp.TabIndex = 9;
            // 
            // labe1
            // 
            this.labe1.AutoSize = true;
            this.labe1.Location = new System.Drawing.Point(33, 30);
            this.labe1.Name = "labe1";
            this.labe1.Size = new System.Drawing.Size(67, 15);
            this.labe1.TabIndex = 8;
            this.labe1.Text = "起床时间";
            // 
            // FormLedLightSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(410, 159);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.timePickerSleep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timePickerWakeUp);
            this.Controls.Add(this.labe1);
            this.Name = "FormLedLightSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Led灯设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker timePickerSleep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker timePickerWakeUp;
        private System.Windows.Forms.Label labe1;
    }
}