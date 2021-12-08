
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
using System.Drawing.Text;
using System.Windows.Forms;
using WcleAnimationLibrary;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// Switch开关按钮控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("Switch开关按钮控件")]
    [DefaultProperty("Status")]
    [DefaultEvent("StatusChanged")]
    public class SwitchButtonExt : Control, IAnimationStaticTimer
    {
        #region 新增事件

        public delegate void CheckedChangedEventHandler(object sender, CheckedChangedEventArgs e);

        private event CheckedChangedEventHandler checkedChanged;
        /// <summary>
        /// 开关状态更改事件
        /// </summary>
        [Description("开关状态更改事件")]
        public event CheckedChangedEventHandler CheckedChanged
        {
            add { this.checkedChanged += value; }
            remove { this.checkedChanged -= value; }
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
        public new event EventHandler BackColorChanged
        {
            add { base.BackColorChanged += value; }
            remove { base.BackColorChanged -= value; }
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

        private SwitchSlideStyles style = SwitchSlideStyles.Quadrangle;
        /// <summary>
        /// 开关类型
        /// </summary>
        [DefaultValue(SwitchSlideStyles.Quadrangle)]
        [Description("开关类型")]
        public SwitchSlideStyles Style
        {
            get { return this.style; }
            set
            {
                if (this.style == value)
                    return;
                this.style = value;
                this.InitializeButtomSwitchRectangle();
                this.Invalidate();
            }
        }

        private int borderThickness = 0;
        /// <summary>
        /// 背景边框画笔大小
        /// </summary>
        [DefaultValue(0)]
        [Description("背景边框画笔大小")]
        public int BorderThickness
        {
            get { return this.borderThickness; }
            set
            {
                if (this.borderThickness == value || value < 0)
                    return;
                this.borderThickness = value;
                this.InitializeButtomSwitchRectangle();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 滑块动画滑动时间(毫秒)
        /// </summary>
        [DefaultValue(150)]
        [Description("滑块动画滑动时间(毫秒)")]
        public int SlideTime
        {
            get { return (int)this.options.AllTransformTime; }
            set
            {
                if (this.options.AllTransformTime == value)
                    return;
                this.options.AllTransformTime = value;
            }
        }

        private int slideRadius = 5;
        /// <summary>
        /// 滑块圆角大小(限于SwitchButtomTypes.Quadrangle)
        /// </summary>
        [DefaultValue(5)]
        [Description("滑块圆角大小(限于SwitchButtomTypes.Quadrangle)")]
        public int SlideRadius
        {
            get { return this.slideRadius; }
            set
            {
                if (this.slideRadius == value)
                    return;
                this.slideRadius = value;
                if (this.Style == SwitchSlideStyles.Quadrangle)
                {
                    this.InitializeButtomSwitchRectangle();
                    this.Invalidate();
                }
            }
        }

        private int slideBorderThickness = 0;
        /// <summary>
        /// 滑块边框画笔大小
        /// </summary>
        [DefaultValue(0)]
        [Description("滑块边框画笔大小")]
        public int SlideBorderThickness
        {
            get { return this.slideBorderThickness; }
            set
            {
                if (this.slideBorderThickness == value || value < 0)
                    return;
                this.slideBorderThickness = value;
                this.InitializeButtomSwitchRectangle();
                this.Invalidate();
            }
        }

        private Color activateColor = Color.Gray;
        /// <summary>
        /// 控件激活的虚线框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
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

        private string checkedText = "开";
        /// <summary>
        /// 开启文本
        /// </summary>
        [DefaultValue("开")]
        [Description("开启文本")]
        public string CheckedText
        {
            get { return this.checkedText; }
            set
            {
                if (this.checkedText == value)
                    return;
                this.checkedText = value;
                this.Invalidate();
            }
        }

        private string unCheckedText = "关";
        /// <summary>
        /// 关闭文本
        /// </summary>
        [DefaultValue("关")]
        [Description("关闭文本")]
        public string UnCheckedText
        {
            get { return this.unCheckedText; }
            set
            {
                if (this.unCheckedText == value)
                    return;
                this.unCheckedText = value;
                this.Invalidate();
            }
        }

        private bool _Checked = false;
        /// <summary>
        /// 开关状态
        /// </summary>
        [DefaultValue(false)]
        [Description("开关状态")]
        public bool Checked
        {
            get { return this._Checked; }
            set
            {
                if (this._Checked == value)
                    return;
                this._Checked = value;
                this.usedTime = 0;
                this.InitializeButtomSwitchRectangle();
                this.Invalidate();

                if (!this.DesignMode)
                {
                    this.OnCheckedChanged(new CheckedChangedEventArgs() { Checked = this._Checked });
                }
            }
        }

        #region（关闭）

        private Color unCheckedBackColor = Color.FromArgb(245, 165, 166);
        /// <summary>
        /// 背景颜色（关闭）
        /// </summary>
        [DefaultValue(typeof(Color), "245, 165, 166")]
        [Description("背景颜色（关闭）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedBackColor
        {
            get { return this.unCheckedBackColor; }
            set
            {
                if (this.unCheckedBackColor == value)
                    return;
                this.unCheckedBackColor = value;
                this.Invalidate();
            }
        }

        private Color unCheckedBorderColor = Color.FromArgb(245, 165, 166);
        /// <summary>
        /// 背景边框颜色（关闭）
        /// </summary>
        [DefaultValue(typeof(Color), "245, 165, 166")]
        [Description("背景边框颜色（关闭）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedBorderColor
        {
            get { return this.unCheckedBorderColor; }
            set
            {
                if (this.unCheckedBorderColor == value)
                    return;
                this.unCheckedBorderColor = value;
                this.Invalidate();
            }
        }

        private Color unCheckedSlideBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 滑块颜色（关闭）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("滑块颜色（关闭）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedSlideBackColor
        {
            get { return this.unCheckedSlideBackColor; }
            set
            {
                if (this.unCheckedSlideBackColor == value)
                    return;
                this.unCheckedSlideBackColor = value;
                this.Invalidate();
            }
        }

        private Color unCheckedSlideBorderColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 滑块边框颜色（关闭）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("滑块边框颜色（关闭）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedSlideBorderColor
        {
            get { return this.unCheckedSlideBorderColor; }
            set
            {
                if (this.unCheckedSlideBorderColor == value)
                    return;
                this.unCheckedSlideBorderColor = value;
                this.InitializeButtomSwitchRectangle();
                this.Invalidate();
            }
        }

        private Color unCheckedTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 文本颜色（关闭）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("文本颜色（关闭）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color UnCheckedTextColor
        {
            get { return this.unCheckedTextColor; }
            set
            {
                if (this.unCheckedTextColor == value)
                    return;
                this.unCheckedTextColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region （开启）

        private Color checkedBackColor = Color.FromArgb(167, 204, 233);
        /// <summary>
        /// 背景颜色颜色（开启）
        /// </summary>
        [DefaultValue(typeof(Color), "167, 204, 233")]
        [Description("背景颜色颜色（开启）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedBackColor
        {
            get { return this.checkedBackColor; }
            set
            {
                if (this.checkedBackColor == value)
                    return;
                this.checkedBackColor = value;
                this.Invalidate();
            }
        }

        private Color checkedSlideBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 滑块颜色（开启）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("滑块颜色（开启）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color CheckedSlideBackColor
        {
            get { return this.checkedSlideBackColor; }
            set
            {
                if (this.checkedSlideBackColor == value)
                    return;
                this.checkedSlideBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region （禁止）
        private Color disableBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 背景颜色颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("背景颜色颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableBackColor
        {
            get { return this.disableBackColor; }
            set
            {
                if (this.disableBackColor == value)
                    return;
                this.disableBackColor = value;
                this.Invalidate();
            }
        }

        private Color disableBorderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 背景边框颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("背景边框颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableBorderColor
        {
            get { return this.disableBorderColor; }
            set
            {
                if (this.disableBorderColor == value)
                    return;
                this.disableBorderColor = value;
                this.Invalidate();
            }
        }

        private Color disableSlideBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 滑块颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("滑块颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableSlideBackColor
        {
            get { return this.disableSlideBackColor; }
            set
            {
                if (this.disableSlideBackColor == value)
                    return;
                this.disableSlideBackColor = value;
                this.Invalidate();
            }
        }

        private Color disableSlideBorderColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 滑块边框颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("滑块边框颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableSlideBorderColor
        {
            get { return this.disableSlideBorderColor; }
            set
            {
                if (this.disableSlideBorderColor == value)
                    return;
                this.disableSlideBorderColor = value;
                this.InitializeButtomSwitchRectangle();
                this.Invalidate();
            }
        }

        private Color disableTextColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 文本颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("文本颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color DisableTextColor
        {
            get { return this.disableTextColor; }
            set
            {
                if (this.disableTextColor == value)
                    return;
                this.disableTextColor = value;
                this.Invalidate();
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
                return new Size(90, 30);
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
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
            set
            {
                base.BackColor = Color.Transparent;
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
        /// 滑块信息
        /// </summary>
        private SwitchSlide switchSlide = new SwitchSlide();

        /// <summary>
        /// 动画中
        /// </summary>
        private bool slideing = false;

        /// <summary>
        /// 选项文字垂直居中
        /// </summary>
        private static StringFormat text_sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
        /// <summary>
        /// 动画已使用的时间
        /// </summary>
        private double usedTime = 0;
        /// <summary>
        /// 动画参数
        /// </summary>
        private AnimationOptions options = new AnimationOptions() { AllTransformTime = 150 };
        #endregion

        public SwitchButtonExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.Font = new Font("宋体", 11, FontStyle.Bold);

            this.InitializeButtomSwitchRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;


            Color back_color = Color.Empty;
            Color border_color = Color.Empty;
            Color slide_back_color = Color.Empty;
            Color slide_border_color = Color.Empty;
            Color text_color = Color.Empty;
            if (this.Enabled)
            {
                back_color = this.Checked ? this.CheckedBackColor : this.UnCheckedBackColor;
                border_color = this.UnCheckedBorderColor;
                slide_back_color = this.Checked ? this.CheckedSlideBackColor : this.UnCheckedSlideBackColor;
                slide_border_color = this.UnCheckedSlideBorderColor;
                text_color = this.UnCheckedTextColor;
            }
            else
            {
                back_color = this.DisableBackColor;
                border_color = this.DisableBorderColor;
                slide_back_color = this.DisableSlideBackColor;
                slide_border_color = this.DisableSlideBorderColor;
                text_color = this.DisableTextColor;
            }

            switch (this.Style)
            {
                case SwitchSlideStyles.Quadrangle:
                    {
                        this.DrawQuadrangle(g, back_color, border_color, slide_back_color, slide_border_color, text_color);
                        break;
                    }
                case SwitchSlideStyles.Excircle:
                    {
                        this.DrawExcircle(g, back_color, border_color, slide_back_color, slide_border_color, text_color);
                        break;
                    }
                case SwitchSlideStyles.Dot:
                    {
                        this.DrawDot(g, back_color, border_color, slide_back_color, slide_border_color, text_color);
                        break;
                    }
                case SwitchSlideStyles.Annular:
                    {
                        this.DrawAnnular(g, back_color, border_color, slide_back_color, text_color);
                        break;
                    }
                case SwitchSlideStyles.Internal:
                    {
                        this.DrawInternal(g, back_color, slide_back_color, text_color);
                        break;
                    }
            }


            if (this.activatedState)
            {
                Pen activate_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
                g.DrawRectangle(activate_pen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                activate_pen.Dispose();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.slideing)
                {
                    this.usedTime = this.options.AllTransformTime - this.usedTime;
                }
                else
                {
                    this.usedTime = 0;
                }
                this.slideing = true;
                this._Checked = !this.Checked;
                this.switchSlide.slide_prepare = this.switchSlide.slide_current;
                AnimationStaticTimer.AnimationStart(this);
                this.OnCheckedChanged(new CheckedChangedEventArgs() { Checked = this._Checked });
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (this.DesignMode)
                return;
            if (e.Button == MouseButtons.Left)
            {
                this.OnMouseClick(new MouseEventArgs(e.Button, 1, e.X, e.Y, e.Delta));
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
        }

        protected override void OnEnter(EventArgs e)
        {
            this.activatedState = true;
            this.Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.activatedState = false;
            this.Invalidate();
            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.activatedState = true;
            this.Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.activatedState = false;
            this.Invalidate();
            base.OnLostFocus(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.activatedState)
            {

                #region Enter、Space
                if (keyData == Keys.Enter || keyData == Keys.Space)
                {

                    this.Checked = !this.Checked;
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeButtomSwitchRectangle();
        }

        #endregion

        #region 虚方法

        protected virtual void OnCheckedChanged(CheckedChangedEventArgs e)
        {
            if (this.checkedChanged != null)
            {
                this.checkedChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 滑动动画中
        /// </summary>
        [Description("禁止手动调用")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Animationing()
        {
            this.usedTime += AnimationStaticTimer.timer.Interval;
            if (this.usedTime > this.options.AllTransformTime)
            {
                this.usedTime = this.options.AllTransformTime;
                AnimationStaticTimer.AnimationStop(this);
                this.slideing = false;
            }

            double progress = AnimationTimer.GetProgress(AnimationTypes.EaseOut, this.options, this.usedTime);
            if (this.slideing == false)
            {
                if (progress < 0)
                    progress = 0;
                if (progress > 1)
                    progress = 1;

                this.usedTime = 0;
            }

            if (this.Checked)
            {
                switchSlide.slide_current.X = (float)(this.switchSlide.slide_prepare.X + (this.switchSlide.slide_on.X - this.switchSlide.slide_prepare.X) * progress);
            }
            else
            {
                switchSlide.slide_current.X = (float)(this.switchSlide.slide_prepare.X - (this.switchSlide.slide_prepare.X - this.switchSlide.slide_off.X) * progress);
            }

            if (Style == SwitchSlideStyles.Internal)
            {
                if (this.Checked)
                {
                    switchSlide.slide_current.Y = (float)(this.switchSlide.slide_prepare.Y + (this.switchSlide.slide_on.Y - this.switchSlide.slide_prepare.Y) * progress);
                    switchSlide.slide_current.Width = (float)(switchSlide.slide_prepare.Width + (this.switchSlide.slide_on.Width - this.switchSlide.slide_prepare.Width) * progress);
                    switchSlide.slide_current.Height = switchSlide.slide_current.Width;
                }
                else
                {
                    switchSlide.slide_current.Y = (float)(this.switchSlide.slide_prepare.Y - (this.switchSlide.slide_prepare.Y - this.switchSlide.slide_off.Y) * progress);
                    switchSlide.slide_current.Width = (float)(switchSlide.slide_prepare.Width - (this.switchSlide.slide_prepare.Width - this.switchSlide.slide_off.Width) * progress);
                    switchSlide.slide_current.Height = switchSlide.slide_current.Width;
                }
            }
            this.Invalidate();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化开关按钮Rectangle
        /// </summary>
        private void InitializeButtomSwitchRectangle()
        {
            RectangleF rectf = this.ClientRectangle;
            #region Quadrangle
            if (this.Style == SwitchSlideStyles.Quadrangle)
            {
                int padding = 3;

                this.switchSlide.slide_back.Width = rectf.Width;
                this.switchSlide.slide_back.Height = rectf.Height;
                this.switchSlide.slide_back.X = rectf.X;
                this.switchSlide.slide_back.Y = rectf.Y;

                this.switchSlide.slide_off.Width = (this.switchSlide.slide_back.Width - this.BorderThickness * 2) / 2f - padding * 2;
                this.switchSlide.slide_off.Height = this.switchSlide.slide_back.Height - this.BorderThickness * 2 - padding * 2;
                this.switchSlide.slide_off.Y = this.switchSlide.slide_back.Y + this.BorderThickness + padding;
                this.switchSlide.slide_off.X = this.switchSlide.slide_back.X + this.BorderThickness + padding;

                this.switchSlide.slide_on.Width = this.switchSlide.slide_off.Width;
                this.switchSlide.slide_on.Height = this.switchSlide.slide_off.Height;
                this.switchSlide.slide_on.Y = this.switchSlide.slide_off.Y;
                this.switchSlide.slide_on.X = this.switchSlide.slide_back.Right - this.BorderThickness - padding - this.switchSlide.slide_on.Width;
            }
            #endregion
            #region Internal
            else if (this.Style == SwitchSlideStyles.Internal)
            {
                float padding = 4;

                this.switchSlide.slide_back.Width = rectf.Width;
                this.switchSlide.slide_back.Height = rectf.Height;
                this.switchSlide.slide_back.X = rectf.X;
                this.switchSlide.slide_back.Y = rectf.Y;

                this.switchSlide.slide_off.Width = rectf.Height;
                this.switchSlide.slide_off.Height = rectf.Height;
                this.switchSlide.slide_off.Y = rectf.Y;
                this.switchSlide.slide_off.X = rectf.X;

                this.switchSlide.slide_on.Width = this.switchSlide.slide_off.Width - padding * 2;
                this.switchSlide.slide_on.Height = this.switchSlide.slide_on.Width;
                this.switchSlide.slide_on.Y = this.ClientRectangle.Y + padding;
                this.switchSlide.slide_on.X = rectf.Right - padding - this.switchSlide.slide_on.Width;
            }
            #endregion
            #region Excircle
            else if (this.Style == SwitchSlideStyles.Excircle)
            {
                int padding = 5;

                this.switchSlide.slide_back.Width = rectf.Width - padding * 2;
                this.switchSlide.slide_back.Height = rectf.Height - padding * 2;
                this.switchSlide.slide_back.X = rectf.X + padding;
                this.switchSlide.slide_back.Y = rectf.Y + padding;

                this.switchSlide.slide_off.Width = rectf.Height;
                this.switchSlide.slide_off.Height = rectf.Height;
                this.switchSlide.slide_off.Y = rectf.Y;
                this.switchSlide.slide_off.X = rectf.X;

                this.switchSlide.slide_on.Width = this.switchSlide.slide_off.Width;
                this.switchSlide.slide_on.Height = this.switchSlide.slide_off.Height;
                this.switchSlide.slide_on.Y = this.switchSlide.slide_off.Y;
                this.switchSlide.slide_on.X = rectf.Right - this.switchSlide.slide_on.Width;
            }
            #endregion
            #region Dot
            else if (this.Style == SwitchSlideStyles.Dot)
            {
                float padding = 2;
                this.switchSlide.slide_back.Width = rectf.Width - padding * 2;
                this.switchSlide.slide_back.Height = rectf.Height / 5f;
                this.switchSlide.slide_back.X = rectf.X + padding;
                this.switchSlide.slide_back.Y = rectf.Y + (rectf.Height - this.switchSlide.slide_back.Height) / 2f;

                this.switchSlide.slide_off.Width = rectf.Height;
                this.switchSlide.slide_off.Height = rectf.Height;
                this.switchSlide.slide_off.Y = rectf.Y;
                this.switchSlide.slide_off.X = rectf.X;

                this.switchSlide.slide_on.Width = this.switchSlide.slide_off.Width;
                this.switchSlide.slide_on.Height = this.switchSlide.slide_on.Width;
                this.switchSlide.slide_on.Y = this.switchSlide.slide_off.Y;
                this.switchSlide.slide_on.X = rectf.Right - this.switchSlide.slide_on.Width;
            }
            #endregion
            #region Annular
            else if (this.Style == SwitchSlideStyles.Annular)
            {
                float padding = rectf.Height / 8f;

                this.switchSlide.slide_back.Width = rectf.Width;
                this.switchSlide.slide_back.Height = rectf.Height;
                this.switchSlide.slide_back.X = rectf.X;
                this.switchSlide.slide_back.Y = rectf.Y;

                this.switchSlide.slide_off.Width = padding * 4;
                this.switchSlide.slide_off.Height = padding * 4;
                this.switchSlide.slide_off.Y = rectf.Y + padding * 2;
                this.switchSlide.slide_off.X = rectf.X + padding * 2;

                this.switchSlide.slide_on.Width = this.switchSlide.slide_off.Width;
                this.switchSlide.slide_on.Height = this.switchSlide.slide_on.Width;
                this.switchSlide.slide_on.Y = this.switchSlide.slide_off.Y;
                this.switchSlide.slide_on.X = rectf.Right - padding * 2 - this.switchSlide.slide_on.Width;
            }
            #endregion
            this.switchSlide.slide_current = this.Checked ? this.switchSlide.slide_on : this.switchSlide.slide_off;
        }

        /// <summary>
        /// 绘制四边形开关
        /// </summary>
        /// <param name="g"></param>
        /// <param name="back_color"></param>
        /// <param name="border_color"></param>
        /// <param name="slide_back_color"></param>
        /// <param name="slide_border_color"></param>
        /// <param name="text_color"></param>
        private void DrawQuadrangle(Graphics g, Color back_color, Color border_color, Color slide_back_color, Color slide_border_color, Color text_color)
        {
            //背景
            SolidBrush back_sb = new SolidBrush(back_color);
            GraphicsPath back_gp = ControlCommom.TransformCircular(ControlCommom.TransformRectangleF(this.switchSlide.slide_back, this.BorderThickness), this.SlideRadius);
            g.FillPath(back_sb, back_gp);
            if (this.BorderThickness > 0)
            {
                Pen back_border_pen = new Pen(border_color, this.BorderThickness);
                g.DrawPath(back_border_pen, back_gp);
                back_border_pen.Dispose();
            }
            back_gp.Dispose();

            //开启文本
            if (!String.IsNullOrWhiteSpace(this.CheckedText))
            {
                Rectangle on_text_rect = new Rectangle((int)this.switchSlide.slide_off.X, (int)this.switchSlide.slide_off.Y, (int)this.switchSlide.slide_off.Width, (int)this.switchSlide.slide_off.Height);
                SolidBrush text_sb = new SolidBrush(text_color);
                g.DrawString(this.CheckedText, this.Font, text_sb, on_text_rect, text_sf);
                text_sb.Dispose();
            }
            //关闭文本
            if (!String.IsNullOrWhiteSpace(this.UnCheckedText))
            {
                Rectangle off_text_rect = new Rectangle((int)this.switchSlide.slide_on.X, (int)this.switchSlide.slide_on.Y, (int)this.switchSlide.slide_on.Width, (int)this.switchSlide.slide_on.Height);
                SolidBrush text_sb = new SolidBrush(text_color);
                g.DrawString(this.UnCheckedText, this.Font, text_sb, off_text_rect, text_sf);
                text_sb.Dispose();

            }


            //滑块
            SolidBrush slide_back_sb = new SolidBrush(slide_back_color);
            GraphicsPath slide_back_gp = ControlCommom.TransformCircular(ControlCommom.TransformRectangleF(this.switchSlide.slide_current, this.SlideBorderThickness), this.SlideRadius);
            g.FillPath(slide_back_sb, slide_back_gp);
            if (this.BorderThickness > 0)
            {
                Pen slide_border_pen = new Pen(slide_border_color, this.SlideBorderThickness);
                g.DrawPath(slide_border_pen, slide_back_gp);
                slide_border_pen.Dispose();
            }
            slide_back_gp.Dispose();
            slide_back_sb.Dispose();

            //滑块竖线1
            float avg_w = (this.switchSlide.slide_current.Width - this.SlideBorderThickness * 2) / 10f;
            float avg_h = (this.switchSlide.slide_current.Height - this.SlideBorderThickness * 2) / 5f;
            RectangleF slideline_left_rectf = new RectangleF();
            slideline_left_rectf.Width = avg_w;
            slideline_left_rectf.Height = avg_h * 3;
            slideline_left_rectf.X = this.switchSlide.slide_current.X + this.SlideBorderThickness + avg_w * 3;
            slideline_left_rectf.Y = this.switchSlide.slide_current.Y + this.SlideBorderThickness + avg_h;

            RectangleF slideline_right_rectf = new RectangleF();
            slideline_right_rectf.Width = avg_w;
            slideline_right_rectf.Height = avg_h * 3;
            slideline_right_rectf.X = slideline_left_rectf.Right + avg_w * 2;
            slideline_right_rectf.Y = slideline_left_rectf.Y;

            g.FillRectangle(back_sb, slideline_left_rectf);
            g.FillRectangle(back_sb, slideline_right_rectf);
            back_sb.Dispose();
        }

        /// <summary>
        /// 绘制内圆开关
        /// </summary>
        /// <param name="g"></param>
        /// <param name="back_color"></param>
        /// <param name="slide_back_color"></param>
        /// <param name="text_color"></param>
        private void DrawInternal(Graphics g, Color back_color, Color slide_back_color, Color text_color)
        {
            //背景
            SolidBrush back_sb = new SolidBrush(back_color);
            RectangleF back_tmp = new RectangleF(this.switchSlide.slide_back.X, this.switchSlide.slide_back.Y, this.switchSlide.slide_back.Width - 1, this.switchSlide.slide_back.Height - 1);
            GraphicsPath back_gp = ControlCommom.TransformCircular(back_tmp, back_tmp.Height / 2f);
            g.FillPath(back_sb, back_gp);
            back_gp.Dispose();
            back_sb.Dispose();

            //滑块
            SolidBrush slide_back_sb = new SolidBrush(slide_back_color);
            RectangleF slide_back_tmp = new RectangleF(this.switchSlide.slide_current.X, this.switchSlide.slide_current.Y, this.switchSlide.slide_current.Width - 1, this.switchSlide.slide_current.Height - 1);
            GraphicsPath slide_back_gp = ControlCommom.TransformCircular(slide_back_tmp, slide_back_tmp.Height / 2f);
            g.FillPath(slide_back_sb, slide_back_gp);
            slide_back_gp.Dispose();
            slide_back_sb.Dispose();
        }

        /// <summary>
        /// 绘制外圆开关
        /// </summary>
        /// <param name="g"></param>
        /// <param name="back_color"></param>
        /// <param name="border_color"></param>
        /// <param name="slide_back_color"></param>
        /// <param name="slide_border_color"></param>
        /// <param name="text_color"></param>
        private void DrawExcircle(Graphics g, Color back_color, Color border_color, Color slide_back_color, Color slide_border_color, Color text_color)
        {
            //背景
            SolidBrush back_sb = new SolidBrush(back_color);
            RectangleF back_tmp = ControlCommom.TransformRectangleF(this.switchSlide.slide_back, this.BorderThickness);
            GraphicsPath back_gp = ControlCommom.TransformCircular(back_tmp, back_tmp.Height / 2f);
            g.FillPath(back_sb, back_gp);
            if (this.BorderThickness > 0)
            {
                Pen back_border_pen = new Pen(border_color, this.BorderThickness);
                g.DrawPath(back_border_pen, back_gp);
                back_border_pen.Dispose();
            }
            back_gp.Dispose();
            back_sb.Dispose();


            //开启文本
            if (!String.IsNullOrWhiteSpace(this.CheckedText))
            {
                Rectangle on_text_rect = new Rectangle((int)this.switchSlide.slide_off.X, (int)this.switchSlide.slide_off.Y, (int)this.switchSlide.slide_off.Width, (int)this.switchSlide.slide_off.Height);
                SolidBrush text_sb = new SolidBrush(text_color);
                g.DrawString(this.CheckedText, this.Font, text_sb, on_text_rect, text_sf);
                text_sb.Dispose();
            }
            //关闭文本 
            if (!String.IsNullOrWhiteSpace(this.UnCheckedText))
            {
                Rectangle off_text_rect = new Rectangle((int)this.switchSlide.slide_on.X, (int)this.switchSlide.slide_on.Y, (int)this.switchSlide.slide_on.Width, (int)this.switchSlide.slide_on.Height);
                SolidBrush text_sb = new SolidBrush(text_color);
                g.DrawString(this.UnCheckedText, this.Font, text_sb, off_text_rect, text_sf);
                text_sb.Dispose();
            }

            //滑块
            SolidBrush slide_back_sb = new SolidBrush(slide_back_color);
            RectangleF slide_back_tmp = new RectangleF(this.switchSlide.slide_current.X, this.switchSlide.slide_current.Y, this.switchSlide.slide_current.Width - 1, this.switchSlide.slide_current.Height - 1);
            RectangleF slide_back_current_rectf = ControlCommom.TransformRectangleF(slide_back_tmp, this.SlideBorderThickness);
            GraphicsPath slide_back_gp = ControlCommom.TransformCircular(slide_back_current_rectf, slide_back_current_rectf.Height / 2f);
            g.FillPath(slide_back_sb, slide_back_gp);
            if (this.SlideBorderThickness > 0)
            {
                Pen slide_border_pen = new Pen(slide_border_color, this.SlideBorderThickness);
                g.DrawPath(slide_border_pen, slide_back_gp);
                slide_border_pen.Dispose();
            }
            slide_back_gp.Dispose();
            slide_back_sb.Dispose();
        }

        /// <summary>
        /// 绘制圆点开关
        /// </summary>
        /// <param name="g"></param>
        /// <param name="back_color"></param>
        /// <param name="border_color"></param>
        /// <param name="slide_back_color"></param>
        /// <param name="slide_border_color"></param>
        /// <param name="text_color"></param>
        private void DrawDot(Graphics g, Color back_color, Color border_color, Color slide_back_color, Color slide_border_color, Color text_color)
        {
            //背景
            SolidBrush back_sb = new SolidBrush(back_color);
            RectangleF back_tmp = ControlCommom.TransformRectangleF(this.switchSlide.slide_back, this.BorderThickness);
            GraphicsPath backdrop_gp = ControlCommom.TransformCircular(back_tmp, back_tmp.Height / 2f);
            g.FillPath(back_sb, backdrop_gp);
            if (this.BorderThickness > 0)
            {
                Pen back_border_pen = new Pen(border_color, this.BorderThickness);
                g.DrawPath(back_border_pen, backdrop_gp);
                back_border_pen.Dispose();
            }
            backdrop_gp.Dispose();
            back_sb.Dispose();

            //滑块
            SolidBrush slide_back_sb = new SolidBrush(slide_back_color);
            RectangleF slide_back_tmp = new RectangleF(this.switchSlide.slide_current.X, this.switchSlide.slide_current.Y, this.switchSlide.slide_current.Width - 1, this.switchSlide.slide_current.Height - 1);
            RectangleF slide_back_current_rectf = ControlCommom.TransformRectangleF(slide_back_tmp, this.SlideBorderThickness);
            GraphicsPath slide_back_gp = ControlCommom.TransformCircular(slide_back_current_rectf, slide_back_current_rectf.Height / 2f);
            g.FillPath(slide_back_sb, slide_back_gp);
            if (this.SlideBorderThickness > 0)
            {
                Pen slide_border_pen = new Pen(slide_border_color, this.SlideBorderThickness);
                g.DrawPath(slide_border_pen, slide_back_gp);
                slide_border_pen.Dispose();
            }
            slide_back_gp.Dispose();
            slide_back_sb.Dispose();
        }

        /// <summary>
        /// 绘制环形开关
        /// </summary>
        /// <param name="g"></param>
        /// <param name="back_color"></param>
        /// <param name="border_color"></param>
        /// <param name="text_color"></param>
        /// <param name="slide_back_color"></param>
        private void DrawAnnular(Graphics g, Color back_color, Color border_color, Color slide_back_color, Color text_color)
        {
            //背景
            float padding = this.switchSlide.slide_back.Height / 8;
            SolidBrush back_sb = new SolidBrush(back_color);
            RectangleF back_tmp = new RectangleF(this.switchSlide.slide_back.X, this.switchSlide.slide_back.Y, this.switchSlide.slide_back.Width - 1, this.switchSlide.slide_back.Height - 1);
            RectangleF back_rectf = ControlCommom.TransformRectangleF(back_tmp, (int)padding);
            GraphicsPath backdrop_gp = ControlCommom.TransformCircular(back_rectf, back_rectf.Height / 2f);
            g.FillPath(back_sb, backdrop_gp);

            Pen back_border_pen = new Pen(border_color, padding);
            g.DrawPath(back_border_pen, backdrop_gp);
            back_sb.Dispose();
            back_border_pen.Dispose();
            backdrop_gp.Dispose();

            //滑块
            SolidBrush slide_back_sb = new SolidBrush(slide_back_color);
            RectangleF slide_back_tmp = new RectangleF(this.switchSlide.slide_current.X, this.switchSlide.slide_current.Y, this.switchSlide.slide_current.Width - 1, this.switchSlide.slide_current.Height - 1);
            g.FillEllipse(slide_back_sb, slide_back_tmp);
            slide_back_sb.Dispose();
        }

        #endregion

        #region 类

        /// <summary>
        /// 滑块信息
        /// </summary>
        [Description("滑块信息")]
        public class SwitchSlide
        {
            /// <summary>
            ///滑块背景rect 
            /// </summary>
            [Description("滑块背景rect")]
            public RectangleF slide_back;
            /// <summary>
            /// 滑块关闭rect
            /// </summary>
            [Description("滑块关闭rect")]
            public RectangleF slide_off;
            /// <summary>
            /// 滑块开启rect
            /// </summary>
            [Description("滑块开启rect")]
            public RectangleF slide_on;
            /// <summary>
            /// 滑块当前rect
            /// </summary>
            [Description("滑块当前rect")]
            public RectangleF slide_current;
            /// <summary>
            /// 滑块动画前rect
            /// </summary>
            [Description("滑块动画前rect")]
            public RectangleF slide_prepare;
        }

        /// <summary>
        /// 开关状态更改事件参数
        /// </summary>
        [Description("开关状态更改事件参数")]
        public class CheckedChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 开关状态
            /// </summary>
            [Description("开关状态")]
            public bool Checked { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 开关显示风格类型
        /// </summary>
        [Description("开关显示风格类型")]
        public enum SwitchSlideStyles
        {
            /// <summary>
            /// 四边
            /// </summary>
            Quadrangle,
            /// <summary>
            /// 内圆
            /// </summary>
            Internal,
            /// <summary>
            /// 外圆
            /// </summary>
            Excircle,
            /// <summary>
            /// 圆点
            /// </summary>
            Dot,
            /// <summary>
            /// 环形
            /// </summary>
            Annular
        }

        #endregion
    }
}
