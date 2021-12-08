
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

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// TabControl美化扩展
    /// </summary>
    [ToolboxItem(true)]
    [Description("TabControl美化扩展")]
    public class TabControlExt : TabControl
    {

        #region 新增属性

        private Color backColor = Color.White;
        /// <summary>
        /// TabContorl背景颜色
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("TabContorl背景颜色")]
        [DefaultValue(typeof(Color), "White")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public override Color BackColor
        {
            get { return this.backColor; }
            set
            {
                if (this.backColor == value)
                    return;
                this.backColor = value;
                base.Invalidate(true);
            }
        }

        private Color tabPageBorderColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// TabContorl边框色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("TabContorl边框色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabPageBorderColor
        {
            get { return this.tabPageBorderColor; }
            set
            {
                if (this.tabPageBorderColor == value)
                    return;
                this.tabPageBorderColor = value;
                base.Invalidate(true);
            }
        }

        #region 圆角

        private int tabRadiusLeftTop = 0;
        /// <summary>
        /// 左上角圆角
        /// </summary>
        [Description("左上角圆角")]
        [DefaultValue(0)]
        public int TabRadiusLeftTop
        {
            get { return this.tabRadiusLeftTop; }
            set
            {
                if (this.tabRadiusLeftTop == value)
                    return;
                this.tabRadiusLeftTop = value;
                this.Invalidate();
            }
        }

        private int tabRadiusRightTop = 0;
        /// <summary>
        /// 右上角圆角
        /// </summary>
        [Description("右上角圆角")]
        [DefaultValue(0)]
        public int TabRadiusRightTop
        {
            get { return this.tabRadiusRightTop; }
            set
            {
                if (this.tabRadiusRightTop == value)
                    return;
                this.tabRadiusRightTop = value;
                this.Invalidate();
            }
        }

        private int tabRadiusRightBottom = 0;
        /// <summary>
        /// 右下角圆角
        /// </summary>
        [Description("右下角圆角")]
        [DefaultValue(0)]
        public int TabRadiusRightBottom
        {
            get { return this.tabRadiusRightBottom; }
            set
            {
                if (this.tabRadiusRightBottom == value)
                    return;
                this.tabRadiusRightBottom = value;
                this.Invalidate();
            }
        }

        private int tabRadiusLeftBottom = 0;
        /// <summary>
        /// 左下角圆角
        /// </summary>
        [Description("左下角圆角")]
        [DefaultValue(0)]
        public int TabRadiusLeftBottom
        {
            get { return this.tabRadiusLeftBottom; }
            set
            {
                if (this.tabRadiusLeftBottom == value)
                    return;
                this.tabRadiusLeftBottom = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Tab选项

        private Color tabBackNormalColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// Tab选项背景颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("Tab选项背景颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabBackNormalColor
        {
            get { return this.tabBackNormalColor; }
            set
            {
                if (this.tabBackNormalColor == value)
                    return;
                this.tabBackNormalColor = value;
                base.Invalidate();
            }
        }

        private Color tabBackSelectedColor = Color.FromArgb(201, 153, 204, 153);
        /// <summary>
        /// Tab选项背景颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "201, 153, 204, 153")]
        [Description("Tab选项背景颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabBackSelectedColor
        {
            get { return this.tabBackSelectedColor; }
            set
            {
                if (this.tabBackSelectedColor == value)
                    return;
                this.tabBackSelectedColor = value;
                base.Invalidate();
            }
        }

        private Color tabTextNormalColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// Tab选项文本颜色(正常)
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("Tab选项文本颜色(正常)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabTextNormalColor
        {
            get { return this.tabTextNormalColor; }
            set
            {
                if (this.tabTextNormalColor == value)
                    return;
                this.tabTextNormalColor = value;
                base.Invalidate();
            }
        }

        private Color tabTextSelectedColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// Tab选项文本颜色(选中)
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("Tab选项文本颜色(选中)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabTextSelectedColor
        {
            get { return this.tabTextSelectedColor; }
            set
            {
                if (this.tabTextSelectedColor == value)
                    return;
                this.tabTextSelectedColor = value;
                base.Invalidate();
            }
        }

        private StringAlignment tabTextAlignment = StringAlignment.Near;
        /// <summary>
        /// Tab选项文本对齐方式
        /// </summary>
        [DefaultValue(StringAlignment.Near)]
        [Description("Tab选项文本对齐方式")]
        public StringAlignment TabTextAlignment
        {
            get { return this.tabTextAlignment; }
            set
            {
                if (this.tabTextAlignment == value)
                    return;
                this.tabTextAlignment = value;
                base.Invalidate();
            }
        }

        private bool textVertical = false;
        /// <summary>
        /// Tab选项文本是否垂直
        /// </summary>
        [Description("Tab选项文本是否垂直")]
        [DefaultValue(false)]
        public bool TextVertical
        {
            get { return this.textVertical; }
            set
            {
                if (this.textVertical == value)
                    return;
                this.textVertical = value;
                this.Invalidate();
            }
        }

        private Size tabImageSize = new Size(16, 16);
        /// <summary>
        /// tab选项图标大小
        /// </summary>
        [Description("左下角圆角")]
        [DefaultValue(typeof(Size), "16,16")]
        public Size TabImageSize
        {
            get { return this.tabImageSize; }
            set
            {
                if (this.tabImageSize == value)
                    return;
                this.tabImageSize = value;
                this.Invalidate();
            }
        }

        #endregion

        #region  关闭

        private bool tabCloseShow = false;
        /// <summary>
        /// Tab选项关闭按钮是否显示
        /// </summary>
        [Description("Tab选项关闭按钮是否显示")]
        [DefaultValue(false)]
        public bool TabCloseShow
        {
            get { return this.tabCloseShow; }
            set
            {
                if (this.tabCloseShow == value)
                    return;
                this.tabCloseShow = value;
                this.Invalidate();
            }
        }

        private Size tabCloseSize = new Size(10, 10);
        /// <summary>
        /// Tab关闭按钮Size
        /// </summary>
        [DefaultValue(typeof(Size), "10, 10")]
        [Description("Tab关闭按钮Size")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Size TabCloseSize
        {
            get { return this.tabCloseSize; }
            set
            {
                if (this.tabCloseSize == value)
                    return;
                this.tabCloseSize = value;
                base.Invalidate();
            }
        }
        private Color tabCloseBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// Tab关闭按钮背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("Tab关闭按钮背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TabCloseBackColor
        {
            get { return this.tabCloseBackColor; }
            set
            {
                if (this.tabCloseBackColor == value)
                    return;
                this.tabCloseBackColor = value;
                base.Invalidate();
            }
        }

        #endregion

        #endregion

        #region 重写属性

        [DefaultValue(TabDrawMode.OwnerDrawFixed)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new TabDrawMode DrawMode
        {
            get { return TabDrawMode.OwnerDrawFixed; }
            set { base.DrawMode = TabDrawMode.OwnerDrawFixed; }
        }

        [DefaultValue(TabSizeMode.Fixed)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new TabSizeMode SizeMode
        {
            get { return TabSizeMode.Fixed; }
            set { base.SizeMode = TabSizeMode.Fixed; }
        }

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
                return new Size(300, 200);
            }
        }

        #endregion

        #region 字段

        private int tabImageMarginLeft = 4;

        private int pd = 2;

        private int preNextBtnWidth = 40;

        #endregion

        public TabControlExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            #region 绘制所有Tab选项

            SolidBrush back_normal_sb = new SolidBrush(this.TabBackNormalColor);
            SolidBrush back_selected_sb = new SolidBrush(this.TabBackSelectedColor);
            SolidBrush text_normal_sb = new SolidBrush(this.TabTextNormalColor);
            SolidBrush text_selected_sb = new SolidBrush(this.TabTextSelectedColor);
            StringFormat text_sf = new StringFormat() { Alignment = this.TabTextAlignment, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };
            Pen close_pen = new Pen(this.TabCloseBackColor, 2) { StartCap = LineCap.Round, EndCap = LineCap.Round };

            Rectangle tab_rect = this.GetTabRectangle();
            Region client_region = null;
            Region tabitem_region = null;
            if (this.Alignment == TabAlignment.Top || this.Alignment == TabAlignment.Bottom)
            {
                client_region = g.Clip.Clone();
                tabitem_region = new Region(tab_rect);
                g.Clip = tabitem_region;

            }
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rect = this.GetTabRect(i);
                GraphicsPath path = ControlCommom.TransformCircular(rect, this.TabRadiusLeftTop, this.TabRadiusRightTop, this.TabRadiusRightBottom, this.TabRadiusLeftBottom);

                #region  绘制Tab选项背景颜色
                g.FillPath((i == this.SelectedIndex) ? back_selected_sb : back_normal_sb, path);
                #endregion

                #region 绘制Tab选项图片
                if (this.ImageList != null && this.ImageList.Images.Count > 0)
                {
                    Image img = null;
                    if (this.TabPages[i].ImageIndex > -1)
                    {
                        img = this.ImageList.Images[this.TabPages[i].ImageIndex];
                    }
                    else if (this.TabPages[i].ImageKey.Trim().Length > 0)
                    {
                        img = this.ImageList.Images[this.TabPages[i].ImageKey];
                    }
                    if (img != null)
                    {
                        g.DrawImage(img, rect.X + this.tabImageMarginLeft, rect.Y + (rect.Height - this.TabImageSize.Height) / 2, this.TabImageSize.Width, this.TabImageSize.Height);
                    }
                }
                #endregion

                #region 绘制Tab选项文本
                if (this.ImageList != null && ((this.TabPages[i].ImageIndex > -1) || (this.TabPages[i].ImageKey.Trim().Length > 0)))
                {
                    rect = new Rectangle(rect.Left + this.TabImageSize.Width + this.tabImageMarginLeft * 2, rect.Top, rect.Width - this.TabImageSize.Width - this.tabImageMarginLeft * 2, rect.Height);
                }

                if (this.TextVertical)
                {
                    string text = this.TabPages[i].Text;
                    float sum = 0;
                    SizeF text_size = g.MeasureString(text, this.Font, new PointF(), text_sf);
                    for (int j = 0; j < text.Length; j++)
                    {
                        RectangleF char_rect = new RectangleF(this.Padding.X + rect.X, this.Padding.Y + rect.Y + sum, text_size.Width, text_size.Height + 1);
                        g.DrawString(text.Substring(j, 1), this.Font, (i == this.SelectedIndex) ? text_selected_sb : text_normal_sb, char_rect, text_sf);
                        sum += text_size.Height + 1;
                    }
                }
                else
                {
                    g.DrawString(this.TabPages[i].Text, this.Font, (i == this.SelectedIndex) ? text_selected_sb : text_normal_sb, rect, text_sf);
                }
                #endregion

                #region 绘制关闭按钮
                if (this.TabCloseShow && this.GetIsShowCloseButton(i))
                {
                    RectangleF close_rect = this.GetTabCloseRectangle(i);
                    g.DrawLine(close_pen, new PointF(close_rect.X, close_rect.Y), new PointF(close_rect.Right, close_rect.Bottom));
                    g.DrawLine(close_pen, new PointF(close_rect.Right, close_rect.Y), new PointF(close_rect.Left, close_rect.Bottom));
                }
                #endregion
            }

            if (tabitem_region != null)
            {
                g.Clip = client_region;
                tabitem_region.Dispose();
            }

            if (back_normal_sb != null)
                back_normal_sb.Dispose();
            if (back_selected_sb != null)
                back_selected_sb.Dispose();
            if (text_normal_sb != null)
                text_normal_sb.Dispose();
            if (text_selected_sb != null)
                text_selected_sb.Dispose();
            if (text_sf != null)
                text_sf.Dispose();
            if (close_pen != null)
                close_pen.Dispose();
            #endregion

            #region 设置TabPage内容页边框色
            if (this.TabCount > 0)
            {
                Pen border_pen = new Pen(this.TabPageBorderColor, 1);
                Rectangle borderRect = this.TabPages[0].Bounds;
                borderRect.Inflate(1, 1);
                g.DrawRectangle(border_pen, borderRect);
                border_pen.Dispose();
            }
            #endregion
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.DesignMode)
            {
                if (this.TabCloseShow && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    #region 关闭
                    Rectangle tab_rect = this.GetTabRectangle();
                    if (tab_rect.Contains(e.Location))
                    {
                        for (int i = 0; i < this.TabPages.Count; i++)
                        {
                            if (this.GetTabCloseRectangle(i).Contains(e.Location) && this.GetIsShowCloseButton(i))
                            {
                                int index = 0;
                                if (i >= this.TabPages.Count - 1)
                                {
                                    index = i - 1;
                                    if (i < 0)
                                    {
                                        i = 0;
                                    }
                                }
                                else
                                {
                                    index = i + 1;
                                }
                                this.SelectedIndex = index;
                                this.TabPages.Remove(this.TabPages[i]);
                                return;
                            }
                        }
                    }
                    #endregion
                }
            }

            base.OnMouseClick(e);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取Tab选项区Rectangle
        /// </summary>
        /// <returns></returns>
        private Rectangle GetTabRectangle()
        {
            int tabitem_width = this.TabPages.Count * this.ItemSize.Width;
            if (this.Alignment == TabAlignment.Top || this.Alignment == TabAlignment.Bottom)
            {
                if (tabitem_width > this.ClientRectangle.Width - this.pd * 2)
                {
                    tabitem_width = this.ClientRectangle.Width - this.preNextBtnWidth - this.pd * 2;
                }
            }
            int y = 0;
            if (this.Alignment == TabAlignment.Top)
                y = this.ClientRectangle.Y + this.pd;
            else if (this.Alignment == TabAlignment.Bottom)
                y = this.ClientRectangle.Bottom - this.pd - this.ItemSize.Height;

            return new Rectangle(this.ClientRectangle.X + this.pd, y, tabitem_width, this.ItemSize.Height + this.pd);
        }

        /// <summary>
        /// 获取Tab选项关闭按钮Rectangle
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private RectangleF GetTabCloseRectangle(int index)
        {
            Rectangle rect = this.GetTabRect(index);
            RectangleF close_rect = new RectangleF(rect.Right - 10 - this.TabCloseSize.Width, rect.Y + (rect.Height - this.TabCloseSize.Height) / 2f, this.TabCloseSize.Width, this.TabCloseSize.Height);
            return close_rect;
        }

        /// <summary>
        /// 是否不显示关闭按钮
        /// </summary>
        /// <param name="index"></param>
        private bool GetIsShowCloseButton(int index)
        {
            if (this.TabPages[index].Tag!=null&&this.TabPages[index].Tag.ToString() == "不显示关闭按钮")
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}
