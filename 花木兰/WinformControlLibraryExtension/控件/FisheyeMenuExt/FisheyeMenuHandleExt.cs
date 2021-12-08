
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 鱼眼菜单(窗体版)
    /// </summary>
    [ToolboxItem(true)]
    [Description("鱼眼菜单(窗体版)")]
    [DefaultProperty("Items")]
    [DefaultEvent("ItemClick")]
    public class FisheyeMenuHandleExt : Component
    {
        #region 新增事件

        public delegate void IndexChangedEventHandler(object sender, IndexChangedEventArgs e);

        private event IndexChangedEventHandler indexChanged;
        /// <summary>
        /// 鱼眼菜单选项选中索引更改事件
        /// </summary>
        [Description("鱼眼菜单选项选中索引更改事件")]
        public event IndexChangedEventHandler IndexChanged
        {
            add { this.indexChanged += value; }
            remove { this.indexChanged -= value; }
        }

        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);

        private event ItemClickEventHandler itemClick;
        /// <summary>
        /// 鱼眼菜单选项单击事件
        /// </summary>
        [Description("鱼眼菜单选项单击事件")]
        public event ItemClickEventHandler ItemClick
        {
            add { this.itemClick += value; }
            remove { this.itemClick -= value; }
        }

        public delegate void SelectedEventHandler(object sender, SelectedEventArgs e);

        private event SelectedEventHandler selected;
        /// <summary>
        /// 鱼眼菜单鼠标按下滑动选中鼠标释放事件
        /// </summary>
        [Description("鱼眼菜单鼠标按下滑动选中鼠标释放事件")]
        public event SelectedEventHandler Selected
        {
            add { this.selected += value; }
            remove { this.selected -= value; }
        }

        #endregion

        #region 新增属性

        #region

        private bool enabled = false;
        /// <summary>
        /// 是否启用控件
        /// </summary>
        [DefaultValue(false)]
        [Description("是否启用控件")]
        public bool Enabled
        {
            get { return this.enabled; }
            set
            {
                if (this.enabled == value)
                    return;

                this.enabled = value;

                this.fbhm.Enabled = this.enabled;
                this.fml.Enabled = this.enabled;

                if (!this.DesignMode)
                {
                    #region
                    if (this.enabled)
                    {
                        if (this.timer_obj.timer == null)
                        {
                            this.CreateFisheyeMenuTimer();
                        }

                        if (this.ShowWay == FisheyeMenuShowWays.Always)
                        {
                            this.ShowFisheyeMenuLayer();
                        }

                        this.fbmh.HookStart(this.ISScreenControl() ? FisheyeMenuMouseHookTypes.Global : FisheyeMenuMouseHookTypes.Module);

                        if (this.ShortcutKeyShow)
                        {
                            this.fbkh.HookStart();
                        }
                    }
                    #endregion
                    #region
                    else
                    {
                        if (this.timer_obj.timer != null)
                        {
                            this.timer_obj.timer.Stop();
                            this.timer_obj.timer.Tick -= new EventHandler(this.FisheyeMenuExtLayerTimer_Tick);
                            this.timer_obj.timer.Dispose();
                        }

                        if (this.ShowWay == FisheyeMenuShowWays.Always)
                        {
                            this.HideFisheyeMenuLayer();
                        }

                        this.fbmh.HookStop();
                        this.fbkh.HookStop();
                    }
                    #endregion
                    this.InvalidateLayer();
                }
            }
        }

        private FisheyeMenuShowTypes showType = FisheyeMenuShowTypes.ImageText;
        /// <summary>
        /// 鱼眼菜单显示类型
        /// </summary>
        [DefaultValue(FisheyeMenuShowTypes.ImageText)]
        [Description("鱼眼菜单显示类型")]
        public FisheyeMenuShowTypes ShowType
        {
            get { return this.showType; }
            set
            {
                if (this.showType == value)
                    return;

                this.showType = value;

                if (this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.UpdateReflectionImage();
                }
                else
                {
                    this.FreeReflectionImages();
                }
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
            }
        }

        private FisheyeMenuShowWays showWay = FisheyeMenuShowWays.Auto;
        /// <summary>
        /// 鱼眼菜单显示方式
        /// </summary>
        [DefaultValue(FisheyeMenuShowWays.Auto)]
        [Description("鱼眼菜单显示方式")]
        public FisheyeMenuShowWays ShowWay
        {
            get { return this.showWay; }
            set
            {
                if (this.showWay == value)
                    return;

                this.showWay = value;
                if (!this.DesignMode)
                {
                    #region
                    if (this.showWay == FisheyeMenuShowWays.Always)
                    {
                        if (this.timer_obj.timer != null)
                        {
                            this.timer_obj.timer.Stop();
                            this.timer_obj.timer.Tick -= new EventHandler(this.FisheyeMenuExtLayerTimer_Tick);
                            this.timer_obj.timer.Dispose();
                        }

                        this.fbmh.HookStop();
                        this.fbkh.HookStop();

                        this.ShowFisheyeMenuLayer();

                        this.FisheyeMenuHandleMaskRemoveEvent();
                        this.fbhm.Hide();
                    }
                    #endregion
                    #region
                    else
                    {
                        if (this.Enabled)
                        {

                            if (this.timer_obj.timer == null)
                            {
                                this.CreateFisheyeMenuTimer();
                            }

                            this.fbmh.HookStart(this.ISScreenControl() ? FisheyeMenuMouseHookTypes.Global : FisheyeMenuMouseHookTypes.Module);

                            this.HideFisheyeMenuLayer();
                            if (!this.ISScreenControl())
                            {
                                this.ShowFisheyeMenuHandleMask();
                            }
                            if (this.ShortcutKeyShow)
                            {
                                this.fbkh.HookStart();
                            }
                        }
                    }
                    #endregion
                    this.InvalidateLayer();
                }
            }
        }

        private FisheyeMenuShowOrientation showOrientation = FisheyeMenuShowOrientation.Bottom;
        /// <summary>
        /// 鱼眼菜单显示方向
        /// </summary>
        [DefaultValue(FisheyeMenuShowOrientation.Bottom)]
        [Description("鱼眼菜单显示方向")]
        public FisheyeMenuShowOrientation ShowOrientation
        {
            get { return this.showOrientation; }
            set
            {
                if (this.showOrientation == value)
                    return;

                this.showOrientation = value;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.UpdateReflectionImage();
                }
                else
                {
                    this.FreeReflectionImages();
                }
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
                this.UpdateFisheyeMenuHandleMask();
            }
        }

        private int cushionThickness = 10;
        /// <summary>
        /// 鱼眼菜单选项底垫厚度
        /// </summary>
        [DefaultValue(10)]
        [Description("鱼眼菜单选项底垫厚度")]
        public int CushionThickness
        {
            get { return this.cushionThickness; }
            set
            {
                if (this.cushionThickness == value || value < 0)
                    return;

                this.cushionThickness = value;
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
            }
        }

        private Form ownerForm = null;
        /// <summary>
        /// 鱼眼菜单所属窗体(null为屏幕控件)
        /// </summary>
        [DefaultValue(null)]
        [Description("鱼眼菜单所属窗体(null为屏幕控件)")]
        public Form OwnerForm
        {
            get { return this.ownerForm; }
            set
            {
                if (this.ownerForm == value)
                    return;

                if (value == null)
                {
                    this.ownerForm = value;
                    this.fml.Owner = this.ownerForm;
                    this.fbhm.Owner = this.ownerForm;

                    if (!this.DesignMode)
                    {
                        this.CreateFisheyeMenuMouseHook();
                        this.fbmh.HookStart(this.ISScreenControl() ? FisheyeMenuMouseHookTypes.Global : FisheyeMenuMouseHookTypes.Module);
                        if (this.ShortcutKeyShow)
                        {
                            this.CreateFisheyeMenuKeyHook();
                            this.fbkh.HookStart();
                        }
                    }
                }
                else
                {
                    this.fbmh.HookStop();

                    if (!this.DesignMode)
                    {
                        this.fbmh.HookStart(this.ISScreenControl() ? FisheyeMenuMouseHookTypes.Global : FisheyeMenuMouseHookTypes.Module);
                    }

                    this.ownerForm = value;
                    this.fml.Owner = this.ownerForm;
                    this.fbhm.Owner = this.ownerForm;

                    if (!this.DesignMode)
                    {
                        this.ShowFisheyeMenuHandleMask();
                    }
                }

                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
            }
        }

        private FisheyeMenuItemCollection fisheyeMenuItemCollection;
        /// <summary>
        /// 鱼眼菜单选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("鱼眼菜单选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FisheyeMenuItemCollection Items
        {
            get
            {
                if (this.fisheyeMenuItemCollection == null)
                    this.fisheyeMenuItemCollection = new FisheyeMenuItemCollection(this);
                return this.fisheyeMenuItemCollection;
            }
        }

        #endregion

        #region 鱼眼菜单弹层

        private int layeredShowTime = 1000;
        /// <summary>
        /// 鼠标停留指定毫秒数后显示鱼眼菜单
        /// </summary>
        [DefaultValue(1000)]
        [Description("鼠标停留指定毫秒数后显示鱼眼菜单")]
        [Category("杂项(鱼眼菜单)")]
        public int LayeredShowTime
        {
            get { return this.layeredShowTime; }
            set
            {
                if (this.layeredShowTime == value || value < 0)
                    return;

                this.layeredShowTime = value;
            }
        }

        private int layeredHideTime = 1000;
        /// <summary>
        /// 鼠标离开指定毫秒数后隐藏鱼眼菜单
        /// </summary>
        [DefaultValue(1000)]
        [Description("鼠标离开指定毫秒数后隐藏鱼眼菜单")]
        [Category("杂项(鱼眼菜单)")]
        public int LayeredHideTime
        {
            get { return this.layeredHideTime; }
            set
            {
                if (this.layeredHideTime == value || value < 0)
                    return;

                this.layeredHideTime = value;
            }
        }

        #endregion

        #region 鱼眼菜单句柄蒙版层

        private bool handleMaskShow = true;
        /// <summary>
        /// 是否显示鱼眼菜单句柄蒙版层
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示鱼眼菜单句柄蒙版层")]
        [Category("杂项(鱼眼菜单句柄)")]
        public bool HandleMaskShow
        {
            get { return this.handleMaskShow; }
            set
            {
                if (this.handleMaskShow == value)
                    return;

                this.handleMaskShow = value;
                if (this.handleMaskShow)
                {
                    this.ShowFisheyeMenuHandleMask();
                }
                else
                {
                    this.FisheyeMenuHandleMaskRemoveEvent();
                    this.fbhm.Hide();
                }
            }
        }

        private int handlemaskheight = 10;
        /// <summary>
        /// 鱼眼菜单句柄蒙版层height
        /// </summary>
        [DefaultValue(10)]
        [Description("鱼眼菜单句柄蒙版层height")]
        [Category("杂项(鱼眼菜单句柄)")]
        public int HandleMaskHeight
        {
            get
            {
                return this.handlemaskheight;
            }
            set
            {
                if (this.handlemaskheight == value)
                    return;

                this.handlemaskheight = value;
                this.UpdateFisheyeMenuHandleMask();
            }
        }

        private Color handleMaskBackColor = Color.FromArgb(40, 0, 0, 0);
        /// <summary>
        /// 鱼眼菜单句柄蒙版层背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "40, 0, 0, 0")]
        [Description("鱼眼菜单句柄蒙版层背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [Category("杂项(鱼眼菜单句柄)")]
        public Color HandleMaskBackColor
        {
            get { return this.handleMaskBackColor; }
            set
            {
                if (this.handleMaskBackColor == value)
                    return;

                this.handleMaskBackColor = value;
                this.fbhm.InvalidateLayer();
            }
        }

        #endregion

        #region 选项

        private bool itemMaskShow = true;
        /// <summary>
        /// 是否显示选项内容蒙版层
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示选项内容蒙版层")]
        [Category("杂项(选项)")]
        public bool ItemMaskShow
        {
            get { return this.itemMaskShow; }
            set
            {
                if (this.itemMaskShow == value)
                    return;

                this.itemMaskShow = value;
                this.InvalidateLayer();
            }
        }

        private int itemMaskPadding = 10;
        /// <summary>
        /// 鱼眼菜单选项蒙版层内边距
        /// </summary>
        [DefaultValue(10)]
        [Description("鱼眼菜单选项蒙版层内边距")]
        [Category("杂项(选项)")]
        public int ItemMaskPadding
        {
            get { return this.itemMaskPadding; }
            set
            {
                if (this.itemMaskPadding == value || value < 0)
                    return;

                this.itemMaskPadding = value;
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
            }
        }

        private int itemMaskRadius = 5;
        /// <summary>
        /// 选项内容背景圆角
        /// </summary>
        [Browsable(true)]
        [DefaultValue(5)]
        [Description("选项内容背景圆角")]
        [Category("杂项(选项)")]
        public int ItemMaskRadius
        {
            get { return this.itemMaskRadius; }
            set
            {
                if (this.itemMaskRadius == value || value < 0)
                    return;

                this.itemMaskRadius = value;
                this.InvalidateLayer();
            }
        }

        private Color itemMaskBackColor = Color.FromArgb(100, 0, 0, 0);
        /// <summary>
        /// 鱼眼菜单弹层内容背景颜色 
        /// </summary>
        [DefaultValue(typeof(Color), "100, 0, 0, 0")]
        [Description("鱼眼菜单弹层内容背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [Category("杂项(选项)")]
        public Color ItemMaskBackColor
        {
            get { return this.itemMaskBackColor; }
            set
            {
                if (this.itemMaskBackColor == value)
                    return;

                this.itemMaskBackColor = value;
                this.InvalidateLayer();
            }
        }

        private int itemDistance = 0;
        /// <summary>
        /// 鱼眼菜单选项间距
        /// </summary>
        [DefaultValue(0)]
        [Description("鱼眼菜单选项间距")]
        [Category("杂项(选项)")]
        public int ItemDistance
        {
            get { return this.itemDistance; }
            set
            {
                if (this.itemDistance == value || value < 0)
                    return;

                this.itemDistance = value;
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
                this.UpdateFisheyeMenuHandleMask();
            }
        }

        #endregion

        #region 图片

        private int imageWidth = 128;
        /// <summary>
        /// 图片宽度
        /// </summary>
        [DefaultValue(128)]
        [Description("图片宽度")]
        [Category("杂项(图片)")]
        public int ImageWidth
        {
            get { return this.imageWidth; }
            set
            {
                if (this.imageWidth == value || value < 0)
                    return;

                this.imageWidth = value;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText)
                {
                    this.CalculateImageSize();
                    this.UpdateFisheyeMenuLayerRectangle();
                    this.InvalidateLayer();
                }
            }
        }

        private int imageHeight = 128;
        /// <summary>
        /// 图片高度
        /// </summary>
        [DefaultValue(128)]
        [Description("图片高度")]
        [Category("杂项(图片)")]
        public int ImageHeight
        {
            get { return this.imageHeight; }
            set
            {
                if (this.imageHeight == value || value < 0)
                    return;

                this.imageHeight = value;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText)
                {
                    this.CalculateImageSize();
                    this.UpdateFisheyeMenuLayerRectangle();
                    this.InvalidateLayer();
                }
            }
        }

        private float imageProportion = 0.5f;
        /// <summary>
        /// 图片缩放比例(1>Proportion>0)
        /// </summary>
        [DefaultValue(0.5f)]
        [Description("图片缩放比例(1>Proportion>0)")]
        [Category("杂项(图片)")]
        public float ImageProportion
        {
            get { return this.imageProportion; }
            set
            {
                if (this.imageProportion == value || value <= 0)
                    return;

                this.imageProportion = value;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText)
                {
                    this.SetFisheyeMenuItemDefaultProportion();
                    this.UpdateFisheyeMenuLayerRectangle();
                    this.InvalidateLayer();
                }
            }
        }

        private bool imageAutoFree = true;
        /// <summary>
        /// 控件释放时是否自动释放倒影图片
        /// </summary>
        [DefaultValue(true)]
        [Description("控件释放时是否自动释放倒影图片")]
        [Category("杂项(图片)")]
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

        private bool imageReflection = false;
        /// <summary>
        /// 图片是否添加倒影(限于FisheyeMenuOrientation.Top 、 FisheyeMenuOrientation.Bottom)
        /// </summary>
        [DefaultValue(false)]
        [Description("图片是否添加倒影(限于FisheyeMenuOrientation.Top 、 FisheyeMenuOrientation.Bottom)")]
        [Category("杂项(图片)")]
        public bool ImageReflection
        {
            get { return this.imageReflection; }
            set
            {
                if (this.imageReflection == value)
                    return;

                this.imageReflection = value;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.UpdateReflectionImage();
                }
                else
                {
                    this.FreeReflectionImages();
                }
                this.CalculateImageSize();
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
            }
        }

        private bool imageTextShow = true;
        /// <summary>
        /// 是否显示图片文本
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示图片文本")]
        [Category("杂项(图片)")]
        public bool ImageTextShow
        {
            get { return this.imageTextShow; }
            set
            {
                if (this.imageTextShow == value)
                    return;

                this.imageTextShow = value;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText)
                {
                    this.UpdateFisheyeMenuLayerRectangle();
                    this.InvalidateLayer();
                    this.UpdateFisheyeMenuHandleMask();
                }
            }
        }

        #endregion

        #region 文本字符

        private Font textCharFont = new Font("宋体", 20);
        /// <summary>
        /// 文本字符字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 20pt")]
        [Description("文本字符字体")]
        [Category("杂项(选项)")]
        public Font TextCharFont
        {
            get { return this.textCharFont; }
            set
            {
                if (this.textCharFont == value)
                    return;

                this.textCharFont = value;
                this.CalculateCharSize();
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
                this.UpdateFisheyeMenuHandleMask();
            }
        }

        private Color textCharNormalColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 文本字符颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("文本字符颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [Category("杂项(选项)")]
        public Color TextCharNormalColor
        {
            get { return this.textCharNormalColor; }
            set
            {
                if (this.textCharNormalColor == value)
                    return;

                this.textCharNormalColor = value;
                this.InvalidateLayer();
            }
        }

        private Color textCharActivateColor = Color.OliveDrab;
        /// <summary>
        /// 文本字符颜色（激活）
        /// </summary>
        [DefaultValue(typeof(Color), "OliveDrab")]
        [Description("文本字符颜色（激活）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [Category("杂项(选项)")]
        public Color TextCharActivateColor
        {
            get { return this.textCharActivateColor; }
            set
            {
                if (this.textCharActivateColor == value)
                    return;

                this.textCharActivateColor = value;
                this.InvalidateLayer();
            }
        }

        private Color textCharDisableColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 文本字符颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("文本字符颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [Category("杂项(选项)")]
        public Color TextCharDisableColor
        {
            get { return this.textCharDisableColor; }
            set
            {
                if (this.textCharDisableColor == value)
                    return;

                this.textCharDisableColor = value;
                this.InvalidateLayer();
            }
        }

        #endregion

        #region 字符

        private int charTlasticity = 100;
        /// <summary>
        /// 字符弹性系数(字符震动幅度)
        /// </summary>
        [DefaultValue(100)]
        [Description("字符弹性系数(字符震动幅度)")]
        [Category("杂项(字符)")]
        public int CharTlasticity
        {
            get { return this.charTlasticity; }
            set
            {
                if (this.charTlasticity == value)
                    return;

                this.charTlasticity = value;
                this.UpdateFisheyeMenuLayerRectangle();
                this.InvalidateLayer();
                this.UpdateFisheyeMenuHandleMask();
            }
        }

        private int charSakeNumber = 2;
        /// <summary>
        /// 字符震动时受影响选项数量
        /// </summary>
        [DefaultValue(2)]
        [Description("字符震动时受影响选项数量")]
        [Category("杂项(字符)")]
        public int CharSakeNumber
        {
            get { return this.charSakeNumber; }
            set
            {
                if (this.charSakeNumber == value)
                    return;

                this.charSakeNumber = value;
            }
        }

        #endregion

        #region 快捷键

        private bool shortcutKeyShow = true;
        /// <summary>
        /// 是否快捷键打开鱼眼菜单
        /// </summary>
        [DefaultValue(true)]
        [Description("是否快捷键打开鱼眼菜单")]
        public bool ShortcutKeyShow
        {
            get { return this.shortcutKeyShow; }
            set
            {
                if (this.shortcutKeyShow == value)
                    return;

                this.shortcutKeyShow = value;

                if (this.shortcutKeyShow)
                {
                    if (this.Enabled)
                    {
                        this.CreateFisheyeMenuKeyHook();
                        this.fbkh.HookStart();
                    }
                }
                else
                {
                    this.fbkh.HookStop();
                }
            }
        }

        private bool shortcutKeyForm = true;
        /// <summary>
        /// 快捷键是否在鱼眼菜单所属窗体在激活状态下才有效
        /// </summary>
        [DefaultValue(true)]
        [Description("快捷键是否在鱼眼菜单所属窗体在激活状态下才有效")]
        public bool ShortcutKeyForm
        {
            get { return this.shortcutKeyForm; }
            set
            {
                if (this.shortcutKeyForm == value)
                    return;

                this.shortcutKeyForm = value;
            }
        }

        /// <summary>
        /// 弹出鱼眼菜单键盘快捷键
        /// </summary>
        [DefaultValue(Keys.Control | Keys.Q)]
        [Description("弹出鱼眼菜单键盘快捷键")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Keys ShortcutKey
        {
            get { return this.fbkh.ShortcutKey; }
            set
            {
                if (this.fbkh.ShortcutKey == value)
                    return;

                this.fbkh.ShortcutKey = value;
            }
        }

        #endregion

        #region 测试

        private bool testMaskShow = false;
        /// <summary>
        /// 是否显示测试蒙版层(用于测试)
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示测试蒙版层(用于测试)")]
        [Category("杂项(测试)")]
        public bool TestMaskShow
        {
            get { return this.testMaskShow; }
            set
            {
                if (this.testMaskShow == value)
                    return;

                this.testMaskShow = value;
                this.InvalidateLayer();
            }
        }

        private bool testMaskPenetrate = false;
        /// <summary>
        /// 鼠标是否穿透测试蒙版层(用于测试)
        /// </summary>
        [DefaultValue(false)]
        [Description("鼠标是否穿透测试蒙版层(用于测试)")]
        [Category("杂项(测试)")]
        public bool TestMaskPenetrate
        {
            get { return this.testMaskPenetrate; }
            set
            {
                if (this.testMaskPenetrate == value)
                    return;

                this.testMaskPenetrate = value;
                this.InvalidateLayer();
            }
        }

        private Color testMaskBackColor = Color.FromArgb(30, 0, 0, 0);
        /// <summary>
        /// 测试蒙版层背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "30, 0, 0, 0")]
        [Description("测试蒙版层背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [Category("杂项(测试)")]
        public Color TestMaskBackColor
        {
            get { return this.testMaskBackColor; }
            set
            {
                if (this.testMaskBackColor == value)
                    return;

                this.testMaskBackColor = value;
                this.InvalidateLayer();
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

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        private bool activatedStatus = false;

        /// <summary>
        /// 控件激活状态选项索引
        /// </summary>
        private int activatedStatusIndex = -1;

        /// <summary>
        /// 鱼眼菜单弹层
        /// </summary>
        private FisheyeMenuLayer fml = null;
        /// <summary>
        /// 鱼眼菜单弹层rect(控件的Size(指中间选项放大到最大的状态下的Size)、Location)
        /// </summary>
        private Rectangle fbl_control_rect = Rectangle.Empty;
        /// <summary>
        /// 鱼眼菜单弹层items选项蒙版rect(选未进行任何放大情况)
        /// </summary>
        private RectangleF fbl_items_mask_rect = RectangleF.Empty;

        /// <summary>
        /// 鱼眼菜单句柄蒙版层
        /// </summary>
        private FisheyeMenuHandleMask fbhm = null;
        /// <summary>
        /// 鱼眼菜单句柄蒙版层rect
        /// </summary>
        private Rectangle fbhm_mask_rect = Rectangle.Empty;

        /// <summary>
        /// 鼠标钩子
        /// </summary>
        private FisheyeMenuMouseHook fbmh = null;
        /// <summary>
        /// 全局键盘钩子
        /// </summary>
        private FisheyeMenuKeyHook fbkh = null;

        /// <summary>
        /// 语言菜单计时器
        /// </summary>
        private FisheyeMenuTimer timer_obj = null;

        /// <summary>
        /// 倒影高度(图片指定百分比)
        /// </summary>
        private float reflectionHeight = 0.3f;
        /// <summary>
        /// 图片Size
        /// </summary>
        private SizeF image_size = SizeF.Empty;

        /// <summary>
        /// 文本字符格式
        /// </summary>
        private StringFormat text_sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far, Trimming = StringTrimming.EllipsisCharacter };
        /// <summary>
        /// 字符Size
        /// </summary>
        private SizeF char_size = SizeF.Empty;

        #endregion

        #region 扩展

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        #endregion

        public FisheyeMenuHandleExt(IContainer container)
        {
            this.CreateFisheyeMenuLayer();
            this.CalculateCharSize();
            this.CalculateImageSize();
            this.CreateFisheyeMenuHandleMask();
            this.CreateFisheyeMenuTimer();

            this.UpdateFisheyeMenuLayerRectangle();
            this.UpdateFisheyeMenuHandleMask();

            this.CreateFisheyeMenuMouseHook();
            this.CreateFisheyeMenuKeyHook();
            if (this.Enabled && !this.DesignMode)
            {
                this.fbmh.HookStart(this.ISScreenControl() ? FisheyeMenuMouseHookTypes.Global : FisheyeMenuMouseHookTypes.Module);

                if (this.ShortcutKeyShow)
                {
                    this.fbkh.HookStart();
                }
            }

            if (container == null)
                throw new ArgumentNullException("container");
            container.Add(this);
        }

        #region 重写

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.FisheyeMenuExtLayerRemoveEvent();

                if (this.ImageAutoFree)
                {
                    this.FreeReflectionImages();
                }
                if (this.text_sf != null)
                {
                    this.text_sf.Dispose();
                }
                if (this.fbmh != null)
                {
                    this.fbmh.HookStop();
                }
                if (this.fbkh != null)
                {
                    this.fbkh.HookStop();
                }
                if (this.timer_obj != null && this.timer_obj.timer != null)
                {
                    this.timer_obj.timer.Dispose();
                }
                if (this.fbhm != null)
                {
                    this.fbhm.Dispose();
                }
                if (this.fml != null)
                {
                    this.fml.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnIndexChanged(IndexChangedEventArgs e)
        {
            if (this.indexChanged != null)
            {
                this.indexChanged(this, e);
            }
        }

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.itemClick != null)
            {
                this.itemClick(this, e);
            }
        }

        protected virtual void OnSelected(SelectedEventArgs e)
        {
            if (this.selected != null)
            {
                this.selected(this, e);
            }
        }

        /// <summary>
        /// 鱼眼菜单选项选中索引更改方法
        /// </summary>
        /// <param name="index"></param>
        protected virtual void FisheyeMenuIndexChanged(int index)
        {
            if (index > 0 && index < this.Items.Count)
            {
                this.OnIndexChanged(new IndexChangedEventArgs() { Item = this.Items[index] });
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 使分层控件的整个图面无效并导致重绘控件
        /// </summary>
        /// <param name="isReaetReflectionImages">是否刷新所有倒影图片</param>
        public void InvalidateLayer(bool isReaetReflectionImages = false)
        {
            if (isReaetReflectionImages)
            {
                if (this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.UpdateReflectionImage();
                }
                this.UpdateFisheyeMenuLayerRectangle();
                this.fml.InvalidateLayer();
            }
            else
            {
                this.fml.InvalidateLayer();
            }
        }

        /// <summary>
        /// 变换图片更新倒影图片
        /// </summary>
        public void UpdateReflectionImage()
        {
            Image oldImage = null;
            for (int i = 0; i < this.Items.Count; i++)
            {
                oldImage = this.Items[i].ReflectionImage;
                if (this.Items[i].Image == null)
                {
                    this.Items[i].ReflectionImage = null;
                }
                else
                {
                    this.UpdateReflectionImage(this.Items[i]);
                }
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
        }

        /// <summary>
        /// 变换图片更新倒影图片
        /// </summary>
        /// <param name="item"></param>
        public void UpdateReflectionImage(FisheyeMenuItem item)
        {
            if (item.Image != null)
            {
                item.ReflectionImage = ControlCommom.TransformReflection((Bitmap)item.Image, 0, 0, 150, 0, (int)(item.Image.Height * this.reflectionHeight));
            }
        }

        #endregion

        #region 私有方法

        #region

        #region 配件

        /// <summary>
        /// 创建鱼眼菜单句柄蒙版层
        /// </summary>
        private void CreateFisheyeMenuHandleMask()
        {
            if (this.fbhm == null)
            {
                this.fbhm = new FisheyeMenuHandleMask(this);
            }
        }

        /// <summary>
        /// 创建鱼眼菜单弹层
        /// </summary>
        private void CreateFisheyeMenuLayer()
        {
            if (this.fml == null)
            {
                this.fml = new FisheyeMenuLayer(this);
            }
        }

        /// <summary>
        /// 创建显示隐藏鱼眼菜单弹层定时器
        /// </summary>
        private void CreateFisheyeMenuTimer()
        {
            if (this.timer_obj == null)
            {
                this.timer_obj = new FisheyeMenuTimer(this.FisheyeMenuExtLayerTimer_Tick);
            }
        }

        /// <summary>
        /// 创建鼠标钩子
        /// </summary>
        private void CreateFisheyeMenuMouseHook()
        {
            if (this.ShowWay == FisheyeMenuShowWays.Auto && this.fbmh == null)
            {
                this.fbmh = new FisheyeMenuMouseHook();
                this.fbmh.MouseMove += new MouseEventHandler(this.GlobalModule_MouseMove);
            }
        }

        #endregion

        #region 全局事件

        /// <summary>
        /// 创建全局键盘钩子
        /// </summary>
        private void CreateFisheyeMenuKeyHook()
        {
            if (this.ShowWay == FisheyeMenuShowWays.Auto && this.fbkh == null)
            {
                this.fbkh = new FisheyeMenuKeyHook();
                this.fbkh.KeyDown += new KeyEventHandler(this.Global_KeyDown);
            }
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalModule_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ShowWay == FisheyeMenuShowWays.Always)
                return;

            if (this.fbhm_mask_rect.Contains(Control.MousePosition))
            {
                this.StartShowTimer();
            }
            else
            {
                this.StartHideTimer();
            }
        }

        /// <summary>
        /// 键盘全局事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Global_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ShowWay == FisheyeMenuShowWays.Always)
                return;

            IntPtr activeHandle = GetActiveWindow();
            #region 隐藏鱼眼菜单
            if (this.fml.Visible)
            {
                #region 屏幕
                if (this.ISScreenControl())
                {
                    this.HideFisheyeMenuLayer();
                }
                #endregion
                #region 窗体
                else
                {
                    if (!this.ShortcutKeyForm || (this.ShortcutKeyForm && (this.OwnerForm.Handle == activeHandle || this.fml.Handle == activeHandle)))
                    {
                        this.HideFisheyeMenuLayer();
                        this.ShowFisheyeMenuHandleMask();
                    }
                }
                #endregion
            }
            #endregion
            #region 显示鱼眼菜单
            else
            {
                #region 屏幕
                if (this.ISScreenControl())
                {
                    this.ShowFisheyeMenuLayer();
                }
                #endregion
                #region 窗体
                else
                {
                    if (!this.ShortcutKeyForm || (this.ShortcutKeyForm && (this.OwnerForm.Handle == activeHandle || this.fml.Handle == activeHandle)))
                    {
                        this.ShowFisheyeMenuLayer();
                        this.HideFisheyeMenuHandleMask();
                    }
                }
                #endregion
            }
            #endregion
        }

        #endregion

        #region 选项缩放比例

        /// <summary>
        ///重置所有鱼眼菜单选项默认缩放比例
        /// </summary>
        private void SetFisheyeMenuItemDefaultProportion()
        {
            foreach (FisheyeMenuItem item in this.Items)
            {
                this.SetFisheyeMenuItemDefaultProportion(item);
            }
        }

        /// <summary>
        ///重置指定鱼眼菜单选项默认缩放比例
        /// </summary>
        /// <param name="item"></param>
        private void SetFisheyeMenuItemDefaultProportion(FisheyeMenuItem item)
        {
            item.now_proportion = this.ShowType == FisheyeMenuShowTypes.ImageText ? this.ImageProportion : 0;
        }

        /// <summary>
        /// 根据鼠标坐标更新所有选项的对应缩放比例
        /// </summary>
        /// <param name="point">鼠标坐标</param>
        private void UpdateFisheyeMenuItemZoomProportion(PointF point)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].now_proportion = this.GetFisheyeMenuItemProportion(this.Items[i].now_rectf_centerpoint, point);
            }
        }

        /// <summary>
        /// 根据鼠标坐标获取选项的对应缩放比例
        /// </summary>
        /// <param name="itemCenterPoint">选项</param>
        /// <param name="point">鼠标坐标</param>
        /// <returns></returns>
        private float GetFisheyeMenuItemProportion(PointF itemCenterPoint, PointF mousePoint)
        {
            float item_distance = 0f;
            float distance = 0f;
            float p = 0f;
            distance = (float)Math.Sqrt(Math.Pow(Math.Abs(itemCenterPoint.X - mousePoint.X), 2) + Math.Pow(Math.Abs(itemCenterPoint.Y - mousePoint.Y), 2));//鼠标焦点和选项圆心的距离 
            #region
            if (this.ShowType == FisheyeMenuShowTypes.ImageText)
            {
                item_distance = (float)Math.Sqrt(Math.Pow(this.ImageWidth + (this.ISHorizontal() ? this.ItemDistance : 0), 2) + Math.Pow(this.ImageHeight + (this.ISVertical() ? this.ItemDistance : 0), 2));
                p = 1 - (item_distance == 0 ? 0 : this.ImageProportion * (distance / item_distance));
                if (p < this.ImageProportion)
                {
                    p = this.ImageProportion;
                }
            }
            #endregion
            #region
            else
            {
                item_distance = (float)Math.Sqrt(Math.Pow(this.char_size.Width * (this.ISHorizontal() ? this.CharSakeNumber : 1), 2) + Math.Pow(this.char_size.Height * (this.ISVertical() ? this.CharSakeNumber : 1), 2));
                p = 1 - (item_distance == 0 ? 0 : (distance / item_distance));
                if (p < 0)
                {
                    p = 0;
                }
            }
            #endregion

            return p;
        }

        #endregion

        /// <summary>
        /// 显示隐藏鱼眼菜单弹层定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FisheyeMenuExtLayerTimer_Tick(object sender, EventArgs e)
        {
            #region 隐藏计时器
            if (this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.HideTimer)
            {
                this.timer_obj.timer_total += this.timer_obj.timer.Interval;
                if (this.timer_obj.timer_total >= this.LayeredHideTime)
                {
                    this.HideFisheyeMenuLayer();
                    this.timer_obj.timer.Enabled = false;
                    this.timer_obj.timer_total = 0;
                    this.timer_obj.timer_type = FisheyeMenuTimer.FisheyeMenuTimerTypes.Hideed;

                    this.ShowFisheyeMenuHandleMask();
                }
            }
            #endregion
            #region 显示计时器
            else
            {
                this.timer_obj.timer_total += this.timer_obj.timer.Interval;
                if (this.timer_obj.timer_total >= this.LayeredShowTime)
                {
                    this.ShowFisheyeMenuLayer();
                    this.timer_obj.timer.Enabled = false;
                    this.timer_obj.timer_total = 0;
                    this.timer_obj.timer_type = FisheyeMenuTimer.FisheyeMenuTimerTypes.Showed;

                    this.HideFisheyeMenuHandleMask();
                }
            }
            #endregion
        }

        /// <summary>
        ///  选项是否横向排列
        /// </summary>
        /// <returns></returns>
        private bool ISHorizontal()
        {
            return (this.showOrientation == FisheyeMenuShowOrientation.Top || this.showOrientation == FisheyeMenuShowOrientation.Bottom);
        }

        /// <summary>
        /// 选项是否纵向排列
        /// </summary>
        /// <returns></returns>
        private bool ISVertical()
        {
            return (this.showOrientation == FisheyeMenuShowOrientation.Left || this.showOrientation == FisheyeMenuShowOrientation.Right);
        }

        /// <summary>
        /// 是否为屏幕菜单控件
        /// </summary>
        /// <returns></returns>
        private bool ISScreenControl()
        {
            return this.OwnerForm == null ? true : false;
        }

        #endregion

        #region 鱼眼菜单弹层

        /// <summary>
        /// 显示鱼眼菜单弹层
        /// </summary>
        private void ShowFisheyeMenuLayer()
        {
            if (!this.Enabled || this.DesignMode || this.fml.Visible)
                return;

            this.fbmh.HookStop();//显示后停止鼠标钩子只有在鼠标离开鱼眼菜单弹层或键盘隐藏后才重启鼠标钩子
            this.fml.TopMost = this.ISScreenControl() ? true : false;
            this.fml.Owner = this.ISScreenControl() ? null : this.OwnerForm;
            this.fml.Show();

            this.FisheyeMenuExtLayerAddEvent();
            this.UpdateFisheyeMenuLayerRectangle();
            this.InvalidateLayer();
        }

        /// <summary>
        /// 隐藏鱼眼菜单弹层
        /// </summary>
        private void HideFisheyeMenuLayer()
        {
            if (this.DesignMode || !this.fml.Visible)
                return;

            this.FisheyeMenuExtLayerRemoveEvent();
            this.fml.Hide();

            if (!this.DesignMode)
            {
                this.fbmh.HookStart(this.ISScreenControl() ? FisheyeMenuMouseHookTypes.Global : FisheyeMenuMouseHookTypes.Module);
            }
        }

        /// <summary>
        /// 更新鱼眼菜单弹层rect
        /// </summary>
        private void UpdateFisheyeMenuLayerRectangle()
        {
            if (this.Items.Count < 1)
                return;

            //ImageText:文本在rect外上面
            //     Char:文本在rect内上面
            #region 初始化所有选项
            if (this.ISHorizontal())
            {
                SizeF rectf_size = this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size : new SizeF(this.char_size.Width, this.char_size.Height + this.CushionThickness);
                float start_x = 0;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].rectf = new RectangleF(start_x, 0, rectf_size.Width, rectf_size.Height);
                    start_x += this.Items[i].rectf.Width + ((i < this.Items.Count - 1) ? this.ItemDistance : 0);
                }
            }
            else
            {
                SizeF rectf_size = this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size : new SizeF(this.char_size.Width + this.CushionThickness, this.char_size.Height);
                float start_y = 0;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].rectf = new RectangleF(0, start_y, rectf_size.Width, rectf_size.Height);
                    start_y += this.Items[i].rectf.Height + ((i < this.Items.Count - 1) ? this.ItemDistance : 0);
                }
            }
            #endregion

            #region 计算选项缩放过程中最大总长度
            //无法精确计算最大长度，这是额外估计补加
            float uncertain = (this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size.Width : this.char_size.Width) * 0.15f;
            if (this.ISVertical())
            {
                uncertain = (this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size.Height : this.char_size.Height) * 0.15f;
            }
            float max = 0f;
            int center_item_index = this.Items.Count == 1 ? 0 : (this.Items.Count / 2 - 1 + this.Items.Count % 2);
            for (int i = 0; i < this.Items.Count; i++)
            {
                float p = this.GetFisheyeMenuItemProportion(this.Items[i].rectf_centerpoint, this.Items[center_item_index].rectf_centerpoint);
                float item_now_width = this.ShowType == FisheyeMenuShowTypes.ImageText ? (this.Items[i].rectf.Width * p) : (this.Items[i].rectf.Width + (this.ISHorizontal() ? 0 : this.CharTlasticity * p));
                float item_now_height = this.ShowType == FisheyeMenuShowTypes.ImageText ? (this.Items[i].rectf.Height * p) : (this.Items[i].rectf.Height + (this.ISVertical() ? 0 : this.CharTlasticity * p));
                max += (this.ISHorizontal() ? item_now_width : item_now_height) + ((i < this.Items.Count - 1) ? this.ItemDistance : 0);
            }
            max += this.ItemMaskPadding * 2 + uncertain;
            #endregion

            #region 鱼眼菜单弹层rect(控件的Size(指中间选项放大到最大的状态下的Size)、Location)
            Rectangle parent_rect = System.Windows.Forms.Screen.GetWorkingArea(this.fml);
            if (!this.ISScreenControl())
            {
                parent_rect = new Rectangle(this.OwnerForm.PointToScreen(this.OwnerForm.ClientRectangle.Location), this.OwnerForm.ClientSize);
            }
            switch (this.ShowOrientation)
            {
                case FisheyeMenuShowOrientation.Bottom:
                    {
                        float w = max;
                        float h = this.cushionThickness + (this.ShowType == FisheyeMenuShowTypes.ImageText ? (this.image_size.Height + (this.ImageTextShow ? this.char_size.Height : 0)) : (this.char_size.Height + this.charTlasticity));
                        float x = parent_rect.X + (parent_rect.Width - w) / 2;
                        float y = parent_rect.Bottom - h;

                        this.fbl_control_rect = new Rectangle((int)x, (int)y, (int)w, (int)h);
                        break;
                    }
                case FisheyeMenuShowOrientation.Top:
                    {
                        float w = max;
                        float h = this.cushionThickness + (this.ShowType == FisheyeMenuShowTypes.ImageText ? (this.image_size.Height + (this.ImageTextShow ? this.char_size.Height : 0)) : (this.char_size.Height + this.charTlasticity));
                        float x = parent_rect.X + (parent_rect.Width - w) / 2;
                        float y = parent_rect.Top;

                        this.fbl_control_rect = new Rectangle((int)x, (int)y, (int)w, (int)h);
                        break;
                    }

                case FisheyeMenuShowOrientation.Left:
                    {
                        float w = this.cushionThickness + (this.ShowType == FisheyeMenuShowTypes.ImageText ? (this.image_size.Width + (this.ImageTextShow ? this.char_size.Width : 0)) : (this.char_size.Width + this.charTlasticity));
                        float h = max;
                        float x = parent_rect.Left;
                        float y = parent_rect.Y + (parent_rect.Height - h) / 2;

                        this.fbl_control_rect = new Rectangle((int)x, (int)y, (int)w, (int)h);
                        break;
                    }
                case FisheyeMenuShowOrientation.Right:
                    {
                        float w = this.cushionThickness + (this.ShowType == FisheyeMenuShowTypes.ImageText ? (this.image_size.Width + (this.ImageTextShow ? this.char_size.Width : 0)) : (this.char_size.Width + this.charTlasticity));
                        float h = max;
                        float x = parent_rect.Right - w;
                        float y = parent_rect.Y + (parent_rect.Height - h) / 2;

                        this.fbl_control_rect = new Rectangle((int)x, (int)y, (int)w, (int)h);
                        break;
                    }
            }
            #endregion

            this.fml.SetBounds(this.fbl_control_rect.Location.X, this.fbl_control_rect.Location.Y, this.fbl_control_rect.Size.Width, this.fbl_control_rect.Size.Height, BoundsSpecified.All);

            #region 设置所有选项缩放到默认比例后Location
            float min = 0f;
            for (int i = 0; i < this.Items.Count; i++)
            {
                min += (this.ISHorizontal() ? this.Items[i].rectf.Width : this.Items[i].rectf.Height) + ((i < this.Items.Count - 1) ? this.ItemDistance : 0);
            }
            for (int i = 0; i < this.Items.Count; i++)
            {
                float x = 0;
                float y = 0;
                switch (this.ShowOrientation)
                {
                    case FisheyeMenuShowOrientation.Bottom:
                        {
                            x = (i == 0) ? (this.fml.ClientRectangle.Width - min) / 2 : this.Items[i - 1].now_rectf.Right + this.ItemDistance;
                            y = this.fml.ClientRectangle.Bottom - this.Items[i].now_rectf.Height;
                            break;
                        }
                    case FisheyeMenuShowOrientation.Top:
                        {
                            x = (i == 0) ? (this.fml.ClientRectangle.Width - min) / 2 : this.Items[i - 1].now_rectf.Right + this.ItemDistance;
                            y = this.fml.ClientRectangle.Y;
                            break;
                        }
                    case FisheyeMenuShowOrientation.Left:
                        {
                            x = this.fml.ClientRectangle.X;
                            y = (i == 0) ? (this.fml.ClientRectangle.Height - min) / 2 : this.Items[i - 1].now_rectf.Bottom + this.ItemDistance;
                            break;
                        }
                    case FisheyeMenuShowOrientation.Right:
                        {
                            x = this.fml.ClientRectangle.Right - this.Items[i].now_rectf.Width;
                            y = (i == 0) ? (this.fml.ClientRectangle.Height - min) / 2 : this.Items[i - 1].now_rectf.Bottom + this.ItemDistance;
                            break;
                        }
                }
                this.Items[i].now_rectf = new RectangleF(x, y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height);
            }
            #endregion

            this.UpdateFisheyeMenuLayerItemsRectangle();
        }

        /// <summary>
        /// 更新鱼眼菜单弹层所有选项rect
        /// </summary>
        private void UpdateFisheyeMenuLayerItemsRectangle()
        {
            if (this.Items.Count < 1)
                return;

            #region s设置选项当前选项Size、计算当前选项总长度
            float now = 0f;
            for (int i = 0; i < this.Items.Count; i++)
            {
                float item_now_width = 0f;
                float item_now_height = 0f;
                if (this.ShowType == FisheyeMenuShowTypes.ImageText)
                {
                    item_now_width = (this.Items[i].rectf.Width * this.Items[i].now_proportion);
                    item_now_height = (this.Items[i].rectf.Height * this.Items[i].now_proportion);
                }
                else
                {
                    item_now_width = (this.char_size.Width + (this.ISHorizontal() ? 0 :this.CushionThickness+ this.CharTlasticity * this.Items[i].now_proportion));
                    item_now_height = (this.char_size.Height + (this.ISVertical() ? 0 : this.CushionThickness + this.CharTlasticity * this.Items[i].now_proportion));
                }

                this.Items[i].now_rectf = new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y, item_now_width, item_now_height);
                now += (this.ISHorizontal() ? item_now_width : item_now_height) + ((i < this.Items.Count - 1) ? this.ItemDistance : 0);
            }
            now += this.ItemMaskPadding * 2;
            #endregion

            #region 鱼眼菜单弹层rect(控件的Size(指中间选项放大到最大的状态下的Size)、Location)
            switch (this.ShowOrientation)
            {
                case FisheyeMenuShowOrientation.Bottom:
                    {
                        float w = now;
                        float h = this.cushionThickness + ((this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size.Height * this.ImageProportion : 0) + (((this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageTextShow) || this.ShowType == FisheyeMenuShowTypes.Char) ? this.char_size.Height : 0));
                        float x = this.fml.ClientRectangle.X + (this.fml.ClientRectangle.Width - w) / 2;
                        float y = this.fml.ClientRectangle.Bottom - h;

                        this.fbl_items_mask_rect = new RectangleF(x, y, w, h);
                        break;
                    }
                case FisheyeMenuShowOrientation.Top:
                    {
                        float w = now;
                        float h = this.cushionThickness + ((this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size.Height * this.ImageProportion : 0) + (((this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageTextShow) || this.ShowType == FisheyeMenuShowTypes.Char) ? this.char_size.Height : 0));
                        float x = this.fml.ClientRectangle.X + (this.fml.ClientRectangle.Width - w) / 2;
                        float y = this.fml.ClientRectangle.Top;

                        this.fbl_items_mask_rect = new RectangleF(x, y, w, h);
                        break;
                    }

                case FisheyeMenuShowOrientation.Left:
                    {
                        float w = this.cushionThickness + ((this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size.Width * this.ImageProportion : 0) + (((this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageTextShow) || this.ShowType == FisheyeMenuShowTypes.Char) ? this.char_size.Width : 0));
                        float h = now;
                        float x = this.fml.ClientRectangle.X;
                        float y = this.fml.ClientRectangle.Y + (this.fml.ClientRectangle.Height - h) / 2;

                        this.fbl_items_mask_rect = new RectangleF(x, y, w, h);
                        break;
                    }
                case FisheyeMenuShowOrientation.Right:
                    {
                        float w = this.cushionThickness + ((this.ShowType == FisheyeMenuShowTypes.ImageText ? this.image_size.Width * this.ImageProportion : 0) + (((this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageTextShow) || this.ShowType == FisheyeMenuShowTypes.Char) ? this.char_size.Width : 0));
                        float h = now;
                        float x = this.fml.ClientRectangle.Right - w;
                        float y = this.fml.ClientRectangle.Y + (this.fml.ClientRectangle.Height - h) / 2;

                        this.fbl_items_mask_rect = new RectangleF(x, y, w, h);
                        break;
                    }
            }
            #endregion

            #region  计算选项当前选项Location
            for (int i = 0; i < this.Items.Count; i++)
            {
                float x = 0;
                float y = 0;
                switch (this.ShowOrientation)
                {
                    case FisheyeMenuShowOrientation.Bottom:
                        {
                            x = (i == 0) ? (this.fml.ClientRectangle.Width - now) / 2 + this.ItemMaskPadding : this.Items[i - 1].now_rectf.Right + this.ItemDistance;
                            y = this.fml.ClientRectangle.Bottom - this.Items[i].now_rectf.Height;
                            break;
                        }
                    case FisheyeMenuShowOrientation.Top:
                        {
                            x = (i == 0) ? (this.fml.ClientRectangle.Width - now) / 2 + this.ItemMaskPadding : this.Items[i - 1].now_rectf.Right + this.ItemDistance;
                            y = this.fml.ClientRectangle.Top;
                            break;
                        }
                    case FisheyeMenuShowOrientation.Left:
                        {
                            x = this.fml.ClientRectangle.X;
                            y = (i == 0) ? (this.fml.ClientRectangle.Height - now) / 2 + this.ItemMaskPadding : this.Items[i - 1].now_rectf.Bottom + this.ItemDistance;
                            break;
                        }
                    case FisheyeMenuShowOrientation.Right:
                        {
                            x = this.fml.ClientRectangle.Right - this.Items[i].now_rectf.Width;
                            y = (i == 0) ? (this.fml.ClientRectangle.Height - now) / 2 + this.ItemMaskPadding : this.Items[i - 1].now_rectf.Bottom + this.ItemDistance;
                            break;
                        }
                }
                this.Items[i].now_rectf = new RectangleF(x, y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height);
            }
            #endregion
        }

        /// <summary>
        /// 更新鱼眼菜单弹层所属窗体添加事件
        /// </summary>
        private void FisheyeMenuExtLayerAddEvent()
        {
            if (!this.ISScreenControl() && this.OwnerForm != null)
            {
                this.OwnerForm.SizeChanged += new EventHandler(this.FisheyeMenuExtLayer_LocationSizeChanged);
                this.OwnerForm.LocationChanged += new EventHandler(this.FisheyeMenuExtLayer_LocationSizeChanged);
            }
        }

        /// <summary>
        /// 更新鱼眼菜单弹层所属窗体移除事件
        /// </summary>
        private void FisheyeMenuExtLayerRemoveEvent()
        {
            if (!this.ISScreenControl() && this.OwnerForm != null)
            {
                this.OwnerForm.SizeChanged -= new EventHandler(this.FisheyeMenuExtLayer_LocationSizeChanged);
                this.OwnerForm.LocationChanged -= new EventHandler(this.FisheyeMenuExtLayer_LocationSizeChanged);
            }
        }

        /// <summary>
        /// 鱼眼菜单弹层Location、Size更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FisheyeMenuExtLayer_LocationSizeChanged(object sender, EventArgs e)
        {
            Rectangle parent_rect = System.Windows.Forms.Screen.GetWorkingArea(this.fml);
            if (!this.ISScreenControl())
            {
                parent_rect = new Rectangle(this.OwnerForm.PointToScreen(this.OwnerForm.ClientRectangle.Location), this.OwnerForm.ClientSize);
            }

            switch (this.ShowOrientation)
            {
                case FisheyeMenuShowOrientation.Bottom:
                    {
                        this.fml.Location = new Point(parent_rect.X + (parent_rect.Width - this.fml.Width) / 2, parent_rect.Bottom - this.fml.Height);
                        break;
                    }
                case FisheyeMenuShowOrientation.Top:
                    {
                        this.fml.Location = new Point(parent_rect.X + (parent_rect.Width - this.fml.Width) / 2, parent_rect.Top);
                        break;
                    }
                case FisheyeMenuShowOrientation.Left:
                    {
                        this.fml.Location = new Point(parent_rect.Left, parent_rect.Y + (parent_rect.Height - this.fml.Height) / 2);
                        break;
                    }
                case FisheyeMenuShowOrientation.Right:
                    {
                        this.fml.Location = new Point(parent_rect.Right - this.fml.Width, parent_rect.Y + (parent_rect.Height - this.fml.Height) / 2);
                        break;
                    }
            }

        }

        /// <summary>
        /// 启动显示计时器
        /// </summary>
        private void StartShowTimer()
        {
            if (this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.None || this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.HideTimer || this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.Hideed)
            {
                this.timer_obj.timer_type = FisheyeMenuTimer.FisheyeMenuTimerTypes.ShowTimer;
                this.timer_obj.timer_total = 0;
                this.timer_obj.timer.Enabled = true;
            }
        }

        /// <summary>
        /// 启动隐藏计时器
        /// </summary>
        private void StartHideTimer()
        {
            if (this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.None || this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.ShowTimer || this.timer_obj.timer_type == FisheyeMenuTimer.FisheyeMenuTimerTypes.Showed)
            {
                this.timer_obj.timer_type = FisheyeMenuTimer.FisheyeMenuTimerTypes.HideTimer;
                this.timer_obj.timer_total = 0;
                this.timer_obj.timer.Enabled = true;
            }
        }

        #endregion

        #region 鱼眼菜单句柄蒙版层

        /// <summary>
        /// 显示鱼眼菜单句柄蒙版层
        /// </summary>
        private void ShowFisheyeMenuHandleMask()
        {
            if (!this.Enabled || this.DesignMode || this.fbhm.Visible || !this.HandleMaskShow || this.ShowWay == FisheyeMenuShowWays.Always)
                return;

            this.fbhm.TopMost = this.ISScreenControl() ? true : false;
            this.fbhm.Owner = this.ISScreenControl() ? null : this.OwnerForm;
            this.fbhm.Show();

            this.FisheyeMenuHandleMaskAddEvent();
            this.UpdateFisheyeMenuHandleMask();
        }

        /// <summary>
        /// 隐藏鱼眼菜单句柄蒙版层
        /// </summary>
        private void HideFisheyeMenuHandleMask()
        {
            if (this.DesignMode || !this.fbhm.Visible)
                return;

            this.FisheyeMenuHandleMaskRemoveEvent();
            this.fbhm.Hide();
        }

        /// <summary>
        /// 更新鱼眼菜单句柄蒙版层
        /// </summary>
        private void UpdateFisheyeMenuHandleMask()
        {
            this.UpdateFisheyeMenuHandleMaskRectangle();

            if (this.fbhm != null)
            {
                this.fbhm.SetBounds(this.fbhm_mask_rect.X, this.fbhm_mask_rect.Y, this.fbhm_mask_rect.Width, this.fbhm_mask_rect.Height, BoundsSpecified.All);
            }
        }

        /// <summary>
        /// 更新鱼眼菜单句柄蒙版层rect
        /// </summary>
        private void UpdateFisheyeMenuHandleMaskRectangle()
        {
            if (this.ShowWay == FisheyeMenuShowWays.Always)
                return;

            #region  屏幕
            if (this.ISScreenControl())
            {
                Rectangle screen_rect = System.Windows.Forms.Screen.GetWorkingArea(this.fml);
                switch (this.ShowOrientation)
                {
                    case FisheyeMenuShowOrientation.Bottom:
                        {
                            this.fbhm_mask_rect = new Rectangle(Math.Max(this.fbl_control_rect.X, screen_rect.X), this.fbl_control_rect.Bottom - this.HandleMaskHeight, Math.Min(this.fbl_control_rect.Right, screen_rect.Right), this.HandleMaskHeight);
                            break;
                        }
                    case FisheyeMenuShowOrientation.Top:
                        {
                            this.fbhm_mask_rect = new Rectangle(Math.Max(this.fbl_control_rect.X, screen_rect.X), screen_rect.Y, Math.Min(this.fbl_control_rect.Right, screen_rect.Right), this.HandleMaskHeight);
                            break;
                        }
                    case FisheyeMenuShowOrientation.Left:
                        {
                            this.fbhm_mask_rect = new Rectangle(screen_rect.X, Math.Max(this.fbl_control_rect.Y, screen_rect.Y), this.HandleMaskHeight, Math.Min(this.fbl_control_rect.Bottom, screen_rect.Bottom));
                            break;
                        }
                    case FisheyeMenuShowOrientation.Right:
                        {
                            this.fbhm_mask_rect = new Rectangle(screen_rect.Right - this.HandleMaskHeight, Math.Max(this.fbl_control_rect.Y, screen_rect.Y), this.HandleMaskHeight, Math.Min(this.fbl_control_rect.Bottom, screen_rect.Bottom));
                            break;
                        }
                }
            }
            #endregion
            #region 窗体
            else
            {
                Point lt = this.OwnerForm.PointToScreen(this.OwnerForm.ClientRectangle.Location);
                Point rb = this.OwnerForm.PointToScreen(new Point(this.OwnerForm.ClientRectangle.Right, this.OwnerForm.ClientRectangle.Bottom));
                Rectangle rect = new Rectangle(lt.X, lt.Y, rb.X - lt.X, rb.Y - lt.Y);

                switch (this.ShowOrientation)
                {
                    case FisheyeMenuShowOrientation.Bottom:
                        {
                            int min_width = (this.fml.Width > rect.Width) ? rect.Width : this.fml.Width;
                            this.fbhm_mask_rect = new Rectangle(rect.X + (rect.Width - min_width) / 2, rect.Bottom - this.HandleMaskHeight, min_width, this.HandleMaskHeight);
                            break;
                        }
                    case FisheyeMenuShowOrientation.Top:
                        {
                            int mmin_width = (this.fml.Width > rect.Width) ? rect.Width : this.fml.Width;
                            this.fbhm_mask_rect = new Rectangle(rect.X + (rect.Width - mmin_width) / 2, rect.Y, mmin_width, this.HandleMaskHeight);
                            break;
                        }
                    case FisheyeMenuShowOrientation.Left:
                        {
                            int mmin_min_height = (this.fml.Height > rect.Height) ? rect.Height : this.fml.Height;
                            this.fbhm_mask_rect = new Rectangle(rect.X, rect.Y + (rect.Height - mmin_min_height) / 2, this.HandleMaskHeight, mmin_min_height);
                            break;
                        }
                    case FisheyeMenuShowOrientation.Right:
                        {
                            int mmin_min_height = (this.fml.Height > rect.Height) ? rect.Height : this.fml.Height;
                            this.fbhm_mask_rect = new Rectangle(rect.Right - this.HandleMaskHeight, rect.Y + (rect.Height - mmin_min_height) / 2, this.HandleMaskHeight, mmin_min_height);
                            break;
                        }
                }
            }
            #endregion
        }

        /// <summary>
        /// 鱼眼菜单句柄蒙版层所在窗体添加事件
        /// </summary>
        private void FisheyeMenuHandleMaskAddEvent()
        {
            if (this.OwnerForm != null)
            {
                this.OwnerForm.SizeChanged += new EventHandler(this.FisheyeMenuHandleMask_LocationSizeChanged);
                this.OwnerForm.LocationChanged += new EventHandler(this.FisheyeMenuHandleMask_LocationSizeChanged);
            }
        }

        /// <summary>
        /// 鱼眼菜单句柄蒙版层所在窗体移除事件
        /// </summary>
        private void FisheyeMenuHandleMaskRemoveEvent()
        {
            if (this.OwnerForm != null)
            {
                this.OwnerForm.SizeChanged -= new EventHandler(this.FisheyeMenuHandleMask_LocationSizeChanged);
                this.OwnerForm.LocationChanged -= new EventHandler(this.FisheyeMenuHandleMask_LocationSizeChanged);
            }
        }

        /// <summary>
        /// 鱼眼菜单句柄蒙版Location、Size更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FisheyeMenuHandleMask_LocationSizeChanged(object sender, EventArgs e)
        {
            this.UpdateFisheyeMenuHandleMask();
        }

        #endregion

        #region 图片处理

        /// <summary>
        /// 释放所有倒影图片
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void FreeReflectionImages()
        {
            if (this.Items != null)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].ReflectionImage != null)
                    {
                        this.Items[i].ReflectionImage.Dispose();
                        this.Items[i].ReflectionImage = null;
                    }
                }
            }
        }

        /// <summary>
        /// 释放指定索引倒影图片
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void FreeReflectionImage(int index)
        {
            if (this.Items != null && index >= 0 && index < this.Items.Count)
            {
                if (this.Items[index].ReflectionImage != null)
                {
                    this.Items[index].ReflectionImage.Dispose();
                    this.Items[index].ReflectionImage = null;
                }
            }
        }

        /// <summary>
        /// 计算图片处理后的真实Size(有倒影情况)
        /// </summary>
        private void CalculateImageSize()
        {
            if (this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageReflection && this.ISHorizontal())
            {
                this.image_size = new SizeF(this.ImageWidth, this.ImageHeight + (this.ImageHeight * this.reflectionHeight));
            }
            else
            {
                this.image_size = new SizeF(this.ImageWidth, this.ImageHeight);
            }
        }

        #endregion

        #region 字符

        /// <summary>
        /// 根据字体计算字符Size
        /// </summary>
        /// <returns></returns>
        internal void CalculateCharSize()
        {
            IntPtr hDC = GetWindowDC(this.fml.Handle);
            Graphics g = Graphics.FromHdc(hDC);
            this.char_size = g.MeasureString("字", this.TextCharFont, Size.Empty);
            g.Dispose();
            ReleaseDC(this.fml.Handle, hDC);
        }

        #endregion

        #region 分层

        /// <summary>
        /// 生成分层控件画面图片
        /// </summary>
        private Bitmap CreateLayerImage()
        {
            Bitmap bmp = new Bitmap(this.fml.Width, this.fml.Height);
            Graphics g = Graphics.FromImage(bmp);

            #region 测试用
            if (!this.TestMaskPenetrate && this.TestMaskShow)
            {
                g.Clear(this.TestMaskBackColor);
            }
            #endregion

            #region 选项背景蒙版
            if (this.ItemMaskShow && this.Items.Count > 0)
            {
                SolidBrush back_mask_sb = new SolidBrush(this.ItemMaskBackColor);
                if (this.ItemMaskRadius == 0)
                {
                    g.FillRectangle(back_mask_sb, this.fbl_items_mask_rect);
                }
                else
                {
                    SmoothingMode back_mask_sm = g.SmoothingMode;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    GraphicsPath back_mask_gp = ControlCommom.TransformCircular(this.fbl_items_mask_rect, this.ItemMaskRadius);
                    g.FillPath(back_mask_sb, back_mask_gp);
                    g.SmoothingMode = back_mask_sm;
                    back_mask_gp.Dispose();
                }

                back_mask_sb.Dispose();
            }
            #endregion

            #region 文本画笔
            SolidBrush normal_item_text_sb = null;
            SolidBrush activate_item_text_sb = null;
            SolidBrush disable_item_text_sb = null;
            if (this.ShowType == FisheyeMenuShowTypes.Char || (this.ShowType == FisheyeMenuShowTypes.ImageText && this.ImageTextShow))
            {
                if (this.Enabled)
                {
                    normal_item_text_sb = new SolidBrush(this.TextCharNormalColor);
                    activate_item_text_sb = new SolidBrush(this.TextCharActivateColor);
                }
                else
                {
                    disable_item_text_sb = new SolidBrush(this.TextCharDisableColor);
                }
            }
            #endregion

            #region 图片
            if (this.ShowType == FisheyeMenuShowTypes.ImageText)
            {
                #region 倒影图片
                if (this.ImageReflection && this.ISHorizontal())
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].ReflectionImage != null)
                        {
                            g.DrawImage(this.Items[i].ReflectionImage, new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height));
                        }
                    }
                }
                #endregion
                #region 正常图片
                else
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].Image != null)
                        {
                            g.DrawImage(this.Items[i].Image, new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height));
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 文本
            #region
            if (this.ShowType == FisheyeMenuShowTypes.ImageText)
            {
                if (this.ImageTextShow)
                {
                    TextRenderingHint text_trh = g.TextRenderingHint;
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(this.Items[i].Text))
                        {
                            #region 文本Rectangle
                            RectangleF item_text_rectf = RectangleF.Empty;
                            switch (this.ShowOrientation)
                            {
                                case FisheyeMenuShowOrientation.Bottom:
                                    {
                                        item_text_rectf = new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Top - this.char_size.Height, this.Items[i].now_rectf.Width, this.char_size.Height);
                                        break;
                                    }
                                case FisheyeMenuShowOrientation.Top:
                                    {
                                        item_text_rectf = new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Bottom, this.Items[i].now_rectf.Width, this.char_size.Height);
                                        break;
                                    }
                                case FisheyeMenuShowOrientation.Left:
                                    {
                                        item_text_rectf = new RectangleF(this.Items[i].now_rectf.Right, this.Items[i].now_rectf.Y, this.char_size.Width, this.Items[i].now_rectf.Height);
                                        break;
                                    }
                                case FisheyeMenuShowOrientation.Right:
                                    {
                                        item_text_rectf = new RectangleF(this.Items[i].now_rectf.X - this.char_size.Width, this.Items[i].now_rectf.Y, this.char_size.Width, this.Items[i].now_rectf.Height);
                                        break;
                                    }
                            }
                            #endregion
                            g.DrawString(this.Items[i].Text, this.TextCharFont, (!this.Enabled) ? disable_item_text_sb : ((this.activatedStatusIndex == i) ? activate_item_text_sb : normal_item_text_sb), item_text_rectf, this.text_sf);
                        }
                    }
                    g.TextRenderingHint = text_trh;
                }
            }
            #endregion
            #region
            else if (this.ShowType == FisheyeMenuShowTypes.Char)
            {
                TextRenderingHint text_trh = g.TextRenderingHint;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (!String.IsNullOrWhiteSpace(this.Items[i].Char))
                    {
                        #region 文本Rectangle
                        RectangleF item_text_rectf = RectangleF.Empty;
                        switch (this.ShowOrientation)
                        {
                            case FisheyeMenuShowOrientation.Bottom:
                                {
                                    item_text_rectf = new RectangleF(this.Items[i].now_rectf.X + (this.Items[i].now_rectf.Width - this.char_size.Width) / 2, this.Items[i].now_rectf.Top, this.char_size.Width, this.char_size.Height);
                                    break;
                                }
                            case FisheyeMenuShowOrientation.Top:
                                {
                                    item_text_rectf = new RectangleF(this.Items[i].now_rectf.X + (this.Items[i].now_rectf.Width - this.char_size.Width) / 2, this.Items[i].now_rectf.Bottom - this.char_size.Height, this.char_size.Width, this.char_size.Height);
                                    break;
                                }
                            case FisheyeMenuShowOrientation.Left:
                                {
                                    item_text_rectf = new RectangleF(this.Items[i].now_rectf.Right - this.char_size.Width, this.Items[i].now_rectf.Y + (this.Items[i].now_rectf.Height - this.char_size.Height) / 2, this.char_size.Width, this.char_size.Height);
                                    break;
                                }
                            case FisheyeMenuShowOrientation.Right:
                                {
                                    item_text_rectf = new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y + (this.Items[i].now_rectf.Height - this.char_size.Height) / 2, this.char_size.Width, this.char_size.Height);
                                    break;
                                }
                        }
                        #endregion

                        g.DrawString(this.Items[i].Char, this.TextCharFont, (!this.Enabled) ? disable_item_text_sb : ((this.activatedStatusIndex == i) ? activate_item_text_sb : normal_item_text_sb), item_text_rectf, this.text_sf);
                        //g.DrawRectangle(new Pen(Color.Blue), this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height);
                        //g.DrawRectangle(new Pen(Color.Yellow), item_text_rectf.X, item_text_rectf.Y, item_text_rectf.Width, item_text_rectf.Height);
                    }
                }
                g.TextRenderingHint = text_trh;
            }
            #endregion
            #endregion

            #region 释放

            if (normal_item_text_sb != null)
                normal_item_text_sb.Dispose();
            if (activate_item_text_sb != null)
                activate_item_text_sb.Dispose();
            if (disable_item_text_sb != null)
                disable_item_text_sb.Dispose();

            g.Dispose();

            #endregion

            return bmp;
        }

        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 鱼眼菜单选项集合
        /// </summary>
        [Description("鱼眼菜单选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class FisheyeMenuItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList fisheyeMenuItemList = new ArrayList();
            private FisheyeMenuHandleExt owner;

            public FisheyeMenuItemCollection(FisheyeMenuHandleExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                FisheyeMenuItem[] listArray = new FisheyeMenuItem[this.fisheyeMenuItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (FisheyeMenuItem)this.fisheyeMenuItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                    array.SetValue(this.fisheyeMenuItemList[i], i + index);
            }

            public int Count
            {
                get
                {
                    return this.fisheyeMenuItemList.Count;
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
                if (!(value is FisheyeMenuItem))
                {
                    throw new ArgumentException("FisheyeMenuItem");
                }
                return this.Add((FisheyeMenuItem)value);
            }

            public int Add(FisheyeMenuItem item)
            {
                this.owner.SetFisheyeMenuItemDefaultProportion(item);
                this.fisheyeMenuItemList.Add(item);
                if (this.owner.ShowType == FisheyeMenuShowTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.UpdateReflectionImage(item);
                }
                this.owner.UpdateFisheyeMenuLayerRectangle();
                this.owner.InvalidateLayer();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.fisheyeMenuItemList.Clear();
                if (this.owner.ShowType == FisheyeMenuShowTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.FreeReflectionImages();
                }
                this.owner.UpdateFisheyeMenuLayerRectangle();
                this.owner.InvalidateLayer();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is FisheyeMenuItem)
                {
                    return this.Contains((FisheyeMenuItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is FisheyeMenuItem)
                {
                    return this.fisheyeMenuItemList.IndexOf(item);
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
                if (!(value is FisheyeMenuItem))
                {
                    throw new ArgumentException("FisheyeMenuItem");
                }
                int index = this.fisheyeMenuItemList.IndexOf((FisheyeMenuItem)value);
                this.Remove((FisheyeMenuItem)value);
            }

            public void Remove(FisheyeMenuItem item)
            {
                int index = this.fisheyeMenuItemList.IndexOf(item);
                if (this.owner.ShowType == FisheyeMenuShowTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.FreeReflectionImage(index);
                }
                this.fisheyeMenuItemList.Remove(item);
                this.owner.UpdateFisheyeMenuLayerRectangle();
                this.owner.InvalidateLayer();
            }

            public void RemoveAt(int index)
            {
                if (this.owner.ShowType == FisheyeMenuShowTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.FreeReflectionImage(index);
                }
                this.fisheyeMenuItemList.RemoveAt(index);
                this.owner.UpdateFisheyeMenuLayerRectangle();
                this.owner.InvalidateLayer();
            }

            public FisheyeMenuItem this[int index]
            {
                get
                {
                    return (FisheyeMenuItem)this.fisheyeMenuItemList[index];
                }
                set
                {
                    this.fisheyeMenuItemList[index] = (FisheyeMenuItem)value;
                    this.owner.UpdateFisheyeMenuLayerRectangle();
                    this.owner.InvalidateLayer();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.fisheyeMenuItemList[index];
                }
                set
                {
                    this.fisheyeMenuItemList[index] = (FisheyeMenuItem)value;
                    this.owner.UpdateFisheyeMenuLayerRectangle();
                    this.owner.InvalidateLayer();
                }
            }

            #endregion

        }

        /// <summary>
        /// 鱼眼菜单选项
        /// </summary>
        [Description("鱼眼菜单选项")]
        public class FisheyeMenuItem
        {
            private Image image = null;
            /// <summary>
            /// 图片
            /// </summary>
            [Browsable(true)]
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

            private Image reflectionImage = null;
            /// <summary>
            /// 倒影图片
            /// </summary>
            [Browsable(false)]
            [DefaultValue(null)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("倒影图片")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

            private string text = "";
            /// <summary>
            /// 文本信息
            /// </summary>
            [Browsable(true)]
            [DefaultValue("")]
            [Description("文本信息")]
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

            private string _Char = "";
            /// <summary>
            /// 字符信息(单字符)
            /// </summary>
            [Browsable(true)]
            [DefaultValue("")]
            [Description("字符信息(单字符)")]
            public string Char
            {
                get { return this._Char; }
                set
                {
                    if (this._Char == value || value.Length > 1)
                        return;

                    this._Char = value;
                }
            }

            private string tag = "";
            /// <summary>
            /// 自定义信息
            /// </summary>
            [Browsable(true)]
            [DefaultValue("")]
            [Description("自定义信息")]
            public string Tag
            {
                get { return this.tag; }
                set
                {
                    if (this.tag == value)
                        return;

                    this.tag = value;
                }
            }

            private float _now_proportion;
            /// <summary>
            /// 当前选项大小比例
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("当前选项大小比例")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public float now_proportion
            {
                get { return this._now_proportion; }
                set
                {
                    if (this._now_proportion == value)
                        return;

                    this._now_proportion = value;
                }
            }

            private RectangleF _rectf;
            /// <summary>
            /// 选项缩放到默认比例后rectf（图片真实size或字符真实size）
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("选项缩放到默认比例后rectf")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF rectf
            {
                get { return this._rectf; }
                set
                {
                    if (this._rectf == value)
                        return;

                    this._rectf = value;
                }
            }

            /// <summary>
            /// 选项缩放到默认比例后rectf中心坐标
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("选项缩放到默认比例后rectf中心坐标")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public PointF rectf_centerpoint
            {
                get
                {
                    return new PointF(this.rectf.X + rectf.Width / 2f, rectf.Y + rectf.Height / 2f);
                }
            }

            private RectangleF _now_rectf;
            /// <summary>
            /// 当前选项rectf
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("当前选项rectf")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF now_rectf
            {
                get { return this._now_rectf; }
                set
                {
                    if (this._now_rectf == value)
                        return;

                    this._now_rectf = value;
                }
            }

            /// <summary>
            /// 当前选项rectf中心坐标
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("当前选项rectf中心坐标")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public PointF now_rectf_centerpoint
            {
                get
                {
                    return new PointF(this.now_rectf.X + now_rectf.Width / 2f, now_rectf.Y + now_rectf.Height / 2f);
                }
            }
        }

        /// <summary>
        /// 鱼眼菜单选项选中索引更改事件参数
        /// </summary>
        [Description("鱼眼菜单选项选中索引更改事件参数")]
        public class IndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 鱼眼菜单选项
            /// </summary>
            [Description("鱼眼菜单选项")]
            public FisheyeMenuItem Item { get; set; }
        }

        /// <summary>
        /// 鱼眼菜单选项单击事件参数
        /// </summary>
        [Description("鱼眼菜单选项单击事件参数")]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 鱼眼菜单选项
            /// </summary>
            [Description("鱼眼菜单选项")]
            public FisheyeMenuItem Item { get; set; }
        }

        /// <summary>
        /// 鱼眼菜单鼠标按下滑动选中鼠标释放事件参数
        /// </summary>
        [Description("鱼眼菜单鼠标按下滑动选中鼠标释放事件参数")]
        public class SelectedEventArgs : EventArgs
        {
            /// <summary>
            /// 鱼眼菜单选项
            /// </summary>
            [Description("鱼眼菜单选项")]
            public FisheyeMenuItem Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鱼眼菜单显示方向
        /// </summary>
        [Description("鱼眼菜单显示方向")]
        public enum FisheyeMenuShowOrientation
        {
            /// <summary>
            /// 靠上
            /// </summary>
            Top,
            /// <summary>
            /// 靠左
            /// </summary>
            Left,
            /// <summary>
            /// 靠下
            /// </summary>
            Bottom,
            /// <summary>
            /// 靠右
            /// </summary>
            Right
        }

        /// <summary>
        /// 鱼眼菜单显示类型
        /// </summary>
        [Description("鱼眼菜单显示类型")]
        public enum FisheyeMenuShowTypes
        {
            /// <summary>
            /// 图片文本
            /// </summary>
            ImageText,
            /// <summary>
            /// 字符
            /// </summary>
            Char
        }

        /// <summary>
        /// 鱼眼菜单显示方式
        /// </summary>
        [Description("鱼眼菜单显示方式")]
        public enum FisheyeMenuShowWays
        {
            /// <summary>
            /// 一直显示
            /// </summary>
            Always,
            /// <summary>
            /// 自动显示
            /// </summary>
            Auto
        }

        #endregion

        #region 配件

        /// <summary>
        /// 鱼眼菜单弹层
        /// </summary>
        [Description("鱼眼菜单弹层")]
        protected internal class FisheyeMenuLayer : Form
        {
            #region 扩展

            /// <summary>
            /// 窗户是分层的窗户。如果窗口中有一个不能用这种风格类样式之一CS_OWNDC或CS_CLASSDC。Windows 8的：该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。
            /// </summary>
            private const int WS_EX_LAYERED = 0x80000;

            private const byte AC_SRC_OVER = 0;
            private const byte AC_SRC_ALPHA = 1;
            /// <summary>
            /// 使用pblend作为混合功能。如果显示模式为256色或更小，则此值的效果与ULW_OPAQUE的效果相同。
            /// </summary>
            private const Int32 ULW_ALPHA = 0x00000002;

            /// <summary>
            /// 该BLENDFUNCTION结构控制通过指定源和目的地的位图的混合函数共混。
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                /// <summary>
                /// 源混合操作。当前，唯一已定义的源和目标混合操作是AC_SRC_OVER。有关详细信息，请参见以下“备注”部分。
                /// </summary>
                public byte BlendOp;
                /// <summary>
                /// 必须为零。
                /// </summary>
                public byte BlendFlags;
                /// <summary>
                /// 指定要在整个源位图上使用的Alpha透明度值。所述SourceConstantAlpha值与源位图任何每像素的alpha值组合。如果将SourceConstantAlpha设置为0，则假定图像是透明的。当您只想使用每像素Alpha值时，请将SourceConstantAlpha值设置为255（不透明）。
                /// </summary>
                public byte SourceConstantAlpha;
                /// <summary>
                /// 该成员控制解释源位图和目标位图的方式。AlphaFormat具有以下值。
                /// AC_SRC_ALPHA	
                /// 当位图具有Alpha通道（即每像素alpha）时，将设置此标志。请注意，API使用预乘Alpha，这意味着位图中的红色，绿色和蓝色通道值必须预乘Alpha通道值。例如，如果Alpha通道值为x，则在调用之前，红色，绿色和蓝色通道必须乘以x并除以0xff。
                /// </summary>
                public byte AlphaFormat;
            }

            /// <summary>
            /// 检索句柄用于指定窗口的客户区或整个屏幕的设备上下文（DC）。您可以在后续的GDI函数中使用返回的句柄来绘制DC。设备上下文是一个不透明的数据结构，其值由GDI内部使用。
            /// </summary>
            /// <param name="hWnd">要获取其DC的窗口的句柄。如果此值为NULL，则GetDC检索整个屏幕的DC。</param>
            /// <returns>如果函数成功，则返回值是指定窗口的客户区DC的句柄。如果函数失败，则返回值为NULL。</returns>
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            /// <summary>
            /// 创建具有指定设备兼容的存储器设备上下文（DC）。
            /// </summary>
            /// <param name="hdc">现有DC的句柄。如果此句柄为NULL，则该函数将创建一个与应用程序当前屏幕兼容的内存DC。</param>
            /// <returns>如果函数成功，则返回值是内存DC的句柄。如果函数失败，则返回值为NULL。</returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            /// <summary>
            /// 释放设备上下文（DC），释放它，以供其他应用程序使用。ReleaseDC功能的效果取决于DC的类型。它仅释放公共DC和窗口DC。它对班级或专用DC无效。
            /// </summary>
            /// <param name="hWnd">要释放其DC的窗口的句柄。</param>
            /// <param name="hDC">要释放的DC的句柄。</param>
            /// <returns></returns>
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            /// <summary>
            /// 删除指定的设备上下文（DC）。。
            /// </summary>
            /// <param name="hdc">设备上下文的句柄。</param>
            /// <returns></returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteDC(IntPtr hdc);

            /// <summary>
            /// 选择一个对象到指定的设备上下文（DC）。新对象将替换相同类型的先前对象。
            /// </summary>
            /// <param name="hdc">DC的句柄。</param>
            /// <param name="h">要选择的对象的句柄。必须使用以下功能之一创建指定的对象。
            /// CreateBitmap，CreateBitmapIndirect，CreateCompatibleBitmap，CreateDIBitmap，CreateDIBSection
            /// 位图只能选择到存储器DC中。单个位图不能同时选择到多个DC中。
            /// CreateBrushIndirect，CreateDIBPatternBrush，CreateDIBPatternBrushPt，CreateHatchBrush，CreatePatternBrush，CreateSolidBrush
            /// CreateFont，CreateFontIndirect
            /// 创建笔，创建笔间接
            /// CombineRgn，CreateEllipticRgn，CreateEllipticRgnIndirect，CreatePolygonRgn，CreateRectRgn，CreateRectRgnIndirect</param>
            /// <returns></returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

            /// <summary>
            /// 删除逻辑笔，刷子，字体，位图，区域或调色板，释放与该对象相关联的所有系统资源。删除对象后，指定的句柄不再有效。
            /// </summary>
            /// <param name="ho">逻辑笔，画笔，字体，位图，区域或调色板的句柄。</param>
            /// <returns></returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteObject(IntPtr ho);

            /// <summary>
            /// 更新分层窗口的位置，大小，形状，内容和半透明。
            /// </summary>
            /// <param name="hWnd">分层窗口的句柄。使用CreateWindowEx函数创建窗口时，可以通过指定WS_EX_LAYERED来创建分层窗口。Windows 8的：  该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。</param>
            /// <param name="hdcDst">屏幕DC的句柄。通过在调用函数时指定NULL可获得此句柄。当窗口内容更新时，它用于调色板颜色匹配。如果hdcDst为NULL，则将使用默认调色板。如果hdcSrc为NULL，则hdcDst必须为NULL。</param>
            /// <param name="pptDst">指向指定分层窗口的新屏幕位置的结构的指针。如果当前位置未更改，则pptDst可以为NULL。</param>
            /// <param name="psize">指向指定分层窗口新大小的结构的指针。如果窗口的大小未更改，则psize可以为NULL。如果hdcSrc为NULL，则psize必须为NULL。</param>
            /// <param name="hdcSrc">DC的句柄，用于定义分层窗口的表面。可以通过调用CreateCompatibleDC函数获得此句柄。如果窗口的形状和视觉上下文未更改，则hdcSrc可以为NULL。</param>
            /// <param name="pptSrc">指向指定设备上下文中层位置的结构的指针。如果hdcSrc为NULL，则pptSrc应该为NULL。</param>
            /// <param name="crKey">一个结构，用于指定在组成分层窗口时要使用的颜色键。要生成COLORREF，请使用RGB宏。</param>
            /// <param name="pblend">指向结构的指针，该结构指定组成分层窗口时要使用的透明度值。</param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int UpdateLayeredWindow(IntPtr hWnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

            #endregion

            #region 字段

            /// <summary>
            /// 控件激活状态鼠标是否按下
            /// </summary>
            private bool activatedStateMoveDown = false;

            /// <summary>
            /// 鼠标按下的选项索引
            /// </summary>
            private int mouseDownIndex = -1;

            /// <summary>
            /// 窗体句柄创建完成
            /// </summary>
            private bool isHandleCreate = false;

            /// <summary>
            /// 鱼眼菜单
            /// </summary>
            private FisheyeMenuHandleExt fmce = null;

            #endregion

            public FisheyeMenuLayer(FisheyeMenuHandleExt fmce)
            {
                this.fmce = fmce;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
            }

            #region 重写

            protected override void OnHandleCreated(EventArgs e)
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Selectable, false);

                base.OnHandleCreated(e);
                isHandleCreate = true;
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cParms = base.CreateParams;
                    cParms.ExStyle |= WS_EX_LAYERED;
                    return cParms;
                }
            }

            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);

                this.fmce.activatedStatus = true;
                this.fmce.activatedStatusIndex = -1;
            }

            protected override void OnLeave(EventArgs e)
            {
                base.OnLeave(e);
                this.fmce.activatedStatus = false;
                this.fmce.activatedStatusIndex = -1;

                this.fmce.SetFisheyeMenuItemDefaultProportion();
                this.fmce.UpdateFisheyeMenuLayerRectangle();
                this.fmce.InvalidateLayer();

                if (this.fmce.Enabled && this.fmce.ShowWay == FisheyeMenuShowWays.Auto)
                {
                    this.fmce.StartHideTimer();
                }
            }

            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);

                this.fmce.activatedStatus = true;

                this.fmce.SetFisheyeMenuItemDefaultProportion();
                this.fmce.UpdateFisheyeMenuLayerRectangle();
                this.fmce.InvalidateLayer();
            }

            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);

                this.fmce.activatedStatus = false;
                this.fmce.activatedStatusIndex = -1;
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);

                this.Select();
                this.fmce.activatedStatus = true;
                this.fmce.activatedStatusIndex = -1;

                if (this.fmce.Enabled && this.fmce.ShowWay == FisheyeMenuShowWays.Auto)
                {
                    this.fmce.StartShowTimer();
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);

                this.fmce.SetFisheyeMenuItemDefaultProportion();
                this.fmce.UpdateFisheyeMenuLayerRectangle();
                this.fmce.InvalidateLayer();

                if (this.fmce.Enabled && this.fmce.ShowWay == FisheyeMenuShowWays.Auto)
                {
                    this.fmce.StartHideTimer();
                }
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);

                this.activatedStateMoveDown = true;
                this.mouseDownIndex = -1;
                for (int i = 0; i < this.fmce.Items.Count; i++)
                {
                    if (this.fmce.Items[i].now_rectf.Contains(e.Location))
                    {
                        this.mouseDownIndex = i;
                        int pre_activatedStateIndex = this.fmce.activatedStatusIndex;
                        this.fmce.activatedStatusIndex = i;
                        if (pre_activatedStateIndex != this.fmce.activatedStatusIndex)
                        {
                            this.fmce.FisheyeMenuIndexChanged(this.fmce.activatedStatusIndex);
                        }
                        break;
                    }
                }
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);

                if (this.activatedStateMoveDown && this.fmce.activatedStatusIndex > -1)
                {
                    this.fmce.OnSelected(new SelectedEventArgs() { Item = this.fmce.Items[this.fmce.activatedStatusIndex] });
                }

                this.fmce.activatedStatusIndex = -1;
                this.activatedStateMoveDown = false;
                this.mouseDownIndex = -1;
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);

                if (this.activatedStateMoveDown)
                {
                    for (int i = 0; i < this.fmce.Items.Count; i++)
                    {
                        if (this.fmce.Items[i].now_rectf.Contains(e.Location))
                        {
                            int pre_activatedStateIndex = this.fmce.activatedStatusIndex;
                            this.fmce.activatedStatusIndex = i;
                            if (pre_activatedStateIndex != this.fmce.activatedStatusIndex)
                            {
                                this.fmce.FisheyeMenuIndexChanged(this.fmce.activatedStatusIndex);
                            }
                        }
                    }
                }
                else
                {
                    this.fmce.activatedStatusIndex = -1;
                }

                this.fmce.UpdateFisheyeMenuItemZoomProportion(e.Location);
                this.fmce.UpdateFisheyeMenuLayerItemsRectangle();
                this.InvalidateLayer();
            }

            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);

                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point point = this.PointToClient(Control.MousePosition);
                    for (int i = 0; i < this.fmce.Items.Count; i++)
                    {
                        if (this.fmce.Items[i].now_rectf.Contains(point) && this.mouseDownIndex == i)
                        {
                            this.fmce.OnItemClick(new ItemClickEventArgs() { Item = this.fmce.Items[i] });
                            break;
                        }
                    }
                }
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (this.fmce.activatedStatus)
                {
                    #region Left
                    if (keyData == Keys.Left)
                    {
                        int pre_activatedStateIndex = this.fmce.activatedStatusIndex;
                        this.fmce.activatedStatusIndex--;
                        if (this.fmce.activatedStatusIndex < 0)
                        {
                            this.fmce.activatedStatusIndex = this.fmce.Items.Count - 1;
                        }

                        this.fmce.UpdateFisheyeMenuItemZoomProportion(new PointF(this.fmce.Items[this.fmce.activatedStatusIndex].now_rectf_centerpoint.X, this.fmce.Items[this.fmce.activatedStatusIndex].now_rectf_centerpoint.Y));
                        this.fmce.UpdateFisheyeMenuLayerItemsRectangle();

                        this.InvalidateLayer();
                        if (pre_activatedStateIndex != this.fmce.activatedStatusIndex)
                        {
                            this.fmce.FisheyeMenuIndexChanged(this.fmce.activatedStatusIndex);
                        }
                        return false;
                    }
                    #endregion
                    #region Right
                    else if (keyData == Keys.Right)
                    {
                        int pre_activatedStateIndex = this.fmce.activatedStatusIndex;
                        this.fmce.activatedStatusIndex++;
                        if (this.fmce.activatedStatusIndex > this.fmce.Items.Count - 1)
                        {
                            this.fmce.activatedStatusIndex = 0;
                        }

                        this.fmce.UpdateFisheyeMenuItemZoomProportion(new PointF(this.fmce.Items[this.fmce.activatedStatusIndex].now_rectf_centerpoint.X, this.fmce.Items[this.fmce.activatedStatusIndex].now_rectf_centerpoint.Y));
                        this.fmce.UpdateFisheyeMenuLayerItemsRectangle();

                        this.InvalidateLayer();
                        if (pre_activatedStateIndex != this.fmce.activatedStatusIndex)
                        {
                            this.fmce.FisheyeMenuIndexChanged(this.fmce.activatedStatusIndex);
                        }
                        return false;
                    }
                    #endregion
                    #region Enter、Space
                    else if (keyData == Keys.Enter || keyData == Keys.Space)
                    {
                        this.fmce.SetFisheyeMenuItemDefaultProportion();
                        this.fmce.UpdateFisheyeMenuLayerItemsRectangle();
                        this.InvalidateLayer();

                        this.fmce.OnItemClick(new ItemClickEventArgs() { Item = this.fmce.Items[this.fmce.activatedStatusIndex] });

                        this.fmce.activatedStatusIndex = -1;
                        return false;
                    }
                    #endregion
                }

                return base.ProcessDialogKey(keyData);
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 使分层控件的整个图面无效并导致重绘控件（Invalidate已失效）。
            /// </summary>
            public void InvalidateLayer()
            {
                if (this.isHandleCreate && this.Visible)
                {
                    this.DrawImageToLayer(this.fmce.CreateLayerImage());
                }
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 绘制图片到分层控件上
            /// </summary>
            /// <param name="bitmap"></param>
            private void DrawImageToLayer(Bitmap bitmap)
            {
                IntPtr hdcDst = GetDC(this.Handle);
                IntPtr hdcSrc = CreateCompatibleDC(hdcDst);

                IntPtr newBitmap = bitmap.GetHbitmap(Color.FromArgb(0));//创建一张位图
                IntPtr oldBitmap = SelectObject(hdcSrc, newBitmap);//位图绑定到DC设备上

                Point pptDst = new Point(this.Left, this.Top);
                Size psize = new Size(bitmap.Width, bitmap.Height);
                Point pptSrc = new Point(0, 0);

                BLENDFUNCTION pblend = new BLENDFUNCTION();
                pblend.BlendOp = AC_SRC_OVER;
                pblend.SourceConstantAlpha = 255;
                pblend.AlphaFormat = AC_SRC_ALPHA;
                pblend.BlendFlags = 0;

                UpdateLayeredWindow(this.Handle, hdcDst, ref pptDst, ref psize, hdcSrc, ref pptSrc, 0, ref pblend, ULW_ALPHA);

                if (oldBitmap != IntPtr.Zero)
                {
                    if (oldBitmap != IntPtr.Zero)
                        DeleteObject(newBitmap);
                    if (oldBitmap != IntPtr.Zero)
                        DeleteObject(newBitmap);
                }
                if (bitmap != null)
                    bitmap.Dispose();
                ReleaseDC(this.Handle, hdcDst);
                DeleteDC(hdcSrc);
            }

            #endregion

        }

        /// <summary>
        /// 鱼眼菜单句柄蒙版层
        /// </summary>
        [Description("鱼眼菜单句柄蒙版层")]
        protected internal class FisheyeMenuHandleMask : Form
        {
            #region 扩展

            // 下面这段代码主要用来调用Windows API实现窗体透明(鼠标可以穿透窗体),注意SetWindowLong的兼容性

            protected internal static IntPtr GetWindowLong(IntPtr hWnd, int nIndex)
            {
                HandleRef hr_hWnd = new HandleRef(null, hWnd);

                if (IntPtr.Size == 4)
                    return GetWindowLong32(hr_hWnd, nIndex);
                return GetWindowLongPtr64(hr_hWnd, nIndex);
            }

            [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
            protected internal static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);
            [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
            protected internal static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);

            protected internal static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
            {
                HandleRef hr_hWnd = new HandleRef(null, hWnd);
                HandleRef hr_dwNewLong = new HandleRef(null, (IntPtr)dwNewLong);

                if (IntPtr.Size == 4)
                    return SetWindowLongPtr32(hr_hWnd, nIndex, hr_dwNewLong);
                return SetWindowLongPtr64(hr_hWnd, nIndex, hr_dwNewLong);
            }

            [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
            protected internal static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
            [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
            protected internal static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, HandleRef dwNewLong);

            /// <summary>
            /// 设置分层窗口的不透明度和透明度颜色键
            /// </summary>
            /// <param name="hwnd"></param>
            /// <param name="crKey"></param>
            /// <param name="bAlpha"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes", CharSet = CharSet.Auto)]
            private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

            /// <summary>
            /// 设置新的扩展窗口样式
            /// </summary>
            private const int GWL_EXSTYLE = -20;
            /// <summary>
            /// 在绘制窗口下方的兄弟姐妹（由同一线程创建）之前，不应绘制窗口。该窗口显示为透明，因为基础同级窗口的位已被绘制。要获得透明性而没有这些限制，请使用SetWindowRgn函数
            /// </summary>
            private const int WS_EX_TRANSPARENT = 0x20;
            /// <summary>
            /// 窗户是分层的窗户。如果窗口中有一个不能用这种风格类样式之一CS_OWNDC或CS_CLASSDC。Windows 8的：该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。
            /// </summary>
            private const int WS_EX_LAYERED = 0x80000;
            /// <summary>
            /// 使用bAlpha确定分层窗口的不透明度。
            /// </summary>
            private const int LWA_ALPHA = 2;

            #endregion

            #region 字段

            /// <summary>
            /// 鱼眼菜单
            /// </summary>
            private FisheyeMenuHandleExt fmce = null;

            #endregion

            public FisheyeMenuHandleMask(FisheyeMenuHandleExt fmce)
            {
                this.fmce = fmce;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;

                this.InvalidateLayer();//背景透明穿透
            }

            #region 公开方法

            /// <summary>
            ///  使控件的整个图面无效并导致重绘控件。
            /// </summary>
            public void InvalidateLayer()
            {
                this.BackColor = Color.FromArgb(255, this.fmce.HandleMaskBackColor);
                SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)((int)GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED));
                SetLayeredWindowAttributes(this.Handle, 0, this.fmce.HandleMaskBackColor.A, LWA_ALPHA);
            }

            #endregion
        }

        /// <summary>
        /// 鱼眼菜单计时器
        /// </summary>
        [Description("鱼眼菜单计时器")]
        protected internal class FisheyeMenuTimer
        {
            #region 新增属性

            private Timer _timer = null;
            /// <summary>
            /// 显示隐藏鱼眼菜单弹层的定时器
            /// </summary>
            [Description("显示隐藏鱼眼菜单弹层的定时器")]
            public Timer timer
            {
                get { return this._timer; }
                set
                {
                    if (this._timer == value)
                        return;

                    this._timer = value;
                }
            }

            private FisheyeMenuTimerTypes _timer_type = FisheyeMenuTimerTypes.Hideed;
            /// <summary>
            /// 鱼眼菜单计时器累计时间
            /// </summary>
            [Description("鱼眼菜单计时器累计时间")]
            public FisheyeMenuTimerTypes timer_type
            {
                get { return this._timer_type; }
                set
                {
                    if (this._timer_type == value)
                        return;

                    this._timer_type = value;
                }
            }

            private int _timer_total = 0;
            /// <summary>
            /// 鱼眼菜单计时器累计时间
            /// </summary>
            [Description("鱼眼菜单计时器累计时间")]
            public int timer_total
            {
                get { return this._timer_total; }
                set
                {
                    if (this._timer_total == value)
                        return;

                    this._timer_total = value;
                }
            }

            public FisheyeMenuTimer(EventHandler tick)
            {
                this.CreateTimer(tick);
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 初始化计时器
            /// </summary>
            /// <param name="tick"></param>
            public void CreateTimer(EventHandler tick)
            {
                if (this.timer == null)
                {
                    this.timer = new Timer();
                    this.timer.Interval = 50;
                    this.timer.Tick += new EventHandler(tick);
                }
            }

            #endregion

            #region 枚举

            /// <summary>
            /// 鱼眼菜单计时器功能类型
            /// </summary>
            [Description("鱼眼菜单计时器功能类型")]
            public enum FisheyeMenuTimerTypes
            {
                /// <summary>
                /// 没有任何操作
                /// </summary>
                None,
                /// <summary>
                /// 显示累计器
                /// </summary>
                ShowTimer,
                /// <summary>
                /// 已显示
                /// </summary>
                Showed,
                /// <summary>
                /// 隐藏累计器
                /// </summary>
                HideTimer,
                /// <summary>
                /// 已隐藏
                /// </summary>
                Hideed
            }

            #endregion

        }

        /// <summary>
        /// 钩子
        /// </summary>
        [Description("钩子")]
        protected internal abstract class FisheyeMenuHook : IDisposable
        {
            #region 结构

            /// <summary>
            /// 坐标
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct PointStruct
            {
                public int X;
                public int Y;
            }

            /// <summary>
            /// 鼠标钩子返回信息结构体
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public class MouseHookStruct
            {
                public PointStruct pt;
                public int hwnd;
                public int wHitTestCode;
                public int dwExtraInfo;
            }

            /// <summary>
            /// 键盘钩子返回信息结构体
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public class KeyHookStruct
            {
                public int vkCode;
                public int scanCode;
                public int flags;
                public int time;
                public int dwExtraInfo;
            }

            #endregion

            #region 扩展

            /// <summary>
            /// 钩子回调函数
            /// </summary>
            /// <param name="nCode"></param>
            /// <param name="wParam"></param>
            /// <param name="lParam"></param>
            /// <returns></returns>
            public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

            /// <summary>
            /// 安装钩子
            /// </summary>
            /// <param name="idHook"></param>
            /// <param name="lpfn"></param>
            /// <param name="hInstance"></param>
            /// <param name="threadId"></param>
            /// <returns></returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

            /// <summary>
            /// 卸载钩子
            /// </summary>
            /// <param name="idHook"></param>
            /// <returns></returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern bool UnhookWindowsHookEx(int idHook);

            /// <summary>
            /// 调用下一个钩子
            /// </summary>
            /// <param name="idHook"></param>
            /// <param name="nCode"></param>
            /// <param name="wParam"></param>
            /// <param name="lParam"></param>
            /// <returns></returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

            /// <summary>
            /// 获取指定修改键状态
            /// </summary>
            /// <param name="vKey"></param>
            /// <returns></returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern short GetKeyState(int vKey);

            /// <summary>
            /// 获取模块句柄
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetModuleHandle(string name);

            #endregion

            #region 公开方法

            /// <summary>
            /// 安装钩子
            /// </summary>
            public abstract void HookStart();

            /// <summary>  
            /// 取消钩子  
            /// </summary>  
            public abstract void HookStop();

            #endregion

            #region 释放

            /// <summary>
            /// 是否回收完毕
            /// </summary>
            protected bool _disposed;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            ~FisheyeMenuHook()
            {
                Dispose(false);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)//如果已经被回收，就中断执行
                    return;

                if (disposing)
                {
                    this.HookStop();
                    _disposed = true;
                }

            }

            #endregion
        }

        /// <summary>
        /// 鼠标钩子
        /// </summary>
        [Description("鼠标钩子")]
        protected internal class FisheyeMenuMouseHook : FisheyeMenuHook
        {
            #region 扩展

            internal const int WH_MOUSE_LL = 14;//全局鼠标事件
            internal const int WH_MOUSE = 14;//模块鼠标事件
            internal const int WM_MOUSEMOVE = 0x200;
            internal const int WM_LBUTTONDOWN = 0x201;
            internal const int WM_RBUTTONDOWN = 0x204;
            internal const int WM_MBUTTONDOWN = 0x207;
            internal const int WM_XBUTTONDOWN = 0x020B;
            internal const int WM_LBUTTONUP = 0x202;
            internal const int WM_RBUTTONUP = 0x205;
            internal const int WM_MBUTTONUP = 0x208;
            internal const int WM_XBUTTONUP = 0x020C;

            #endregion

            #region 新增事件

            private event MouseEventHandler mouseMove;
            /// <summary>
            /// 鼠标移动事件
            /// </summary>
            public event MouseEventHandler MouseMove
            {
                add { this.mouseMove += value; }
                remove { this.mouseMove -= value; }
            }

            #endregion

            #region 新增字段

            private HookProc MouseMoveHookProcedure;

            private int mouseMoveHookStatus = 0;

            private bool ismovedown = false;

            #endregion

            #region 公开方法
            /// <summary>
            /// 安装钩子
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("不再使用")]
            public override void HookStart()
            {

            }

            /// <summary>
            /// 安装钩子
            /// </summary>
            /// <param name="type">鼠标钩子类型</param>
            public void HookStart(FisheyeMenuMouseHookTypes type)
            {
                if (this.mouseMoveHookStatus == 0)
                {
                    this.MouseMoveHookProcedure = new HookProc(this.MouseMoveHookProc);
                    this.mouseMoveHookStatus = SetWindowsHookEx(type == FisheyeMenuMouseHookTypes.Global ? WH_MOUSE_LL : WH_MOUSE, this.MouseMoveHookProcedure, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                }
            }

            /// <summary>  
            /// 取消钩子  
            /// </summary>  
            public override void HookStop()
            {
                if (mouseMoveHookStatus != 0)
                {
                    UnhookWindowsHookEx(this.mouseMoveHookStatus);
                    this.mouseMoveHookStatus = 0;
                }
            }

            #endregion

            #region 私有方法

            /// <summary>  
            /// 鼠标处理事件 
            /// </summary>  
            private int MouseMoveHookProc(int nCode, Int32 wParam, IntPtr lParam)
            {
                if (nCode >= 0 && this.mouseMove != null)
                {
                    switch (wParam)
                    {
                        case WM_LBUTTONUP:
                        case WM_RBUTTONUP:
                        case WM_MBUTTONUP:
                        case WM_XBUTTONUP:
                            {
                                this.ismovedown = false;
                                break;
                            }
                        case WM_LBUTTONDOWN:
                        case WM_RBUTTONDOWN:
                        case WM_MBUTTONDOWN:
                        case WM_XBUTTONDOWN:
                            {
                                this.ismovedown = true;
                                break;
                            }
                        case WM_MOUSEMOVE:
                            {
                                if (!this.ismovedown)
                                {
                                    MouseHookStruct mouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                                    MouseEventArgs e = new MouseEventArgs(MouseButtons.None, 0, mouseHookStruct.pt.X, mouseHookStruct.pt.Y, 0);
                                    this.mouseMove(this, e);
                                }
                                break;
                            }
                    }
                }

                // 启动下一次钩子  
                return CallNextHookEx(this.mouseMoveHookStatus, nCode, wParam, lParam);
            }

            #endregion


        }

        /// <summary>
        /// 全局键盘钩子
        /// </summary>
        [Description("全局键盘钩子")]
        protected internal class FisheyeMenuKeyHook : FisheyeMenuHook
        {
            #region 扩展

            internal const int WH_KEYBOARD_LL = 13;//键盘事件
            internal const int WM_KEYDOWN = 0X0100; //键按下
            internal const int WM_SYSKEYDOWN = 0X0104;
            internal const int WM_KEYUP = 0x0101;  //键按下释放
            internal const int WM_SYSKEYUP = 0x0105;

            internal const byte VK_SHIFT = 0x10;
            internal const byte VK_CONTROL = 0x11;
            internal const byte VK_MENU = 0x12;

            #endregion

            #region 新增事件

            public event KeyEventHandler keyDown;
            /// <summary>
            /// 键盘按下事件
            /// </summary>
            public event KeyEventHandler KeyDown
            {
                add { this.keyDown += value; }
                remove { this.keyDown -= value; }
            }

            public event KeyEventHandler keyUp;
            /// <summary>
            /// 键盘按下松开事件
            /// </summary>
            public event KeyEventHandler KeyUp
            {
                add { this.keyUp += value; }
                remove { this.keyUp -= value; }
            }

            #endregion

            #region 新增属性

            private Keys shortcutKey = Keys.Control | Keys.Q;
            /// <summary>
            /// 弹出鱼眼菜单键盘快捷键
            /// </summary>
            [DefaultValue(Keys.Control | Keys.Q)]
            [Description("弹出鱼眼菜单键盘快捷键")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public Keys ShortcutKey
            {
                get { return shortcutKey; }
                set
                {
                    if (shortcutKey == value)
                        return;

                    shortcutKey = value;
                }
            }

            #endregion

            #region 新增字段

            private HookProc KeyDownHookProcedure;

            private int keyDownHookStatus = 0;

            private List<Keys> keyList = new List<Keys>();

            #endregion

            #region 公开方法

            /// <summary>
            /// 安装钩子
            /// </summary>
            public override void HookStart()
            {
                if (this.keyDownHookStatus == 0)
                {
                    this.keyList.Clear();
                    this.KeyDownHookProcedure = new HookProc(this.KeyDownHookProc);
                    this.keyDownHookStatus = SetWindowsHookEx(WH_KEYBOARD_LL, this.KeyDownHookProcedure, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                }
            }

            /// <summary>  
            /// 取消钩子  
            /// </summary>  
            public override void HookStop()
            {
                if (this.keyDownHookStatus != 0)
                {
                    UnhookWindowsHookEx(this.keyDownHookStatus);
                    this.keyDownHookStatus = 0;
                }
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 键盘处理事件
            /// </summary>
            /// <param name="nCode"></param>
            /// <param name="wParam"></param>
            /// <param name="lParam"></param>
            /// <returns></returns>
            private int KeyDownHookProc(int nCode, Int32 wParam, IntPtr lParam)
            {
                if (nCode >= 0 && (this.keyDown != null || this.keyUp != null))
                {
                    bool is_ctrl = ((GetKeyState(VK_CONTROL) & 0x80) != 0);
                    bool is_shift = ((GetKeyState(VK_SHIFT) & 0x80) != 0);
                    bool is_alt = ((GetKeyState(VK_MENU) & 0x80) != 0);

                    KeyHookStruct keyHookStruct = (KeyHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyHookStruct));//获取钩子的相关信息
                    KeyEventArgs e = new KeyEventArgs((Keys)(//获取KeyEventArgs事件的相关信息
                                               keyHookStruct.vkCode |
                                               (is_ctrl ? (int)Keys.Control : 0) |
                                               (is_shift ? (int)Keys.Shift : 0) |
                                               (is_alt ? (int)Keys.Alt : 0)
                                               ));

                    if (e.KeyData == this.ShortcutKey)
                    {
                        if (this.keyDown != null && (wParam == (int)WM_SYSKEYDOWN) || (wParam == (int)WM_KEYDOWN))
                        {
                            if (this.keyList.IndexOf(e.KeyCode) == -1)
                            {
                                this.keyList.Add(e.KeyCode);
                                this.keyDown(this, e);
                                return 1;
                            }
                        }
                        else if (this.keyUp != null && (wParam == (int)WM_SYSKEYUP) || (wParam == (int)WM_KEYUP))
                        {
                            this.keyList.Remove(e.KeyCode);
                            this.keyUp(this, e);
                            return 1;
                        }
                    }

                }

                // 启动下一次钩子  
                return CallNextHookEx(this.keyDownHookStatus, nCode, wParam, lParam);
            }

            #endregion

        }

        /// <summary>
        /// 鼠标钩子类型
        /// </summary>
        [Description("鼠标钩子类型")]
        public enum FisheyeMenuMouseHookTypes
        {
            /// <summary>
            /// 全局
            /// </summary>
            Global,
            /// <summary>
            /// 模块
            /// </summary>
            Module
        }

        #endregion

    }

}
