
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
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design;
using WinformControlLibraryExtension.Design;
using System.Drawing.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 数字时间控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("数字时间控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class NumberTimeExt : Control
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 时间更改事件
        /// </summary>
        [Description("时间更改事件")]
        public event ValueChangedEventHandler ValueChanged
        {
            add { this.valueChanged += value; }
            remove { this.valueChanged -= value; }
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
        public new event EventHandler TabIndexChanged
        {
            add { base.TabIndexChanged += value; }
            remove { base.TabIndexChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add { base.TabStopChanged += value; }
            remove { base.TabStopChanged -= value; }
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

        private int lineWidth = 6;
        /// <summary>
        /// 线宽度(必须偶数)
        /// </summary>
        [DefaultValue(6)]
        [Description("线宽度(必须偶数)")]
        public int LineWidth
        {
            get { return this.lineWidth; }
            set
            {
                if (this.lineWidth == value || value % 2 != 0)
                    return;
                this.lineWidth = value;
                this.InitializeNumberTimeRectangle();
                this.Invalidate();
            }
        }

        private Color lineHighlightColor = Color.FromArgb(147, 112, 219);
        /// <summary>
        /// 线高亮颜色
        /// </summary>
        [DefaultValue(typeof(Color), "147, 112, 219")]
        [Description("线高亮颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LineHighlightColor
        {
            get { return this.lineHighlightColor; }
            set
            {
                if (this.lineHighlightColor == value)
                    return;
                this.lineHighlightColor = value;
                if (this.HourLineHighlightColor == Color.Empty)
                    this.highlight_hour_pen.Color = value;
                if (this.MinuteLineHighlightColor == Color.Empty)
                    this.highlight_minute_pen.Color = value;
                if (this.SecondLineHighlightColor == Color.Empty)
                    this.highlight_second_pen.Color = value;
                if (this.MillisecondLineHighlightColor == Color.Empty)
                    this.highlight_millisecond_pen.Color = value;

                this.split_sb.Color = value;
                this.Invalidate();
            }
        }

        private bool shadowShow = true;
        /// <summary>
        /// 是否显示线阴影
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示线阴影")]
        public bool ShadowShow
        {
            get { return this.shadowShow; }
            set
            {
                if (this.shadowShow == value)
                    return;
                this.shadowShow = value;
                this.Invalidate();
            }
        }

        private Color lineShadowColor = Color.FromArgb(220, 220, 220);
        /// <summary>
        /// 线阴影颜色
        /// </summary>
        [DefaultValue(typeof(Color), "220, 220, 220")]
        [Description("线阴影颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LineShadowColor
        {
            get { return this.lineShadowColor; }
            set
            {
                if (this.lineShadowColor == value)
                    return;
                this.lineShadowColor = value;
                this.Invalidate();
            }
        }

        private Color hourLineHighlightColor = Color.Empty;
        /// <summary>
        /// 小时高亮颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("小时高亮颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color HourLineHighlightColor
        {
            get { return this.hourLineHighlightColor; }
            set
            {
                if (this.hourLineHighlightColor == value)
                    return;
                this.hourLineHighlightColor = value;
                if (value == Color.Empty)
                    this.highlight_hour_pen.Color = this.LineHighlightColor;
                else
                    this.highlight_hour_pen.Color = value;
                this.Invalidate();
            }
        }

        private Color minuteLineHighlightColor = Color.Empty;
        /// <summary>
        /// 分钟高亮颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("分钟高亮颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color MinuteLineHighlightColor
        {
            get { return this.minuteLineHighlightColor; }
            set
            {
                if (this.minuteLineHighlightColor == value)
                    return;
                this.minuteLineHighlightColor = value;
                if (value == Color.Empty)
                    this.highlight_minute_pen.Color = this.LineHighlightColor;
                else
                    this.highlight_minute_pen.Color = value;
                this.Invalidate();
            }
        }

        private Color secondLineHighlightColor = Color.Empty;
        /// <summary>
        /// 秒高亮颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("秒高亮颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SecondLineHighlightColor
        {
            get { return this.secondLineHighlightColor; }
            set
            {
                if (this.secondLineHighlightColor == value)
                    return;
                this.secondLineHighlightColor = value;
                if (value == Color.Empty)
                    this.highlight_second_pen.Color = this.LineHighlightColor;
                else
                    this.highlight_second_pen.Color = value;
                this.Invalidate();
            }
        }

        private Color millisecondLineHighlightColor = Color.Empty;
        /// <summary>
        /// 毫秒高亮颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("毫秒高亮颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color MillisecondLineHighlightColor
        {
            get { return this.millisecondLineHighlightColor; }
            set
            {
                if (this.millisecondLineHighlightColor == value)
                    return;
                this.millisecondLineHighlightColor = value;
                if (value == Color.Empty)
                    this.highlight_millisecond_pen.Color = this.LineHighlightColor;
                else
                    this.highlight_millisecond_pen.Color = value;
                this.Invalidate();
            }
        }

        private DateTime value = DateTime.MinValue;
        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        public DateTime Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value)
                    return;
                this.value = value;
                this.Invalidate();

                this.OnValueChanged(new ValueChangedEventArgs() { Value = value });
            }
        }

        private NumberTimeFormats timeTypeFormat = NumberTimeFormats.HourMinuteSecond;
        /// <summary>
        /// 时间显示格式
        /// </summary>
        [DefaultValue(NumberTimeFormats.HourMinuteSecond)]
        [Description("时间显示格式")]
        public NumberTimeFormats TimeTypeFormat
        {
            get { return this.timeTypeFormat; }
            set
            {
                if (this.timeTypeFormat == value)
                    return;
                this.timeTypeFormat = value;
                this.InitializeNumberTimeRectangle();
                this.Invalidate();
            }
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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(280, 80);
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
        public new int TabIndex
        {
            get { return 0; }
            set { base.TabIndex = 0; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
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
        /// 笔帽的一半
        /// </summary>
        private float cap_c = 0f;
        /// <summary>
        /// 数字笔画横向宽度
        /// </summary>
        private float line_w = 0f;
        /// <summary>
        /// 数字笔画纵向高度
        /// </summary>
        private float line_h = 0f;

        private RectangleF hour1_rect;
        private RectangleF hour2_rect;

        private RectangleF split1_rect;
        private RectangleF minute1_rect;
        private RectangleF minute2_rect;

        private RectangleF split2_rect;
        private RectangleF second1_rect;
        private RectangleF second2_rect;

        private RectangleF split3_rect;
        private RectangleF millisecond1_rect;
        private RectangleF millisecond2_rect;
        private RectangleF millisecond3_rect;

        private Pen highlight_hour_pen;
        private Pen highlight_minute_pen;
        private Pen highlight_second_pen;
        private Pen highlight_millisecond_pen;
        private Pen shadow_pen;
        private SolidBrush split_sb;
        #endregion

        public NumberTimeExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.InitializeNumberTimeRectangle();

            this.highlight_hour_pen = new Pen(this.HourLineHighlightColor == Color.Empty ? this.LineHighlightColor : this.HourLineHighlightColor, this.LineWidth);
            this.highlight_hour_pen.StartCap = LineCap.Triangle;
            this.highlight_hour_pen.EndCap = LineCap.Triangle;
            this.highlight_minute_pen = new Pen(this.MinuteLineHighlightColor == Color.Empty ? this.LineHighlightColor : this.MinuteLineHighlightColor, this.LineWidth);
            this.highlight_minute_pen.StartCap = LineCap.Triangle;
            this.highlight_minute_pen.EndCap = LineCap.Triangle;
            this.highlight_second_pen = new Pen(this.SecondLineHighlightColor == Color.Empty ? this.LineHighlightColor : this.SecondLineHighlightColor, this.LineWidth);
            this.highlight_second_pen.StartCap = LineCap.Triangle;
            this.highlight_second_pen.EndCap = LineCap.Triangle;
            this.highlight_millisecond_pen = new Pen(this.MillisecondLineHighlightColor == Color.Empty ? this.LineHighlightColor : this.MillisecondLineHighlightColor, this.LineWidth);
            this.highlight_millisecond_pen.StartCap = LineCap.Triangle;
            this.highlight_millisecond_pen.EndCap = LineCap.Triangle;
            this.shadow_pen = new Pen(this.lineShadowColor, this.LineWidth);
            this.shadow_pen.StartCap = LineCap.Triangle;
            this.shadow_pen.EndCap = LineCap.Triangle;
            this.split_sb = new SolidBrush(this.lineHighlightColor);

        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Value == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (this.TimeTypeFormat == NumberTimeFormats.Hour)
            {
                this.draw_num(g, this.highlight_hour_pen, this.hour1_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(0, 1)));
                this.draw_num(g, this.highlight_hour_pen, this.hour2_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(1, 1)));
            }
            else if (this.TimeTypeFormat == NumberTimeFormats.HourMinute)
            {
                this.draw_num(g, this.highlight_hour_pen, this.hour1_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(0, 1)));
                this.draw_num(g, this.highlight_hour_pen, this.hour2_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(1, 1)));

                this.draw_split(g, split_sb, this.split1_rect);
                this.draw_num(g, this.highlight_minute_pen, this.minute1_rect, this.shadow_pen, int.Parse(this.Value.ToString("mm").Substring(0, 1)));
                this.draw_num(g, this.highlight_minute_pen, this.minute2_rect, this.shadow_pen, int.Parse(this.Value.ToString("mm").Substring(1, 1)));
            }
            else if (this.TimeTypeFormat == NumberTimeFormats.HourMinuteSecond)
            {
                this.draw_num(g, this.highlight_hour_pen, this.hour1_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(0, 1)));
                this.draw_num(g, this.highlight_hour_pen, this.hour2_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(1, 1)));

                this.draw_split(g, split_sb, this.split1_rect);
                this.draw_num(g, this.highlight_minute_pen, this.minute1_rect, this.shadow_pen, int.Parse(this.Value.ToString("mm").Substring(0, 1)));
                this.draw_num(g, this.highlight_minute_pen, this.minute2_rect, this.shadow_pen, int.Parse(this.Value.ToString("mm").Substring(1, 1)));

                this.draw_split(g, split_sb, this.split2_rect);
                this.draw_num(g, this.highlight_second_pen, this.second1_rect, this.shadow_pen, int.Parse(this.Value.ToString("ss").Substring(0, 1)));
                this.draw_num(g, this.highlight_second_pen, this.second2_rect, this.shadow_pen, int.Parse(this.Value.ToString("ss").Substring(1, 1)));
            }
            else if (this.TimeTypeFormat == NumberTimeFormats.HourMinuteSecondMillisecond)
            {
                this.draw_num(g, this.highlight_hour_pen, this.hour1_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(0, 1)));
                this.draw_num(g, this.highlight_hour_pen, this.hour2_rect, this.shadow_pen, int.Parse(this.Value.ToString("HH").Substring(1, 1)));

                this.draw_split(g, split_sb, this.split1_rect);
                this.draw_num(g, this.highlight_minute_pen, this.minute1_rect, this.shadow_pen, int.Parse(this.Value.ToString("mm").Substring(0, 1)));
                this.draw_num(g, this.highlight_minute_pen, this.minute2_rect, this.shadow_pen, int.Parse(this.Value.ToString("mm").Substring(1, 1)));

                this.draw_split(g, split_sb, this.split2_rect);
                this.draw_num(g, this.highlight_second_pen, this.second1_rect, this.shadow_pen, int.Parse(this.Value.ToString("ss").Substring(0, 1)));
                this.draw_num(g, this.highlight_second_pen, this.second2_rect, this.shadow_pen, int.Parse(this.Value.ToString("ss").Substring(1, 1)));

                this.draw_split(g, split_sb, this.split3_rect);
                this.draw_num(g, this.highlight_millisecond_pen, this.millisecond1_rect, this.shadow_pen, int.Parse(this.Value.ToString("fff").Substring(0, 1)));
                this.draw_num(g, this.highlight_millisecond_pen, this.millisecond2_rect, this.shadow_pen, int.Parse(this.Value.ToString("fff").Substring(1, 1)));
                this.draw_num(g, this.highlight_millisecond_pen, this.millisecond3_rect, this.shadow_pen, int.Parse(this.Value.ToString("fff").Substring(2, 1)));
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeNumberTimeRectangle();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.highlight_hour_pen != null)
                    this.highlight_hour_pen.Dispose();
                if (this.highlight_minute_pen != null)
                    this.highlight_minute_pen.Dispose();
                if (this.highlight_second_pen != null)
                    this.highlight_second_pen.Dispose();
                if (this.highlight_millisecond_pen != null)
                    this.highlight_millisecond_pen.Dispose();
                if (this.shadow_pen != null)
                    this.shadow_pen.Dispose();
                if (this.split_sb != null)
                    this.split_sb.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            if (this.valueChanged != null)
            {
                this.valueChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化数字时间Rectangle
        /// </summary>
        private void InitializeNumberTimeRectangle()
        {
            this.cap_c = (float)this.LineWidth / 2f;
            this.line_w = (float)this.LineWidth * 4;
            this.line_h = this.line_w;

            float rectf_w = this.line_w + this.LineWidth + 2;
            float rectf_h = this.line_h * 2 + this.LineWidth + 4;

            float split_w = this.LineWidth * 3;

            float start_x = 0f;
            if (this.TimeTypeFormat == NumberTimeFormats.Hour)
            {
                start_x = (this.ClientRectangle.Width - (rectf_w * 2 + this.LineWidth)) / 2f;
            }
            else if (this.TimeTypeFormat == NumberTimeFormats.HourMinute)
            {
                start_x = (this.ClientRectangle.Width - (rectf_w * 4 + this.LineWidth * 2 + split_w)) / 2f;
            }
            else if (this.TimeTypeFormat == NumberTimeFormats.HourMinuteSecond)
            {
                start_x = (this.ClientRectangle.Width - (rectf_w * 6 + this.LineWidth * 3 + split_w * 2)) / 2f;
            }
            else if (this.TimeTypeFormat == NumberTimeFormats.HourMinuteSecondMillisecond)
            {
                start_x = (this.ClientRectangle.Width - (rectf_w * 9 + this.LineWidth * 5 + split_w * 3)) / 2f;
            }
            float start_y = (this.ClientRectangle.Height - rectf_h) / 2f;


            this.hour1_rect = new RectangleF(start_x, start_y, rectf_w, rectf_h);
            this.hour2_rect = new RectangleF(this.hour1_rect.Right + this.LineWidth, start_y, rectf_w, rectf_h);

            this.split1_rect = new RectangleF(this.hour2_rect.Right, start_y, split_w, rectf_h);
            this.minute1_rect = new RectangleF(this.split1_rect.Right, start_y, rectf_w, rectf_h);
            this.minute2_rect = new RectangleF(this.minute1_rect.Right + this.LineWidth, start_y, rectf_w, rectf_h);

            this.split2_rect = new RectangleF(this.minute2_rect.Right, start_y, split_w, rectf_h);
            this.second1_rect = new RectangleF(this.split2_rect.Right, start_y, rectf_w, rectf_h);
            this.second2_rect = new RectangleF(this.second1_rect.Right + this.LineWidth, start_y, rectf_w, rectf_h);

            this.split3_rect = new RectangleF(this.second2_rect.Right, start_y, split_w, rectf_h);
            this.millisecond1_rect = new RectangleF(this.split3_rect.Right, start_y, rectf_w, rectf_h);
            this.millisecond2_rect = new RectangleF(this.millisecond1_rect.Right + this.LineWidth, start_y, rectf_w, rectf_h);
            this.millisecond3_rect = new RectangleF(this.millisecond2_rect.Right + this.LineWidth, start_y, rectf_w, rectf_h);

        }


        #region 绘制数字笔画
        //
        //    ---        1
        //    | |      11  12
        //    ---        2
        //    | |      21  22
        //    ---        3
        //
        private void draw_vertical_11(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = bounds_rect.X + this.cap_c;
            float y1 = bounds_rect.Y + this.LineWidth + 1;
            float x2 = bounds_rect.X + this.cap_c;
            float y2 = bounds_rect.Y + this.line_h + 1;
            g.DrawLine(pen, x1, y1, x2, y2);
        }
        private void draw_vertical_21(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = bounds_rect.X + this.cap_c;
            float y1 = bounds_rect.Y + this.LineWidth + this.line_h + 3;
            float x2 = bounds_rect.X + this.cap_c;
            float y2 = bounds_rect.Y + this.line_h + this.line_h + 3;
            g.DrawLine(pen, x1, y1, x2, y2);
        }

        private void draw_horizontal_1(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = 1 + bounds_rect.X + this.LineWidth;
            float y1 = bounds_rect.Y + this.cap_c;
            float x2 = 1 + bounds_rect.X + this.line_w;
            float y2 = bounds_rect.Y + this.cap_c;
            g.DrawLine(pen, x1, y1, x2, y2);
        }
        private void draw_horizontal_2(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = 1 + bounds_rect.X + this.LineWidth;
            float y1 = 2 + bounds_rect.Y + this.cap_c + this.line_h;
            float x2 = 1 + bounds_rect.X + this.line_w;
            float y2 = 2 + bounds_rect.Y + this.cap_c + this.line_h;
            g.DrawLine(pen, x1, y1, x2, y2);
        }
        private void draw_horizontal_3(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = 1 + bounds_rect.X + this.LineWidth;
            float y1 = 4 + bounds_rect.Y + this.cap_c + this.line_h + this.line_h;
            float x2 = 1 + bounds_rect.X + this.line_w;
            float y2 = 4 + bounds_rect.Y + this.cap_c + this.line_h + this.line_h;
            g.DrawLine(pen, x1, y1, x2, y2);
        }

        private void draw_vertical_12(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = bounds_rect.X + this.cap_c + 2 + this.line_w;
            float y1 = bounds_rect.Y + this.LineWidth + 1;
            float x2 = bounds_rect.X + this.cap_c + 2 + this.line_w;
            float y2 = bounds_rect.Y + this.line_h + 1;
            g.DrawLine(pen, x1, y1, x2, y2);
        }
        private void draw_vertical_22(Graphics g, Pen pen, RectangleF bounds_rect)
        {
            float x1 = bounds_rect.X + this.cap_c + 2 + this.line_w;
            float y1 = bounds_rect.Y + this.LineWidth + this.line_h + +3;
            float x2 = bounds_rect.X + this.cap_c + 2 + this.line_w;
            float y2 = bounds_rect.Y + this.line_h + this.line_h + 3;
            g.DrawLine(pen, x1, y1, x2, y2);
        }
        #endregion

        #region 绘制数字
        private void draw_0(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            this.draw_vertical_11(g, highlight_pen, bounds_rect);
            this.draw_vertical_21(g, highlight_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_horizontal_2(g, shadow_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_1(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            if (this.ShadowShow)
                this.draw_vertical_11(g, shadow_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_21(g, shadow_pen, bounds_rect);

            if (this.ShadowShow)
                this.draw_horizontal_1(g, shadow_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_horizontal_2(g, shadow_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_horizontal_3(g, shadow_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_2(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            if (this.ShadowShow)
                this.draw_vertical_11(g, shadow_pen, bounds_rect);
            this.draw_vertical_21(g, highlight_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_22(g, shadow_pen, bounds_rect);
        }
        private void draw_3(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            if (this.ShadowShow)
                this.draw_vertical_11(g, shadow_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_21(g, shadow_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_4(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            this.draw_vertical_11(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_21(g, shadow_pen, bounds_rect);

            if (this.ShadowShow)
                this.draw_horizontal_1(g, shadow_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_horizontal_3(g, shadow_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_5(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            this.draw_vertical_11(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_21(g, shadow_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            if (this.ShadowShow)
                this.draw_vertical_12(g, shadow_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_6(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            this.draw_vertical_11(g, highlight_pen, bounds_rect);
            this.draw_vertical_21(g, highlight_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            if (this.ShadowShow)
                this.draw_vertical_12(g, shadow_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_7(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            if (this.ShadowShow)
                this.draw_vertical_11(g, shadow_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_21(g, shadow_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_horizontal_2(g, shadow_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_horizontal_3(g, shadow_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_8(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            this.draw_vertical_11(g, highlight_pen, bounds_rect);
            this.draw_vertical_21(g, highlight_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_9(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen)
        {
            this.draw_vertical_11(g, highlight_pen, bounds_rect);
            if (this.ShadowShow)
                this.draw_vertical_21(g, shadow_pen, bounds_rect);

            this.draw_horizontal_1(g, highlight_pen, bounds_rect);
            this.draw_horizontal_2(g, highlight_pen, bounds_rect);
            this.draw_horizontal_3(g, highlight_pen, bounds_rect);

            this.draw_vertical_12(g, highlight_pen, bounds_rect);
            this.draw_vertical_22(g, highlight_pen, bounds_rect);
        }
        private void draw_split(Graphics g, SolidBrush highlight_sb, RectangleF bounds_rect)
        {
            RectangleF top_rect = new RectangleF(bounds_rect.X + (bounds_rect.Width - this.LineWidth) / 2, bounds_rect.Y + (bounds_rect.Height / 2 - this.LineWidth) / 2, this.LineWidth, this.LineWidth);
            RectangleF bottom_rect = new RectangleF(bounds_rect.X + (bounds_rect.Width - this.LineWidth) / 2, bounds_rect.Y + bounds_rect.Height / 2 + (bounds_rect.Height / 2 - this.LineWidth) / 2, this.LineWidth, this.LineWidth);
            g.FillEllipse(highlight_sb, top_rect);
            g.FillEllipse(highlight_sb, bottom_rect);
        }

        /// <summary>
        /// 绘制数字
        /// </summary>
        /// <param name="g"></param>
        /// <param name="highlight_pen">数字高亮颜色</param>
        /// <param name="bounds_rect">数字的rect</param>
        /// <param name="shadow_pen">数字阴影颜色</param>
        /// <param name="num">数字</param>
        private void draw_num(Graphics g, Pen highlight_pen, RectangleF bounds_rect, Pen shadow_pen, int num)
        {
            switch (num)
            {
                case 0:
                    {
                        this.draw_0(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 1:
                    {
                        this.draw_1(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 2:
                    {
                        this.draw_2(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 3:
                    {
                        this.draw_3(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 4:
                    {
                        this.draw_4(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 5:
                    {
                        this.draw_5(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 6:
                    {
                        this.draw_6(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 7:
                    {
                        this.draw_7(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 8:
                    {
                        this.draw_8(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
                case 9:
                    {
                        this.draw_9(g, highlight_pen, bounds_rect, shadow_pen);
                        break;
                    }
            }
        }
        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 时间更改事件参数
        /// </summary>
        [Description("时间更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 时间值
            /// </summary>
            [Description("时间值")]
            public DateTime Value { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 时间显示格式
        /// </summary>
        [Description("时间显示格式")]
        public enum NumberTimeFormats
        {
            /// <summary>
            /// 时
            /// </summary>
            Hour,
            /// <summary>
            /// 时分
            /// </summary>
            HourMinute,
            /// <summary>
            /// 时分秒
            /// </summary>
            HourMinuteSecond,
            /// <summary>
            /// 时分秒毫秒
            /// </summary>
            HourMinuteSecondMillisecond,
        }

        #endregion

    }
}
