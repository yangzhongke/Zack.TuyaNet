
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 温度计控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("温度计控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class ThermometerExt : Control, IAnimationStaticTimer
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 温度值更改事件
        /// </summary>
        [Description("温度值更改事件")]
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

        private int animationTime = 150;
        /// <summary>
        /// 动画时间(毫秒)
        /// </summary>
        [DefaultValue(150)]
        [Description("动画时间(毫秒)")]
        public int AnimationTime
        {
            get { return this.animationTime; }
            set
            {
                if (this.animationTime == value)
                    return;

                this.options.AllTransformTime = value;
                this.animationTime = value;
            }
        }

        private bool animationActive = true;
        /// <summary>
        /// 是否启动动画
        /// </summary>
        [DefaultValue(true)]
        [Description("是否启动动画")]
        public bool AnimationActive
        {
            get { return this.animationActive; }
            set
            {
                if (this.animationActive == value)
                    return;

                this.animationActive = value;
            }
        }

        private int circleRadius = 10;
        /// <summary>
        /// 温度计圆点半径
        /// </summary>
        [DefaultValue(10)]
        [Description("温度计圆点半径")]
        public int CircleRadius
        {
            get { return this.circleRadius; }
            set
            {
                if (this.circleRadius == value)
                    return;

                this.circleRadius = value;
                this.Invalidate();
            }
        }

        private bool textShow = true;
        /// <summary>
        /// 是否显示文本
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示文本")]
        public bool TextShow
        {
            get { return this.textShow; }
            set
            {
                if (this.textShow == value)
                    return;
                this.textShow = value;
                this.Invalidate();
            }
        }

        private bool scaleShow = true;
        /// <summary>
        /// 是否显示刻度线
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示刻度线")]
        public bool ScaleShow
        {
            get { return this.scaleShow; }
            set
            {
                if (this.scaleShow == value)
                    return;
                this.scaleShow = value;
                this.Invalidate();
            }
        }

        private ScaleDirection scaleDirectionType = ScaleDirection.Left;
        /// <summary>
        /// 刻度线显示位置
        /// </summary>
        [DefaultValue(ScaleDirection.Left)]
        [Description("刻度线显示位置")]
        public ScaleDirection ScaleDirectionType
        {
            get { return this.scaleDirectionType; }
            set
            {
                if (this.scaleDirectionType == value)
                    return;
                this.scaleDirectionType = value;
                this.Invalidate();
            }
        }

        private Color scaleLineColor = Color.DimGray;
        /// <summary>
        /// 刻度线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("刻度线颜色")]
        public Color ScaleLineColor
        {
            get { return this.scaleLineColor; }
            set
            {
                if (this.scaleLineColor == value)
                    return;
                this.scaleLineColor = value;
                this.Invalidate();
            }
        }

        private int scaleCutCount = 5;
        /// <summary>
        /// 一个间隔刻度分割成多少个子刻度
        /// </summary>
        [DefaultValue(5)]
        [Description("一个间隔刻度分割成多少个子刻度")]
        public int ScaleCutCount
        {
            get { return this.scaleCutCount; }
            set
            {
                if (this.scaleCutCount == value || value < 1)
                    return;
                this.scaleCutCount = value;
                this.Invalidate();
            }
        }

        private Color scaleCutLineColor = Color.DimGray;
        /// <summary>
        /// 子刻度颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("子刻度颜色")]
        public Color TcaleCutLineColor
        {
            get { return this.scaleCutLineColor; }
            set
            {
                if (this.scaleCutLineColor == value)
                    return;
                this.scaleCutLineColor = value;
                this.Invalidate();
            }
        }

        private bool scaleTextShow = true;
        /// <summary>
        /// 是否显示刻度线值
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示刻度线值")]
        public bool ScaleTextShow
        {
            get { return this.scaleTextShow; }
            set
            {
                if (this.scaleTextShow == value)
                    return;
                this.scaleTextShow = value;
                this.Invalidate();
            }
        }

        private Font scaleTextFont = new Font("宋体", 10);
        /// <summary>
        /// 刻度线值字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 10pt")]
        [Description("刻度线值字体")]
        public Font ScaleTextFont
        {
            get { return this.scaleTextFont; }
            set
            {
                if (this.scaleTextFont == value)
                    return;
                this.scaleTextFont = value;
                this.Invalidate();
            }
        }

        private Color scaleTextColor = Color.DimGray;
        /// <summary>
        /// 刻度线文字颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("刻度线文字颜色")]
        public Color ScaleTextColor
        {
            get { return this.scaleTextColor; }
            set
            {
                if (this.scaleTextColor == value)
                    return;
                this.scaleTextColor = value;
                this.Invalidate();
            }
        }

        private float intervalValue = 10f;
        /// <summary>
        /// 间隔刻度大小
        /// </summary>
        [DefaultValue(10f)]
        [Description("间隔刻度大小")]
        public float IntervalValue
        {
            get { return this.intervalValue; }
            set
            {
                if (this.intervalValue == value)
                    return;
                this.intervalValue = value;
                this.Invalidate();
            }
        }


        private Color pipeBackColor = Color.White;
        /// <summary>
        /// 管内背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("管内背景颜色")]
        public Color PipeBackColor
        {
            get { return this.pipeBackColor; }
            set
            {
                if (this.pipeBackColor == value)
                    return;

                this.pipeBackColor = value;
                this.Invalidate();
            }
        }


        private int borderWidth = 3;
        /// <summary>
        /// 边框宽度
        /// </summary>
        [DefaultValue(3)]
        [Description("边框宽度")]
        public int BorderWidth
        {
            get { return this.borderWidth; }
            set
            {
                if (this.borderWidth == value)
                    return;
                this.borderWidth = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.DimGray;
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
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

        private Color valueBackColor = Color.Tomato;
        /// <summary>
        /// 值背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Tomato")]
        [Description("值背景颜色")]
        public Color ValueBackColor
        {
            get { return this.valueBackColor; }
            set
            {
                if (this.valueBackColor == value)
                    return;
                this.valueBackColor = value;
                this.Invalidate();
            }
        }

        private float maxValue = 100f;
        /// <summary>
        /// 最大值
        /// </summary>
        [DefaultValue(100f)]
        [Description("最大值")]
        public float MaxValue
        {
            get { return this.maxValue; }
            set
            {
                if (this.maxValue == value || value < this.minValue)
                    return;
                this.maxValue = value;
                this.Invalidate();
            }
        }

        private float minValue = -20f;
        /// <summary>
        /// 最小值
        /// </summary>
        [DefaultValue(-20f)]
        [Description("最小值")]
        public float MinValue
        {
            get { return this.minValue; }
            set
            {
                if (this.minValue == value || value > this.maxValue)
                    return;
                this.minValue = value;
                this.Invalidate();
            }
        }

        private float value = 0f;
        /// <summary>
        /// 当前值
        /// </summary>
        [DefaultValue(0f)]
        [Description("当前值")]
        public float Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value)
                    return;

                this.value = value;
                if (this.AnimationActive && this.Enabled && this.Visible && this.DesignMode == false)
                {
                    this.animation_start_value = this.animation_current_value;
                    this.animation_current_value = this.animation_start_value;
                    this.animation_end_value = value;

                    this.usedTime = 0;
                    AnimationStaticTimer.AnimationStart(this);
                    this.Invalidate();
                }
                else
                {
                    this.animation_current_value = value;
                    this.Invalidate();
                }

                this.OnValueChanged(new ValueChangedEventArgs() { Value = value });
            }
        }

        #endregion

        #region 重写属性

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text == value)
                    return;

                base.Text = value;
                this.Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(80, 220);
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
        /// 动画开始值
        /// </summary>
        private float animation_start_value = 0f;
        /// <summary>
        /// 动画结束值
        /// </summary>
        private float animation_end_value = 0f;
        /// <summary>
        /// 动画当前值
        /// </summary>
        private float animation_current_value = 0f;
        /// <summary>
        /// 动画已使用的时间
        /// </summary>
        private double usedTime = 0;
        /// <summary>
        /// 动画参数
        /// </summary>
        private AnimationOptions options = new AnimationOptions() { AllTransformTime = 150 };

        private readonly int angle = 45;
        private readonly int paddingBottom = 10;
        private readonly int paddingTop = 10;
        private readonly int paddingRight = 6;
        private readonly int paddingLeft = 6;
        private readonly int lineExtent = 10;

        #endregion

        public ThermometerExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int diameter = this.circleRadius * 2;
            Rectangle bounds_rect = this.ClientRectangle;
            RectangleF text_rect = new RectangleF(0, 0, 0, 0);//文本rect
            if (this.TextShow)
            {
                SizeF text_size = g.MeasureString(this.Text, this.Font);
                text_rect.Width = text_size.Width;
                text_rect.Height = text_size.Height;
                text_rect.X = bounds_rect.X + ((float)bounds_rect.Width - text_size.Width) / 2f;
                text_rect.Y = bounds_rect.Bottom - text_size.Height;
            }
            float scale_width = (float)Math.Sqrt(Math.Pow(this.CircleRadius, 2) * 2);//温度计刻度部分rect的宽度
            float scale_height = bounds_rect.Height - this.paddingBottom - text_rect.Height - this.CircleRadius - scale_width / 2f - scale_width / 2f - this.paddingTop;
            Rectangle circle_rect = new Rectangle(this.paddingLeft, bounds_rect.Bottom - this.paddingBottom - (int)text_rect.Height - diameter, diameter, diameter);//圆的rect
            if (this.scaleDirectionType == ScaleDirection.Right)
            {
                circle_rect.X = bounds_rect.Right - this.paddingRight - diameter;
            }
            RectangleF scale_rect = new RectangleF(circle_rect.X + (this.circleRadius - scale_width / 2f), bounds_rect.Y + this.paddingTop + scale_width / 2f, scale_width, scale_height);//温度计刻度部分rect

            float sumValue = 0;
            if (this.MaxValue > 0 && this.MinValue >= 0)
            {
                sumValue = this.MaxValue - this.MinValue;
            }
            else if (this.MaxValue > 0 && this.MinValue < 0)
            {
                sumValue = this.MaxValue - this.MinValue;
            }
            else if (this.MaxValue < 0 && this.MinValue < 0)
            {
                sumValue = Math.Abs(this.MinValue) - Math.Abs(this.MaxValue);
            }

            #region Text
            if (this.TextShow)
            {
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                g.DrawString(this.Text, this.Font, text_sb, text_rect.X, text_rect.Y);
                text_sb.Dispose();
            }
            #endregion

            GraphicsPath border_gp = new GraphicsPath();
            border_gp.AddArc(circle_rect, 270 + (90 - this.angle), 360 - (90 - this.angle) * 2);
            border_gp.AddArc(new RectangleF(circle_rect.X + (circle_rect.Width - scale_width) / 2f, this.paddingTop, scale_width, scale_width), 180, 180);
            border_gp.CloseFigure();
            #region 管内背景色
            SolidBrush pipeback_sb = new SolidBrush(this.PipeBackColor);
            g.FillPath(pipeback_sb, border_gp);
            pipeback_sb.Dispose();
            #endregion

            #region 值背景
            SolidBrush value_sb = new SolidBrush(this.ValueBackColor);
            GraphicsPath value_gp = new GraphicsPath();
            value_gp.AddArc(circle_rect, 270 + (90 - this.angle), 360 - (90 - this.angle) * 2);
            if (this.animation_current_value < this.MaxValue)
            {
                float x = circle_rect.X + (circle_rect.Width - scale_width) / 2f;
                float y = scale_rect.Bottom - scale_height / (sumValue / (this.animation_current_value + Math.Abs(this.MinValue)));
                value_gp.AddLine(x, y, x + scale_width, y);
            }
            else
            {
                float x = circle_rect.X + (circle_rect.Width - scale_width) / 2f;
                float y = this.paddingTop;
                value_gp.AddArc(new RectangleF(x, y, scale_width, scale_width), 180, 180);
            }
            value_gp.CloseFigure();
            g.FillPath(value_sb, value_gp);
            value_gp.Dispose();
            value_sb.Dispose();
            #endregion

            #region 边框
            Pen border_pen = new Pen(this.BorderColor, this.BorderWidth);
            g.DrawPath(border_pen, border_gp);
            border_pen.Dispose();
            #endregion

            border_gp.Dispose();

            g.SmoothingMode = sm;

            #region  刻度

            if (this.ScaleShow)
            {
                Pen scaleLine_pen = new Pen(this.ScaleLineColor, 2);
                Pen scaleCutLine_pen = new Pen(this.scaleCutLineColor, 1);
                SolidBrush scaleLineText_sb = new SolidBrush(this.ScaleTextColor);

                float maxValueYU = Math.Abs(this.MaxValue % this.IntervalValue);
                float minValueYU = Math.Abs(this.MinValue % this.IntervalValue);
                int count = 0;
                float v = sumValue;
                if (maxValueYU != 0)
                    v -= maxValueYU;
                if (minValueYU != 0)
                    v -= minValueYU;
                count = (int)(v / this.IntervalValue);//分了多少个间隔

                //count*pixel+(maxValueYU/this.TickFrequency)*pixel+(minValueYU/this.TickFrequency)*pixel=scale_height;
                float pixel = scale_height / (count + maxValueYU / this.IntervalValue + minValueYU / this.IntervalValue);//一个间隔代表像素

                if (maxValueYU != 0)
                    count++;
                if (minValueYU != 0)
                    count++;
                float line_y = scale_rect.Bottom;
                float str = 0;
                for (int i = 0; i <= count; i++)
                {
                    if (i == 0)
                    {
                        str = this.MinValue;
                    }
                    else if (i == 1)
                    {
                        if (minValueYU != 0)
                        {
                            line_y -= (minValueYU / this.IntervalValue) * pixel;
                            str += minValueYU;
                        }
                        else
                        {
                            line_y -= pixel;
                            str += this.IntervalValue;
                        }
                    }
                    else if (i == count)
                    {
                        if (maxValueYU != 0)
                        {
                            line_y -= (maxValueYU / this.IntervalValue) * pixel;
                            str += maxValueYU;
                        }
                        else
                        {
                            line_y -= pixel;
                            str += this.IntervalValue;
                        }
                    }
                    else
                    {
                        line_y -= pixel;
                        str += this.IntervalValue;
                    }
                    float line_x1 = scale_rect.Right;
                    float line_x2 = scale_rect.Right + this.lineExtent;
                    if (this.scaleDirectionType == ScaleDirection.Right)
                    {
                        line_x1 = scale_rect.X - this.lineExtent;
                        line_x2 = scale_rect.X;
                    }
                    g.DrawLine(scaleLine_pen, line_x1, line_y, line_x2, line_y);


                    #region 子刻度线
                    if (this.ScaleCutCount > 1)
                    {
                        float group_y = line_y;
                        if (!((i == 0) || (i == 1 && minValueYU != 0) || (i == count && maxValueYU != 0)))//排除第一个和不完整的
                        {
                            for (int j = 0; j < this.ScaleCutCount - 1; j++)
                            {
                                group_y += pixel / this.ScaleCutCount;
                                float group_x1 = scale_rect.Right;
                                float group_x2 = scale_rect.Right + (float)this.lineExtent / 2f;
                                if (this.scaleDirectionType == ScaleDirection.Right)
                                {
                                    group_x1 = scale_rect.X - (float)this.lineExtent / 2f;
                                    group_x2 = scale_rect.X;
                                }
                                g.DrawLine(scaleCutLine_pen, group_x1, group_y, group_x2, group_y);
                            }
                        }
                    }
                    #endregion

                    #region  刻度值
                    if (this.scaleTextShow)
                    {
                        SizeF str_size = g.MeasureString(str.ToString(), this.Font);
                        float text_x1 = line_x2;
                        if (this.scaleDirectionType == ScaleDirection.Right)
                        {
                            text_x1 = scale_rect.X - this.lineExtent - str_size.Width;
                        }
                        g.DrawString(str.ToString(), this.ScaleTextFont, scaleLineText_sb, text_x1, line_y - str_size.Height / 2f);
                    }
                    #endregion

                }
                scaleLineText_sb.Dispose();
                scaleCutLine_pen.Dispose();
                scaleLine_pen.Dispose();
            }
            #endregion


        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.DesignMode)
                return;

            if (this.Enabled)
            {

            }
            else
            {
                this.animation_current_value = this.Value;
                AnimationStaticTimer.AnimationStop(this);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.DesignMode)
                return;

            if (this.Visible)
            {

            }
            else
            {
                this.animation_current_value = this.Value;
                AnimationStaticTimer.AnimationStop(this);
            }
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

        #region 公开方法

        /// <summary>
        /// 值更改动画中(禁止手动调用)
        /// </summary>
        [Description("值更改动画中(禁止手动调用)")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Animationing()
        {
            bool finish = false;
            this.usedTime += AnimationStaticTimer.timer.Interval;
            if (this.usedTime > this.options.AllTransformTime)
            {
                this.usedTime = this.options.AllTransformTime;
                AnimationStaticTimer.AnimationStop(this);
                finish = true;
            }

            double progress = AnimationTimer.GetProgress(AnimationTypes.EaseOut, this.options, this.usedTime);
            if (finish)
            {
                if (progress < 0)
                    progress = 0;
                if (progress > 1)
                    progress = 1;

                this.usedTime = 0;
            }

            this.animation_current_value = (float)(this.animation_start_value + (this.animation_end_value - this.animation_start_value) * progress);
            this.Invalidate();
        }
        #endregion

        #region 类

        /// <summary>
        /// 温度值更改事件参数
        /// </summary>
        [Description("温度值更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 温度值
            /// </summary>
            [Description("温度值")]
            public float Value { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 刻度线显示位置
        /// </summary>
        [Description("刻度线显示位置")]
        public enum ScaleDirection
        {
            /// <summary>
            /// 左
            /// </summary>
            Left,
            /// <summary>
            /// 右
            /// </summary>
            Right
        }

        #endregion
    }
}
