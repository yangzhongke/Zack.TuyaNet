using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformDemo
{
    public partial class DatePickerExtForm : Form
    {
        public DatePickerExtForm()
        {
            InitializeComponent();
        }

        private void DatePickerExtForm_Load(object sender, EventArgs e)
        {
            this.dateExt1.DatePicker.DateValue = DateTime.Now;
            this.dateExt2.DatePicker.DateValue = DateTime.Now;
            this.dateExt3.DatePicker.DateValue = DateTime.Now;
            this.datePickerExt1.DateValue = DateTime.Now;
            this.datePickerExt2.DateValue = DateTime.Now;
        }

    }


}
