
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 多点滑块滑杆控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("多点滑块滑杆控件")]
    [DefaultProperty("Items")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class MultidropSlideBarExt : Control
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 滑块选项值更改事件
        /// </summary>
        [Description("滑块选项值更改事件")]
        public event ValueChangedEventHandler ValueChanged
        {
            add { this.valueChanged += value; }
            remove { this.valueChanged -= value; }
        }

        public delegate void GlobalEventHandler(object sender, GlobalValueChangedEventArgs e);

        private event GlobalEventHandler globalValueChanged;
        /// <summary>
        /// 滑块选项值更改事件参数(根据全局值修改)
        /// </summary>
        [Description("滑块选项值更改事件参数(根据全局值修改)")]
        public event GlobalEventHandler GlobalValueChanged
        {
            add { this.globalValueChanged += value; }
            remove { this.globalValueChanged -= value; }
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

        private SlideOrientation orientation = SlideOrientation.HorizontalBottom;
        /// <summary>
        /// 滑块方向位置
        /// </summary>
        [DefaultValue(SlideOrientation.HorizontalBottom)]
        [Description("滑块方向位置")]
        public SlideOrientation Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation == value)
                    return;
                this.orientation = value;
                this.InitializeMultidropSlideBarRectangle();
                this.Invalidate();
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

        private Color slideLockNormalBackColor = Color.FromArgb(115, 255, 255, 255);
        /// <summary>
        /// 滑块锁定背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "115, 255, 255, 255")]
        [Description(" 滑块锁定背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideLockNormalBackColor
        {
            get { return this.slideLockNormalBackColor; }
            set
            {
                if (this.slideLockNormalBackColor == value)
                    return;
                this.slideLockNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color slideLockDisableBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 滑块锁定背景颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description(" 滑块锁定背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideLockDisableBackColor
        {
            get { return this.slideLockDisableBackColor; }
            set
            {
                if (this.slideLockDisableBackColor == value)
                    return;
                this.slideLockDisableBackColor = value;
                this.Invalidate();
            }
        }

        private int slidePadding = 6;
        /// <summary>
        /// 控件边距
        /// </summary>
        [DefaultValue(6)]
        [Description("控件边距")]
        public int SlidePadding
        {
            get { return this.slidePadding; }
            set
            {
                if (this.slidePadding == value || value < 0)
                    return;
                this.slidePadding = value;
                this.InitializeMultidropSlideBarRectangle();
                this.Invalidate();
            }
        }

        private int border = 0;
        /// <summary>
        /// 控件边框
        /// </summary>
        [DefaultValue(0)]
        [Description("控件边框")]
        public int Border
        {
            get { return this.border; }
            set
            {
                if (this.border == value || value < 0)
                    return;
                this.border = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 控件边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("控件边框颜色")]
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

        private float scrollInterval = 1f;
        /// <summary>
        /// 鼠标滚轮或键盘上下键移动间隔值
        /// </summary>
        [DefaultValue(1f)]
        [Description("鼠标滚轮或键盘上下键移动间隔值")]
        public float ScrollInterval
        {
            get { return this.scrollInterval; }
            set
            {
                if (this.scrollInterval == value || value < 0)
                    return;
                this.scrollInterval = value;
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

        private float minValue = 0f;
        /// <summary>
        /// 最小值
        /// </summary>
        [DefaultValue(0f)]
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


        private MultidropSlideBarColorItemCollection multidropSlideBarColorItemCollection;
        /// <summary>
        /// 滑块条颜色级别配置集合
        /// </summary>
        [DefaultValue(null)]
        [Description("滑块条颜色级别配置集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MultidropSlideBarColorItemCollection BarColorItems
        {
            get
            {
                if (this.multidropSlideBarColorItemCollection == null)
                    this.multidropSlideBarColorItemCollection = new MultidropSlideBarColorItemCollection(this);
                return this.multidropSlideBarColorItemCollection;
            }
        }

        private MultidropSlideBarColorItemCollection multidropSlideBarProgressColorItemCollection;
        /// <summary>
        /// 滑块条进度颜色级别配置集合
        /// </summary>
        [DefaultValue(null)]
        [Description("滑块条进度颜色级别配置集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MultidropSlideBarColorItemCollection BarProgressColorItems
        {
            get
            {
                if (this.multidropSlideBarProgressColorItemCollection == null)
                    this.multidropSlideBarProgressColorItemCollection = new MultidropSlideBarColorItemCollection(this);
                return this.multidropSlideBarProgressColorItemCollection;
            }
        }

        #region 滑条

        private int slideBarThickness = 8;
        /// <summary>
        /// 滑条背景大小
        /// </summary>
        [DefaultValue(8)]
        [Description("滑条背景大小")]
        public int SlideBarThickness
        {
            get { return this.slideBarThickness; }
            set
            {
                if (this.slideBarThickness == value || value < 0)
                    return;
                this.slideBarThickness = value;
                this.Invalidate();
            }
        }

        private bool slideBarRadius = true;
        /// <summary>
        /// 背景是否为圆角
        /// </summary>
        [DefaultValue(true)]
        [Description("背景是否为圆角")]
        public bool SlideBarRadius
        {
            get { return this.slideBarRadius; }
            set
            {
                if (this.slideBarRadius == value)
                    return;
                this.slideBarRadius = value;
                this.Invalidate();
            }
        }

        private Color slideBarNormalBackColor = Color.FromArgb(76, 240, 128, 128);
        /// <summary>
        /// 滑条背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "76, 240, 128, 128")]
        [Description("滑条背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideBarNormalBackColor
        {
            get { return this.slideBarNormalBackColor; }
            set
            {
                if (this.slideBarNormalBackColor == value)
                    return;
                this.slideBarNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color slideBarDisableBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 滑条背景颜色（禁止）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("滑条背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideBarDisableBackColor
        {
            get { return this.slideBarDisableBackColor; }
            set
            {
                if (this.slideBarDisableBackColor == value)
                    return;
                this.slideBarDisableBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 滑块

        private int slideWidth = 20;
        /// <summary>
        /// 滑块宽度
        /// </summary>
        [DefaultValue(20)]
        [Description("滑块宽度")]
        public int SlideWidth
        {
            get { return this.slideWidth; }
            set
            {
                if (this.slideWidth == value || value < 0)
                    return;
                this.slideWidth = value;
                this.InitializeMultidropSlideBarRectangle();
                this.Invalidate();
            }
        }

        private int slideHeight = 20;
        /// <summary>
        /// 滑块高度
        /// </summary>
        [DefaultValue(20)]
        [Description("滑块高度")]
        public int SlideHeight
        {
            get { return this.slideHeight; }
            set
            {
                if (this.slideHeight == value || value < 0)
                    return;
                this.slideHeight = value;
                this.InitializeMultidropSlideBarRectangle();
                this.Invalidate();
            }
        }

        private int slideRadius = 10;
        /// <summary>
        /// 滑块圆角大小
        /// </summary>
        [DefaultValue(10)]
        [Description("滑块圆角大小")]
        public int SlideRadius
        {
            get { return this.slideRadius; }
            set
            {
                if (this.slideRadius == value || value < 0)
                    return;
                this.slideRadius = value;
                this.InitializeMultidropSlideBarRectangle();
                this.Invalidate();
            }
        }

        private Color slideNormalBackColor = Color.FromArgb(255, 128, 128);
        /// <summary>
        /// 滑块背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 128, 128")]
        [Description("滑块背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideNormalBackColor
        {
            get { return this.slideNormalBackColor; }
            set
            {
                if (this.slideNormalBackColor == value)
                    return;
                this.slideNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color slideDisableBackColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 滑块背景颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("滑块背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideDisableBackColor
        {
            get { return this.slideDisableBackColor; }
            set
            {
                if (this.slideDisableBackColor == value)
                    return;
                this.slideDisableBackColor = value;
                this.Invalidate();
            }
        }

        private MultidropSlideBarItemCollection multidropSlideBarItemCollection;
        /// <summary>
        /// 滑块选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("滑块选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MultidropSlideBarItemCollection Items
        {
            get
            {
                if (this.multidropSlideBarItemCollection == null)
                    this.multidropSlideBarItemCollection = new MultidropSlideBarItemCollection(this);
                return this.multidropSlideBarItemCollection;
            }
        }

        #endregion

        #region 滑块进度

        private Color slideProgressNormalBackColor = Color.FromArgb(175, 240, 128, 128);
        /// <summary>
        /// 滑块进度背景颜色(仅限于只有一个滑块)（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "175, 240, 128, 128")]
        [Description("滑块进度背景颜色(仅限于只有一个滑块)（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideProgressNormalBackColor
        {
            get { return this.slideProgressNormalBackColor; }
            set
            {
                if (this.slideProgressNormalBackColor == value)
                    return;
                this.slideProgressNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color slideProgressDisableBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 滑块进度背景颜色(仅限于只有一个滑块)（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("滑块进度背景颜色(仅限于只有一个滑块)（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideProgressDisableBackColor
        {
            get { return this.slideProgressDisableBackColor; }
            set
            {
                if (this.slideProgressDisableBackColor == value)
                    return;
                this.slideProgressDisableBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 提示信息

        private bool tipShow = true;
        /// <summary>
        /// 是否显示提示信息
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示提示信息")]
        public bool TipShow
        {
            get { return this.tipShow; }
            set
            {
                if (this.tipShow == value)
                    return;
                this.tipShow = value;
                this.Invalidate();
            }
        }

        private Font tipFont = new Font("宋体", 11, FontStyle.Regular);
        /// <summary>
        /// 提示信息字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体,11pt,style=Regular")]
        [Description("提示信息字体")]
        public Font TipFont
        {
            get { return this.tipFont; }
            set
            {
                if (this.tipFont == value)
                    return;
                this.tipFont = value;
                this.Invalidate();
            }
        }

        private Color tipNormalBackColor = Color.FromArgb(180, 255, 128, 128);
        /// <summary>
        /// 提示信息背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "180, 255, 128, 128")]
        [Description("提示信息背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TipNormalBackColor
        {
            get { return this.tipNormalBackColor; }
            set
            {
                if (this.tipNormalBackColor == value)
                    return;
                this.tipNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color tipDisableBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 提示信息背景颜色（禁止）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("提示信息背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TipDisableBackColor
        {
            get { return this.tipDisableBackColor; }
            set
            {
                if (this.tipDisableBackColor == value)
                    return;
                this.tipDisableBackColor = value;
                this.Invalidate();
            }
        }

        private Color tipNormalTextColor = Color.FromArgb(150, 255, 255, 255);
        /// <summary>
        /// 提示信息文本颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "150,255, 255, 255")]
        [Description("提示信息文本颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TipNormalTextColor
        {
            get { return this.tipNormalTextColor; }
            set
            {
                if (this.tipNormalTextColor == value)
                    return;
                this.tipNormalTextColor = value;
                this.Invalidate();
            }
        }

        private Color tipDisableTextColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 提示信息文本颜色（禁止）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("提示信息文本颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TipDisableTextColor
        {
            get { return this.tipDisableTextColor; }
            set
            {
                if (this.tipDisableTextColor == value)
                    return;
                this.tipDisableTextColor = value;
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
                return new Size(300, 60);
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
        /// 控件激活状态选项索引
        /// </summary>
        private int activatedStateIndex = -1;

        /// <summary>
        /// 控件激活鼠标选中选项索引
        /// </summary>
        private int selectIndex = -1;

        /// <summary>
        /// 鼠标状态
        /// </summary>
        private SlideMoveStatus move_status = SlideMoveStatus.Leave;
        /// <summary>
        /// 鼠标坐标
        /// </summary>
        private Point move_point;

        #endregion

        public MultidropSlideBarExt()
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
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectf = new Rectangle(this.SlidePadding, this.SlidePadding, this.ClientRectangle.Width - this.SlidePadding * 2, this.ClientRectangle.Height - this.SlidePadding * 2);

            #region 滑条

            #region
            if (this.Orientation == SlideOrientation.HorizontalTop || this.Orientation == SlideOrientation.HorizontalBottom)
            {
                int bar_back_x_start = rectf.X;
                int bar_back_x_end = rectf.Right;
                int bar_back_y = (this.Orientation == SlideOrientation.HorizontalTop) ? this.SlidePadding + this.SlideHeight / 2 : rectf.Bottom - this.SlideHeight / 2 - this.SlidePadding;

                if (this.BarColorItems.Count < 2)
                {
                    Pen bar_back_pen = new Pen(this.Enabled ? this.SlideBarNormalBackColor : this.SlideBarDisableBackColor, this.SlideBarThickness);
                    if (this.SlideBarRadius)
                    {
                        bar_back_pen.StartCap = LineCap.Round;
                        bar_back_pen.EndCap = LineCap.Round;
                        bar_back_x_start += this.SlideBarThickness / 2;
                        bar_back_x_end -= this.SlideBarThickness / 2;
                    }
                    g.DrawLine(bar_back_pen, bar_back_x_start, bar_back_y, bar_back_x_end, bar_back_y);
                    bar_back_pen.Dispose();
                }
                else
                {
                    RectangleF bar_back_rectf = new RectangleF(bar_back_x_start, bar_back_y - (float)this.SlideBarThickness / 2f, bar_back_x_end - bar_back_x_start, this.SlideBarThickness);
                    this.DrawBarLinearGradient(g, bar_back_rectf, true);
                }
            }
            #endregion
            #region
            else
            {
                int bar_back_x_start = rectf.Y;
                int bar_back_x_end = rectf.Bottom;
                int bar_back_y = (this.Orientation == SlideOrientation.VerticalLeft) ? this.SlidePadding + this.SlideWidth / 2 : rectf.Right - this.SlideWidth / 2 - this.SlidePadding;

                if (this.BarColorItems.Count < 2)
                {
                    Pen bar_back_pen = new Pen(this.Enabled ? this.SlideBarNormalBackColor : this.SlideBarDisableBackColor, this.SlideBarThickness);
                    if (this.SlideBarRadius)
                    {
                        bar_back_pen.StartCap = LineCap.Round;
                        bar_back_pen.EndCap = LineCap.Round;
                        bar_back_x_start += this.SlideBarThickness / 2;
                        bar_back_x_end -= this.SlideBarThickness / 2;
                    }
                    g.DrawLine(bar_back_pen, bar_back_y, bar_back_x_start, bar_back_y, bar_back_x_end);
                    bar_back_pen.Dispose();
                }
                else
                {
                    RectangleF bar_back_rectf = new RectangleF(bar_back_y - (float)this.SlideBarThickness / 2f, bar_back_x_start, this.SlideBarThickness, bar_back_x_end - bar_back_x_start);
                    this.DrawBarLinearGradient(g, bar_back_rectf, false);
                }
            }
            #endregion

            #endregion

            #region 滑条进度值
            if (this.Items.Count == 1)
            {
                #region
                if (this.Orientation == SlideOrientation.HorizontalTop || this.Orientation == SlideOrientation.HorizontalBottom)
                {
                    int bar_progress_x_start = rectf.X;
                    int bar_progress_x_end = (int)(this.Items[0].SlideRect.Right - this.Items[0].SlideRect.Width) + this.SlideWidth / 2;
                    int bar_progress_y = (this.Orientation == SlideOrientation.HorizontalTop) ? this.SlidePadding + this.SlideHeight / 2 : rectf.Bottom - this.SlideHeight / 2 - this.SlidePadding;

                    if (this.BarProgressColorItems.Count < 2)
                    {
                        Pen bar_progress_pen = new Pen(this.Enabled ? this.SlideProgressNormalBackColor : this.SlideProgressDisableBackColor, this.SlideBarThickness);
                        if (this.SlideBarRadius)
                        {
                            bar_progress_pen.StartCap = LineCap.Round;
                            bar_progress_x_start += this.SlideBarThickness / 2;
                        }
                        g.DrawLine(bar_progress_pen, bar_progress_x_start, bar_progress_y, bar_progress_x_end, bar_progress_y);
                        bar_progress_pen.Dispose();
                    }
                    else
                    {
                        RectangleF bar_progress_rectf = new RectangleF(bar_progress_x_start, bar_progress_y - (float)this.SlideBarThickness / 2f, bar_progress_x_end - bar_progress_x_start, this.SlideBarThickness);
                        this.DrawProgressLinearGradient(g, bar_progress_rectf, true);
                    }
                }
                #endregion
                #region
                else
                {
                    int bar_progress_x_start = rectf.Bottom;
                    int bar_progress_x_end = (int)(this.Items[0].SlideRect.Bottom - this.Items[0].SlideRect.Height);
                    int bar_progress_y = (this.Orientation == SlideOrientation.VerticalLeft) ? this.SlidePadding + this.SlideWidth / 2 : rectf.Right - this.SlideWidth / 2 - this.SlidePadding;
                    if (this.BarProgressColorItems.Count < 2)
                    {
                        Pen bar_progress_pen = new Pen(this.Enabled ? this.SlideProgressNormalBackColor : this.SlideProgressDisableBackColor, this.SlideBarThickness);
                        if (this.SlideBarRadius)
                        {
                            bar_progress_pen.StartCap = LineCap.Round;
                            bar_progress_x_start -= this.SlideBarThickness / 2;
                        }
                        g.DrawLine(bar_progress_pen, bar_progress_y, bar_progress_x_start, bar_progress_y, bar_progress_x_end);
                        bar_progress_pen.Dispose();
                    }
                    else
                    {
                        RectangleF bar_progress_rectf = new RectangleF(bar_progress_y - (float)this.SlideBarThickness / 2f, bar_progress_x_end, this.SlideBarThickness, bar_progress_x_start - bar_progress_x_end);
                        this.DrawProgressLinearGradient(g, bar_progress_rectf, false);
                    }
                }
                #endregion
            }
            #endregion

            #region  滑块
            SolidBrush slidebar_back_sb = new SolidBrush(this.Enabled ? this.SlideNormalBackColor : this.SlideDisableBackColor);

            SolidBrush lock_slide_sb = new SolidBrush(this.Enabled ? this.SlideLockNormalBackColor : this.SlideLockDisableBackColor);

            SolidBrush normal_slide_back_sb = null;
            SolidBrush normal_tip_back_sb = null;
            SolidBrush normal_tip_text_sb = null;
            Pen normal_tip_line_pen = null;

            SolidBrush disable_slide_back_sb = null;
            SolidBrush disable_tip_back_sb = null;
            SolidBrush disable_tip_text_sb = null;
            Pen disable_tip_line_pen = null;

            Pen activate_border_pen = null;

            SolidBrush commom_slide_back_sb = null;
            SolidBrush commom_tip_back_sb = null;
            SolidBrush commom_tip_text_sb = null;
            Pen commom_tip_line_pen = null;
            bool subitemsSlideBackBrush = false;
            bool subitemsTipBackBrush = false;
            bool subitemsTipTextBrush = false;
            bool subitemsTipLinePen = false;

            #region 全局颜色
            if (this.Enabled)
            {
                normal_slide_back_sb = new SolidBrush(this.SlideNormalBackColor);
                normal_tip_back_sb = new SolidBrush(this.TipNormalBackColor);
                normal_tip_text_sb = new SolidBrush(this.TipNormalTextColor);
                normal_tip_line_pen = new Pen(this.TipNormalBackColor, 2);

                activate_border_pen = new Pen(this.ActivateColor, 1) { DashStyle = DashStyle.Dash };
            }
            else
            {
                disable_slide_back_sb = new SolidBrush(this.SlideDisableBackColor);
                disable_tip_back_sb = new SolidBrush(this.TipDisableBackColor);
                disable_tip_text_sb = new SolidBrush(this.TipDisableTextColor);
                disable_tip_line_pen = new Pen(this.TipDisableBackColor, 2);
            }
            #endregion

            int line_area = 6;//连线区域大小
            for (int i = 0; i < this.Items.Count; i++)
            {
                #region 滑块
                if (this.Enabled)
                {
                    #region
                    if (this.Items[i].SlideNormalBackColor == Color.Empty)
                    {
                        subitemsSlideBackBrush = false;
                        commom_slide_back_sb = normal_slide_back_sb;
                    }
                    else
                    {
                        subitemsSlideBackBrush = true;
                        commom_slide_back_sb = new SolidBrush(this.Items[i].SlideNormalBackColor);
                    }
                    #endregion
                }
                else
                {
                    #region
                    if (this.Items[i].SlideDisableBackColor == Color.Empty)
                    {
                        subitemsSlideBackBrush = false;
                        commom_slide_back_sb = disable_slide_back_sb;
                    }
                    else
                    {
                        subitemsSlideBackBrush = true;
                        commom_slide_back_sb = new SolidBrush(this.Items[i].SlideDisableBackColor);
                    }
                    #endregion
                }

                RectangleF slide_rectf = new RectangleF(this.Items[i].SlideRect.X, this.Items[i].SlideRect.Y, this.Items[i].SlideRect.Width, this.Items[i].SlideRect.Height);
                GraphicsPath slide_gp = ControlCommom.TransformCircular(slide_rectf, this.SlideRadius);
                g.FillPath(commom_slide_back_sb, slide_gp);
                if (this.Enabled && this.activatedState && this.activatedStateIndex == i)
                {
                    g.DrawPath(activate_border_pen, slide_gp);
                }
                slide_gp.Dispose();

                #region 锁
                if (this.Items[i].SlideLock)
                {
                    float min_lock_diameter = Math.Min(this.Items[i].SlideRect.Width, this.Items[i].SlideRect.Height) / 3f;
                    RectangleF slide_lock_rectf = new RectangleF(this.Items[i].SlideRect.X + (this.Items[i].SlideRect.Width - min_lock_diameter) / 2f, this.Items[i].SlideRect.Y + (this.Items[i].SlideRect.Height - min_lock_diameter) / 2f, min_lock_diameter, min_lock_diameter);
                    g.FillEllipse(lock_slide_sb, slide_lock_rectf);
                }
                #endregion

                #region 释放
                if (subitemsSlideBackBrush && commom_slide_back_sb != null)
                {
                    commom_slide_back_sb.Dispose();
                    commom_slide_back_sb = null;
                }
                #endregion

                #endregion

                #region 计算提示信息的位置
                if (this.TipShow)
                {
                    string tooltiptext_str = this.Items[i].Value.ToString("F2");
                    Size tooltiptext_size = g.MeasureString(tooltiptext_str, this.TipFont, new SizeF()).ToSize();

                    Rectangle tooltipback_rect = new Rectangle(0, 0, tooltiptext_size.Width, tooltiptext_size.Height);
                    if (this.Orientation == SlideOrientation.HorizontalTop)
                    {
                        tooltipback_rect.X = (int)this.Items[i].SlideRect.X + ((int)this.Items[i].SlideRect.Width - tooltipback_rect.Width) / 2;
                        if (tooltipback_rect.X < 0)
                            tooltipback_rect.X = 0;
                        tooltipback_rect.Y = (int)this.Items[i].SlideRect.Bottom + line_area;
                        if (i > 0 && (tooltipback_rect.X < this.Items[i - 1].TipRect.Right + line_area))
                        {
                            tooltipback_rect.X = (int)this.Items[i - 1].TipRect.Right + line_area;
                        }
                    }
                    else if (this.Orientation == SlideOrientation.HorizontalBottom)
                    {
                        tooltipback_rect.X = (int)this.Items[i].SlideRect.X + ((int)this.Items[i].SlideRect.Width - tooltipback_rect.Width) / 2;
                        if (tooltipback_rect.X < 0)
                            tooltipback_rect.X = 0;
                        tooltipback_rect.Y = (int)this.Items[i].SlideRect.Y - line_area - tooltipback_rect.Height;
                        if (i > 0 && (tooltipback_rect.X < this.Items[i - 1].TipRect.Right + line_area))
                        {
                            tooltipback_rect.X = (int)this.Items[i - 1].TipRect.Right + line_area;
                        }
                    }
                    else if (this.Orientation == SlideOrientation.VerticalLeft)
                    {
                        tooltipback_rect.X = (int)this.Items[i].SlideRect.Right + line_area;
                        tooltipback_rect.Y = (int)this.Items[i].SlideRect.Y + ((int)this.Items[i].SlideRect.Height - tooltipback_rect.Height) / 2;
                        if (tooltipback_rect.Y > rectf.Bottom - tooltipback_rect.Height)
                            tooltipback_rect.Y = rectf.Bottom - tooltipback_rect.Height;
                        if (i > 0 && (tooltipback_rect.Y > (int)this.Items[i - 1].TipRect.Y - line_area - tooltipback_rect.Height))
                        {
                            tooltipback_rect.Y = (int)this.Items[i - 1].TipRect.Y - line_area - tooltipback_rect.Height;
                        }
                    }
                    else if (this.Orientation == SlideOrientation.VerticalRight)
                    {
                        tooltipback_rect.X = (int)this.Items[i].SlideRect.X - line_area - tooltipback_rect.Width;
                        tooltipback_rect.Y = (int)this.Items[i].SlideRect.Y + ((int)this.Items[i].SlideRect.Height - tooltipback_rect.Height) / 2;
                        if (tooltipback_rect.Y > rectf.Bottom - tooltipback_rect.Height)
                            tooltipback_rect.Y = rectf.Bottom - tooltipback_rect.Height;
                        if (i > 0 && (tooltipback_rect.Y > (int)this.Items[i - 1].TipRect.Y - line_area - tooltipback_rect.Height))
                        {
                            tooltipback_rect.Y = (int)this.Items[i - 1].TipRect.Y - line_area - tooltipback_rect.Height;
                        }
                    }

                    this.Items[i].TipRect = tooltipback_rect;
                }
                #endregion
            }

            #region 提示信息
            if (this.TipShow)
            {
                for (int i = this.Items.Count - 1; i >= 0; i--)
                {
                    #region
                    if (this.Enabled)
                    {
                        #region
                        if (this.Items[i].TipNormalBackColor == Color.Empty)
                        {
                            subitemsTipBackBrush = false;
                            commom_tip_back_sb = normal_tip_back_sb;
                            subitemsTipLinePen = false;
                            commom_tip_line_pen = normal_tip_line_pen;
                        }
                        else
                        {
                            subitemsTipBackBrush = true;
                            commom_tip_back_sb = new SolidBrush(this.Items[i].TipNormalBackColor);
                            subitemsTipLinePen = true;
                            commom_tip_line_pen = new Pen(this.Items[i].TipNormalBackColor, 2);
                        }

                        if (this.Items[i].TipNormalTextColor == Color.Empty)
                        {
                            subitemsTipTextBrush = false;
                            commom_tip_text_sb = normal_tip_text_sb;
                        }
                        else
                        {
                            subitemsTipTextBrush = true;
                            commom_tip_text_sb = new SolidBrush(this.Items[i].TipNormalTextColor);
                        }
                        #endregion
                    }
                    else
                    {
                        #region
                        if (this.Items[i].TipDisableBackColor == Color.Empty)
                        {
                            subitemsTipBackBrush = false;
                            commom_tip_back_sb = disable_tip_back_sb;
                            subitemsTipLinePen = false;
                            commom_tip_line_pen = disable_tip_line_pen;
                        }
                        else
                        {
                            subitemsTipBackBrush = true;
                            commom_tip_back_sb = new SolidBrush(this.Items[i].TipDisableBackColor);
                            subitemsTipLinePen = true;
                            commom_tip_line_pen = new Pen(this.Items[i].TipDisableBackColor, 2);
                        }

                        if (this.Items[i].TipDisableTextColor == Color.Empty)
                        {
                            subitemsTipTextBrush = false;
                            commom_tip_text_sb = disable_tip_text_sb;
                        }
                        else
                        {
                            subitemsTipTextBrush = true;
                            commom_tip_text_sb = new SolidBrush(this.Items[i].TipDisableTextColor);
                        }
                        #endregion
                    }
                    #endregion

                    #region
                    if (this.Orientation == SlideOrientation.HorizontalTop || this.Orientation == SlideOrientation.HorizontalBottom)
                    {
                        if ((i == this.Items.Count - 1))
                        {
                            if (this.Items[i].TipRect.Right > rectf.Right)
                                this.Items[i].TipRect = new Rectangle((int)(rectf.Right - this.Items[i].TipRect.Width), this.Items[i].TipRect.Y, this.Items[i].TipRect.Width, this.Items[i].TipRect.Height);
                        }
                        else
                        {
                            if (this.Items[i].TipRect.Right + line_area > this.Items[i + 1].TipRect.X)
                                this.Items[i].TipRect = new Rectangle((this.Items[i + 1].TipRect.X - this.Items[i].TipRect.Width - line_area), this.Items[i].TipRect.Y, this.Items[i].TipRect.Width, this.Items[i].TipRect.Height);
                        }

                        this.Items[i].Slidepoint = new PointF(this.Items[i].SlideRect.X + this.Items[i].SlideRect.Width / 2, this.Items[i].SlideRect.Bottom);
                        this.Items[i].TipPoint = new PointF(this.Items[i].TipRect.X + this.Items[i].TipRect.Width / 2, this.Items[i].TipRect.Y);
                        if (this.Orientation == SlideOrientation.HorizontalBottom)
                        {
                            this.Items[i].Slidepoint = new PointF(this.Items[i].SlideRect.X + this.Items[i].SlideRect.Width / 2, this.Items[i].SlideRect.Y);
                            this.Items[i].TipPoint = new PointF(this.Items[i].TipRect.X + this.Items[i].TipRect.Width / 2, this.Items[i].TipRect.Bottom);
                        }
                    }
                    else if (this.Orientation == SlideOrientation.VerticalLeft || this.Orientation == SlideOrientation.VerticalRight)
                    {
                        if (i == this.Items.Count - 1)
                        {
                            if (this.Items[i].TipRect.Y < rectf.Y)
                                this.Items[i].TipRect = new Rectangle(this.Items[i].TipRect.X, rectf.Y, this.Items[i].TipRect.Width, this.Items[i].TipRect.Height);
                        }
                        else
                        {
                            if (this.Items[i].TipRect.Y < this.Items[i + 1].TipRect.Bottom + line_area)
                                this.Items[i].TipRect = new Rectangle(this.Items[i].TipRect.X, this.Items[i + 1].TipRect.Bottom + line_area, this.Items[i].TipRect.Width, this.Items[i].TipRect.Height);
                        }

                        this.Items[i].Slidepoint = new PointF(this.Items[i].SlideRect.Right, this.Items[i].SlideRect.Bottom - this.Items[i].SlideRect.Height / 2);
                        this.Items[i].TipPoint = new PointF(this.Items[i].TipRect.Left, this.Items[i].TipRect.Bottom - this.Items[i].TipRect.Height / 2);
                        if (this.Orientation == SlideOrientation.VerticalRight)
                        {
                            this.Items[i].Slidepoint = new PointF(this.Items[i].SlideRect.X, this.Items[i].SlideRect.Bottom - this.Items[i].SlideRect.Height / 2);
                            this.Items[i].TipPoint = new PointF(this.Items[i].TipRect.Right, this.Items[i].TipRect.Bottom - this.Items[i].TipRect.Height / 2);
                        }
                    }
                    #endregion

                    g.DrawLine(commom_tip_line_pen, this.Items[i].Slidepoint, this.Items[i].TipPoint);
                    g.FillRectangle(commom_tip_back_sb, this.Items[i].TipRect);
                    string tooltiptext_str = this.Items[i].Value.ToString("F2");
                    g.DrawString(tooltiptext_str, this.TipFont, commom_tip_text_sb, this.Items[i].TipRect);

                    #region 释放
                    if (subitemsTipLinePen && commom_tip_line_pen != null)
                    {
                        commom_tip_line_pen.Dispose();
                        commom_tip_line_pen = null;
                    }
                    if (subitemsTipBackBrush && commom_tip_back_sb != null)
                    {
                        commom_tip_back_sb.Dispose();
                        commom_tip_back_sb = null;
                    }
                    if (subitemsTipTextBrush && commom_tip_text_sb != null)
                    {
                        commom_tip_text_sb.Dispose();
                        commom_tip_text_sb = null;
                    }
                    #endregion
                }
            }
            #endregion


            #region 释放全局画笔
            if (lock_slide_sb != null)
                lock_slide_sb.Dispose();

            if (slidebar_back_sb != null)
                slidebar_back_sb.Dispose();
            if (normal_slide_back_sb != null)
                normal_slide_back_sb.Dispose();
            if (normal_tip_back_sb != null)
                normal_tip_back_sb.Dispose();
            if (normal_tip_text_sb != null)
                normal_tip_text_sb.Dispose();
            if (normal_tip_line_pen != null)
                normal_tip_line_pen.Dispose();

            if (disable_slide_back_sb != null)
                disable_slide_back_sb.Dispose();
            if (disable_tip_back_sb != null)
                disable_tip_back_sb.Dispose();
            if (disable_tip_text_sb != null)
                disable_tip_text_sb.Dispose();
            if (disable_tip_line_pen != null)
                disable_tip_line_pen.Dispose();


            if (commom_slide_back_sb != null)
                commom_slide_back_sb.Dispose();
            if (commom_tip_back_sb != null)
                commom_tip_back_sb.Dispose();
            if (commom_tip_text_sb != null)
                commom_tip_text_sb.Dispose();
            if (commom_tip_line_pen != null)
                commom_tip_line_pen.Dispose();

            if (activate_border_pen != null)
                activate_border_pen.Dispose();
            #endregion

            #endregion

            #region 边框
            if (this.Border > 0)
            {
                Pen border_pen = new Pen(this.BorderColor, this.Border);
                g.DrawRectangle(border_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.Width - this.Border, this.ClientRectangle.Height - this.Border));
                border_pen.Dispose();
            }

            #endregion
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (!this.Items[i].SlideLock)
                {
                    this.activatedState = true;
                    this.activatedStateIndex = i;
                    this.Invalidate();
                    break;
                }
            }

        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.Invalidate();
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
                    int tmp_index = this.activatedStateIndex - 1;
                    for (int i = tmp_index; i >= -1; i--)
                    {
                        int index = (i > -1) ? i : this.Items.Count - 1;
                        if (!this.Items[index].SlideLock)
                        {
                            this.activatedStateIndex = index;
                            this.Invalidate();
                            break;
                        }
                        else if (index == this.Items.Count - 1)
                        {
                            for (int j = index; j > this.activatedStateIndex; j--)
                            {
                                if (!this.Items[j].SlideLock)
                                {
                                    this.activatedStateIndex = j;
                                    this.Invalidate();
                                    break;
                                }
                            }
                        }
                    }
                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    int tmp_index = this.activatedStateIndex + 1;
                    for (int i = tmp_index; i <= this.Items.Count; i++)
                    {
                        int index = (i < this.Items.Count) ? i : 0;
                        if (!this.Items[index].SlideLock)
                        {
                            this.activatedStateIndex = index;
                            this.Invalidate();
                            break;
                        }
                        else if (index == 0)
                        {
                            for (int j = index; j < this.activatedStateIndex; j++)
                            {
                                if (!this.Items[j].SlideLock)
                                {
                                    this.activatedStateIndex = j;
                                    this.Invalidate();
                                    break;
                                }
                            }
                        }
                    }
                    return false;
                }
                #endregion
                #region Up
                else if (keyData == Keys.Up)
                {
                    float value_tmp = this.Items[this.activatedStateIndex].Value + this.ScrollInterval;

                    if (this.activatedStateIndex >= this.Items.Count - 1)
                    {
                        if (value_tmp > this.MaxValue)
                        {
                            value_tmp = this.MinValue;
                        }
                    }
                    else
                    {
                        if (value_tmp > this.Items[this.activatedStateIndex + 1].Value)
                        {
                            value_tmp = this.Items[this.activatedStateIndex + 1].Value;
                        }
                    }

                    if (value_tmp != this.Items[this.activatedStateIndex].Value)
                    {
                        this.Items[this.activatedStateIndex].UpdateValue(value_tmp);
                    }
                    return false;
                }
                #endregion
                #region Down
                else if (keyData == Keys.Down)
                {
                    float value_tmp = this.Items[this.activatedStateIndex].Value - this.ScrollInterval;

                    if (this.activatedStateIndex <= 0)
                    {
                        if (value_tmp < this.minValue)
                        {
                            value_tmp = this.minValue;
                        }
                    }
                    else
                    {
                        if (value_tmp < this.Items[this.activatedStateIndex - 1].Value)
                        {
                            value_tmp = this.Items[this.activatedStateIndex - 1].Value;
                        }
                    }

                    if (value_tmp != this.Items[this.activatedStateIndex].Value)
                    {
                        this.Items[this.activatedStateIndex].UpdateValue(value_tmp);
                    }
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

            this.move_status = SlideMoveStatus.Enter;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.move_status = SlideMoveStatus.Leave;
            this.selectIndex = -1;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            this.move_status = SlideMoveStatus.Down;
            Point point = this.PointToClient(Control.MousePosition);
            this.move_point = point;
            int active_index = this.GetSelectedSlideIndex(point);

            if (active_index > -1)
            {
                if (!this.Items[active_index].SlideLock)
                {
                    this.selectIndex = active_index;
                    this.Select();
                    this.activatedStateIndex = active_index;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            this.move_status = SlideMoveStatus.Up;
            this.selectIndex = -1;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode)
                return;

            if (this.activatedState)
            {
                #region Up
                if (e.Delta > 0)
                {
                    float value_tmp = this.Items[this.activatedStateIndex].Value + this.ScrollInterval;

                    if (this.activatedStateIndex >= this.Items.Count - 1)
                    {
                        if (value_tmp > this.MaxValue)
                        {
                            value_tmp = this.MinValue;
                        }
                    }
                    else
                    {
                        if (value_tmp > this.Items[this.activatedStateIndex + 1].Value)
                        {
                            value_tmp = this.Items[this.activatedStateIndex + 1].Value;
                        }
                    }

                    if (value_tmp != this.Items[this.activatedStateIndex].Value)
                    {
                        this.Items[this.activatedStateIndex].UpdateValue(value_tmp);
                    }
                }
                #endregion
                #region Down
                else if (e.Delta < 0)
                {
                    float value_tmp = this.Items[this.activatedStateIndex].Value - this.ScrollInterval;

                    if (this.activatedStateIndex <= 0)
                    {
                        if (value_tmp < this.minValue)
                        {
                            value_tmp = this.minValue;
                        }
                    }
                    else
                    {
                        if (value_tmp < this.Items[this.activatedStateIndex - 1].Value)
                        {
                            value_tmp = this.Items[this.activatedStateIndex - 1].Value;
                        }
                    }

                    if (value_tmp != this.Items[this.activatedStateIndex].Value)
                    {
                        this.Items[this.activatedStateIndex].UpdateValue(value_tmp);
                    }
                }
                #endregion
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.move_status == SlideMoveStatus.Down)
            {
                if (this.selectIndex > -1)
                {
                    this.InitializeSlideValueByPoint(this.Items[this.selectIndex], (e.Button == System.Windows.Forms.MouseButtons.Right));
                }
            }
            else
            {
                Point point = this.PointToClient(Control.MousePosition);
                int index = this.GetSelectedSlideIndex(point);
                this.Cursor = (index > -1 && !this.Items[index].SlideLock) ? Cursors.Hand : Cursors.Default;
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeMultidropSlideBarRectangle();
        }

        #endregion

        #region 虚方法

        protected virtual void OnSlideValueChanged(ValueChangedEventArgs e)
        {
            if (this.valueChanged != null)
            {
                this.valueChanged(this, e);
            }
        }

        protected virtual void OnSlideGlobalValueChanged(GlobalValueChangedEventArgs e)
        {
            if (this.globalValueChanged != null)
            {
                this.globalValueChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化所有滑块Rectangle
        /// </summary>
        /// <param name="item"></param>
        private void InitializeMultidropSlideBarRectangle()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.InitializeMultidropSlideBarItemRectangle(this.Items[i]);
            }
        }

        /// <summary>
        /// 初始化指定滑块Rectangle
        /// </summary>
        /// <param name="item"></param>
        private void InitializeMultidropSlideBarItemRectangle(MultidropSlideBarItem item)
        {
            Rectangle rect = new Rectangle(this.SlidePadding, this.SlidePadding, this.ClientRectangle.Width - this.SlidePadding * 2, this.ClientRectangle.Height - this.SlidePadding * 2);

            int index = this.Items.IndexOf(item);
            if (this.Orientation == SlideOrientation.HorizontalBottom || this.Orientation == SlideOrientation.HorizontalTop)
            {
                float back_l = rect.Width - this.SlideWidth - (this.Items.Count - 1) * this.SlideWidth;
                int slide_x = this.SlidePadding + (this.SlideWidth / 2) + (int)(item.Value / (Math.Abs(this.MinValue) + Math.Abs(this.MaxValue)) * back_l);
                if (slide_x < 0)
                    slide_x = 0;
                if (slide_x > rect.Right - this.SlideWidth / 2)
                    slide_x = rect.Right - this.SlideWidth / 2;

                int slide_y = (this.Orientation == SlideOrientation.HorizontalTop) ? rect.Y : rect.Bottom - this.SlideHeight - this.SlidePadding;
                item.SlideRect = new RectangleF(slide_x - (this.SlideWidth / 2) + index * this.SlideWidth, slide_y, this.SlideWidth, this.SlideHeight);
            }
            else
            {
                float back_l = rect.Height - this.SlideHeight - (this.Items.Count - 1) * this.SlideHeight;
                int slide_y = rect.Bottom - (this.SlideHeight / 2) - (int)(item.Value / (Math.Abs(this.MinValue) + Math.Abs(this.MaxValue)) * back_l);
                if (slide_y < 0)
                    slide_y = 0;
                if (slide_y > rect.Bottom - this.SlideHeight / 2)
                    slide_y = rect.Bottom - this.SlideHeight / 2;
                int slide_x = (this.Orientation == SlideOrientation.VerticalLeft) ? rect.X : rect.Right - this.SlideWidth - this.SlidePadding;
                item.SlideRect = new RectangleF(slide_x, slide_y - (this.SlideHeight / 2) - index * this.SlideHeight, this.SlideWidth, this.SlideHeight);
            }
        }

        /// <summary>
        /// 根据当前鼠标坐标计算滑块值
        /// </summary>
        /// <param name="item">当前滑块</param>
        /// <param name="isGlobal">是否为全局值</param>
        private void InitializeSlideValueByPoint(MultidropSlideBarItem item, bool isGlobal)
        {
            Rectangle rect = new Rectangle(this.SlidePadding, this.SlidePadding, this.ClientRectangle.Width - this.SlidePadding * 2, this.ClientRectangle.Height - this.SlidePadding * 2);
            Point point = this.PointToClient(Control.MousePosition);

            if (this.Orientation == SlideOrientation.HorizontalTop || this.Orientation == SlideOrientation.HorizontalBottom)
            {
                if (point.X == this.move_point.X)
                    return;

                int index = this.Items.IndexOf(item);
                float value_l = Math.Abs(this.MinValue) + Math.Abs(this.MaxValue);//值总长度
                float back_l = rect.Width - this.SlideWidth - (this.Items.Count - 1) * this.SlideWidth;//背景总长度
                float increment = value_l / back_l;//一个像素代表曾值量

                float value = item.Value;
                value += increment * (point.X - this.move_point.X);
                this.move_point = point;

                if (isGlobal)
                    item.UpdateGlobalValue(value);
                else
                    item.UpdateValue(value);
            }
            else
            {
                if (point.Y == this.move_point.Y)
                    return;

                int index = this.Items.IndexOf(item);
                float value_l = Math.Abs(this.MinValue) + Math.Abs(this.MaxValue);//值总长度
                float back_l = rect.Height - this.SlideHeight - (this.Items.Count - 1) * this.SlideHeight;//背景总长度
                float increment = value_l / back_l;//一个像素代表曾值量

                float value = item.Value;
                value -= increment * (point.Y - this.move_point.Y);
                this.move_point = point;

                if (isGlobal)
                    item.UpdateGlobalValue(value);
                else
                    item.UpdateValue(value);
            }
        }

        /// <summary>
        /// 获取选中滑块索引
        /// </summary>
        /// <param name="point">当前鼠标坐标</param>
        /// <returns></returns>
        private int GetSelectedSlideIndex(Point point)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].SlideRect.Contains(point))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 绘制滑块条渐变背景色
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectf">渐变背景色rectf</param>
        /// <param name="ishorizontal">是否横向</param>
        private void DrawBarLinearGradient(Graphics g, RectangleF rectf, bool ishorizontal)
        {
            if (this.SlideBarRadius)
            {
                GraphicsPath bar_back_gp = new GraphicsPath();
                if (ishorizontal)
                {
                    bar_back_gp.AddArc(new RectangleF(rectf.X, rectf.Y, (float)this.SlideBarThickness, (float)this.SlideBarThickness), 90, 180);
                    bar_back_gp.AddArc(new RectangleF(rectf.Right - this.SlideBarThickness, rectf.Top, (float)this.SlideBarThickness, (float)this.SlideBarThickness), 270, 180);
                }
                else
                {
                    bar_back_gp.AddArc(new RectangleF(rectf.X, rectf.Y, (float)this.SlideBarThickness, (float)this.SlideBarThickness), 180, 180);
                    bar_back_gp.AddArc(new RectangleF(rectf.X, rectf.Bottom - (float)this.SlideBarThickness, (float)this.SlideBarThickness, (float)this.SlideBarThickness), 0, 180);
                }
                bar_back_gp.CloseFigure();
                if (this.Enabled)
                {
                    LinearGradientBrush bar_back_lgb = this.GetLinearGradientBrush(this.BarColorItems, rectf, ishorizontal ? 0f : 270f);
                    g.FillPath(bar_back_lgb, bar_back_gp);
                    bar_back_lgb.Dispose();
                }
                else
                {
                    SolidBrush bar_back_sb = new SolidBrush(this.SlideBarDisableBackColor);
                    g.FillPath(bar_back_sb, bar_back_gp);
                    bar_back_sb.Dispose();
                }
                bar_back_gp.Dispose();
            }
            else
            {
                if (this.Enabled)
                {
                    LinearGradientBrush bar_back_lgb = this.GetLinearGradientBrush(this.BarColorItems, rectf, ishorizontal ? 0f : 270f);
                    g.FillRectangle(bar_back_lgb, rectf);
                    bar_back_lgb.Dispose();
                }
                else
                {
                    SolidBrush bar_back_sb = new SolidBrush(this.SlideBarDisableBackColor);
                    g.FillRectangle(bar_back_sb, rectf);
                    bar_back_sb.Dispose();
                }
            }
        }

        /// <summary>
        /// 绘制滑块条进度渐变背景色
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectf">渐变背景色rectf</param>
        /// <param name="ishorizontal">是否横向</param>
        private void DrawProgressLinearGradient(Graphics g, RectangleF rectf, bool ishorizontal)
        {
            if (this.SlideBarRadius)
            {
                GraphicsPath bar_progress_gp = new GraphicsPath();
                if (ishorizontal)
                {
                    bar_progress_gp.AddArc(new RectangleF(rectf.X, rectf.Y, (float)this.SlideBarThickness, (float)this.SlideBarThickness), 90, 180);
                    bar_progress_gp.AddLine(new PointF(rectf.Right, rectf.Top), new PointF(rectf.Right, rectf.Bottom));
                }
                else
                {
                    bar_progress_gp.AddArc(new RectangleF(rectf.X, rectf.Bottom - this.SlideBarThickness, (float)this.SlideBarThickness, (float)this.SlideBarThickness), 0, 180);
                    bar_progress_gp.AddLine(new PointF(rectf.X, rectf.Y), new PointF(rectf.Right, rectf.Y));

                }
                bar_progress_gp.CloseFigure();
                if (this.Enabled)
                {
                    LinearGradientBrush bar_progress_lgb = this.GetLinearGradientBrush(this.BarProgressColorItems, rectf, ishorizontal ? 0f : 270f);
                    g.FillPath(bar_progress_lgb, bar_progress_gp);
                    bar_progress_lgb.Dispose();
                }
                else
                {
                    SolidBrush bar_progress_sb = new SolidBrush(this.SlideBarDisableBackColor);
                    g.FillPath(bar_progress_sb, bar_progress_gp);
                    bar_progress_sb.Dispose();
                }
                bar_progress_gp.Dispose();
            }
            else
            {
                if (this.Enabled)
                {
                    LinearGradientBrush bar_progress_lgb = this.GetLinearGradientBrush(this.BarProgressColorItems, rectf, ishorizontal ? 0f : 270f);
                    g.FillRectangle(bar_progress_lgb, rectf);
                    bar_progress_lgb.Dispose();
                }
                else
                {
                    SolidBrush bar_progress_sb = new SolidBrush(this.SlideBarDisableBackColor);
                    g.FillRectangle(bar_progress_sb, rectf);
                    bar_progress_sb.Dispose();
                }
            }
        }

        /// <summary>
        /// 获取渐变画笔
        /// </summary>
        /// <param name="list"></param>
        /// <param name="rectf"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private LinearGradientBrush GetLinearGradientBrush(MultidropSlideBarColorItemCollection list, RectangleF rectf, float angle)
        {
            LinearGradientBrush lgb = null;
            if (list.Count > 1)
            {
                if (list[0].Position != 0)
                    list[0].Position = 0;
                if (list[list.Count - 1].Position != 1)
                    list[list.Count - 1].Position = 1;

                Color[] colors = new Color[list.Count];
                float[] positions = new float[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    colors[i] = list[i].Color;
                    positions[i] = list[i].Position;
                }
                ColorBlend blend = new ColorBlend() { Positions = positions, Colors = colors };
                lgb = new LinearGradientBrush(rectf, Color.Transparent, Color.Transparent, angle, true) { InterpolationColors = blend };
            }
            return lgb;
        }

        #endregion

        #region 类

        /// <summary>
        /// 滑块选项集合
        /// </summary>
        [Description("滑块选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class MultidropSlideBarItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList multidropSlideBarItemList = new ArrayList();
            private MultidropSlideBarExt owner;

            public MultidropSlideBarItemCollection(MultidropSlideBarExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                MultidropSlideBarItem[] listArray = new MultidropSlideBarItem[this.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (MultidropSlideBarItem)this.multidropSlideBarItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.multidropSlideBarItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.multidropSlideBarItemList.Count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return (object)this;
                }
            }

            #endregion

            #region IList

            /// <summary>
            /// 添加滑块选项（返回插入滑块选项的索引）
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public int Add(object value)
            {
                if (!(value is MultidropSlideBarItem))
                {
                    throw new ArgumentException("MultidropSlideBarItem");
                }
                return this.Add((MultidropSlideBarItem)value);
            }

            /// <summary>
            /// 添加滑块选项（返回插入滑块选项的索引）
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public int Add(MultidropSlideBarItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                item.UpdateOwner(this.owner);

                float value_tmp = item.DefaultValue;
                if (value_tmp < this.owner.MinValue)
                    value_tmp = this.owner.MinValue;
                if (value_tmp > this.owner.MaxValue)
                    value_tmp = this.owner.MaxValue;

                int insert_index = 0;
                ArrayList multidropSlideBarItemList_tmp = new ArrayList();
                if (this.multidropSlideBarItemList.Count == 0)
                {
                    multidropSlideBarItemList_tmp.Add(item);
                    item.UpdateDefaultValue(value_tmp);
                }
                else
                {
                    #region 获取插入的索引
                    for (int i = 0; i < multidropSlideBarItemList.Count; i++)
                    {
                        if (value_tmp >= ((MultidropSlideBarItem)this.multidropSlideBarItemList[i]).Value)
                        {
                            insert_index += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion

                    for (int i = 0; i < this.multidropSlideBarItemList.Count; i++)
                    {
                        if (insert_index == 0 && i == 0)
                        {
                            multidropSlideBarItemList_tmp.Add(item);
                            item.UpdateDefaultValue(value_tmp);
                            multidropSlideBarItemList_tmp.Add(this.multidropSlideBarItemList[i]);
                        }
                        else
                        {
                            multidropSlideBarItemList_tmp.Add(this.multidropSlideBarItemList[i]);
                            if (i + 1 == insert_index)
                            {
                                multidropSlideBarItemList_tmp.Add(item);
                                item.UpdateDefaultValue(value_tmp);
                            }
                        }
                    }
                }
                this.multidropSlideBarItemList = multidropSlideBarItemList_tmp;
                this.owner.InitializeMultidropSlideBarRectangle();
                this.owner.Invalidate();
                return insert_index;
            }

            public void Clear()
            {
                this.multidropSlideBarItemList.Clear();
                this.owner.Invalidate();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is MultidropSlideBarItem)
                {
                    return this.Contains((MultidropSlideBarItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is MultidropSlideBarItem)
                {
                    return this.multidropSlideBarItemList.IndexOf(item);
                }
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Remove(object value)
            {
                if (!(value is MultidropSlideBarItem))
                {
                    throw new ArgumentException("MultidropSlideBarItem");
                }
                this.multidropSlideBarItemList.Remove((MultidropSlideBarItem)value);
                this.owner.Invalidate();
            }

            public void Remove(MultidropSlideBarItem item)
            {
                this.multidropSlideBarItemList.Remove(item);
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.multidropSlideBarItemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public MultidropSlideBarItem this[int index]
            {
                get
                {
                    return (MultidropSlideBarItem)this.multidropSlideBarItemList[index];
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.multidropSlideBarItemList[index];
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            #endregion

        }

        /// <summary>
        /// 滑块条颜色级别配置集合
        /// </summary>
        [Description("滑块条颜色级别配置集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class MultidropSlideBarColorItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList multidropSlideBarColorItemList = new ArrayList();
            private MultidropSlideBarExt owner;

            public MultidropSlideBarColorItemCollection(MultidropSlideBarExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                MultidropSlideBarColorItem[] listArray = new MultidropSlideBarColorItem[this.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (MultidropSlideBarColorItem)this.multidropSlideBarColorItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.multidropSlideBarColorItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.multidropSlideBarColorItemList.Count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return (object)this;
                }
            }

            #endregion

            #region IList

            public int Add(object value)
            {
                if (!(value is MultidropSlideBarColorItem))
                {
                    throw new ArgumentException("MultidropSlideBarColorItem");
                }
                return this.Add((MultidropSlideBarColorItem)value);
            }

            public int Add(MultidropSlideBarColorItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                this.multidropSlideBarColorItemList.Add(item);
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.multidropSlideBarColorItemList.Clear();
                this.owner.Invalidate();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is MultidropSlideBarColorItem)
                {
                    return this.Contains((MultidropSlideBarColorItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is MultidropSlideBarColorItem)
                {
                    return this.multidropSlideBarColorItemList.IndexOf(item);
                }
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Remove(object value)
            {
                if (!(value is MultidropSlideBarColorItem))
                {
                    throw new ArgumentException("MultidropSlideBarColorItem");
                }
                this.Remove((MultidropSlideBarColorItem)value);
            }

            public void Remove(MultidropSlideBarColorItem item)
            {
                this.multidropSlideBarColorItemList.Remove(item);
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.multidropSlideBarColorItemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public MultidropSlideBarColorItem this[int index]
            {
                get
                {
                    return (MultidropSlideBarColorItem)this.multidropSlideBarColorItemList[index];
                }
                set
                {
                    this.multidropSlideBarColorItemList[index] = (MultidropSlideBarColorItem)value;
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.multidropSlideBarColorItemList[index];
                }
                set
                {
                    this.multidropSlideBarColorItemList[index] = (MultidropSlideBarColorItem)value;
                    this.owner.Invalidate();
                }
            }

            #endregion
        }

        /// <summary>
        /// 滑块选项
        /// </summary>
        [Description("滑块选项")]
        public class MultidropSlideBarItem
        {
            private MultidropSlideBarExt owner;

            public MultidropSlideBarItem()
            {

            }

            #region 滑块

            private RectangleF slideRect = new RectangleF();
            /// <summary>
            /// 滑块rect
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("滑块rect")]
            public RectangleF SlideRect
            {
                get { return this.slideRect; }
                set
                {
                    if (this.slideRect == value)
                        return;
                    this.slideRect = value;
                }
            }

            private bool slideLock = false;
            /// <summary>
            /// 滑块是否锁定
            /// </summary>
            [Browsable(true)]
            [DefaultValue(false)]
            [Description("滑块是否锁定")]
            public bool SlideLock
            {
                get { return this.slideLock; }
                set
                {
                    if (this.slideLock == value)
                        return;
                    this.slideLock = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private float value = 0;
            /// <summary>
            /// 滑块值
            /// </summary>
            [Browsable(false)]
            [Description("滑块值")]
            public float Value
            {
                get
                {
                    return this.DefaultValueInit ? this.value : this.defaultValue;
                }
            }

            private float defaultValue = 0;
            /// <summary>
            /// 滑块初始化值
            /// </summary>
            [Browsable(true)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DefaultValue(0)]
            [Description("滑块初始化值")]
            public float DefaultValue
            {
                get { return this.defaultValue; }
                set
                {
                    this.defaultValue = value;
                }
            }

            private bool defaultValueInit = false;
            /// <summary>
            /// 滑块初始化值是否已初始化到滑块上
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DefaultValue(false)]
            [Description("滑块初始化值是否已初始化到滑块上")]
            public bool DefaultValueInit
            {
                get { return this.defaultValueInit; }
                set
                {
                    this.defaultValueInit = value;
                }
            }

            private PointF slidePoint = new Point();
            /// <summary>
            /// 滑块连线的坐标
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("滑块连线的坐标")]
            public PointF Slidepoint
            {
                get { return this.slidePoint; }
                set
                {
                    if (this.slidePoint == value)
                        return;
                    this.slidePoint = value;
                }
            }

            private PointF tipPoint = new Point();
            /// <summary>
            /// 提示信息连线的坐标
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("提示信息连线的坐标")]
            public PointF TipPoint
            {
                get { return this.tipPoint; }
                set
                {
                    if (this.tipPoint == value)
                        return;
                    this.tipPoint = value;
                }
            }

            private Color slideNormalBackColor = Color.Empty;
            /// <summary>
            /// 滑块颜色
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("滑块颜色")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color SlideNormalBackColor
            {
                get { return this.slideNormalBackColor; }
                set
                {
                    if (this.slideNormalBackColor == value)
                        return;
                    this.slideNormalBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color slideDisableBackColor = Color.Empty;
            /// <summary>
            /// 滑块背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("滑块背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color SlideDisableBackColor
            {
                get { return this.slideDisableBackColor; }
                set
                {
                    if (this.slideDisableBackColor == value)
                        return;
                    this.slideDisableBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            #region 提示信息

            private Rectangle tipRect = new Rectangle();
            /// <summary>
            /// 提示信息rect
            /// </summary>
            [Browsable(false)]
            [Description("提示信息rect")]
            public Rectangle TipRect
            {
                get { return this.tipRect; }
                set
                {
                    if (this.tipRect == value)
                        return;
                    this.tipRect = value;
                }
            }

            private Color tipNormalBackColor = Color.Empty;
            /// <summary>
            /// 提示信息背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("提示信息背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color TipNormalBackColor
            {
                get { return this.tipNormalBackColor; }
                set
                {
                    if (this.tipNormalBackColor == value)
                        return;
                    this.tipNormalBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color tipDisableBackColor = Color.Empty;
            /// <summary>
            /// 提示信息背景颜色（禁止）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("提示信息背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color TipDisableBackColor
            {
                get { return this.tipDisableBackColor; }
                set
                {
                    if (this.tipDisableBackColor == value)
                        return;
                    this.tipDisableBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color tipNormalTextColor = Color.Empty;
            /// <summary>
            /// 提示信息文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("提示信息文本颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color TipNormalTextColor
            {
                get { return this.tipNormalTextColor; }
                set
                {
                    if (this.tipNormalTextColor == value)
                        return;
                    this.tipNormalTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color tipDisableTextColor = Color.Empty;
            /// <summary>
            /// 提示信息文本颜色（禁止）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("提示信息文本颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color TipDisableTextColor
            {
                get { return this.tipDisableTextColor; }
                set
                {
                    if (this.tipDisableTextColor == value)
                        return;
                    this.tipDisableTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 更改主容器控件
            /// </summary>
            /// <param name="owner"></param>
            [Description("更改主容器控件")]
            internal void UpdateOwner(MultidropSlideBarExt owner)
            {
                this.owner = owner;
            }

            /// <summary>
            /// 初始化滑块初始化值
            /// </summary>
            /// <param name="value"></param>
            [Description("初始化滑块初始化值")]
            internal void UpdateDefaultValue(float value)
            {
                this.DefaultValueInit = true;
                this.value = value;

                if (!this.owner.DesignMode)
                {
                    this.owner.OnSlideValueChanged(new ValueChangedEventArgs() { Item = this });
                }
            }

            /// <summary>
            /// 更改值
            /// </summary>
            /// <param name="value"></param>
            [Description("更改值")]
            public void UpdateValue(float value)
            {
                if (this.owner == null)
                {
                    throw new ArgumentNullException("滑块选项值修改方法调用必须在添加到集合之后");
                }

                if (this.SlideLock)
                    return;

                if (value < this.owner.MinValue)
                    value = this.owner.MinValue;
                if (value > this.owner.MaxValue)
                    value = this.owner.MaxValue;

                if (this.value == value)
                    return;


                int index = this.owner.Items.IndexOf(this);

                if (this.owner.Items.Count > 1)
                {
                    #region 防止大于右边滑块值
                    if (value > this.value)
                    {
                        if (index < this.owner.Items.Count - 1)
                        {
                            if (value > this.owner.Items[index + 1].Value)
                            {
                                value = this.owner.Items[index + 1].Value;
                            }
                        }
                    }
                    #endregion
                    #region 防止大于左边滑块值
                    else if (value < this.value)
                    {
                        if (index > 0)
                        {
                            if (value < this.owner.Items[index - 1].Value)
                            {
                                value = this.owner.Items[index - 1].Value;
                            }
                        }
                    }
                    #endregion
                }

                this.value = value;
                this.owner.InitializeMultidropSlideBarItemRectangle(this);
                this.owner.Invalidate();

                if (!this.owner.DesignMode)
                {
                    this.owner.OnSlideValueChanged(new ValueChangedEventArgs() { Item = this });
                }
            }

            /// <summary>
            /// 更改全局值值
            /// </summary>
            /// <param name="value"></param>
            public void UpdateGlobalValue(float value)
            {
                if (this.owner == null)
                {
                    throw new ArgumentNullException("滑块选项值修改方法调用必须在添加到集合之后");
                }

                if (this.SlideLock)
                    return;

                if (value < this.owner.MinValue)
                    value = this.owner.MinValue;
                if (value > this.owner.MaxValue)
                    value = this.owner.MaxValue;

                if (this.value == value)
                    return;

                List<int> updateIndexList = new List<int>();
                if (this.owner.Items.Count > 1)
                {
                    #region 防止大于右边禁止滑块值
                    if (value > this.value)
                    {
                        int index = this.owner.Items.IndexOf(this);
                        int lock_index = this.owner.Items.Count - 1;

                        for (int i = index + 1; i < this.owner.Items.Count; i++)
                        {
                            if (this.owner.Items[i].SlideLock)
                            {
                                lock_index = i;
                                if (value > this.owner.Items[i].value)
                                {
                                    value = this.owner.Items[i].value;
                                }
                                break;
                            }
                        }
                        for (int i = index + 1; i <= lock_index; i++)
                        {
                            if (value > this.owner.Items[i].Value)
                            {
                                updateIndexList.Add(i);
                                this.owner.Items[i].value = value;
                                this.owner.InitializeMultidropSlideBarItemRectangle(this.owner.Items[i]);
                            }
                        }
                    }
                    #endregion
                    #region 防止大于左边禁止滑块值
                    else if (value < this.value)
                    {
                        int index = this.owner.Items.IndexOf(this);
                        int lock_index = 0;

                        for (int i = index - 1; i > -1; i--)
                        {
                            if (this.owner.Items[i].SlideLock)
                            {
                                lock_index = i;
                                if (value < this.owner.Items[i].value)
                                {
                                    value = this.owner.Items[i].value;
                                }
                                break;
                            }
                        }
                        for (int i = index - 1; i >= lock_index; i--)
                        {
                            if (value < this.owner.Items[i].Value)
                            {
                                updateIndexList.Add(i);
                                this.owner.Items[i].value = value;
                                this.owner.InitializeMultidropSlideBarItemRectangle(this.owner.Items[i]);
                            }
                        }

                    }
                    #endregion
                }
                this.value = value;
                this.owner.InitializeMultidropSlideBarItemRectangle(this);
                this.owner.Invalidate();

                if (!this.owner.DesignMode)
                {
                    this.owner.OnSlideGlobalValueChanged(new GlobalValueChangedEventArgs() { Item = this, UpdateIndexList = updateIndexList });
                }
            }

            #endregion
        }

        /// <summary>
        /// 滑块条颜色级别配置
        /// </summary>
        [Description("滑块条颜色级别配置")]
        public class MultidropSlideBarColorItem
        {
            private float position = 0f;
            /// <summary>
            /// 渐变值0-1
            /// </summary>
            [DefaultValue(0f)]
            [Description("渐变值0-1")]
            public float Position
            {
                get { return this.position; }
                set
                {
                    if (this.position == value || value < 0 || value > 1)
                        return;
                    this.position = value;
                }
            }

            private Color color = Color.FromArgb(255, 128, 128);
            /// <summary>
            /// 渐变值对应渐变颜色
            /// </summary>
            [DefaultValue(typeof(Color), "255, 128, 128")]
            [Description("渐变值对应渐变颜色")]
            public Color Color
            {
                get { return this.color; }
                set
                {
                    if (this.color == value)
                        return;
                    this.color = value;
                }
            }
        }

        /// <summary>
        /// 滑块选项值更改事件参数
        /// </summary>
        [Description("滑块选项值更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 滑块选项
            /// </summary>
            [Description("滑块选项")]
            public MultidropSlideBarItem Item { get; set; }
        }

        /// <summary>
        /// 滑块选项值更改事件参数(根据全局值修改)
        /// </summary>
        [Description("滑块选项值更改事件参数(根据全局值修改)")]
        public class GlobalValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 滑块选项
            /// </summary>
            [Description("滑块选项")]
            public MultidropSlideBarItem Item { get; set; }

            /// <summary>
            /// 受全局值影响的选项列表
            /// </summary>
            [Description("受全局值影响的选项列表")]
            public List<int> UpdateIndexList { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 滑块鼠标状态
        /// </summary>
        [Description("滑块鼠标状态")]
        private enum SlideMoveStatus
        {
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter,
            /// <summary>
            /// 鼠标离开
            /// </summary>
            Leave,
            /// <summary>
            /// 鼠标按下
            /// </summary>
            Down,
            /// <summary>
            /// 鼠标按下释放
            /// </summary>
            Up
        }

        /// <summary>
        /// 滑块方向位置
        /// </summary>
        [Description("滑块方向位置")]
        public enum SlideOrientation
        {
            /// <summary>
            ///水平放置靠近上边
            /// </summary>
            HorizontalTop,
            /// <summary>
            /// 水平放置靠近下边
            /// </summary>
            HorizontalBottom,
            /// <summary>
            /// 垂直放置靠近左边
            /// </summary>
            VerticalLeft,
            /// <summary>
            /// 垂直放置靠近右边
            /// </summary>
            VerticalRight,
        }

        #endregion

    }
}
