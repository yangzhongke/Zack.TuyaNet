
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
    /// ListBoxExt控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("ListBoxExt控件")]
    [DefaultProperty("Items")]
    [DefaultEvent("ItemClick")]
    public class ListBoxExt : Control
    {
        #region 新增事件

        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);
        private event ItemClickEventHandler itemClick;
        /// <summary>
        /// 选项单击事件
        /// </summary>
        [Description("选项单击事件")]
        public event ItemClickEventHandler ItemClick
        {
            add { this.itemClick += value; }
            remove { this.itemClick -= value; }
        }

        public delegate void ItemSelectedChangedEventHandler(object sender, ItemSelectedChangedEventArgs e);
        private event ItemSelectedChangedEventHandler itemSelectedChanged;
        /// <summary>
        /// 选项选中状态更改事件
        /// </summary>
        [Description("选项选中状态更改事件")]
        public event ItemSelectedChangedEventHandler ItemSelectedChanged
        {
            add { this.itemSelectedChanged += value; }
            remove { this.itemSelectedChanged -= value; }
        }

        public delegate void SelectedChangedEventHandler(object sender, SelectedIndexChangedEventArgs e);
        private event SelectedChangedEventHandler selectedIndexChanged;
        /// <summary>
        /// 选中选项更改事件（限制于单选）
        /// </summary>
        [Description("选中选项更改事件")]
        public event SelectedChangedEventHandler SelectedIndexChanged
        {
            add { this.selectedIndexChanged += value; }
            remove { this.selectedIndexChanged -= value; }
        }

        public delegate void DrawItemEventHandler(object sender, DrawItemEventArgs e);
        private event DrawItemEventHandler drawItem;
        /// <summary>
        /// 选项自定义绘制事件
        /// </summary>
        [Description("选项自定义绘制事件")]
        public event DrawItemEventHandler DrawItem
        {
            add { this.drawItem += value; }
            remove { this.drawItem -= value; }
        }

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MarginChanged
        {
            add { base.MarginChanged += value; }
            remove { base.MarginChanged -= value; }
        }

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

        private DrawTypes drawType = DrawTypes.Default;
        /// <summary>
        /// 选项绘制方式
        /// </summary>
        [DefaultValue(DrawTypes.Default)]
        [Description("选项绘制方式")]
        public DrawTypes DrawType
        {
            get { return this.drawType; }
            set
            {
                if (this.drawType == value)
                    return;

                this.drawType = value;
                this.Invalidate();
            }
        }

        private int borderWidth = 1;
        /// <summary>
        /// 边框宽度
        /// </summary>
        [DefaultValue(1)]
        [Description("边框宽度")]
        public int BorderWidth
        {
            get { return this.borderWidth; }
            set
            {
                if (this.borderWidth == value || value < 0)
                    return;

                this.borderWidth = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description(" 边框颜色")]
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

        private bool multiple = false;
        /// <summary>
        /// 是否多想选中
        /// </summary>
        [DefaultValue(false)]
        [Description("是否多想选中")]
        public bool Multiple
        {
            get { return this.multiple; }
            set
            {
                if (this.multiple == value)
                    return;

                this.multiple = value;

                if (this.multiple == false)
                {
                    bool readly = false;
                    foreach (Item item in this.Items)
                    {
                        if (readly)
                        {
                            item.Selected = false;
                        }
                        else
                        {
                            if (item.Selected)
                            {
                                readly = true;
                            }
                        }
                    }
                }
            }
        }

        private ScrollClass scroll;
        /// <summary>
        /// 滚动条
        /// </summary>
        [Description("滚动条")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ScrollClass Scroll
        {
            get
            {
                if (this.scroll == null)
                    this.scroll = new ScrollClass(this);
                return this.scroll;
            }
        }

        private ItemCollection itemCollection;
        /// <summary>
        /// 选项集合
        /// </summary>
        [Description("选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ItemCollection Items
        {
            get
            {
                if (this.itemCollection == null)
                    this.itemCollection = new ItemCollection(this);
                return this.itemCollection;
            }
        }

        #region 选项

        private int itemBHeight = 24;
        /// <summary>
        /// 选项高度
        /// </summary>
        [DefaultValue(24)]
        [Description("选项高度")]
        public int ItemHeight
        {
            get { return this.itemBHeight; }
            set
            {
                if (this.itemBHeight == value || value < 0)
                    return;

                this.itemBHeight = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private ItemBorderStyles itemBorderStyle = ItemBorderStyles.Line;
        /// <summary>
        /// 选项边框风格
        /// </summary>
        [DefaultValue(ItemBorderStyles.Line)]
        [Description("选项边框风格")]
        public ItemBorderStyles ItemBorderStyle
        {
            get { return this.itemBorderStyle; }
            set
            {
                if (this.itemBorderStyle == value)
                    return;

                this.itemBorderStyle = value;
                this.Invalidate();
            }
        }

        private Color itemBorderColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 选项边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description(" 选项边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemBorderColor
        {
            get { return this.itemBorderColor; }
            set
            {
                if (this.itemBorderColor == value)
                    return;

                this.itemBorderColor = value;
                this.Invalidate();
            }
        }

        private bool itemImageShow = false;
        /// <summary>
        /// 是否显示选项图片
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示选项图片")]
        public bool ItemImageShow
        {
            get { return this.itemImageShow; }
            set
            {
                if (this.itemImageShow == value)
                    return;

                this.itemImageShow = value;
                this.Invalidate();
            }
        }

        private Size itemImageSize = new Size(22, 22);
        /// <summary>
        /// 选项图片Size
        /// </summary>
        [DefaultValue(typeof(Size), "22,22")]
        [Description("选项图片Size")]
        public Size ItemImageSize
        {
            get { return this.itemImageSize; }
            set
            {
                if (this.itemImageSize == value)
                    return;

                this.itemImageSize = value;
                this.Invalidate();
            }
        }

        private ImageList itemImageList;
        /// <summary>
        /// 选项图片List
        /// </summary>
        [Description("选项图片List")]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageList ItemImageList
        {
            get
            {
                return this.itemImageList;
            }
            set
            {
                if (this.itemImageList == value)
                    return;

                EventHandler eventHandler1 = new EventHandler(this.ImageListRecreateHandle);
                EventHandler eventHandler2 = new EventHandler(this.DetachImageList);
                if (this.itemImageList != null)
                {
                    this.itemImageList.RecreateHandle -= eventHandler1;
                    this.itemImageList.Disposed -= eventHandler2;
                }
                if (value != null)
                {
                    this.itemImage = (Image)null;
                }
                this.itemImageList = value;
                this.itemImageIndex.ImageList = value;
                if (value != null)
                {
                    value.RecreateHandle += eventHandler1;
                    value.Disposed += eventHandler2;
                }
                else
                {
                    this.itemImageIndex.Index = -1;
                    this.itemImageIndex.Key = string.Empty;
                }
                this.Invalidate();
            }
        }

        private Image itemImage = null;
        /// <summary>
        /// 选项图片
        /// </summary>
        [DefaultValue(null)]
        [Description("选项图片")]
        public Image ItemImage
        {
            get
            {
                if (this.itemImage != null)
                {
                    return this.itemImage;
                }
                else
                {
                    if (this.itemImageList != null)
                    {
                        int index = this.itemImageIndex.ActualIndex;
                        if (index >= this.itemImageList.Images.Count)
                            return null;
                        if (index >= 0)
                            return this.itemImageList.Images[index];
                    }
                    return null;
                }
            }
            set
            {
                if (this.itemImage == value)
                    return;

                this.itemImage = value;
                this.itemImageIndex.Index = -1;
                this.itemImageIndex.Key = string.Empty;
                this.Invalidate();
            }
        }

        private Indexer itemImageIndex = new Indexer();
        /// <summary>
        /// 选项图片Index
        /// </summary>
        [Description("选项图片Index")]
        [DefaultValue(-1)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageIndexConverter))]
        public int ItemImageIndex
        {
            get
            {
                if (this.itemImageIndex.Index != -1 && this.itemImageList != null && this.itemImageIndex.Index >= this.itemImageList.Images.Count)
                    return this.itemImageList.Images.Count - 1;
                return this.itemImageIndex.Index;
            }
            set
            {
                if (this.itemImageIndex.Index == value || value < -1)
                    return;

                this.itemImageIndex.Index = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 选项图片Key
        /// </summary>
        [Description("选项图片Key")]
        [DefaultValue("")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(ImageKeyConverter))]
        public string ItemImageKey
        {
            get
            {
                return this.itemImageIndex.Key;
            }
            set
            {
                if (this.itemImageIndex.Key == value)
                    return;

                this.itemImageIndex.Key = value;
                this.Invalidate();
            }
        }

        private Color normalBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 选项背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description(" 选项背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        public Color NormalBackColor
        {
            get { return this.normalBackColor; }
            set
            {
                if (this.normalBackColor == value)
                    return;

                this.normalBackColor = value;
                this.Invalidate();
            }
        }

        private Color normalTextColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 选项文本颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description(" 选项文本颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        public Color NormalTextColor
        {
            get { return this.normalTextColor; }
            set
            {
                if (this.normalTextColor == value)
                    return;

                this.normalTextColor = value;
                this.Invalidate();
            }
        }

        private Color enterBackColor = Color.FromArgb(189, 208, 188);
        /// <summary>
        /// 选项背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "189, 208, 188")]
        [Description(" 选项背景颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        public Color EnterBackColor
        {
            get { return this.enterBackColor; }
            set
            {
                if (this.enterBackColor == value)
                    return;

                this.enterBackColor = value;
                this.Invalidate();
            }
        }

        private Color enterTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 选项文本颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description(" 选项文本颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        public Color EnterTextColor
        {
            get { return this.enterTextColor; }
            set
            {
                if (this.enterTextColor == value)
                    return;

                this.enterTextColor = value;
                this.Invalidate();
            }
        }

        private Color selectedBackColor = Color.FromArgb(176, 197, 175);
        /// <summary>
        /// 选项背景颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "176, 197, 175")]
        [Description(" 选项背景颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        public Color SelectedBackColor
        {
            get { return this.selectedBackColor; }
            set
            {
                if (this.selectedBackColor == value)
                    return;

                this.selectedBackColor = value;
                this.Invalidate();
            }
        }

        private Color selectedTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 选项文本颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description(" 选项文本颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        public Color SelectedTextColor
        {
            get { return this.selectedTextColor; }
            set
            {
                if (this.selectedTextColor == value)
                    return;

                this.selectedTextColor = value;
                this.Invalidate();
            }
        }

        private Color disableBackColor = Color.FromArgb(234, 234, 234);
        /// <summary>
        /// 选项背景颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "234, 234, 234")]
        [Description(" 选项背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
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

        private Color disableTextColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 选项文本颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("选项文本颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
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
                return new Size(100, 200);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        public new Padding Margin
        {
            get
            {
                return base.Margin;
            }
            set
            {
                base.Margin = value;
            }
        }

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
        private bool activatedState = false;

        /// <summary>
        /// 控件激活状态选项索引
        /// </summary>
        private int activatedStateIndex = -1;

        /// <summary>
        /// 列表区域Rect
        /// </summary>
        private Rectangle mainRect = Rectangle.Empty;
        /// <summary>
        /// 真实列表区域Rect
        /// </summary>
        private Rectangle mainRealityRect = Rectangle.Empty;

        /// <summary>
        /// 是否按下鼠标
        /// </summary>
        private bool ismovedown = false;
        /// <summary>
        /// 鼠标按下的坐标
        /// </summary>
        private Point movedownpoint = Point.Empty;
        /// <summary>
        /// 鼠标按下信息
        /// </summary>
        private MouseDownClass mousedowninfo = new MouseDownClass();

        #endregion

        public ListBoxExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.InitializeRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            #region 边框

            if (this.BorderWidth > 0)
            {
                Pen border_pen = new Pen(this.BorderColor, this.BorderWidth);
                border_pen.Alignment = PenAlignment.Inset;
                int border = this.BorderWidth == 1 ? -1 : 0;
                g.DrawRectangle(border_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, (int)(this.ClientRectangle.Width + border), this.ClientRectangle.Height + border));
                border_pen.Dispose();
            }

            #endregion

            #region 背景

            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, this.mainRect);
            back_sb.Dispose();

            #endregion

            #region 选项

            Region client_region = null;
            Region main_region = null;
            if (this.BorderWidth > 0)
            {
                client_region = g.Clip.Clone();
                main_region = new Region(this.mainRect);
                g.Clip = main_region;
            }

            #region 颜色

            Pen itemborder_pen = null;
            LinearGradientBrush itemborder_lgb = null;
            if (this.ItemBorderStyle == ItemBorderStyles.Line)
            {
                itemborder_pen = new Pen(this.ItemBorderColor, 1);
            }
            else if (this.ItemBorderStyle == ItemBorderStyles.GradualLine)
            {
                itemborder_lgb = new LinearGradientBrush(new PointF(this.mainRect.X, this.mainRect.Y), new PointF(this.mainRect.Right, this.mainRect.Y), Color.Transparent, Color.Transparent);
                ColorBlend itemborder_cb = new ColorBlend();
                itemborder_cb.Colors = new Color[] { Color.Transparent, this.ItemBorderColor, this.ItemBorderColor, Color.Transparent };
                itemborder_cb.Positions = new float[] { 0.0f, 0.23f, 0.70f, 1.0f };
                itemborder_lgb.InterpolationColors = itemborder_cb;
                itemborder_pen = new Pen(itemborder_lgb, 1);
            }

            SolidBrush item_normal_back_sb = new SolidBrush(this.NormalBackColor);
            SolidBrush item_enter_back_sb = new SolidBrush(this.EnterBackColor);
            SolidBrush item_selected_back_sb = new SolidBrush(this.SelectedBackColor);
            SolidBrush item_disable_back_sb = new SolidBrush(this.DisableBackColor);

            SolidBrush item_normal_text_sb = new SolidBrush(this.NormalTextColor);
            SolidBrush item_enter_text_sb = new SolidBrush(this.EnterTextColor);
            SolidBrush item_selected_text_sb = new SolidBrush(this.SelectedTextColor);
            SolidBrush item_disable_text_sb = new SolidBrush(this.DisableTextColor);

            #endregion

            #region 绘制
            List<Brush> brushList = new List<Brush>();
            List<Pen> penList = new List<Pen>();

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Rect.Bottom >= this.mainRect.Y && this.Items[i].Rect.Y <= this.mainRect.Bottom)
                {
                    SolidBrush commom_back_sb = null;
                    SolidBrush commom_text_sb = null;
                    bool custom_back_sb = false;
                    bool custom_text_sb = false;
                    Image commom_image = null;
                    if (this.ItemImageShow)
                    {
                        commom_image = (this.Items[i].Image == null) ? commom_image = this.ItemImage : this.Items[i].Image;
                    }
                    if (this.Items[i].Enabled == false)
                    {
                        if (this.Items[i].DisableBackColor == Color.Empty)
                        {
                            commom_back_sb = item_disable_back_sb;
                        }
                        else
                        {
                            custom_back_sb = true;
                            commom_back_sb = new SolidBrush(this.Items[i].DisableBackColor);
                        }
                        if (this.Items[i].DisableTextColor == Color.Empty)
                        {
                            commom_text_sb = item_disable_text_sb;
                        }
                        else
                        {
                            custom_text_sb = true;
                            commom_text_sb = new SolidBrush(this.Items[i].DisableTextColor);
                        }
                    }
                    else
                    {
                        if (this.Items[i].Selected == true)
                        {
                            if (this.Items[i].SelectedBackColor == Color.Empty)
                            {
                                commom_back_sb = item_selected_back_sb;
                            }
                            else
                            {
                                custom_back_sb = true;
                                commom_back_sb = new SolidBrush(this.Items[i].SelectedBackColor);
                            }
                            if (this.Items[i].SelectedTextColor == Color.Empty)
                            {
                                commom_text_sb = item_selected_text_sb;
                            }
                            else
                            {
                                custom_text_sb = true;
                                commom_text_sb = new SolidBrush(this.Items[i].SelectedTextColor);
                            }
                        }
                        else
                        {
                            if (this.Items[i].MouseStatus == ItemMouseStatuss.Enter)
                            {
                                if (this.Items[i].EnterBackColor == Color.Empty)
                                {
                                    commom_back_sb = item_enter_back_sb;
                                }
                                else
                                {
                                    custom_back_sb = true;
                                    commom_back_sb = new SolidBrush(this.Items[i].EnterBackColor);
                                }
                                if (this.Items[i].EnterTextColor == Color.Empty)
                                {
                                    commom_text_sb = item_enter_text_sb;
                                }
                                else
                                {
                                    custom_text_sb = true;
                                    commom_text_sb = new SolidBrush(this.Items[i].EnterTextColor);
                                }
                            }
                            else
                            {
                                if (this.Items[i].NormalBackColor == Color.Empty)
                                {
                                    commom_back_sb = item_normal_back_sb;
                                }
                                else
                                {
                                    custom_back_sb = true;
                                    commom_back_sb = new SolidBrush(this.Items[i].NormalBackColor);
                                }
                                if (this.Items[i].NormalTextColor == Color.Empty)
                                {
                                    commom_text_sb = item_normal_text_sb;
                                }
                                else
                                {
                                    custom_text_sb = true;
                                    commom_text_sb = new SolidBrush(this.Items[i].NormalTextColor);
                                }
                            }
                        }
                    }
                    if (this.DrawType == DrawTypes.Default)
                    {
                        this.PaintItem(this.Items[i], g, commom_image, itemborder_pen, commom_back_sb, commom_text_sb);
                    }
                    else
                    {
                        this.OnDrawItem(new DrawItemEventArgs() { g = g, Image = commom_image, Item = this.Items[i], BackBrush = commom_back_sb, TextBrush = commom_text_sb, BrushList = brushList, PenList = penList });
                    }
                    if (custom_back_sb && commom_back_sb != null)
                        commom_back_sb.Dispose();
                    if (custom_text_sb && commom_text_sb != null)
                        commom_text_sb.Dispose();
                }
            }
            foreach (Brush item in brushList)
            {
                if (item != null)
                    item.Dispose();
            }
            foreach (Pen item in penList)
            {
                if (item != null)
                    item.Dispose();
            }

            #region 释放全局画笔

            if (itemborder_pen != null)
                itemborder_pen.Dispose();

            if (itemborder_lgb != null)
                itemborder_lgb.Dispose();

            if (item_normal_back_sb != null)
                item_normal_back_sb.Dispose();
            if (item_enter_back_sb != null)
                item_enter_back_sb.Dispose();
            if (item_selected_back_sb != null)
                item_selected_back_sb.Dispose();
            if (item_disable_back_sb != null)
                item_disable_back_sb.Dispose();

            if (item_normal_text_sb != null)
                item_normal_text_sb.Dispose();
            if (item_enter_text_sb != null)
                item_enter_text_sb.Dispose();
            if (item_selected_text_sb != null)
                item_selected_text_sb.Dispose();
            if (item_disable_text_sb != null)
                item_disable_text_sb.Dispose();

            #endregion

            #endregion

            #region 滚动条
            if (this.mainRealityRect.Height > this.mainRect.Height)
            {
                #region 画笔
                SolidBrush bar_back_sb = null;
                Pen slide_back_pen = null;

                if (this.Enabled)
                {
                    bar_back_sb = new SolidBrush(this.Scroll.BarNormalBackColor);
                    slide_back_pen = new Pen(this.Scroll.SlideStatus == ScrollSlideMoveStatus.Normal ? this.Scroll.SlideNormalBackColor : this.Scroll.SlideEnterBackColor, this.Scroll.Thickness);
                }
                else
                {
                    bar_back_sb = new SolidBrush(this.Scroll.BarDisableBackColor);
                    slide_back_pen = new Pen(this.Scroll.SlideDisableBackColor, this.Scroll.Thickness);
                }

                #endregion

                #region 滑条
                g.FillRectangle(bar_back_sb, this.Scroll.Rect);
                #endregion

                #region  滑块
                PointF sp_start = new PointF(this.Scroll.SlideRect.X + this.Scroll.Thickness / 2, this.Scroll.SlideRect.Y);
                PointF sp_end = new PointF(this.Scroll.SlideRect.X + this.Scroll.Thickness / 2, this.Scroll.SlideRect.Bottom);

                g.DrawLine(slide_back_pen, sp_start, sp_end);
                #endregion

                #region 释放画笔

                if (bar_back_sb != null)
                    bar_back_sb.Dispose();
                if (slide_back_pen != null)
                    slide_back_pen.Dispose();

                #endregion
            }
            #endregion

            if (main_region != null)
            {
                g.Clip = client_region;
                main_region.Dispose();
            }

            #endregion

            #region 激活tab边框
            if (this.activatedState && this.activatedStateIndex > -1 && this.activatedStateIndex < this.Items.Count)
            {
                Pen activate_pen = new Pen(this.ActivateColor, 1) { DashStyle = DashStyle.Dash, Alignment = PenAlignment.Left };
                Item item = this.Items[this.activatedStateIndex];
                Rectangle active_rect = new Rectangle((int)(item.Rect.X + 2), (int)(item.Rect.Y + 2), (int)(item.Rect.Width - 5), (int)(item.Rect.Height - 5));
                g.DrawRectangle(activate_pen, active_rect);
                activate_pen.Dispose();
            }
            #endregion

        }

        protected override void OnEnter(EventArgs e)
        {
            this.activatedState = true;
            this.activatedStateIndex = 0;
            this.Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.Invalidate();
            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.activatedState = true;
            this.activatedStateIndex = 0;
            this.Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            if (this.ResetItemsMouseStatus())
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (!this.Focused)
            {
                this.Focus();
            }

            this.ismovedown = true;
            this.movedownpoint = e.Location;

            if (this.Scroll.Rect.Contains(e.Location))
            {
                if (this.Scroll.SlideRect.Contains(e.Location))
                {
                    this.mousedowninfo.Type = MouseDownTypes.Scroll;
                    this.mousedowninfo.Sender = this.Scroll;
                }
                else
                {
                    this.mousedowninfo.Type = MouseDownTypes.None;
                    this.mousedowninfo.Sender = null;
                }
            }
            else if (this.mainRect.Contains(e.Location))
            {
                Item item = this.FindMouseDownItem(e.Location);
                if (item != null)
                {
                    this.mousedowninfo.Type = MouseDownTypes.MainItem;
                    this.mousedowninfo.Sender = item;
                }
                else
                {
                    this.mousedowninfo.Type = MouseDownTypes.None;
                    this.mousedowninfo.Sender = null;
                }
            }
            else
            {
                this.mousedowninfo.Type = MouseDownTypes.None;
                this.mousedowninfo.Sender = null;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            this.ismovedown = false;
            this.movedownpoint = Point.Empty;
            this.mousedowninfo.Type = MouseDownTypes.None;
            this.mousedowninfo.Sender = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.ismovedown)
            {
                if (this.mousedowninfo.Type == MouseDownTypes.Scroll)
                {
                    if (this.mousedowninfo.Type == MouseDownTypes.Scroll && (ScrollClass)this.mousedowninfo.Sender == this.Scroll)
                    {
                        int offset = (int)((e.Location.Y - this.movedownpoint.Y));
                        this.movedownpoint = e.Location;
                        this.MouseMoveWheel(offset);
                    }
                }
            }
            else
            {
                this.UpdateItemsMouseStatus(e.Location);
            }

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.mousedowninfo.Type == MouseDownTypes.MainItem)
                {
                    this.UpdateItemSelectedStatusForDown((Item)this.mousedowninfo.Sender, e.Location);
                    this.OnItemClick(new ItemClickEventArgs() { Item = (Item)this.mousedowninfo.Sender });
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.activatedState)
            {
                #region Up
                if (keyData == Keys.Up)
                {
                    int tmp_index = this.activatedStateIndex - 1;
                    for (int i = tmp_index; i >= -1; i--)
                    {
                        int index = (i > -1) ? i : this.Items.Count - 1;
                        if (this.Items[index].Enabled)
                        {
                            this.activatedStateIndex = index;
                            this.Invalidate();
                            break;
                        }
                        else if (index == this.Items.Count - 1)
                        {
                            for (int j = index; j > this.activatedStateIndex; j--)
                            {
                                if (this.Items[j].Enabled)
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
                #region Down
                else if (keyData == Keys.Down)
                {
                    int tmp_index = this.activatedStateIndex + 1;
                    for (int i = tmp_index; i <= this.Items.Count; i++)
                    {
                        int index = (i < this.Items.Count) ? i : 0;
                        if (this.Items[index].Enabled)
                        {
                            this.activatedStateIndex = index;
                            this.Invalidate();
                            break;
                        }
                        else if (index == 0)
                        {
                            for (int j = index; j < this.activatedStateIndex; j++)
                            {
                                if (this.Items[j].Enabled)
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
                else if (keyData == Keys.Enter)
                {
                    if (this.activatedStateIndex > -1 && this.activatedStateIndex < this.Items.Count)
                    {
                        Point point = new Point((int)(this.Items[this.activatedStateIndex].Rect.X + 1), (int)(this.Items[this.activatedStateIndex].Rect.Y + 1));
                        this.UpdateItemSelectedStatusForDown(this.Items[this.activatedStateIndex], point);
                        this.OnItemClick(new ItemClickEventArgs() { Item = this.Items[this.activatedStateIndex] });
                        return false;
                    }
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode)
                return;

            int offset = e.Delta > 1 ? -1 : 1;
            this.MouseMoveWheel(offset);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeMainRectangle();
            this.Scroll.Rect = new Rectangle((int)this.ClientRectangle.Right - this.BorderWidth - this.Scroll.Thickness, this.ClientRectangle.Top + this.BorderWidth, this.Scroll.Thickness, this.ClientRectangle.Height - this.BorderWidth * 2);
            this.InitializeMainRealityRectangle();
            this.Invalidate();
        }

        #endregion

        #region 虚方法

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.itemClick != null)
            {
                this.itemClick(this, e);
            }
        }

        protected virtual void OnItemSelectedChanged(ItemSelectedChangedEventArgs e)
        {
            if (this.itemSelectedChanged != null)
            {
                this.itemSelectedChanged(this, e);
            }
        }

        protected virtual void OnSelectedIndexChanged(SelectedIndexChangedEventArgs e)
        {
            if (this.selectedIndexChanged != null)
            {
                this.selectedIndexChanged(this, e);
            }
        }

        protected virtual void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.drawItem != null)
            {
                this.drawItem(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件Rect
        /// </summary>
        public void InitializeRectangle()
        {
            this.InitializeMainRectangle();
            this.InitializeMainRealityRectangle();
            this.InitializeScrollRectangle();
            this.UpdateItemsRect();
        }

        /// <summary>
        /// 初始化列表区域Rect
        /// </summary>
        private void InitializeMainRectangle()
        {
            this.mainRect = new Rectangle(this.ClientRectangle.X + this.BorderWidth, this.ClientRectangle.Top + this.BorderWidth, this.ClientRectangle.Width - this.BorderWidth * 2, this.ClientRectangle.Height - this.BorderWidth * 2);
        }

        /// <summary>
        /// 初始化真实列表区域Rect
        /// </summary>
        protected internal void InitializeMainRealityRectangle()
        {
            this.mainRealityRect = new Rectangle(this.mainRect.X, this.mainRect.Y, this.mainRect.Width, 0);

            int y = this.mainRealityRect.Y;
            if (this.mainRealityRect.Bottom < this.mainRect.Bottom)
            {
                y += (this.mainRect.Bottom - this.mainRealityRect.Bottom);
            }
            if (y > this.mainRect.Y)
            {
                y = this.mainRect.Y;
            }
            this.mainRealityRect = new Rectangle(this.mainRealityRect.X, y, this.mainRealityRect.Width, this.mainRealityRect.Height);

            int h = 0;
            for (int i = 0; i < this.Items.Count; i++)
            {
                h += this.ItemHeight;
                this.Items[i].Rect = new RectangleF(this.mainRect.Left, this.mainRect.Top + i * this.ItemHeight, this.mainRect.Width, this.ItemHeight);
            }
            this.mainRealityRect = new Rectangle(this.mainRealityRect.X, this.mainRealityRect.Y, this.mainRealityRect.Width, h);

            this.UpdateScrollSlideRectLocation();
        }

        /// <summary>
        /// 初始化滚动条Rect
        /// </summary>
        private void InitializeScrollRectangle()
        {
            this.Scroll.Rect = new Rectangle((int)this.mainRect.Right - this.Scroll.Thickness, this.mainRect.Top, this.Scroll.Thickness, this.mainRect.Height);
            float bi = (float)this.mainRect.Height / (float)this.mainRealityRect.Height;
            if (bi > 1)
            {
                bi = 1;
            }
            float slide_height = this.Scroll.Rect.Height * bi;
            if (slide_height < this.Scroll.SlideMinHeight)
            {
                slide_height = this.Scroll.SlideMinHeight;
            }
            this.Scroll.SlideRect = new RectangleF(this.Scroll.Rect.X, this.Scroll.Rect.Y, this.Scroll.Thickness, slide_height);
        }

        /// <summary>
        /// 更新所有选项的鼠标状态
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        private void UpdateItemsMouseStatus(Point mousePoint)
        {
            bool result = false;
            bool isInMainRect = this.mainRect.Contains(mousePoint) && !this.Scroll.Rect.Contains(mousePoint);
            foreach (Item item in this.Items)
            {
                if (item.Enabled)
                {
                    if (isInMainRect && item.Rect.Contains(mousePoint))
                    {
                        if (item.MouseStatus == ItemMouseStatuss.Normal)
                        {
                            item.MouseStatus = ItemMouseStatuss.Enter;
                            result = true;
                        }
                    }
                    else
                    {
                        if (item.MouseStatus == ItemMouseStatuss.Enter)
                        {
                            item.MouseStatus = ItemMouseStatuss.Normal;
                            result = true;
                        }
                    }
                }
            }

            if (result)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 重置所有选项鼠标状态
        /// </summary>
        /// <returns></returns>
        private bool ResetItemsMouseStatus()
        {
            bool result = false;
            foreach (Item item in this.Items)
            {
                if (item.MouseStatus != ItemMouseStatuss.Normal)
                {
                    item.MouseStatus = ItemMouseStatuss.Normal;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 查找被按下的选项
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        /// <returns>没有为null</returns>
        private Item FindMouseDownItem(Point mousePoint)
        {
            foreach (Item item in this.Items)
            {
                if (item.Enabled)
                {
                    if (item.Rect.Contains(mousePoint))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 更新选项的选中状态(鼠标点击)
        /// </summary>
        /// <param name="down_item">要判断的选项</param>
        /// <param name="mousePoint">要判断的选项的坐标</param>
        /// <returns></returns>
        private void UpdateItemSelectedStatusForDown(Item down_item, Point mousePoint)
        {
            if (this.Multiple)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Enabled && down_item == this.Items[i] && this.Items[i].Rect.Contains(mousePoint))
                    {
                        this.Items[i].UpdateItemStatus(!this.Items[i].Selected);
                        this.Invalidate();
                        this.OnItemSelectedChanged(new ItemSelectedChangedEventArgs() { Item = this.Items[i] });
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Enabled && down_item == this.Items[i] && this.Items[i].Rect.Contains(mousePoint))
                    {
                        if (this.Items[i].Selected == false)
                        {
                            int index = this.GetSelectedIndex();
                            this.Items[i].UpdateItemStatus(true);
                            this.Invalidate();
                            this.OnItemSelectedChanged(new ItemSelectedChangedEventArgs() { Item = this.Items[i] });


                            if (index > -1 && index != i)
                            {
                                for (int j = 0; j < this.Items.Count; j++)
                                {
                                    if (i != j)
                                    {
                                        this.Items[j].UpdateItemStatus(false);
                                    }
                                }
                                this.OnSelectedIndexChanged(new SelectedIndexChangedEventArgs() { Item = this.Items[i] });
                            }
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 更新选项的选中状态
        /// </summary>
        /// <param name="down_item">要判断的选项</param>
        /// <param name="isselected">是否选中</param>
        /// <returns></returns>
        private void UpdateItemSelectedStatus(Item down_item, bool isselected)
        {
            if (this.Multiple)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Enabled && down_item == this.Items[i])
                    {
                        this.Items[i].UpdateItemStatus(isselected);
                        this.Invalidate();
                        this.OnItemSelectedChanged(new ItemSelectedChangedEventArgs() { Item = this.Items[i] });
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Enabled && down_item == this.Items[i])
                    {
                        if (this.Items[i].Selected == false)
                        {
                            int index = this.GetSelectedIndex();
                            this.Items[i].UpdateItemStatus(true);
                            this.Invalidate();
                            this.OnItemSelectedChanged(new ItemSelectedChangedEventArgs() { Item = this.Items[i] });


                            if (index > -1 && index != i)
                            {
                                for (int j = 0; j < this.Items.Count; j++)
                                {
                                    if (i != j)
                                    {
                                        this.Items[j].UpdateItemStatus(false);
                                    }
                                }
                                this.OnSelectedIndexChanged(new SelectedIndexChangedEventArgs() { Item = this.Items[i] });
                            }
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取选中选项索引（限制于单选）
        /// </summary>
        /// <returns></returns>
        private int GetSelectedIndex()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Selected)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取选中选项索引（限制于多选）
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedIndexs()
        {
            List<int> resultList = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Selected)
                {
                    resultList.Add(i);
                }
            }
            return resultList;
        }

        /// <summary>
        /// 更新滑块的RectLocation
        /// </summary>
        private void UpdateScrollSlideRectLocation()
        {
            float slide_height = this.Scroll.Rect.Height * ((float)this.mainRect.Height / ((float)this.mainRealityRect.Height));
            if (slide_height < this.Scroll.SlideMinHeight)
            {
                slide_height = this.Scroll.SlideMinHeight;
            }
            float h = this.mainRect.Y - this.mainRealityRect.Y;
            if (this.mainRealityRect.Y < 0)
            {
                h = this.mainRect.Y + Math.Abs(this.mainRealityRect.Y);
            }
            float slide_y = this.Scroll.Rect.Y + (this.Scroll.Rect.Height - slide_height) * h / (float)(this.mainRealityRect.Height - this.mainRect.Height);

            this.Scroll.SlideRect = new RectangleF(this.Scroll.Rect.X, slide_y, this.Scroll.SlideRect.Width, slide_height);

        }

        /// <summary>
        /// 更新所有选项Rect
        /// </summary>
        private void UpdateItemsRect()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].Rect = new RectangleF(this.mainRect.Left, this.mainRealityRect.Top + i * this.ItemHeight, this.mainRect.Width, this.ItemHeight);
            }
        }

        /// <summary>
        /// 滚动条移动或鼠标滚轮移动
        /// </summary>
        /// <param name="offset"></param>
        private void MouseMoveWheel(int offset)
        {
            float y = this.Scroll.SlideRect.Y;
            y += offset;
            if (y < this.Scroll.Rect.Y)
            {
                y = this.Scroll.Rect.Y;
            }
            if (y > this.Scroll.Rect.Bottom - this.Scroll.SlideRect.Height)
            {
                y = this.Scroll.Rect.Bottom - this.Scroll.SlideRect.Height;
            }

            this.Scroll.SlideRect = new RectangleF(this.Scroll.SlideRect.Location.X, y, this.Scroll.SlideRect.Width, this.Scroll.SlideRect.Height);

            float bi = (float)(this.Scroll.SlideRect.Y - this.Scroll.Rect.Y) / (float)(this.Scroll.Rect.Height - this.Scroll.SlideRect.Height);

            float scroll_h = this.mainRealityRect.Height - this.mainRect.Height < 0 ? 0 : (this.mainRealityRect.Height - this.mainRect.Height);
            this.mainRealityRect.Y = (int)(this.mainRect.Y - scroll_h * bi);

            this.UpdateItemsRect();
            this.Invalidate();
        }

        /// <summary>
        /// 绘制当前选项
        /// </summary>
        /// <param name="item"></param>
        /// <param name="g"></param>
        /// <param name="image"></param>
        /// <param name="itemborder_pen"></param>
        /// <param name="commom_back_sb"></param>
        /// <param name="commom_text_sb"></param>
        protected virtual void PaintItem(Item item, Graphics g, Image image, Pen itemborder_pen, SolidBrush commom_back_sb, SolidBrush commom_text_sb)
        {
            #region 选项背景
            g.FillRectangle(commom_back_sb, item.Rect);
            #endregion

            #region 选项图片
            int image_padding = 2;
            if (this.ItemImageShow && image != null)
            {
                Rectangle image_rect = new Rectangle((int)(item.Rect.X + image_padding), (int)(item.Rect.Y + (item.Rect.Height - image.Height) / 2), image.Width, image.Height);

                g.DrawImage(image, image_rect);
            }
            #endregion

            #region 选项文本

            SizeF text_size = g.MeasureString(item.Text, this.Font);
            float text_x = this.mainRect.X + (this.ItemImageShow ? (this.ItemImageSize.Width + image_padding * 2) : 0);

            RectangleF text_rect = new RectangleF(text_x, item.Rect.Y + (item.Rect.Height - text_size.Height) / 2f, text_size.Width, text_size.Height);
            g.DrawString(item.Text, this.Font, commom_text_sb, text_rect);

            #endregion

            #region 选项边框
            if (this.ItemBorderStyle != ItemBorderStyles.None)
            {
                g.DrawLine(itemborder_pen, item.Rect.X, item.Rect.Bottom - 1, item.Rect.Right, item.Rect.Bottom - 1);
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageListRecreateHandle(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated)
                return;
            this.Invalidate();
        }

        /// <summary>
        /// 控件分离ImageList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetachImageList(object sender, EventArgs e)
        {
            this.ItemImageList = (ImageList)null;
        }

        #endregion

        #region 类

        /// <summary>
        ///选项集合
        /// </summary>
        [Description("选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ItemCollection : IList, ICollection, IEnumerable
        {
            private ListBoxExt owner = null;

            private ArrayList itemList = new ArrayList();

            public ItemCollection(ListBoxExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                Item[] listArray = new Item[this.itemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (Item)this.itemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.itemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.itemList.Count;
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
                if (!(value is Item))
                {
                    throw new ArgumentException("Item");
                }
                return this.Add((Item)value);
            }

            public int Add(Item item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                item.owner = owner;
                this.itemList.Add(item);
                this.owner.InitializeMainRealityRectangle();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.itemList.Clear();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is Item)
                {
                    return this.Contains((Item)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is Item)
                {
                    return this.itemList.IndexOf(item);
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
                if (!(value is Item))
                {
                    throw new ArgumentException("Item");
                }
                this.Remove((Item)value);
            }

            public void Remove(Item item)
            {
                this.itemList.Remove(item);
                this.owner.InitializeMainRealityRectangle();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.owner.InitializeMainRealityRectangle();
                this.itemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public Item this[int index]
            {
                get
                {
                    return (Item)this.itemList[index];
                }
                set
                {
                    Item item = (Item)value;
                    this.itemList[index] = item;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.itemList[index];
                }
                set
                {
                    Item item = (Item)value;
                    this.itemList[index] = item;
                }
            }

            #endregion
        }

        /// <summary>
        /// 选项
        /// </summary>
        [Description("选项")]
        public class Item
        {
            #region 字段

            protected internal ListBoxExt owner = null;

            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 选项是否启用
            /// </summary>
            [Description("选项是否启用")]
            [DefaultValue(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private ItemMouseStatuss mouseStatus = ItemMouseStatuss.Normal;
            /// <summary>
            /// 选项鼠标状态
            /// </summary>
            [Description("选项鼠标状态")]
            [DefaultValue(ItemMouseStatuss.Normal)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ItemMouseStatuss MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            private bool selected = false;
            /// <summary>
            /// 选项是否选中
            /// </summary>
            [Description("选项是否选中")]
            [DefaultValue(false)]
            public bool Selected
            {
                get { return this.selected; }
                set
                {
                    if (this.selected == value)
                        return;

                    if (this.owner != null)
                    {
                        Point point = new Point((int)(this.Rect.X + 1), (int)(this.Rect.Y + 1));
                        this.owner.UpdateItemSelectedStatus(this, value);
                    }
                }
            }

            private string text = "";
            /// <summary>
            /// 选项文本
            /// </summary>
            [Description("选项文本")]
            [DefaultValue("")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;

                    this.text = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private object data = null;
            /// <summary>
            /// 选项自定义数据
            /// </summary>
            [Description("选项自定义数据")]
            [Browsable(false)]
            public object Data
            {
                get { return this.data; }
                set
                {
                    this.data = value;
                }
            }

            private Image image = null;
            /// <summary>
            /// 列表图片
            /// </summary>
            [Description("列表图片")]
            [DefaultValue(null)]
            public Image Image
            {
                get { return this.image; }
                set
                {
                    if (this.image == value)
                        return;

                    this.image = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 选项Rect
            /// </summary>
            [Description("选项Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            #region 颜色

            private Color normalBackColor = Color.Empty;
            /// <summary>
            /// 选项背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalBackColor
            {
                get { return this.normalBackColor; }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color normalTextColor = Color.Empty;
            /// <summary>
            /// 选项文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项文本颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalTextColor
            {
                get { return this.normalTextColor; }
                set
                {
                    if (this.normalTextColor == value)
                        return;

                    this.normalTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color enterBackColor = Color.Empty;
            /// <summary>
            /// 选项背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterBackColor
            {
                get { return this.enterBackColor; }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color enterTextColor = Color.Empty;
            /// <summary>
            /// 选项文本颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项文本颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterTextColor
            {
                get { return this.enterTextColor; }
                set
                {
                    if (this.enterTextColor == value)
                        return;

                    this.enterTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color selectedBackColor = Color.Empty;
            /// <summary>
            /// 选项背景颜色（选中）(限于MainTab类型)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项背景颜色（选中）(限于MainTab类型)")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color SelectedBackColor
            {
                get { return this.selectedBackColor; }
                set
                {
                    if (this.selectedBackColor == value)
                        return;

                    this.selectedBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color selectedTextColor = Color.Empty;
            /// <summary>
            /// 选项文本颜色（选中）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项文本颜色（选中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color SelectedTextColor
            {
                get { return this.selectedTextColor; }
                set
                {
                    if (this.selectedTextColor == value)
                        return;

                    this.selectedTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color disableBackColor = Color.Empty;
            /// <summary>
            /// 选项背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color DisableBackColor
            {
                get { return this.disableBackColor; }
                set
                {
                    if (this.disableBackColor == value)
                        return;

                    this.disableBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color disableTextColor = Color.Empty;
            /// <summary>
            /// 选项文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 选项文本颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color DisableTextColor
            {
                get { return this.disableTextColor; }
                set
                {
                    if (this.disableTextColor == value)
                        return;

                    this.disableTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            #endregion

            public Item()
            {

            }

            public Item(ListBoxExt owner)
            {
                owner = owner;
            }

            #region

            /// <summary>
            /// 修改选项选中状态但不触发事件和界面刷新
            /// </summary>
            /// <param name="isselected"></param>
            public void UpdateItemStatus(bool isselected)
            {
                this.selected = isselected;
            }

            #endregion

        }

        /// <summary>
        /// 滚动条
        /// </summary>
        [Description("滚动条")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ScrollClass
        {
            #region 字段

            private ListBoxExt owner = null;

            #endregion

            #region 属性

            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// Rect
            /// </summary>
            [Description("Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

            private int thickness = 10;
            /// <summary>
            /// 滑条厚度
            /// </summary>
            [DefaultValue(10)]
            [Description("滑条厚度")]
            [NotifyParentProperty(true)]
            public int Thickness
            {
                get { return this.thickness; }
                set
                {
                    if (this.thickness == value || value < 0)
                        return;

                    this.thickness = value;
                    this.owner.InitializeScrollRectangle();
                    this.owner.Invalidate();
                }
            }

            #region 滑条

            private Color barNormalBackColor = Color.FromArgb(68, 128, 128, 128);
            /// <summary>
            /// 滑条背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "68, 128, 128, 128")]
            [Description("滑条背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color BarNormalBackColor
            {
                get { return this.barNormalBackColor; }
                set
                {
                    if (this.barNormalBackColor == value)
                        return;

                    this.barNormalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color barDisableBackColor = Color.FromArgb(224, 224, 224);
            /// <summary>
            /// 滑条背景颜色（禁止）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "224, 224, 224")]
            [Description("滑条背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color BarDisableBackColor
            {
                get { return this.barDisableBackColor; }
                set
                {
                    if (this.barDisableBackColor == value)
                        return;

                    this.barDisableBackColor = value;
                    this.owner.Invalidate();
                }
            }

            #endregion

            #region 滑块

            private int slideMinHeight = 26;
            /// <summary>
            /// 滑块最小高度
            /// </summary>
            [DefaultValue(26)]
            [Description("滑块最小高度")]
            [NotifyParentProperty(true)]
            public int SlideMinHeight
            {
                get { return this.slideMinHeight; }
                set
                {
                    if (this.slideMinHeight == value || value < 1)
                        return;

                    this.slideMinHeight = value;
                    this.owner.Invalidate();
                }
            }

            private Color slideNormalBackColor = Color.FromArgb(120, 64, 64, 64);
            /// <summary>
            /// 滑块背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "120, 64, 64, 64")]
            [Description("滑块背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SlideNormalBackColor
            {
                get { return this.slideNormalBackColor; }
                set
                {
                    if (this.slideNormalBackColor == value)
                        return;

                    this.slideNormalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color slideEnterBackColor = Color.FromArgb(160, 64, 64, 64);
            /// <summary>
            /// 滑块背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "160,64, 64, 64")]
            [Description("滑块背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SlideEnterBackColor
            {
                get { return this.slideEnterBackColor; }
                set
                {
                    if (this.slideEnterBackColor == value)
                        return;

                    this.slideEnterBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color slideDisableBackColor = Color.FromArgb(192, 192, 192);
            /// <summary>
            /// 滑块背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "192, 192, 192")]
            [Description("滑块背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SlideDisableBackColor
            {
                get { return this.slideDisableBackColor; }
                set
                {
                    if (this.slideDisableBackColor == value)
                        return;

                    this.slideDisableBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private RectangleF slideRect = RectangleF.Empty;
            /// <summary>
            /// 滑块rect
            /// </summary>
            [Description("滑块rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF SlideRect
            {
                get { return this.slideRect; }
                set { this.slideRect = value; }
            }

            private ScrollSlideMoveStatus slideStatus = ScrollSlideMoveStatus.Normal;
            /// <summary>
            /// 滑块鼠标状态
            /// </summary>
            [Browsable(false)]
            [Description("滑块鼠标状态")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ScrollSlideMoveStatus SlideStatus
            {
                get { return this.slideStatus; }
                set { this.slideStatus = value; }
            }
            #endregion

            #endregion

            public ScrollClass(ListBoxExt owner)
            {
                this.owner = owner;
            }

        }

        /// <summary>
        /// 鼠标按下功能类型
        /// </summary>
        [Description("鼠标按下功能类型")]
        protected internal class MouseDownClass
        {
            /// <summary>
            /// 鼠标按下功能类型
            /// </summary>
            [Description("鼠标按下功能类型")]
            public MouseDownTypes Type { get; set; }
            /// <summary>
            /// 鼠标按下功能对象
            /// </summary>
            [Description("鼠标按下功能对象")]
            public object Sender { get; set; }
        }

        /// <summary>
        /// 选项单击事件参数
        /// </summary>
        [Description("选项单击事件参数")]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 选项
            /// </summary>
            [Description("选项")]
            public Item Item { get; set; }
        }

        /// <summary>
        /// 选项选中状态更改事件参数
        /// </summary>
        [Description("选项选中状态更改事件参数")]
        public class ItemSelectedChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 选项
            /// </summary>
            [Description("选项")]
            public Item Item { get; set; }
        }

        /// <summary>
        /// 选中选项更改事件参数(限制于单选)
        /// </summary>
        [Description("选中选项更改事件参数(限制于单选)")]
        public class SelectedIndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 选中选项
            /// </summary>
            [Description("选中选项")]
            public Item Item { get; set; }
        }

        /// <summary>
        /// 选项自定义绘制事件参数
        /// </summary>
        [Description("选项自定义绘制事件参数")]
        public class DrawItemEventArgs : EventArgs
        {
            /// <summary>
            /// Graphics
            /// </summary>
            [Description("Graphics")]
            public Graphics g { get; set; }

            /// <summary>
            /// 当前选项
            /// </summary>
            [Description("当前选项")]
            public Item Item { get; set; }

            /// <summary>
            /// 当前选项图片
            /// </summary>
            [Description("当前选项图片")]
            public Image Image { get; set; }

            /// <summary>
            /// 当前选项背景画笔
            /// </summary>
            [Description("当前选项背景画笔")]
            public SolidBrush BackBrush { get; set; }

            /// <summary>
            /// 当前选项文本画笔
            /// </summary>
            [Description("当前选项文本画笔")]
            public SolidBrush TextBrush { get; set; }

            /// <summary>
            /// 自定义Pen列表(最后自动释放)
            /// </summary>
            [Description("自定义Pen列表(最后自动释放)")]
            public List<Pen> PenList { get; set; }

            /// <summary>
            /// 自定义Brush列表(最后自动释放)
            /// </summary>
            [Description("自定义Brush列表(最后自动释放)")]
            public List<Brush> BrushList { get; set; }

        }

        /// <summary>
        /// ImageList自定义索引管理
        /// </summary>
        [Description("ImageList自定义索引管理")]
        public class Indexer
        {
            private string key = string.Empty;
            private int index = -1;
            private bool useIntegerIndex = true;
            private ImageList imageList;

            public virtual ImageList ImageList
            {
                get
                {
                    return this.imageList;
                }
                set
                {
                    this.imageList = value;
                }
            }

            public virtual string Key
            {
                get
                {
                    return this.key;
                }
                set
                {
                    this.index = -1;
                    this.key = value == null ? string.Empty : value;
                    this.useIntegerIndex = false;
                }
            }

            public virtual int Index
            {
                get
                {
                    return this.index;
                }
                set
                {
                    this.key = string.Empty;
                    this.index = value;
                    this.useIntegerIndex = true;
                }
            }

            public virtual int ActualIndex
            {
                get
                {
                    if (this.useIntegerIndex)
                        return this.Index;
                    if (this.ImageList != null)
                        return this.ImageList.Images.IndexOfKey(this.Key);
                    return -1;
                }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 选项绘制方式
        /// </summary>
        [Description("选项绘制方式")]
        public enum DrawTypes
        {
            /// <summary>
            /// 默认
            /// </summary>
            Default,
            /// <summary>
            /// 自定义
            /// </summary>
            Custom
        }

        /// <summary>
        /// 选项边框风格
        /// </summary>
        [Description("选项边框风格")]
        public enum ItemBorderStyles
        {
            /// <summary>
            /// 没有
            /// </summary>
            None,
            /// <summary>
            /// 线
            /// </summary>
            Line,
            /// <summary>
            /// 渐变线
            /// </summary>
            GradualLine
        }

        /// <summary>
        /// 鼠标单击类型
        /// </summary>
        [Description("鼠标单击类型")]
        protected internal enum MouseDownTypes
        {
            /// <summary>
            /// 空
            /// </summary>
            None,
            /// <summary>
            /// 选项按下
            /// </summary>
            MainItem,
            /// <summary>
            /// 滚动条按下
            /// </summary>
            Scroll
        }

        /// <summary>
        ///选项鼠标状态
        /// </summary>
        [Description("选项鼠标状态")]
        public enum ItemMouseStatuss
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
        /// 滚动条滑块鼠标状态
        /// </summary>
        [Description("滚动条滑块鼠标状态")]
        public enum ScrollSlideMoveStatus
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

        #endregion
    }
}
