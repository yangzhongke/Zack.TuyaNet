
/*****版权***************************************************************

版权：  唧唧复唧唧木兰当户织
作者：  唧唧复唧唧木兰当户织
日期：  2020-10-28
描述：  禁止删除下面的木兰诗,
        博客 https://www.cnblogs.com/tlmbem/ ,
        源码地址 https://gitee.com/tlmbem/hml ,
        授权使用在 https://gitee.com/tlmbem/hml 上有介绍。
	
              	木兰诗
              	
        唧唧复唧唧，木兰当户织。
        不闻机杼声，唯闻女叹息。 
        问女何所思，问女何所忆。
        女亦无所思，女亦无所忆。
        昨夜见军帖，可汗大点兵，
        军书十二卷，卷卷有爷名。
        阿爷无大儿，木兰无长兄，
        愿为市鞍马，从此替爷征。 
        东市买骏马，西市买鞍鞯，
        南市买辔头，北市买长鞭。
        旦辞爷娘去，暮宿黄河边，
        不闻爷娘唤女声，但闻黄河流水鸣溅溅。
        旦辞黄河去，暮至黑山头，
        不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
        万里赴戎机，关山度若飞。
        朔气传金柝，寒光照铁衣。
        将军百战死，壮士十年归。 
        归来见天子，天子坐明堂。
        策勋十二转，赏赐百千强。
        可汗问所欲，木兰不用尚书郎，
        愿驰千里足，送儿还故乡。
        爷娘闻女来，出郭相扶将；
        阿姊闻妹来，当户理红妆；
        小弟闻姊来，磨刀霍霍向猪羊。
        开我东阁门，坐我西阁床，
        脱我战时袍，著我旧时裳。
        当窗理云鬓，对镜帖花黄。
        出门看火伴，火伴皆惊忙，
        同行十二年，不知木兰是女郎。 
        
*********************************************************************/

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 日期选择美化控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("日期选择美化控件")]
    [DefaultProperty("DatePicker")]
    [Designer(typeof(DateExtDesigner))]
    public class DateExt : Control
    {
        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private bool readOnly = false;
        /// <summary>
        /// 是否只读
        /// </summary>
        [DefaultValue(false)]
        [Description("是否只读")]
        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                if (this.readOnly == value)
                    return;
                this.readOnly = value;
                if (this.DateStyle == DateStyles.Editor)
                {
                    this.dateTextBox.SelectedText = "";
                }
            }
        }

        private bool borderShow = true;
        /// <summary>
        /// 是否显示边框
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示边框")]
        public bool BorderShow
        {
            get { return this.borderShow; }
            set
            {
                if (this.borderShow == value)
                    return;
                this.borderShow = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;
                this.borderColor = value;
                this.Invalidate();
            }
        }

        private DataImageAligns dataImageAlign = DataImageAligns.Right;
        /// <summary>
        /// 日期图片位置
        /// </summary>
        [DefaultValue(DataImageAligns.Right)]
        [Description("日期图片位置")]
        public DataImageAligns DataImageAlign
        {
            get { return this.dataImageAlign; }
            set
            {
                if (this.dataImageAlign == value)
                    return;
                this.dataImageAlign = value;
                this.Invalidate();
                this.UpdateLocationSize();
            }
        }

        private DataTextAligns dateTextAlign = DataTextAligns.Right;
        /// <summary>
        /// 日期文本位置
        /// </summary>
        [DefaultValue(DataTextAligns.Right)]
        [Description("日期文本位置")]
        public DataTextAligns DateTextAlign
        {
            get { return this.dateTextAlign; }
            set
            {
                if (this.dateTextAlign == value)
                    return;
                this.dateTextAlign = value;
                this.dateTextBox.TextAlign = (value == DataTextAligns.Left) ? HorizontalAlignment.Left : HorizontalAlignment.Right;
                if (this.DateStyle == DateStyles.DataPanel)
                {
                    this.Invalidate();
                }
            }
        }

        private DateStyles dateStyle = DateStyles.Editor;
        /// <summary>
        /// 日期输入框类型
        /// </summary>
        [DefaultValue(DateStyles.Editor)]
        [Description("日期输入框类型")]
        public DateStyles DateStyle
        {
            get { return this.dateStyle; }
            set
            {
                if (this.dateStyle == value)
                    return;
                this.dateStyle = value;
                this.UpdateDateStyle();
                this.Invalidate();
                this.UpdateLocationSize();
            }
        }

        private DatePickerExt datePicker = null;
        /// <summary>
        /// 日期选择面板
        /// </summary>
        [Browsable(true)]
        [Description("日期选择面板")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DatePickerExt DatePicker
        {
            get { return this.datePicker; }
            set { this.datePicker = value; }
        }

        #endregion

        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        [DefaultValue(typeof(Color), "255,255,255")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.dateTextBox.BackColor = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "105, 105, 105")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.dateTextBox.ForeColor = value;
                this.Invalidate();
            }
        }

        protected override Cursor DefaultCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(130, 24);
            }
        }

        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        protected bool activatedState = false;

        /// <summary>
        /// 日期控件文本选中类型索引（1年2月3日4时5分6秒）
        /// </summary>
        protected int selectIndex = 0;

        /// <summary>
        /// 日期面板显示状态
        /// </summary>
        private bool displayStatus = false;

        private ToolStripDropDown tsdd = null;

        private ToolStripControlHost tsch = null;

        private TextBox dateTextBox = new TextBox();

        private int image_width = 16;

        private int image_height = 16;

        private int image_padding = 2;

        private int border = 1;

        /// <summary>
        /// 鼠标是否按下
        /// </summary>
        private bool isMoveDown = false;

        /// <summary>
        /// 控件日期存放年
        /// </summary>
        private string yearstr = null;
        /// <summary>
        /// 控件日期存放月
        /// </summary>
        private string monthstr = null;
        /// <summary>
        /// 控件日期存放日
        /// </summary>
        private string daystr = null;
        /// <summary>
        /// 控件日期存放时
        /// </summary>
        private string hourstr = null;
        /// <summary>
        /// 控件日期存放分
        /// </summary>
        private string minutestr = null;
        /// <summary>
        /// 控件日期存放秒
        /// </summary>
        private string secondstr = null;

        private IFormatProvider date_ip = new CultureInfo("zh-CN", true);

        private Rectangle image_rect = Rectangle.Empty;
        private Rectangle date_rect = Rectangle.Empty;
        #endregion

        public DateExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            this.BackColor = Color.FromArgb(255, 255, 255);
            this.ForeColor = Color.FromArgb(105, 105, 105);
            this.Font = new Font("微软雅黑", 9);

            this.DatePicker = new DatePickerExt();

            this.tsdd = new ToolStripDropDown() { Padding = Padding.Empty };
            this.tsch = new ToolStripControlHost(this.DatePicker) { Margin = Padding.Empty, Padding = Padding.Empty };
            tsdd.Items.Add(this.tsch);

            this.tsdd.Closed += new ToolStripDropDownClosedEventHandler(this.tsdd_Closed);
            this.DatePicker.BottomBarConfirmClick += new DatePickerExt.BottomBarIiemClickEventHandler(this.datePicker_BottomBarConfirmClick);
            this.DatePicker.BottomBarClearClick += new DatePickerExt.BottomBarIiemClickEventHandler(this.datePicker_BottomBarClearClick);
            this.datePicker.DateValueChanged += new DatePickerExt.DateValueChangedEventHandler(this.datePicker_DateValueChanged);
            this.DatePicker.DateDisplayTypeChanged += new DatePickerExt.DateDisplayTypeChangedEventHandler(this.datePicker_DateDisplayTypeChanged);

            this.dateTextBox.ImeMode = ImeMode.Off;
            this.dateTextBox.ShortcutsEnabled = false;
            this.dateTextBox.TextAlign = HorizontalAlignment.Right;
            this.dateTextBox.TabStop = false;
            this.dateTextBox.Cursor = Cursors.Default;
            this.dateTextBox.BorderStyle = BorderStyle.None;
            this.dateTextBox.LostFocus += new EventHandler(dateTextBox_LostFocus);
            this.dateTextBox.KeyDown += new KeyEventHandler(this.dateTextBox_KeyDown);
            this.dateTextBox.MouseDown += new MouseEventHandler(this.dateTextBox_MouseDown);
            this.dateTextBox.MouseUp += new MouseEventHandler(this.dateTextBox_MouseUp);
            this.dateTextBox.MouseMove += new MouseEventHandler(this.dateTextBox_MouseMove);

            this.Controls.Add(this.dateTextBox);

            this.UpdateLocationSize();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            #region 控件激活状态虚线框
            if (this.DateStyle == DateStyles.DataPanel && this.activatedState)
            {
                Pen backborder_pen = new Pen(this.BorderColor, 1);
                backborder_pen.DashStyle = DashStyle.Dash;
                Rectangle rect = new Rectangle(this.ClientRectangle.X + 2, this.ClientRectangle.Y + 2, this.ClientRectangle.Width - 4 - this.border, this.ClientRectangle.Height - 4 - this.border);
                g.DrawRectangle(backborder_pen, rect);
                backborder_pen.Dispose();
            }
            #endregion

            #region 图片、文本
            g.DrawImage(Resources.date, image_rect);

            if (this.DateStyle == DateStyles.DataPanel)
            {
                SolidBrush date_sb = new SolidBrush(this.ForeColor);
                StringFormat date_sf = new StringFormat() { Alignment = (this.DateTextAlign == DataTextAligns.Left ? StringAlignment.Near : StringAlignment.Far), LineAlignment = StringAlignment.Center, Trimming = StringTrimming.None, FormatFlags = StringFormatFlags.NoWrap };
                g.DrawString(this.GetLocalDateFormatText(), this.Font, date_sb, new Rectangle(date_rect.X, date_rect.Y, date_rect.Width - 2, date_rect.Height), date_sf);
                date_sb.Dispose();
                date_sf.Dispose();
            }
            #endregion

            #region 边框
            if (this.BorderShow)
            {
                Pen backborder_pen = new Pen(this.BorderColor, this.border);
                g.DrawRectangle(backborder_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
                backborder_pen.Dispose();
            }
            #endregion
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = true;
            if (this.DateStyle == DateStyles.DataPanel)
            {
                this.Invalidate();
            }
            else
            {
                if (this.yearstr != null)
                    this.SelectYear();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = false;
            if (this.DateStyle == DateStyles.DataPanel)
            {
                this.Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.activatedState = false;
            if (this.displayStatus == true)
            {
                this.tsdd.Close();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.ReadOnly)
                return true;

            if (this.activatedState)
            {
                #region Left
                if (keyData == Keys.Left)
                {
                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    return false;
                }
                #endregion
                else if (keyData == Keys.Up)
                {
                    return false;
                }
                else if (keyData == Keys.Down)
                {
                    return false;
                }
                #region Enter
                else if (keyData == Keys.Enter)
                {
                    this.OnMouseClick(new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2, 0));
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.DateStyle == DateStyles.Editor)
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.image_rect.Contains(point))
                {
                    if (this.Cursor != Cursors.Hand)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor != Cursors.Default)
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Hand)
                    this.Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.DateStyle == DateStyles.Editor)
            {
                Point point = this.PointToClient(Control.MousePosition);
                if (this.image_rect.Contains(point))
                {
                    if (this.Cursor != Cursors.Hand)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor != Cursors.Default)
                        this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Hand)
                    this.Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (e.Button == MouseButtons.Left)
            {
                this.Focus();

                if (!this.displayStatus)
                {
                    this.DatePicker.InitializeDatePickerDateValue(this.GetLocalDate());
                    tsdd.Show(this.PointToScreen(new Point(0, this.Height + 2)));
                    this.DatePicker.SetActive();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.UpdateLocationSize();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, this.DefaultSize.Height, specified);
            this.Invalidate();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DatePicker != null)
                    this.DatePicker.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 私有方法

        #region 日期面板事件

        /// <summary>
        /// 日期面板清除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_BottomBarClearClick(object sender, DatePickerExt.BottomBarIiemEventArgs e)
        {
            this.SetLocalDateByDatePicker(this.DatePicker.DateValue);
            this.UpdateLocalDateUI();
            this.tsdd.Close();
        }

        /// <summary>
        /// 日期面板确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_BottomBarConfirmClick(object sender, DatePickerExt.BottomBarIiemEventArgs e)
        {
            this.Select();
            this.tsdd.Close();
        }

        /// <summary>
        /// 日期面板值更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_DateValueChanged(object sender, DatePickerExt.DateValueChangedEventArgs e)
        {
            this.SetLocalDateByDatePicker(e.NewDateValue);
            this.UpdateLocalDateUI();
        }


        /// <summary>
        /// 显示功能类型更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePicker_DateDisplayTypeChanged(object sender, DatePickerExt.DateDisplayTypeChangedEventArgs e)
        {
            this.SetLocalDateByDatePicker(this.DatePicker.DateValue);
            this.UpdateLocalDateUI();
        }

        /// <summary>
        /// 隐藏日期面板弹层事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsdd_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.displayStatus = false;
            this.DatePicker.ClearSelectDate();
            this.Invalidate();
            this.Select();
        }

        #endregion

        #region 日期输入框 事件

        private void dateTextBox_LostFocus(object sender, EventArgs e)
        {
            if (this.ReadOnly)
                return;

            this.ValidYear();
        }

        private void dateTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            WindowNavigate.HideCaret(this.dateTextBox.Handle);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.isMoveDown = true;
            Point point = this.dateTextBox.PointToClient(Control.MousePosition);
            int index = this.dateTextBox.GetCharIndexFromPosition(point);
            if (index < 5)
            {
                this.selectIndex = 1;
                this.SelectYear();
            }
            else if (index < 8)
            {
                this.selectIndex = 2;
                this.SelectMonth();
            }
            else if (index < 11)
            {
                this.selectIndex = 3;
                this.SelectDay();
            }
            else if (index < 14)
            {
                this.selectIndex = 4;
                this.SelectHour();
            }
            else if (index < 17)
            {
                this.selectIndex = 5;
                this.SelectMinute();
            }
            else
            {
                this.selectIndex = 6;
                this.SelectSecond();
            }

        }

        private void dateTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            this.isMoveDown = false;
        }

        private void dateTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            WindowNavigate.HideCaret(this.dateTextBox.Handle);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            if (this.isMoveDown)
            {
                Point point = this.dateTextBox.PointToClient(Control.MousePosition);
                int index = this.dateTextBox.GetCharIndexFromPosition(point);
                if (index < 5)
                {
                    this.selectIndex = 1;
                    this.SelectYear();
                }
                else if (index < 8)
                {
                    this.selectIndex = 2;
                    this.SelectMonth();
                }
                else if (index < 11)
                {
                    this.selectIndex = 3;
                    this.SelectDay();
                }
                else if (index < 14)
                {
                    this.selectIndex = 4;
                    this.SelectHour();
                }
                else if (index < 17)
                {
                    this.selectIndex = 5;
                    this.SelectMinute();
                }
                else
                {
                    this.selectIndex = 6;
                    this.SelectSecond();
                }
            }
        }

        private void dateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            WindowNavigate.HideCaret(this.dateTextBox.Handle);

            if (this.DesignMode)
                return;

            if (this.ReadOnly)
                return;

            switch (e.KeyCode)
            {
                #region Left
                case Keys.Left:
                    {

                        if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.Year)
                        {
                            if (this.yearstr == null)
                            {
                                goto suppress;
                            }
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonth)
                        {
                            this.ValidYear();
                            this.selectIndex--;
                            if (this.selectIndex < 1)
                            {
                                this.selectIndex = 2;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDay)
                        {
                            this.ValidYear();
                            this.selectIndex--;
                            if (this.selectIndex < 1)
                            {
                                this.selectIndex = 3;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour)
                        {
                            this.ValidYear();
                            this.selectIndex--;
                            if (this.selectIndex < 1)
                            {
                                this.selectIndex = 4;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute)
                        {
                            this.ValidYear();
                            this.selectIndex--;
                            if (this.selectIndex < 1)
                            {
                                this.selectIndex = 5;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
                        {
                            this.ValidYear();
                            this.selectIndex--;
                            if (this.selectIndex < 1)
                            {
                                this.selectIndex = 6;
                            }
                            this.UpdateSelect();
                        }
                        break;
                    }
                #endregion
                #region Right
                case Keys.Right:
                    {
                        if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.Year)
                        {
                            if (this.yearstr == null)
                            {
                                goto suppress;
                            }
                        }
                        if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonth)
                        {
                            this.ValidYear();
                            this.selectIndex++;
                            if (this.selectIndex > 2)
                            {
                                this.selectIndex = 1;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDay)
                        {
                            this.ValidYear();
                            this.selectIndex++;
                            if (this.selectIndex > 3)
                            {
                                this.selectIndex = 1;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour)
                        {
                            this.ValidYear();
                            this.selectIndex++;
                            if (this.selectIndex > 4)
                            {
                                this.selectIndex = 1;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute)
                        {
                            this.ValidYear();
                            this.selectIndex++;
                            if (this.selectIndex > 5)
                            {
                                this.selectIndex = 1;
                            }
                            this.UpdateSelect();
                        }
                        else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
                        {
                            this.ValidYear();
                            this.selectIndex++;
                            if (this.selectIndex > 6)
                            {
                                this.selectIndex = 1;
                            }
                            this.UpdateSelect();
                        }
                        break;
                    }
                #endregion
                #region Up
                case Keys.Up:
                    {
                        if (this.selectIndex == 1)
                        {
                            if (this.yearstr == null)
                                goto suppress;

                            int year = this.ConvertYear();
                            year += 1;
                            if (year > this.DatePicker.MaxValue.Year)
                                year = this.DatePicker.MaxValue.Year;
                            this.yearstr = year.ToString().PadLeft(4, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 2)
                        {
                            if (this.monthstr == null)
                                goto suppress;

                            int month = this.ConvertMonth();
                            month += 1;
                            if (month > 12)
                                month = 12;
                            this.monthstr = month.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 3)
                        {
                            if (this.yearstr == null || this.monthstr == null || this.daystr == null)
                                goto suppress;

                            int year = this.ConvertYear();
                            int month = this.ConvertMonth();
                            int days = DateTime.DaysInMonth(year, month);
                            int day = this.ConvertDay();
                            day += 1;
                            if (day > days)
                                day = days;
                            this.daystr = day.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 4)
                        {
                            if (this.hourstr == null)
                                goto suppress;

                            int hour = this.ConvertHour();
                            hour += 1;
                            if (hour > 23)
                                hour = 23;
                            this.hourstr = hour.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 5)
                        {
                            if (this.minutestr == null)
                                goto suppress;

                            int minute = this.ConvertMinute();
                            minute += 1;
                            if (minute > 59)
                                minute = 59;
                            this.minutestr = minute.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 6)
                        {
                            if (this.secondstr == null)
                                goto suppress;

                            int second = this.ConvertSecond();
                            second += 1;
                            if (second > 59)
                                second = 59;
                            this.secondstr = second.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        break;
                    }
                #endregion
                #region Down
                case Keys.Down:
                    {
                        if (this.selectIndex == 1)
                        {
                            if (this.yearstr == null)
                                goto suppress;

                            int year = this.ConvertYear();
                            year -= 1;
                            if (year < this.DatePicker.MinValue.Year)
                                year = this.DatePicker.MinValue.Year;
                            this.yearstr = year.ToString().PadLeft(4, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 2)
                        {
                            if (this.monthstr == null)
                                goto suppress;

                            int month = this.ConvertMonth();
                            month -= 1;
                            if (month < 1)
                                month = 1;
                            this.monthstr = month.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 3)
                        {
                            if (this.yearstr == null || this.monthstr == null || this.daystr == null)
                                goto suppress;

                            int year = this.ConvertYear();
                            int month = this.ConvertMonth();
                            int days = DateTime.DaysInMonth(year, month);
                            int day = this.ConvertDay();
                            day -= 1;
                            if (day < 1)
                                day = 1;
                            this.daystr = day.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 4)
                        {
                            if (this.hourstr == null)
                                goto suppress;

                            int hour = this.ConvertHour();
                            hour -= 1;
                            if (hour < 0)
                                hour = 0;
                            this.hourstr = hour.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 5)
                        {
                            if (this.minutestr == null)
                                goto suppress;

                            int minute = this.ConvertMinute();
                            minute -= 1;
                            if (minute < 0)
                                minute = 0;
                            this.minutestr = minute.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        else if (this.selectIndex == 6)
                        {
                            if (this.secondstr == null)
                                goto suppress;

                            int second = this.ConvertSecond();
                            second -= 1;
                            if (second < 0)
                                second = 0;
                            this.secondstr = second.ToString().PadLeft(2, '0');
                            this.UpdateLocalDateUI();
                            this.UpdateSelect();
                        }
                        break;
                    }
                #endregion
                #region Number
                case Keys.D0:
                case Keys.NumPad0:
                    {
                        this.UpdateLoaclDateByKey(0);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D1:
                case Keys.NumPad1:
                    {
                        this.UpdateLoaclDateByKey(1);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D2:
                case Keys.NumPad2:
                    {
                        this.UpdateLoaclDateByKey(2);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D3:
                case Keys.NumPad3:
                    {
                        this.UpdateLoaclDateByKey(3);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D4:
                case Keys.NumPad4:
                    {
                        this.UpdateLoaclDateByKey(4);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D5:
                case Keys.NumPad5:
                    {
                        this.UpdateLoaclDateByKey(5);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D6:
                case Keys.NumPad6:
                    {
                        this.UpdateLoaclDateByKey(6);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D7:
                case Keys.NumPad7:
                    {
                        this.UpdateLoaclDateByKey(7);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D8:
                case Keys.NumPad8:
                    {
                        this.UpdateLoaclDateByKey(8);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                case Keys.D9:
                case Keys.NumPad9:
                    {
                        this.UpdateLoaclDateByKey(9);
                        this.UpdateLocalDateUI();
                        this.UpdateSelect();
                        break;
                    }
                    #endregion
            }

        suppress:
            e.SuppressKeyPress = true;
        }

        #endregion

        /// <summary>
        /// 更新日期输入框Location、Size
        /// </summary>
        private void UpdateLocationSize()
        {
            this.dateTextBox.Height = this.DefaultSize.Height - 6;
            this.dateTextBox.Width = this.Width - this.image_width - this.image_padding * 2 - this.border * 2;
            this.dateTextBox.Location = this.DataImageAlign == DataImageAligns.Left ? new Point(this.image_width + this.image_padding * 2 + this.border, 4) : new Point(this.border, 4);

            if (this.DataImageAlign == DataImageAligns.Right)
            {
                this.image_rect = new Rectangle(this.ClientRectangle.Right - this.image_width - this.image_padding * 2, this.ClientRectangle.Y + (this.ClientRectangle.Height - this.image_height) / 2, this.image_width, this.image_height);
                this.date_rect = new Rectangle(this.ClientRectangle.X + this.border, this.ClientRectangle.Y, this.ClientRectangle.Width - this.image_width - this.image_padding * 2 - this.border * 2, this.ClientRectangle.Height);

            }
            else
            {
                this.image_rect = new Rectangle(this.ClientRectangle.X + this.image_padding + this.border, this.ClientRectangle.Y + (this.ClientRectangle.Height - this.image_height) / 2, this.image_width, this.image_height);
                this.date_rect = new Rectangle(this.ClientRectangle.X + this.image_width + this.image_padding * 2 + this.border * 2, this.ClientRectangle.Y, this.ClientRectangle.Width - this.image_width - this.image_padding * 2 - this.border * 2, this.ClientRectangle.Height);
            }
        }

        /// <summary>
        /// 设置控件日期根据面板日期
        /// </summary>
        /// <param name="date"></param>
        private void SetLocalDateByDatePicker(DateTime? date)
        {
            if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.Year)
            {
                if (date.HasValue)
                {
                    this.yearstr = date.Value.Year.ToString().PadLeft(2, '4');
                }
                else
                {
                    this.yearstr = null;
                }
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonth)
            {

                if (date.HasValue)
                {
                    this.yearstr = date.Value.Year.ToString().PadLeft(4, '0');
                    this.monthstr = date.Value.Month.ToString().PadLeft(2, '0');
                }
                else
                {
                    this.yearstr = null;
                    this.monthstr = null;
                }
            }
            else if (this.DatePicker.YearMonthDayOrTime)
            {
                if (date.HasValue)
                {
                    this.yearstr = date.Value.Year.ToString().PadLeft(4, '0');
                    this.monthstr = date.Value.Month.ToString().PadLeft(2, '0');
                    this.daystr = date.Value.Day.ToString().PadLeft(2, '0');
                    if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour || this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute || this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
                    {
                        this.hourstr = date.Value.Hour.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.hourstr = null;
                    }
                    if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute || this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
                    {
                        this.minutestr = date.Value.Minute.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.minutestr = null;
                    }
                    if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
                    {
                        this.secondstr = date.Value.Second.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.secondstr = null;
                    }
                }
                else
                {
                    this.yearstr = null;
                    this.monthstr = null;
                    this.daystr = null;
                    this.hourstr = null;
                    this.minutestr = null;
                    this.secondstr = null;
                }
            }
        }

        /// <summary>
        /// 更新日期控件日期UI
        /// </summary>
        private void UpdateLocalDateUI()
        {
            if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.Year)
            {
                if (this.yearstr == null)
                    this.dateTextBox.Text = "";
                else
                    this.dateTextBox.Text = this.yearstr;
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonth)
            {
                if (this.yearstr == null && this.monthstr == null)
                    this.dateTextBox.Text = "";
                else
                    this.dateTextBox.Text = String.Format("{0}-{1}", this.yearstr, this.monthstr);
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDay)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null)
                    this.dateTextBox.Text = "";
                else
                    this.dateTextBox.Text = String.Format("{0}-{1}-{2}", this.yearstr, this.monthstr, this.daystr);
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null && this.hourstr == null)
                    this.dateTextBox.Text = "";
                else
                    this.dateTextBox.Text = String.Format("{0}-{1}-{2} {3}", this.yearstr, this.monthstr, this.daystr, this.hourstr);
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null && this.hourstr == null && this.minutestr == null)
                    this.dateTextBox.Text = "";
                else
                    this.dateTextBox.Text = String.Format("{0}-{1}-{2} {3}:{4}", this.yearstr, this.monthstr, this.daystr, this.hourstr, this.minutestr);
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null && this.hourstr == null && this.minutestr == null && this.secondstr == null)
                    this.dateTextBox.Text = "";
                else
                    this.dateTextBox.Text = String.Format("{0}-{1}-{2} {3}:{4}:{5}", this.yearstr, this.monthstr, this.daystr, this.hourstr, this.minutestr, this.secondstr);
            }
        }

        /// <summary>
        /// 获取控件日期完整文本
        /// </summary>
        /// <returns></returns>
        private string GetLocalDateFormatText()
        {
            string datestr = "";
            if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.Year)
            {
                if (this.yearstr == null)
                    datestr = "";
                else
                    datestr = this.yearstr.PadLeft(4, '0');
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonth)
            {
                if (this.yearstr == null && this.monthstr == null)
                    datestr = "";
                else
                    datestr = String.Format("{0}-{1}", this.yearstr.PadLeft(4, '0'), this.monthstr.PadLeft(2, '0'));
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDay)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null)
                    datestr = "";
                else
                    datestr = String.Format("{0}-{1}-{2}", this.yearstr.PadLeft(4, '0'), this.monthstr.PadLeft(2, '0'), this.daystr.PadLeft(2, '0'));
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null && this.hourstr == null)
                    datestr = "";
                else
                    datestr = String.Format("{0}-{1}-{2} {3}", this.yearstr.PadLeft(4, '0'), this.monthstr.PadLeft(2, '0'), this.daystr.PadLeft(2, '0'), this.hourstr.PadLeft(2, '0'));
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null && this.hourstr == null && this.minutestr == null)
                    datestr = "";
                else
                    datestr = String.Format("{0}-{1}-{2} {3}:{4}", this.yearstr.PadLeft(4, '0'), this.monthstr.PadLeft(2, '0'), this.daystr.PadLeft(2, '0'), this.hourstr.PadLeft(2, '0'), this.minutestr.PadLeft(2, '0'));
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                if (this.yearstr == null && this.monthstr == null && this.daystr == null && this.hourstr == null && this.minutestr == null && this.secondstr == null)
                    datestr = "";
                else
                    datestr = String.Format("{0}-{1}-{2} {3}:{4}:{5}", this.yearstr.PadLeft(4, '0'), this.monthstr.PadLeft(2, '0'), this.daystr.PadLeft(2, '0'), this.hourstr.PadLeft(2, '0'), this.minutestr.PadLeft(2, '0'), this.secondstr.PadLeft(2, '0'));
            }
            return datestr;
        }

        /// <summary>
        /// 获取控件日期
        /// </summary>
        /// <returns></returns>
        private DateTime? GetLocalDate()
        {
            DateTime? result = null;
            if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.Year)
            {
                if (this.yearstr == null)
                {
                    result = null;
                }
                else
                {
                    DateTime date = DateTime.MinValue;
                    result = DateTime.ParseExact(String.Format("{0}", this.yearstr), this.DatePicker.GetDateFormat(), date_ip, DateTimeStyles.AllowWhiteSpaces);
                }
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonth)
            {
                if (this.yearstr == null || this.monthstr == null)
                {
                    result = null;
                }
                else
                {
                    DateTime date = DateTime.MinValue;
                    result = DateTime.ParseExact(String.Format("{0}-{1}", this.yearstr, this.monthstr), this.DatePicker.GetDateFormat(), date_ip, DateTimeStyles.AllowWhiteSpaces);
                }
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDay)
            {
                if (this.yearstr == null || this.monthstr == null || this.daystr == null)
                {
                    result = null;
                }
                else
                {
                    DateTime date = DateTime.MinValue;
                    result = DateTime.ParseExact(String.Format("{0}-{1}-{2}", this.yearstr, this.monthstr, this.daystr), this.DatePicker.GetDateFormat(), date_ip, DateTimeStyles.AllowWhiteSpaces);
                }
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour)
            {
                if (this.yearstr == null || this.monthstr == null || this.daystr == null || this.hourstr == null)
                {
                    result = null;
                }
                else
                {
                    DateTime date = DateTime.MinValue;
                    result = DateTime.ParseExact(String.Format("{0}-{1}-{2} {3}:00:00", this.yearstr, this.monthstr, this.daystr, this.hourstr), this.DatePicker.GetDateFormat(), date_ip, DateTimeStyles.AllowWhiteSpaces);
                }
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute)
            {
                if (this.yearstr == null || this.monthstr == null || this.daystr == null || this.hourstr == null || this.minutestr == null)
                {
                    result = null;
                }
                else
                {
                    DateTime date = DateTime.MinValue;
                    result = DateTime.ParseExact(String.Format("{0}-{1}-{2} {3}:{4}:00", this.yearstr, this.monthstr, this.daystr, this.hourstr, this.minutestr), this.DatePicker.GetDateFormat(), date_ip, DateTimeStyles.AllowWhiteSpaces);
                }
            }
            else if (this.DatePicker.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                if (this.yearstr == null || this.monthstr == null || this.daystr == null || this.hourstr == null || this.minutestr == null || this.secondstr == null)
                {
                    result = null;
                }
                else
                {
                    DateTime date = DateTime.MinValue;
                    result = DateTime.ParseExact(String.Format("{0}-{1}-{2} {3}:{4}:{5}", this.yearstr, this.monthstr, this.daystr, this.hourstr, this.minutestr, this.secondstr), this.DatePicker.GetDateFormat(), date_ip, DateTimeStyles.AllowWhiteSpaces);
                }
            }
            return result;
        }

        /// <summary>
        /// 更新日期输入框功能类型
        /// </summary>
        private void UpdateDateStyle()
        {
            if (this.DateStyle == DateStyles.Editor)
            {
                this.dateTextBox.Enabled = true;
                this.dateTextBox.Visible = true;
            }
            else
            {
                this.dateTextBox.Enabled = false;
                this.dateTextBox.Visible = false;
            }

        }

        /// <summary>
        /// 键盘修改控件日期值
        /// </summary>
        /// <param name="number"></param>
        private void UpdateLoaclDateByKey(int number)
        {
            if (this.selectIndex == 1)
            {
                string year_tmp = this.RemoveChar(this.yearstr);
                if (number != 0 && year_tmp.Length < 4)
                {
                    this.yearstr = year_tmp + number.ToString();
                    if (int.Parse(this.yearstr) > this.DatePicker.MaxValue.Year)
                    {
                        this.yearstr = this.DatePicker.MaxValue.Year.ToString();
                    }
                    else
                    {
                        this.yearstr = this.yearstr.PadLeft(2, '0');
                    }
                }
                else
                {
                    if (number != 0)
                    {
                        this.yearstr = number.ToString().PadLeft(4, '0');
                    }
                }
            }
            else if (this.selectIndex == 2)
            {
                string month_tmp = this.RemoveChar(this.monthstr);
                if (number != 0 && month_tmp.Length < 2)
                {
                    this.monthstr = month_tmp + number.ToString();
                    if (int.Parse(this.monthstr) > 12)
                    {
                        this.monthstr = number.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.monthstr = this.monthstr.PadLeft(2, '0');
                    }
                }
                else
                {
                    if (number != 0)
                    {
                        this.monthstr = number.ToString().PadLeft(2, '0');
                    }
                }
            }
            else if (this.selectIndex == 3)
            {
                if (number != 0 && this.daystr.Length < 2)
                {
                    string day_tmp = this.RemoveChar(this.daystr);
                    int days = DateTime.DaysInMonth(int.Parse(this.yearstr), int.Parse(this.monthstr));
                    this.daystr = day_tmp + number.ToString();
                    if (int.Parse(this.daystr) > days)
                    {
                        this.daystr = number.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.daystr = this.daystr.PadLeft(2, '0');
                    }
                }
                else
                {
                    if (number != 0)
                    {
                        this.daystr = number.ToString().PadLeft(2, '0');
                    }
                }
            }
            else if (this.selectIndex == 4)
            {
                string hour_tmp = this.RemoveChar(this.hourstr);
                if (number != 0 && hour_tmp.Length < 2)
                {
                    this.hourstr = hour_tmp + number.ToString();
                    if (int.Parse(this.hourstr) > 23)
                    {
                        this.hourstr = number.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.hourstr = this.hourstr.PadLeft(2, '0');
                    }
                }
                else
                {
                    if (number != 0)
                    {
                        this.hourstr = number.ToString().PadLeft(2, '0');
                    }
                }
            }
            else if (this.selectIndex == 5)
            {
                string minute_tmp = this.RemoveChar(this.minutestr);
                if (number != 0 && minute_tmp.Length < 2)
                {
                    this.minutestr = minute_tmp + number.ToString();
                    if (int.Parse(this.minutestr) > 59)
                    {
                        this.minutestr = number.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.minutestr = this.minutestr.PadLeft(2, '0');
                    }
                }
                else
                {
                    if (number != 0)
                    {
                        this.minutestr = number.ToString().PadLeft(2, '0');
                    }
                }
            }
            else if (this.selectIndex == 6)
            {
                string second_tmp = this.RemoveChar(this.secondstr);
                if (number != 0 && second_tmp.Length < 2)
                {
                    this.secondstr = second_tmp + number.ToString();
                    if (int.Parse(this.secondstr) > 59)
                    {
                        this.secondstr = number.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.secondstr = this.secondstr.PadLeft(2, '0');
                    }
                }
                else
                {
                    if (number != 0)
                    {
                        this.secondstr = number.ToString().PadLeft(2, '0');
                    }
                }
            }
        }

        /// <summary>
        /// 验证年分有效性
        /// </summary>
        private void ValidYear()
        {
            if (this.yearstr == null)
                return;

            if (int.Parse(this.yearstr) > this.DatePicker.MaxValue.Year)
            {
                this.yearstr = this.DatePicker.MaxValue.Year.ToString();
                this.DatePicker.UpdateDateValueNotInvalidate(this.GetLocalDate());
            }
            else if (int.Parse(this.yearstr) < this.DatePicker.MinValue.Year)
            {
                this.yearstr = this.DatePicker.MinValue.Year.ToString();
                this.DatePicker.UpdateDateValueNotInvalidate(this.GetLocalDate());
            }
        }

        /// <summary>
        /// 转换成数字年
        /// </summary>
        /// <returns></returns>
        private int ConvertYear()
        {
            return int.Parse(this.yearstr);
        }

        /// <summary>
        /// 转换成数字月
        /// </summary>
        /// <returns></returns>
        private int ConvertMonth()
        {
            return int.Parse(this.monthstr);
        }

        /// <summary>
        /// 转换成数字日
        /// </summary>
        /// <returns></returns>
        private int ConvertDay()
        {
            return int.Parse(this.daystr);
        }

        /// <summary>
        /// 转换成数字时
        /// </summary>
        /// <returns></returns>
        private int ConvertHour()
        {
            return int.Parse(this.hourstr);
        }

        /// <summary>
        /// 转换成数字分
        /// </summary>
        /// <returns></returns>
        private int ConvertMinute()
        {
            return int.Parse(this.minutestr);
        }

        /// <summary>
        /// 转换成数字秒
        /// </summary>
        /// <returns></returns>
        private int ConvertSecond()
        {
            return int.Parse(this.secondstr);
        }

        /// <summary>
        /// 更新选中索引高亮状态
        /// </summary>
        private void UpdateSelect()
        {
            if (this.selectIndex == 1)
            {
                this.SelectYear();
            }
            else if (this.selectIndex == 2)
            {
                this.SelectMonth();
            }
            else if (this.selectIndex == 3)
            {
                this.SelectDay();
            }
            else if (this.selectIndex == 4)
            {
                this.SelectHour();
            }
            else if (this.selectIndex == 5)
            {
                this.SelectMinute();
            }
            else if (this.selectIndex == 6)
            {
                this.SelectSecond();
            }
        }

        /// <summary>
        /// 选中年
        /// </summary>
        private void SelectYear()
        {
            this.dateTextBox.Select();
            this.dateTextBox.SelectionStart = 0;
            this.dateTextBox.Select(0, 4);
        }

        /// <summary>
        /// 选中月
        /// </summary>
        private void SelectMonth()
        {
            this.dateTextBox.Select();
            this.dateTextBox.SelectionStart = 5;
            this.dateTextBox.Select(5, 2);
        }

        /// <summary>
        /// 选中日
        /// </summary>
        private void SelectDay()
        {
            this.dateTextBox.Select();
            this.dateTextBox.SelectionStart = 8;
            this.dateTextBox.Select(8, 2);
        }

        /// <summary>
        /// 选中时
        /// </summary>
        private void SelectHour()
        {
            this.dateTextBox.Select();
            this.dateTextBox.SelectionStart = 11;
            this.dateTextBox.Select(11, 2);
        }

        /// <summary>
        /// 选中分
        /// </summary>
        private void SelectMinute()
        {
            this.dateTextBox.Select();
            this.dateTextBox.SelectionStart = 14;
            this.dateTextBox.Select(14, 2);
        }

        /// <summary>
        /// 选中秒
        /// </summary>
        private void SelectSecond()
        {
            this.dateTextBox.Select();
            this.dateTextBox.SelectionStart = 17;
            this.dateTextBox.Select(17, 2);
        }

        /// <summary>
        /// 移除字符串左边的0字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string RemoveChar(string str)
        {
            int index = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    index += 1;
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (index == -1)
            {
                return str;
            }
            else
            {
                return str.Substring(index + 1);
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 日期图片位置
        /// </summary>
        [Description("日期图片位置")]
        public enum DataImageAligns
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 日期文本位置
        /// </summary>
        [Description("日期文本位置")]
        public enum DataTextAligns
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 日期输入框类型
        /// </summary>
        [Description("日期输入框类型")]
        public enum DateStyles
        {
            /// <summary>
            /// 可编辑
            /// </summary>
            Editor,
            /// <summary>
            /// 只能日期面板选择
            /// </summary>
            DataPanel
        }

        #endregion
    }

    /// <summary>
    /// 日期面板美化控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("日期面板美化控件")]
    [DefaultProperty("DateValue")]
    [DefaultEvent("BottomBarConfirmClick")]
    [Designer(typeof(DatePickerExtDesigner))]
    [TypeConverter(typeof(EmptyConverter))]
    public class DatePickerExt : Control
    {
        #region 新增事件
        #region 顶部工具栏

        public delegate void TopBarIiemClickEventHandler(object sender, TopBarIiemEventArgs e);

        private event TopBarIiemClickEventHandler topBarPrevYearClick;
        /// <summary>
        /// 顶部工具栏上一年单击事件
        /// </summary>
        [Description("顶部工具栏上一年单击事件")]
        public event TopBarIiemClickEventHandler TopBarPrevYearClick
        {
            add { this.topBarPrevYearClick += value; }
            remove { this.topBarPrevYearClick -= value; }
        }

        private event TopBarIiemClickEventHandler topBarPrevMonthClick;
        /// <summary>
        /// 顶部工具栏上一月单击事件
        /// </summary>
        [Description("顶部工具栏上一月单击事件")]
        public event TopBarIiemClickEventHandler TopBarPrevMonthClick
        {
            add { this.topBarPrevMonthClick += value; }
            remove { this.topBarPrevMonthClick -= value; }
        }

        private event TopBarIiemClickEventHandler topBarMonthClick;
        /// <summary>
        /// 顶部工具栏月单击事件
        /// </summary>
        [Description("顶部工具栏月单击事件")]
        public event TopBarIiemClickEventHandler TopBarMonthClick
        {
            add { this.topBarMonthClick += value; }
            remove { this.topBarMonthClick -= value; }
        }

        private event TopBarIiemClickEventHandler topBarYearClick;
        /// <summary>
        /// 顶部工具栏年单击事件
        /// </summary>
        [Description("顶部工具栏年单击事件")]
        public event TopBarIiemClickEventHandler TopBarYearClick
        {
            add { this.topBarYearClick += value; }
            remove { this.topBarYearClick -= value; }
        }

        private event TopBarIiemClickEventHandler topBarNextMonthClick;
        /// <summary>
        /// 顶部工具栏下一月单击事件
        /// </summary>
        [Description("顶部工具栏下一月单击事件")]
        public event TopBarIiemClickEventHandler TopBarNextMonthClick
        {
            add { this.topBarNextMonthClick += value; }
            remove { this.topBarNextMonthClick -= value; }
        }

        private event TopBarIiemClickEventHandler topBarNextYearClick;
        /// <summary>
        /// 顶部工具栏下一年单击事件
        /// </summary>
        [Description("顶部工具栏下一年单击事件")]
        public event TopBarIiemClickEventHandler TopBarNextYearClick
        {
            add { this.topBarNextYearClick += value; }
            remove { this.topBarNextYearClick -= value; }
        }

        #endregion
        #region 日期面板

        public delegate void YearMainItemClickEventHandler(object sender, YearMainItemEventArgs e);

        private event YearMainItemClickEventHandler yearMainItemClick;
        /// <summary>
        /// 年面板年选项单击事件
        /// </summary>
        [Description("年面板年选项单击事件")]
        public event YearMainItemClickEventHandler YearMainItemClick
        {
            add { this.yearMainItemClick += value; }
            remove { this.yearMainItemClick -= value; }
        }

        public delegate void MonthMainItemClickEventHandler(object sender, MonthMainItemEventArgs e);

        private event MonthMainItemClickEventHandler monthMainItemClick;
        /// <summary>
        /// 月面板月选项单击事件
        /// </summary>
        [Description("月面板月选项单击事件")]
        public event MonthMainItemClickEventHandler MonthMainItemClick
        {
            add { this.monthMainItemClick += value; }
            remove { this.monthMainItemClick -= value; }
        }

        public delegate void DayMainItemClickEventHandler(object sender, DayMainItemEventArgs e);

        private event DayMainItemClickEventHandler dayMainItemClick;
        /// <summary>
        /// 日面板日选项单击事件
        /// </summary>
        [Description("日面板日选项单击事件")]
        public event DayMainItemClickEventHandler DayMainItemClick
        {
            add { this.dayMainItemClick += value; }
            remove { this.dayMainItemClick -= value; }
        }

        public delegate void TimeMainHourClickEventHandler(object sender, TimeMainHourEventArgs e);

        private event TimeMainHourClickEventHandler timeMainHourClick;
        /// <summary>
        /// 时间面板时选项单击事件
        /// </summary>
        [Description("时间面板时选项单击事件")]
        public event TimeMainHourClickEventHandler TimeMainHourClick
        {
            add { this.timeMainHourClick += value; }
            remove { this.timeMainHourClick -= value; }
        }

        public delegate void TimeMainMinuteClickEventHandler(object sender, TimeMainMinuteEventArgs e);

        private event TimeMainMinuteClickEventHandler timeMainMinuteClick;
        /// <summary>
        /// 时间面板分选项单击事件
        /// </summary>
        [Description("时间面板分选项单击事件")]
        public event TimeMainMinuteClickEventHandler TimeMainMinuteClick
        {
            add { this.timeMainMinuteClick += value; }
            remove { this.timeMainMinuteClick -= value; }
        }

        public delegate void TimeMainSecondClickEventHandler(object sender, TimeMainSecondEventArgs e);

        private event TimeMainSecondClickEventHandler timeMainSecondClick;
        /// <summary>
        /// 时间面板秒选项单击事件
        /// </summary>
        [Description("时间面板秒选项单击事件")]
        public event TimeMainSecondClickEventHandler TimeMainSecondClick
        {
            add { this.timeMainSecondClick += value; }
            remove { this.timeMainSecondClick -= value; }
        }
        #endregion
        #region 底部工具栏

        public delegate void BottomBarIiemClickEventHandler(object sender, BottomBarIiemEventArgs e);

        private event BottomBarIiemClickEventHandler bottomBarTimeClick;
        /// <summary>
        /// 底部工具栏时间单击事件
        /// </summary>
        [Description("底部工具栏时间单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarTimeClick
        {
            add { this.bottomBarTimeClick += value; }
            remove { this.bottomBarTimeClick -= value; }
        }

        private event BottomBarIiemClickEventHandler bottomBarClearClick;
        /// <summary>
        /// 底部工具栏清除单击事件
        /// </summary>
        [Description("底部工具栏清除单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarClearClick
        {
            add { this.bottomBarClearClick += value; }
            remove { this.bottomBarClearClick -= value; }
        }

        private event BottomBarIiemClickEventHandler bottomBarNowClick;
        /// <summary>
        /// 底部工具栏现在单击事件
        /// </summary>
        [Description("底部工具栏现在单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarNowClick
        {
            add { this.bottomBarNowClick += value; }
            remove { this.bottomBarNowClick -= value; }
        }


        private event BottomBarIiemClickEventHandler bottomBarConfirmClick;
        /// <summary>
        /// 底部工具栏确认单击事件
        /// </summary>
        [Description("底部工具栏确认单击事件")]
        public event BottomBarIiemClickEventHandler BottomBarConfirmClick
        {
            add { this.bottomBarConfirmClick += value; }
            remove { this.bottomBarConfirmClick -= value; }
        }

        #endregion

        public delegate void DateValueChangedEventHandler(object sender, DateValueChangedEventArgs e);

        private event DateValueChangedEventHandler dateValueChanged;
        /// <summary>
        /// 日期值更改事件
        /// </summary>
        [Description("日期值更改事件")]
        public event DateValueChangedEventHandler DateValueChanged
        {
            add { this.dateValueChanged += value; }
            remove { this.dateValueChanged -= value; }
        }

        public delegate void DateDisplayTypeChangedEventHandler(object sender, DateDisplayTypeChangedEventArgs e);

        private event DateDisplayTypeChangedEventHandler dateDisplayTypeChanged;
        /// <summary>
        /// 显示功能类型更改事件
        /// </summary>
        [Description("显示功能类型更改事件")]
        public event DateDisplayTypeChangedEventHandler DateDisplayTypeChanged
        {
            add { this.dateDisplayTypeChanged += value; }
            remove { this.dateDisplayTypeChanged -= value; }
        }

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageChanged
        {
            add { base.BackgroundImageChanged += value; }
            remove { base.BackgroundImageChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageLayoutChanged
        {
            add { base.BackgroundImageLayoutChanged += value; }
            remove { base.BackgroundImageLayoutChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add { base.FontChanged += value; }
            remove { base.FontChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add { base.ForeColorChanged += value; }
            remove { base.ForeColorChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private DateDisplayTypes dateDisplayType = DateDisplayTypes.YearMonthDay;
        /// <summary>
        /// 显示功能类型
        /// </summary>
        [DefaultValue(DateDisplayTypes.YearMonthDay)]
        [Description("显示功能类型")]
        public DateDisplayTypes DateDisplayType
        {
            get { return this.dateDisplayType; }
            set
            {
                if (this.dateDisplayType == value)
                    return;

                DateDisplayTypeChangedEventArgs arg = new DateDisplayTypeChangedEventArgs() { OldDateDisplayType = this.dateDisplayType, NewDateDisplayType = value };

                this.dateDisplayType = value;
                this.DateDisplayStatus = DateDisplayStatuss.Default;

                this.LoadDateForControl(this.DateValue);

                this.InitializeTimeRectangle();

                this.UpdateRectangleText();
                this.Invalidate();

                this.OnDateDisplayTypeChanged(arg);
            }
        }

        private Color activateColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 控件激活的虚线框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("控件激活的虚线框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ActivateColor
        {
            get { return this.activateColor; }
            set
            {
                if (this.activateColor == value)
                    return;
                this.activateColor = value;
                this.Invalidate();
            }
        }

        private DateDisplayStatuss dateDisplayStatus = DateDisplayStatuss.Default;
        /// <summary>
        /// 在指定显示功能类型下面板显示状态
        /// </summary>
        [Browsable(false)]
        [DefaultValue(DateDisplayStatuss.Default)]
        [Description("在指定显示功能类型下面板显示状态")]
        public DateDisplayStatuss DateDisplayStatus
        {
            get { return this.dateDisplayStatus; }
            set
            {
                if (this.dateDisplayStatus == value)
                    return;
                this.dateDisplayStatus = value;
            }
        }

        private bool dateReadOnly = false;
        /// <summary>
        /// 日期面板是否只读
        /// </summary>
        [DefaultValue(false)]
        [Description("日期面板是否只读")]
        public bool DateReadOnly
        {
            get { return this.dateReadOnly; }
            set
            {
                if (this.dateReadOnly == value)
                    return;
                this.dateReadOnly = value;
                this.UpdateRectangleText();
                this.Invalidate();
            }
        }

        private bool autoConfirm = false;
        /// <summary>
        /// 是否开启自动确认
        /// </summary>
        [DefaultValue(false)]
        [Description("是否开启自动确认")]
        public bool AutoConfirm
        {
            get { return this.autoConfirm; }
            set
            {
                if (this.autoConfirm == value)
                    return;
                this.autoConfirm = value;
            }
        }

        private bool minMaxInput = false;
        /// <summary>
        /// 最小值最大值是否限制输入值(否则只限制选择面板)
        /// </summary>
        [DefaultValue(false)]
        [Description("最小值最大值是否限制输入值(否则只限制选择面板)")]
        public bool MinMaxInput
        {
            get { return this.minMaxInput; }
            set
            {
                if (this.minMaxInput == value)
                    return;
                this.minMaxInput = value;
                this.UpdateRectangleText();
                this.Invalidate();
            }
        }

        private bool minMaxTip = true;
        /// <summary>
        /// 是否显示最小值最大值限制提示信息
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示最小值最大值限制提示信息")]
        public bool MinMaxTip
        {
            get { return this.minMaxTip; }
            set
            {
                if (this.minMaxTip == value)
                    return;
                this.minMaxTip = value;
                this.UpdateBottomRectangleText();
                this.Invalidate();
            }
        }

        private DateTime minValue = minDate;
        /// <summary>
        /// 最小日期
        /// </summary>
        [DefaultValue(typeof(DateTime), "1753,1,1")]
        [Description("最小日期")]
        public DateTime MinValue
        {
            get { return this.minValue; }
            set
            {
                if (this.minValue.Date == value.Date)
                    return;
                if (value.Date < minDate)
                    value = minDate;
                if (value.Date > this.MaxValue)
                    value = this.MaxValue;
                this.minValue = value.Date;
                this.UpdateBottomRectangleText();
                this.Invalidate();
            }
        }

        private DateTime maxValue = maxDate;
        /// <summary>
        /// 最大日期
        /// </summary>
        [DefaultValue(typeof(DateTime), "9998,12,31")]
        [Description("最大日期")]
        public DateTime MaxValue
        {
            get { return this.maxValue; }
            set
            {
                if (this.maxValue.Date == value.Date)
                    return;
                if (value.Date > maxDate)
                    value = maxDate;
                if (value.Date < this.MinValue)
                    value = this.MinValue;
                this.maxValue = value.Date;
                this.UpdateBottomRectangleText();
                this.Invalidate();
            }
        }

        private DateTime? dateValue = null;
        /// <summary>
        /// 日期
        /// </summary>
        [DefaultValue(null)]
        [Description("日期")]
        public DateTime? DateValue
        {
            get
            {
                if (this.dateValue.HasValue)
                {
                    if (this.DateDisplayType == DateDisplayTypes.Year || this.DateDisplayType == DateDisplayTypes.YearMonth || this.DateDisplayType == DateDisplayTypes.YearMonthDay)
                        return this.dateValue.Value.Date;
                    else
                        return this.dateValue.Value;
                }
                else
                    return null;
            }
            set
            {
                if (this.dateValue == value)
                    return;

                if (value.HasValue && this.MinMaxInput)
                {

                    if (this.DateDisplayType == DateDisplayTypes.Year)
                    {
                        if (value.Value.Date.Year < this.MinValue.Year)
                            value = new DateTime(this.MinValue.Year, 0, 0);
                        if (value.Value.Date.Year > this.MaxValue.Year)
                            value = new DateTime(this.MaxValue.Year, 0, 0);
                    }
                    else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
                    {
                        if (value.Value.Date.Year < this.MinValue.Year || (value.Value.Date.Year >= this.MinValue.Year && value.Value.Date.Month < this.MinValue.Month))
                            value = new DateTime(this.MinValue.Year, this.MinValue.Month, 0);
                        if (value.Value.Date.Year > this.MaxValue.Year || (value.Value.Date.Year <= this.MaxValue.Year && value.Value.Date.Month > this.MaxValue.Month))
                            value = new DateTime(this.MaxValue.Year, this.MaxValue.Month, 0);
                    }
                    else if (this.YearMonthDayOrTime)
                    {
                        if (value.Value.Date < this.MinValue)
                            value = this.MinValue;
                        if (value.Value.Date > this.MaxValue)
                            value = this.MaxValue;
                    }
                }

                if (this.dateValue == value)
                    return;

                DateValueChangedEventArgs arg = new DateValueChangedEventArgs() { OldDateValue = this.dateValue, NewDateValue = value };

                this.dateValue = value;

                this.LoadDateForControl(this.dateValue);

                this.UpdateRectangleText();
                this.Invalidate();

                this.OnDateValueChanged(arg);
            }
        }

        /// <summary>
        /// 该控件功能是否为包含日选择或时间选择
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("该控件功能是否为包含日选择或时间选择")]
        public bool YearMonthDayOrTime
        {
            get { return (this.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDay || this.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHour || this.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute || this.DateDisplayType == DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond); }
        }

        #region 顶部工具栏

        private Color topBarBackColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 顶部工具栏背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("顶部工具栏背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TopBarBackColor
        {
            get { return this.topBarBackColor; }
            set
            {
                if (this.topBarBackColor == value)
                    return;
                this.topBarBackColor = value;
            }
        }

        private Color topBarBtnForeNormalColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 顶部工具栏按钮字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("顶部工具栏按钮字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TopBarBtnForeNormalColor
        {
            get { return this.topBarBtnForeNormalColor; }
            set
            {
                if (this.topBarBtnForeNormalColor == value)
                    return;
                this.topBarBtnForeNormalColor = value;
            }
        }

        private Color topBarBtnForeEnterColor = Color.FromArgb(200, 255, 255, 255);
        /// <summary>
        /// 顶部工具栏按钮字体颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "200, 255, 255, 255")]
        [Description("顶部工具栏按钮字体颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TopBarBtnForeEnterColor
        {
            get { return this.topBarBtnForeEnterColor; }
            set
            {
                if (this.topBarBtnForeEnterColor == value)
                    return;
                this.topBarBtnForeEnterColor = value;
            }
        }

        #endregion

        #region 日期面板

        private Color dateBackNormalColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 日期面板背景颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("日期面板背景颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateBackNormalColor
        {
            get { return this.dateBackNormalColor; }
            set
            {
                if (this.dateBackNormalColor == value)
                    return;
                this.dateBackNormalColor = value;
            }
        }

        private Color dateBackSelectedColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 日期面板日期背景颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("日期面板日期背景颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateBackSelectedColor
        {
            get { return this.dateBackSelectedColor; }
            set
            {
                if (this.dateBackSelectedColor == value)
                    return;
                this.dateBackSelectedColor = value;
            }
        }

        private Color dateBackDisabledColor = Color.FromArgb(220, 220, 220);
        /// <summary>
        /// 日期面板日期背景颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "220, 220, 220")]
        [Description("日期面板日期背景颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateBackDisabledColor
        {
            get { return this.dateBackDisabledColor; }
            set
            {
                if (this.dateBackDisabledColor == value)
                    return;
                this.dateBackDisabledColor = value;
            }
        }

        private Color dateTitleForeColor = Color.FromArgb(105, 105, 105);
        /// <summary>
        /// 日期面板标题字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "105, 105, 105")]
        [Description("日期面板标题字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateTitleForeColor
        {
            get { return this.dateTitleForeColor; }
            set
            {
                if (this.dateTitleForeColor == value)
                    return;
                this.dateTitleForeColor = value;
            }
        }

        private Color dateForePastColor = Color.FromArgb(135, 206, 235);
        /// <summary>
        /// 日期面板过期日期字体颜色(过去)
        /// </summary>
        [DefaultValue(typeof(Color), "135, 206, 235")]
        [Description("日期面板过期日期字体颜色(过去)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateForePastColor
        {
            get { return this.dateForePastColor; }
            set
            {
                if (this.dateForePastColor == value)
                    return;
                this.dateForePastColor = value;
            }
        }

        private Color dateForeNormalColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 日期面板正常日期字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("日期面板正常日期字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateForeNormalColor
        {
            get { return this.dateForeNormalColor; }
            set
            {
                if (this.dateForeNormalColor == value)
                    return;
                this.dateForeNormalColor = value;
            }
        }

        private Color dateForeFutureColor = Color.FromArgb(135, 206, 235);
        /// <summary>
        /// 日期面板未来日期字体颜色(未来)
        /// </summary>
        [DefaultValue(typeof(Color), "135, 206, 235")]
        [Description("日期面板未来日期字体颜色(未来)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateForeFutureColor
        {
            get { return this.dateForeFutureColor; }
            set
            {
                if (this.dateForeFutureColor == value)
                    return;
                this.dateForeFutureColor = value;
            }
        }

        private Color dateBackEnterColor = Color.FromArgb(189, 220, 220, 220);
        /// <summary>
        /// 日期面板日期背景颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "189, 220, 220, 220")]
        [Description("日期面板日期背景颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateBackEnterColor
        {
            get { return this.dateBackEnterColor; }
            set
            {
                if (this.dateBackEnterColor == value)
                    return;
                this.dateBackEnterColor = value;
            }
        }

        private Color dateForeSelectedColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 日期面板日期字体颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("日期面板日期字体颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateForeSelectedColor
        {
            get { return this.dateForeSelectedColor; }
            set
            {
                if (this.dateForeSelectedColor == value)
                    return;
                this.dateForeSelectedColor = value;
            }
        }

        private Color dateForeDisabledColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 日期面板日期字体颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("日期面板日期字体颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DateForeDisabledColor
        {
            get { return this.dateForeDisabledColor; }
            set
            {
                if (this.dateForeDisabledColor == value)
                    return;
                this.dateForeDisabledColor = value;
            }
        }

        #region 时间

        private Color timeCrossLineColor = Color.FromArgb(40, 128, 128, 128);
        /// <summary>
        /// 时间选项分割线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "40, 128, 128, 128")]
        [Description("时间选项分割线颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TimeCrossLineColor
        {
            get { return this.timeCrossLineColor; }
            set
            {
                if (this.timeCrossLineColor == value)
                    return;
                this.timeCrossLineColor = value;
            }
        }

        private Color timeBackSelectedColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 时间面板时间背景颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("时间面板时间字体颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TimeBackSelectedColor
        {
            get { return this.timeBackSelectedColor; }
            set
            {
                if (this.timeBackSelectedColor == value)
                    return;
                this.timeBackSelectedColor = value;
            }
        }

        private Color timeForeNormalColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 时间面板时间字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("时间面板时间字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TimeForeNormalColor
        {
            get { return this.timeForeNormalColor; }
            set
            {
                if (this.timeForeNormalColor == value)
                    return;
                this.timeForeNormalColor = value;
            }
        }

        private Color timeForeSelectedColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 时间面板时间字体颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("时间面板时间字体颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TimeForeSelectedColor
        {
            get { return this.timeForeSelectedColor; }
            set
            {
                if (this.timeForeSelectedColor == value)
                    return;
                this.timeForeSelectedColor = value;
            }
        }

        private Color timeScrollBackColor = Color.FromArgb(40, 128, 128, 128);
        /// <summary>
        /// 时间滚动条背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "40, 128, 128, 128")]
        [Description("时间滚动条背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TimeScrollBackColor
        {
            get { return this.timeScrollBackColor; }
            set
            {
                if (this.timeScrollBackColor == value)
                    return;
                this.timeScrollBackColor = value;

            }
        }

        private Color timeScrollSlideColor = Color.FromArgb(150, 128, 128, 128);
        /// <summary>
        /// 时间滚动条滑块颜色
        /// </summary>
        [DefaultValue(typeof(Color), "150,128, 128, 128")]
        [Description("时间滚动条滑块颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TimeScrollSlideColor
        {
            get { return this.timeScrollSlideColor; }
            set
            {
                if (this.timeScrollSlideColor == value)
                    return;
                this.timeScrollSlideColor = value;

            }
        }

        #endregion

        #endregion

        #region 底部工具栏

        private Color bottomBarBackBorderColor = Color.FromArgb(233, 233, 233);
        /// <summary>
        /// 底部工具栏边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "233, 233, 233")]
        [Description("底部工具栏边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBackBorderColor
        {
            get { return this.bottomBarBackBorderColor; }
            set
            {
                if (this.bottomBarBackBorderColor == value)
                    return;
                this.bottomBarBackBorderColor = value;
            }
        }

        private Color bottomBarBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 底部工具栏背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("底部工具栏背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBackColor
        {
            get { return this.bottomBarBackColor; }
            set
            {
                if (this.bottomBarBackColor == value)
                    return;
                this.bottomBarBackColor = value;
            }
        }

        private Color bottomBarTipForeColor = Color.FromArgb(255, 204, 153);
        /// <summary>
        /// 底部工具栏最小最大限制提示字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 204, 153")]
        [Description("底部工具栏最小最大限制提示字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarTipForeColor
        {
            get { return this.bottomBarTipForeColor; }
            set
            {
                if (this.bottomBarTipForeColor == value)
                    return;
                this.bottomBarTipForeColor = value;
            }
        }

        #region 时钟

        private Color bottomBarClockBorderColor = Color.FromArgb(233, 143, 54);
        /// <summary>
        ///时钟边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "233, 143, 54")]
        [Description("时钟边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarClockBorderColor
        {
            get { return this.bottomBarClockBorderColor; }
            set
            {
                if (this.bottomBarClockBorderColor == value)
                    return;
                this.bottomBarClockBorderColor = value;
            }
        }

        private Color bottomBarClockDotColor = Color.FromArgb(0, 0, 0);
        /// <summary>
        ///时钟点颜色
        /// </summary>
        [DefaultValue(typeof(Color), "0, 0, 0")]
        [Description("时钟点颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarClockDotColor
        {
            get { return this.bottomBarClockDotColor; }
            set
            {
                if (this.bottomBarClockDotColor == value)
                    return;
                this.bottomBarClockDotColor = value;
                if (this.YearMonthDayOrTime)
                {
                    this.Invalidate();
                }
            }
        }

        private Color bottomBarClockHourColor = Color.FromArgb(71, 88, 126);
        /// <summary>
        ///时钟时指针颜色
        /// </summary>
        [DefaultValue(typeof(Color), "71, 88, 126")]
        [Description("时钟时指针颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarClockHourColor
        {
            get { return this.bottomBarClockHourColor; }
            set
            {
                if (this.bottomBarClockHourColor == value)
                    return;
                this.bottomBarClockHourColor = value;
            }
        }

        private Color bottomBarClockMinuteColor = Color.FromArgb(71, 88, 126);
        /// <summary>
        ///时钟分指针颜色
        /// </summary>
        [DefaultValue(typeof(Color), "71, 88, 126")]
        [Description("时钟分指针颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarClockMinuteColor
        {
            get { return this.bottomBarClockMinuteColor; }
            set
            {
                if (this.bottomBarClockMinuteColor == value)
                    return;
                this.bottomBarClockMinuteColor = value;
            }
        }

        private Color bottomBarClockSecondColor = Color.FromArgb(223, 137, 135);
        /// <summary>
        ///时钟秒指针颜色
        /// </summary>
        [DefaultValue(typeof(Color), "223, 137, 135")]
        [Description("时钟秒指针颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarClockSecondColor
        {
            get { return this.bottomBarClockSecondColor; }
            set
            {
                if (this.bottomBarClockSecondColor == value)
                    return;
                this.bottomBarClockSecondColor = value;
            }
        }

        #endregion

        #region 按钮

        private Color bottomBarBtnBackNormalColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 底部工具栏按钮背景颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("底部工具栏按钮背景颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBtnBackNormalColor
        {
            get { return this.bottomBarBtnBackNormalColor; }
            set
            {
                if (this.bottomBarBtnBackNormalColor == value)
                    return;
                this.bottomBarBtnBackNormalColor = value;
            }
        }

        private Color bottomBarBtnForeNormalColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 底部工具栏按钮字体颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "255,255,255")]
        [Description("底部工具栏按钮字体颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBtnForeNormalColor
        {
            get { return this.bottomBarBtnForeNormalColor; }
            set
            {
                if (this.bottomBarBtnForeNormalColor == value)
                    return;
                this.bottomBarBtnForeNormalColor = value;
            }
        }

        private Color bottomBarBtnBackEnterColor = Color.FromArgb(200, 153, 204, 153);
        /// <summary>
        /// 底部工具栏按钮背景颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "200, 153, 204, 153")]
        [Description("底部工具栏按钮背景颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBtnBackEnterColor
        {
            get { return this.bottomBarBtnBackEnterColor; }
            set
            {
                if (this.bottomBarBtnBackEnterColor == value)
                    return;
                this.bottomBarBtnBackEnterColor = value;
            }
        }

        private Color bottomBarBtnForeEnterColor = Color.FromArgb(200, 255, 255, 255);
        /// <summary>
        /// 底部工具栏按钮字体颜色(鼠标进入)
        /// </summary>
        [DefaultValue(typeof(Color), "200,255,255,255")]
        [Description("底部工具栏按钮字体颜色(鼠标进入)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBtnForeEnterColor
        {
            get { return this.bottomBarBtnForeEnterColor; }
            set
            {
                if (this.bottomBarBtnForeEnterColor == value)
                    return;
                this.bottomBarBtnForeEnterColor = value;
            }
        }

        private Color bottomBarBtnBackDisabledColor = Color.FromArgb(170, 153, 204, 153);
        /// <summary>
        /// 底部工具栏按钮背景颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "170, 153, 204, 153")]
        [Description("底部工具栏按钮背景颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBtnBackDisabledColor
        {
            get { return this.bottomBarBtnBackDisabledColor; }
            set
            {
                if (this.bottomBarBtnBackDisabledColor == value)
                    return;
                this.bottomBarBtnBackDisabledColor = value;
            }
        }

        private Color bottomBarBtnForeDisabledColor = Color.FromArgb(170, 255, 255, 255);
        /// <summary>
        /// 底部工具栏按钮字体颜色(禁用)
        /// </summary>
        [DefaultValue(typeof(Color), "170, 255, 255, 255")]
        [Description("底部工具栏按钮字体颜色(禁用)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BottomBarBtnForeDisabledColor
        {
            get { return this.bottomBarBtnForeDisabledColor; }
            set
            {
                if (this.bottomBarBtnForeDisabledColor == value)
                    return;
                this.bottomBarBtnForeDisabledColor = value;
            }
        }

        #endregion

        #endregion

        #endregion

        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        /// <summary>
        /// 控件默认大小
        /// </summary>
        [DefaultValue(typeof(Size), "226, 298")]
        [Description("控件默认大小")]
        protected override Size DefaultSize
        {
            get
            {
                return new Size(226, 298); ;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        private bool activatedState = false;

        /// <summary>
        /// 最小日期
        /// </summary>
        private static readonly DateTime minDate = new DateTime(1753, 1, 1).Date;
        /// <summary>
        /// 最大日期
        /// </summary>
        private static readonly DateTime maxDate = new DateTime(9998, 12, 31).Date;

        /// <summary>
        /// 顶部工具栏高度
        /// </summary>
        private readonly int topbar_rect_height = 36;

        /// <summary>
        /// 日期面板宽度
        /// </summary>
        private readonly int date_rect_width = 226;
        /// <summary>
        /// 日期面板高度
        /// </summary>
        private readonly int date_rect_height = 226;
        /// <summary>
        /// 日期标题
        /// </summary>
        private readonly string[] days_titles = new string[] { "日", "一", "二", "三", "四", "五", "六" };
        /// <summary>
        /// 年面板年选项宽度
        /// </summary>
        private readonly int year_rectf_item_width = 66;
        /// <summary>
        /// 年面板年选项高度
        /// </summary>
        private readonly int year_rectf_item_height = 36;
        /// <summary>
        /// 月面板月选项宽度
        /// </summary>
        private readonly int month_rectf_item_width = 66;
        /// <summary>
        /// 月面板月选项高度
        /// </summary>
        private readonly int month_rectf_item_height = 36;
        /// <summary>
        /// 日面板月选项宽度
        /// </summary>
        private readonly int day_rectf_item_width = 30;
        /// <summary>
        /// 日面板月选项高度
        /// </summary>
        private readonly int day_rectf_item_height = 30;

        /// <summary>
        /// 时间面板顶部工具栏高度
        /// </summary>
        private readonly int time_topbar_rect_height = 36;

        /// <summary>
        /// 时间面板选项高度
        /// </summary>
        public int time_item_height = 26;
        /// <summary>
        /// 滚动条厚度
        /// </summary>
        private int timeScrollThickness = 8;

        /// <summary>
        /// 底部工具栏高度
        /// </summary>
        private readonly int bottombar_rect_height = 36;

        /// <summary>
        /// 开始日期对象
        /// </summary>
        private DateClass DateObject;

        /// <summary>
        /// 画笔管理
        /// </summary>
        private SolidBrushManage SolidBrushManageObject;

        /// <summary>
        /// 居中字体格式
        /// </summary>
        private static readonly StringFormat center_sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        #endregion

        public DatePickerExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.FromArgb(255, 255, 255);

            this.SolidBrushManageObject = new SolidBrushManage(this);
            this.DateObject = new DateClass();

            this.LoadDateForControl(this.DateValue);

            this.InitializeRectangle();
            this.UpdateRectangleText();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            RectangleF rectf = new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);

            #region 背景
            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, rectf);
            back_sb.Dispose();
            #endregion
            #region 顶部工具栏
            this.DrawTopBar(g);
            #endregion
            #region 年面板
            if (this.DateDisplayType == DateDisplayTypes.Year || (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year))
            {
                this.DrawYear(g);
            }
            #endregion
            #region 月面板
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                this.DrawYearMonth(g);
            }
            #endregion
            #region 日面板
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.Default)
            {
                this.DrawYearMonthDay(g);
            }
            #endregion
            #region 时间面板
            else if (this.YearMonthDayOrTime && (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time))
            {
                this.DrawTime(g);
            }
            #endregion
            #region 底部工具栏
            this.DrawBottomBar(g);
            #endregion
            #region 控件激活的虚线
            if (this.activatedState)
            {
                #region 年
                #region
                if (this.DateDisplayType == DateDisplayTypes.Year)
                {
                    if (this.DateObject.YearMain.activeIndex == -2)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.prev_year_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == -1)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.next_year_btn.Rect);
                    }
                    else if (0 <= this.DateObject.YearMain.activeIndex && this.DateObject.YearMain.activeIndex <= 11)
                    {
                        this.DrawActiveBorder(g, this.DateObject.YearMain.itemArr[this.DateObject.YearMain.activeIndex].Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 12)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 13)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 14)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                    }
                }
                #endregion
                #region
                else if (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year)
                {
                    if (this.DateObject.YearMain.activeIndex == -3)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.prev_year_btn.Rect);
                    }
                    if (this.DateObject.YearMain.activeIndex == -2)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.monthyear_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == -1)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.next_year_btn.Rect);
                    }
                    else if (0 <= this.DateObject.YearMain.activeIndex && this.DateObject.YearMain.activeIndex <= 11)
                    {
                        this.DrawActiveBorder(g, this.DateObject.YearMain.itemArr[this.DateObject.YearMain.activeIndex].Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 12)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 13)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 14)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                    }
                }
                #endregion
                #region
                else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)
                {
                    if (this.DateObject.YearMain.activeIndex == -6)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.prev_year_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == -5)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.prev_month_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == -4)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.month_btn.Rect);
                    }
                    if (this.DateObject.YearMain.activeIndex == -3)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.year_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == -2)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.next_month_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == -1)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.next_year_btn.Rect);
                    }
                    else if (0 <= this.DateObject.YearMain.activeIndex && this.DateObject.YearMain.activeIndex <= 11)
                    {
                        this.DrawActiveBorder(g, this.DateObject.YearMain.itemArr[this.DateObject.YearMain.activeIndex].Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 12)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_time_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 13)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 14)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                    }
                    else if (this.DateObject.YearMain.activeIndex == 15)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                    }
                }
                #endregion
                #endregion
                #region 月
                #region
                else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
                {
                    if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                    {
                        if (this.DateObject.MonthMain.activeIndex == -3)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.prev_year_btn.Rect);
                        }
                        else if (this.DateObject.MonthMain.activeIndex == -2)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.monthyear_btn.Rect);
                        }
                        else if (this.DateObject.MonthMain.activeIndex == -1)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.next_year_btn.Rect);
                        }
                        else if (0 <= this.DateObject.MonthMain.activeIndex && this.DateObject.MonthMain.activeIndex <= 11)
                        {
                            this.DrawActiveBorder(g, this.DateObject.MonthMain.itemArr[this.DateObject.MonthMain.activeIndex].Rect);
                        }
                        else if (this.DateObject.MonthMain.activeIndex == 12)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                        }
                        else if (this.DateObject.MonthMain.activeIndex == 13)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                        }
                        else if (this.DateObject.MonthMain.activeIndex == 14)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                        }
                    }
                }
                #endregion
                #region
                else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
                {
                    if (this.DateObject.MonthMain.activeIndex == -6)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.prev_year_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == -5)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.prev_month_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == -4)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.month_btn.Rect);
                    }
                    if (this.DateObject.MonthMain.activeIndex == -3)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.year_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == -2)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.next_month_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == -1)
                    {
                        this.DrawActiveBorder(g, this.DateObject.TopBar.next_year_btn.Rect);
                    }
                    else if (0 <= this.DateObject.MonthMain.activeIndex && this.DateObject.MonthMain.activeIndex <= 11)
                    {
                        this.DrawActiveBorder(g, this.DateObject.MonthMain.itemArr[this.DateObject.MonthMain.activeIndex].Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == 12)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_time_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == 13)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == 14)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                    }
                    else if (this.DateObject.MonthMain.activeIndex == 15)
                    {
                        this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                    }
                }
                #endregion
                #endregion
                #region 日
                #region
                else if (this.YearMonthDayOrTime)
                {
                    if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
                    {
                        if (this.DateObject.DayMain.activeIndex == 0)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_time_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 1)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 2)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 3)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                        }
                    }
                    else
                    {
                        if (this.DateObject.DayMain.activeIndex == -6)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.prev_year_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == -5)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.prev_month_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == -4)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.month_btn.Rect);
                        }
                        if (this.DateObject.DayMain.activeIndex == -3)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.year_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == -2)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.next_month_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == -1)
                        {
                            this.DrawActiveBorder(g, this.DateObject.TopBar.next_year_btn.Rect);
                        }
                        else if (7 <= this.DateObject.DayMain.activeIndex && this.DateObject.DayMain.activeIndex <= 48)
                        {
                            this.DrawActiveBorder(g, this.DateObject.DayMain.itemArr[this.DateObject.DayMain.activeIndex].Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 49)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_time_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 50)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_clear_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 51)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_now_btn.Rect);
                        }
                        else if (this.DateObject.DayMain.activeIndex == 52)
                        {
                            this.DrawActiveBorder(g, this.DateObject.BottomBar.bottombar_confirm_btn.Rect);
                        }
                    }
                }
                #endregion
                #endregion
            }
            #endregion
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            if (this.SolidBrushManageObject != null)
                this.SolidBrushManageObject.ReleaseSolidBrushs();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.activatedState)
            {
                #region Left
                if (keyData == Keys.Left)
                {
                    int index_tmp = this.UpdateActiveIndexByKey(this.GetIndexOffset(KeyOffsetTypes.Left));
                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    int index_tmp = this.UpdateActiveIndexByKey(this.GetIndexOffset(KeyOffsetTypes.Right));
                    return false;
                }
                #endregion
                #region Up
                else if (keyData == Keys.Up)
                {
                    int index_tmp = this.UpdateActiveIndexByKey(this.GetIndexOffset(KeyOffsetTypes.Up));
                    return false;
                }
                #endregion
                #region Down
                else if (keyData == Keys.Down)
                {
                    int index_tmp = this.UpdateActiveIndexByKey(this.GetIndexOffset(KeyOffsetTypes.Down));
                    return false;
                }
                #endregion
                #region Enter
                else if (keyData == Keys.Enter)
                {
                    this.ActiveIndexClick();
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
                return;

            #region  顶部工具栏鼠标按下释放
            this.DateObject.TopBar.prev_year_btn.ismovedown = false;
            this.DateObject.TopBar.prev_month_btn.ismovedown = false;
            this.DateObject.TopBar.next_month_btn.ismovedown = false;
            this.DateObject.TopBar.next_year_btn.ismovedown = false;
            this.DateObject.TopBar.next_month_btn.ismovedown = false;
            this.DateObject.TopBar.monthyear_btn.ismovedown = false;
            #endregion

            #region 年面板、年面板选项(鼠标按下释放、鼠标离开)
            if (this.DateDisplayType == DateDisplayTypes.Year || (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year))
            {
                this.DateObject.TimeMain.HourArea.MoveStatus = MoveStatuss.Normal;
                for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                {
                    this.DateObject.YearMain.itemArr[i].ismovedown = false;
                    this.DateObject.YearMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                }
                this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.ismovedown = false;
            }
            #endregion
            #region 月面板、月面板选项(鼠标按下释放、鼠标离开)
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                this.DateObject.TimeMain.MinuteArea.MoveStatus = MoveStatuss.Normal;
                for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                {
                    this.DateObject.MonthMain.itemArr[i].ismovedown = false;
                    this.DateObject.MonthMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                }
                this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.ismovedown = false;
            }
            #endregion
            #region 日面板、日面板选项(鼠标按下释放、鼠标离开)
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                this.DateObject.TimeMain.SecondArea.MoveStatus = MoveStatuss.Normal;
                for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                {
                    this.DateObject.DayMain.itemArr[i].ismovedown = false;
                    this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                }
                this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.ismovedown = false;
            }
            #endregion
            #region 时间面板鼠标按下释放
            if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
            {
                #region 时区域鼠标按下释放
                this.DateObject.TimeMain.HourArea.ismovedown = false;
                for (int i = 0; i < this.DateObject.TimeMain.HourArea.itemArr.Length; i++)
                {
                    this.DateObject.TimeMain.HourArea.itemArr[i].ismovedown = false;
                }
                this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.ismovedown = false;
                #endregion
                #region 分区域鼠标按下释放
                this.DateObject.TimeMain.MinuteArea.ismovedown = false;
                for (int i = 0; i < this.DateObject.TimeMain.MinuteArea.itemArr.Length; i++)
                {
                    this.DateObject.TimeMain.MinuteArea.itemArr[i].ismovedown = false;
                }
                this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.ismovedown = false;
                #endregion
                #region 秒区域鼠标按下释放
                this.DateObject.TimeMain.SecondArea.ismovedown = false;
                for (int i = 0; i < this.DateObject.TimeMain.SecondArea.itemArr.Length; i++)
                {
                    this.DateObject.TimeMain.SecondArea.itemArr[i].ismovedown = false;
                }
                this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.ismovedown = false;
                #endregion
            }
            #endregion

            #region  底部工具栏鼠标按下释放
            this.DateObject.BottomBar.bottombar_time_btn.ismovedown = false;
            this.DateObject.BottomBar.bottombar_clear_btn.ismovedown = false;
            this.DateObject.BottomBar.bottombar_now_btn.ismovedown = false;
            this.DateObject.BottomBar.bottombar_confirm_btn.ismovedown = false;
            #endregion
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
                return;

            if (this.activatedState == false)
            {
                this.Select();
            }
            if (!this.Focused)
            {
                this.Focus();
            }

            #region  顶部工具栏鼠标按下
            #region   上一年按钮鼠标按下
            if (this.DateObject.TopBar.prev_year_btn.Rect.Contains(e.Location))
            {
                this.DateObject.TopBar.prev_year_btn.ismovedown = true;
            }
            #endregion
            #region 上一月按钮鼠标按下
            else if (this.DateObject.TopBar.prev_month_btn.Rect.Contains(e.Location))
            {
                this.DateObject.TopBar.prev_month_btn.ismovedown = true;
            }
            #endregion
            #region 月按钮鼠标按下
            else if (this.DateObject.TopBar.month_btn.Rect.Contains(e.Location) && this.YearMonthDayOrTime)
            {
                this.DateObject.TopBar.month_btn.ismovedown = true;
            }
            #endregion
            #region 年按钮鼠标按下
            else if (this.DateObject.TopBar.year_btn.Rect.Contains(e.Location) && (this.DateDisplayType == DateDisplayTypes.YearMonth || this.YearMonthDayOrTime))
            {
                this.DateObject.TopBar.year_btn.ismovedown = true;
            }
            #endregion
            #region 下一月按钮鼠标按下
            else if (this.DateObject.TopBar.next_month_btn.Rect.Contains(e.Location))
            {
                this.DateObject.TopBar.next_month_btn.ismovedown = true;
            }
            #endregion
            #region 下一年按钮鼠标按下
            else if (this.DateObject.TopBar.next_year_btn.Rect.Contains(e.Location))
            {
                this.DateObject.TopBar.next_year_btn.ismovedown = true;
            }
            #endregion
            #endregion

            #region 年面板选项鼠标按下
            if (this.DateDisplayType == DateDisplayTypes.Year || (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year))
            {
                if (this.DateObject.YearMain.Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                    {
                        if (this.DateObject.YearMain.itemArr[i].Rect.Contains(e.Location))
                        {
                            this.DateObject.YearMain.itemArr[i].ismovedown = true;
                        }
                    }
                }
            }
            #endregion
            #region 月面板选项鼠标按下
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                {
                    if (this.DateObject.MonthMain.itemArr[i].Rect.Contains(e.Location))
                    {
                        this.DateObject.MonthMain.itemArr[i].ismovedown = true;
                    }
                }

            }
            #endregion
            #region 日面板选项鼠标按下
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.Default)
            {
                for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                {
                    if (this.DateObject.DayMain.itemArr[i].Rect.Contains(e.Location))
                    {
                        this.DateObject.DayMain.itemArr[i].ismovedown = true;
                    }
                }
            }
            #endregion
            #region 时间面板鼠标按下
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
            {
                #region 滚动条滑块鼠标按下
                if (this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.ismovedown = true;
                    this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.movedownpoint = e.Location;

                }
                else if (this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.ismovedown = true;
                    this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.movedownpoint = e.Location;

                }
                else if (this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.ismovedown = true;
                    this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.movedownpoint = e.Location;

                }
                #endregion
                #region 时区域、时区域选项鼠标按下
                if (this.DateObject.TimeMain.HourArea.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.HourArea.ismovedown = true;
                    this.DateObject.TimeMain.HourArea.movedownpoint = e.Location;
                    int y = this.GetDisplayY(this.DateObject.TimeMain.HourArea.verticalScroll);
                    for (int i = 0; i < this.DateObject.TimeMain.HourArea.itemArr.Length; i++)
                    {
                        if (this.DateObject.TimeMain.HourArea.itemArr[i].Rect != Rectangle.Empty)
                        {
                            if (this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                            {
                                this.DateObject.TimeMain.HourArea.itemArr[i].ismovedown = true;
                                break;
                            }
                        }
                    }
                }
                #endregion
                #region 分区域、分区域选项鼠标按下
                else if (this.DateObject.TimeMain.MinuteArea.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.MinuteArea.ismovedown = true;
                    this.DateObject.TimeMain.MinuteArea.movedownpoint = e.Location;
                    int y = this.GetDisplayY(this.DateObject.TimeMain.MinuteArea.verticalScroll);
                    for (int i = 0; i < this.DateObject.TimeMain.MinuteArea.itemArr.Length; i++)
                    {
                        if (this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect != Rectangle.Empty)
                        {
                            if (this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                            {
                                this.DateObject.TimeMain.MinuteArea.itemArr[i].ismovedown = true;
                                break;
                            }
                        }
                    }
                }
                #endregion
                #region 秒区域、秒区域选项鼠标按下
                else if (this.DateObject.TimeMain.SecondArea.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.SecondArea.ismovedown = true;
                    this.DateObject.TimeMain.SecondArea.movedownpoint = e.Location;
                    int y = this.GetDisplayY(this.DateObject.TimeMain.SecondArea.verticalScroll);
                    for (int i = 0; i < this.DateObject.TimeMain.SecondArea.itemArr.Length; i++)
                    {
                        if (this.DateObject.TimeMain.SecondArea.itemArr[i].Rect != Rectangle.Empty)
                        {
                            if (this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                            {
                                this.DateObject.TimeMain.SecondArea.itemArr[i].ismovedown = true;
                                break;
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region  底部工具栏鼠标按下
            #region   时钟按钮鼠标按下
            if (this.DateObject.BottomBar.bottombar_time_btn.Rect.Contains(e.Location))
            {
                this.DateObject.BottomBar.bottombar_time_btn.ismovedown = true;
            }
            #endregion
            #region 清除按钮鼠标按下
            else if (this.DateObject.BottomBar.bottombar_clear_btn.Rect.Contains(e.Location))
            {
                this.DateObject.BottomBar.bottombar_clear_btn.ismovedown = true;
            }
            #endregion
            #region 现在按钮鼠标按下
            else if (this.DateObject.BottomBar.bottombar_now_btn.Rect.Contains(e.Location))
            {
                this.DateObject.BottomBar.bottombar_now_btn.ismovedown = true;
            }
            #endregion
            #region 确认按钮鼠标按下
            else if (this.DateObject.BottomBar.bottombar_confirm_btn.Rect.Contains(e.Location))
            {
                this.DateObject.BottomBar.bottombar_confirm_btn.ismovedown = true;
            }
            #endregion
            #endregion
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
                return;

            #region  顶部工具栏鼠标按下释放
            this.DateObject.TopBar.prev_year_btn.ismovedown = false;
            this.DateObject.TopBar.prev_month_btn.ismovedown = false;
            this.DateObject.TopBar.next_month_btn.ismovedown = false;
            this.DateObject.TopBar.next_year_btn.ismovedown = false;
            this.DateObject.TopBar.next_month_btn.ismovedown = false;
            this.DateObject.TopBar.monthyear_btn.ismovedown = false;
            #endregion

            #region 年面板选项鼠标按下释放
            if (this.DateDisplayType == DateDisplayTypes.Year || (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year))
            {
                for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                {
                    this.DateObject.YearMain.itemArr[i].ismovedown = false;
                }
            }
            #endregion
            #region 月面板选项鼠标按下释放
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                {
                    this.DateObject.MonthMain.itemArr[i].ismovedown = false;
                }
            }
            #endregion
            #region 日面板选项鼠标按下释放
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                {
                    this.DateObject.DayMain.itemArr[i].ismovedown = false;
                }
            }
            #endregion
            #region 时间面板鼠标按下释放
            if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
            {
                #region 时区域鼠标按下释放
                this.DateObject.TimeMain.HourArea.ismovedown = false;
                for (int i = 0; i < this.DateObject.TimeMain.HourArea.itemArr.Length; i++)
                {
                    this.DateObject.TimeMain.HourArea.itemArr[i].ismovedown = false;
                }
                this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.ismovedown = false;
                #endregion
                #region 分区域鼠标按下释放
                this.DateObject.TimeMain.MinuteArea.ismovedown = false;
                for (int i = 0; i < this.DateObject.TimeMain.MinuteArea.itemArr.Length; i++)
                {
                    this.DateObject.TimeMain.MinuteArea.itemArr[i].ismovedown = false;
                }
                this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.ismovedown = false;
                #endregion
                #region 秒区域鼠标按下释放
                this.DateObject.TimeMain.SecondArea.ismovedown = false;
                for (int i = 0; i < this.DateObject.TimeMain.SecondArea.itemArr.Length; i++)
                {
                    this.DateObject.TimeMain.SecondArea.itemArr[i].ismovedown = false;
                }
                this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.ismovedown = false;
                #endregion
            }
            #endregion

            #region  底部工具栏鼠标按下释放
            this.DateObject.BottomBar.bottombar_time_btn.ismovedown = false;
            this.DateObject.BottomBar.bottombar_clear_btn.ismovedown = false;
            this.DateObject.BottomBar.bottombar_now_btn.ismovedown = false;
            this.DateObject.BottomBar.bottombar_confirm_btn.ismovedown = false;
            #endregion
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
                return;

            bool isreset = false;
            bool isenter = false;

            #region 顶部工具栏鼠标进入离开（用于变色）
            if (this.DateObject.TopBar.Rect.Contains(e.Location))
            {
                #region 上一年按钮
                if (this.DateObject.TopBar.prev_year_btn.Rect.Contains(e.Location))
                {
                    this.DateObject.TopBar.prev_year_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.TopBar.prev_year_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 上一月按钮
                if (this.DateObject.TopBar.prev_month_btn.Rect.Contains(e.Location) && this.YearMonthDayOrTime)
                {
                    this.DateObject.TopBar.prev_month_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.TopBar.prev_month_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 月按钮
                if (this.DateObject.TopBar.month_btn.Rect.Contains(e.Location) && this.YearMonthDayOrTime)
                {
                    this.DateObject.TopBar.month_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.TopBar.month_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 年按钮
                if (this.DateObject.TopBar.year_btn.Rect.Contains(e.Location) && (this.DateDisplayType == DateDisplayTypes.YearMonth || this.YearMonthDayOrTime))
                {
                    this.DateObject.TopBar.year_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.TopBar.year_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 下一月按钮
                if (this.DateObject.TopBar.next_month_btn.Rect.Contains(e.Location) && this.YearMonthDayOrTime)
                {
                    this.DateObject.TopBar.next_month_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.TopBar.next_month_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 下一年按钮
                if (this.DateObject.TopBar.next_year_btn.Rect.Contains(e.Location))
                {
                    this.DateObject.TopBar.next_year_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.TopBar.next_year_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
            }
            else
            {
                this.DateObject.TopBar.prev_year_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TopBar.prev_month_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TopBar.month_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TopBar.year_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TopBar.next_month_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.TopBar.next_year_btn.MoveStatus = MoveStatuss.Normal;
            }
            #endregion

            #region 年面板鼠标进入离开（用于变色）
            if (this.DateDisplayType == DateDisplayTypes.Year || (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year))
            {
                #region
                if (this.DateObject.YearMain.Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                    {
                        if (this.DateObject.YearMain.itemArr[i].Rect.Contains(e.Location))
                        {
                            if (this.DateObject.YearMain.itemArr[i].DateItemType == DateItemTypes.Normal)
                            {
                                this.DateObject.YearMain.itemArr[i].MoveStatus = MoveStatuss.Enter;
                                isenter = true;
                            }
                        }
                        else
                        {
                            this.DateObject.YearMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        }
                    }
                }
                #endregion
                #region
                else
                {
                    for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                    {
                        this.DateObject.YearMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                    }
                }
                #endregion
            }
            #endregion
            #region 月面板鼠标进入离开（用于变色）
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                #region
                if (this.DateObject.MonthMain.Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                    {
                        if (this.DateObject.MonthMain.itemArr[i].Rect.Contains(e.Location))
                        {
                            if (this.DateObject.MonthMain.itemArr[i].DateItemType == DateItemTypes.Normal)
                            {
                                this.DateObject.MonthMain.itemArr[i].MoveStatus = MoveStatuss.Enter;
                                isenter = true;
                            }
                        }
                        else
                        {
                            this.DateObject.MonthMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        }
                    }
                }
                #endregion
                #region
                else
                {
                    for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                    {
                        this.DateObject.MonthMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                    }
                }
                #endregion
            }
            #endregion
            #region 日面板鼠标进入离开（用于变色）
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.Default)
            {
                #region
                if (this.DateObject.DayMain.Rect.Contains(e.Location))
                {
                    for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                    {
                        if (this.DateObject.DayMain.itemArr[i].Rect.Contains(e.Location))
                        {
                            if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Past || this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Normal || this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Future)
                            {
                                this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Enter;
                                isenter = true;
                            }
                        }
                        else
                        {
                            this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        }
                    }
                }
                #endregion
                #region
                else
                {
                    for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                    {
                        this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                    }
                }
                #endregion
            }
            #endregion
            #region 时间面板鼠标
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
            {
                #region 时区域鼠标进入离开（用于滚轮）
                if (this.DateObject.TimeMain.HourArea.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.HourArea.MoveStatus = MoveStatuss.Enter;
                }
                else
                {
                    this.DateObject.TimeMain.HourArea.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 时区域滚动条鼠标进入离开（用于滚轮）
                if (this.DateObject.TimeMain.HourArea.verticalScroll.ScrollBack.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.HourArea.verticalScroll.ScrollBack.MoveStatus = MoveStatuss.Enter;
                }
                else
                {
                    this.DateObject.TimeMain.HourArea.verticalScroll.ScrollBack.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 分区域鼠标进入离开（用于滚轮）
                if (this.DateObject.TimeMain.MinuteArea.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.MinuteArea.MoveStatus = MoveStatuss.Enter;
                }
                else
                {
                    this.DateObject.TimeMain.MinuteArea.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 分区域滚动条鼠标进入离开（用于滚轮）
                if (this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollBack.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollBack.MoveStatus = MoveStatuss.Enter;
                }
                else
                {
                    this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollBack.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 秒区域鼠标进入离开（用于滚轮）
                if (this.DateObject.TimeMain.SecondArea.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.SecondArea.MoveStatus = MoveStatuss.Enter;
                }
                else
                {
                    this.DateObject.TimeMain.SecondArea.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 秒区域滚动条鼠标进入离开（用于滚轮）
                if (this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollBack.Rect.Contains(e.Location))
                {
                    this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollBack.MoveStatus = MoveStatuss.Enter;
                }
                else
                {
                    this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollBack.MoveStatus = MoveStatuss.Normal;
                }
                #endregion

                #region 滚动条滑块上下滚动
                if (this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.ismovedown)
                {
                    int offset = (int)((e.Location.Y - this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.movedownpoint.Y));
                    if (this.DateObject.TimeMain.HourArea.verticalScroll.IsResetScroll(offset))
                    {
                        this.DateObject.TimeMain.HourArea.verticalScroll.ScrollSlide.movedownpoint = e.Location;
                        isreset = true;
                    }
                }
                else if (this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.ismovedown)
                {
                    int offset = (int)((e.Location.Y - this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.movedownpoint.Y));
                    if (this.DateObject.TimeMain.MinuteArea.verticalScroll.IsResetScroll(offset))
                    {
                        this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollSlide.movedownpoint = e.Location;
                        isreset = true;
                    }
                }
                else if (this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.ismovedown)
                {
                    int offset = (int)((e.Location.Y - this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.movedownpoint.Y));
                    if (this.DateObject.TimeMain.SecondArea.verticalScroll.IsResetScroll(offset))
                    {
                        this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollSlide.movedownpoint = e.Location;
                        isreset = true;
                    }
                }
                if (isreset)
                {
                    this.Invalidate();
                }
                #endregion
            }

            #endregion

            #region  底部工具栏鼠标进入离开（用于变色）
            if (this.DateObject.BottomBar.Rect.Contains(e.Location))
            {
                #region 时钟按钮
                if (this.DateObject.BottomBar.bottombar_time_btn.Rect.Contains(e.Location))
                {
                    this.DateObject.BottomBar.bottombar_time_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 清除按钮
                if (this.DateObject.BottomBar.bottombar_clear_btn.Rect.Contains(e.Location))
                {
                    this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 现在按钮
                if (this.DateObject.BottomBar.bottombar_now_btn.Rect.Contains(e.Location) && this.DateObject.BottomBar.bottombar_now_btn.ItemStatus == BottomBarItemStatuss.Normal)
                {
                    this.DateObject.BottomBar.bottombar_now_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.BottomBar.bottombar_now_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
                #region 确认按钮
                if (this.DateObject.BottomBar.bottombar_confirm_btn.Rect.Contains(e.Location))
                {
                    this.DateObject.BottomBar.bottombar_confirm_btn.MoveStatus = MoveStatuss.Enter;
                    isenter = true;
                }
                else
                {
                    this.DateObject.BottomBar.bottombar_confirm_btn.MoveStatus = MoveStatuss.Normal;
                }
                #endregion
            }
            else
            {
                this.DateObject.BottomBar.bottombar_time_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.BottomBar.bottombar_now_btn.MoveStatus = MoveStatuss.Normal;
                this.DateObject.BottomBar.bottombar_confirm_btn.MoveStatus = MoveStatuss.Normal;
            }
            #endregion

            this.Cursor = isenter ? Cursors.Hand : Cursors.Default;
            if (isreset || isenter)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
                return;

            #region 时区域、时区域滚动条滚动
            if (this.DateObject.TimeMain.HourArea.MoveStatus == MoveStatuss.Enter || this.DateObject.TimeMain.HourArea.verticalScroll.ScrollBack.MoveStatus == MoveStatuss.Enter)
            {
                int offset = e.Delta > 1 ? -1 : 1;
                if (this.DateObject.TimeMain.HourArea.verticalScroll.IsResetScroll(offset))
                {
                    this.Invalidate();
                }
            }
            #endregion
            #region 分区域、分区域滚动条滚动
            else if (this.DateObject.TimeMain.MinuteArea.MoveStatus == MoveStatuss.Enter || this.DateObject.TimeMain.MinuteArea.verticalScroll.ScrollBack.MoveStatus == MoveStatuss.Enter)
            {
                int offset = e.Delta > 1 ? -1 : 1;
                if (this.DateObject.TimeMain.MinuteArea.verticalScroll.IsResetScroll(offset))
                {
                    this.Invalidate();
                }
            }
            #endregion
            #region 秒区域、秒区域滚动条滚动
            else if (this.DateObject.TimeMain.SecondArea.MoveStatus == MoveStatuss.Enter || this.DateObject.TimeMain.SecondArea.verticalScroll.ScrollBack.MoveStatus == MoveStatuss.Enter)
            {
                int offset = e.Delta > 1 ? -1 : 1;
                if (this.DateObject.TimeMain.SecondArea.verticalScroll.IsResetScroll(offset))
                {
                    this.Invalidate();
                }
            }
            #endregion
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (this.DateReadOnly)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            #region 顶部工具栏
            if (this.DateObject.TopBar.Rect.Contains(e.Location) && this.DateDisplayStatus != DateDisplayStatuss.YearMonthDay_Time)
            {
                #region 上一年按钮
                if (this.DateObject.TopBar.prev_year_btn.ismovedown && this.DateObject.TopBar.prev_year_btn.Rect.Contains(e.Location))
                {
                    this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                    this.UpdateTopRectangleText();
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
                #region 上一月按钮
                else if (this.DateObject.TopBar.prev_month_btn.ismovedown && this.DateObject.TopBar.prev_month_btn.Rect.Contains(e.Location))
                {
                    if (this.YearMonthDayOrTime)
                    {
                        this.OnTopBarPrevMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_month_btn.Text });
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                    }
                }
                #endregion
                #region 月按钮
                else if (this.DateObject.TopBar.month_btn.ismovedown && this.DateObject.TopBar.month_btn.Rect.Contains(e.Location) && this.YearMonthDayOrTime)
                {
                    if (this.YearMonthDayOrTime)
                    {
                        this.OnTopBarMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.month_btn.Text });
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                    }
                }
                #endregion
                #region 年按钮
                else if (this.DateObject.TopBar.year_btn.ismovedown && this.DateObject.TopBar.year_btn.Rect.Contains(e.Location) && (this.DateDisplayType == DateDisplayTypes.YearMonth || this.YearMonthDayOrTime))
                {
                    if (this.DateDisplayType == DateDisplayTypes.YearMonth || this.YearMonthDayOrTime)
                    {
                        this.OnTopBarYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.year_btn.Text });
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                    }
                }
                #endregion
                #region 下一月按钮
                else if (this.DateObject.TopBar.next_month_btn.ismovedown && this.DateObject.TopBar.next_month_btn.Rect.Contains(e.Location))
                {
                    if (this.YearMonthDayOrTime)
                    {
                        this.OnTopBarNextMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_month_btn.Text });
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                    }
                }
                #endregion
                #region 下一年按钮
                else if (this.DateObject.TopBar.next_year_btn.ismovedown && this.DateObject.TopBar.next_year_btn.Rect.Contains(e.Location))
                {
                    this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                    this.UpdateTopRectangleText();
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
            }
            #endregion

            #region 年选项单击
            else if (this.DateObject.YearMain.Rect.Contains(e.Location) && (this.DateDisplayType == DateDisplayTypes.Year || (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)))
            {
                for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                {
                    if (this.DateObject.YearMain.itemArr[i].ismovedown && this.DateObject.YearMain.itemArr[i].Rect.Contains(e.Location) && this.DateObject.YearMain.itemArr[i].DateItemType == DateItemTypes.Normal)
                    {
                        this.OnYearMainItemClick(new YearMainItemEventArgs() { Item = this.DateObject.YearMain.itemArr[i] });
                        if (this.AutoConfirm && this.DateDisplayType == DateDisplayTypes.Year)
                        {
                            this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                        }
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                        break;
                    }
                }
            }
            #endregion
            #region 月选项单击
            else if (this.DateObject.MonthMain.Rect.Contains(e.Location) && (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.Default) || (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                {
                    if (this.DateObject.MonthMain.itemArr[i].ismovedown && this.DateObject.MonthMain.itemArr[i].Rect.Contains(e.Location) && this.DateObject.MonthMain.itemArr[i].DateItemType == DateItemTypes.Normal)
                    {
                        this.OnMonthMainItemClick(new MonthMainItemEventArgs() { Item = this.DateObject.MonthMain.itemArr[i] });
                        if (this.AutoConfirm && this.DateDisplayType == DateDisplayTypes.YearMonth)
                        {
                            this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                        }
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                        break;
                    }
                }
            }
            #endregion
            #region 日选项单击
            else if (this.DateObject.DayMain.Rect.Contains(e.Location) && (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.Default))
            {
                for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                {
                    if (this.DateObject.DayMain.itemArr[i].ismovedown && this.DateObject.DayMain.itemArr[i].Rect.Contains(e.Location) && (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Past || this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Normal || this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Future))
                    {
                        this.OnDayMainItemClick(new DayMainItemEventArgs() { Item = this.DateObject.DayMain.itemArr[i] });

                        if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Past)
                        {
                            this.OnTopBarPrevMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_month_btn.Text });
                        }
                        else if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Future)
                        {
                            this.OnTopBarNextMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_month_btn.Text });
                        }
                        if (this.AutoConfirm)
                        {
                            this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                        }
                        this.UpdateTopRectangleText();
                        this.UpdateYearMonthDayRectangleText();
                        this.Invalidate();
                        break;
                    }
                }
            }
            #endregion
            #region 时间面板
            else if (this.DateObject.TimeMain.Rect.Contains(e.Location) && (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time))
            {
                #region 时选项
                if (this.DateObject.TimeMain.HourArea.Rect.Contains(e.Location))
                {
                    int y = this.GetDisplayY(this.DateObject.TimeMain.HourArea.verticalScroll);
                    for (int i = 0; i < this.DateObject.TimeMain.HourArea.itemArr.Length; i++)
                    {
                        if (this.DateObject.TimeMain.HourArea.itemArr[i].ismovedown && this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            this.OnTimeMainHourClick(new TimeMainHourEventArgs() { Text = this.DateObject.TimeMain.HourArea.itemArr[i].Text, Value = this.DateObject.TimeMain.HourArea.itemArr[i].Value });
                            break;
                        }
                    }
                }
                #endregion
                #region 分选项
                else if (this.DateObject.TimeMain.MinuteArea.Rect.Contains(e.Location))
                {
                    int y = this.GetDisplayY(this.DateObject.TimeMain.MinuteArea.verticalScroll);
                    for (int i = 0; i < this.DateObject.TimeMain.MinuteArea.itemArr.Length; i++)
                    {
                        if (this.DateObject.TimeMain.MinuteArea.itemArr[i].ismovedown && this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            this.OnTimeMainMinuteClick(new TimeMainMinuteEventArgs() { Text = this.DateObject.TimeMain.MinuteArea.itemArr[i].Text, Value = this.DateObject.TimeMain.MinuteArea.itemArr[i].Value });
                            break;
                        }
                    }
                }
                #endregion
                #region 秒选项
                else if (this.DateObject.TimeMain.SecondArea.Rect.Contains(e.Location))
                {
                    int y = this.GetDisplayY(this.DateObject.TimeMain.SecondArea.verticalScroll);
                    for (int i = 0; i < this.DateObject.TimeMain.SecondArea.itemArr.Length; i++)
                    {
                        if (this.DateObject.TimeMain.SecondArea.itemArr[i].ismovedown && this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Contains(new Point(e.Location.X, e.Location.Y - y)))
                        {
                            this.OnTimeMainSecondClick(new TimeMainSecondEventArgs() { Text = this.DateObject.TimeMain.SecondArea.itemArr[i].Text, Value = this.DateObject.TimeMain.SecondArea.itemArr[i].Value });
                            break;
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region  底部工具栏
            else if (this.DateObject.BottomBar.Rect.Contains(e.Location))
            {
                #region 时钟按钮
                if (this.DateObject.BottomBar.bottombar_time_btn.ismovedown && this.DateObject.BottomBar.bottombar_time_btn.Rect.Contains(e.Location))
                {
                    this.OnBottomBarTimeClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_time_btn.Text });

                    this.Invalidate();
                }
                #endregion
                #region 清除按钮
                else if (this.DateObject.BottomBar.bottombar_clear_btn.ismovedown && this.DateObject.BottomBar.bottombar_clear_btn.Rect.Contains(e.Location))
                {
                    this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    if (this.AutoConfirm)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                }
                #endregion
                #region 现在按钮
                else if (this.DateObject.BottomBar.bottombar_now_btn.ismovedown && this.DateObject.BottomBar.bottombar_now_btn.Rect.Contains(e.Location) && this.DateObject.BottomBar.bottombar_now_btn.ItemStatus == BottomBarItemStatuss.Normal)
                {
                    this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    if (this.AutoConfirm)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                }
                #endregion
                #region 确认按钮
                else if (this.DateObject.BottomBar.bottombar_confirm_btn.ismovedown && this.DateObject.BottomBar.bottombar_confirm_btn.Rect.Contains(e.Location))
                {
                    if ((this.DateDisplayType == DateDisplayTypes.Year && this.DateObject.display_year != -1) ||
                        (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateObject.display_year != -1 && this.DateObject.display_month != -1) ||
                        (this.YearMonthDayOrTime && this.DateObject.display_year != -1 && this.DateObject.display_month != -1 && this.DateObject.display_day != -1))
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                }
                #endregion
            }
            #endregion
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            width = this.date_rect_width;
            height = this.topbar_rect_height + this.date_rect_height + this.bottombar_rect_height;
            base.SetBoundsCore(x, y, width, height, specified);
            this.InitializeRectangle();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.SolidBrushManageObject != null)
                    this.SolidBrushManageObject.ReleaseSolidBrushs();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        #region 顶部工具栏
        /// <summary>
        /// 上一年
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTopBarPrevYearClick(TopBarIiemEventArgs e)
        {
            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                this.DateObject.year -= 12;
            }
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                this.DateObject.year -= 1;
            }
            else if (this.YearMonthDayOrTime)
            {
                this.DateObject.year -= 1;
            }

            if (this.topBarPrevYearClick != null)
            {
                this.topBarPrevYearClick(this, e);
            }
        }
        /// <summary>
        /// 上一月
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTopBarPrevMonthClick(TopBarIiemEventArgs e)
        {
            if (this.YearMonthDayOrTime)
            {
                DateTime now = new DateTime(this.DateObject.year, this.DateObject.month, 1).AddMonths(-1);
                this.DateObject.year = now.Year;
                this.DateObject.month = now.Month;
            }

            if (this.topBarPrevMonthClick != null)
            {
                this.topBarPrevMonthClick(this, e);
            }
        }
        /// <summary>
        /// 显示月面板
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTopBarMonthClick(TopBarIiemEventArgs e)
        {
            if (this.YearMonthDayOrTime)
            {
                if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
                {
                    this.DateDisplayStatus = DateDisplayStatuss.Default;
                }
                else
                {
                    this.DateDisplayStatus = DateDisplayStatuss.YearMonthDay_Month;
                }
            }

            if (this.topBarMonthClick != null)
            {
                this.topBarMonthClick(this, e);
            }
        }
        /// <summary>
        /// 显示年面板
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTopBarYearClick(TopBarIiemEventArgs e)
        {
            if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                if (this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year)
                {
                    this.DateDisplayStatus = DateDisplayStatuss.Default;
                }
                else
                {
                    this.DateDisplayStatus = DateDisplayStatuss.YearMonth_Year;
                }
            }
            else if (this.YearMonthDayOrTime)
            {
                if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)
                {
                    this.DateDisplayStatus = DateDisplayStatuss.Default;
                }
                else
                {
                    this.DateDisplayStatus = DateDisplayStatuss.YearMonthDay_Year;
                }
            }

            if (this.topBarYearClick != null)
            {
                this.topBarYearClick(this, e);
            }
        }
        /// <summary>
        /// 下一月
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTopBarNextMonthClick(TopBarIiemEventArgs e)
        {
            if (this.YearMonthDayOrTime)
            {
                DateTime now = new DateTime(this.DateObject.year, this.DateObject.month, 1).AddMonths(1);
                this.DateObject.year = now.Year;
                this.DateObject.month = now.Month;
            }

            if (this.topBarNextMonthClick != null)
            {
                this.topBarNextMonthClick(this, e);
            }
        }
        /// <summary>
        /// 下一年
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTopBarNextYearClick(TopBarIiemEventArgs e)
        {
            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                this.DateObject.year += 12;
            }
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                this.DateObject.year += 1;
            }
            else if (this.YearMonthDayOrTime)
            {
                this.DateObject.year += 1;
            }

            if (this.topBarNextYearClick != null)
            {
                this.topBarNextYearClick(this, e);
            }
        }
        #endregion

        #region 日期面板
        /// <summary>
        /// 年面板年选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnYearMainItemClick(YearMainItemEventArgs e)
        {
            if (this.DateDisplayType == DateDisplayTypes.Year)//年功能年面板选中保存到display_year还没确定不保存到year
            {
                this.DateObject.display_year = e.Item.Value.Year;
                this.DateDisplayStatus = DateDisplayStatuss.Default;
            }
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year)//年功能年面板选中保存到display_year、year
            {
                this.DateObject.year = e.Item.Value.Year;
                this.DateObject.display_year = e.Item.Value.Year;
                this.DateDisplayStatus = DateDisplayStatuss.Default;
            }
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)//年功能年面板选中保存到display_year、year
            {
                this.DateObject.year = e.Item.Value.Year;
                this.DateObject.display_year = e.Item.Value.Year;
                this.DateObject.display_day = -1;
                this.DateDisplayStatus = DateDisplayStatuss.Default;
            }

            if (this.yearMainItemClick != null)
            {
                this.yearMainItemClick(this, e);
            }
        }
        /// <summary>
        /// 月面板月选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMonthMainItemClick(MonthMainItemEventArgs e)
        {
            if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                if (this.DateObject.display_year == -1)
                {
                    this.DateObject.display_year = e.Item.Value.Year;
                }
                this.DateObject.display_month = e.Item.Value.Month;
                this.DateDisplayStatus = DateDisplayStatuss.Default;
            }
            else if (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
            {
                if (this.DateObject.display_year == -1)
                {
                    this.DateObject.display_year = e.Item.Value.Year;
                }
                this.DateObject.month = e.Item.Value.Month;
                this.DateObject.display_month = e.Item.Value.Month;
                this.DateObject.day = -1;
                this.DateObject.display_day = -1;
                this.DateDisplayStatus = DateDisplayStatuss.Default;
            }

            if (this.monthMainItemClick != null)
            {
                this.monthMainItemClick(this, e);
            }
        }
        /// <summary>
        /// 日月面板日选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDayMainItemClick(DayMainItemEventArgs e)
        {
            this.DateObject.display_year = e.Item.Value.Year;
            this.DateObject.display_month = e.Item.Value.Month;
            this.DateObject.display_day = e.Item.Value.Day;

            if (this.dayMainItemClick != null)
            {
                this.dayMainItemClick(this, e);
            }
        }
        /// <summary>
        /// 时间面板时选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTimeMainHourClick(TimeMainHourEventArgs e)
        {
            this.DateObject.display_hour = e.Value;
            this.Invalidate();

            if (this.timeMainHourClick != null)
            {
                this.timeMainHourClick(this, e);
            }
        }
        /// <summary>
        ///  时间面板分选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTimeMainMinuteClick(TimeMainMinuteEventArgs e)
        {
            this.DateObject.display_minute = e.Value;
            this.Invalidate();

            if (this.timeMainMinuteClick != null)
            {
                this.timeMainMinuteClick(this, e);
            }
        }
        /// <summary>
        ///  时间面板秒选项单击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTimeMainSecondClick(TimeMainSecondEventArgs e)
        {
            this.DateObject.display_second = e.Value;
            this.Invalidate();

            if (this.timeMainSecondClick != null)
            {
                this.timeMainSecondClick(this, e);
            }
        }
        #endregion

        #region 底部工具栏
        /// <summary>
        /// 时间
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarTimeClick(BottomBarIiemEventArgs e)
        {
            if (this.YearMonthDayOrTime)
            {
                if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
                {
                    this.DateDisplayStatus = DateDisplayStatuss.Default;
                    this.DateObject.DayMain.activeIndex = 49;
                }
                else
                {
                    this.DateDisplayStatus = DateDisplayStatuss.YearMonthDay_Time;
                    this.DateObject.DayMain.activeIndex = 0;
                }
            }

            if (this.bottomBarTimeClick != null)
            {
                this.bottomBarTimeClick(this, e);
            }
        }
        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarClearClick(BottomBarIiemEventArgs e)
        {
            DateTime now = DateTime.Now;
            this.DateObject.year = now.Year;
            this.DateObject.display_year = -1;
            this.DateObject.month = now.Month;
            this.DateObject.display_month = -1;
            this.DateObject.day = now.Day;
            this.DateObject.display_day = -1;
            this.DateObject.hour = 0;
            this.DateObject.display_hour = 0;
            this.DateObject.minute = 0;
            this.DateObject.display_minute = 0;
            this.DateObject.second = 0;
            this.DateObject.display_second = 0;
            this.dateValue = null;
            this.Invalidate();

            if (this.bottomBarClearClick != null)
            {
                this.bottomBarClearClick(this, e);
            }
        }
        /// <summary>
        /// 现在
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarNowClick(BottomBarIiemEventArgs e)
        {
            DateTime now = DateTime.Now;

            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                this.DateObject.year = now.Year;
                this.DateObject.display_year = now.Year;
            }
            if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                this.DateObject.year = now.Year;
                this.DateObject.display_year = now.Year;
                this.DateObject.month = now.Month;
                this.DateObject.display_month = now.Month;
            }
            if (this.YearMonthDayOrTime)
            {
                this.DateObject.year = now.Year;
                this.DateObject.display_year = now.Year;
                this.DateObject.month = now.Month;
                this.DateObject.display_month = now.Month;
                this.DateObject.day = now.Day;
                this.DateObject.display_day = now.Day;

                if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour)
                {
                    this.DateObject.hour = now.Hour;
                    this.DateObject.display_hour = now.Hour;
                }
                else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute)
                {
                    this.DateObject.hour = now.Hour;
                    this.DateObject.display_hour = now.Hour;
                    this.DateObject.minute = now.Minute;
                    this.DateObject.display_minute = now.Minute;
                }
                else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
                {
                    this.DateObject.hour = now.Hour;
                    this.DateObject.display_hour = now.Hour;
                    this.DateObject.minute = now.Minute;
                    this.DateObject.display_minute = now.Minute;
                    this.DateObject.second = now.Second;
                    this.DateObject.display_second = now.Second;
                }
            }

            if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
            {
                this.DateDisplayStatus = DateDisplayStatuss.Default;
            }

            this.UpdateRectangleText();
            this.Invalidate();

            if (this.bottomBarNowClick != null)
            {
                this.bottomBarNowClick(this, e);
            }
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBottomBarConfirmClick(BottomBarIiemEventArgs e)
        {
            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                this.DateObject.year = this.DateObject.display_year;
                this.DateValue = new DateTime(this.DateObject.year, 1, 1).Date;
            }
            if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                this.DateObject.year = this.DateObject.display_year;
                this.DateObject.month = this.DateObject.display_month;
                this.DateValue = new DateTime(this.DateObject.year, this.DateObject.month, 1).Date;
            }
            if (this.YearMonthDayOrTime)
            {
                this.DateObject.year = this.DateObject.display_year;
                this.DateObject.month = this.DateObject.display_month;
                this.DateObject.day = this.DateObject.display_day;
                if (this.DateDisplayType == DateDisplayTypes.YearMonthDay)
                {
                    this.DateValue = new DateTime(this.DateObject.year, this.DateObject.month, this.DateObject.day).Date;
                }
                else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour)
                {
                    this.DateObject.hour = this.DateObject.display_hour;
                    this.DateValue = new DateTime(this.DateObject.year, this.DateObject.month, this.DateObject.day, this.DateObject.hour, 0, 0);
                }
                else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute)
                {
                    this.DateObject.hour = this.DateObject.display_hour;
                    this.DateObject.minute = this.DateObject.display_minute;
                    this.DateValue = new DateTime(this.DateObject.year, this.DateObject.month, this.DateObject.day, this.DateObject.hour, this.DateObject.minute, 0);
                }
                else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
                {
                    this.DateObject.hour = this.DateObject.display_hour;
                    this.DateObject.minute = this.DateObject.display_minute;
                    this.DateObject.second = this.DateObject.display_second;
                    this.DateValue = new DateTime(this.DateObject.year, this.DateObject.month, this.DateObject.day, this.DateObject.hour, this.DateObject.minute, this.DateObject.second);
                }
            }

            if (this.bottomBarConfirmClick != null)
            {
                this.bottomBarConfirmClick(this, e);
            }
        }
        #endregion

        /// <summary>
        /// 日期值更改
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDateValueChanged(DateValueChangedEventArgs e)
        {
            if (this.dateValueChanged != null)
            {
                this.dateValueChanged(this, e);
            }
        }

        /// <summary>
        /// 显示功能类型更改
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDateDisplayTypeChanged(DateDisplayTypeChangedEventArgs e)
        {
            if (this.dateDisplayTypeChanged != null)
            {
                this.dateDisplayTypeChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 设置默认激活索引
        /// </summary>
        public void SetActive()
        {
            this.Select();
            this.Focus();
            this.activatedState = true;
            switch (this.DateDisplayType)
            {
                case DateDisplayTypes.Year:
                    {
                        this.DateObject.YearMain.activeIndex = 0;
                        break;
                    }
                case DateDisplayTypes.YearMonth:
                    {
                        if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                        {
                            this.DateObject.MonthMain.activeIndex = 0;
                        }
                        else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year)
                        {
                            this.DateObject.YearMain.activeIndex = 0;
                        }

                        break;
                    }
                case DateDisplayTypes.YearMonthDay:
                case DateDisplayTypes.YearMonthDayHour:
                case DateDisplayTypes.YearMonthDayHourMinute:
                case DateDisplayTypes.YearMonthDayHourMinuteSecond:
                    {
                        if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                        {
                            this.DateObject.DayMain.activeIndex = 7;
                        }
                        else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
                        {
                            this.DateObject.MonthMain.activeIndex = 0;
                        }
                        else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)
                        {
                            this.DateObject.YearMain.activeIndex = 0;
                        }
                        break;
                    }
            }

            if (dateValue.HasValue)
            {
                this.DateObject.year = dateValue.Value.Year;
                this.DateObject.display_year = dateValue.Value.Year;
                this.DateObject.month = dateValue.Value.Month;
                this.DateObject.display_month = dateValue.Value.Month;
                this.DateObject.day = dateValue.Value.Day;
                this.DateObject.display_day = dateValue.Value.Day;
                this.DateObject.hour = dateValue.Value.Hour;
                this.DateObject.display_hour = dateValue.Value.Hour;
                this.DateObject.minute = dateValue.Value.Minute;
                this.DateObject.display_minute = dateValue.Value.Minute;
                this.DateObject.second = dateValue.Value.Second;
                this.DateObject.display_second = dateValue.Value.Second;
            }
            else
            {
                DateTime now = DateTime.Now;
                this.DateObject.year = now.Year;
                this.DateObject.display_year = -1;
                this.DateObject.month = now.Month;
                this.DateObject.display_month = -1;
                this.DateObject.day = now.Day;
                this.DateObject.display_day = -1;
                this.DateObject.hour = 0;
                this.DateObject.display_hour = 0;
                this.DateObject.minute = 0;
                this.DateObject.display_minute = 0;
                this.DateObject.second = 0;
                this.DateObject.display_second = 0;
            }
            this.UpdateRectangleText();
            this.DateDisplayStatus = DateDisplayStatuss.Default;
            this.Invalidate();
        }

        /// <summary>
        /// 清除已选择但没有确认的值
        /// </summary>
        public void ClearSelectDate()
        {
            this.DateObject.display_year = -1;
            this.DateObject.display_month = -1;
            this.DateObject.display_day = -1;
            this.DateObject.display_hour = 0;
            this.DateObject.display_minute = 0;
            this.DateObject.display_second = 0;
        }

        /// <summary>
        /// 获取日期格式
        /// </summary>
        /// <returns></returns>
        public string GetDateFormat()
        {
            string date_format = String.Empty;
            switch (this.DateDisplayType)
            {
                case DatePickerExt.DateDisplayTypes.Year:
                    {
                        date_format = "yyyy";
                        break;
                    }
                case DatePickerExt.DateDisplayTypes.YearMonth:
                    {
                        date_format = "yyyy-MM";
                        break;
                    }
                case DatePickerExt.DateDisplayTypes.YearMonthDay:
                    {
                        date_format = "yyyy-MM-dd";
                        break;
                    }
                case DatePickerExt.DateDisplayTypes.YearMonthDayHour:
                    {
                        date_format = "yyyy-MM-dd HH:mm:ss";
                        break;
                    }
                case DatePickerExt.DateDisplayTypes.YearMonthDayHourMinute:
                    {
                        date_format = "yyyy-MM-dd HH:mm:ss";
                        break;
                    }
                case DatePickerExt.DateDisplayTypes.YearMonthDayHourMinuteSecond:
                    {
                        date_format = "yyyy-MM-dd HH:mm:ss";
                        break;
                    }
            }

            return date_format;
        }

        /// <summary>
        /// 更新日期面板的日期但不刷新日期面板界面（触发DateValueChanged事件）
        /// </summary>
        /// <param name="date"></param>
        public void UpdateDateValueNotInvalidate(DateTime? date)
        {
            if (this.dateValue == date)
                return;

            if (date.HasValue && this.MinMaxInput)
            {
                if (date.Value.Date < this.MinValue)
                    date = this.MinValue;
                if (date.Value.Date > this.MaxValue)
                    date = this.MaxValue;
            }

            if (this.dateValue == date)
                return;

            DateValueChangedEventArgs arg = new DateValueChangedEventArgs() { OldDateValue = this.dateValue, NewDateValue = date };
            this.dateValue = date;

            this.OnDateValueChanged(arg);
        }

        /// <summary>
        /// 初始化日期面板的日期但不刷新日期面板界面
        /// </summary>
        /// <param name="date"></param>
        public void InitializeDatePickerDateValue(DateTime? date)
        {
            if (this.dateValue == date)
                return;

            this.dateValue = date;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeRectangle()
        {
            this.DateObject.TopBar.Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.date_rect_width, this.topbar_rect_height);
            this.DateObject.YearMain.Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + this.topbar_rect_height, this.date_rect_width, this.date_rect_height);
            this.DateObject.MonthMain.Rect = this.DateObject.YearMain.Rect;
            this.DateObject.DayMain.Rect = this.DateObject.YearMain.Rect;
            this.DateObject.TimeMain.TopBarRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.time_topbar_rect_height);
            this.DateObject.TimeMain.Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + this.time_topbar_rect_height, this.date_rect_width, this.ClientRectangle.Height - this.time_topbar_rect_height - this.bottombar_rect_height);
            this.DateObject.BottomBar.Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Bottom - this.bottombar_rect_height, this.ClientRectangle.Width, this.bottombar_rect_height);

            #region 顶部工具栏
            int topbar_btn_rectf_width = 24;
            float topbar_avg_w = topbar_btn_rectf_width / 3f;
            float topbar_avg_h = this.DateObject.TopBar.Rect.Height / 6f;

            #region 上一年
            this.DateObject.TopBar.prev_year_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.X, this.DateObject.TopBar.Rect.Y, topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Height);
            this.DateObject.TopBar.prev_year_btn.LineLeftPointArr = new Point[3];
            this.DateObject.TopBar.prev_year_btn.LineLeftPointArr[0] = new Point((int)(this.DateObject.TopBar.prev_year_btn.Rect.X + topbar_avg_w * 2 - 3), (int)(this.DateObject.TopBar.prev_year_btn.Rect.Y + topbar_avg_h * 2));
            this.DateObject.TopBar.prev_year_btn.LineLeftPointArr[1] = new Point((int)(this.DateObject.TopBar.prev_year_btn.Rect.X + topbar_avg_w), (int)(this.DateObject.TopBar.prev_year_btn.Rect.Y + topbar_avg_h * 3));
            this.DateObject.TopBar.prev_year_btn.LineLeftPointArr[2] = new Point((int)(this.DateObject.TopBar.prev_year_btn.Rect.X + topbar_avg_w * 2 - 3), (int)(this.DateObject.TopBar.prev_year_btn.Rect.Y + topbar_avg_h * 4));

            this.DateObject.TopBar.prev_year_btn.LineRightPointArr = new Point[3];
            this.DateObject.TopBar.prev_year_btn.LineRightPointArr[0] = new Point((int)(this.DateObject.TopBar.prev_year_btn.Rect.X + topbar_avg_w * 2), (int)(this.DateObject.TopBar.prev_year_btn.Rect.Y + topbar_avg_h * 2));
            this.DateObject.TopBar.prev_year_btn.LineRightPointArr[1] = new Point((int)(this.DateObject.TopBar.prev_year_btn.Rect.X + topbar_avg_w + 3), (int)(this.DateObject.TopBar.prev_year_btn.Rect.Y + topbar_avg_h * 3));
            this.DateObject.TopBar.prev_year_btn.LineRightPointArr[2] = new Point((int)(this.DateObject.TopBar.prev_year_btn.Rect.X + topbar_avg_w * 2), (int)(this.DateObject.TopBar.prev_year_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            #region 上一月
            this.DateObject.TopBar.prev_month_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.X + topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Y, topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Height);

            this.DateObject.TopBar.prev_month_btn.LineLeftPointArr = new Point[3];
            this.DateObject.TopBar.prev_month_btn.LineLeftPointArr[0] = new Point((int)(this.DateObject.TopBar.prev_month_btn.Rect.X + topbar_avg_w * 2 - 3), (int)(this.DateObject.TopBar.prev_month_btn.Rect.Y + topbar_avg_h * 2));
            this.DateObject.TopBar.prev_month_btn.LineLeftPointArr[1] = new Point((int)(this.DateObject.TopBar.prev_month_btn.Rect.X + topbar_avg_w), (int)(this.DateObject.TopBar.prev_month_btn.Rect.Y + topbar_avg_h * 3));
            this.DateObject.TopBar.prev_month_btn.LineLeftPointArr[2] = new Point((int)(this.DateObject.TopBar.prev_month_btn.Rect.X + topbar_avg_w * 2 - 3), (int)(this.DateObject.TopBar.prev_month_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            this.DateObject.TopBar.yearscope_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.X + (this.DateObject.TopBar.Rect.Width - 120) / 2, this.DateObject.TopBar.Rect.Y, 120, this.DateObject.TopBar.Rect.Height);
            this.DateObject.TopBar.monthyear_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.X + (this.DateObject.TopBar.Rect.Width - 60) / 2, this.DateObject.TopBar.Rect.Y, 60, this.DateObject.TopBar.Rect.Height);
            this.DateObject.TopBar.month_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.X + (this.DateObject.TopBar.Rect.Width - (37 + 60)) / 2, this.DateObject.TopBar.Rect.Y, 37, this.DateObject.TopBar.Rect.Height);
            this.DateObject.TopBar.year_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.X + (this.DateObject.TopBar.Rect.Width - (37 + 60)) / 2 + 37, this.DateObject.TopBar.Rect.Y, 60, this.DateObject.TopBar.Rect.Height);
            #region 下一月
            this.DateObject.TopBar.next_month_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.Right - topbar_btn_rectf_width - topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Y, topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Height);

            this.DateObject.TopBar.next_month_btn.LineRightPointArr = new Point[3];
            this.DateObject.TopBar.next_month_btn.LineRightPointArr[0] = new Point((int)(this.DateObject.TopBar.next_month_btn.Rect.Right - topbar_avg_w * 2 + 3), (int)(this.DateObject.TopBar.next_month_btn.Rect.Y + topbar_avg_h * 2));
            this.DateObject.TopBar.next_month_btn.LineRightPointArr[1] = new Point((int)(this.DateObject.TopBar.next_month_btn.Rect.Right - topbar_avg_w), (int)(this.DateObject.TopBar.next_month_btn.Rect.Y + topbar_avg_h * 3));
            this.DateObject.TopBar.next_month_btn.LineRightPointArr[2] = new Point((int)(this.DateObject.TopBar.next_month_btn.Rect.Right - topbar_avg_w * 2 + 3), (int)(this.DateObject.TopBar.next_month_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            #region 下一年
            this.DateObject.TopBar.next_year_btn.Rect = new Rectangle(this.DateObject.TopBar.Rect.Right - topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Y, topbar_btn_rectf_width, this.DateObject.TopBar.Rect.Height);

            this.DateObject.TopBar.next_year_btn.LineLeftPointArr = new Point[3];
            this.DateObject.TopBar.next_year_btn.LineLeftPointArr[0] = new Point((int)(this.DateObject.TopBar.next_year_btn.Rect.Right - topbar_avg_w * 2 + 3), (int)(this.DateObject.TopBar.next_year_btn.Rect.Y + topbar_avg_h * 2));
            this.DateObject.TopBar.next_year_btn.LineLeftPointArr[1] = new Point((int)(this.DateObject.TopBar.next_year_btn.Rect.Right - topbar_avg_w), (int)(this.DateObject.TopBar.next_year_btn.Rect.Y + topbar_avg_h * 3));
            this.DateObject.TopBar.next_year_btn.LineLeftPointArr[2] = new Point((int)(this.DateObject.TopBar.next_year_btn.Rect.Right - topbar_avg_w * 2 + 3), (int)(this.DateObject.TopBar.next_year_btn.Rect.Y + topbar_avg_h * 4));

            this.DateObject.TopBar.next_year_btn.LineRightPointArr = new Point[3];
            this.DateObject.TopBar.next_year_btn.LineRightPointArr[0] = new Point((int)(this.DateObject.TopBar.next_year_btn.Rect.Right - topbar_avg_w * 2), (int)(this.DateObject.TopBar.next_year_btn.Rect.Y + topbar_avg_h * 2));
            this.DateObject.TopBar.next_year_btn.LineRightPointArr[1] = new Point((int)(this.DateObject.TopBar.next_year_btn.Rect.Right - topbar_avg_w - 3), (int)(this.DateObject.TopBar.next_year_btn.Rect.Y + topbar_avg_h * 3));
            this.DateObject.TopBar.next_year_btn.LineRightPointArr[2] = new Point((int)(this.DateObject.TopBar.next_year_btn.Rect.Right - topbar_avg_w * 2), (int)(this.DateObject.TopBar.next_year_btn.Rect.Y + topbar_avg_h * 4));
            #endregion
            #endregion
            #region 年面板
            int year_col = 3;
            int year_row = 4;
            float year_space_width = (this.date_rect_width - this.year_rectf_item_width * year_col) / (float)(year_col + 1);
            float year_space_height = (this.date_rect_height - this.year_rectf_item_height * year_row) / (float)(year_row + 1);
            for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
            {
                float x = this.DateObject.YearMain.Rect.X + year_space_width + (i % year_col) * (this.year_rectf_item_width + year_space_width);
                float y = this.DateObject.YearMain.Rect.Y + year_space_height + (i / year_col) * (this.year_rectf_item_height + year_space_height);
                this.DateObject.YearMain.itemArr[i].Rect = new Rectangle((int)x, (int)y, this.year_rectf_item_width, this.year_rectf_item_height);
            }
            #endregion
            #region 月面板
            int month_col = 3;
            int month_row = 4;
            float month_space_width = (this.date_rect_width - this.month_rectf_item_width * month_col) / (float)(month_col + 1);
            float month_space_height = (this.date_rect_height - this.month_rectf_item_height * month_row) / (float)(month_row + 1);
            for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
            {
                float x = this.DateObject.MonthMain.Rect.X + month_space_width + (i % month_col) * (this.month_rectf_item_width + month_space_width);
                float y = this.DateObject.MonthMain.Rect.Y + month_space_height + (i / month_col) * (this.month_rectf_item_height + month_space_height);
                this.DateObject.MonthMain.itemArr[i].Rect = new Rectangle((int)x, (int)y, this.month_rectf_item_width, this.month_rectf_item_height);
            }
            #endregion
            #region 日面板
            int days = DateTime.DaysInMonth(this.DateObject.year, this.DateObject.month);//指定月份的总天数
            DateTime first_day = new DateTime(this.DateObject.year, this.DateObject.month, 1);//指定年月的第一天
            int week_day = (int)(first_day.DayOfWeek);//指定日期为星期几
            if (week_day == 0)
                week_day = 7;

            int day_col = 7;
            int day_row = 7;

            float day_space_width = 1;
            float day_space_height = 1;
            float day_space_left = (this.date_rect_width - this.day_rectf_item_width * day_col - day_space_width * (day_col - 1)) / 2f;
            float day_space_top = (this.date_rect_height - this.day_rectf_item_height * day_row - day_space_height * (day_row - 1)) / 2f;

            for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
            {
                float x = this.DateObject.DayMain.Rect.X + day_space_left + (i % day_col) * (this.day_rectf_item_width + day_space_width);
                float y = this.DateObject.DayMain.Rect.Y + day_space_top + (i / day_col) * (this.day_rectf_item_height + day_space_height);
                this.DateObject.DayMain.itemArr[i].Rect = new Rectangle((int)x, (int)y, this.day_rectf_item_width, this.day_rectf_item_height);

                if (i < day_col)//绘制标题
                {
                    this.DateObject.DayMain.itemArr[i].DateItemType = DateItemTypes.Title;
                    this.DateObject.DayMain.itemArr[i].Value = DateTime.MinValue;
                    this.DateObject.DayMain.itemArr[i].Text = this.days_titles[i];
                }
                else if (i - 7 < week_day)//绘制指定月份上一个月的日期
                {
                    int day = -(week_day - (i - 7));
                    this.DateObject.DayMain.itemArr[i].DateItemType = DateItemTypes.Past;
                    this.DateObject.DayMain.itemArr[i].Value = first_day.AddDays(day);
                    this.DateObject.DayMain.itemArr[i].Text = this.DateObject.DayMain.itemArr[i].Value.Day.ToString();
                }
                else if (i - 7 - week_day < days)//绘制指定月份的日期
                {
                    int day = i - 7 - week_day;
                    this.DateObject.DayMain.itemArr[i].DateItemType = DateItemTypes.Normal;
                    this.DateObject.DayMain.itemArr[i].Value = first_day.AddDays(day);
                    this.DateObject.DayMain.itemArr[i].Text = this.DateObject.DayMain.itemArr[i].Value.Day.ToString();
                }
                else//绘制指定月份下一个月的日期
                {
                    int day = i - 7 - week_day;
                    this.DateObject.DayMain.itemArr[i].DateItemType = DateItemTypes.Future;
                    this.DateObject.DayMain.itemArr[i].Value = first_day.AddDays(day);
                    this.DateObject.DayMain.itemArr[i].Text = this.DateObject.DayMain.itemArr[i].Value.Day.ToString();
                }
            }

            #endregion
            #region 时间面板
            this.InitializeTimeRectangle();
            #endregion
            #region 底部工具栏
            int bottombar_btn_rectf_width = 35;
            int bottombar_btn_rectf_height = 28;
            int bottombar_space_width = 2;
            int bottombar_space_right = 5;
            int bottombar_time_width = 26;
            int bottombar_btn_y = this.DateObject.BottomBar.Rect.Y + (this.DateObject.BottomBar.Rect.Height - bottombar_btn_rectf_height) / 2;

            int bottombar_tip_border_width = 5;
            this.DateObject.BottomBar.bottombar_minmaxborder_lab.LinePointArr = new Point[4];
            this.DateObject.BottomBar.bottombar_minmaxborder_lab.LinePointArr[0] = new Point(this.DateObject.BottomBar.Rect.X + 5 + bottombar_tip_border_width, this.DateObject.BottomBar.Rect.Y + 10);
            this.DateObject.BottomBar.bottombar_minmaxborder_lab.LinePointArr[1] = new Point(this.DateObject.BottomBar.Rect.X + 5, this.DateObject.BottomBar.Rect.Y + 10);
            this.DateObject.BottomBar.bottombar_minmaxborder_lab.LinePointArr[2] = new Point(this.DateObject.BottomBar.Rect.X + 5, this.DateObject.BottomBar.Rect.Bottom - 10);
            this.DateObject.BottomBar.bottombar_minmaxborder_lab.LinePointArr[3] = new Point(this.DateObject.BottomBar.Rect.X + 5 + bottombar_tip_border_width, this.DateObject.BottomBar.Rect.Bottom - 10);

            this.DateObject.BottomBar.bottombar_mindate_lab.Rect = new Rectangle(this.DateObject.BottomBar.Rect.X + 5 + bottombar_tip_border_width, this.DateObject.BottomBar.Rect.Y + 2, 0, 0);
            this.DateObject.BottomBar.bottombar_maxdate_lab.Rect = new Rectangle(this.DateObject.BottomBar.Rect.X + 5 + bottombar_tip_border_width, this.DateObject.BottomBar.Rect.Bottom - 18, 0, 0);

            this.DateObject.BottomBar.bottombar_confirm_btn.Rect = new Rectangle(this.DateObject.BottomBar.Rect.Right - bottombar_space_right - bottombar_btn_rectf_width, bottombar_btn_y, bottombar_btn_rectf_width, bottombar_btn_rectf_height);
            this.DateObject.BottomBar.bottombar_now_btn.Rect = new Rectangle(this.DateObject.BottomBar.bottombar_confirm_btn.Rect.X - bottombar_space_width - bottombar_btn_rectf_width, bottombar_btn_y, bottombar_btn_rectf_width, bottombar_btn_rectf_height);
            this.DateObject.BottomBar.bottombar_clear_btn.Rect = new Rectangle(this.DateObject.BottomBar.bottombar_now_btn.Rect.X - bottombar_space_width - bottombar_btn_rectf_width, bottombar_btn_y, bottombar_btn_rectf_width, bottombar_btn_rectf_height);
            this.DateObject.BottomBar.bottombar_time_btn.Rect = new Rectangle(this.DateObject.BottomBar.bottombar_clear_btn.Rect.X - bottombar_space_width - bottombar_time_width, bottombar_btn_y + (bottombar_btn_rectf_height - bottombar_time_width) / 2, bottombar_time_width, bottombar_time_width);

            #endregion


        }

        /// <summary>
        /// 初始化时间布局
        /// </summary>
        private void InitializeTimeRectangle()
        {

            #region 选项信息
            int item_w = 0;
            int item_y = this.DateObject.TimeMain.Rect.Y;
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour)
            {
                item_w = this.DateObject.TimeMain.Rect.Width - this.timeScrollThickness;
            }
            else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute)
            {
                item_w = (int)(((float)this.DateObject.TimeMain.Rect.Width - this.timeScrollThickness * 2) / 2f);
            }
            else if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                item_w = (int)(((float)this.DateObject.TimeMain.Rect.Width - this.timeScrollThickness * 3) / 3f);
            }
            #endregion

            #region 时分秒区域
            this.DateObject.TimeMain.HourArea.Rect = new RectangleF(this.DateObject.TimeMain.Rect.X, this.DateObject.TimeMain.Rect.Y, item_w, this.DateObject.TimeMain.Rect.Height);
            this.DateObject.TimeMain.MinuteArea.Rect = new RectangleF(this.DateObject.TimeMain.Rect.X + item_w + this.timeScrollThickness, this.DateObject.TimeMain.Rect.Y, item_w, this.DateObject.TimeMain.Rect.Height);
            this.DateObject.TimeMain.SecondArea.Rect = new RectangleF(this.DateObject.TimeMain.Rect.X + item_w * 2f + this.timeScrollThickness * 2, this.DateObject.TimeMain.Rect.Y, item_w, this.DateObject.TimeMain.Rect.Height);
            #endregion

            #region 时分秒选项
            for (int i = 0; i < this.DateObject.TimeMain.HourArea.itemArr.Length; i++)
            {
                this.DateObject.TimeMain.HourArea.itemArr[i].Rect = new Rectangle((int)this.DateObject.TimeMain.HourArea.Rect.X, item_y, item_w, this.time_item_height);
                item_y += this.time_item_height;
            }
            item_y = this.DateObject.TimeMain.Rect.Y;
            for (int i = 0; i < this.DateObject.TimeMain.MinuteArea.itemArr.Length; i++)
            {
                this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect = new Rectangle((int)this.DateObject.TimeMain.MinuteArea.Rect.X, item_y, item_w, this.time_item_height);
                item_y += this.time_item_height;
            }
            item_y = this.DateObject.TimeMain.Rect.Y;
            for (int i = 0; i < this.DateObject.TimeMain.SecondArea.itemArr.Length; i++)
            {
                this.DateObject.TimeMain.SecondArea.itemArr[i].Rect = new Rectangle((int)this.DateObject.TimeMain.SecondArea.Rect.X, item_y, item_w, this.time_item_height);
                item_y += this.time_item_height;
            }
            #endregion

            #region 时分秒滚动条
            this.InitializeTimeScrollRectangle(this.DateObject.TimeMain.HourArea.verticalScroll, this.DateObject.TimeMain.HourArea.Rect, this.DateObject.TimeMain.HourArea.itemArr.Length, this.time_item_height);
            this.InitializeTimeScrollRectangle(this.DateObject.TimeMain.MinuteArea.verticalScroll, this.DateObject.TimeMain.MinuteArea.Rect, this.DateObject.TimeMain.MinuteArea.itemArr.Length, this.time_item_height);
            this.InitializeTimeScrollRectangle(this.DateObject.TimeMain.SecondArea.verticalScroll, this.DateObject.TimeMain.SecondArea.Rect, this.DateObject.TimeMain.SecondArea.itemArr.Length, this.time_item_height);
            #endregion
        }

        /// <summary>
        /// 初始化时间滚动条布局
        /// </summary>
        /// <param name="scroll_obj"></param>
        /// <param name="display_rect"></param>
        /// <param name="item_count"></param>
        /// <param name="item_height"></param>
        private void InitializeTimeScrollRectangle(VerticalScroll scroll_obj, RectangleF display_rect, int item_count, int item_height)
        {
            scroll_obj.DisplayRect = new RectangleF(display_rect.X, display_rect.Y, display_rect.Width, display_rect.Height);
            scroll_obj.ContentRect = new RectangleF(display_rect.X, display_rect.Y, display_rect.Width, item_count * item_height);

            scroll_obj.ScrollBack.Rect = new RectangleF(display_rect.Right, display_rect.Y, this.timeScrollThickness, display_rect.Height);
            float slide_h = scroll_obj.DisplayRect.Height * scroll_obj.ScrollBack.Rect.Height / scroll_obj.ContentRect.Height;
            if (scroll_obj.ContentRect.Height <= scroll_obj.DisplayRect.Height)
            {
                slide_h = scroll_obj.ScrollBack.Rect.Height;
            }
            scroll_obj.ScrollSlide.Rect = new RectangleF(scroll_obj.ScrollBack.Rect.X, scroll_obj.ScrollBack.Rect.Y, this.timeScrollThickness, slide_h);
        }

        /// <summary>
        /// 把时间值加载到控件上
        /// </summary>
        /// <param name="date"></param>
        private void LoadDateForControl(DateTime? date)
        {
            if (date.HasValue)
            {
                this.DateObject.year = date.Value.Year;
                this.DateObject.display_year = date.Value.Year;
                this.DateObject.month = date.Value.Month;
                this.DateObject.display_month = date.Value.Month;
                this.DateObject.day = date.Value.Day;
                this.DateObject.display_day = date.Value.Day;
            }
            else
            {
                DateTime now = DateTime.Now;
                if (this.MinMaxInput)
                {
                    if (now.Date < this.MinValue)
                        now = this.MinValue;
                    if (now.Date > this.MaxValue)
                        now = this.MaxValue;
                }

                this.DateObject.year = now.Year;
                this.DateObject.display_year = -1;
                this.DateObject.month = now.Month;
                this.DateObject.display_month = -1;
                this.DateObject.day = now.Day;
                this.DateObject.display_day = -1;
            }
        }

        /// <summary>
        /// 更新顶部画面信息
        /// </summary>
        private void UpdateTopRectangleText()
        {
            int start_year = GetStartYaer(this.DateObject.year);
            #region 顶部工具栏
            this.DateObject.TopBar.yearscope_btn.Text = String.Format("{0}年~{1}年", start_year.ToString().PadLeft(4, '0'), (start_year + 11).ToString().PadLeft(4, '0'));
            this.DateObject.TopBar.monthyear_btn.Text = this.DateObject.year + "年";
            this.DateObject.TopBar.month_btn.Text = String.Format("{0}月", this.DateObject.month.ToString().PadLeft(2, '0'));

            this.DateObject.TopBar.year_btn.Text = String.Format("{0}年", this.DateObject.year.ToString().PadLeft(4, '0'));
            #endregion
        }

        /// <summary>
        /// 更新年月日画面信息
        /// </summary>
        private void UpdateYearMonthDayRectangleText()
        {
            int start_year = GetStartYaer(this.DateObject.year);
            #region 年面板
            if (this.DateDisplayType == DateDisplayTypes.Year ||
                (this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year) ||
               (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year))
            {
                for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
                {
                    DateTime now = new DateTime(start_year + i, 1, 1).Date;
                    this.DateObject.YearMain.itemArr[i].Value = now;
                    this.DateObject.YearMain.itemArr[i].Text = String.Format("{0}年", now.ToString("yyyy"));
                    this.DateObject.YearMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                    this.DateObject.YearMain.itemArr[i].DateItemType = (now.Year < this.MinValue.Year || now.Year > this.MaxValue.Year) ? DateItemTypes.Disabled : DateItemTypes.Normal;
                }
            }
            #endregion
            #region 月面板
            if ((this.DateDisplayType == DateDisplayTypes.YearMonth && this.DateDisplayStatus == DateDisplayStatuss.Default) ||
            (this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month))
            {
                DateTime month_min = new DateTime(this.MinValue.Year, MinValue.Month, 1).Date;
                DateTime month_max = new DateTime(this.MaxValue.Year, MaxValue.Month, 1).Date;
                for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
                {
                    DateTime now = new DateTime(this.DateObject.year, i + 1, 1).Date;
                    this.DateObject.MonthMain.itemArr[i].Value = now;
                    this.DateObject.MonthMain.itemArr[i].Text = String.Format("{0}月", now.ToString("MM"));
                    this.DateObject.MonthMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                    this.DateObject.MonthMain.itemArr[i].DateItemType = (now < month_min || now > month_max) ? DateItemTypes.Disabled : DateItemTypes.Normal;
                }
            }
            #endregion
            #region 日面板
            if ((this.YearMonthDayOrTime && this.DateDisplayStatus == DateDisplayStatuss.Default))
            {
                int days = DateTime.DaysInMonth(this.DateObject.year, this.DateObject.month);//指定月份的总天数
                DateTime first_day = new DateTime(this.DateObject.year, this.DateObject.month, 1).Date;//指定年月的第一天
                int week_day = (int)(first_day.DayOfWeek);//指定日期为星期几
                if (week_day == 0)
                    week_day = 7;

                DateTime year_min = this.MinValue.Date;
                DateTime year_max = this.MaxValue.Date;
                for (int i = 0; i < this.DateObject.DayMain.itemArr.Length; i++)
                {
                    if (i < 7)//绘制标题
                    {
                        this.DateObject.DayMain.itemArr[i].Value = DateTime.MinValue.Date;
                        this.DateObject.DayMain.itemArr[i].Text = this.days_titles[i];
                        this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        this.DateObject.DayMain.itemArr[i].DateItemType = DateItemTypes.Title;
                    }
                    else if (i - 7 < week_day)//绘制指定月份上一个月的日期
                    {
                        int day = -(week_day - (i - 7));
                        DateTime now = first_day.AddDays(day);
                        this.DateObject.DayMain.itemArr[i].Value = now;
                        this.DateObject.DayMain.itemArr[i].Text = now.Day.ToString();
                        this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        this.DateObject.DayMain.itemArr[i].DateItemType = (now < year_min || now > year_max) ? DateItemTypes.Disabled : DateItemTypes.Past;
                    }
                    else if (i - 7 - week_day < days)//绘制指定月份的日期
                    {
                        int day = i - 7 - week_day;
                        DateTime now = first_day.AddDays(day).Date;
                        this.DateObject.DayMain.itemArr[i].Value = now;
                        this.DateObject.DayMain.itemArr[i].Text = now.Day.ToString();
                        this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        this.DateObject.DayMain.itemArr[i].DateItemType = (now < year_min || now > year_max) ? DateItemTypes.Disabled : DateItemTypes.Normal;
                    }
                    else//绘制指定月份下一个月的日期
                    {
                        int day = i - 7 - week_day;
                        DateTime now = first_day.AddDays(day).Date;
                        this.DateObject.DayMain.itemArr[i].Value = now;
                        this.DateObject.DayMain.itemArr[i].Text = now.Day.ToString();
                        this.DateObject.DayMain.itemArr[i].MoveStatus = MoveStatuss.Normal;
                        this.DateObject.DayMain.itemArr[i].DateItemType = (now < year_min || now > year_max) ? DateItemTypes.Disabled : DateItemTypes.Future;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 更新底部画面信息
        /// </summary>
        private void UpdateBottomRectangleText()
        {
            #region 底部工具栏
            string strformat = "";
            if (this.DateDisplayType == DateDisplayTypes.Year)
                strformat = "yyyy";
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
                strformat = "yyyy-MM";
            else if (this.YearMonthDayOrTime)
                strformat = "yyyy-MM-dd";

            this.DateObject.BottomBar.bottombar_mindate_lab.Text = this.MinValue.ToString(strformat);
            this.DateObject.BottomBar.bottombar_maxdate_lab.Text = this.MaxValue.ToString(strformat);

            this.DateObject.BottomBar.bottombar_confirm_btn.MoveStatus = MoveStatuss.Normal;
            this.DateObject.BottomBar.bottombar_confirm_btn.ItemStatus = this.dateReadOnly ? BottomBarItemStatuss.Disabled : BottomBarItemStatuss.Normal;

            this.DateObject.BottomBar.bottombar_now_btn.MoveStatus = MoveStatuss.Normal;
            this.DateObject.BottomBar.bottombar_now_btn.ItemStatus = (this.dateReadOnly || (DateTime.Now.Date < this.MinValue || DateTime.Now.Date > this.MaxValue)) ? BottomBarItemStatuss.Disabled : BottomBarItemStatuss.Normal;

            this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus = MoveStatuss.Normal;
            this.DateObject.BottomBar.bottombar_clear_btn.ItemStatus = this.dateReadOnly ? BottomBarItemStatuss.Disabled : BottomBarItemStatuss.Normal;
            #endregion
        }

        /// <summary>
        /// 更新所有画面信息
        /// </summary>
        private void UpdateRectangleText()
        {
            #region 顶部工具栏
            this.UpdateTopRectangleText();
            #endregion
            #region 年月日面板
            this.UpdateYearMonthDayRectangleText();
            #endregion
            #region 底部工具栏
            this.UpdateBottomRectangleText();
            #endregion
        }

        /// <summary>
        /// 获取指定年份的年面板第一个开始的年份(以2010年为第一格)
        /// </summary>
        /// <param name="year">指定年份</param>
        /// <returns></returns>
        private int GetStartYaer(int year)
        {
            if (year > 2010)
            {
                return 2010 + ((year - 2010) / 12) * 12;
            }
            if (year < 2010)
            {
                int remainder = (2010 - year) % 12 == 0 ? 0 : 1;
                return 2010 - ((2010 - year) / 12 + remainder) * 12;
            }
            return year;
        }

        /// <summary>
        /// 获取时间选项列表Rect的开始Y坐标
        /// </summary>
        /// <param name="scroll_obj"></param>
        /// <returns></returns>
        private int GetDisplayY(VerticalScroll scroll_obj)
        {
            float y = 0;
            if (scroll_obj.ScrollBack.Rect.Height > scroll_obj.ScrollSlide.Rect.Height)
            {
                y = -(scroll_obj.ScrollSlide.Rect.Y - scroll_obj.ScrollBack.Rect.Y) / (scroll_obj.ScrollBack.Rect.Height - scroll_obj.ScrollSlide.Rect.Height) * (scroll_obj.ContentRect.Height - scroll_obj.DisplayRect.Height);
            }
            return (int)(y);
        }

        #region 绘制

        /// <summary>
        /// 绘制顶部工具栏
        /// </summary>
        /// <param name="g"></param>
        private void DrawTopBar(Graphics g)
        {
            if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
                return;

            //背景
            g.FillRectangle(this.SolidBrushManageObject.topbarback_sb, this.DateObject.TopBar.Rect);

            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            #region 上一年
            if (this.DateObject.TopBar.prev_year_btn.MoveStatus == MoveStatuss.Enter)
            {
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_enter_pen, this.DateObject.TopBar.prev_year_btn.LineLeftPointArr);
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_enter_pen, this.DateObject.TopBar.prev_year_btn.LineRightPointArr);
            }
            else
            {
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_pen, this.DateObject.TopBar.prev_year_btn.LineLeftPointArr);
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_pen, this.DateObject.TopBar.prev_year_btn.LineRightPointArr);
            }
            #endregion
            #region 上一月

            if (this.YearMonthDayOrTime)
            {
                if (this.DateObject.TopBar.prev_month_btn.MoveStatus == MoveStatuss.Enter)
                {
                    g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_enter_pen, this.DateObject.TopBar.prev_month_btn.LineLeftPointArr);
                }
                else
                {
                    g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_pen, this.DateObject.TopBar.prev_month_btn.LineLeftPointArr);
                }
            }
            #endregion
            #region 年面板
            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                g.DrawString(this.DateObject.TopBar.yearscope_btn.Text, this.SolidBrushManageObject.topbar_rect_font, this.SolidBrushManageObject.topbarbtnfore_sb, this.DateObject.TopBar.yearscope_btn.Rect, center_sf);
            }
            #endregion
            #region 月面板
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                g.DrawString(this.DateObject.TopBar.monthyear_btn.Text, this.SolidBrushManageObject.topbar_rect_font, this.SolidBrushManageObject.topbarbtnfore_sb, this.DateObject.TopBar.monthyear_btn.Rect, center_sf);
            }
            #endregion
            #region 日面板
            else if (this.YearMonthDayOrTime)
            {
                g.DrawString(this.DateObject.TopBar.month_btn.Text, this.SolidBrushManageObject.topbar_rect_font, this.SolidBrushManageObject.topbarbtnfore_sb, this.DateObject.TopBar.month_btn.Rect, center_sf);
                g.DrawString(this.DateObject.TopBar.year_btn.Text, this.SolidBrushManageObject.topbar_rect_font, this.SolidBrushManageObject.topbarbtnfore_sb, this.DateObject.TopBar.year_btn.Rect, center_sf);
            }
            #endregion
            #region 下一月
            if (this.YearMonthDayOrTime)
            {
                if (this.DateObject.TopBar.next_month_btn.MoveStatus == MoveStatuss.Enter)
                {
                    g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_enter_pen, this.DateObject.TopBar.next_month_btn.LineRightPointArr);
                }
                else
                {
                    g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_pen, this.DateObject.TopBar.next_month_btn.LineRightPointArr);
                }
            }
            #endregion
            #region 下一年
            if (this.DateObject.TopBar.next_year_btn.MoveStatus == MoveStatuss.Enter)
            {
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_enter_pen, this.DateObject.TopBar.next_year_btn.LineLeftPointArr);
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_enter_pen, this.DateObject.TopBar.next_year_btn.LineRightPointArr);
            }
            else
            {
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_pen, this.DateObject.TopBar.next_year_btn.LineLeftPointArr);
                g.DrawLines(this.SolidBrushManageObject.topbarbtnfore_pen, this.DateObject.TopBar.next_year_btn.LineRightPointArr);
            }
            #endregion

            g.SmoothingMode = sm;
        }

        /// <summary>
        /// 绘制年面板
        /// </summary>
        /// <param name="g"></param>
        private void DrawYear(Graphics g)
        {
            //背景
            g.FillRectangle(this.SolidBrushManageObject.dateback_sb, this.DateObject.YearMain.Rect);

            for (int i = 0; i < this.DateObject.YearMain.itemArr.Length; i++)
            {
                if (this.DateObject.display_year != -1)
                {
                    if (this.DateObject.YearMain.itemArr[i].Value.Year < this.MinValue.Year || this.DateObject.YearMain.itemArr[i].Value.Year > this.MaxValue.Year)
                    {
                        if (this.DateObject.YearMain.itemArr[i].Value.Year == this.DateObject.display_year)
                        {
                            g.FillRectangle(this.SolidBrushManageObject.backdisabled_sb, this.DateObject.YearMain.itemArr[i].Rect);
                        }
                        g.DrawString(this.DateObject.YearMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.foredisabled_sb, this.DateObject.YearMain.itemArr[i].Rect, center_sf);
                    }
                    else if (this.DateObject.YearMain.itemArr[i].Value.Year == this.DateObject.display_year)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backselected_sb, this.DateObject.YearMain.itemArr[i].Rect);
                        g.DrawString(this.DateObject.YearMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.foreselected_sb, this.DateObject.YearMain.itemArr[i].Rect, center_sf);
                    }
                    else
                    {
                        if (this.DateObject.YearMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                        {
                            g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.YearMain.itemArr[i].Rect);
                        }
                        g.DrawString(this.DateObject.YearMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.normalfore_sb, this.DateObject.YearMain.itemArr[i].Rect, center_sf);
                    }
                }
                else
                {
                    if (this.DateObject.YearMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.YearMain.itemArr[i].Rect);
                    }
                    g.DrawString(this.DateObject.YearMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.normalfore_sb, this.DateObject.YearMain.itemArr[i].Rect, center_sf);
                }
            }

        }

        /// <summary>
        /// 绘制月面板
        /// </summary>
        /// <param name="g"></param>
        private void DrawYearMonth(Graphics g)
        {
            //背景
            g.FillRectangle(this.SolidBrushManageObject.dateback_sb, this.DateObject.MonthMain.Rect);

            DateTime min = new DateTime(this.MinValue.Year, this.MinValue.Month, 1);
            DateTime max = new DateTime(this.MaxValue.Year, this.MaxValue.Month, 1);
            for (int i = 0; i < this.DateObject.MonthMain.itemArr.Length; i++)
            {
                if (this.DateObject.display_year != -1 && this.DateObject.display_month != -1)
                {
                    DateTime now = new DateTime(this.DateObject.display_year, this.DateObject.display_month, 1).Date;
                    if (this.DateObject.MonthMain.itemArr[i].Value < min || this.DateObject.MonthMain.itemArr[i].Value > max)
                    {
                        if (this.DateObject.MonthMain.itemArr[i].Value == now)
                        {
                            g.FillRectangle(this.SolidBrushManageObject.backdisabled_sb, this.DateObject.MonthMain.itemArr[i].Rect);
                        }
                        g.DrawString(this.DateObject.MonthMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.foredisabled_sb, this.DateObject.MonthMain.itemArr[i].Rect, center_sf);
                    }
                    else if (this.DateObject.MonthMain.itemArr[i].Value == now)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backselected_sb, this.DateObject.MonthMain.itemArr[i].Rect);
                        g.DrawString(this.DateObject.MonthMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.foreselected_sb, this.DateObject.MonthMain.itemArr[i].Rect, center_sf);
                    }
                    else
                    {
                        if (this.DateObject.MonthMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                        {
                            g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.MonthMain.itemArr[i].Rect);
                        }
                        g.DrawString(this.DateObject.MonthMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.normalfore_sb, this.DateObject.MonthMain.itemArr[i].Rect, center_sf);
                    }
                }
                else
                {
                    if (this.DateObject.MonthMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.MonthMain.itemArr[i].Rect);
                    }
                    g.DrawString(this.DateObject.MonthMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.normalfore_sb, this.DateObject.MonthMain.itemArr[i].Rect, center_sf);
                }
            }

        }

        /// <summary>
        /// 绘制日面板
        /// </summary>
        /// <param name="g"></param>
        private void DrawYearMonthDay(Graphics g)
        {
            //背景
            g.FillRectangle(this.SolidBrushManageObject.dateback_sb, this.DateObject.DayMain.Rect);

            for (int i = 0; i < 7; i++)
            {
                g.DrawString(this.DateObject.DayMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.titlefore_sb, this.DateObject.DayMain.itemArr[i].Rect, center_sf);
            }

            bool isselect = (this.DateObject.display_year != -1 && this.DateObject.display_month != -1 && this.DateObject.display_day != -1);//是否有选中日期
            DateTime select_date = isselect ? new DateTime(this.DateObject.display_year, this.DateObject.display_month, this.DateObject.display_day).Date : new DateTime(0001, 1, 1).Date;

            for (int i = 7; i < this.DateObject.DayMain.itemArr.Length; i++)
            {
                if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Disabled)
                {
                    if (isselect && this.DateObject.DayMain.itemArr[i].Value == select_date)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backdisabled_sb, this.DateObject.DayMain.itemArr[i].Rect);
                    }
                    g.DrawString(this.DateObject.DayMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.foredisabled_sb, this.DateObject.DayMain.itemArr[i].Rect, center_sf);
                }
                else if (isselect && this.DateObject.DayMain.itemArr[i].Value == select_date)
                {
                    g.FillRectangle(this.SolidBrushManageObject.backselected_sb, this.DateObject.DayMain.itemArr[i].Rect);
                    g.DrawString(this.DateObject.DayMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.foreselected_sb, this.DateObject.DayMain.itemArr[i].Rect, center_sf);
                }
                else if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Past)
                {
                    if (this.DateObject.DayMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.DayMain.itemArr[i].Rect);
                    }
                    g.DrawString(this.DateObject.DayMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.pastfore_sb, this.DateObject.DayMain.itemArr[i].Rect, center_sf);
                }
                else if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Normal)
                {
                    if (this.DateObject.DayMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.DayMain.itemArr[i].Rect);
                    }
                    g.DrawString(this.DateObject.DayMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.normalfore_sb, this.DateObject.DayMain.itemArr[i].Rect, center_sf);
                }
                else if (this.DateObject.DayMain.itemArr[i].DateItemType == DateItemTypes.Future)
                {
                    if (this.DateObject.DayMain.itemArr[i].MoveStatus == MoveStatuss.Enter)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.backenter_sb, this.DateObject.DayMain.itemArr[i].Rect);
                    }
                    g.DrawString(this.DateObject.DayMain.itemArr[i].Text, this.SolidBrushManageObject.date_rect_font, this.SolidBrushManageObject.futurefore_sb, this.DateObject.DayMain.itemArr[i].Rect, center_sf);
                }
            }

        }

        /// <summary>
        /// 绘制时间面板
        /// </summary>
        /// <param name="g"></param>
        private void DrawTime(Graphics g)
        {
            #region
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                int y = this.GetDisplayY(this.DateObject.TimeMain.HourArea.verticalScroll);
                for (int i = 0; i < this.DateObject.TimeMain.HourArea.itemArr.Length; i++)
                {
                    if (this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Bottom + y < this.DateObject.TimeMain.Rect.Y || this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Y + y > this.DateObject.TimeMain.Rect.Bottom)
                    {
                        continue;
                    }
                    RectangleF item_rect = new RectangleF(this.DateObject.TimeMain.HourArea.itemArr[i].Rect.X, this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Y + y, this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Width, this.DateObject.TimeMain.HourArea.itemArr[i].Rect.Height);
                    if (this.DateObject.TimeMain.HourArea.itemArr[i].Value == this.DateObject.display_hour)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.timebackselected_sb, item_rect);
                    }
                    g.DrawString(this.DateObject.TimeMain.HourArea.itemArr[i].Text, this.SolidBrushManageObject.time_rect_font, (this.DateObject.display_hour == this.DateObject.TimeMain.HourArea.itemArr[i].Value) ? this.SolidBrushManageObject.timeforeselected_sb : this.SolidBrushManageObject.timeforenormal_sb, item_rect, center_sf);
                    g.DrawLine(this.SolidBrushManageObject.timecrossline_pen, new PointF(item_rect.X, item_rect.Bottom), new PointF(item_rect.Right, item_rect.Bottom));

                }
                this.DrawScroll(g, this.DateObject.TimeMain.HourArea.verticalScroll);
            }
            #endregion
            #region
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                int y = this.GetDisplayY(this.DateObject.TimeMain.MinuteArea.verticalScroll);
                for (int i = 0; i < this.DateObject.TimeMain.MinuteArea.itemArr.Length; i++)
                {
                    if (this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Bottom + y < this.DateObject.TimeMain.Rect.Y || this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Y + y > this.DateObject.TimeMain.Rect.Bottom)
                    {
                        continue;
                    }
                    RectangleF item_rect = new RectangleF(this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.X, this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Y + y, this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Width, this.DateObject.TimeMain.MinuteArea.itemArr[i].Rect.Height);
                    if (this.DateObject.TimeMain.MinuteArea.itemArr[i].Value == this.DateObject.display_minute)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.timebackselected_sb, item_rect);
                    }

                    g.DrawString(this.DateObject.TimeMain.MinuteArea.itemArr[i].Text, this.SolidBrushManageObject.time_rect_font, (this.DateObject.display_minute == this.DateObject.TimeMain.MinuteArea.itemArr[i].Value) ? this.SolidBrushManageObject.timeforeselected_sb : this.SolidBrushManageObject.timeforenormal_sb, item_rect, center_sf);
                    g.DrawLine(this.SolidBrushManageObject.timecrossline_pen, new PointF(item_rect.X, item_rect.Bottom), new PointF(item_rect.Right, item_rect.Bottom));

                }
                this.DrawScroll(g, this.DateObject.TimeMain.MinuteArea.verticalScroll);
            }
            #endregion
            #region
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                int y = this.GetDisplayY(this.DateObject.TimeMain.SecondArea.verticalScroll);
                for (int i = 0; i < this.DateObject.TimeMain.SecondArea.itemArr.Length; i++)
                {
                    if (this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Bottom + y < this.DateObject.TimeMain.Rect.Y || this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Y + y > this.DateObject.TimeMain.Rect.Bottom)
                    {
                        continue;
                    }

                    RectangleF item_rect = new RectangleF(this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.X, this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Y + y, this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Width, this.DateObject.TimeMain.SecondArea.itemArr[i].Rect.Height);
                    if (this.DateObject.TimeMain.SecondArea.itemArr[i].Value == this.DateObject.display_second)
                    {
                        g.FillRectangle(this.SolidBrushManageObject.timebackselected_sb, item_rect);
                    }
                    g.DrawString(this.DateObject.TimeMain.SecondArea.itemArr[i].Text, this.SolidBrushManageObject.time_rect_font, (this.DateObject.display_second == this.DateObject.TimeMain.SecondArea.itemArr[i].Value) ? this.SolidBrushManageObject.timeforeselected_sb : this.SolidBrushManageObject.timeforenormal_sb, item_rect, center_sf);
                    g.DrawLine(this.SolidBrushManageObject.timecrossline_pen, new PointF(item_rect.X, item_rect.Bottom), new PointF(item_rect.Right, item_rect.Bottom));

                }
                this.DrawScroll(g, this.DateObject.TimeMain.SecondArea.verticalScroll);
            }
            #endregion

            #region 绘制时间面板顶部工具栏
            g.FillRectangle(this.SolidBrushManageObject.topbarback_sb, this.DateObject.TimeMain.TopBarRect);
            g.DrawLine(this.SolidBrushManageObject.timecrossline_pen, new PointF(this.DateObject.TimeMain.TopBarRect.X, this.DateObject.TimeMain.TopBarRect.Bottom), new PointF(this.DateObject.TimeMain.TopBarRect.Right, this.DateObject.TimeMain.TopBarRect.Bottom));

            string time_text = "";
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour)
            {
                time_text = string.Format("{0}时", this.DateObject.display_hour.ToString().PadLeft(2,'0'));
            }
            else
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute)
            {
                time_text = string.Format("{0}时:{1}分", this.DateObject.display_hour.ToString().PadLeft(2, '0'), this.DateObject.display_minute.ToString().PadLeft(2, '0'));
            }
            else
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                time_text = string.Format("{0}时:{1}分:{2}秒", this.DateObject.display_hour.ToString().PadLeft(2, '0'), this.DateObject.display_minute.ToString().PadLeft(2, '0'), this.DateObject.display_second.ToString().PadLeft(2, '0'));
            }

            Size time_size = Size.Ceiling(g.MeasureString(time_text, this.Font, 1000));

            Rectangle time_rect = new Rectangle(
                (int)(this.DateObject.TimeMain.TopBarRect.X + (this.DateObject.TimeMain.TopBarRect.Width - time_size.Width) / 2f),
                (int)(this.DateObject.TimeMain.TopBarRect.Y + (this.DateObject.TimeMain.TopBarRect.Height - time_size.Height) / 2f),
                time_size.Width,
                time_size.Height);

            g.DrawString(time_text, this.Font, this.SolidBrushManageObject.topbarbtnfore_sb, time_rect);
            #endregion


        }

        /// <summary>
        /// 绘制滚动条
        /// </summary>
        /// <param name="g"></param>
        /// <param name="scroll_obj"></param>
        private void DrawScroll(Graphics g, VerticalScroll scroll_obj)
        {
            #region 滚动条
            if (scroll_obj.ScrollBack.Rect.Height > scroll_obj.ScrollSlide.Rect.Height)
            {
                #region 滚动条背景

                PointF scroll_start_point = new PointF(scroll_obj.ScrollBack.Rect.X + this.timeScrollThickness / 2f, scroll_obj.ScrollBack.Rect.Y);
                PointF scroll_end_point = new PointF(scroll_obj.ScrollBack.Rect.X + this.timeScrollThickness / 2f, scroll_obj.ScrollBack.Rect.Bottom);

                g.DrawLine(this.SolidBrushManageObject.timescrollback_pen, scroll_start_point, scroll_end_point);
                #endregion

                #region  滚动条滑块
                PointF scroll_slide_start_point = new PointF(scroll_obj.ScrollSlide.Rect.X + this.timeScrollThickness / 2f, scroll_obj.ScrollSlide.Rect.Y);
                PointF scroll_slide_end_point = new PointF(scroll_obj.ScrollSlide.Rect.X + this.timeScrollThickness / 2f, scroll_obj.ScrollSlide.Rect.Bottom);

                g.DrawLine(this.SolidBrushManageObject.timescrollslide_pen, scroll_slide_start_point, scroll_slide_end_point);
                #endregion

            }
            #endregion
        }

        /// <summary>
        /// 绘制底部工具栏
        /// </summary>
        /// <param name="g"></param>
        private void DrawBottomBar(Graphics g)
        {
            //背景
            g.FillRectangle(this.SolidBrushManageObject.bottombarback_sb, this.DateObject.BottomBar.Rect);

            //边框
            g.DrawLine(this.SolidBrushManageObject.bottombarborder_pen, this.DateObject.BottomBar.Rect.X, this.DateObject.BottomBar.Rect.Y, this.DateObject.BottomBar.Rect.Right, this.DateObject.BottomBar.Rect.Y);
            if (this.MinMaxTip)
            {
                g.DrawLines(this.SolidBrushManageObject.bottombarborder_pen, this.DateObject.BottomBar.bottombar_minmaxborder_lab.LinePointArr);
                g.DrawString(this.DateObject.BottomBar.bottombar_mindate_lab.Text, this.SolidBrushManageObject.bottom_rect_tip_font, this.SolidBrushManageObject.bottombar_tip_sb, this.DateObject.BottomBar.bottombar_mindate_lab.Rect.Location);
                g.DrawString(this.DateObject.BottomBar.bottombar_maxdate_lab.Text, this.SolidBrushManageObject.bottom_rect_tip_font, this.SolidBrushManageObject.bottombar_tip_sb, this.DateObject.BottomBar.bottombar_maxdate_lab.Rect.Location);

            }

            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush confirm_btn_back_sb = (!this.Enabled || this.DateObject.BottomBar.bottombar_confirm_btn.ItemStatus == BottomBarItemStatuss.Disabled) ? this.SolidBrushManageObject.bottombarbtnbackdisabled_sb : (this.DateObject.BottomBar.bottombar_confirm_btn.MoveStatus == MoveStatuss.Enter ? this.SolidBrushManageObject.bottombarbtnbackenter_sb : this.SolidBrushManageObject.bottombarbtnback_sb);
            SolidBrush confirm_btn_fore_sb = (!this.Enabled || this.DateObject.BottomBar.bottombar_confirm_btn.ItemStatus == BottomBarItemStatuss.Disabled) ? this.SolidBrushManageObject.bottombarbtnforedisabled_sb : (this.DateObject.BottomBar.bottombar_confirm_btn.MoveStatus == MoveStatuss.Enter ? this.SolidBrushManageObject.bottombarbtnforeenter_sb : this.SolidBrushManageObject.bottombarbtnfore_sb);

            SolidBrush now_btn_back_sb = (!this.Enabled || this.DateObject.BottomBar.bottombar_now_btn.ItemStatus == BottomBarItemStatuss.Disabled) ? this.SolidBrushManageObject.bottombarbtnbackdisabled_sb : (this.DateObject.BottomBar.bottombar_now_btn.MoveStatus == MoveStatuss.Enter ? this.SolidBrushManageObject.bottombarbtnbackenter_sb : this.SolidBrushManageObject.bottombarbtnback_sb);
            SolidBrush now_btn_fore_sb = (!this.Enabled || this.DateObject.BottomBar.bottombar_now_btn.ItemStatus == BottomBarItemStatuss.Disabled) ? this.SolidBrushManageObject.bottombarbtnforedisabled_sb : (this.DateObject.BottomBar.bottombar_now_btn.MoveStatus == MoveStatuss.Enter ? this.SolidBrushManageObject.bottombarbtnforeenter_sb : this.SolidBrushManageObject.bottombarbtnfore_sb);

            SolidBrush clear_btn_back_sb = (!this.Enabled || this.DateObject.BottomBar.bottombar_clear_btn.ItemStatus == BottomBarItemStatuss.Disabled) ? this.SolidBrushManageObject.bottombarbtnbackdisabled_sb : (this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus == MoveStatuss.Enter ? this.SolidBrushManageObject.bottombarbtnbackenter_sb : this.SolidBrushManageObject.bottombarbtnback_sb);
            SolidBrush clear_btn_fore_sb = (!this.Enabled || this.DateObject.BottomBar.bottombar_clear_btn.ItemStatus == BottomBarItemStatuss.Disabled) ? this.SolidBrushManageObject.bottombarbtnforedisabled_sb : (this.DateObject.BottomBar.bottombar_clear_btn.MoveStatus == MoveStatuss.Enter ? this.SolidBrushManageObject.bottombarbtnforeenter_sb : this.SolidBrushManageObject.bottombarbtnfore_sb);

            g.FillPath(confirm_btn_back_sb, ControlCommom.TransformCircular(this.DateObject.BottomBar.bottombar_confirm_btn.Rect, 0, 4, 4, 0));
            g.DrawString(this.DateObject.BottomBar.bottombar_confirm_btn.Text, this.SolidBrushManageObject.bottom_rect_font, confirm_btn_fore_sb, this.DateObject.BottomBar.bottombar_confirm_btn.Rect, center_sf);

            g.FillRectangle(now_btn_back_sb, this.DateObject.BottomBar.bottombar_now_btn.Rect);
            g.DrawString(this.DateObject.BottomBar.bottombar_now_btn.Text, this.SolidBrushManageObject.bottom_rect_font, now_btn_fore_sb, this.DateObject.BottomBar.bottombar_now_btn.Rect, center_sf);

            g.FillPath(clear_btn_back_sb, ControlCommom.TransformCircular(this.DateObject.BottomBar.bottombar_clear_btn.Rect, 4, 0, 0, 4));
            g.DrawString(this.DateObject.BottomBar.bottombar_clear_btn.Text, this.SolidBrushManageObject.bottom_rect_font, clear_btn_fore_sb, this.DateObject.BottomBar.bottombar_clear_btn.Rect, center_sf);

            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                this.DrawBottomBarClock(g);
            }

            g.SmoothingMode = sm;
        }

        /// <summary>
        /// 绘制底部工具栏时钟按钮
        /// </summary>
        /// <param name="g"></param>
        private void DrawBottomBarClock(Graphics g)
        {
            #region 边框
            float border = this.SolidBrushManageObject.bottombarclockborder_pen.Width;
            g.DrawEllipse(this.SolidBrushManageObject.bottombarclockborder_pen, this.DateObject.BottomBar.bottombar_time_btn.Rect);
            #endregion
            #region 点
            int dot_diameter = 1;
            g.FillRectangle(this.SolidBrushManageObject.bottombarclockdot_sb, new RectangleF(this.DateObject.BottomBar.bottombar_time_btn.Rect.X + this.DateObject.BottomBar.bottombar_time_btn.Rect.Width / 2, this.DateObject.BottomBar.bottombar_time_btn.Rect.Y + border + dot_diameter, dot_diameter, dot_diameter));
            g.FillRectangle(this.SolidBrushManageObject.bottombarclockdot_sb, new RectangleF(this.DateObject.BottomBar.bottombar_time_btn.Rect.X + this.DateObject.BottomBar.bottombar_time_btn.Rect.Width / 2, this.DateObject.BottomBar.bottombar_time_btn.Rect.Bottom - border - dot_diameter * 2, dot_diameter, dot_diameter));
            g.FillRectangle(this.SolidBrushManageObject.bottombarclockdot_sb, new RectangleF(this.DateObject.BottomBar.bottombar_time_btn.Rect.X + +border + dot_diameter, this.DateObject.BottomBar.bottombar_time_btn.Rect.Y + this.DateObject.BottomBar.bottombar_time_btn.Rect.Height / 2, dot_diameter, dot_diameter));
            g.FillRectangle(this.SolidBrushManageObject.bottombarclockdot_sb, new RectangleF(this.DateObject.BottomBar.bottombar_time_btn.Rect.Right - +border - dot_diameter * 2, this.DateObject.BottomBar.bottombar_time_btn.Rect.Y + this.DateObject.BottomBar.bottombar_time_btn.Rect.Height / 2, dot_diameter, dot_diameter));
            #endregion
            #region 圆心
            int radius = this.DateObject.BottomBar.bottombar_time_btn.Rect.Width / 2;
            Point center = new Point(this.DateObject.BottomBar.bottombar_time_btn.Rect.X + this.DateObject.BottomBar.bottombar_time_btn.Rect.Width / 2, this.DateObject.BottomBar.bottombar_time_btn.Rect.Y + this.DateObject.BottomBar.bottombar_time_btn.Rect.Height / 2);
            g.FillRectangle(this.SolidBrushManageObject.bottombarclockdot_sb, new Rectangle(center.X - 1, center.Y - 1, 2, 2));
            #endregion
            #region 时
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHour || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                g.DrawLine(this.SolidBrushManageObject.bottombarclockhour_pen, center, ControlCommom.CalculatePointForAngle(center, radius / 5f * 2.5f, this.GetClockHourAngle()));
            }
            #endregion
            #region 分
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinute || this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                g.DrawLine(this.SolidBrushManageObject.bottombarclockminute_pen, center, ControlCommom.CalculatePointForAngle(center, radius / 5f * 3, this.GetClockMinuteAngle()));
            }
            #endregion
            #region 秒
            if (this.DateDisplayType == DateDisplayTypes.YearMonthDayHourMinuteSecond)
            {
                g.DrawLine(this.SolidBrushManageObject.bottombarclocksecond_pen, center, ControlCommom.CalculatePointForAngle(center, radius / 5f * 4, this.GetClockSecondAngle()));
            }
            #endregion
        }

        /// <summary>
        /// 绘制激活边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectf"></param>
        private void DrawActiveBorder(Graphics g, RectangleF rectf)
        {
            Pen activate_border_pen = new Pen(this.ActivateColor, 1) { DashStyle = DashStyle.Dash };
            g.DrawRectangle(activate_border_pen, rectf.X, rectf.Y, rectf.Width - 1, rectf.Height - 1);
            activate_border_pen.Dispose();
        }

        /// <summary>
        /// 绘制激活边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="gp"></param>
        private void DrawActiveBorder(Graphics g, GraphicsPath gp)
        {
            Pen activate_border_pen = new Pen(this.ActivateColor, 1) { DashStyle = DashStyle.Dash };
            g.DrawPath(activate_border_pen, gp);
            activate_border_pen.Dispose();
        }

        #endregion

        #region 时钟

        /// <summary>
        /// 获取时钟时指针角度
        /// </summary>
        /// <returns></returns>
        private float GetClockHourAngle()
        {
            int i = this.DateObject.display_hour;
            if (i > 12)
                i -= 12;
            float angle = 270f + 360f / 12f * i;//270度开始
            angle += 360f / 60f * 5f * (this.DateObject.minute / 60f);
            if (angle > 360)
                angle -= 360;
            return angle;
        }

        /// <summary>
        /// 获取时钟分指针角度
        /// </summary>
        /// <returns></returns>
        private float GetClockMinuteAngle()
        {
            float angle = 270f + 360f / 60f * this.DateObject.display_minute;//270度开始
            if (angle > 360)
                angle -= 360;
            return angle;
        }

        /// <summary>
        /// 获取时钟秒指针角度
        /// </summary>
        /// <returns></returns>
        private float GetClockSecondAngle()
        {
            float angle = 270f + 360f / 60f * this.DateObject.display_second;//270度开始
            if (angle > 360)
                angle -= 360;
            return angle;
        }


        #endregion

        #region 激活索引

        /// <summary>
        ///更新激活索引
        /// </summary>
        /// <param name="offset">索引的偏移量</param>
        /// <returns></returns>
        private int UpdateActiveIndexByKey(int offset)
        {
            int index = 0;
            int index_tmp = 0;

            #region 年面板
            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                #region
                index = this.DateObject.YearMain.activeIndex;
                index_tmp = this.ValidActiveIndex(index, offset, true, -2, -1, true, 0, 11, true, 12, 14, 3);
                if (index != index_tmp)
                {
                    this.DateObject.YearMain.activeIndex = index_tmp;
                    index = index_tmp;
                    this.Invalidate();
                }
                #endregion
            }
            #endregion
            #region 年月面板
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                #region 年月面板月
                if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                {
                    index = this.DateObject.MonthMain.activeIndex;
                    index_tmp = this.ValidActiveIndex(index, offset, true, -3, -1, true, 0, 11, true, 12, 14, 3);
                    if (index != index_tmp)
                    {
                        this.DateObject.MonthMain.activeIndex = index_tmp;
                        index = index_tmp;
                        this.Invalidate();
                    }
                }
                #endregion
                #region 年月面板年
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year)
                {
                    index = this.DateObject.YearMain.activeIndex;
                    index_tmp = this.ValidActiveIndex(index, offset, true, -3, -1, true, 0, 11, true, 12, 14, 3);
                    if (index != index_tmp)
                    {
                        this.DateObject.YearMain.activeIndex = index_tmp;
                        index = index_tmp;
                        this.Invalidate();
                    }
                }
                #endregion
            }
            #endregion
            #region 年月日面板
            else if (this.YearMonthDayOrTime)
            {
                #region 年月日面板日
                if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                {
                    index = this.DateObject.DayMain.activeIndex;
                    index_tmp = this.ValidActiveIndex(index, offset, true, -6, -1, true, 7, 48, true, 49, 52, 7);
                    if (index != index_tmp)
                    {
                        this.DateObject.DayMain.activeIndex = index_tmp;
                        index = index_tmp;
                        this.Invalidate();
                    }
                }
                #endregion
                #region 年月日面板月
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
                {
                    index = this.DateObject.MonthMain.activeIndex;
                    index_tmp = this.ValidActiveIndex(index, offset, true, -6, -1, true, 0, 11, true, 12, 15, 3);
                    if (index != index_tmp)
                    {
                        this.DateObject.MonthMain.activeIndex = index_tmp;
                        index = index_tmp;
                        this.Invalidate();
                    }
                }
                #endregion
                #region 年月日面板年
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)
                {
                    index = this.DateObject.YearMain.activeIndex;
                    index_tmp = this.ValidActiveIndex(index, offset, true, -6, -1, true, 0, 11, true, 12, 15, 3);
                    if (index != index_tmp)
                    {
                        this.DateObject.YearMain.activeIndex = index_tmp;
                        index = index_tmp;
                        this.Invalidate();
                    }
                }
                #endregion
                #region 年月日面板时间
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
                {
                    index = this.DateObject.DayMain.activeIndex;
                    index_tmp = this.ValidActiveIndex(index, offset, false, -1, -1, false, -1, -1, true, 0, 3, 0);
                    if (index != index_tmp)
                    {
                        this.DateObject.DayMain.activeIndex = index_tmp;
                        index = index_tmp;
                        this.Invalidate();
                    }
                }
                #endregion
            }
            #endregion

            return index;
        }

        /// <summary>
        ///激活索引单击
        /// </summary>
        /// <returns></returns>
        private void ActiveIndexClick()
        {
            int index = 0;
            #region 年面板
            if (this.DateDisplayType == DateDisplayTypes.Year)
            {
                #region
                index = this.DateObject.YearMain.activeIndex;
                if (index == -2)
                {
                    this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                }
                else if (index == -1)
                {
                    this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                }
                else if (0 <= index && index <= 11)
                {
                    this.OnYearMainItemClick(new YearMainItemEventArgs() { Item = this.DateObject.YearMain.itemArr[index] });
                }
                else if (index == 12)
                {
                    this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                }
                else if (index == 13)
                {
                    this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                }
                else if (index == 14)
                {
                    this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                }
                this.UpdateTopRectangleText();
                this.UpdateYearMonthDayRectangleText();
                this.Invalidate();
                #endregion
            }
            #endregion
            #region 年月面板
            else if (this.DateDisplayType == DateDisplayTypes.YearMonth)
            {
                #region 年月面板月
                if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                {
                    index = this.DateObject.MonthMain.activeIndex;
                    if (index == -3)
                    {
                        this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                    }
                    else if (index == -2)
                    {
                        this.OnTopBarYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.year_btn.Text });
                    }
                    else if (index == -1)
                    {
                        this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                    }
                    else if (0 <= index && index <= 11)
                    {
                        this.OnMonthMainItemClick(new MonthMainItemEventArgs() { Item = this.DateObject.MonthMain.itemArr[index] });
                    }
                    else if (index == 12)
                    {
                        this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    }
                    else if (index == 13)
                    {
                        this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    }
                    else if (index == 14)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                    this.UpdateTopRectangleText();
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
                #region 年月面板年
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonth_Year)
                {
                    index = this.DateObject.YearMain.activeIndex;
                    if (index == -3)
                    {
                        this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                    }
                    else if (index == -2)
                    {
                        this.OnTopBarYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.year_btn.Text });
                    }
                    else if (index == -1)
                    {
                        this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                    }
                    else if (0 <= index && index <= 11)
                    {
                        this.OnYearMainItemClick(new YearMainItemEventArgs() { Item = this.DateObject.YearMain.itemArr[index] });
                    }
                    else if (index == 12)
                    {
                        this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    }
                    else if (index == 13)
                    {
                        this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    }
                    else if (index == 14)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                    this.UpdateTopRectangleText();
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
            }
            #endregion
            #region 年月日面板
            else if (this.YearMonthDayOrTime)
            {
                #region 年月日面板日
                if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                {
                    index = this.DateObject.DayMain.activeIndex;
                    if (index == -6)
                    {
                        this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                    }
                    else if (index == -5)
                    {
                        this.OnTopBarPrevMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_month_btn.Text });
                    }
                    else if (index == -4)
                    {
                        this.OnTopBarMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.month_btn.Text });
                    }
                    else if (index == -3)
                    {
                        this.OnTopBarYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.year_btn.Text });
                    }
                    else if (index == -2)
                    {
                        this.OnTopBarNextMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_month_btn.Text });
                    }
                    else if (index == -1)
                    {
                        this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                    }
                    else if (7 <= index && index <= 48)
                    {
                        this.OnDayMainItemClick(new DayMainItemEventArgs() { Item = this.DateObject.DayMain.itemArr[index] });
                    }
                    else if (index == 49)
                    {
                        this.OnBottomBarTimeClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_time_btn.Text });
                    }
                    else if (index == 50)
                    {
                        this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    }
                    else if (index == 51)
                    {
                        this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    }
                    else if (index == 52)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
                #region 年月日面板月
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
                {
                    this.InitializeTimeRectangle();
                    index = this.DateObject.MonthMain.activeIndex;
                    if (index == -6)
                    {
                        this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                    }
                    else if (index == -5)
                    {
                        this.OnTopBarPrevMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_month_btn.Text });
                    }
                    else if (index == -4)
                    {
                        this.OnTopBarMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.month_btn.Text });
                    }
                    else if (index == -3)
                    {
                        this.OnTopBarYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.year_btn.Text });
                    }
                    else if (index == -2)
                    {
                        this.OnTopBarNextMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_month_btn.Text });
                    }
                    else if (index == -1)
                    {
                        this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                    }
                    else if (0 <= index && index <= 11)
                    {
                        this.OnMonthMainItemClick(new MonthMainItemEventArgs() { Item = this.DateObject.MonthMain.itemArr[index] });
                    }
                    else if (index == 12)
                    {
                        this.OnBottomBarTimeClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_time_btn.Text });
                    }
                    else if (index == 13)
                    {
                        this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    }
                    else if (index == 14)
                    {
                        this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    }
                    else if (index == 15)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                    this.UpdateTopRectangleText();
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
                #region 年月日面板月日
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year)
                {
                    index = this.DateObject.YearMain.activeIndex;
                    if (index == -6)
                    {
                        this.OnTopBarPrevYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_year_btn.Text });
                    }
                    else if (index == -5)
                    {
                        this.OnTopBarPrevMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.prev_month_btn.Text });
                    }
                    else if (index == -4)
                    {
                        this.OnTopBarMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.month_btn.Text });
                    }
                    else if (index == -3)
                    {
                        this.OnTopBarYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.year_btn.Text });
                    }
                    else if (index == -2)
                    {
                        this.OnTopBarNextMonthClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_month_btn.Text });
                    }
                    else if (index == -1)
                    {
                        this.OnTopBarNextYearClick(new TopBarIiemEventArgs() { Text = this.DateObject.TopBar.next_year_btn.Text });
                    }
                    else if (0 <= index && index <= 11)
                    {
                        this.OnYearMainItemClick(new YearMainItemEventArgs() { Item = this.DateObject.YearMain.itemArr[index] });
                    }
                    else if (index == 12)
                    {
                        this.OnBottomBarTimeClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_time_btn.Text });
                    }
                    else if (index == 13)
                    {
                        this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    }
                    else if (index == 14)
                    {
                        this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    }
                    else if (index == 15)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                    this.UpdateTopRectangleText();
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
                #region 年月日面板时间
                else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
                {
                    index = this.DateObject.DayMain.activeIndex;

                    if (index == 0)
                    {
                        this.OnBottomBarTimeClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_time_btn.Text });
                    }
                    else if (index == 1)
                    {
                        this.OnBottomBarClearClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_clear_btn.Text });
                    }
                    else if (index == 2)
                    {
                        this.OnBottomBarNowClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_now_btn.Text });
                    }
                    else if (index == 3)
                    {
                        this.OnBottomBarConfirmClick(new BottomBarIiemEventArgs() { Text = this.DateObject.BottomBar.bottombar_confirm_btn.Text });
                    }
                    this.UpdateYearMonthDayRectangleText();
                    this.Invalidate();
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 获取对应面板索引偏移量
        /// </summary>
        /// <param name="offsetTypes"></param>
        /// <returns></returns>
        private int GetIndexOffset(KeyOffsetTypes offsetTypes)
        {
            int offset = 0;
            switch (this.DateDisplayType)
            {
                case DateDisplayTypes.Year:
                case DateDisplayTypes.YearMonth:
                    {
                        if (offsetTypes == KeyOffsetTypes.Left)
                            offset = -1;
                        else if (offsetTypes == KeyOffsetTypes.Right)
                            offset = 1;
                        else if (offsetTypes == KeyOffsetTypes.Up)
                            offset = -3;
                        else if (offsetTypes == KeyOffsetTypes.Down)
                            offset = 3;
                        break;
                    }
                case DateDisplayTypes.YearMonthDay:
                case DateDisplayTypes.YearMonthDayHour:
                case DateDisplayTypes.YearMonthDayHourMinute:
                case DateDisplayTypes.YearMonthDayHourMinuteSecond:
                    {
                        if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Year || this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Month)
                        {
                            if (offsetTypes == KeyOffsetTypes.Left)
                                offset = -1;
                            else if (offsetTypes == KeyOffsetTypes.Right)
                                offset = 1;
                            else if (offsetTypes == KeyOffsetTypes.Up)
                                offset = -3;
                            else if (offsetTypes == KeyOffsetTypes.Down)
                                offset = 3;
                        }
                        else if (this.DateDisplayStatus == DateDisplayStatuss.Default)
                        {
                            if (offsetTypes == KeyOffsetTypes.Left)
                                offset = -1;
                            else if (offsetTypes == KeyOffsetTypes.Right)
                                offset = 1;
                            else if (offsetTypes == KeyOffsetTypes.Up)
                                offset = -7;
                            else if (offsetTypes == KeyOffsetTypes.Down)
                                offset = 7;
                        }
                        else if (this.DateDisplayStatus == DateDisplayStatuss.YearMonthDay_Time)
                        {
                            if (offsetTypes == KeyOffsetTypes.Left)
                                offset = -1;
                            else if (offsetTypes == KeyOffsetTypes.Right)
                                offset = 1;
                            else if (offsetTypes == KeyOffsetTypes.Up)
                                offset = -4;
                            else if (offsetTypes == KeyOffsetTypes.Down)
                                offset = 4;
                        }
                        break;
                    }
            }
            return offset;
        }

        /// <summary>
        /// 获取激活索引
        /// </summary>
        /// <param name="index">源索索引</param>
        /// <param name="offset">索引的偏移量</param>
        /// <param name="top_enable">顶部工具栏索引启用</param>
        /// <param name="top_start">顶部工具栏开始索引</param>
        /// <param name="top_end">顶部工具栏结束索引</param>
        /// <param name="date_enable">日期索引启用</param>
        /// <param name="date_start">日期开始索引</param>
        /// <param name="date_end">日期结束索引</param>
        /// <param name="bottom_enable">底部工具栏索引启用</param>
        /// <param name="bottom_start">底部工具栏开始索引</param>
        /// <param name="bottom_end">底部工具栏结束索引</param>
        /// <param name="colunm">上下偏移索引量</param>
        /// <returns></returns>
        private int ValidActiveIndex(int index, int offset, bool top_enable, int top_start, int top_end, bool date_enable, int date_start, int date_end, bool bottom_enable, int bottom_start, int bottom_end, int colunm)
        {
            int value = index + offset;
            #region
            if (top_enable)
            {
                if (top_start <= index && index <= top_end)//顶部工具栏
                {
                    #region
                    if (Math.Abs(offset) == 1)//左右移动
                    {
                        if (value < top_start)//跳到底部工具栏最后一个
                        {
                            if (bottom_enable)
                                return bottom_end;
                            else if (date_enable)
                                return date_end;
                            else
                                return top_end;
                        }
                        else if (value > top_end)//跳到日期第一个
                        {
                            if (date_enable)
                                return date_start;
                            else if (bottom_enable)
                                return bottom_start;
                            else
                                return top_start;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    #endregion
                    #region
                    else if (offset == -colunm)//上移动
                    {
                        if (bottom_enable)
                            return bottom_end;//跳到底部工具栏最后一个
                        else if (date_enable)
                            return date_end;
                    }
                    #endregion
                    #region
                    else if (offset == colunm)//下移动
                    {
                        if (date_enable)
                            return date_start;//跳到日期第一个
                        else if (bottom_enable)
                            return bottom_start;
                    }
                    #endregion
                }
            }
            #endregion
            #region
            if (date_enable)
            {
                if (date_start <= index && index <= date_end)//年面板
                {
                    #region
                    if (Math.Abs(offset) == 1)//左右移动
                    {
                        if (value < date_start)//跳到顶部工具栏最后一个
                        {
                            if (top_enable)
                                return top_end;
                            else if (bottom_enable)
                                return bottom_end;
                            else
                                return date_end;
                        }
                        else if (value > date_end)//跳到底部工具栏第一个
                        {
                            if (bottom_enable)
                                return bottom_start;
                            else if (top_enable)
                                return top_start;
                            else
                                return date_start;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    #endregion
                    #region
                    else if (offset == -colunm)//上移动
                    {
                        if (value < date_start)//跳到顶部工具栏最后一个
                        {
                            if (top_enable)
                                return top_end;
                            else if (bottom_enable)
                                return bottom_end;
                            else
                                return date_end;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    #endregion
                    #region
                    else if (offset == colunm)//下移动
                    {
                        if (value > date_end)//跳到底部工具栏第一个
                        {
                            if (bottom_enable)
                                return bottom_start;
                            else if (top_enable)
                                return top_start;
                            else
                                return date_start;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    #endregion
                }
            }
            #endregion
            #region
            if (bottom_enable)
            {
                if (bottom_start <= index && index <= bottom_end)//底部工具栏
                {
                    #region
                    if (Math.Abs(offset) == 1)
                    {
                        if (value < bottom_start)//跳到日期最后一个
                        {
                            if (date_enable)
                                return date_end;
                            else if (top_enable)
                                return top_end;
                            else
                                return bottom_end;
                        }
                        if (value > bottom_end)//跳到顶部工具栏第一个
                        {
                            if (top_enable)
                                return top_start;
                            else if (date_enable)
                                return date_start;
                            else
                                return bottom_start;
                        }
                        else
                        {
                            return value;
                        }
                    }
                    #endregion
                    #region
                    else if (offset == -colunm)//上移动
                    {
                        if (date_enable)
                            return date_end;//跳到日期最后一个
                        else if (top_enable)
                            return top_end;
                    }
                    #endregion
                    #region
                    else if (offset == colunm)//下移动
                    {
                        if (top_enable)
                            return top_start;//跳到顶部工具栏第一个
                        else if (date_enable)
                            return date_start;
                    }
                    #endregion
                }
            }
            #endregion

            return index;
        }

        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 画笔管理
        /// </summary>
        [Description("画笔管理")]
        public class SolidBrushManage
        {
            private DatePickerExt ower;

            public SolidBrushManage(DatePickerExt ower)
            {
                this.ower = ower;
            }

            #region 顶部工具栏

            private SolidBrush _topbarback_sb = null;
            public SolidBrush topbarback_sb
            {
                get
                {
                    if (this._topbarback_sb == null)
                        this._topbarback_sb = new SolidBrush(this.ower.TopBarBackColor);
                    return this._topbarback_sb;
                }
            }

            private SolidBrush _topbarbtnfore_sb = null;
            public SolidBrush topbarbtnfore_sb
            {
                get
                {
                    if (this._topbarbtnfore_sb == null)
                        this._topbarbtnfore_sb = new SolidBrush(this.ower.TopBarBtnForeNormalColor);
                    return this._topbarbtnfore_sb;
                }
            }

            private Pen _topbarbtnfore_pen = null;
            public Pen topbarbtnfore_pen
            {
                get
                {
                    if (this._topbarbtnfore_pen == null)
                        this._topbarbtnfore_pen = new Pen(this.ower.TopBarBtnForeNormalColor, 1);
                    return this._topbarbtnfore_pen;
                }
            }

            private Pen _topbarbtnfore_enter_pen = null;
            public Pen topbarbtnfore_enter_pen
            {
                get
                {
                    if (this._topbarbtnfore_enter_pen == null)
                        this._topbarbtnfore_enter_pen = new Pen(this.ower.topBarBtnForeEnterColor, 1);
                    return this._topbarbtnfore_enter_pen;
                }
            }

            #endregion

            #region 日期面板

            private SolidBrush _dateback_sb = null;
            public SolidBrush dateback_sb
            {
                get
                {
                    if (this._dateback_sb == null)
                        this._dateback_sb = new SolidBrush(this.ower.DateBackNormalColor);
                    return this._dateback_sb;
                }
            }

            private SolidBrush _titlefore_sb = null;
            public SolidBrush titlefore_sb
            {
                get
                {
                    if (this._titlefore_sb == null)
                        this._titlefore_sb = new SolidBrush(this.ower.DateTitleForeColor);
                    return this._titlefore_sb;
                }
            }

            private SolidBrush _pastfore_sb = null;
            public SolidBrush pastfore_sb
            {
                get
                {
                    if (this._pastfore_sb == null)
                        this._pastfore_sb = new SolidBrush(this.ower.DateForePastColor);
                    return this._pastfore_sb;
                }
            }

            private SolidBrush _normalfore_sb = null;
            public SolidBrush normalfore_sb
            {
                get
                {
                    if (this._normalfore_sb == null)
                        this._normalfore_sb = new SolidBrush(this.ower.DateForeNormalColor);
                    return this._normalfore_sb;
                }
            }

            private SolidBrush _futurefore_sb = null;
            public SolidBrush futurefore_sb
            {
                get
                {
                    if (this._futurefore_sb == null)
                        this._futurefore_sb = new SolidBrush(this.ower.DateForeFutureColor);
                    return this._futurefore_sb;
                }
            }

            private SolidBrush _backdisabled_sb = null;
            public SolidBrush backdisabled_sb
            {
                get
                {
                    if (this._backdisabled_sb == null)
                        this._backdisabled_sb = new SolidBrush(this.ower.DateBackDisabledColor);
                    return this._backdisabled_sb;
                }
            }

            private SolidBrush _foredisabled_sb = null;
            public SolidBrush foredisabled_sb
            {
                get
                {
                    if (this._foredisabled_sb == null)
                        this._foredisabled_sb = new SolidBrush(this.ower.DateForeDisabledColor);
                    return this._foredisabled_sb;
                }
            }

            private SolidBrush _backselected_sb = null;
            public SolidBrush backselected_sb
            {
                get
                {
                    if (this._backselected_sb == null)
                        this._backselected_sb = new SolidBrush(this.ower.DateBackSelectedColor);
                    return this._backselected_sb;
                }
            }

            private SolidBrush _foreselected_sb = null;
            public SolidBrush foreselected_sb
            {
                get
                {
                    if (this._foreselected_sb == null)
                        this._foreselected_sb = new SolidBrush(this.ower.DateForeSelectedColor);
                    return this._foreselected_sb;
                }
            }

            private SolidBrush _backenter_sb = null;
            public SolidBrush backenter_sb
            {
                get
                {
                    if (this._backenter_sb == null)
                        this._backenter_sb = new SolidBrush(this.ower.DateBackEnterColor);
                    return this._backenter_sb;
                }
            }


            private Pen _timescrollback_pen = null;
            public Pen timescrollback_pen
            {
                get
                {
                    if (this._timescrollback_pen == null)
                        this._timescrollback_pen = new Pen(this.ower.TimeScrollBackColor, this.ower.DateObject.TimeMain.HourArea.verticalScroll.ScrollBack.Rect.Width);
                    return this._timescrollback_pen;
                }
            }

            private Pen _timescrollslide_pen = null;
            public Pen timescrollslide_pen
            {
                get
                {
                    if (this._timescrollslide_pen == null)
                        this._timescrollslide_pen = new Pen(this.ower.TimeScrollSlideColor, this.ower.DateObject.TimeMain.HourArea.verticalScroll.ScrollBack.Rect.Width);
                    return this._timescrollslide_pen;
                }
            }




            private Pen _timecrossline_pen = null;
            public Pen timecrossline_pen
            {
                get
                {
                    if (this._timecrossline_pen == null)
                        this._timecrossline_pen = new Pen(this.ower.TimeCrossLineColor);
                    return this._timecrossline_pen;
                }
            }

            private SolidBrush _timebackselected_sb = null;
            public SolidBrush timebackselected_sb
            {
                get
                {
                    if (this._timebackselected_sb == null)
                        this._timebackselected_sb = new SolidBrush(this.ower.TimeBackSelectedColor);
                    return this._timebackselected_sb;
                }
            }

            private SolidBrush _timeforenormal_sb = null;
            public SolidBrush timeforenormal_sb
            {
                get
                {
                    if (this._timeforenormal_sb == null)
                        this._timeforenormal_sb = new SolidBrush(this.ower.TimeForeNormalColor);
                    return this._timeforenormal_sb;
                }
            }

            private SolidBrush _timeforeselected_sb = null;
            public SolidBrush timeforeselected_sb
            {
                get
                {
                    if (this._timeforeselected_sb == null)
                        this._timeforeselected_sb = new SolidBrush(this.ower.TimeForeSelectedColor);
                    return this._timeforeselected_sb;
                }
            }
            #endregion

            #region 底部工具栏

            private SolidBrush _bottombarback_sb = null;
            public SolidBrush bottombarback_sb
            {
                get
                {
                    if (this._bottombarback_sb == null)
                        this._bottombarback_sb = new SolidBrush(this.ower.BottomBarBackColor);
                    return this._bottombarback_sb;
                }
            }

            private Pen _bottombarborder_pen = null;
            public Pen bottombarborder_pen
            {
                get
                {
                    if (this._bottombarborder_pen == null)
                        this._bottombarborder_pen = new Pen(this.ower.BottomBarBackBorderColor, 1);
                    return this._bottombarborder_pen;
                }
            }

            private SolidBrush _bottombar_tip_sb = null;
            public SolidBrush bottombar_tip_sb
            {
                get
                {
                    if (this._bottombar_tip_sb == null)
                        this._bottombar_tip_sb = new SolidBrush(this.ower.BottomBarTipForeColor);
                    return this._bottombar_tip_sb;
                }
            }

            private SolidBrush _bottombarbtnback_sb = null;
            public SolidBrush bottombarbtnback_sb
            {
                get
                {
                    if (this._bottombarbtnback_sb == null)
                        this._bottombarbtnback_sb = new SolidBrush(this.ower.BottomBarBtnBackNormalColor);
                    return this._bottombarbtnback_sb;
                }
            }

            private SolidBrush _bottombarbtnfore_sb = null;
            public SolidBrush bottombarbtnfore_sb
            {
                get
                {
                    if (this._bottombarbtnfore_sb == null)
                        this._bottombarbtnfore_sb = new SolidBrush(this.ower.BottomBarBtnForeNormalColor);
                    return this._bottombarbtnfore_sb;
                }
            }

            private SolidBrush _bottombarbtnbackdisabled_sb = null;
            public SolidBrush bottombarbtnbackdisabled_sb
            {
                get
                {
                    if (this._bottombarbtnbackdisabled_sb == null)
                        this._bottombarbtnbackdisabled_sb = new SolidBrush(this.ower.BottomBarBtnBackDisabledColor);
                    return this._bottombarbtnbackdisabled_sb;
                }
            }

            private SolidBrush _bottombarbtnforedisabled_sb = null;
            public SolidBrush bottombarbtnforedisabled_sb
            {
                get
                {
                    if (this._bottombarbtnforedisabled_sb == null)
                        this._bottombarbtnforedisabled_sb = new SolidBrush(this.ower.BottomBarBtnForeDisabledColor);
                    return this._bottombarbtnforedisabled_sb;
                }
            }

            private SolidBrush _bottombarbtnbackenter_sb = null;
            public SolidBrush bottombarbtnbackenter_sb
            {
                get
                {
                    if (this._bottombarbtnbackenter_sb == null)
                        this._bottombarbtnbackenter_sb = new SolidBrush(this.ower.BottomBarBtnBackEnterColor);
                    return this._bottombarbtnbackenter_sb;
                }
            }

            private SolidBrush _bottombarbtnforeenter_sb = null;
            public SolidBrush bottombarbtnforeenter_sb
            {
                get
                {
                    if (this._bottombarbtnforeenter_sb == null)
                        this._bottombarbtnforeenter_sb = new SolidBrush(this.ower.BottomBarBtnForeEnterColor);
                    return this._bottombarbtnforeenter_sb;
                }
            }

            private Pen _bottombarclockborder_pen = null;
            public Pen bottombarclockborder_pen
            {
                get
                {
                    if (this._bottombarclockborder_pen == null)
                        this._bottombarclockborder_pen = new Pen(this.ower.BottomBarClockBorderColor, 2);
                    return this._bottombarclockborder_pen;
                }
            }

            private SolidBrush _bottombarclockdot_sb = null;
            public SolidBrush bottombarclockdot_sb
            {
                get
                {
                    if (this._bottombarclockdot_sb == null)
                        this._bottombarclockdot_sb = new SolidBrush(this.ower.BottomBarClockDotColor);
                    return this._bottombarclockdot_sb;
                }
            }

            private Pen _bottombarclockhour_pen = null;
            public Pen bottombarclockhour_pen
            {
                get
                {
                    if (this._bottombarclockhour_pen == null)
                        this._bottombarclockhour_pen = new Pen(this.ower.BottomBarClockHourColor, 1.5f);
                    return this._bottombarclockhour_pen;
                }
            }

            private Pen _bottombarclockminute_pen = null;
            public Pen bottombarclockminute_pen
            {
                get
                {
                    if (this._bottombarclockminute_pen == null)
                        this._bottombarclockminute_pen = new Pen(this.ower.BottomBarClockMinuteColor, 1.5f);
                    return this._bottombarclockminute_pen;
                }
            }

            private Pen _bottombarclocksecond_pen = null;
            public Pen bottombarclocksecond_pen
            {
                get
                {
                    if (this._bottombarclocksecond_pen == null)
                        this._bottombarclocksecond_pen = new Pen(this.ower.BottomBarClockSecondColor, 1f);
                    return this._bottombarclocksecond_pen;
                }
            }

            #endregion

            #region 字体

            private Font _topbar_rect_font = null;
            /// <summary>
            /// 顶部工具栏字体
            /// </summary>
            public Font topbar_rect_font
            {
                get
                {
                    if (this._topbar_rect_font == null)
                        this._topbar_rect_font = new Font("微软雅黑", 10);
                    return this._topbar_rect_font;
                }
            }

            private Font _date_rect_font = null;
            /// <summary>
            /// 日期面板字体
            /// </summary>
            public Font date_rect_font
            {
                get
                {
                    if (this._date_rect_font == null)
                        this._date_rect_font = new Font("微软雅黑", 10);
                    return this._date_rect_font;
                }
            }

            private Font _time_rect_font = null;
            /// <summary>
            /// 时间面板字体
            /// </summary>
            public Font time_rect_font
            {
                get
                {
                    if (this._time_rect_font == null)
                        this._time_rect_font = new Font("微软雅黑", 9);
                    return this._time_rect_font;
                }
            }

            private Font _bottom_rect_font = null;
            /// <summary>
            /// 底部工具栏字体
            /// </summary>
            public Font bottom_rect_font
            {
                get
                {
                    if (this._bottom_rect_font == null)
                        this._bottom_rect_font = new Font("微软雅黑", 10);
                    return this._bottom_rect_font;
                }
            }

            private Font _bottom_rect_tip_font = null;
            /// <summary>
            /// 底部工具栏提示信息字体
            /// </summary>
            public Font bottom_rect_tip_font
            {
                get
                {
                    if (this._bottom_rect_tip_font == null)
                        this._bottom_rect_tip_font = new Font("微软雅黑", 9f);
                    return this._bottom_rect_tip_font;
                }
            }

            #endregion

            /// <summary>
            /// 释放所有画笔、字体
            /// </summary>
            public void ReleaseSolidBrushs()
            {
                #region 顶部工具栏
                if (this._topbarback_sb != null)
                {
                    this._topbarback_sb.Dispose();
                    this._topbarback_sb = null;
                }
                if (this._topbarbtnfore_sb != null)
                {
                    this._topbarbtnfore_sb.Dispose();
                    this._topbarbtnfore_sb = null;
                }
                if (this._topbarbtnfore_pen != null)
                {
                    this._topbarbtnfore_pen.Dispose();
                    this._topbarbtnfore_pen = null;
                }
                if (this._topbarbtnfore_enter_pen != null)
                {
                    this._topbarbtnfore_enter_pen.Dispose();
                    this._topbarbtnfore_enter_pen = null;
                }
                #endregion

                #region 日期面板
                if (this._dateback_sb != null)
                {
                    this._dateback_sb.Dispose();
                    this._dateback_sb = null;
                }
                if (this._titlefore_sb != null)
                {
                    this._titlefore_sb.Dispose();
                    this._titlefore_sb = null;
                }
                if (this._pastfore_sb != null)
                {
                    this._pastfore_sb.Dispose();
                    this._pastfore_sb = null;
                }
                if (this._normalfore_sb != null)
                {
                    this._normalfore_sb.Dispose();
                    this._normalfore_sb = null;
                }
                if (this._futurefore_sb != null)
                {
                    this._futurefore_sb.Dispose();
                    this._futurefore_sb = null;
                }
                if (this._backdisabled_sb != null)
                {
                    this._backdisabled_sb.Dispose();
                    this._backdisabled_sb = null;
                }
                if (this._foredisabled_sb != null)
                {
                    this._foredisabled_sb.Dispose();
                    this._foredisabled_sb = null;
                }
                if (this._backselected_sb != null)
                {
                    this._backselected_sb.Dispose();
                    this._backselected_sb = null;
                }
                if (this._foreselected_sb != null)
                {
                    this._foreselected_sb.Dispose();
                    this._foreselected_sb = null;
                }
                if (this._backenter_sb != null)
                {
                    this._backenter_sb.Dispose();
                    this._backenter_sb = null;
                }

                if (this._timecrossline_pen != null)
                {
                    this._timecrossline_pen.Dispose();
                    this._timecrossline_pen = null;
                }

                if (this._timebackselected_sb != null)
                {
                    this._timebackselected_sb.Dispose();
                    this._timebackselected_sb = null;
                }

                if (this._timeforenormal_sb != null)
                {
                    this._timeforenormal_sb.Dispose();
                    this._timeforenormal_sb = null;
                }
                if (this._timeforeselected_sb != null)
                {
                    this._timeforeselected_sb.Dispose();
                    this._timeforeselected_sb = null;
                }

                #endregion

                #region 底部工具栏
                if (this._bottombarback_sb != null)
                {
                    this._bottombarback_sb.Dispose();
                    this._bottombarback_sb = null;
                }
                if (this._bottombarborder_pen != null)
                {
                    this._bottombarborder_pen.Dispose();
                    this._bottombarborder_pen = null;
                }
                if (this._bottombar_tip_sb != null)
                {
                    this._bottombar_tip_sb.Dispose();
                    this._bottombar_tip_sb = null;
                }
                if (this._bottombarbtnback_sb != null)
                {
                    this._bottombarbtnback_sb.Dispose();
                    this._bottombarbtnback_sb = null;
                }
                if (this._bottombarbtnfore_sb != null)
                {
                    this._bottombarbtnfore_sb.Dispose();
                    this._bottombarbtnfore_sb = null;
                }
                if (this._bottombarbtnbackdisabled_sb != null)
                {
                    this._bottombarbtnbackdisabled_sb.Dispose();
                    this._bottombarbtnbackdisabled_sb = null;
                }
                if (this._bottombarbtnforedisabled_sb != null)
                {
                    this._bottombarbtnforedisabled_sb.Dispose();
                    this._bottombarbtnforedisabled_sb = null;
                }
                if (this._bottombarbtnbackenter_sb != null)
                {
                    this._bottombarbtnbackenter_sb.Dispose();
                    this._bottombarbtnbackenter_sb = null;
                }
                if (this._bottombarbtnforeenter_sb != null)
                {
                    this._bottombarbtnforeenter_sb.Dispose();
                    this._bottombarbtnforeenter_sb = null;
                }
                if (this._bottombarclockborder_pen != null)
                {
                    this._bottombarclockborder_pen.Dispose();
                    this._bottombarclockborder_pen = null;
                }
                if (this._bottombarclockdot_sb != null)
                {
                    this._bottombarclockdot_sb.Dispose();
                    this._bottombarclockdot_sb = null;
                }
                if (this._bottombarclockhour_pen != null)
                {
                    this._bottombarclockhour_pen.Dispose();
                    this._bottombarclockhour_pen = null;
                }
                if (this._bottombarclockminute_pen != null)
                {
                    this._bottombarclockminute_pen.Dispose();
                    this._bottombarclockminute_pen = null;
                }
                if (this._bottombarclocksecond_pen != null)
                {
                    this._bottombarclocksecond_pen.Dispose();
                    this._bottombarclocksecond_pen = null;
                }
                #endregion

                #region 字体
                if (this._topbar_rect_font != null)
                {
                    this._topbar_rect_font.Dispose();
                    this._topbar_rect_font = null;
                }
                if (this._date_rect_font != null)
                {
                    this._date_rect_font.Dispose();
                    this._date_rect_font = null;
                }
                if (this._time_rect_font != null)
                {
                    this._time_rect_font.Dispose();
                    this._time_rect_font = null;
                }
                if (this._bottom_rect_font != null)
                {
                    this._bottom_rect_font.Dispose();
                    this._bottom_rect_font = null;
                }
                if (this._bottom_rect_tip_font != null)
                {
                    this._bottom_rect_tip_font.Dispose();
                    this._bottom_rect_tip_font = null;
                }
                #endregion
            }
        }

        /// <summary>
        /// 日期面板
        /// </summary>
        [Description("日期面板")]
        public class DateClass
        {
            #region 面板

            private TopBarClass topBar;
            /// <summary>
            /// 顶部工具栏面板
            /// </summary>
            [Description("顶部工具栏面板")]
            public TopBarClass TopBar
            {
                get
                {
                    if (this.topBar == null)
                        this.topBar = new TopBarClass();

                    return topBar;
                }
                set { topBar = value; }
            }

            private YearMainClass yearMain;
            /// <summary>
            /// 年面板
            /// </summary>
            [Description("年面板")]
            public YearMainClass YearMain
            {
                get
                {
                    if (this.yearMain == null)
                        this.yearMain = new YearMainClass();

                    return yearMain;
                }
                set { yearMain = value; }
            }

            private MonthMainClass monthMain;
            /// <summary>
            /// 月面板
            /// </summary>
            [Description("月面板")]
            public MonthMainClass MonthMain
            {
                get
                {
                    if (this.monthMain == null)
                        this.monthMain = new MonthMainClass();

                    return monthMain;
                }
                set { monthMain = value; }
            }

            private DayMainClass dayMain;
            /// <summary>
            /// 日面板
            /// </summary>
            [Description("日面板")]
            public DayMainClass DayMain
            {
                get
                {
                    if (this.dayMain == null)
                        this.dayMain = new DayMainClass();

                    return dayMain;
                }
                set { dayMain = value; }
            }

            private TimeMainClass timeMain;
            /// <summary>
            /// 时间面板
            /// </summary>
            [Description("时间面板")]
            public TimeMainClass TimeMain
            {
                get
                {
                    if (this.timeMain == null)
                        this.timeMain = new TimeMainClass();

                    return timeMain;
                }
                set { timeMain = value; }
            }

            private BottomBarClass bottomBar;
            /// <summary>
            /// 底部工具栏面板
            /// </summary>
            [Description("底部工具栏面板")]
            public BottomBarClass BottomBar
            {
                get
                {
                    if (this.bottomBar == null)
                        this.bottomBar = new BottomBarClass();

                    return bottomBar;
                }
                set { bottomBar = value; }
            }

            #endregion

            #region 值存放

            private int _year = 1005;
            /// <summary>
            /// 年份选择(已选择值)
            /// </summary>
            [Description("年份选择(已选择值)")]
            public int year
            {
                get { return this._year; }
                set { this._year = value; }
            }

            private int _month = 1;
            /// <summary>
            /// 月份选择(已选择值)
            /// </summary>
            [Description("月份选择(已选择值)")]
            public int month
            {
                get { return this._month; }
                set { this._month = value; }
            }

            private int _day = 1;
            /// <summary>
            /// 日选择(已选择值)
            /// </summary>
            [Description("日选择(已选择值)")]
            public int day
            {
                get { return this._day; }
                set { this._day = value; }
            }

            private int _hour = 0;
            /// <summary>
            /// 时选择(已选择值)
            /// </summary>
            [Description("时选择(已选择值)")]
            public int hour
            {
                get { return this._hour; }
                set { this._hour = value; }
            }

            private int _minute = 0;
            /// <summary>
            /// 分选择(已选择值)
            /// </summary>
            [Description("分选择(已选择值)")]
            public int minute
            {
                get { return this._minute; }
                set { this._minute = value; }
            }

            private int _second = 0;
            /// <summary>
            /// 秒选择(已选择值)
            /// </summary>
            [Description("秒选择(已选择值)")]
            public int second
            {
                get { return this._second; }
                set { this._second = value; }
            }

            #endregion

            #region 用于显示

            private int _display_year = 1005;
            /// <summary>
            /// 年份选择(用于显示)
            /// </summary>
            [Description("年份选择(用于显示)")]
            public int display_year
            {
                get { return this._display_year; }
                set { this._display_year = value; }
            }

            private int _display_month = 1;
            /// <summary>
            /// 月份选择(用于显示)
            /// </summary>
            [Description("月份选择(用于显示)")]
            public int display_month
            {
                get { return this._display_month; }
                set { this._display_month = value; }
            }

            private int _display_day = 1;
            /// <summary>
            /// 日选择(用于显示)
            /// </summary>
            [Description("日选择(用于显示)")]
            public int display_day
            {
                get { return this._display_day; }
                set { this._display_day = value; }
            }

            private int _display_hour = 0;
            /// <summary>
            /// 时选择(用于显示)
            /// </summary>
            [Description("时选择(用于显示)")]
            public int display_hour
            {
                get { return this._display_hour; }
                set { this._display_hour = value; }
            }

            private int _display_minute = 0;
            /// <summary>
            /// 分选择(用于显示)
            /// </summary>
            [Description("分选择(用于显示)")]
            public int display_minute
            {
                get { return this._display_minute; }
                set { this._display_minute = value; }
            }

            private int _display_second = 0;
            /// <summary>
            /// 秒选择(用于显示)
            /// </summary>
            [Description("秒选择(用于显示)")]
            public int display_second
            {
                get { return this._display_second; }
                set { this._display_second = value; }
            }
            #endregion
        }

        #region 顶部工具栏

        /// <summary>
        /// 顶部工具栏面板
        /// </summary>
        [Description("顶部工具栏面板")]
        public class TopBarClass
        {
            public Rectangle rect;
            /// <summary>
            /// 顶部工具栏rect
            /// </summary>
            [Description("顶部工具栏rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;
                    this.rect = value;
                }
            }

            private TopBarItemClass _prev_year_btn;
            /// <summary>
            /// 上一年按钮
            /// </summary>
            [Description("上一年按钮")]
            public TopBarItemClass prev_year_btn
            {
                get
                {
                    if (this._prev_year_btn == null)
                        this._prev_year_btn = new TopBarItemClass();

                    return this._prev_year_btn;
                }
                set { this._prev_year_btn = value; }
            }

            private TopBarItemClass _prev_month_btn;
            /// <summary>
            /// 上一月按钮
            /// </summary>
            [Description("上一月按钮")]
            public TopBarItemClass prev_month_btn
            {
                get
                {
                    if (this._prev_month_btn == null)
                        this._prev_month_btn = new TopBarItemClass();

                    return this._prev_month_btn;
                }
                set { this._prev_month_btn = value; }
            }

            private TopBarItemClass _yearscope_btn;
            /// <summary>
            /// 年范围描述
            /// </summary>
            [Description("年范围描述")]
            public TopBarItemClass yearscope_btn
            {
                get
                {
                    if (this._yearscope_btn == null)
                        this._yearscope_btn = new TopBarItemClass();

                    return this._yearscope_btn;
                }
                set { this._yearscope_btn = value; }
            }

            private TopBarItemClass _monthyear_btn;
            /// <summary>
            /// 月面板年按钮
            /// </summary>
            [Description("月面板年按钮")]
            public TopBarItemClass monthyear_btn
            {
                get
                {
                    if (this._monthyear_btn == null)
                        this._monthyear_btn = new TopBarItemClass();

                    return this._monthyear_btn;
                }
                set { this._monthyear_btn = value; }
            }

            private TopBarItemClass _month_btn;
            /// <summary>
            /// 月按钮
            /// </summary>
            [Description("月按钮")]
            public TopBarItemClass month_btn
            {
                get
                {
                    if (this._month_btn == null)
                        this._month_btn = new TopBarItemClass();

                    return this._month_btn;
                }
                set { this._month_btn = value; }
            }

            private TopBarItemClass _year_btn;
            /// <summary>
            /// 年按钮
            /// </summary>
            [Description("年按钮")]
            public TopBarItemClass year_btn
            {
                get
                {
                    if (this._year_btn == null)
                        this._year_btn = new TopBarItemClass();

                    return this._year_btn;
                }
                set { this._year_btn = value; }
            }

            private TopBarItemClass _next_month_btn;
            /// <summary>
            /// 下一月按钮
            /// </summary>
            [Description("下一月按钮")]
            public TopBarItemClass next_month_btn
            {
                get
                {
                    if (this._next_month_btn == null)
                        this._next_month_btn = new TopBarItemClass();

                    return this._next_month_btn;
                }
                set { this._next_month_btn = value; }
            }

            private TopBarItemClass _next_year_btn;
            /// <summary>
            /// 下一年按钮
            /// </summary>
            [Description("下一年按钮")]
            public TopBarItemClass next_year_btn
            {
                get
                {
                    if (this._next_year_btn == null)
                        this._next_year_btn = new TopBarItemClass();

                    return this._next_year_btn;
                }
                set { this._next_year_btn = value; }
            }
        }

        /// <summary>
        /// 顶部工具栏面板选项
        /// </summary>
        [Description("顶部工具栏面板选项")]
        public class TopBarItemClass
        {
            public Rectangle rect;
            /// <summary>
            /// 顶部工具栏选项rect
            /// </summary>
            [Description("顶部工具栏选项rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;
                    this.rect = value;
                }
            }

            private bool _ismovedown = false;
            /// <summary>
            ///  顶部工具栏选项是否按下鼠标
            /// </summary>
            [Description("顶部工具栏选项是否按下鼠标")]
            public bool ismovedown
            {
                get { return this._ismovedown; }
                set { this._ismovedown = value; }
            }

            private string text;
            /// <summary>
            /// 顶部工具栏选项文本
            /// </summary>
            [Description("顶部工具栏选项文本")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;
                    this.text = value;
                }
            }

            private Point[] lineLeftPointArr;
            /// <summary>
            /// 顶部工具栏选项按钮图形路径
            /// </summary>
            [Description("顶部工具栏选项按钮图形路径")]
            public Point[] LineLeftPointArr
            {
                get { return this.lineLeftPointArr; }
                set
                {
                    if (this.lineLeftPointArr == value)
                        return;
                    this.lineLeftPointArr = value;
                }
            }

            private Point[] lineRightPointArr;
            /// <summary>
            /// 顶部工具栏选项按钮图形路径
            /// </summary>
            [Description("顶部工具栏选项按钮图形路径")]
            public Point[] LineRightPointArr
            {
                get { return this.lineRightPointArr; }
                set
                {
                    if (this.lineRightPointArr == value)
                        return;
                    this.lineRightPointArr = value;
                }
            }

            private MoveStatuss moveStatus = MoveStatuss.Normal;
            /// <summary>
            /// 顶部工具栏选项鼠标状态
            /// </summary>
            [DefaultValue(MoveStatuss.Normal)]
            [Description("顶部工具栏选项鼠标状态")]
            public MoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                }
            }
        }

        #endregion

        #region 年月日

        /// <summary>
        /// 年面板
        /// </summary>
        [Description("年面板")]
        public class YearMainClass
        {
            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// 面板rect
            /// </summary>
            [Description("年面板rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;
                    this.rect = value;
                }
            }

            private YearMainItemClass[] _itemArr;
            /// <summary>
            /// 选项列表
            /// </summary>
            [Description("年选项列表")]
            public YearMainItemClass[] itemArr
            {
                get
                {
                    if (this._itemArr == null)
                    {
                        this._itemArr = new YearMainItemClass[12];
                        for (int i = 0; i < this._itemArr.Length; i++)
                        {
                            this._itemArr[i] = new YearMainItemClass();
                        }
                    }
                    return _itemArr;
                }
                set { _itemArr = value; }
            }

            private int _activeIndex = -2;
            /// <summary>
            /// 激活选项索引(年功能下：-2至14)(年月功能下： -3至14)(年月日功能下：-6至14、-6至15)
            /// </summary>
            [Description("激活选项索引(年功能下：-2至14)(年月功能下： -3至14)(年月日功能下：-6至14、-6至15)")]
            public int activeIndex
            {
                get { return this._activeIndex; }
                set
                {
                    if (this._activeIndex == value)
                        return;
                    this._activeIndex = value;
                }
            }
        }
        /// <summary>
        /// 月面板
        /// </summary>
        [Description("月面板")]
        public class MonthMainClass : YearMainClass
        {
            private MonthMainItemClass[] _itemArr;
            /// <summary>
            /// 选项列表
            /// </summary>
            [Description("年选项列表")]
            public new MonthMainItemClass[] itemArr
            {
                get
                {
                    if (this._itemArr == null)
                    {
                        this._itemArr = new MonthMainItemClass[12];
                        for (int i = 0; i < this._itemArr.Length; i++)
                        {
                            this._itemArr[i] = new MonthMainItemClass();
                        }
                    }
                    return _itemArr;
                }
                set { _itemArr = value; }
            }

            private int _activeIndex = -3;
            /// <summary>
            /// 激活选项索引(年月功能下： -3至14)(年月日功能下：-6至14、-6至15)
            /// </summary>
            [Description("激活选项索引(年月功能下： -3至14)(年月日功能下：-6至14、-6至15)")]
            public new int activeIndex
            {
                get { return this._activeIndex; }
                set
                {
                    if (this._activeIndex == value)
                        return;
                    this._activeIndex = value;
                }
            }
        }
        /// <summary>
        /// 月面板
        /// </summary>
        [Description("月面板")]
        public class DayMainClass : YearMainClass
        {
            private DayMainItemClass[] _itemArr;
            /// <summary>
            /// 选项列表
            /// </summary>
            [Description("年选项列表")]
            public new DayMainItemClass[] itemArr
            {
                get
                {
                    if (this._itemArr == null)
                    {
                        this._itemArr = new DayMainItemClass[49];
                        for (int i = 0; i < this._itemArr.Length; i++)
                        {
                            this._itemArr[i] = new DayMainItemClass();
                        }
                    }
                    return _itemArr;
                }
                set { _itemArr = value; }
            }

            private int _activeIndex = -6;
            /// <summary>
            /// 激活选项索引(年月日功能下：-6至-1至7至52)(年月日功时间面板能下：0至4)
            /// </summary>
            [Description("激活选项索引(年月日功能下：-6至-1至7至52)(年月日功时间面板能下：0至4)")]
            public new int activeIndex
            {
                get { return this._activeIndex; }
                set
                {
                    if (this._activeIndex == value)
                        return;
                    this._activeIndex = value;
                }
            }
        }
        /// <summary>
        /// 年面板选项
        /// </summary>
        [Description("年面板选项")]
        public class YearMainItemClass
        {
            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// 选项rect
            /// </summary>
            [Description("选项rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;
                    this.rect = value;
                }
            }

            private bool _ismovedown = false;
            /// <summary>
            ///  底部工具栏选项是否按下鼠标
            /// </summary>
            [Description("底部工具栏选项是否按下鼠标")]
            public bool ismovedown
            {
                get { return this._ismovedown; }
                set { this._ismovedown = value; }
            }

            private DateTime value;
            /// <summary>
            /// 选项值
            /// </summary>
            [Description("选项值")]
            public DateTime Value
            {
                get { return this.value; }
                set
                {
                    if (this.value == value)
                        return;
                    this.value = value;
                }
            }

            private string text = "";
            /// <summary>
            /// 选项文本
            /// </summary>
            [DefaultValue("")]
            [Description("选项文本")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;
                    this.text = value;
                }
            }

            private MoveStatuss moveStatus = MoveStatuss.Normal;
            /// <summary>
            /// 选项鼠标状态
            /// </summary>
            [DefaultValue(MoveStatuss.Normal)]
            [Description("选项鼠标状态")]
            public MoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                }
            }

            private DateItemTypes dateItemType = DateItemTypes.Normal;
            /// <summary>
            /// 日期选项类型
            /// </summary>
            [DefaultValue(MoveStatuss.Normal)]
            [Description("日期选项类型")]
            public DateItemTypes DateItemType
            {
                get { return this.dateItemType; }
                set
                {
                    if (this.dateItemType == value)
                        return;
                    this.dateItemType = value;
                }
            }
        }
        /// <summary>
        /// 月面板选项
        /// </summary>
        [Description("月面板选项")]
        public class MonthMainItemClass : YearMainItemClass
        {

        }
        /// <summary>
        /// 日面板选项
        /// </summary>
        [Description("日面板选项")]
        public class DayMainItemClass : YearMainItemClass
        {

        }

        #endregion

        #region 时间

        /// <summary>
        /// 时间面板
        /// </summary>
        [Description("时间面板")]
        public class TimeMainClass
        {
            private Rectangle topBarRect = Rectangle.Empty;
            /// <summary>
            ///  时间面板顶部rect
            /// </summary>
            [Description("时间面板顶部rect")]
            public Rectangle TopBarRect
            {
                get { return this.topBarRect; }
                set { this.topBarRect = value; }
            }

            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            ///  时间面板rect
            /// </summary>
            [Description("时间面板rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set { this.rect = value; }
            }


            private TimeMainHourArea hourArea = new TimeMainHourArea();
            /// <summary>
            /// 时间面板时区域
            /// </summary>
            [Description("时间面板时区域")]
            public TimeMainHourArea HourArea
            {
                get { return this.hourArea; }
                set { this.hourArea = value; }
            }

            private TimeMainMinuteArea minuteArea = new TimeMainMinuteArea();
            /// <summary>
            /// 时间面板分区域
            /// </summary>
            [Description("时间面板分区域")]
            public TimeMainMinuteArea MinuteArea
            {
                get { return this.minuteArea; }
                set { this.minuteArea = value; }
            }

            private TimeMainSecondArea secondArea = new TimeMainSecondArea();
            /// <summary>
            /// 时间面板秒区域
            /// </summary>
            [Description("时间面板秒区域")]
            public TimeMainSecondArea SecondArea
            {
                get { return this.secondArea; }
                set { this.secondArea = value; }
            }

        }
        /// <summary>
        /// 时间面板时区域
        /// </summary>
        [Description("时间面板时区域")]
        public class TimeMainHourArea
        {
            private RectangleF rect = Rectangle.Empty;
            /// <summary>
            ///  区域Rect
            /// </summary>
            [Description("区域Rect")]
            public RectangleF Rect
            {
                get { return this.rect; }
                set { this.rect = value; }
            }

            private bool _ismovedown = false;
            /// <summary>
            ///  区域是否按下鼠标
            /// </summary>
            [Description("区域鼠标按下的坐标")]
            public bool ismovedown
            {
                get { return this._ismovedown; }
                set { this._ismovedown = value; }
            }

            private Point _movedownpoint = Point.Empty;
            /// <summary>
            ///  区域鼠标按下的坐标
            /// </summary>
            [Description("区域鼠标按下的坐标")]
            public Point movedownpoint
            {
                get { return this._movedownpoint; }
                set { this._movedownpoint = value; }
            }

            private TimeMainHourItemClass[] _itemArr;
            /// <summary>
            /// 区域选项列表
            /// </summary>
            [Description("区域选项列表")]
            public TimeMainHourItemClass[] itemArr
            {
                get
                {
                    if (this._itemArr == null)
                    {
                        this._itemArr = new TimeMainHourItemClass[24];
                        for (int i = 0; i < this._itemArr.Length; i++)
                        {
                            this._itemArr[i] = new TimeMainHourItemClass() { Value = i, Text = i.ToString().PadLeft(2, '0') };
                        }
                    }

                    return this._itemArr;
                }
                set { this._itemArr = value; }
            }

            private MoveStatuss moveStatus;
            /// <summary>
            /// 区域选项鼠标状态
            /// </summary>
            [Description("区域选项鼠标状态")]
            public MoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set { this.moveStatus = value; }
            }

            private VerticalScroll _verticalScroll = new VerticalScroll();
            /// <summary>
            /// 区域垂直滚动条
            /// </summary>
            [Description("区域垂直滚动条")]
            public VerticalScroll verticalScroll
            {
                get { return this._verticalScroll; }
                set { this._verticalScroll = value; }
            }
        }
        /// <summary>
        /// 时间面板分区域
        /// </summary>
        [Description("时间面板分区域")]
        public class TimeMainMinuteArea : TimeMainHourArea
        {

            private TimeMainMinuteItemClass[] _itemArr;
            /// <summary>
            /// 区域选项列表
            /// </summary>
            [Description("区域选项列表")]
            public new TimeMainMinuteItemClass[] itemArr
            {
                get
                {
                    if (this._itemArr == null)
                    {
                        this._itemArr = new TimeMainMinuteItemClass[60];
                        for (int i = 0; i < this._itemArr.Length; i++)
                        {
                            this._itemArr[i] = new TimeMainMinuteItemClass() { Value = i, Text = i.ToString().PadLeft(2, '0') };
                        }
                    }

                    return this._itemArr;
                }
                set { this._itemArr = value; }
            }

        }
        /// <summary>
        /// 时间面板分区域
        /// </summary>
        [Description("时间面板分区域")]
        public class TimeMainSecondArea : TimeMainHourArea
        {

            private TimeMainSecondItemClass[] _itemArr;
            /// <summary>
            /// 区域选项列表
            /// </summary>
            [Description("区域选项列表")]
            public new TimeMainSecondItemClass[] itemArr
            {
                get
                {
                    if (this._itemArr == null)
                    {
                        this._itemArr = new TimeMainSecondItemClass[60];
                        for (int i = 0; i < this._itemArr.Length; i++)
                        {
                            this._itemArr[i] = new TimeMainSecondItemClass() { Value = i, Text = i.ToString().PadLeft(2, '0') };
                        }
                    }

                    return this._itemArr;
                }
                set { this._itemArr = value; }
            }

        }
        /// <summary>
        /// 时间面板时选项
        /// </summary>
        [Description("时间面板时选项")]
        public class TimeMainHourItemClass
        {
            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// 选项rect
            /// </summary>
            [Description("选项rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;
                    this.rect = value;
                }
            }

            private bool _ismovedown = false;
            /// <summary>
            ///  选项是否按下鼠标
            /// </summary>
            [Description("选项鼠标按下的坐标")]
            public bool ismovedown
            {
                get { return this._ismovedown; }
                set { this._ismovedown = value; }
            }

            public int value;
            /// <summary>
            /// 选项值
            /// </summary>
            [Description("选项值")]
            public int Value
            {
                get { return this.value; }
                set
                {
                    if (this.value == value)
                        return;
                    this.value = value;
                }
            }

            private string text = "";
            /// <summary>
            /// 选项文本
            /// </summary>
            [DefaultValue("")]
            [Description("选项文本")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;
                    this.text = value;
                }
            }

        }
        /// <summary>
        /// 时间面板分选项
        /// </summary>
        [Description("时间面板分选项")]
        public class TimeMainMinuteItemClass : TimeMainHourItemClass
        {

        }
        /// <summary>
        /// 时间面板秒选项
        /// </summary>
        [Description("时间面板秒选项")]
        public class TimeMainSecondItemClass : TimeMainHourItemClass
        {

        }
        /// <summary>
        /// 垂直滚动条
        /// </summary>
        [Description("垂直滚动条")]
        public class VerticalScroll
        {
            #region 属性

            /// <summary>
            /// 滚动条背景
            /// </summary>
            public ScrollClass scrollBack = new ScrollClass();
            [Description("滚动条背景")]
            public ScrollClass ScrollBack
            {
                get { return this.scrollBack; }
                set { this.scrollBack = value; }
            }

            private ScrollClass scrollSlide = new ScrollClass();
            /// <summary>
            /// 滚动条滑块
            /// </summary>
            [Description("滚动条滑块")]
            public ScrollClass ScrollSlide
            {
                get { return this.scrollSlide; }
                set { this.scrollSlide = value; }
            }

            public RectangleF displayRect = RectangleF.Empty;
            /// <summary>
            /// 内容显示区rect
            /// </summary>
            [Description("内容显示区rect")]
            public RectangleF DisplayRect
            {
                get { return this.displayRect; }
                set { this.displayRect = value; }
            }

            public RectangleF contentRect = RectangleF.Empty;
            /// <summary>
            /// 内容真实区rect
            /// </summary>
            [Description("内容真实区rect")]
            public RectangleF ContentRect
            {
                get { return this.contentRect; }
                set { this.contentRect = value; }
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 判断是否需要更新滚动条UI根据滚动条滑块偏移量
            /// </summary>
            /// <param name="offset">滚动条滑块偏移量</param>
            /// <returns>是否要刷新</returns>
            public bool IsResetScroll(int offset)
            {
                float y = this.ScrollSlide.Rect.Y + offset;
                if (y < this.ScrollBack.Rect.Y)
                    y = this.ScrollBack.Rect.Y;
                if (y > this.ScrollBack.Rect.Bottom - this.ScrollSlide.Rect.Height)
                    y = this.ScrollBack.Rect.Bottom - this.ScrollSlide.Rect.Height;

                if (this.ScrollSlide.Rect.Y != y)
                {
                    this.ScrollSlide.Rect = new RectangleF(this.ScrollSlide.Rect.X, y, this.ScrollSlide.Rect.Width, this.ScrollSlide.Rect.Height);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            #endregion

            #region 类

            /// <summary>
            /// 滚动条选项
            /// </summary>
            [Description("滚动条选项")]
            public class ScrollClass
            {
                private RectangleF rect = RectangleF.Empty;
                /// <summary>
                /// 选项rect
                /// </summary>
                [Description("选项rect")]
                public RectangleF Rect
                {
                    get { return this.rect; }
                    set { this.rect = value; }
                }

                private bool _ismovedown = false;
                /// <summary>
                ///  选项是否按下鼠标
                /// </summary>
                [Description("选项鼠标按下的坐标")]
                public bool ismovedown
                {
                    get { return this._ismovedown; }
                    set { this._ismovedown = value; }
                }

                private Point _movedownpoint = Point.Empty;
                /// <summary>
                ///  选项鼠标按下的坐标
                /// </summary>
                [Description("选项鼠标按下的坐标")]
                public Point movedownpoint
                {
                    get { return this._movedownpoint; }
                    set { this._movedownpoint = value; }
                }

                private MoveStatuss moveStatus = MoveStatuss.Normal;
                /// <summary>
                /// 选项鼠标状态
                /// </summary>
                [DefaultValue(MoveStatuss.Normal)]
                [Description("选项鼠标状态")]
                public MoveStatuss MoveStatus
                {
                    get { return this.moveStatus; }
                    set
                    {
                        if (this.moveStatus == value)
                            return;
                        this.moveStatus = value;
                    }
                }
            }

            #endregion
        }

        #endregion

        #region 底部工具栏

        /// <summary>
        /// 底部工具栏面板
        /// </summary>
        [Description("底部工具栏面板")]
        public class BottomBarClass
        {
            private Rectangle rect;
            /// <summary>
            /// 底部工具栏rect
            /// </summary>
            [Description("底部工具栏rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set { this.rect = value; }
            }

            private BottomBarItemClass _bottombar_minmaxborder_lab;
            /// <summary>
            /// 底部工具栏最小时间最大时间线
            /// </summary>
            [Description("底部工具栏最小时间最大时间线")]
            public BottomBarItemClass bottombar_minmaxborder_lab
            {
                get
                {
                    if (this._bottombar_minmaxborder_lab == null)
                        this._bottombar_minmaxborder_lab = new BottomBarItemClass() { Text = "", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_minmaxborder_lab;
                }
                set { this._bottombar_minmaxborder_lab = value; }
            }

            private BottomBarItemClass _bottombar_mindate_lab;
            /// <summary>
            /// 底部工具栏最小时间
            /// </summary>
            [Description("底部工具栏最小时间")]
            public BottomBarItemClass bottombar_mindate_lab
            {
                get
                {
                    if (this._bottombar_mindate_lab == null)
                        this._bottombar_mindate_lab = new BottomBarItemClass() { Text = "", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_mindate_lab;
                }
                set { this._bottombar_mindate_lab = value; }
            }

            private BottomBarItemClass _bottombar_maxdate_lab;
            /// <summary>
            /// 底部工具栏最大时间
            /// </summary>
            [Description("底部工具栏最大时间")]
            public BottomBarItemClass bottombar_maxdate_lab
            {
                get
                {
                    if (this._bottombar_maxdate_lab == null)
                        this._bottombar_maxdate_lab = new BottomBarItemClass() { Text = "", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_maxdate_lab;
                }
                set { this._bottombar_maxdate_lab = value; }
            }

            private BottomBarItemClass _bottombar_time_btn;
            /// <summary>
            /// 底部工具栏时间按钮
            /// </summary>
            [Description("底部工具栏时间按钮")]
            public BottomBarItemClass bottombar_time_btn
            {
                get
                {
                    if (this._bottombar_time_btn == null)
                        this._bottombar_time_btn = new BottomBarItemClass() { Text = "时间", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_time_btn;
                }
                set { this._bottombar_time_btn = value; }
            }

            private BottomBarItemClass _bottombar_clear_btn;
            /// <summary>
            /// 底部工具栏清除按钮
            /// </summary>
            [Description("底部工具栏清除按钮")]
            public BottomBarItemClass bottombar_clear_btn
            {
                get
                {
                    if (this._bottombar_clear_btn == null)
                        this._bottombar_clear_btn = new BottomBarItemClass() { Text = "清除", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_clear_btn;
                }
                set { this._bottombar_clear_btn = value; }
            }

            private BottomBarItemClass _bottombar_now_btn;
            /// <summary>
            /// 底部工具栏现在按钮
            /// </summary>
            [Description("底部工具栏现在按钮")]
            public BottomBarItemClass bottombar_now_btn
            {
                get
                {
                    if (this._bottombar_now_btn == null)
                        this._bottombar_now_btn = new BottomBarItemClass() { Text = "现在", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_now_btn;
                }
                set { this._bottombar_now_btn = value; }
            }

            private BottomBarItemClass _bottombar_confirm_btn;
            /// <summary>
            /// 底部工具栏确认按钮
            /// </summary>
            [Description("底部工具栏确认按钮")]
            public BottomBarItemClass bottombar_confirm_btn
            {
                get
                {
                    if (this._bottombar_confirm_btn == null)
                        this._bottombar_confirm_btn = new BottomBarItemClass() { Text = "确认", MoveStatus = MoveStatuss.Normal };

                    return this._bottombar_confirm_btn;
                }
                set { this._bottombar_confirm_btn = value; }
            }

        }

        /// <summary>
        /// 底部工具栏面板选项
        /// </summary>
        [Description("底部工具栏面板选项")]
        public class BottomBarItemClass
        {
            private Rectangle rect;
            /// <summary>
            /// 底部工具栏选项rect
            /// </summary>
            [Description("底部工具栏选项rect")]
            public Rectangle Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;
                    this.rect = value;
                }
            }

            private bool _ismovedown = false;
            /// <summary>
            ///  底部工具栏选项是否按下鼠标
            /// </summary>
            [Description("底部工具栏选项是否按下鼠标")]
            public bool ismovedown
            {
                get { return this._ismovedown; }
                set { this._ismovedown = value; }
            }

            private string text;
            /// <summary>
            ///底部工具栏选项文本
            /// </summary>
            [Description("底部工具栏选项文本")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;
                    this.text = value;
                }
            }

            private Point[] linePointArr;
            /// <summary>
            /// 底部工具栏选项按钮图形路径
            /// </summary>
            [Description("底部工具栏选项按钮图形路径")]
            public Point[] LinePointArr
            {
                get { return this.linePointArr; }
                set
                {
                    if (this.linePointArr == value)
                        return;
                    this.linePointArr = value;
                }
            }

            private MoveStatuss moveStatus = MoveStatuss.Normal;
            /// <summary>
            /// 底部工具栏选项鼠标状态
            /// </summary>
            [DefaultValue(MoveStatuss.Normal)]
            [Description("底部工具栏选项鼠标状态")]
            public MoveStatuss MoveStatus
            {
                get { return this.moveStatus; }
                set
                {
                    if (this.moveStatus == value)
                        return;
                    this.moveStatus = value;
                }
            }

            private BottomBarItemStatuss itemStatus = BottomBarItemStatuss.Normal;
            /// <summary>
            /// 底部工具栏按钮状态类型
            /// </summary>
            [DefaultValue(BottomBarItemStatuss.Normal)]
            [Description("底部工具栏按钮状态类型")]
            public BottomBarItemStatuss ItemStatus
            {
                get { return this.itemStatus; }
                set
                {
                    if (this.itemStatus == value)
                        return;
                    this.itemStatus = value;
                }
            }
        }

        #endregion

        #region 事件参数

        /// <summary>
        /// 顶部工具栏选项单击事件参数
        /// </summary>
        [Description("顶部工具栏选项单击事件参数")]
        public class TopBarIiemEventArgs : EventArgs
        {
            /// <summary>
            ///顶部工具栏选项文本
            /// </summary>
            [Description("时间面板选项文本")]
            public string Text { get; set; }
        }

        /// <summary>
        /// 年选项单击事件参数
        /// </summary>
        [Description("年选项单击事件参数")]
        public class YearMainItemEventArgs : EventArgs
        {
            /// <summary>
            /// 年选项
            /// </summary>
            [Description("年选项")]
            public YearMainItemClass Item { get; set; }
        }

        /// <summary>
        /// 月选项单击事件参数
        /// </summary>
        [Description("月选项单击事件参数")]
        public class MonthMainItemEventArgs : EventArgs
        {
            /// <summary>
            /// 月选项
            /// </summary>
            [Description("月选项")]
            public MonthMainItemClass Item { get; set; }
        }

        /// <summary>
        /// 日选项单击事件参数
        /// </summary>
        [Description("日选项单击事件参数")]
        public class DayMainItemEventArgs : EventArgs
        {
            /// <summary>
            /// 日选项
            /// </summary>
            [Description("日选项")]
            public DayMainItemClass Item { get; set; }
        }

        /// <summary>
        /// 时间面板时选项单击事件参数
        /// </summary>
        [Description("时间面板时选项单击事件参数")]
        public class TimeMainHourEventArgs : EventArgs
        {
            /// <summary>
            /// 选项值
            /// </summary>
            [Description("选项值")]
            public int Value { get; set; }

            /// <summary>
            ///选项文本
            /// </summary>
            [Description("选项文本")]
            public string Text { get; set; }
        }

        /// <summary>
        /// 时间面板分选项单击事件参数
        /// </summary>
        [Description("时间面板分选项单击事件参数")]
        public class TimeMainMinuteEventArgs : TimeMainHourEventArgs
        {

        }

        /// <summary>
        /// 时间面板秒选项单击事件参数
        /// </summary>
        [Description("时间面板秒选项单击事件参数")]
        public class TimeMainSecondEventArgs : TimeMainHourEventArgs
        {

        }

        /// <summary>
        /// 底部工具栏选项单击事件参数
        /// </summary>
        [Description("底部工具栏选项单击事件参数")]
        public class BottomBarIiemEventArgs : EventArgs
        {
            /// <summary>
            ///底部工具栏选项文本
            /// </summary>
            [Description("底部工具栏选项文本")]
            public string Text { get; set; }
        }

        /// <summary>
        /// 日期值更改事件参数
        /// </summary>
        [Description("日期值更改事件参数")]
        public class DateValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 更改前日期
            /// </summary>
            [Description("更改前日期")]
            public DateTime? OldDateValue { get; set; }
            /// <summary>
            /// 更改后日期
            /// </summary>
            [Description("更改后日期")]
            public DateTime? NewDateValue { get; set; }
        }

        /// <summary>
        /// 显示功能类型更改事件参数
        /// </summary>
        [Description("显示功能类型更改事件参数")]
        public class DateDisplayTypeChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 更改前显示功能类型
            /// </summary>
            [Description("更改前日期")]
            public DateDisplayTypes OldDateDisplayType { get; set; }
            /// <summary>
            /// 更改后显示功能类型
            /// </summary>
            [Description("更改后日期")]
            public DateDisplayTypes NewDateDisplayType { get; set; }
        }

        #endregion

        #endregion

        #region 枚举

        /// <summary>
        /// 显示功能类型
        /// </summary>
        [Description("显示功能类型")]
        public enum DateDisplayTypes
        {
            /// <summary>
            /// 年
            /// </summary>
            Year,
            /// <summary>
            /// 年月
            /// </summary>
            YearMonth,
            /// <summary>
            /// 年月日
            /// </summary>
            YearMonthDay,
            /// <summary>
            /// 年月日时
            /// </summary>
            YearMonthDayHour,
            /// <summary>
            /// 年月日时分
            /// </summary>
            YearMonthDayHourMinute,
            /// <summary>
            /// 年月日时分秒
            /// </summary>
            YearMonthDayHourMinuteSecond
        }

        /// <summary>
        /// 在指定显示功能类型下面板显示状态
        /// </summary>
        [Browsable(false)]
        [Description("在指定显示功能类型下面板显示状态")]
        public enum DateDisplayStatuss
        {
            /// <summary>
            /// 功能默认面板【年面板->年】【年月面板->月】【年月日面板->日】【年月日时间面板->日】
            /// </summary>
            Default,
            /// <summary>
            /// 年月功能中(年面板)
            /// </summary>
            YearMonth_Year,
            /// <summary>
            /// 年月日功能中(月面板)
            /// </summary>
            YearMonthDay_Month,
            /// <summary>
            /// 年月日功能中(年面板)
            /// </summary>
            YearMonthDay_Year,
            /// <summary>
            /// 年月日功能中(时间面板)
            /// </summary>
            YearMonthDay_Time
        }

        /// <summary>
        /// 选项的鼠标状态
        /// </summary>
        [Description("选项的鼠标状态")]
        public enum MoveStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter
        }

        /// <summary>
        /// 日期选项类型
        /// </summary>
        [Description("日期选项类型")]
        public enum DateItemTypes
        {
            /// <summary>
            /// 标题
            /// </summary>
            Title,
            /// <summary>
            /// 过期日期
            /// </summary>
            Past,
            /// <summary>
            /// 正常日期
            /// </summary>
            Normal,
            /// <summary>
            /// 未来日期
            /// </summary>
            Future,
            /// <summary>
            /// 禁用
            /// </summary>
            Disabled
        }

        /// <summary>
        /// 底部工具栏按钮状态类型
        /// </summary>
        [Description("底部工具栏按钮状态类型")]
        public enum BottomBarItemStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 禁用
            /// </summary>
            Disabled
        }

        /// <summary>
        /// 键盘方向键使激活索引偏移类型
        /// </summary>
        [Description("键盘方向键使激活索引偏移类型")]
        public enum KeyOffsetTypes
        {
            /// <summary>
            /// 左
            /// </summary>
            Left,
            /// <summary>
            /// 右
            /// </summary>
            Right,
            /// <summary>
            /// 上
            /// </summary>
            Up,
            /// <summary>
            /// 下
            /// </summary>
            Down
        }

        #endregion
    }

}
