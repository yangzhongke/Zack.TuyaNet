
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 水波纹进度控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("水波纹进度控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class WaveProgressExt : Control, IAnimationStaticTimer
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 值更改事件
        /// </summary>
        [Description("值更改事件")]
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

        private WaveProgressStyles style = WaveProgressStyles.Circle;
        /// <summary>
        /// 外观类型
        /// </summary>
        [DefaultValue(WaveProgressStyles.Circle)]
        [Description("外观类型")]
        public WaveProgressStyles Style
        {
            get { return this.style; }
            set
            {
                if (this.style == value)
                    return;
                this.style = value;
                this.Invalidate();
            }
        }

        private bool animationActive = false;
        /// <summary>
        /// 是否启动动画
        /// </summary>
        [DefaultValue(false)]
        [Description("是否启动动画")]
        public bool AnimationActive
        {
            get { return this.animationActive; }
            set
            {
                if (this.animationActive == value)
                    return;
                this.animationActive = value;
                this.Invalidate();

                if (!this.DesignMode)
                {
                    if (this.animationActive && this.Enabled && this.Visible)
                    {
                        AnimationStaticTimer.AnimationStart(this);
                    }
                    else
                    {
                        AnimationStaticTimer.AnimationStop(this);
                    }
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

        private Color borderColor = Color.FromArgb(104, 135, 206, 250);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "104, 135, 206, 250")]
        [Description("边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
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

        #region 水波纹

        private int waveInterval = 5;
        /// <summary>
        /// 水波纹移动速度
        /// </summary>
        [DefaultValue(5)]
        [Description("水波纹移动速度")]
        public int WaveInterval
        {
            get { return this.waveInterval; }
            set
            {
                if (this.waveInterval == value || value < 0)
                    return;
                this.waveInterval = value;
            }
        }

        private float waveTension = 0.5f;
        /// <summary>
        /// 水波纹曲线的张力(0-1)
        /// </summary>
        [DefaultValue(0.5f)]
        [Description("水波纹曲线的张力(0-1)")]
        public float WaveTension
        {
            get { return this.waveTension; }
            set
            {
                if (this.waveTension == value || value < 0 || value > 1)
                    return;
                this.waveTension = value;
                this.InitializeWaveProgressRectangle();
                this.Invalidate();
            }
        }

        private int waveWidth = 30;
        /// <summary>
        /// 水波纹宽度
        /// </summary>
        [DefaultValue(30)]
        [Description("水波纹宽度")]
        public int WaveWidth
        {
            get { return this.waveWidth; }
            set
            {
                if (this.waveWidth == value || value < 1)
                    return;
                this.waveWidth = value;
                this.InitializeWaveProgressRectangle();
                this.Invalidate();
            }
        }

        private int waveHeight = 10;
        /// <summary>
        /// 水波纹高度
        /// </summary>
        [DefaultValue(10)]
        [Description("水波纹高度")]
        public int WaveHeight
        {
            get { return this.waveHeight; }
            set
            {
                if (this.waveHeight == value || value < 1)
                    return;
                this.waveHeight = value;
                this.InitializeWaveProgressRectangle();
                this.Invalidate();
            }
        }

        private Color waveBackColor = Color.Empty;
        /// <summary>
        /// 水波纹背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("水波纹背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color WaveBackColor
        {
            get { return this.waveBackColor; }
            set
            {
                if (this.waveBackColor == value)
                    return;
                this.waveBackColor = value;
                this.Invalidate();
            }
        }

        private Color waveFrontColor = Color.FromArgb(104, 135, 206, 250);
        /// <summary>
        /// 水波纹前方颜色
        /// </summary>
        [DefaultValue(typeof(Color), "104, 135, 206, 250")]
        [Description("水波纹前方颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color WaveFrontColor
        {
            get { return this.waveFrontColor; }
            set
            {
                if (this.waveFrontColor == value)
                    return;
                this.waveFrontColor = value;
                this.Invalidate();
            }
        }

        private Color waveBehindColor = Color.FromArgb(104, 135, 206, 250);
        /// <summary>
        /// 水波纹后方颜色
        /// </summary>
        [DefaultValue(typeof(Color), "104, 135, 206, 250")]
        [Description("水波纹后方颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color WaveBehindColor
        {
            get { return this.waveBehindColor; }
            set
            {
                if (this.waveBehindColor == value)
                    return;
                this.waveBehindColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 进度值

        private bool valueShow = true;
        /// <summary>
        /// 是否显示进度值
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示进度值")]
        public bool ValueShow
        {
            get { return this.valueShow; }
            set
            {
                if (this.valueShow == value)
                    return;
                this.valueShow = value;
                this.Invalidate();
            }
        }

        private float value = 0.0f;
        /// <summary>
        /// 进度值(0-1)
        /// </summary>
        [DefaultValue(0.0f)]
        [Description("进度值(0-1)")]
        public float Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value)
                    return;

                if (value > 1)
                    value = 1;
                if (value < 0)
                    value = 0;
                this.value = value;
                this.Invalidate();

                this.OnValueChanged(new ValueChangedEventArgs() { Value = value });
            }
        }

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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 100); ;
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
        /// 水波纹移动距离
        /// </summary>
        private int wave_distance = 0;
        /// <summary>
        /// 前面水波纹坐标
        /// </summary>
        private List<Point> waveFrontPointList = new List<Point>();
        /// <summary>
        /// 后面水波纹坐标
        /// </summary>
        private List<Point> waveBehindPointList = new List<Point>();

        /// <summary>
        /// 水波纹动画累加时间
        /// </summary>
        private double waveAccumulationTime = 0;

        #endregion

        public WaveProgressExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.Font = new Font("宋体", 13, FontStyle.Bold);
            this.ForeColor = Color.FromArgb(110, 123, 104, 238);

            this.InitializeWaveProgressRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle;
            int border = 2;

            if (this.Style == WaveProgressStyles.Circle)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(rect);
                g.SetClip(gp);
                gp.Dispose();
            }

            #region 水波纹背景
            if (this.WaveBackColor != Color.Empty)
            {
                SolidBrush waveback_sb = new SolidBrush(this.WaveBackColor);
                if (this.Style == WaveProgressStyles.Circle)
                    g.FillEllipse(waveback_sb, new Rectangle(rect.X + border, rect.Y + border, rect.Width - border * 2, rect.Height - border * 2));
                else
                    g.FillRectangle(waveback_sb, new Rectangle(rect.X, rect.Y, rect.Width - border, rect.Height - border));
                waveback_sb.Dispose();
            }
            #endregion

            #region 水波纹
            if (this.waveFrontPointList.Count > 0)
            {
                SolidBrush behind_sb = new SolidBrush(this.WaveBehindColor);
                SolidBrush front_sb = new SolidBrush(this.WaveFrontColor);

                Point[] behindPoint = new Point[this.waveFrontPointList.Count + 2];
                Point[] frontPoint = new Point[this.waveFrontPointList.Count + 2];

                int value_h = (int)(this.Value * rect.Height);
                for (int i = 0; i < this.waveFrontPointList.Count; i++)
                {
                    behindPoint[i] = new Point(this.waveBehindPointList[i].X - this.wave_distance, rect.Bottom - this.waveBehindPointList[i].Y - value_h + (int)((float)this.WaveHeight / 3f));
                    frontPoint[i] = new Point(this.waveFrontPointList[i].X + this.wave_distance, rect.Bottom - this.waveFrontPointList[i].Y - value_h);
                }

                behindPoint[this.waveFrontPointList.Count] = new Point(behindPoint[this.waveFrontPointList.Count - 1].X, rect.Bottom);
                behindPoint[this.waveFrontPointList.Count + 1] = new Point(behindPoint[0].X, rect.Bottom);

                frontPoint[this.waveFrontPointList.Count] = new Point(frontPoint[this.waveFrontPointList.Count - 1].X, rect.Bottom);
                frontPoint[this.waveFrontPointList.Count + 1] = new Point(frontPoint[0].X, rect.Bottom);

                g.FillClosedCurve(behind_sb, behindPoint, FillMode.Alternate, this.WaveTension);
                g.FillClosedCurve(front_sb, frontPoint, FillMode.Alternate, this.WaveTension);
                front_sb.Dispose();
                behind_sb.Dispose();

                #region 进度值
                if (this.ValueShow)
                {
                    string value_str = (this.Value * 100).ToString("F0").PadLeft(3, ' ') + "%";
                    SizeF value_size = g.MeasureString(value_str, this.Font, new Size());
                    RectangleF value_rect = new RectangleF((rect.Width - value_size.Width) / 2f, (rect.Height - value_size.Height) / 2f, value_size.Width, value_size.Height);
                    SolidBrush text_sb = new SolidBrush(this.ForeColor);

                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.DrawString(value_str, this.Font, text_sb, value_rect);
                    text_sb.Dispose();
                }
                #endregion

                #region 边框
                if (this.Style == WaveProgressStyles.Circle)
                {
                    Pen back_pen = new Pen(this.BackColor);
                    g.DrawEllipse(back_pen, rect);
                    back_pen.Dispose();

                    if (this.BorderShow)
                    {
                        Pen border_pen = new Pen(this.WaveFrontColor, border);
                        g.DrawEllipse(border_pen, new Rectangle(rect.X + border, rect.Y + border, rect.Width - border * 2, rect.Height - border * 2));
                        border_pen.Dispose();
                    }
                }
                else
                {
                    if (this.BorderShow)
                    {
                        Pen border_pen = new Pen(this.BorderColor, border);
                        g.DrawRectangle(border_pen, new Rectangle(rect.X, rect.Y, rect.Width - border, rect.Height - border));
                        border_pen.Dispose();
                    }
                }
                #endregion

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
                if (this.AnimationActive || this.Visible)
                {
                    AnimationStaticTimer.AnimationStart(this);
                }
            }
            else
            {
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
                if (this.AnimationActive || this.Enabled)
                {
                    AnimationStaticTimer.AnimationStart(this);
                }
            }
            else
            {
                AnimationStaticTimer.AnimationStop(this);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeWaveProgressRectangle();
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
        /// 水波纹移动动画中(禁止手动调用)
        /// </summary>
        [Description("水波纹移动动画中(禁止手动调用)")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Animationing()
        {
            this.waveAccumulationTime += AnimationStaticTimer.timer.Interval;
            if (this.waveAccumulationTime > 100)
            {
                this.waveAccumulationTime = 0;

                this.wave_distance += this.WaveInterval;
                if (this.wave_distance >= this.WaveWidth * 2)
                {
                    this.wave_distance = 0;
                }

                this.Invalidate();
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化水波纹Rectangle
        /// </summary>
        private void InitializeWaveProgressRectangle()
        {
            this.waveFrontPointList.Clear();
            this.waveBehindPointList.Clear();
            int startFront_x = this.ClientRectangle.X - this.WaveWidth * 4;
            int start_y = 0;
            int startBehind_x = this.ClientRectangle.Right + this.WaveWidth * 4;

            int i = 0;
            while (true)
            {
                startFront_x += this.WaveWidth;
                startBehind_x -= this.WaveWidth;
                start_y = this.WaveHeight * (i % 2);
                this.waveFrontPointList.Add(new Point(startFront_x, start_y));
                this.waveBehindPointList.Add(new Point(startBehind_x, start_y));
                if (startFront_x >= this.ClientRectangle.Right && start_y == 0)
                {
                    this.wave_distance = 0;
                    return;
                }
                i++;
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 值更改事件参数
        /// </summary>
        [Description("值更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 值
            /// </summary>
            [Description("值")]
            public float Value { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 外观风格类型
        /// </summary>
        [Description("外观风格类型")]
        public enum WaveProgressStyles
        {
            /// <summary>
            /// 四边形
            /// </summary>
            Quadrangle,
            /// <summary>
            /// 圆形
            /// </summary>
            Circle
        }

        #endregion
    }

}
