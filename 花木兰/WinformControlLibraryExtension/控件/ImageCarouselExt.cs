
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
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 走马灯图片轮播控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("走马灯图片轮播控件")]
    [DefaultProperty("Images")]
    [DefaultEvent("NavigationBarBtnClick")]
    [Designer(typeof(ImageCarouselExtDesigner))]
    public class ImageCarouselExt : Control
    {
        #region 新增事件

        public delegate void ImageFrameEventHandler(object sender, ImageFrameIndexChangedEventArgs e);

        private event ImageFrameEventHandler imageFrameIndexChanged;
        /// <summary>
        /// 图片轮播选项索引更改事件
        /// </summary>
        [Description("图片轮播选项索引更改事件")]
        public event ImageFrameEventHandler ImageFrameIndexChanged
        {
            add { this.imageFrameIndexChanged += value; }
            remove { this.imageFrameIndexChanged -= value; }
        }

        public delegate void NavigationBarBtnClickEventHandler(object sender, NavigationBarBtnClickEventArgs e);

        private event NavigationBarBtnClickEventHandler navigationBarBtnClick;
        /// <summary>
        /// 导航栏按钮单击事件
        /// </summary>
        [Description("导航栏按钮单击事件")]
        public event NavigationBarBtnClickEventHandler NavigationBarBtnClick
        {
            add { this.navigationBarBtnClick += value; }
            remove { this.navigationBarBtnClick -= value; }
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

        private Orientations orientation = Orientations.RightToLeft;
        /// <summary>
        ///图片轮播播放方向 
        /// </summary>
        [DefaultValue(Orientations.RightToLeft)]
        [Description("图片轮播播放方向")]
        public Orientations Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation == value)
                    return;

                this.orientation = value;
                this.current_orientation = this.orientation;
                this.InitializeSlideDirection();
                this.InitializeDisplayRectangle();
                this.InitializeImageFrameRectangleIndex();
                this.Invalidate();
            }
        }

        private bool borderShow = false;
        /// <summary>
        ///是否显示边框
        /// </summary>
        [DefaultValue(false)]
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

        private bool enterStop = false;
        /// <summary>
        /// 鼠标进入是是否停止自动切换
        /// </summary>
        [DefaultValue(false)]
        [Description("鼠标进入是是否停止自动切换")]
        public bool EnterStop
        {
            get { return this.enterStop; }
            set
            {
                if (this.enterStop == value)
                    return;
                this.enterStop = value;
            }
        }

        private double animationTime = 500d;
        /// <summary>
        /// 动画播放的总时间
        /// </summary>
        [DefaultValue(500d)]
        [Description("动画播放的总时间(默认500毫秒)")]
        public double AnimationTime
        {
            get { return this.animationTime; }
            set
            {
                if (this.animationTime == value || value < 0)
                    return;
                this.animationTime = value;
            }
        }

        private int intervalTime = 1000;
        /// <summary>
        /// 图片轮播的时间间隔
        /// </summary>
        [DefaultValue(1000)]
        [Description("图片轮播的时间间隔(默认1000毫秒)")]
        public int IntervalTime
        {
            get { return this.intervalTime; }
            set
            {
                if (this.intervalTime == value || value < 0)
                    return;
                this.intervalTime = value;
            }
        }

        private int enableImageCurrentIndex = 0;
        /// <summary>
        ///已启用图片列表的当前显示区的开始图片的索引（负向第一个为最左边、正向第一个为最右边）
        /// </summary>
        [DefaultValue(0)]
        [Description("已启用图片列表的当前显示区的开始图片的索引（负向第一个为最左边、正向第一个为最右边）")]
        public int EnableImageCurrentIndex
        {
            get { return this.enableImageCurrentIndex; }
            set
            {
                if (value < 0 || value >= this.enableImageList.Count)
                    return;

                this.enableImageCurrentIndex = value;

                this.RestoreOrientation();
                this.InitializeImageFrameRectangleIndex();
                //跳过更新索引
                this.Invalidate();

                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new ImageFrameIndexChangedEventArgs() { index = value, Item = this.Images[value] });
                }
            }
        }

        private ImageItemCollection imageItemCollection;
        /// <summary>
        /// 图片选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("图片选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ImageItemCollection Images
        {
            get
            {
                if (this.imageItemCollection == null)
                    this.imageItemCollection = new ImageItemCollection(this);
                return this.imageItemCollection;
            }
        }

        #region 图片框

        private int imageFrameCount = 1;
        /// <summary>
        ///显示区要显示的图片框数量(最小值1)
        /// </summary>
        [DefaultValue(1)]
        [Description("显示区要显示的图片框数量(最小值1)")]
        public int ImageFrameCount
        {
            get { return this.imageFrameCount; }
            set
            {
                if (this.imageFrameCount == value || value < 1)
                    return;
                this.imageFrameCount = value;
                this.LoadImageFrame();
                this.InitializeDisplayRectangle();
                this.InitializeImageFrameRectangleIndex();
                this.Invalidate();
            }
        }

        private int imageFrameWidth = 400;
        /// <summary>
        ///图片框宽度 
        /// </summary>
        [DefaultValue(400)]
        [Description("图片框宽度")]
        public int ImageFrameWidth
        {
            get { return this.imageFrameWidth; }
            set
            {
                if (this.imageFrameWidth == value || value < 0)
                    return;
                this.imageFrameWidth = value;
                this.InitializeSlideDirection();
                this.InitializeDisplayRectangle();
                this.InitializeImageFrameRectangleIndex();
                this.Invalidate();
            }
        }

        private int imageFrameHeight = 200;
        /// <summary>
        ///图片框高度 
        /// </summary>
        [DefaultValue(200)]
        [Description("图片框高度")]
        public int ImageFrameHeight
        {
            get { return this.imageFrameHeight; }
            set
            {
                if (this.imageFrameHeight == value || value < 0)
                    return;
                this.imageFrameHeight = value;
                this.InitializeSlideDirection();
                this.InitializeDisplayRectangle();
                this.InitializeImageFrameRectangleIndex();
                this.Invalidate();
            }
        }

        #endregion

        #region 图片文本

        private bool textShow = true;
        /// <summary>
        ///是否显示图片文字 
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示图片文字")]
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

        private Color textBackColor = Color.FromArgb(70, 128, 128, 128);
        /// <summary>
        ///图片文字背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "70, 128, 128, 128")]
        [Description("图片文字背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TextBackColor
        {
            get { return this.textBackColor; }
            set
            {
                if (this.textBackColor == value)
                    return;
                this.textBackColor = value;
                this.Invalidate();
            }
        }

        private Color textForeColor = Color.FromArgb(100, 255, 99, 71);
        /// <summary>
        ///图片文字颜色
        /// </summary>
        [DefaultValue(typeof(Color), "100, 255, 99, 71")]
        [Description("图片文字颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TextForeColor
        {
            get { return this.textForeColor; }
            set
            {
                if (this.textForeColor == value)
                    return;
                this.textForeColor = value;
                this.Invalidate();
            }
        }

        private Font textFont = new Font("宋体", 18, FontStyle.Regular);
        /// <summary>
        /// 图片文字字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体,18pt,style=Regular")]
        [Description("图片文字字体")]
        public Font TextFont
        {
            get { return this.textFont; }
            set
            {
                if (this.textFont == value)
                    return;
                this.textFont = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 导航栏

        private NavigationBarShowTypes navigationBarShowType = NavigationBarShowTypes.Normal;
        /// <summary>
        ///导航栏按钮显示类型
        /// </summary>
        [DefaultValue(NavigationBarShowTypes.Normal)]
        [Description("导航栏按钮显示类型")]
        public NavigationBarShowTypes NavigationBarShowType
        {
            get { return this.navigationBarShowType; }
            set
            {
                if (this.navigationBarShowType == value)
                    return;

                this.navigationBarShowType = value;
                if (this.navigationBarShowType != NavigationBarShowTypes.Normal && this.TabStop)
                {
                    this.TabStop = false;
                }
                else
                {
                    if (this.TabStop != true)
                    {
                        this.TabStop = true;
                    }
                }

                this.navigationBar.IsShow = this.NavigationBarShowType == NavigationBarShowTypes.Normal ? true : false;

                this.InitializeNavigationBarRectangle();
                this.Invalidate();
            }
        }

        private int navigationBarBtnWidth = 30;
        /// <summary>
        /// 按钮宽度
        /// </summary>
        [DefaultValue(30)]
        [Description("按钮宽度")]
        public int NavigationBarBtnWidth
        {
            get { return this.navigationBarBtnWidth; }
            set
            {
                if (this.navigationBarBtnWidth == value || value < 0)
                    return;
                this.navigationBarBtnWidth = value;
                this.InitializeNavigationBarRectangle();
                this.Invalidate();
            }
        }

        private int navigationBarBtnHeight = 60;
        /// <summary>
        /// 按钮高度
        /// </summary>
        [DefaultValue(60)]
        [Description("按钮高度")]
        public int NavigationBarBtnHeight
        {
            get { return this.navigationBarBtnHeight; }
            set
            {
                if (this.navigationBarBtnHeight == value || value < 0)
                    return;
                this.navigationBarBtnHeight = value;
                this.InitializeNavigationBarRectangle();
                this.Invalidate();

            }
        }

        private int navigationBarBtnLineThickness = 2;
        /// <summary>
        /// 按钮线条厚度
        /// </summary>
        [DefaultValue(2)]
        [Description("按钮高度")]
        public int NavigationBarBtnLineThickness
        {
            get { return this.navigationBarBtnLineThickness; }
            set
            {
                if (this.navigationBarBtnLineThickness == value || value < 0)
                    return;
                this.navigationBarBtnLineThickness = value;
                this.InitializeNavigationBarRectangle();
                this.Invalidate();

            }
        }

        private Color navigationBarBtnNormalBackColor = Color.FromArgb(70, 128, 128, 128);
        /// <summary>
        ///导航栏按钮背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "70, 128, 128, 128")]
        [Description("导航栏按钮背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color NavigationBarBtnNormalBackColor
        {
            get { return this.navigationBarBtnNormalBackColor; }
            set
            {
                if (this.navigationBarBtnNormalBackColor == value)
                    return;
                this.navigationBarBtnNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color navigationBarBtnEnterBackColor = Color.FromArgb(70, 64, 64, 64);
        /// <summary>
        ///导航栏按钮背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "70, 64, 64, 64")]
        [Description("导航栏按钮背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color NavigationBarBtnEnterBackColor
        {
            get { return this.navigationBarBtnEnterBackColor; }
            set
            {
                if (this.navigationBarBtnEnterBackColor == value)
                    return;
                this.navigationBarBtnEnterBackColor = value;
                this.Invalidate();
            }
        }

        private Color navigationBarBtnNormalLineColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        ///导航栏按钮线条颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Description("导航栏按钮线条颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color NavigationBarBtnNormalLineColor
        {
            get { return this.navigationBarBtnNormalLineColor; }
            set
            {
                if (this.navigationBarBtnNormalLineColor == value)
                    return;
                this.navigationBarBtnNormalLineColor = value;
                this.Invalidate();
            }
        }

        private Color navigationBarBtnEnterLineColor = Color.FromArgb(100, 255, 255, 255);
        /// <summary>
        ///导航栏按钮线条颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "100, 255, 255, 255")]
        [Description("导航栏按钮线条颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color NavigationBarBtnEnterLineColor
        {
            get { return this.navigationBarBtnEnterLineColor; }
            set
            {
                if (this.navigationBarBtnEnterLineColor == value)
                    return;
                this.navigationBarBtnEnterLineColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 状态栏

        private bool statusBarShow = true;
        /// <summary>
        ///状态栏是否显示
        /// </summary>
        [DefaultValue(true)]
        [Description("状态栏是否显示")]
        public bool StatusBarShow
        {
            get { return this.statusBarShow; }
            set
            {
                if (this.statusBarShow == value)
                    return;
                this.statusBarShow = value;
                this.InitializeStatusBarRectangle();
                this.Invalidate();
            }
        }

        private StatusBarTypes statusBarType = StatusBarTypes.Circular;
        /// <summary>
        ///状态栏选项外观类型
        /// </summary>
        [DefaultValue(StatusBarTypes.Circular)]
        [Description("状态栏选项外观类型")]
        public StatusBarTypes StatusBarType
        {
            get { return this.statusBarType; }
            set
            {
                if (this.statusBarType == value)
                    return;
                this.statusBarType = value;
                this.InitializeStatusBarRectangle();
                this.Invalidate();
            }
        }

        private int statusBarDiameter = 12;
        /// <summary>
        ///状态栏选项直径
        /// </summary>
        [DefaultValue(12)]
        [Description("状态栏选项直径")]
        public int StatusBarDiameter
        {
            get { return this.statusBarDiameter; }
            set
            {
                if (this.statusBarDiameter == value || value < 0)
                    return;
                this.statusBarDiameter = value;
                this.InitializeStatusBarRectangle();
                this.Invalidate();
            }
        }

        private int statusBarPadding = 10;
        /// <summary>
        ///状态栏选项内边距
        /// </summary>
        [DefaultValue(10)]
        [Description("状态栏选项内边距")]
        public int StatusBarPadding
        {
            get { return this.statusBarPadding; }
            set
            {
                if (this.statusBarPadding == value || value < 0)
                    return;
                this.statusBarPadding = value;
                this.InitializeStatusBarRectangle();
                this.Invalidate();
            }
        }

        private Color statusBarNormalBackColor = Color.FromArgb(70, 128, 128, 128);
        /// <summary>
        ///状态栏选项颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "70, 128, 128, 128")]
        [Description("状态栏选项颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color StatusBarNormalBackColor
        {
            get { return this.statusBarNormalBackColor; }
            set
            {
                if (this.statusBarNormalBackColor == value)
                    return;
                this.statusBarNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color statusBarCurrentBackColor = Color.FromArgb(100, 255, 99, 71);
        /// <summary>
        ///状态栏选项颜色（当前）
        /// </summary>
        [DefaultValue(typeof(Color), "100, 255, 99, 71")]
        [Description("状态栏选项颜色（当前）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color StatusBarCurrentBackColor
        {
            get { return this.statusBarCurrentBackColor; }
            set
            {
                if (this.statusBarCurrentBackColor == value)
                    return;
                this.statusBarCurrentBackColor = value;
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
                return new Size(400, 200); ;
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
        /// 图片框滑动距离
        /// </summary>
        private int distance = 0;

        /// <summary>
        /// 图片框集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<ImageFrameItem> imageFrameList = new List<ImageFrameItem>();

        /// <summary>
        /// 已启用图片索引集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<int> enableImageList = new List<int>();

        /// <summary>
        /// 状态栏选项集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<RectangleF> statusBarList = new List<RectangleF>();

        /// <summary>
        /// 图片轮播的时间间隔累计(-1为动画正在切换中)
        /// </summary>
        private int intervalTimeValue = 0;

        /// <summary>
        /// 动画播放时间间隔定时器
        /// </summary>
        private Timer intervalTimer;

        /// <summary>
        /// 控件是否开始播放功能
        /// </summary>
        private bool allowPlay = false;

        /// <summary>
        /// 动画播放定时器
        /// </summary>
        private AnimationTimer animation;

        /// <summary>
        /// 当前滑动方向
        /// </summary>
        private Orientations current_orientation = Orientations.RightToLeft;

        /// <summary>
        /// 图片显示区
        /// </summary>
        private RectangleF display_rectf = RectangleF.Empty;

        /// <summary>
        /// 导航栏
        /// </summary>
        private NavigationBar navigationBar = new NavigationBar()
        {
            pre_btn = new NavigationBarItem() { type = NavigationBarBtnTypes.Pre },
            next_btn = new NavigationBarItem() { type = NavigationBarBtnTypes.Next }
        };

        #endregion

        public ImageCarouselExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.navigationBar.IsShow = this.NavigationBarShowType == NavigationBarShowTypes.Normal ? true : false;

            this.LoadImageFrame();
            this.InitializeSlideDirection();
            this.LoadEnableImageIndex();
            this.InitializeDisplayRectangle();

            if (!this.DesignMode)
            {
                this.intervalTimer = new Timer();
                this.intervalTimer.Interval = 50;
                this.intervalTimer.Tick += new EventHandler(this.intervalTimer_Tick);

                this.animation = new AnimationTimer(this, new AnimationOptions() { EveryNewTimer = false });
                this.animation.Animationing += new AnimationTimer.AnimationEventHandler(this.animationTimer_Animationing);
                this.animation.AnimationEnding += new AnimationTimer.AnimationEventHandler(this.animationTimer_AnimationEnding);
            }
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SetClip(this.display_rectf);

            if (this.enableImageList.Count < 1)//图片的数量不等于图片显示框的数量
            {
                goto border;
            }

            #region 图片框
            StringFormat text_sf = new StringFormat() { Alignment = StringAlignment.Center, };
            SolidBrush text_back_sb = null;
            SolidBrush text_fore_sb = null;
            if (this.TextShow)
            {
                text_back_sb = new SolidBrush(this.TextBackColor);
                text_fore_sb = new SolidBrush(this.TextForeColor);
            }
            for (int i = 0; i < this.imageFrameList.Count; i++)
            {
                #region 图片
                if (this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)].Image != null)
                {
                    g.DrawImage(this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)].Image, this.imageFrameList[i].current_rectf);
                }
                #endregion
                #region 文本
                if (this.TextShow)
                {
                    SizeF text_size = g.MeasureString(this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)].Text, this.TextFont, new SizeF(), text_sf);
                    RectangleF text_rectf = new RectangleF(this.imageFrameList[i].current_rectf.X, this.imageFrameList[i].current_rectf.Y, this.imageFrameList[i].current_rectf.Width, text_size.Height);
                    g.FillRectangle(text_back_sb, text_rectf);
                    g.DrawString(this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)].Text, this.TextFont, text_fore_sb, text_rectf, text_sf);
                }
                #endregion
            }
            if (text_fore_sb != null)
                text_fore_sb.Dispose();
            if (text_back_sb != null)
                text_back_sb.Dispose();
            if (text_sf != null)
                text_sf.Dispose();

            #endregion

            #region 状态栏
            if (this.StatusBarShow)
            {
                SolidBrush bar_normal_back_sb = new SolidBrush(this.StatusBarNormalBackColor);
                SolidBrush bar_current_back_sb = new SolidBrush(this.StatusBarCurrentBackColor);

                int current_index = this.IsNegative(this.Orientation) ? this.EnableImageCurrentIndex : Math.Abs(this.enableImageList.Count - 1 - this.EnableImageCurrentIndex);
                #region 圆形
                if (this.StatusBarType == StatusBarTypes.Circular)
                {
                    SmoothingMode sm = g.SmoothingMode;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    for (int i = 0; i < this.enableImageList.Count; i++)
                    {
                        g.FillEllipse(i == current_index ? bar_current_back_sb : bar_normal_back_sb, this.statusBarList[i]);
                    }
                    g.SmoothingMode = sm;
                }
                #endregion
                #region 四边形
                else if (this.StatusBarType == StatusBarTypes.Quadrangle)
                {
                    for (int i = 0; i < this.enableImageList.Count; i++)
                    {
                        g.FillRectangle(i == current_index ? bar_current_back_sb : bar_normal_back_sb, this.statusBarList[i]);
                    }
                }
                #endregion

                bar_normal_back_sb.Dispose();
                bar_current_back_sb.Dispose();
            }
            #endregion

            #region 导航栏

            SolidBrush normal_barbtn_back_sb = null;
            Pen normal_barbtn_fore_pen = null;
            SolidBrush enter_barbtn_back_sb = null;
            Pen enter_barbtn_fore_pen = null;
            Pen active_barbtn_line_pen = (this.activatedStateIndex > -1 && this.activatedStateIndex < this.navigationBar.GetBtnCount()) ? new Pen(this.ActivateColor, 1) { DashStyle = DashStyle.Dash } : null;

            #region
            if (this.NavigationBarShowType == NavigationBarShowTypes.Normal || (this.NavigationBarShowType == NavigationBarShowTypes.Enter && this.navigationBar.IsShow))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                #region 画笔
                normal_barbtn_back_sb = new SolidBrush(this.NavigationBarBtnNormalBackColor);
                normal_barbtn_fore_pen = new Pen(this.NavigationBarBtnNormalLineColor, this.NavigationBarBtnLineThickness) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                if (this.navigationBar.pre_btn.status == NavigationBarBtnStatus.Enter || this.navigationBar.next_btn.status == NavigationBarBtnStatus.Enter)
                {
                    enter_barbtn_back_sb = new SolidBrush(this.NavigationBarBtnEnterBackColor);
                    enter_barbtn_fore_pen = new Pen(this.NavigationBarBtnEnterLineColor, this.NavigationBarBtnLineThickness) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                }
                #endregion

                #region 向前按钮
                g.FillRectangle(this.navigationBar.pre_btn.status == NavigationBarBtnStatus.Enter ? enter_barbtn_back_sb : normal_barbtn_back_sb, this.navigationBar.pre_btn.btn_rectf);
                g.DrawLines(this.navigationBar.pre_btn.status == NavigationBarBtnStatus.Enter ? enter_barbtn_fore_pen : normal_barbtn_fore_pen, this.navigationBar.pre_btn.btn_line_rectf);
                if (this.activatedStateIndex == 0)
                {
                    g.DrawRectangle(active_barbtn_line_pen, this.navigationBar.pre_btn.btn_rectf.X, this.navigationBar.pre_btn.btn_rectf.Y, this.navigationBar.pre_btn.btn_rectf.Width, this.navigationBar.pre_btn.btn_rectf.Height);
                }
                #endregion
                #region 向后按钮
                g.FillRectangle(this.navigationBar.next_btn.status == NavigationBarBtnStatus.Enter ? enter_barbtn_back_sb : normal_barbtn_back_sb, this.navigationBar.next_btn.btn_rectf);
                g.DrawLines(this.navigationBar.next_btn.status == NavigationBarBtnStatus.Enter ? enter_barbtn_fore_pen : normal_barbtn_fore_pen, this.navigationBar.next_btn.btn_line_rectf);
                if (this.activatedStateIndex == 1)
                {
                    g.DrawRectangle(active_barbtn_line_pen, this.navigationBar.next_btn.btn_rectf.X, this.navigationBar.next_btn.btn_rectf.Y, this.navigationBar.next_btn.btn_rectf.Width, this.navigationBar.next_btn.btn_rectf.Height);
                }
                #endregion
            }
            #endregion

            if (normal_barbtn_back_sb != null)
                normal_barbtn_back_sb.Dispose();
            if (normal_barbtn_fore_pen != null)
                normal_barbtn_fore_pen.Dispose();
            if (enter_barbtn_back_sb != null)
                enter_barbtn_back_sb.Dispose();
            if (enter_barbtn_fore_pen != null)
                enter_barbtn_fore_pen.Dispose();
            if (active_barbtn_line_pen != null)
                active_barbtn_line_pen.Dispose();
            #endregion

            border:
            #region 边框
            if (this.BorderShow)
            {
                Pen border_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(border_pen, this.display_rectf.X, this.display_rectf.Y, this.display_rectf.Width - 1, this.display_rectf.Height - 1);

                if (border_pen != null)
                    border_pen.Dispose();
            }

            #endregion

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.activatedStateIndex = 0;
            this.Invalidate();
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
                base.ProcessDialogKey(keyData);
            }

            if (this.activatedState)
            {
                #region Left
                if (keyData == Keys.Left)
                {
                    if (this.NavigationBarShowType == NavigationBarShowTypes.Normal)
                    {
                        this.activatedStateIndex--;
                        if (this.activatedStateIndex < 0)
                        {
                            this.activatedStateIndex = this.navigationBar.GetBtnCount() - 1;
                        }
                        this.Invalidate();
                    }
                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    if (this.NavigationBarShowType == NavigationBarShowTypes.Normal)
                    {
                        this.activatedStateIndex++;
                        if (this.activatedStateIndex > this.navigationBar.GetBtnCount() - 1)
                        {
                            this.activatedStateIndex = 0;
                        }
                        this.Invalidate();
                    }
                    return false;
                }
                #endregion
                #region Enter、Space
                else if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    if (this.NavigationBarShowType == NavigationBarShowTypes.Normal && this.activatedStateIndex > -1 && this.activatedStateIndex < this.navigationBar.GetBtnCount())
                    {
                        this.OnImageCarouseBarBtnClick(new NavigationBarBtnClickEventArgs() { index = this.EnableImageCurrentIndex, Btn = this.navigationBar.GetBtn(this.activatedStateIndex) });
                    }
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnTabStopChanged(EventArgs e)
        {
            base.OnTabStopChanged(e);

            if (this.DesignMode)
                return;

            if (this.navigationBarShowType != NavigationBarShowTypes.Normal && this.TabStop)
            {
                this.TabStop = false;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.DesignMode)
                return;

            if (!this.Enabled)
            {
                this.Stop();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                #region 导航栏
                if (this.NavigationBarShowType != NavigationBarShowTypes.None)
                {
                    Point point = this.PointToClient(Control.MousePosition);
                    if (this.navigationBar.pre_btn.btn_rectf.Contains(point))
                    {
                        this.OnImageCarouseBarBtnClick(new NavigationBarBtnClickEventArgs() { index = this.EnableImageCurrentIndex, Btn = this.navigationBar.pre_btn });
                    }
                    else if (this.navigationBar.next_btn.btn_rectf.Contains(point))
                    {
                        this.OnImageCarouseBarBtnClick(new NavigationBarBtnClickEventArgs() { index = this.EnableImageCurrentIndex, Btn = this.navigationBar.next_btn });
                    }
                }
                #endregion
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            Point point = this.PointToClient(Control.MousePosition);

            bool isReset = false;

            #region 导航栏
            if (this.NavigationBarShowType == NavigationBarShowTypes.Enter)
            {
                bool tmp = this.display_rectf.Contains(point) ? true : false;
                if (this.navigationBar.IsShow != tmp)
                {
                    isReset = true;
                }
                this.navigationBar.IsShow = tmp;
            }
            #endregion

            #region 停止轮播
            if (this.EnterStop)
            {
                this.StopIntervalTimer();
            }
            #endregion

            if (isReset)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            Point point = this.PointToClient(Control.MousePosition);

            bool isReset = false;

            #region 导航栏
            if (this.NavigationBarShowType == NavigationBarShowTypes.Enter)
            {
                bool tmp = this.display_rectf.Contains(point) ? true : false;
                if (this.navigationBar.IsShow != tmp)
                {
                    isReset = true;
                }
                this.navigationBar.IsShow = tmp;
            }
            else if (this.NavigationBarShowType == NavigationBarShowTypes.Normal)
            {
                if (this.navigationBar.pre_btn.status != NavigationBarBtnStatus.Normal || this.navigationBar.next_btn.status != NavigationBarBtnStatus.Normal)
                {
                    this.navigationBar.pre_btn.status = NavigationBarBtnStatus.Normal;
                    this.navigationBar.next_btn.status = NavigationBarBtnStatus.Normal;
                    isReset = true;
                }
            }
            #endregion

            #region 停止轮播定时器
            if (this.allowPlay && this.EnterStop)
            {
                this.StartIntervalTimer();
            }
            #endregion

            if (isReset)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            Point point = this.PointToClient(Control.MousePosition);

            bool isReset = false;
            bool tmp = this.display_rectf.Contains(point) ? true : false;

            #region 导航栏
            #region Enter
            if (this.NavigationBarShowType == NavigationBarShowTypes.Enter)
            {
                if (this.navigationBar.IsShow != tmp)
                {
                    this.navigationBar.IsShow = tmp;
                    isReset = true;
                }

                if (this.navigationBar.IsShow)
                {
                    NavigationBarBtnStatus pre_status = this.navigationBar.pre_btn.btn_rectf.Contains(e.Location) ? NavigationBarBtnStatus.Enter : NavigationBarBtnStatus.Normal;
                    if (this.navigationBar.pre_btn.status != pre_status)
                    {
                        this.navigationBar.pre_btn.status = pre_status;
                        this.Cursor = Cursors.Hand;
                        isReset = true;
                    }
                    NavigationBarBtnStatus next_status = this.navigationBar.next_btn.btn_rectf.Contains(e.Location) ? NavigationBarBtnStatus.Enter : NavigationBarBtnStatus.Normal;
                    if (this.navigationBar.next_btn.status != next_status)
                    {
                        this.navigationBar.next_btn.status = next_status;
                        this.Cursor = Cursors.Hand;
                        isReset = true;
                    }

                    if (this.navigationBar.pre_btn.status != NavigationBarBtnStatus.Enter && this.navigationBar.next_btn.status != NavigationBarBtnStatus.Enter && this.Cursor != Cursors.Default)
                    {
                        this.Cursor = Cursors.Default;
                        isReset = true;
                    }
                }

            }
            #endregion
            #region Normal
            else if (this.NavigationBarShowType == NavigationBarShowTypes.Normal)
            {
                NavigationBarBtnStatus pre_status = this.navigationBar.pre_btn.btn_rectf.Contains(e.Location) ? NavigationBarBtnStatus.Enter : NavigationBarBtnStatus.Normal;
                if (this.navigationBar.pre_btn.status != pre_status)
                {
                    this.navigationBar.pre_btn.status = pre_status;
                    this.Cursor = Cursors.Hand;
                    isReset = true;
                }
                NavigationBarBtnStatus next_status = this.navigationBar.next_btn.btn_rectf.Contains(e.Location) ? NavigationBarBtnStatus.Enter : NavigationBarBtnStatus.Normal;
                if (this.navigationBar.next_btn.status != next_status)
                {
                    this.navigationBar.next_btn.status = next_status;
                    this.Cursor = Cursors.Hand;
                    isReset = true;
                }

                if (this.navigationBar.pre_btn.status != NavigationBarBtnStatus.Enter && this.navigationBar.next_btn.status != NavigationBarBtnStatus.Enter && this.Cursor != Cursors.Default)
                {
                    this.Cursor = Cursors.Default;
                    isReset = true;
                }
            }
            #endregion
            #endregion

            if (isReset)
            {
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeDisplayRectangle();
            this.InitializeImageFrameRectangleIndex();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.intervalTimer != null)
                    this.intervalTimer.Dispose();
                if (this.animation != null)
                    this.animation.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnFrameIndexChanged(ImageFrameIndexChangedEventArgs e)
        {
            if (this.imageFrameIndexChanged != null)
            {
                this.imageFrameIndexChanged(this, e);
            }
        }

        protected virtual void OnImageCarouseBarBtnClick(NavigationBarBtnClickEventArgs e)
        {
            if (this.intervalTimeValue == -1)//动画进行中
                return;
            this.intervalTimeValue = -1;

            #region 获取当前滑动方向
            if (e.Btn.type == NavigationBarBtnTypes.Pre)
            {
                if (this.Orientation == Orientations.LeftToRight)
                {
                    this.current_orientation = Orientations.RightToLeft;
                }
                else if (this.Orientation == Orientations.TopToBottom)
                {
                    this.current_orientation = Orientations.BottomToTop;
                }
            }
            else
            {
                if (this.Orientation == Orientations.RightToLeft)
                {
                    this.current_orientation = Orientations.LeftToRight;
                }
                else if (this.Orientation == Orientations.BottomToTop)
                {
                    this.current_orientation = Orientations.TopToBottom;
                }
            }
            #endregion

            if (this.navigationBarBtnClick != null)
            {
                this.navigationBarBtnClick(this, e);
            }

            this.InitializeSlideDirection();
            this.InitializeImageFrameRectangleIndex();
            this.AutoUpdateImageEnableCurrentIndex(this.current_orientation);

            this.animation.Options.Data = this.current_orientation;
            this.animation.AnimationType = AnimationTypes.EaseOut;
            this.animation.Options.AllTransformValue = this.distance;
            this.animation.Options.AllTransformTime = this.AnimationTime;
            this.animation.Start(AnimationIntervalTypes.Add, 0);

        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 开始轮播图片
        /// </summary>
        public void Play()
        {
            if (!this.Enabled)
                return;

            if (!this.allowPlay)
            {
                this.allowPlay = true;
                this.intervalTimer.Enabled = true;
            }
        }

        /// <summary>
        /// 指定索引开始轮播图片
        /// </summary>
        /// <param name="index">已启用图片列表索引值</param>
        public void Play(int index)
        {
            if (!this.Enabled)
                return;

            if (!this.allowPlay)
            {
                this.allowPlay = true;
                this.intervalTimer.Enabled = true;
                this.EnableImageCurrentIndex = index;
            }
        }

        /// <summary>
        /// 停止轮播图片
        /// </summary>
        public void Stop()
        {
            this.allowPlay = false;
            this.intervalTimer.Enabled = false;
        }

        /// <summary>
        /// 获取图片显示区
        /// </summary>
        /// <returns></returns>
        public RectangleF GetDisplayRectangle()
        {
            return this.display_rectf;
        }

        /// <summary>
        /// 获取启用的图片列表中图片真实索引值
        /// </summary>
        /// <param name="index">在启用的图片列表中的索引</param>
        /// <returns></returns>
        public int GetEnableImageRealityIndex(int index)
        {
            if (index < 0 || index >= this.enableImageList.Count)
                return -1;
            return this.enableImageList[index];
        }

        /// <summary>
        /// 获取所有已启用的图片列表索引
        /// </summary>
        public List<int> GetEnableImagesIndex()
        {
            List<int> resultList = new List<int>();
            this.enableImageList.ForEach(a => resultList.Add(a));
            return resultList;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 图片轮播的时间间隔事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalTimer_Tick(object sender, EventArgs e)
        {
            if (this.intervalTimeValue == -1)//动画进行中
                return;

            this.intervalTimeValue += this.intervalTimer.Interval;
            if (this.intervalTimeValue >= this.IntervalTime)
            {
                this.intervalTimeValue = -1;

                this.RestoreOrientation();
                this.InitializeImageFrameRectangleIndex();
                this.AutoUpdateImageEnableCurrentIndex(this.current_orientation);

                this.animation.Options.Data = this.current_orientation;
                this.animation.AnimationType = AnimationTypes.EaseOut;
                this.animation.Options.AllTransformValue = this.distance;
                this.animation.Options.AllTransformTime = this.AnimationTime;
                this.animation.Start(AnimationIntervalTypes.Add, 0);
            }
        }

        /// <summary>
        /// 动画进行中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void animationTimer_Animationing(object sender, AnimationEventArgs e)
        {
            Orientations _orientation = (Orientations)e.Data;
            float dis = (float)(e.AllTransformValue * e.ProgressValue);//计算动画值
            for (int i = 0; i < this.imageFrameList.Count; i++)
            {
                RectangleF current_rectf = new RectangleF(this.imageFrameList[i].before_point + dis, this.imageFrameList[i].current_rectf.Y, this.imageFrameList[i].current_rectf.Width, this.imageFrameList[i].current_rectf.Height);
                if (this.IsVertical(_orientation))
                {
                    current_rectf = new RectangleF(this.imageFrameList[i].current_rectf.X, this.imageFrameList[i].before_point + dis, this.imageFrameList[i].current_rectf.Width, this.imageFrameList[i].current_rectf.Height);
                }
                this.imageFrameList[i].current_rectf = current_rectf;
            }

            if (this.Enabled && this.Visible)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 动画结束时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void animationTimer_AnimationEnding(object sender, AnimationEventArgs e)
        {
            this.RestoreOrientation();

            this.intervalTimeValue = 0;
        }

        /// <summary>
        /// 加载已启用图片索引集合
        /// </summary>
        internal void LoadEnableImageIndex()
        {
            List<int> old_enableImageList = this.enableImageList;
            List<int> new_enableImageList = new List<int>();
            List<RectangleF> old_statusBarList = this.statusBarList;
            List<RectangleF> new_statusBarList = new List<RectangleF>();
            for (int i = 0; i < this.Images.Count; i++)
            {
                if (this.Images[i].Enable)
                {
                    new_enableImageList.Add(i);
                    new_statusBarList.Add(RectangleF.Empty);
                }
            }
            this.enableImageList = new_enableImageList;
            old_enableImageList.Clear();
            this.statusBarList = new_statusBarList;
            old_statusBarList.Clear();
        }

        /// <summary>
        /// 加载图片框集合(图片框要比现实的数量多一个)
        /// </summary>
        private void LoadImageFrame()
        {
            List<ImageFrameItem> old_imageFrameList = this.imageFrameList;
            List<ImageFrameItem> new_imageFrameList = new List<ImageFrameItem>();
            this.imageFrameList = new List<ImageFrameItem>();
            for (int i = 0; i < this.ImageFrameCount + 1; i++)
            {
                new_imageFrameList.Add(new ImageFrameItem());
            }
            this.imageFrameList = new_imageFrameList;
            old_imageFrameList.Clear();
        }

        /// <summary>
        /// 初始化播放显示区Rectangle
        /// </summary>
        /// <returns></returns>
        public void InitializeDisplayRectangle()
        {
            RectangleF rectf = RectangleF.Empty;
            if (this.IsHorizonta(this.Orientation))
            {
                float width = this.ImageFrameWidth * this.ImageFrameCount;
                float x = this.ClientRectangle.X;
                float y = this.ClientRectangle.Y;

                if (this.ClientRectangle.Width != width)
                {
                    x = (this.ClientRectangle.Width - width) / 2f;
                }

                if (this.ClientRectangle.Height != this.ImageFrameHeight)
                {
                    y = (this.ClientRectangle.Height - this.ImageFrameHeight) / 2f;
                }
                rectf = new RectangleF(x, y, width, this.ImageFrameHeight);
            }
            else
            {
                float height = this.ImageFrameHeight * this.ImageFrameCount;
                float x = this.ClientRectangle.X;
                float y = this.ClientRectangle.Y;

                if (this.ClientRectangle.Height != height)
                {
                    y = (this.ClientRectangle.Height - height) / 2f;
                }

                if (this.ClientRectangle.Width != this.ImageFrameWidth)
                {
                    x = (this.ClientRectangle.Width - this.ImageFrameWidth) / 2f;
                }
                rectf = new RectangleF(x, y, this.ImageFrameWidth, height);
            }
            this.display_rectf = rectf;

            this.InitializeNavigationBarRectangle();
            this.InitializeStatusBarRectangle();
        }

        /// <summary>
        /// 初始化导航栏Rectangle
        /// </summary>
        private void InitializeNavigationBarRectangle()
        {
            if (this.NavigationBarShowType != NavigationBarShowTypes.None)
            {
                #region
                if (this.IsHorizonta(this.Orientation))
                {
                    float padding = this.NavigationBarBtnWidth / 5f;
                    this.navigationBar.pre_btn.btn_rectf = new RectangleF(this.display_rectf.X + padding, this.display_rectf.Y + (this.display_rectf.Height - this.NavigationBarBtnHeight) / 2f, this.NavigationBarBtnWidth, this.NavigationBarBtnHeight);
                    this.navigationBar.next_btn.btn_rectf = new RectangleF(this.display_rectf.Right - this.NavigationBarBtnWidth - padding, this.display_rectf.Y + (this.display_rectf.Height - this.NavigationBarBtnHeight) / 2f, this.NavigationBarBtnWidth, this.NavigationBarBtnHeight);

                    float barbtn_avg_w = this.navigationBar.pre_btn.btn_rectf.Width / 4f;
                    float barbtn_avg_h = this.navigationBar.pre_btn.btn_rectf.Height / 6f;
                    #region
                    PointF[] pre_line_points = new PointF[3];
                    pre_line_points[0] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w * 3), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h));
                    pre_line_points[1] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h * 3));
                    pre_line_points[2] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w * 3), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h * 5));
                    this.navigationBar.pre_btn.btn_line_rectf = pre_line_points;
                    #endregion
                    #region
                    PointF[] next_line_points = new PointF[3];
                    next_line_points[0] = new PointF((this.navigationBar.next_btn.btn_rectf.Right - barbtn_avg_w * 3), (this.navigationBar.next_btn.btn_rectf.Y + barbtn_avg_h));
                    next_line_points[1] = new PointF((this.navigationBar.next_btn.btn_rectf.Right - barbtn_avg_w), (this.navigationBar.next_btn.btn_rectf.Y + barbtn_avg_h * 3));
                    next_line_points[2] = new PointF((this.navigationBar.next_btn.btn_rectf.Right - barbtn_avg_w * 3), (this.navigationBar.next_btn.btn_rectf.Y + barbtn_avg_h * 5));
                    this.navigationBar.next_btn.btn_line_rectf = next_line_points;
                    #endregion
                }
                #endregion
                #region
                else if (this.IsVertical(this.Orientation))
                {
                    float padding = this.NavigationBarBtnWidth / 5f;
                    this.navigationBar.pre_btn.btn_rectf = new RectangleF(this.display_rectf.X + (this.display_rectf.Width - this.NavigationBarBtnHeight) / 2f, this.display_rectf.Y + padding, this.NavigationBarBtnHeight, this.NavigationBarBtnWidth);
                    this.navigationBar.next_btn.btn_rectf = new RectangleF(this.display_rectf.X + (this.display_rectf.Width - this.NavigationBarBtnHeight) / 2f, this.display_rectf.Bottom - this.NavigationBarBtnWidth - padding, this.NavigationBarBtnHeight, this.NavigationBarBtnWidth);

                    float barbtn_avg_w = this.navigationBar.pre_btn.btn_rectf.Width / 6f;
                    float barbtn_avg_h = this.navigationBar.pre_btn.btn_rectf.Height / 4f;
                    #region
                    PointF[] pre_line_points = new PointF[3];
                    pre_line_points[0] = new PointF((this.navigationBar.next_btn.btn_rectf.X + barbtn_avg_w), (this.navigationBar.next_btn.btn_rectf.Bottom - barbtn_avg_h * 3));
                    pre_line_points[1] = new PointF((this.navigationBar.next_btn.btn_rectf.X + barbtn_avg_w * 3), (this.navigationBar.next_btn.btn_rectf.Bottom - barbtn_avg_h));
                    pre_line_points[2] = new PointF((this.navigationBar.next_btn.btn_rectf.X + barbtn_avg_w * 5), (this.navigationBar.next_btn.btn_rectf.Bottom - barbtn_avg_h * 3));
                    this.navigationBar.pre_btn.btn_line_rectf = pre_line_points;
                    #endregion

                    #region
                    PointF[] next_line_points = new PointF[3];
                    next_line_points[0] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h * 3));
                    next_line_points[1] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w * 3), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h));
                    next_line_points[2] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w * 5), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h * 3));
                    this.navigationBar.next_btn.btn_line_rectf = next_line_points;
                    #endregion

                }
                #endregion
            }
        }

        /// <summary>
        /// 初始化状态栏Rectangle
        /// </summary>
        /// <returns></returns>
        private void InitializeStatusBarRectangle()
        {
            if (this.StatusBarShow)
            {
                for (int i = 0; i < this.statusBarList.Count; i++)
                {
                    RectangleF statusbar_item_rectf = RectangleF.Empty;
                    float interval = this.StatusBarDiameter / 2f;
                    float statusbar_width = (this.StatusBarDiameter + interval) * this.enableImageList.Count - interval;
                    float statusbar_item_start_x = (this.display_rectf.Width - statusbar_width) / 2f;
                    float statusbar_item_start_y = this.display_rectf.Y + (this.display_rectf.Height - statusbar_width) / 2f;

                    if (this.IsVertical(this.current_orientation))
                    {
                        statusbar_item_rectf = new RectangleF(this.display_rectf.Right - this.StatusBarDiameter - this.statusBarPadding, this.display_rectf.Y + statusbar_item_start_y + i * this.StatusBarDiameter + (i - 1) * interval, this.StatusBarDiameter, this.StatusBarDiameter);
                    }
                    else
                    {
                        statusbar_item_rectf = new RectangleF(this.display_rectf.X + statusbar_item_start_x + i * this.StatusBarDiameter + (i - 1) * interval, this.display_rectf.Bottom - this.StatusBarDiameter - this.statusBarPadding, this.StatusBarDiameter, this.StatusBarDiameter);
                    }
                    this.statusBarList[i] = statusbar_item_rectf;
                }
            }
        }

        /// <summary>
        /// 初始化图片框滑动距离
        /// </summary>
        private void InitializeSlideDirection()
        {
            switch (this.current_orientation)
            {
                case Orientations.BottomToTop:
                    {
                        this.distance = -this.ImageFrameHeight;
                        break;
                    }
                case Orientations.TopToBottom:
                    {
                        this.distance = this.ImageFrameHeight;
                        break;
                    }
                case Orientations.RightToLeft:
                    {
                        this.distance = -this.ImageFrameWidth;
                        break;
                    }
                case Orientations.LeftToRight:
                    {
                        this.distance = this.ImageFrameWidth;
                        break;
                    }
            }

        }

        /// <summary>
        /// 初始化播放前每一个图片框的Rectangle和图片索引
        /// </summary>
        private void InitializeImageFrameRectangleIndex()
        {
            // 当前显示区的开始图片的索引（负向第一个为最左边、正向第一个为最右边）

            if (this.enableImageList.Count < 1)
                return;

            #region 负方向
            if (this.IsNegative(this.current_orientation))
            {
                #region 负方向的同向
                if (!this.IsReverse(this.Orientation, this.current_orientation))
                {
                    #region 图片框
                    for (int i = 0; i < this.imageFrameList.Count; i++)
                    {
                        if (this.current_orientation == Orientations.RightToLeft)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.X + (i * -this.distance);
                            this.imageFrameList[i].current_rectf = new RectangleF(this.imageFrameList[i].before_point, this.display_rectf.Y, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                        else if (this.current_orientation == Orientations.BottomToTop)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.Y + (i * -this.distance);
                            this.imageFrameList[i].current_rectf = new RectangleF(this.display_rectf.X, this.imageFrameList[i].before_point, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                    }
                    #endregion

                    #region 图片索引
                    for (int i = 0; i < this.imageFrameList.Count; i++)
                    {
                        this.imageFrameList[i].image_index = this.ValidImageEnableIndex(this.EnableImageCurrentIndex + i);//增加指定偏移量
                    }
                    #endregion
                }
                #endregion
                #region 正方向的反向
                else
                {
                    for (int i = this.imageFrameList.Count - 1; i >= 0; i--)
                    {
                        #region 图片框
                        if (this.current_orientation == Orientations.RightToLeft)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.X + (i * -this.distance);
                            this.imageFrameList[i].current_rectf = new RectangleF(this.imageFrameList[i].before_point, this.display_rectf.Y, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                        else if (this.current_orientation == Orientations.BottomToTop)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.Y + (i * -this.distance);
                            this.imageFrameList[i].current_rectf = new RectangleF(this.display_rectf.X, this.imageFrameList[i].before_point, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                        #endregion

                        #region 图片索引
                        int index_tmp = this.EnableImageCurrentIndex - 1;//更正图片开始索引值(值应该为右边第一个图片框索引值)
                        this.imageFrameList[i].image_index = this.ValidImageEnableIndex(index_tmp + (this.imageFrameList.Count - 1 - i));//增加指定偏移量
                        #endregion
                    }
                }
                #endregion
            }
            #endregion
            #region 正方向
            else
            {
                #region 正方向的同向
                if (!this.IsReverse(this.Orientation, this.current_orientation))
                {
                    #region 图片框
                    for (int i = this.imageFrameList.Count - 1; i >= 0; i--)
                    {
                        if (this.current_orientation == Orientations.LeftToRight)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.X + (i - 1) * this.distance;
                            this.imageFrameList[i].current_rectf = new RectangleF(this.imageFrameList[i].before_point, this.display_rectf.Y, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                        else if (this.current_orientation == Orientations.TopToBottom)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.Y + (i - 1) * this.distance;
                            this.imageFrameList[i].current_rectf = new RectangleF(this.display_rectf.X, this.imageFrameList[i].before_point, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                    }
                    #endregion

                    #region 图片索引
                    for (int i = this.imageFrameList.Count - 1; i >= 0; i--)
                    {
                        this.imageFrameList[i].image_index = this.ValidImageEnableIndex(this.EnableImageCurrentIndex + (this.imageFrameList.Count - 1 - i));//增加指定偏移量
                    }
                    #endregion
                }
                #endregion
                #region 负方向的反向
                else
                {
                    for (int i = this.imageFrameList.Count - 1; i >= 0; i--)
                    {
                        #region 图片框
                        if (this.current_orientation == Orientations.LeftToRight)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.X + (i - 1) * this.distance;
                            this.imageFrameList[i].current_rectf = new RectangleF(this.imageFrameList[i].before_point, this.display_rectf.Y, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                        else if (this.current_orientation == Orientations.TopToBottom)
                        {
                            this.imageFrameList[i].before_point = this.display_rectf.Y + (i - 1) * this.distance;
                            this.imageFrameList[i].current_rectf = new RectangleF(this.display_rectf.X, this.imageFrameList[i].before_point, this.ImageFrameWidth, this.ImageFrameHeight);
                        }
                        #endregion

                        #region 图片索引
                        int index_tmp = this.EnableImageCurrentIndex - 1;//更正图片开始索引值(值应该为左边第一个图片框索引值)
                        this.imageFrameList[i].image_index = this.ValidImageEnableIndex(index_tmp + i);//增加指定偏移量
                        #endregion
                    }
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 自动更新已启用图片列表的当前显示区的开始图片的索引(用于定时器和按钮切换时索引加减1)
        /// </summary>
        /// <param name="_orientation">播放方向</param>
        private void AutoUpdateImageEnableCurrentIndex(Orientations _orientation)
        {
            #region 索引同向
            if (!this.IsReverse(this.Orientation, _orientation))//同向滑动后当前图片索引加1
            {
                int display_index_tmp = this.ValidImageEnableIndex(this.EnableImageCurrentIndex + 1);
                this.enableImageCurrentIndex = display_index_tmp;

                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new ImageFrameIndexChangedEventArgs() { index = display_index_tmp, Item = this.Images[display_index_tmp] });
                }
            }
            #endregion
            #region 索引反向
            else//反向滑动后当前图片索引减1
            {
                int display_index_tmp = this.ValidImageEnableIndex(this.EnableImageCurrentIndex - 1);
                this.enableImageCurrentIndex = display_index_tmp;

                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new ImageFrameIndexChangedEventArgs() { index = display_index_tmp, Item = this.Images[display_index_tmp] });
                }
            }
            #endregion
        }

        /// <summary>
        /// 获取验证后图片在已启用图片列表的索引
        /// </summary>
        /// <param name="index">已启用图片列表的索引</param>
        /// <returns></returns>
        private int ValidImageEnableIndex(int index)
        {
            while (index >= this.enableImageList.Count)
                index -= this.enableImageList.Count;
            while (index < 0)
                index += this.enableImageList.Count;
            return index;
        }

        /// <summary>
        /// 还原默认方向
        /// </summary>
        private void RestoreOrientation()
        {
            if (this.Orientation != this.current_orientation)
            {
                this.current_orientation = this.Orientation;
                this.InitializeSlideDirection();
            }
        }

        /// <summary>
        /// 是否横向
        /// </summary>
        /// <param name="_orientation"></param>
        /// <returns></returns>
        private bool IsHorizonta(Orientations _orientation)
        {
            return (_orientation == Orientations.LeftToRight || _orientation == Orientations.RightToLeft);
        }

        /// <summary>
        /// 是否纵向
        /// </summary>
        /// <param name="_orientation"></param>
        /// <returns></returns>
        private bool IsVertical(Orientations _orientation)
        {
            return (_orientation == Orientations.TopToBottom || _orientation == Orientations.BottomToTop);
        }

        /// <summary>
        /// 是否负方向滑动（RightToLeft、BottomToTop）
        /// </summary>
        /// <param name="_orientation"></param>
        /// <returns></returns>
        private bool IsNegative(Orientations _orientation)
        {
            return (_orientation == Orientations.RightToLeft || _orientation == Orientations.BottomToTop);
        }

        /// <summary>
        /// 是否正方向滑动（LeftToRight、TopToBottom）
        /// </summary>
        /// <param name="_orientation"></param>
        /// <returns></returns>
        private bool IsPositive(Orientations _orientation)
        {
            return (_orientation == Orientations.LeftToRight || _orientation == Orientations.TopToBottom);
        }

        /// <summary>
        /// 是否和设置运动方向相反
        /// </summary>
        /// <param name="old_orientation"></param>
        /// <param name="new_orientation"></param>
        /// <returns></returns>
        private bool IsReverse(Orientations old_orientation, Orientations new_orientation)
        {
            bool _old = this.IsNegative(old_orientation);
            bool _new = this.IsNegative(new_orientation);

            if (_old != _new)
                return true;
            return
                false;
        }

        /// <summary>
        /// 开始动画间隔定时器
        /// </summary>
        private void StartIntervalTimer()
        {
            if (!this.allowPlay)
            {
                this.allowPlay = true;
                this.intervalTimer.Enabled = true;
                this.intervalTimeValue = 0;
            }
        }

        /// <summary>
        /// 停止动画间隔定时器
        /// </summary>
        private void StopIntervalTimer()
        {
            if (this.allowPlay)
            {
                this.allowPlay = false;
                this.intervalTimer.Enabled = false;
                this.intervalTimeValue = 0;
            }
        }

        #endregion

        #region 类

        /// <summary>
        ///图片选项集合
        /// </summary>
        [Description("图片选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ImageItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList imageItemList = new ArrayList();
            private ImageCarouselExt owner;

            public ImageItemCollection(ImageCarouselExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ImageItem[] listArray = new ImageItem[this.imageItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ImageItem)this.imageItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.imageItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.imageItemList.Count;
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
                if (!(value is ImageItem))
                {
                    throw new ArgumentException("ImageItem");
                }
                return this.Add((ImageItem)value);
            }

            public int Add(ImageItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                this.imageItemList.Add(item);
                item.owner = owner;
                if (item.Enable)
                {
                    this.owner.LoadEnableImageIndex();
                }
                this.owner.InitializeImageFrameRectangleIndex();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.imageItemList.Clear();
                this.owner.LoadEnableImageIndex();
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
                if (item is ImageItem)
                {
                    return this.Contains((ImageItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ImageItem)
                {
                    return this.imageItemList.IndexOf(item);
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
                if (!(value is ImageItem))
                {
                    throw new ArgumentException("ImageItem");
                }
                this.Remove((ImageItem)value);
            }

            public void Remove(ImageItem item)
            {
                this.imageItemList.Remove(item);
                this.owner.LoadEnableImageIndex();
                this.owner.InitializeImageFrameRectangleIndex();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.imageItemList.RemoveAt(index);
                this.owner.LoadEnableImageIndex();
                this.owner.InitializeImageFrameRectangleIndex();
                this.owner.Invalidate();
            }

            public ImageItem this[int index]
            {
                get
                {
                    return (ImageItem)this.imageItemList[index];
                }
                set
                {
                    this.imageItemList[index] = (ImageItem)value;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.imageItemList[index];
                }
                set
                {
                    this.imageItemList[index] = (ImageItem)value;
                }
            }

            #endregion
        }

        /// <summary>
        /// 图片选项
        /// </summary>
        [Description("图片选项")]
        public class ImageItem
        {
            internal ImageCarouselExt owner;

            private Image image = null;
            /// <summary>
            /// 图片
            /// </summary>
            [DefaultValue(null)]
            [Description("图片")]
            public Image Image
            {
                get { return this.image; }
                set
                {
                    if (this.image == value)
                        return;
                    this.image = value;
                }
            }

            private string text = null;
            /// <summary>
            /// 图片文本
            /// </summary>
            [Description("图片文本")]
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

            private bool enable = true;
            /// <summary>
            /// 是否启用
            /// </summary>
            [DefaultValue(true)]
            [Description("是否启用")]
            public bool Enable
            {
                get { return this.enable; }
                set
                {
                    if (this.enable == value)
                        return;
                    this.enable = value;
                    if (this.owner != null)
                    {
                        this.owner.LoadEnableImageIndex();
                    }
                }
            }
        }

        /// <summary>
        /// 图片轮播选项
        /// </summary>
        [Description("图片轮播选项")]
        public class ImageFrameItem
        {
            /// <summary>
            /// 运动前坐标
            /// </summary>
            [Browsable(false)]
            [Description("运动前坐标")]
            public float before_point { get; set; }

            /// <summary>
            /// 当前rectf
            /// </summary>
            [Browsable(false)]
            [Description("当前rectf")]
            public RectangleF current_rectf { get; set; }

            /// <summary>
            /// 已启用显示属性的图片列表的索引值
            /// </summary>
            [Browsable(false)]
            [Description("已启用显示属性的图片列表的索引值")]
            public int image_index { get; set; }

        }

        /// <summary>
        /// 导航栏
        /// </summary>
        [Description("导航栏")]
        public class NavigationBar
        {
            /// <summary>
            /// 向前按钮
            /// </summary>
            [Browsable(false)]
            [Description("向前按钮")]
            public NavigationBarItem pre_btn { get; set; }

            /// <summary>
            /// 向后按钮
            /// </summary>
            [Browsable(false)]
            [Description("向后按钮")]
            public NavigationBarItem next_btn { get; set; }

            /// <summary>
            /// 导航栏显示状态
            /// </summary>
            [Browsable(false)]
            [Description("导航栏显示状态")]
            public bool IsShow { get; set; }

            /// <summary>
            /// 获取导航栏按钮数量
            /// </summary>
            /// <returns></returns>
            public int GetBtnCount()
            {
                return 2;
            }

            /// <summary>
            /// 根据索引获取按钮对象
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public NavigationBarItem GetBtn(int index)
            {
                if (index == 1)
                    return pre_btn;
                else return next_btn;
            }
        }

        /// <summary>
        /// 导航栏选项
        /// </summary>
        [Description("导航栏选项")]
        public class NavigationBarItem
        {
            /// <summary>
            /// 按钮rectf
            /// </summary>
            [Browsable(false)]
            [Description("按钮rectf")]
            public RectangleF btn_rectf { get; set; }

            /// <summary>
            /// 按钮线条rectf
            /// </summary>
            [Browsable(false)]
            [Description("按钮线条rectf")]
            public PointF[] btn_line_rectf { get; set; }

            /// <summary>
            /// 按钮状态
            /// </summary>
            [Browsable(false)]
            [DefaultValue(NavigationBarBtnStatus.Normal)]
            [Description("按钮状态")]
            public NavigationBarBtnStatus status { get; set; }

            /// <summary>
            /// 导航栏按钮类型
            /// </summary>
            [Browsable(false)]
            [Description("导航栏按钮类型")]
            public NavigationBarBtnTypes type { get; set; }

        }

        /// <summary>
        /// 图片轮播选项索引更改事件参数
        /// </summary>
        [Description("图片轮播选项索引更改事件参数")]
        public class ImageFrameIndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 图片选项在已启动图片列表的索引
            /// </summary>
            [Description("图片选项在已启动图片列表的索引")]
            public int index { get; set; }
            /// <summary>
            /// 图片选项
            /// </summary>
            [Description("图片选项")]
            public ImageItem Item { get; set; }
        }

        /// <summary>
        /// 导航栏按钮单击事件参数
        /// </summary>
        [Description("导航栏按钮单击事件参数")]
        public class NavigationBarBtnClickEventArgs : EventArgs
        {
            /// <summary>
            /// 图片选项在已启动图片列表的索引
            /// </summary>
            [Description("图片选项在已启动图片列表的索引")]
            public int index { get; set; }

            /// <summary>
            /// 导航栏按钮
            /// </summary>
            [Description("导航栏按钮")]
            public NavigationBarItem Btn { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 图片轮播方向
        /// </summary>
        [Description("图片轮播方向")]
        public enum Orientations
        {
            /// <summary>
            /// 由右往左
            /// </summary>
            RightToLeft,
            /// <summary>
            /// 由左往右
            /// </summary>
            LeftToRight,
            /// <summary>
            /// 由下往上
            /// </summary>
            BottomToTop,
            /// <summary>
            /// 由上往下
            /// </summary>
            TopToBottom
        }

        /// <summary>
        /// 状态栏选项外观类型
        /// </summary>
        [Description("状态栏选项外观类型")]
        public enum StatusBarTypes
        {
            /// <summary>
            /// 四边形
            /// </summary>
            Quadrangle,
            /// <summary>
            /// 圆形
            /// </summary>
            Circular
        }

        /// <summary>
        /// 导航栏按钮显示类型
        /// </summary>
        [Description("导航栏按钮状态")]
        public enum NavigationBarShowTypes
        {
            /// <summary>
            /// 不显示
            /// </summary>
            None,
            /// <summary>
            /// 一直显示
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入才显示
            /// </summary>
            Enter
        }

        /// <summary>
        /// 导航栏按钮状态
        /// </summary>
        [Description("导航栏按钮状态")]
        public enum NavigationBarBtnStatus
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
        /// 导航栏按钮类型
        /// </summary>
        [Description("导航栏按钮类型")]
        public enum NavigationBarBtnTypes
        {
            /// <summary>
            /// 向前按钮
            /// </summary>
            Pre,
            /// <summary>
            /// 向后按钮
            /// </summary>
            Next
        }

        #endregion

    }

}
