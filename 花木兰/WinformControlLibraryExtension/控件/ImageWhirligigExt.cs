
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
    /// 图片旋转播放控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("图片旋转播放控件")]
    [DefaultProperty("Images")]
    [DefaultEvent("NavigationBarBtnClick")]
    [Designer(typeof(ImageWhirligigExtDesigner))]
    public class ImageWhirligigExt : Control
    {
        #region 新增事件

        public delegate void ImageFrameEventHandler(object sender, ImageFrameIndexChangedEventArgs e);

        private event ImageFrameEventHandler imageFrameIndexChanged;
        /// <summary>
        /// 图片旋转播放选项索引更改事件
        /// </summary>
        [Description("图片旋转播放选项索引更改事件")]
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
        ///图片旋转播放方向 
        /// </summary>
        [DefaultValue(Orientations.RightToLeft)]
        [Description("图片旋转播放方向")]
        public Orientations Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation == value)
                    return;

                this.orientation = value;
                this.current_orientation = this.orientation;
                this.InitializeImageFrameRectangle();
                this.InitializeImageFrameIndex();
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

        private bool imageAutoFree = true;
        /// <summary>
        /// 控件释放时是否自动释放倒影图片
        /// </summary>
        [DefaultValue(true)]
        [Description("控件释放时是否自动释放倒影图片")]
        public bool ImageAutoFree
        {
            get { return this.imageAutoFree; }
            set
            {
                if (this.imageAutoFree == value)
                    return;
                this.imageAutoFree = value;
            }
        }

        private double animationTime = 300d;
        /// <summary>
        /// 动画播放的总时间
        /// </summary>
        [DefaultValue(300d)]
        [Description("动画播放的总时间(默认300毫秒)")]
        public double AnimationTime
        {
            get { return this.animationTime; }
            set
            {
                if (this.animationTime == value || value < 10)
                    return;
                this.animationTime = value;
            }
        }

        private int intervalTime = 1000;
        /// <summary>
        /// 图片播放的时间间隔
        /// </summary>
        [DefaultValue(1000)]
        [Description("图片播放的时间间隔(默认1000毫秒)")]
        public int IntervalTime
        {
            get { return this.intervalTime; }
            set
            {
                if (this.intervalTime == value || value < 10)
                    return;
                this.intervalTime = value;
            }
        }

        private int enableImageCurrentIndex = 0;
        /// <summary>
        ///已启用图片列表的当前显示区的开始图片的索引
        /// </summary>
        [DefaultValue(0)]
        [Description("已启用图片列表的当前显示区的开始图片的索引")]
        public int EnableImageCurrentIndex
        {
            get { return this.enableImageCurrentIndex; }
            set
            {
                if (value < 0 || value >= this.enableImageList.Count)
                    return;

                this.enableImageCurrentIndex = value;
                this.InitializeImageFrameIndex();

                //跳过更新索引
                this.Invalidate();

                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new ImageFrameIndexChangedEventArgs() { index = value, Item = this.Images[this.enableImageList[value]] });
                }
            }
        }

        private ImageItemCollection imageItemCollection;
        /// <summary>
        /// 要播放的图片集合
        /// </summary>
        [DefaultValue(null)]
        [Description("要播放的图片集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ImageItemCollection Images
        {
            get
            {
                if (this.imageItemCollection == null)
                {
                    this.imageItemCollection = new ImageItemCollection(this);
                }
                return this.imageItemCollection;
            }
        }

        #region 图片框

        private int imageFrameCount = 5;
        /// <summary>
        /// 显示区要显示的图片框数量(必须为奇数,最小值3)
        /// </summary>
        [DefaultValue(5)]
        [Description("显示区要显示的图片框数量(必须为奇数,最小值3)")]
        public int ImageFrameCount
        {
            get { return this.imageFrameCount; }
            set
            {
                if (this.imageFrameCount == value || value < 2 || value % 2 != 1)
                    return;
                this.imageFrameCount = value;
                this.LoadImageFrame();
                this.InitializeDisplayRectangle();
                this.InitializeImageFrameIndex();
                this.Invalidate();
            }
        }

        private float imageFrameShrink = 0.8f;
        /// <summary>
        ///图片框间缩小比例 
        /// </summary>
        [DefaultValue(0.8f)]
        [Description("图片框间缩小比例")]
        public float ImageFrameShrink
        {
            get { return this.imageFrameShrink; }
            set
            {
                if (this.imageFrameShrink == value)
                    return;
                this.imageFrameShrink = value;
                this.InitializeDisplayRectangle();
                this.Invalidate();
            }
        }

        private int imageFrameInterval = 0;
        /// <summary>
        ///图片框间隔距离偏移量(为0时自动分配)
        /// </summary>
        [DefaultValue(0)]
        [Description("图片框间隔距离偏移量(为0时自动分配)")]
        public int ImageFrameInterval
        {
            get { return this.imageFrameInterval; }
            set
            {
                if (this.imageFrameInterval == value || value < 0)
                    return;
                this.imageFrameInterval = value;
                this.InitializeDisplayRectangle();
                this.Invalidate();
            }
        }

        private int imageFrameWidth = 400;
        /// <summary>
        /// 中间图片框宽度
        /// </summary>
        [DefaultValue(400)]
        [Description("中间图片框宽度(默认400)")]
        public int ImageFrameWidth
        {
            get { return this.imageFrameWidth; }
            set
            {
                if (this.imageFrameWidth == value || value < 1)
                    return;
                this.imageFrameWidth = value;
                this.InitializeDisplayRectangle();
                this.Invalidate();
            }
        }

        private int imageFrameHeight = 200;
        /// <summary>
        /// 中间图片框高度
        /// </summary>
        [DefaultValue(200)]
        [Description("中间图片框高度(默认200)")]
        public int ImageFrameHeight
        {
            get { return this.imageFrameHeight; }
            set
            {
                if (this.imageFrameHeight == value || value < 1)
                    return;
                this.imageFrameHeight = value;
                this.InitializeDisplayRectangle();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 中间图片框最终高度
        /// </summary>
        [Browsable(false)]
        [Description("中间图片框最终高度")]
        public int ImageFrameFinallyHeight
        {
            get
            {
                return this.ReflectionShow ? this.ImageFrameHeight + this.reflectionTop + this.ReflectionHeight : this.ImageFrameHeight;
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

        private Color textBackColor = Color.Transparent;
        /// <summary>
        ///图片文字背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
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

        #region 倒影

        private bool reflectionShow = false;
        /// <summary>
        /// 是否添加倒影
        /// </summary>
        [DefaultValue(false)]
        [Description("是否添加倒影")]
        public bool ReflectionShow
        {
            get { return this.reflectionShow; }
            set
            {
                if (this.reflectionShow == value)
                    return;
                this.reflectionShow = value;
                if (this.reflectionShow)
                {
                    this.InitializeReflectionImages(false);
                }
                this.InitializeDisplayRectangle();
                this.InitializeImageFrameIndex();
                this.Invalidate();
            }
        }

        private int reflectionHeight = 50;
        /// <summary>
        /// 倒影高度
        /// </summary>
        [DefaultValue(50)]
        [Description("倒影高度")]
        public int ReflectionHeight
        {
            get { return this.reflectionHeight; }
            set
            {
                if (this.reflectionHeight == value || value < 0)
                    return;
                this.reflectionHeight = value;
                if (this.ReflectionShow)
                {
                    this.InitializeReflectionImages(true);
                }

                this.InitializeDisplayRectangle();
                this.InitializeImageFrameIndex();
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
                return new Size(750, 280); ;
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
        /// 图片框是否已切换到指定图片(图片数量大于图片框数量时使用)
        /// </summary>
        private bool isSwitchImage = false;

        /// <summary>
        /// 图片播放的时间间隔累计(-1为动画正在切换中)
        /// </summary>
        private int intervalTimeValue = 0;

        /// <summary>
        /// 动画间隔定时器
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

        /// <summary>
        /// 倒影边距
        /// </summary>
        private int reflectionTop = 10;
        /// <summary>
        /// 明亮度
        /// </summary>
        private int reflectionBrightness = -50;
        /// <summary>
        /// 倒影开始透明度
        /// </summary>
        private int reflectionTransparentStart = 200;
        /// <summary>
        /// 倒影结束透明度
        /// </summary>
        private int reflectionTransparentEnd = -0;

        #endregion

        public ImageWhirligigExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.navigationBar.IsShow = (this.NavigationBarShowType == NavigationBarShowTypes.Normal) ? true : false;

            this.LoadImageFrame();
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

            if (this.imageFrameList.Count < 1 || this.enableImageList.Count < 1)
            {
                goto border;
            }

            #region 绘制图片
            //绘制顺序很重要
            SolidBrush image_sb = new SolidBrush(Color.White);
            int center_index = this.imageFrameList.Count / 2;

            //非动画状态时中间图片框为最前端
            if (this.intervalTimeValue != -1)
            {
                for (int i = 0; i < center_index; i++)
                {
                    //左边
                    this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)], this.imageFrameList[i].current_rectf);
                    //右边
                    this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[this.imageFrameList.Count - 1 - i].image_index)], this.imageFrameList[this.imageFrameList.Count - 1 - i].current_rectf);
                }
                this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[center_index].image_index)], this.imageFrameList[center_index].current_rectf);
            }
            else
            {
                if (this.IsNegative(this.current_orientation))//负向方向滑动
                {
                    int right_index = center_index + 1;
                    //左边
                    for (int i = 0; i < right_index; i++)
                    {
                        this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)], this.imageFrameList[i].current_rectf);
                    }
                    //右边
                    for (int i = this.imageFrameList.Count - 1; i >= right_index; i--)
                    {
                        this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)], this.imageFrameList[i].current_rectf);
                    }
                    //负向滑动时中间左边图片框为最前端
                    this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[right_index].image_index)], this.imageFrameList[right_index].current_rectf);
                }
                else
                {
                    int left_index = center_index - 1;
                    //右边
                    for (int i = this.imageFrameList.Count - 1; i > left_index; i--)
                    {
                        this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)], this.imageFrameList[i].current_rectf);
                    }
                    //左边
                    for (int i = 0; i < left_index; i++)
                    {
                        this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[i].image_index)], this.imageFrameList[i].current_rectf);
                    }
                    //正向滑动时中间右边图片框为最前端
                    this.DrawFrameImage(g, image_sb, this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[left_index].image_index)], this.imageFrameList[left_index].current_rectf);
                }
            }
            image_sb.Dispose();

            #endregion

            #region 图片文本
            if (this.TextShow)
            {
                int index = this.imageFrameList.Count / 2;
                string pre_text = this.Images[this.imageFrameList[this.imageFrameList.Count / 2].image_index].Text;
                string text = this.Images[this.GetEnableImageRealityIndex(this.imageFrameList[center_index].image_index)].Text;
                if (!String.IsNullOrWhiteSpace(text))
                {
                    StringFormat text_sf = new StringFormat() { Alignment = StringAlignment.Center };
                    SolidBrush text_back_sb = null;
                    SolidBrush text_fore_sb = null;

                    SizeF text_size = g.MeasureString(text, this.TextFont, new SizeF(), text_sf);
                    RectangleF text_rectf = new RectangleF(this.display_rectf.X + (this.display_rectf.Width - text_size.Width) / 2f, this.display_rectf.Bottom, text_size.Width, text_size.Height);
                    if (this.intervalTimeValue == -1)
                    {
                        float animation_progress = this.imageFrameList[center_index].animation_progress;
                        if (animation_progress <= 0.25f)
                        {
                            int a = ControlCommom.VerifyRGB((int)(this.TextBackColor.A * (1 - animation_progress * 4)));
                            text_back_sb = new SolidBrush(Color.FromArgb(a, this.TextBackColor));
                            text_fore_sb = new SolidBrush(Color.FromArgb(a, this.TextForeColor));
                        }
                        else
                        {
                            int a = ControlCommom.VerifyRGB((int)(this.TextBackColor.A * ((animation_progress - 0.25) * 1.333333333333)));
                            text_back_sb = new SolidBrush(Color.FromArgb(a, this.TextBackColor));
                            text_fore_sb = new SolidBrush(Color.FromArgb(a, this.TextForeColor));
                        }
                    }
                    else
                    {
                        text_back_sb = new SolidBrush(this.TextBackColor);
                        text_fore_sb = new SolidBrush(this.TextForeColor);
                    }
                    g.FillRectangle(text_back_sb, text_rectf);
                    g.DrawString(text, this.TextFont, text_fore_sb, text_rectf, text_sf);

                    if (text_fore_sb != null)
                        text_fore_sb.Dispose();
                    if (text_back_sb != null)
                        text_back_sb.Dispose();
                    if (text_sf != null)
                        text_sf.Dispose();
                }
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
                return base.ProcessDialogKey(keyData);
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
                    if (this.enableImageList.Count > 0)
                    {
                        if (this.NavigationBarShowType == NavigationBarShowTypes.Normal && this.activatedStateIndex > -1 && this.activatedStateIndex < this.navigationBar.GetBtnCount())
                        {
                            if (!this.DesignMode)
                            {
                                this.OnImageCarouseBarBtnClick(new NavigationBarBtnClickEventArgs() { index = this.EnableImageCurrentIndex, Btn = this.navigationBar.GetBtn(this.activatedStateIndex) });
                            }
                        }
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
                if (this.NavigationBarShowType != NavigationBarShowTypes.None && this.enableImageList.Count > 0)
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

            #region 停止轮播定时器
            if (this.EnterStop)
            {
                if (this.display_rectf.Contains(point))
                {
                    this.StopIntervalTimer();
                }
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

            #region 开始停止轮播定时器
            if (this.EnterStop)
            {
                if (this.display_rectf.Contains(e.Location))
                {
                    this.StopIntervalTimer();
                }
                else
                {
                    this.StartIntervalTimer();
                }
            }
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
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.animation != null)
                    this.animation.Dispose();
                if (this.intervalTimer != null)
                    this.intervalTimer.Dispose();
                if (this.ImageAutoFree)
                    this.FreeReflectionImages();
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
            this.isSwitchImage = false;

            #region 获取当前滑动方向
            if (e.Btn.type == NavigationBarBtnTypes.Pre)
            {
                if (this.Orientation == Orientations.LeftToRight)
                {
                    this.current_orientation = Orientations.RightToLeft;
                }
            }
            else
            {
                if (this.Orientation == Orientations.RightToLeft)
                {
                    this.current_orientation = Orientations.LeftToRight;
                }
            }
            #endregion

            if (this.navigationBarBtnClick != null)
            {
                this.navigationBarBtnClick(this, e);
            }

            this.ResetImageFrameRectangle();
            this.AutoUpdateImageEnableCurrentIndex();
            this.AutoUpdateEveryImageFrameIndex();

            this.animation.Options.Data = this.current_orientation;
            this.animation.AnimationType = AnimationTypes.EaseOut;
            this.animation.Options.AllTransformTime = this.AnimationTime;
            this.animation.Start(AnimationIntervalTypes.Add, 0);

        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 开始播放图片
        /// </summary>
        public void Play()
        {
            if (!this.Enabled)
                return;

            this.StartIntervalTimer();
        }

        /// <summary>
        /// 指定索引开始播放图片
        /// </summary>
        /// <param name="index"></param>
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
        /// 停止播放图片
        /// </summary>
        public void Stop()
        {
            this.StopIntervalTimer();
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

        /// <summary>
        /// 初始化所有倒影(已启用图片集)
        /// </summary>
        /// <param name="reload">强制重新生成倒影图片</param>
        public void InitializeReflectionImages(bool reload)
        {
            if (this.ReflectionShow)
            {
                for (int i = 0; i < this.enableImageList.Count; i++)
                {
                    this.InitializeReflectionImages(reload, this.enableImageList[i]);
                }
            }
        }

        /// <summary>
        /// 初始化指定倒影图片
        /// </summary>
        /// <param name="reload">强制重新生成倒影图片</param>
        /// <param name="index">Images集合图片索引</param>
        public void InitializeReflectionImages(bool reload, int index)
        {
            if (!this.ReflectionShow || index < 0 || index >= this.Images.Count)
                return;

            if (index >= 0)
            {
                if (reload)
                {
                    if (this.Images[index].ReflectionImage != null)
                    {
                        this.Images[index].ReflectionImage.Dispose();
                    }
                    this.Images[index].ReflectionImage = this.TransformReflection((Bitmap)this.Images[index].Image);
                }
                else
                {
                    if (this.Images[index].ReflectionImage == null)
                    {
                        this.Images[index].ReflectionImage = TransformReflection((Bitmap)this.Images[index].Image);
                    }
                }
            }

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
            if (this.enableImageList.Count < 1)
                return;

            if (this.intervalTimeValue == -1)//动画进行中
                return;

            this.intervalTimeValue += this.intervalTimer.Interval;
            if (this.intervalTimeValue >= this.intervalTime)
            {
                this.intervalTimeValue = -1;
                this.isSwitchImage = false;

                this.RestoreOrientation();
                this.AutoUpdateImageEnableCurrentIndex();
                this.AutoUpdateEveryImageFrameIndex();

                this.animation.Options.Data = this.current_orientation;
                this.animation.AnimationType = AnimationTypes.EaseOut;
                this.animation.Options.AllTransformTime = this.animationTime;
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
            int center_index = this.imageFrameList.Count / 2;

            #region 计算图片框当前Rectangle
            for (int i = 0; i < this.imageFrameList.Count; i++)
            {
                float w = this.imageFrameList[i].before_rectf.Width + (this.imageFrameList[i].target_rectf.Width - this.imageFrameList[i].before_rectf.Width) * (float)e.ProgressValue;
                float h = this.imageFrameList[i].before_rectf.Height + (this.imageFrameList[i].target_rectf.Height - this.imageFrameList[i].before_rectf.Height) * (float)e.ProgressValue;
                float x = this.imageFrameList[i].before_rectf.X + (this.imageFrameList[i].target_rectf.X - this.imageFrameList[i].before_rectf.X) * (float)e.ProgressValue;
                float y = this.display_rectf.Y + (this.display_rectf.Height - h) / 2;
                this.imageFrameList[i].current_rectf = new RectangleF(x, y, w, h);
            }
            #endregion

            #region 第一个图片框和最后一个图片框的图片索引更新
            if (this.Images.Count > this.imageFrameList.Count && !this.isSwitchImage)//当图片数量大于图片框数处理
            {
                if (this.Orientation == Orientations.RightToLeft)
                {
                    if (this.imageFrameList[0].current_rectf.X > (this.display_rectf.Width - this.ImageFrameWidth) / 2)
                    {
                        this.imageFrameList[0].image_index = this.ValidEnableImageIndex(this.imageFrameList[this.imageFrameList.Count - 1].image_index + 1);
                        this.isSwitchImage = true;
                    }
                }
                else
                {
                    if (this.imageFrameList[this.imageFrameList.Count - 1].current_rectf.X < (this.display_rectf.Width - this.ImageFrameWidth) / 2 + this.display_rectf.Width / 2)
                    {
                        this.imageFrameList[this.imageFrameList.Count - 1].image_index = this.ValidEnableImageIndex(this.imageFrameList[0].image_index + 1);
                        this.isSwitchImage = true;
                    }
                }
            }
            #endregion

            #region 图片文本显示问题
            if (this.Orientation == Orientations.RightToLeft)
            {
                center_index += 1;
                while (center_index >= this.imageFrameList.Count)
                {
                    center_index -= this.imageFrameList.Count;
                }
            }
            else
            {
                center_index -= 1;
                while (center_index < 0)
                {
                    center_index += this.imageFrameList.Count;
                }
            }

            this.imageFrameList[center_index].animation_progress = (float)e.AnimationUsedTime / (float)this.animation.Options.AllTransformTime;

            #endregion

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

            this.ResetImageFrameRectangle();
            this.InitializeImageFrameIndex();

            this.intervalTimeValue = 0;

            this.Invalidate();
        }

        /// <summary>
        /// 加载已启用图片索引集合
        /// </summary>
        internal void LoadEnableImageIndex()
        {
            List<int> old_enableImageList = this.enableImageList;
            List<int> new_enableImageList = new List<int>();
            for (int i = 0; i < this.Images.Count; i++)
            {
                if (this.Images[i].Enable)
                {
                    new_enableImageList.Add(i);
                }
            }
            this.enableImageList = new_enableImageList;
            old_enableImageList.Clear(); ;
        }

        /// <summary>
        /// 加载图片框集合
        /// </summary>
        private void LoadImageFrame()
        {
            List<ImageFrameItem> old_imageFrameList = this.imageFrameList;
            List<ImageFrameItem> new_imageFrameList = new List<ImageFrameItem>();
            for (int i = 0; i < this.ImageFrameCount; i++)
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
            int excursion = (int)(this.ImageFrameInterval != 0 ? this.ImageFrameInterval : this.ImageFrameWidth * this.ImageFrameShrink / 4);
            int center_index = this.ImageFrameCount / 2;
            float width = ImageFrameWidth + (this.ImageFrameCount - (center_index + 1)) * excursion * 2;
            float x = this.ClientRectangle.X;
            float y = this.ClientRectangle.Y;
            if (this.ClientRectangle.Width != width)
            {
                x = (this.ClientRectangle.Width - width) / 2f;
            }
            if (this.ClientRectangle.Height != this.ImageFrameFinallyHeight)
            {
                y = (this.ClientRectangle.Height - this.ImageFrameFinallyHeight) / 2f;
            }
            rectf = new RectangleF(x, y, width, this.ImageFrameFinallyHeight);

            this.display_rectf = rectf;

            this.InitializeNavigationBarRectangle();
            this.InitializeImageFrameRectangle();
        }

        /// <summary>
        /// 初始化导航栏Rectangle
        /// </summary>
        private void InitializeNavigationBarRectangle()
        {
            if (this.NavigationBarShowType != NavigationBarShowTypes.None)
            {
                float barbtn_avg_w = this.NavigationBarBtnWidth / 4f;
                float barbtn_avg_h = this.NavigationBarBtnHeight / 6f;
                float padding = this.NavigationBarBtnWidth / 5f;

                #region 向上一页按钮
                this.navigationBar.pre_btn.btn_rectf = new RectangleF(this.display_rectf.X + padding, this.display_rectf.Y + (this.display_rectf.Height - this.NavigationBarBtnHeight) / 2f, this.NavigationBarBtnWidth, this.NavigationBarBtnHeight);
                PointF[] pre_line_points = new PointF[3];
                pre_line_points[0] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w * 3), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h));
                pre_line_points[1] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h * 3));
                pre_line_points[2] = new PointF((this.navigationBar.pre_btn.btn_rectf.X + barbtn_avg_w * 3), (this.navigationBar.pre_btn.btn_rectf.Y + barbtn_avg_h * 5));
                this.navigationBar.pre_btn.btn_line_rectf = pre_line_points;
                #endregion
                #region 向下一页按钮
                this.navigationBar.next_btn.btn_rectf = new RectangleF(this.display_rectf.Right - this.NavigationBarBtnWidth - padding, this.display_rectf.Y + (this.display_rectf.Height - this.NavigationBarBtnHeight) / 2f, this.NavigationBarBtnWidth, this.NavigationBarBtnHeight);
                PointF[] next_line_points = new PointF[3];
                next_line_points[0] = new PointF((this.navigationBar.next_btn.btn_rectf.Right - barbtn_avg_w * 3), (this.navigationBar.next_btn.btn_rectf.Y + barbtn_avg_h));
                next_line_points[1] = new PointF((this.navigationBar.next_btn.btn_rectf.Right - barbtn_avg_w), (this.navigationBar.next_btn.btn_rectf.Y + barbtn_avg_h * 3));
                next_line_points[2] = new PointF((this.navigationBar.next_btn.btn_rectf.Right - barbtn_avg_w * 3), (this.navigationBar.next_btn.btn_rectf.Y + barbtn_avg_h * 5));
                this.navigationBar.next_btn.btn_line_rectf = next_line_points;
                #endregion
            }
        }

        /// <summary>
        /// 初始化所有图片框Rectangle
        /// </summary>
        private void InitializeImageFrameRectangle()
        {
            if (this.imageFrameList.Count < 1)
                return;

            int excursion = (int)(this.ImageFrameInterval != 0 ? this.ImageFrameInterval : this.ImageFrameWidth * this.ImageFrameShrink / 4);
            int center_index = this.imageFrameList.Count / 2;

            #region 图片框Rectangle
            //中间图片框
            this.imageFrameList[center_index].before_rectf = new RectangleF(this.display_rectf.X + (this.display_rectf.Width - this.ImageFrameWidth) / 2, this.display_rectf.Y + (this.display_rectf.Height - this.ImageFrameFinallyHeight) / 2, this.ImageFrameWidth, this.ImageFrameFinallyHeight);
            this.imageFrameList[center_index].current_rectf = this.imageFrameList[center_index].before_rectf;

            for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
            {
                float w = this.imageFrameList[i - 1].current_rectf.Width * this.ImageFrameShrink;
                float h = this.imageFrameList[i - 1].current_rectf.Height * this.ImageFrameShrink;
                float y = (this.display_rectf.Height - h) / 2;

                //右边图片框
                float x_right = this.imageFrameList[i - 1].current_rectf.Right + excursion - w;
                this.imageFrameList[i].before_rectf = new RectangleF(x_right, this.display_rectf.Y + y, w, h);
                this.imageFrameList[i].current_rectf = this.imageFrameList[i].before_rectf;

                //左边图片框
                float x_left = this.imageFrameList[this.imageFrameList.Count - 1 - i + 1].current_rectf.X - excursion;
                this.imageFrameList[this.imageFrameList.Count - 1 - i].before_rectf = new RectangleF(x_left, this.display_rectf.Y + y, w, h);
                this.imageFrameList[this.imageFrameList.Count - 1 - i].current_rectf = this.imageFrameList[this.imageFrameList.Count - 1 - i].before_rectf;
            }
            #endregion

            #region 默认Rectangle
            #region 负方向
            for (int i = 0; i < this.imageFrameList.Count; i++)
            {
                this.imageFrameList[i].target_right_rectf = this.imageFrameList[this.ValidImageFrameIndex(i - 1)].before_rectf;
            }
            #endregion
            #region 正方向
            for (int i = 0; i < this.imageFrameList.Count; i++)
            {
                this.imageFrameList[i].target_left_rectf = this.imageFrameList[this.ValidImageFrameIndex(i + 1)].before_rectf;
            }
            #endregion
            #endregion

            #region 目标Rectangle
            #region 负方向
            if (this.IsNegative(this.current_orientation))
            {
                this.imageFrameList[0].target_rectf = this.imageFrameList[this.imageFrameList.Count - 1].before_rectf;
                for (int i = this.imageFrameList.Count - 1; i > 0; i--)
                {
                    this.imageFrameList[i].target_rectf = this.imageFrameList[i - 1].before_rectf;
                }
            }
            #endregion
            #region 正方向
            else
            {
                this.imageFrameList[this.imageFrameList.Count - 1].target_rectf = this.imageFrameList[0].before_rectf;
                for (int i = 0; i < this.imageFrameList.Count - 1; i++)
                {
                    this.imageFrameList[i].target_rectf = this.imageFrameList[i + 1].before_rectf;
                }
            }
            #endregion
            #endregion

        }

        /// <summary>
        /// 初始化每一个图片框的图片索引（用于ImageEnableCurrentIndex更改但不进行切换的情况）
        /// </summary>
        private void InitializeImageFrameIndex()
        {
            if (this.imageFrameList.Count < 1 || this.enableImageList.Count < 1)
                return;

            int center_index = this.imageFrameList.Count / 2;
            #region 负方向
            if (this.IsNegative(this.current_orientation))
            {
                this.imageFrameList[center_index].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex);
                for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
                {
                    this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + (i - center_index));//增加指定偏移量
                }
                for (int i = center_index - 1; i >= 0; i--)
                {
                    this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + (i - center_index));//增加指定偏移量
                }
            }
            #endregion
            #region 正方向
            else
            {
                this.imageFrameList[center_index].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex);
                for (int i = center_index - 1; i >= 0; i--)
                {
                    this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - (i - center_index));//增加指定偏移量
                }
                for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
                {
                    this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - (i - center_index));//增加指定偏移量
                }
            }
            #endregion
        }

        /// <summary>
        /// 每一次播放前还原图片框的默认Rectangle设置
        /// </summary>
        private void ResetImageFrameRectangle()
        {
            #region 负方向滑动
            if (this.IsNegative(this.current_orientation))
            {
                for (int i = 0; i < this.imageFrameList.Count; i++)
                {
                    this.imageFrameList[i].target_rectf = this.imageFrameList[i].target_right_rectf;
                    this.imageFrameList[i].current_rectf = this.imageFrameList[i].before_rectf;
                }
            }
            #endregion
            #region 正方向滑动
            else
            {
                for (int i = 0; i < this.imageFrameList.Count; i++)
                {
                    this.imageFrameList[i].target_rectf = this.imageFrameList[i].target_left_rectf;
                    this.imageFrameList[i].current_rectf = this.imageFrameList[i].before_rectf;
                }
            }
            #endregion
        }

        /// <summary>
        /// 自动更新已启用图片列表的当前显示区的开始图片的索引(用于定时器和按钮切换时索引加减1)
        /// </summary>
        private void AutoUpdateImageEnableCurrentIndex()
        {
            #region 同向
            if (!this.IsReverse(this.Orientation, this.current_orientation))//同向滑动后当前图片索引加1
            {
                int display_index_tmp = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + 1);
                this.enableImageCurrentIndex = display_index_tmp;

                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new ImageFrameIndexChangedEventArgs() { index = display_index_tmp, Item = this.Images[this.enableImageList[display_index_tmp]] });
                }
            }
            #endregion
            #region 反向
            else//反向滑动后当前图片索引减1
            {
                int display_index_tmp = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - 1);
                this.enableImageCurrentIndex = display_index_tmp;
                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new ImageFrameIndexChangedEventArgs() { index = display_index_tmp, Item = this.Images[this.enableImageList[display_index_tmp]] });
                }
            }

            #endregion

        }

        /// <summary>
        /// 更新每一个图片框的图片索引(用于定时器和按钮切换时索引加减1,一般用于AutoUpdateImageEnableCurrentIndex方法之后)
        /// </summary>
        private void AutoUpdateEveryImageFrameIndex()
        {
            #region 图片索引
            if (this.imageFrameList.Count < 1 || this.enableImageList.Count < 1)
                return;

            int center_index = this.imageFrameList.Count / 2;
            #region 负方向
            if (this.IsNegative(this.current_orientation))
            {
                #region 负方向的同向
                if (!this.IsReverse(this.Orientation, this.current_orientation))
                {
                    center_index += 1;
                    this.imageFrameList[center_index].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex);
                    for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + (i - center_index));//增加指定偏移量
                    }
                    for (int i = center_index - 1; i >= 0; i--)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + (i - center_index));//增加指定偏移量
                    }
                }
                #endregion
                #region 负方向的反向
                else if (!this.IsReverse(this.Orientation, this.current_orientation))
                {
                    center_index -= 1;
                    this.imageFrameList[center_index].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex);
                    for (int i = center_index - 1; i >= 0; i--)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - (i - center_index));//增加指定偏移量
                    }
                    for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - (i - center_index));//增加指定偏移量
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
                    center_index -= 1;
                    this.imageFrameList[center_index].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex);
                    for (int i = center_index - 1; i >= 0; i--)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - (i - center_index));//增加指定偏移量
                    }
                    for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex - (i - center_index));//增加指定偏移量
                    }

                }
                #endregion
                #region 正方向的反向
                else if (!this.IsReverse(this.Orientation, this.current_orientation))
                {
                    center_index += 1;
                    this.imageFrameList[center_index].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex);
                    for (int i = center_index + 1; i < this.imageFrameList.Count; i++)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + (i - center_index));//增加指定偏移量
                    }
                    for (int i = center_index - 1; i >= 0; i--)
                    {
                        this.imageFrameList[i].image_index = this.ValidEnableImageIndex(this.EnableImageCurrentIndex + (i - center_index));//增加指定偏移量
                    }
                }
                #endregion
            }
            #endregion
            #endregion

        }

        /// <summary>
        ///获取验证后图片在已启用图片列表的索引
        /// </summary>
        /// <param name="index">已启用图片列表的索引</param>
        /// <returns></returns>
        private int ValidEnableImageIndex(int index)
        {
            while (index > this.enableImageList.Count - 1)
                index -= this.enableImageList.Count;
            while (index < 0)
                index += this.enableImageList.Count;
            return index;
        }

        /// <summary>
        ///获取验证后图片框列表的索引
        /// </summary>
        /// <param name="index">图片框的索引</param>
        /// <returns></returns>
        private int ValidImageFrameIndex(int index)
        {
            while (index > this.imageFrameList.Count - 1)
                index -= this.imageFrameList.Count;
            while (index < 0)
                index += this.imageFrameList.Count;
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
            }
        }

        /// <summary>
        /// 是否负方向滑动（RightToLeft）
        /// </summary>
        /// <param name="_orientation"></param>
        /// <returns></returns>
        private bool IsNegative(Orientations _orientation)
        {
            return (_orientation == Orientations.RightToLeft);
        }

        /// <summary>
        /// 是否正方向滑动（LeftToRight）
        /// </summary>
        /// <param name="_orientation"></param>
        /// <returns></returns>
        private bool IsPositive(Orientations _orientation)
        {
            return (_orientation == Orientations.LeftToRight);
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

        /// <summary>
        /// 绘制图片
        /// </summary>
        /// <param name="g"></param>
        /// <param name="imageCarousel"></param>
        /// <param name="rectf"></param>
        private void DrawFrameImage(Graphics g, SolidBrush imageSb, ImageItem imageCarousel, RectangleF rectf)
        {
            if (this.ReflectionShow)
            {
                if (imageCarousel.ReflectionImage != null)
                    g.DrawImage(imageCarousel.ReflectionImage, rectf);
                else
                    g.FillRectangle(imageSb, rectf);
            }
            else
            {
                if (imageCarousel.Image != null)
                    g.DrawImage(imageCarousel.Image, rectf);
                else
                    g.FillRectangle(imageSb, rectf);
            }
        }

        /// <summary>
        /// 倒影变换
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="val">透明度（0-255）</param>
        private Bitmap TransformReflection(Bitmap bmp)
        {
            if (bmp == null)
                return null;
            return ControlCommom.TransformReflection(bmp, this.reflectionTop, this.reflectionBrightness, reflectionTransparentStart, reflectionTransparentEnd, this.ReflectionHeight);
        }

        /// <summary>
        /// 释放所有倒影图片
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void FreeReflectionImages()
        {
            if (this.Images != null)
            {
                for (int i = 0; i < this.Images.Count; i++)
                {
                    this.Images[i].ReflectionImage.Dispose();
                    this.Images[i].ReflectionImage = null;
                }
                this.Images.Clear();
            }
        }

        /// <summary>
        /// 释放指定索引倒影图片
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void FreeReflectionImage(int index)
        {
            if (this.Images != null && index >= 0 && index < this.Images.Count)
            {
                this.Images[index].ReflectionImage.Dispose();
                this.Images[index].ReflectionImage = null;
                this.Images.RemoveAt(index);
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 图片选项集合
        /// </summary>
        [Description("图片选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ImageItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList imageItemList = new ArrayList();
            private ImageWhirligigExt owner;

            public ImageItemCollection(ImageWhirligigExt owner)
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
                if (this.owner.ReflectionShow)
                {
                    this.owner.InitializeReflectionImages(true, this.Count - 1);
                }
                this.owner.InitializeImageFrameIndex();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                if (this.owner.ImageAutoFree)
                {
                    for (int i = 0; i < this.imageItemList.Count; i++)
                    {
                        ImageItem item = (ImageItem)this.imageItemList[i];
                        if (item.ReflectionImage != null)
                        {
                            item.ReflectionImage.Dispose();
                            item.ReflectionImage = null;
                        }
                    }
                }
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
                if (this.owner.ImageAutoFree)
                {
                    if (item.ReflectionImage != null)
                    {
                        item.ReflectionImage.Dispose();
                        item.ReflectionImage = null;
                    }
                }
                this.imageItemList.Remove(item);
                this.owner.LoadEnableImageIndex();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                ImageItem item = (ImageItem)this.imageItemList[index];
                if (this.owner.ImageAutoFree)
                {
                    if (item.ReflectionImage != null)
                    {
                        item.ReflectionImage.Dispose();
                        item.ReflectionImage = null;
                    }
                }
                this.imageItemList.RemoveAt(index);
                this.owner.LoadEnableImageIndex();
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
                    ImageItem item = (ImageItem)this.imageItemList[index];
                    if (item.ReflectionImage != null)
                    {
                        item.ReflectionImage.Dispose();
                        item.ReflectionImage = null;
                    }
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
                    ImageItem item = (ImageItem)this.imageItemList[index];
                    if (item.ReflectionImage != null)
                    {
                        item.ReflectionImage.Dispose();
                        item.ReflectionImage = null;
                    }
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
            internal ImageWhirligigExt owner;

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

                    if (this.owner != null && this.owner.ReflectionShow)
                    {
                        this.owner.InitializeReflectionImages(true, this.owner.Images.IndexOf(this));
                    }
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

            private Image reflectionImage = null;
            /// <summary>
            /// 倒影图片
            /// </summary>
            [Browsable(false)]
            [DefaultValue(null)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("倒影图片")]
            public Image ReflectionImage
            {
                get { return this.reflectionImage; }
                set
                {
                    if (this.reflectionImage == value)
                        return;
                    this.reflectionImage = value;
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
        /// 图片旋转播放选项
        /// </summary>
        [Description("图片旋转播放选项")]
        public class ImageFrameItem
        {
            /// <summary>
            /// 向左滑动时默认目标rectf
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("向左滑动时默认目标rectf")]
            public RectangleF target_left_rectf { get; set; }

            /// <summary>
            /// 向右滑动时默认目标rectf
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("向右滑动时默认目标rectf")]
            public RectangleF target_right_rectf { get; set; }

            /// <summary>
            /// 运动前rectf
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("框运动前rectf")]
            public RectangleF before_rectf { get; set; }

            /// <summary>
            /// 目标rectf
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("框目标rectf")]
            public RectangleF target_rectf { get; set; }

            /// <summary>
            /// 当前rectf
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("框当前rectf")]
            public RectangleF current_rectf { get; set; }

            /// <summary>
            /// 已启用显示属性的图片列表的索引值
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("已启用显示属性的图片列表的索引值")]
            public int image_index { get; set; }

            /// <summary>
            /// 动画进度（0-1）
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("动画进度（0-1）")]
            public float animation_progress { get; set; }
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
        /// 图片旋转播放方向
        /// </summary>
        [Description("图片旋转播放方向")]
        public enum Orientations
        {
            /// <summary>
            /// 由右往左
            /// </summary>
            RightToLeft,
            /// <summary>
            /// 由左往右
            /// </summary>
            LeftToRight
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
