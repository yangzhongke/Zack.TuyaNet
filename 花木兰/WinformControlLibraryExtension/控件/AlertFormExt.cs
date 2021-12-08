
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
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WcleAnimationLibrary;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 提示信息窗体
    /// </summary>
    [Description("提示信息窗体")]
    public partial class AlertFormExt : Form
    {
        #region 新增属性

        #region 滚动条

        private int scrollThickness = 10;
        /// <summary>
        /// 滚动条厚度
        /// </summary>
        [DefaultValue(10)]
        [Description("滚动条厚度")]
        public int ScrollThickness
        {
            get { return this.scrollThickness; }
            set
            {
                if (this.scrollThickness == value || value < 0)
                    return;
                this.scrollThickness = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color scrollNormalBackColor = Color.FromArgb(68, 128, 128, 128);
        /// <summary>
        /// 滑条背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "68, 128, 128, 128")]
        [Description("滑条背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollNormalBackColor
        {
            get { return this.scrollNormalBackColor; }
            set
            {
                if (this.scrollNormalBackColor == value)
                    return;
                this.scrollNormalBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 滚动条滑块

        private int scrollSlideThickness = 10;
        /// <summary>
        /// 滑块条厚度
        /// </summary>
        [DefaultValue(10)]
        [Description("滑块条厚度")]
        public int ScrollSlideThickness
        {
            get { return this.scrollSlideThickness; }
            set
            {
                if (this.scrollSlideThickness == value || value < 0)
                    return;
                this.scrollSlideThickness = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color scrollSlideNormalBackColor = Color.FromArgb(120, 64, 64, 64);
        /// <summary>
        /// 滑块背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "120, 64, 64, 64")]
        [Description("滑块背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollSlideNormalBackColor
        {
            get { return this.scrollSlideNormalBackColor; }
            set
            {
                if (this.scrollSlideNormalBackColor == value)
                    return;
                this.scrollSlideNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color scrollSlideEnterBackColor = Color.FromArgb(160, 64, 64, 64);
        /// <summary>
        /// 滑块背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "160, 64, 64, 64")]
        [Description("滑块背景颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollSlideEnterBackColor
        {
            get { return this.scrollSlideEnterBackColor; }
            set
            {
                if (this.scrollSlideEnterBackColor == value)
                    return;
                this.scrollSlideEnterBackColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 滚动条按钮

        private bool scrollBtnShow = false;
        /// <summary>
        /// 是否显示按钮
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示按钮")]
        public bool ScrollBtnShow
        {
            get { return this.scrollBtnShow; }
            set
            {
                if (this.scrollBtnShow == value)
                    return;
                this.scrollBtnShow = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int scrollBtnHeight = 10;
        /// <summary>
        /// 按钮高度
        /// </summary>
        [DefaultValue(10)]
        [Description("/// 按钮高度")]
        public int ScrollBtnHeight
        {
            get { return this.scrollBtnHeight; }
            set
            {
                if (this.scrollBtnHeight == value || value < 0)
                    return;
                this.scrollBtnHeight = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color scrollBtnNormalBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 按钮背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("按钮背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnNormalBackColor
        {
            get { return this.scrollBtnNormalBackColor; }
            set
            {
                if (this.scrollBtnNormalBackColor == value)
                    return;
                this.scrollBtnNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color scrollBtnEnterBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 按钮背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("按钮背景颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnEnterBackColor
        {
            get { return this.scrollBtnEnterBackColor; }
            set
            {
                if (this.scrollBtnEnterBackColor == value)
                    return;
                this.scrollBtnEnterBackColor = value;
                this.Invalidate();
            }
        }

        private Color scrollBtnNormalForeColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 按钮颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("按钮颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnNormalForeColor
        {
            get { return this.scrollBtnNormalForeColor; }
            set
            {
                if (this.scrollBtnNormalForeColor == value)
                    return;
                this.scrollBtnNormalForeColor = value;
                this.Invalidate();
            }
        }

        private Color scrollBtnEnterForeColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 按钮颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("按钮颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScrollBtnEnterForeColor
        {
            get { return this.scrollBtnEnterForeColor; }
            set
            {
                if (this.scrollBtnEnterForeColor == value)
                    return;
                this.scrollBtnEnterForeColor = value;
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

        #endregion

        #region 字段

        #region 工具栏

        /// <summary>
        /// 工具栏高度
        /// </summary>
        private int tool_height = 18;
        /// <summary>
        /// 工具栏rect
        /// </summary>
        private RectangleF tool_rect;

        #region 工具栏图标
        /// <summary>
        /// 工具栏图标宽度
        /// </summary>
        private float tool_ico_width = 16;
        /// <summary>
        /// 工具栏图标高度
        /// </summary>
        private float tool_ico_height = 16;
        /// <summary>
        /// 工具栏图标rect
        /// </summary>
        private RectangleF tool_ico_rect;
        #endregion

        #region 工具栏标题
        /// <summary>
        /// 工具栏标题rect
        /// </summary>
        private RectangleF tool_title_rect;
        #endregion

        #region  工具栏复制按钮
        /// <summary>
        /// <summary>
        /// 复制按钮背景色Enter
        /// </summary>
        private Color tool_copy_enter_color = Color.FromArgb(70, 0, 0, 0);
        /// <summary>
        /// 复制按钮鼠标状态
        /// </summary>
        private MoveStatus tool_copy_status = MoveStatus.Normal;
        /// 工具栏复制按钮rect
        /// </summary>
        private RectangleF tool_copy_rect;
        /// <summary>
        /// 工具栏复制按钮图片宽度
        /// </summary>
        private float tool_copy_image_width = 12;
        /// <summary>
        /// 工具栏复制按钮图片高度
        /// </summary>
        private float tool_copy_image_height = 12;
        /// <summary>
        /// 工具栏复制按钮图片
        /// </summary>
        private static Image tool_copy_image = (Image)Resources.复制;
        /// <summary>
        /// 工具栏复制按钮图片rect
        /// </summary>
        private RectangleF tool_copy_image_rect;
        #endregion

        #region  工具栏关闭按钮
        /// <summary>
        /// <summary>
        /// 关闭按钮背景色Enter
        /// </summary>
        private Color tool_close_enter_color = Color.FromArgb(70, 0, 0, 0);
        /// <summary>
        /// 关闭按钮鼠标状态
        /// </summary>
        private MoveStatus tool_close_status = MoveStatus.Normal;
        /// 工具栏关闭按钮rect
        /// </summary>
        private RectangleF tool_close_rect;
        /// <summary>
        /// 工具栏关闭按钮图片宽度
        /// </summary>
        private float tool_close_image_width = 12;
        /// <summary>
        /// 工具栏关闭按钮图片高度
        /// </summary>
        private float tool_close_image_height = 12;
        /// <summary>
        /// 工具栏关闭按钮图片
        /// </summary>
        private static Image tool_close_image = (Image)Resources.关闭;
        /// <summary>
        /// 工具栏关闭按钮图片rect
        /// </summary>
        private RectangleF tool_close_image_rect;
        #endregion

        #endregion

        #region 主容器

        /// <summary>
        /// 主内容rect
        /// </summary>
        private RectangleF content_rect;
        /// <summary>
        /// 提示内容rect
        /// </summary>
        private RectangleF text_rect;
        /// <summary>
        /// 提示内容鼠标状态
        /// </summary>
        private MoveStatus text_status = MoveStatus.Normal;
        /// <summary>
        /// 提示内容真实rect
        /// </summary>
        private RectangleF text_reality_rect;
        /// <summary>
        /// 提示内容左边距
        /// </summary>
        private int text_left_padding = 5;

        #endregion

        #region 滚动条
        /// <summary>
        /// 滚动条
        /// </summary>
        private ScrollItem scroll = new ScrollItem();
        /// <summary>
        /// 滚动条滑块
        /// </summary>
        private ScrollItem scroll_slide = new ScrollItem();
        /// <summary>
        /// 滚动条上滚按钮
        /// </summary>
        private ScrollItem scroll_pre = new ScrollItem();
        /// <summary>
        /// 滚动条下滚按钮
        /// </summary>
        private ScrollItem scroll_next = new ScrollItem();
        #endregion

        /// <summary>
        /// 是否按下鼠标
        /// </summary>
        private bool ismovedown = false;
        /// <summary>
        /// 鼠标按下的坐标
        /// </summary>
        private Point movedownpoint = Point.Empty;

        /// <summary>
        /// 提示信息
        /// </summary>
        private DesktopAlert.AlertItem ai = null;

        #endregion

        #region 扩展
        /// <summary>
        /// 移动鼠标，按住或释放鼠标时发生 
        /// </summary>
        public const int WM_NCHITTEST = 0x0084;

        private const int HTLEFT = 10;

        #endregion

        public AlertFormExt()
        {
            InitializeComponent();
        }

        public AlertFormExt(DesktopAlert.AlertItem ai)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, true);

            this.ai = ai;

            InitializeComponent();

            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = this.ai.Win_Size;
            this.MinimumSize = this.ai.Win_Size;
            this.Location = this.ai.Win_Location;
            this.InitializeRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.ai == null)
                return;

            Graphics g = e.Graphics;
            SolidBrush back_sb = new SolidBrush(this.ai.BackColor);

            #region 背景
            g.FillRectangle(back_sb, new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height));
            #endregion

            #region 提示信息文本
            SolidBrush text_sb = new SolidBrush(this.ai.TextColor);
            StringFormat text_sf = new StringFormat() { Trimming = StringTrimming.Character };
            g.DrawString(this.ai.Text, this.Font, text_sb, this.GetDisplayRectangle(), text_sf);
            text_sf.Dispose();
            text_sb.Dispose();
            #endregion

            #region 滚动条
            if (this.scroll.Rect.Height > this.scroll_slide.Rect.Height)
            {
                #region 画笔
                Pen scroll_normal_back_pen = new Pen(this.ScrollNormalBackColor, this.ScrollThickness);
                Pen scroll_slide_back_pen = new Pen(this.scroll_slide.Status == MoveStatus.Normal ? this.ScrollSlideNormalBackColor : this.ScrollSlideEnterBackColor, this.ScrollSlideThickness);

                SolidBrush scroll_pre_back_sb = new SolidBrush(this.scroll_pre.Status == MoveStatus.Normal ? this.ScrollBtnNormalBackColor : this.ScrollBtnEnterBackColor);
                Pen scroll_pre_pen = new Pen(this.scroll_pre.Status == MoveStatus.Normal ? this.ScrollBtnNormalForeColor : this.ScrollBtnEnterForeColor, this.ScrollThickness - 2) { EndCap = LineCap.Triangle };
                SolidBrush scroll_next_back_sb = new SolidBrush(this.scroll_next.Status == MoveStatus.Normal ? this.ScrollBtnNormalBackColor : this.ScrollBtnEnterBackColor);
                Pen scroll_next_pen = new Pen(this.scroll_next.Status == MoveStatus.Normal ? this.ScrollBtnNormalForeColor : this.ScrollBtnEnterForeColor, this.ScrollThickness - 2) { EndCap = LineCap.Triangle };

                #endregion

                #region 滚动条背景
                Point scroll_start_point = new Point((int)this.scroll.Rect.X + (int)(this.scroll.Rect.Width / 2f), (int)this.scroll.Rect.Y);
                Point scroll_end_point = new Point((int)this.scroll.Rect.X + (int)(this.scroll.Rect.Width / 2f), (int)this.scroll.Rect.Bottom);

                g.DrawLine(scroll_normal_back_pen, scroll_start_point, scroll_end_point);
                #endregion

                #region 滚动条按钮
                g.FillRectangle(scroll_pre_back_sb, this.scroll_pre.Rect);
                g.DrawLine(scroll_pre_pen, new PointF(this.scroll_pre.Rect.X + this.scroll_pre.Rect.Width / 2f, this.scroll_pre.Rect.Bottom - this.scroll_pre.Rect.Height / 3f), new PointF(this.scroll_pre.Rect.X + this.scroll_pre.Rect.Width / 2f, this.scroll_pre.Rect.Bottom - this.scroll_pre.Rect.Height / 3f - 1));

                g.FillRectangle(scroll_next_back_sb, this.scroll_next.Rect);
                g.DrawLine(scroll_next_pen, new PointF(this.scroll_next.Rect.X + this.scroll_next.Rect.Width / 2f, this.scroll_next.Rect.Y + this.scroll_pre.Rect.Height / 3f), new PointF(this.scroll_next.Rect.X + this.scroll_next.Rect.Width / 2f, this.scroll_next.Rect.Y + this.scroll_pre.Rect.Height / 3f + 1));

                #endregion

                #region  滚动条滑块
                Point scroll_slide_start_point = new Point((int)this.scroll_slide.Rect.X + (int)(this.scroll_slide.Rect.Width / 2f), (int)this.scroll_slide.Rect.Y);
                Point scroll_slide_end_point = new Point((int)this.scroll_slide.Rect.X + (int)(this.scroll_slide.Rect.Width / 2f), (int)this.scroll_slide.Rect.Bottom);

                g.DrawLine(scroll_slide_back_pen, scroll_slide_start_point, scroll_slide_end_point);
                #endregion

                #region 释放画笔
                scroll_normal_back_pen.Dispose();
                scroll_slide_back_pen.Dispose();
                if (scroll_pre_back_sb != null)
                    scroll_pre_back_sb.Dispose();
                if (scroll_pre_pen != null)
                    scroll_pre_pen.Dispose();
                if (scroll_next_back_sb != null)
                    scroll_next_back_sb.Dispose();
                if (scroll_next_pen != null)
                    scroll_next_pen.Dispose();
                #endregion
            }
            #endregion

            #region 工具栏

            #region 工具栏背景
            g.FillRectangle(back_sb, this.tool_rect);
            #endregion

            #region 工具栏图标
            if (this.ai.Image != null)
            {
                g.DrawImage(this.ai.Image, this.tool_ico_rect);
            }
            #endregion

            #region 工具栏标题
            if (!String.IsNullOrWhiteSpace(this.ai.Title))
            {
                SolidBrush title_sb = new SolidBrush(this.ai.TextColor);
                StringFormat title_sf = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.MeasureTrailingSpaces) { LineAlignment = StringAlignment.Center };
                g.DrawString(this.ai.Title, this.Font, title_sb, this.tool_title_rect, title_sf);
                title_sf.Dispose();
                title_sb.Dispose();
            }
            #endregion

            #region 工具栏复制按钮
            if (this.tool_copy_status == MoveStatus.Enter)
            {
                SolidBrush tool_copy_enter_sb = new SolidBrush(this.tool_copy_enter_color);
                g.FillRectangle(tool_copy_enter_sb, this.tool_copy_rect);
                tool_copy_enter_sb.Dispose();
            }
            g.DrawImage(tool_copy_image, this.tool_copy_image_rect);
            #endregion

            #region 工具栏关闭按钮
            if (this.tool_close_status == MoveStatus.Enter)
            {
                SolidBrush tool_close_enter_sb = new SolidBrush(this.tool_close_enter_color);
                g.FillRectangle(tool_close_enter_sb, this.tool_close_rect);
                tool_close_enter_sb.Dispose();
            }
            g.DrawImage(tool_close_image, this.tool_close_image_rect);
            #endregion

            #endregion

            back_sb.Dispose();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            #region 关闭
            if (this.tool_close_status != MoveStatus.Normal)
            {
                this.tool_close_status = MoveStatus.Normal;
            }
            #endregion
            #region 复制
            if (this.tool_copy_status != MoveStatus.Normal)
            {
                this.tool_copy_status = MoveStatus.Normal;
            }
            #endregion
            #region 滚动条
            if (this.scroll_pre.Status != MoveStatus.Normal)
            {
                this.scroll_pre.Status = MoveStatus.Normal;
            }
            if (this.scroll_next.Status != MoveStatus.Normal)
            {
                this.scroll_next.Status = MoveStatus.Normal;
            }
            if (this.scroll_slide.Status != MoveStatus.Normal)
            {
                this.scroll_slide.Status = MoveStatus.Normal;
            }
            #endregion

            this.ismovedown = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            this.ismovedown = true;
            this.movedownpoint = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            this.ismovedown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            bool isreset = false;

            if (!ismovedown)
            {
                #region 关闭
                if (this.tool_close_rect.Contains(e.Location))
                {
                    if (this.tool_close_status != MoveStatus.Enter)
                    {
                        this.tool_close_status = MoveStatus.Enter;
                        this.Cursor = Cursors.Hand;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.tool_close_status != MoveStatus.Normal)
                    {
                        this.tool_close_status = MoveStatus.Normal;
                        this.Cursor = Cursors.Default;
                        isreset = true;
                    }
                }
                #endregion
                #region 复制
                if (this.tool_copy_rect.Contains(e.Location))
                {
                    if (this.tool_copy_status != MoveStatus.Enter)
                    {
                        this.tool_copy_status = MoveStatus.Enter;
                        this.Cursor = Cursors.Hand;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.tool_copy_status != MoveStatus.Normal)
                    {
                        this.tool_copy_status = MoveStatus.Normal;
                        this.Cursor = Cursors.Default;
                        isreset = true;
                    }
                }
                #endregion
                #region 滚动条
                #region  scroll
                if (this.scroll.Rect.Contains(e.Location))
                {
                    if (this.scroll.Status != MoveStatus.Enter)
                    {
                        this.scroll.Status = MoveStatus.Enter;
                        isreset = true;
                        this.Focus();
                    }
                }
                else
                {
                    if (this.scroll.Status != MoveStatus.Normal)
                    {
                        this.scroll.Status = MoveStatus.Normal;
                        isreset = true;
                        this.Focus();
                    }
                }
                #endregion
                #region scroll_pre
                if (this.scroll_pre.Rect.Contains(e.Location))
                {
                    if (this.scroll_pre.Status != MoveStatus.Enter)
                    {
                        this.scroll_pre.Status = MoveStatus.Enter;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.scroll_pre.Status != MoveStatus.Normal)
                    {
                        this.scroll_pre.Status = MoveStatus.Normal;
                        isreset = true;
                    }
                }
                #endregion
                #region scroll_next
                if (this.scroll_next.Rect.Contains(e.Location))
                {
                    if (this.scroll_next.Status != MoveStatus.Enter)
                    {
                        this.scroll_next.Status = MoveStatus.Enter;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.scroll_next.Status != MoveStatus.Normal)
                    {
                        this.scroll_next.Status = MoveStatus.Normal;
                        isreset = true;
                    }
                }
                #endregion
                #region scroll_slide
                if (this.scroll_slide.Rect.Contains(e.Location))
                {
                    if (this.scroll_slide.Status != MoveStatus.Enter)
                    {
                        this.scroll_slide.Status = MoveStatus.Enter;
                        isreset = true;
                    }
                }
                else
                {
                    if (this.scroll_slide.Status != MoveStatus.Normal)
                    {
                        this.scroll_slide.Status = MoveStatus.Normal;
                        isreset = true;
                    }
                }
                #endregion
                #endregion
                #region 文本
                if (this.text_rect.Contains(e.Location))
                {
                    if (this.text_status != MoveStatus.Enter)
                    {
                        this.text_status = MoveStatus.Enter;
                    }
                }
                else
                {
                    if (this.text_status != MoveStatus.Normal)
                    {
                        this.text_status = MoveStatus.Normal;
                    }
                }
                #endregion
            }

            if (this.ismovedown && this.scroll.Status == MoveStatus.Enter)
            {
                int offset = (int)((e.Location.Y - this.movedownpoint.Y));
                if (this.IsResetScroll(offset))
                {
                    this.movedownpoint = e.Location;
                    isreset = true;
                }
            }

            if (isreset)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                #region 关闭
                if (this.tool_close_status == MoveStatus.Enter)
                {
                    this.ai.Status = this.ai.Status | DesktopAlert.AnimationStatuss.Closeing;
                    this.ai.Close_origin = this.Opacity;
                    this.ai.Close_transform = -this.Opacity;
                    this.ai.Close_usedTime = 0;
                    this.ai.Close_allTime = DesktopAlert.DefaultAllTime;

                    this.ai.Slide_transform = 0;
                    this.ai.Slide_usedTime = 0;
                    this.ai.Slide_allTime = 0;

                    if (!DesktopAlert.AnimationTime.Enabled)
                    {
                        DesktopAlert.AnimationTime.Enabled = true;
                    }
                }
                #endregion
                #region 复制
                else if (this.tool_copy_status == MoveStatus.Enter)
                {
                    Clipboard.SetDataObject(this.ai.Text);
                }
                #endregion
                #region 上滚动
                else if (this.scroll_pre.Status == MoveStatus.Enter)
                {
                    if (this.IsResetScroll(-1))
                    {
                        this.Invalidate();
                    }
                }
                #endregion
                #region 下滚动
                else if (this.scroll_next.Status == MoveStatus.Enter)
                {
                    if (this.IsResetScroll(1))
                    {
                        this.Invalidate();
                    }
                }
                #endregion
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode)
                return;

            if (this.scroll.Status == MoveStatus.Enter || this.text_status == MoveStatus.Enter)
            {
                int offset = e.Delta > 1 ? -1 : 1;
                if (this.IsResetScroll(offset))
                {
                    this.Invalidate();
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    {
                        base.WndProc(ref m);
                        Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = this.PointToClient(vPoint);
                        if (vPoint.X <= 10)
                        {
                            m.Result = (IntPtr)HTLEFT;//窗体左拉伸
                        }
                        break;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeRectangle();
            this.Invalidate();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 重置信息窗体大小和坐标
        /// </summary>
        public void ResetAlertLocationSize()
        {
            this.SetBoundsCore(this.ai.Win_Location.X, this.ai.Win_Location.Y, this.ai.Win_Size.Width, this.ai.Win_Size.Height, BoundsSpecified.All);
            this.InitializeRectangle();
            this.Invalidate();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeRectangle()
        {
            this.tool_rect = new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.tool_height);


            float toolico_x = this.tool_rect.X + (this.tool_height - this.tool_ico_width) / 2f;
            float toolico_y = this.tool_rect.Y + (this.tool_height - this.tool_ico_height) / 2f;
            this.tool_ico_rect = new RectangleF(toolico_x, toolico_y, this.tool_ico_width, this.tool_ico_height);


            this.tool_close_rect = new RectangleF(this.tool_rect.Right - this.tool_height, this.tool_rect.Y, this.tool_height, this.tool_height);
            float tool_close_image_x = this.tool_close_rect.X + (this.tool_close_rect.Width - this.tool_close_image_width) / 2;
            float tool_close_image_y = this.tool_close_rect.Y + (this.tool_close_rect.Height - this.tool_close_image_height) / 2;
            this.tool_close_image_rect = new RectangleF(tool_close_image_x, tool_close_image_y, this.tool_close_image_width, this.tool_close_image_height);

            float tool_copy_right_padding = 10;
            this.tool_copy_rect = new RectangleF(this.tool_close_rect.X - tool_copy_right_padding - this.tool_height, this.tool_rect.Y, this.tool_height, this.tool_height);
            float tool_copy_image_x = this.tool_copy_rect.X + (this.tool_copy_rect.Width - this.tool_copy_image_width) / 2;
            float tool_copy_image_y = this.tool_copy_rect.Y + (this.tool_copy_rect.Height - this.tool_copy_image_height) / 2;
            this.tool_copy_image_rect = new RectangleF(tool_copy_image_x, tool_copy_image_y, this.tool_copy_image_width, this.tool_copy_image_height);


            float tooltitle_x = this.tool_ico_rect.Right + (this.tool_height - this.tool_ico_width) / 2f;
            this.tool_title_rect = new RectangleF(tooltitle_x, this.tool_rect.Y, this.tool_rect.Width - tooltitle_x - this.tool_close_rect.Width, this.tool_height);


            this.content_rect = new RectangleF(this.ClientRectangle.X, this.tool_rect.Bottom, this.ClientRectangle.Width, this.ClientRectangle.Height - this.tool_height);
            this.text_rect = new RectangleF(this.content_rect.X + this.text_left_padding, this.content_rect.Y, this.content_rect.Width - this.text_left_padding - this.ScrollThickness, this.content_rect.Height);
            Graphics g = this.CreateGraphics();
            StringFormat text_sf = new StringFormat() { Trimming = StringTrimming.Character };
            SizeF text_size = g.MeasureString(this.ai.Text, this.Font, (int)this.text_rect.Width, text_sf);
            text_sf.Dispose();
            g.Dispose();
            this.text_reality_rect = new RectangleF(text_rect.Location, text_size);


            if (this.ScrollBtnShow)
            {
                this.scroll_pre.Rect = new RectangleF(this.ClientRectangle.Right - this.ScrollThickness, this.tool_rect.Bottom, this.ScrollThickness, this.ScrollBtnHeight);
                this.scroll_next.Rect = new RectangleF(this.ClientRectangle.Right - this.ScrollThickness, this.ClientRectangle.Bottom - this.ScrollBtnHeight, this.ScrollThickness, this.ScrollBtnHeight);
            }
            else
            {
                this.scroll_pre.Rect = new RectangleF(0, this.content_rect.Y, 0, 0);
                this.scroll_next.Rect = new RectangleF(this.ClientRectangle.Right - this.ScrollThickness, this.ClientRectangle.Bottom, 0, 0);
            }
            this.scroll.Rect = new RectangleF(this.content_rect.Right - this.ScrollThickness, this.content_rect.Y + this.scroll_pre.Rect.Height, this.ScrollThickness, this.content_rect.Height - this.scroll_pre.Rect.Height - this.scroll_next.Rect.Height);
            float slide_h = (this.text_rect.Height / this.text_reality_rect.Height * this.scroll.Rect.Height);
            if (this.text_reality_rect.Height <= this.text_rect.Height)
            {
                slide_h = this.scroll.Rect.Height;
            }
            this.scroll_slide.Rect = new RectangleF(this.scroll.Rect.X, this.scroll_pre.Rect.Bottom, this.ScrollThickness, slide_h);
        }

        /// <summary>
        /// 判断是否需要更新滚动条UI根据滚动条滑块偏移量
        /// </summary>
        /// <param name="offset">滚动条滑块偏移量</param>
        /// <returns>是否要刷新</returns>
        private bool IsResetScroll(int offset)
        {
            float y = this.scroll_slide.Rect.Y + offset;
            if (y < this.scroll.Rect.Y)
                y = this.scroll.Rect.Y;
            if (y > this.scroll.Rect.Bottom - this.scroll_slide.Rect.Height)
                y = this.scroll.Rect.Bottom - this.scroll_slide.Rect.Height;

            bool result = !(this.scroll_slide.Rect.Y == y);
            this.scroll_slide.Rect = new RectangleF(this.scroll_slide.Rect.X, y, this.scroll_slide.Rect.Width, this.scroll_slide.Rect.Height);
            return result;
        }

        /// <summary>
        /// 获取文本Y坐标
        /// </summary>
        /// <returns></returns>
        private int GetDisplayY()
        {
            float y = 0;
            if (this.scroll.Rect.Height > this.scroll_slide.Rect.Height)
            {
                y = -(this.scroll_slide.Rect.Y - this.scroll_pre.Rect.Bottom) / (this.scroll.Rect.Height - this.scroll_slide.Rect.Height) * (this.text_reality_rect.Height - this.text_rect.Height);
            }
            return (int)(this.text_rect.Y + y);
        }

        /// <summary>
        /// 获取文本rect
        /// </summary>
        /// <returns></returns>
        private Rectangle GetDisplayRectangle()
        {
            return new Rectangle(this.text_left_padding, this.GetDisplayY(), (int)this.text_rect.Width, (int)this.text_reality_rect.Height);
        }

        #endregion

        #region 类

        /// <summary>
        /// 滚动条选项信息
        /// </summary>
        [Description("滚动条选项信息")]
        public class ScrollItem
        {
            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 选项rect
            /// </summary>
            public RectangleF Rect
            {
                get { return this.rect; }
                set { this.rect = value; }
            }

            private MoveStatus status = MoveStatus.Normal;
            /// <summary>
            /// 选项鼠标状态
            /// </summary>
            public MoveStatus Status
            {
                get { return this.status; }
                set { this.status = value; }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鼠标状态
        /// </summary>
        [Description("鼠标状态")]
        public enum MoveStatus
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

    /// <summary>
    /// 提示信息工具类
    /// </summary>
    [Description("提示信息工具类")]
    public static class DesktopAlert
    {
        #region 属性

        #region  通知栏
        private static NotifyIcon notify = new NotifyIcon();
        /// <summary>
        /// 通知栏
        /// </summary>
        public static NotifyIcon Notify
        {
            get { return DesktopAlert.notify; }
            set { DesktopAlert.notify = value; }
        }

        private static ContextMenuStrip cms = new ContextMenuStrip();
        /// <summary>
        /// 通知栏右键菜单
        /// </summary>
        public static ContextMenuStrip Cms
        {
            get { return DesktopAlert.cms; }
            set { DesktopAlert.cms = value; }
        }

        #endregion

        #region 提示信息窗体

        private static Size defaultSize = new Size(300, 100);
        /// <summary>
        ///  提示信息窗体默认size
        /// </summary>
        public static Size DefaultSize
        {
            get { return DesktopAlert.defaultSize; }
            set { DesktopAlert.defaultSize = value; }
        }

        public static double defaultAllTime = 100;
        /// <summary>
        ///  动画总默认时间
        /// </summary>
        public static double DefaultAllTime
        {
            get { return DesktopAlert.defaultAllTime; }
            set { DesktopAlert.defaultAllTime = value; }
        }

        private static Timer snimationTime = new Timer();
        /// <summary>
        /// 动画定时器
        /// </summary>
        public static Timer AnimationTime
        {
            get { return DesktopAlert.snimationTime; }
            set { DesktopAlert.snimationTime = value; }
        }
        #endregion

        private static List<AlertItem> alertItemList = new List<AlertItem>();
        /// <summary>
        /// 提示信息集合
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<AlertItem> AlertItemList
        {
            get { return DesktopAlert.alertItemList; }
            set { DesktopAlert.alertItemList = value; }
        }

        #endregion

        #region 字段

        #region 声音
        /// <summary>
        /// 是否播放提示声音
        /// </summary>
        private static bool isPlayMisc = true;
        #endregion

        #region  通知栏
        /// <summary>
        /// 通知栏定时器已累加的时间
        /// </summary>
        private static int notifyAccumulationTime = 0;
        /// <summary>
        /// 通知栏正常图标
        /// </summary>
        private static Icon normalNotifyIco = Resources.通知栏正常图标;
        /// <summary>
        /// 通知栏错误闪烁图标
        /// </summary>
        private static Icon twink_cuowuNotifyIco = Resources.通知栏错误闪烁图标;
        /// <summary>
        /// 通知栏警告闪烁图标
        /// </summary>
        private static Icon twink_jinggaoNotifyIco = Resources.通知栏警告闪烁图标;
        /// <summary>
        /// 通知栏通过闪烁图标
        /// </summary>
        private static Icon twink_tongguoNotifyIco = Resources.通知栏通过闪烁图标;
        /// <summary>
        /// 通知栏通知闪烁图标
        /// </summary>
        private static Icon twink_tongzhiNotifyIco = Resources.通知栏通知闪烁图标;
        /// <summary>
        /// 通知栏疑问闪烁图标
        /// </summary>
        private static Icon twink_yiwenNotifyIco = Resources.通知栏疑问闪烁图标;
        /// <summary>
        /// 通知栏当前为正常图标
        /// </summary>
        private static bool currentNormalNotifyIco = true;
        /// <summary>
        /// 关闭全部信息
        /// </summary>
        private static ToolStripMenuItem close_ToolStripItem;
        /// <summary>
        /// 隐藏全部信息
        /// </summary>
        private static ToolStripMenuItem hide_ToolStripItem;
        /// <summary>
        /// 最前端
        /// </summary>
        private static ToolStripMenuItem topMost_ToolStripItem;
        /// <summary>
        /// 声音提示
        /// </summary>
        private static ToolStripMenuItem misc_ToolStripItem;
        /// <summary>
        /// 声音提示类型
        /// </summary>
        private static ToolStripMenuItem misctype_ToolStripItem;
        /// <summary>
        /// 声音提示global
        /// </summary>
        private static ToolStripMenuItem misc_global_ToolStripItem;
        /// <summary>
        /// 声音提示msg
        /// </summary>
        private static ToolStripMenuItem misc_msg_ToolStripItem;
        /// <summary>
        /// 声音提示shake
        /// </summary>
        private static ToolStripMenuItem misc_shake_ToolStripItem;
        /// <summary>
        /// 当前提示信息类型
        /// </summary>
        public static MessageType CurrentMessageType = MessageType.None;
        #endregion

        #region 提示信息窗体
        /// <summary>
        /// 提示信息窗体是否置顶
        /// </summary>
        private static bool isTopMost = true;
        /// <summary>
        /// 提示信息窗体边距
        /// </summary>
        private static int margin = 2;
        #endregion

        /// <summary>
        /// 提示信息集合线程安全
        /// </summary>
        private static object alert_obj = new object();

        /// <summary>
        /// 是否接收到新的提示信息
        /// </summary>
        private static bool isNewAlert = false;

        /// <summary>
        /// 允许同时显示提示信息窗口最大数量
        /// </summary>
        private static int maxWinCount = 20;
        /// <summary>
        /// 当前已显示提示信息窗口数量
        /// </summary>
        private static int currentWinCount = 0;
        /// <summary>
        /// 是否隐藏提示信息
        /// </summary>
        private static bool isHideAlert = false;

        #endregion

        static DesktopAlert()
        {
            AnimationTime.Interval = 20;
            AnimationTime.Tick += new EventHandler(AnimationTime_Tick);
            Notify.Icon = normalNotifyIco;
            Notify.ContextMenuStrip = Cms;

            close_ToolStripItem = new ToolStripMenuItem("关闭全部信息");
            close_ToolStripItem.Click += ToolStripItem_CloseClick;
            Cms.Items.Add(close_ToolStripItem);

            hide_ToolStripItem = new ToolStripMenuItem("隐藏全部信息");
            hide_ToolStripItem.Click += ToolStripItem_HideClick;
            Cms.Items.Add(hide_ToolStripItem);

            topMost_ToolStripItem = new ToolStripMenuItem("最前端");
            topMost_ToolStripItem.CheckState = isTopMost ? CheckState.Checked : CheckState.Unchecked;
            topMost_ToolStripItem.Click += ToolStripItem_TopMostClick;
            Cms.Items.Add(topMost_ToolStripItem);

            misc_ToolStripItem = new ToolStripMenuItem("声音提示");
            misc_ToolStripItem.CheckState = isPlayMisc ? CheckState.Checked : CheckState.Unchecked;
            misc_ToolStripItem.Click += ToolStripItem_MiscClick;
            Cms.Items.Add(misc_ToolStripItem);

            misctype_ToolStripItem = new ToolStripMenuItem("声音提示类型");
            Cms.Items.Add(misctype_ToolStripItem);

            misc_shake_ToolStripItem = new ToolStripMenuItem("shake");
            misc_shake_ToolStripItem.CheckState = CheckState.Checked;
            misc_shake_ToolStripItem.Click += new EventHandler(ToolStripItem_MiscTypeClick);
            misctype_ToolStripItem.DropDownItems.Add(misc_shake_ToolStripItem);

            misc_msg_ToolStripItem = new ToolStripMenuItem("msg");
            misc_msg_ToolStripItem.CheckState = CheckState.Unchecked;
            misc_msg_ToolStripItem.Click += new EventHandler(ToolStripItem_MiscTypeClick);
            misctype_ToolStripItem.DropDownItems.Add(misc_msg_ToolStripItem);

            misc_global_ToolStripItem = new ToolStripMenuItem("Global");
            misc_global_ToolStripItem.CheckState = CheckState.Unchecked;
            misc_global_ToolStripItem.Click += new EventHandler(ToolStripItem_MiscTypeClick);
            misctype_ToolStripItem.DropDownItems.Add(misc_global_ToolStripItem);

            Notify.Click += new EventHandler(Notify_Click);
        }

        #region 公开方法

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="title">提示标题</param>
        /// <param name="text">提示信息</param>
        /// <param name="type">提示信息类型</param>
        /// <param name="customAlertBackColor">自定义背景颜色</param>
        /// <param name="customAlertTextColor">自定义文本颜色</param>
        public static void ShowAlert(string title, string text, MessageType type, Color? customAlertBackColor = null, Color? customAlertTextColor = null)
        {
            if (Notify.Visible)
            {
                SetCount(AlertItemList.Count + 1);
                CurrentMessageType = type;

                Point location = new Point(SystemInformation.WorkingArea.Right - DefaultSize.Width - margin, (AlertItemList.Count == 0 ? SystemInformation.WorkingArea.Bottom : AlertItemList[AlertItemList.Count - 1].Win_Location.Y) - DefaultSize.Height - margin);
                AlertItem ai = new AlertItem()
                {
                    MsgType = type,
                    Title = title,
                    Text = text,
                    Win_Size = new Size(DefaultSize.Width, DefaultSize.Height),
                    Win_Location = location,
                    Status = AnimationStatuss.none,
                    Slide_origin = location.Y,
                    IsShow = ((isHideAlert || currentWinCount >= maxWinCount) ? false : true)
                };
                AlertFormExt awe = new AlertFormExt(ai) { TopMost = isTopMost };
                ai.Win = awe;
                ai.Handle = awe.Handle;
                switch (type)
                {
                    case MessageType.错误:
                        ai.Image = Resources.错误;
                        ai.BackColor = ColorTranslator.FromHtml("#f56c6d");
                        ai.TextColor = Color.White;
                        break;
                    case MessageType.警告:
                        ai.Image = Resources.警告;
                        ai.BackColor = ColorTranslator.FromHtml("#ffc107");
                        ai.TextColor = Color.White;
                        break;
                    case MessageType.通过:
                        ai.Image = Resources.通过;
                        ai.BackColor = ColorTranslator.FromHtml("#8cbb19");
                        ai.TextColor = Color.White;
                        break;
                    case MessageType.通知:
                        ai.Image = Resources.通知;
                        ai.BackColor = ColorTranslator.FromHtml("#7dc5eb");
                        ai.TextColor = Color.White;
                        break;
                    case MessageType.疑问:
                        ai.Image = Resources.疑问;
                        ai.BackColor = ColorTranslator.FromHtml("#a4579d");
                        ai.TextColor = Color.White;
                        break;
                    default:
                        ai.Image = Resources.自定义;
                        ai.BackColor = customAlertBackColor.Value;
                        ai.TextColor = customAlertTextColor.Value;
                        break;
                }

                AlertItemList.Add(ai);
                awe.ResetAlertLocationSize();
                if (!isHideAlert || ai.IsShow)
                {
                    awe.Show();
                    currentWinCount += 1;
                }

                isNewAlert = true;
                if (isNewAlert)
                {
                    AnimationTime.Enabled = true;
                }

                if (isPlayMisc)
                    PlayMisc();
            }

        }

        /// <summary>
        /// 播放提示音
        /// </summary>
        public static void PlayMisc()
        {
            using (SoundPlayer sp = new SoundPlayer())
            {
                if (misc_shake_ToolStripItem.CheckState == CheckState.Checked)
                {
                    sp.Stream = Resources.shake;
                }
                else if (misc_msg_ToolStripItem.CheckState == CheckState.Checked)
                {
                    sp.Stream = Resources.msg;
                }
                else
                {
                    sp.Stream = Resources.Global;
                }
                sp.LoadAsync();
                sp.Play();
            }
        }

        /// <summary>
        /// 显示通知栏图标
        /// </summary>
        public static void ShowNotify()
        {
            if (!Notify.Visible)
            {
                lock (AlertItemList)
                {
                    AlertItemList.Clear();
                }
                Notify.Visible = true;
            }
        }

        /// <summary>
        /// 隐藏通知栏图标
        /// </summary>
        public static void HideNotify()
        {
            if (Notify.Visible)
            {
                AnimationTime.Enabled = false;
                lock (AlertItemList)
                {
                    foreach (AlertItem item in AlertItemList)
                    {
                        item.Win.Close();
                    }
                    AlertItemList.Clear();
                }
                Notify.Visible = false;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void AnimationTime_Tick(object sender, EventArgs e)
        {
            List<int> closeedlist = new List<int>();
            for (int i = 0; i < AlertItemList.Count; i++)
            {
                #region 关闭
                if (AlertItemList[i].Status.HasFlag(AnimationStatuss.Closeing))
                {
                    if (AlertItemList[i].Close_usedTime > AlertItemList[i].Close_allTime)//已关闭
                    {
                        closeedlist.Add(i);
                        AlertFormExt tmp_daw = AlertItemList[i].Win;
                        Size tmp_size = new Size(AlertItemList[i].Win_Size.Width, AlertItemList[i].Win_Size.Height);
                        AlertItemList[i].Status = AlertItemList[i].Status & ~AnimationStatuss.Closeing;
                        AlertItemList[i].Status = AlertItemList[i].Status | AnimationStatuss.Closeed;
                        AlertItemList[i].Win_Location = new Point(AlertItemList[i].Win_Size.Width, AlertItemList[i].Win_Location.Y + AlertItemList[i].Win_Size.Height);
                        AlertItemList[i].Win_Size = new Size(AlertItemList[i].Win_Size.Width, 0);
                        AlertItemList[i].Win = null;
                        tmp_daw.Close();

                        for (int k = i + 1; k < AlertItemList.Count; k++)
                        {
                            AlertItemList[k].Slide_allTime += DesktopAlert.DefaultAllTime;
                            AlertItemList[k].Slide_transform += tmp_size.Height + margin;
                            AlertItemList[k].Status = AlertItemList[k].Status | AnimationStatuss.Slideing;
                        }
                        currentWinCount -= 1;
                        AutoShowAlert();
                    }
                    else//关闭中
                    {
                        AlertItemList[i].Win.Opacity = AnimationCore.EaseOut(AlertItemList[i].Close_origin, AlertItemList[i].Close_transform, AlertItemList[i].Close_usedTime, AlertItemList[i].Close_allTime, 2);
                        AlertItemList[i].Close_usedTime += AnimationTime.Interval;
                    }
                }
                #endregion

                #region 滑动
                if (AlertItemList[i].Status.HasFlag(AnimationStatuss.Slideing))
                {
                    if (AlertItemList[i].Slide_usedTime > AlertItemList[i].Slide_allTime)
                    {
                        AlertItemList[i].Status = AlertItemList[i].Status & ~AnimationStatuss.Slideing;
                        AlertItemList[i].Status = AlertItemList[i].Status | AnimationStatuss.Slideed;
                    }
                    else
                    {
                        AlertItemList[i].Win_Location = new Point(AlertItemList[i].Win_Location.X, (int)AnimationCore.EaseOut(AlertItemList[i].Slide_origin, AlertItemList[i].Slide_transform, AlertItemList[i].Slide_usedTime, AlertItemList[i].Slide_allTime, 2));
                        AlertItemList[i].Slide_usedTime += AnimationTime.Interval;
                        AlertItemList[i].Win.ResetAlertLocationSize();
                    }
                }
                #endregion
            }

            #region 移除已关闭窗体
            if (closeedlist.Count > 0)
            {
                lock (alert_obj)
                {
                    AlertItem[] alertArr = new AlertItem[DesktopAlert.AlertItemList.Count];
                    DesktopAlert.AlertItemList.CopyTo(alertArr, 0);
                    List<AlertItem> cpList = alertArr.ToList<AlertItem>();
                    for (int i = 0; i < closeedlist.Count; i++)
                    {
                        cpList.Remove(cpList[closeedlist[i]]);
                    }
                    AlertItemList = cpList;
                }
                SetCount(AlertItemList.Count);
            }
            #endregion

            #region  通知栏
            if (isNewAlert)
            {
                if (Notify != null && Notify.Visible)
                {
                    notifyAccumulationTime += AnimationTime.Interval;
                    if (notifyAccumulationTime >= 300)
                    {
                        notifyAccumulationTime = 0;
                        if (currentNormalNotifyIco)
                        {
                            switch (AlertItemList[AlertItemList.Count - 1].MsgType)
                            {
                                case MessageType.错误:
                                    Notify.Icon = twink_cuowuNotifyIco;
                                    break;
                                case MessageType.警告:
                                    Notify.Icon = twink_jinggaoNotifyIco;
                                    break;
                                case MessageType.通过:
                                    Notify.Icon = twink_tongguoNotifyIco;
                                    break;
                                case MessageType.通知:
                                    Notify.Icon = twink_tongzhiNotifyIco;
                                    break;
                                case MessageType.疑问:
                                    Notify.Icon = twink_yiwenNotifyIco;
                                    break;
                                default:
                                    Notify.Icon = normalNotifyIco;
                                    break;
                            }
                            currentNormalNotifyIco = false;
                        }
                        else
                        {
                            Notify.Icon = normalNotifyIco;
                            currentNormalNotifyIco = true;
                        }
                    }
                }

                RectangleF rect = new RectangleF(AlertItemList[AlertItemList.Count - 1].Win.Location.X, AlertItemList[AlertItemList.Count - 1].Win.Location.Y, DefaultSize.Width, AlertItemList[0].Win.Location.Y + AlertItemList[0].Win.Height);
                if (rect.Contains(Control.MousePosition))
                {
                    isNewAlert = false;
                    Notify.Icon = normalNotifyIco;
                }
            }
            #endregion 

            if (isNewAlert == false && AlertItemList.Select(a => a.Status == AnimationStatuss.Slideing || a.Status == AnimationStatuss.Closeing).Count() == 0)
            {
                AnimationTime.Enabled = false;
            }

        }

        /// <summary>
        /// 通知栏单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Notify_Click(object sender, EventArgs e)
        {
            isNewAlert = false;
            Notify.Icon = normalNotifyIco;
            AutoShowAlert();
        }

        /// <summary>
        /// 播放信息提示音类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ToolStripItem_MiscTypeClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem obj = (ToolStripMenuItem)sender;
                if (obj.CheckState == CheckState.Unchecked)
                {
                    foreach (ToolStripMenuItem item in misctype_ToolStripItem.DropDownItems)
                    {
                        item.CheckState = CheckState.Unchecked;
                    }
                    obj.CheckState = CheckState.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 是否播放信息提示音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ToolStripItem_MiscClick(object sender, EventArgs e)
        {
            try
            {
                misc_ToolStripItem.CheckState = misc_ToolStripItem.CheckState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
                isPlayMisc = misc_ToolStripItem.CheckState == CheckState.Checked ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 关闭所有提示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ToolStripItem_CloseClick(object sender, EventArgs e)
        {
            try
            {
                lock (AlertItemList)
                {
                    foreach (AlertItem item in AlertItemList)
                    {
                        item.Win.Close();
                    }
                    AlertItemList.Clear();
                }
                currentWinCount = 0;
                SetCount(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 是否隐藏所有提示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ToolStripItem_HideClick(object sender, EventArgs e)
        {
            try
            {
                hide_ToolStripItem.CheckState = hide_ToolStripItem.CheckState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
                isHideAlert = hide_ToolStripItem.CheckState == CheckState.Checked ? true : false;
                if (!isHideAlert)
                {
                    AutoShowAlert();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 提示信息窗体置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ToolStripItem_TopMostClick(object sender, EventArgs e)
        {
            try
            {
                topMost_ToolStripItem.CheckState = topMost_ToolStripItem.CheckState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
                isTopMost = topMost_ToolStripItem.CheckState == CheckState.Checked ? true : false;
                lock (AlertItemList)
                {
                    foreach (AlertItem item in AlertItemList)
                    {
                        item.Win.TopMost = isTopMost;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 自动显示剩下提示信息
        /// </summary>
        private static void AutoShowAlert()
        {
            lock (AlertItemList)
            {
                foreach (AlertItem item in AlertItemList)
                {
                    if (currentWinCount >= maxWinCount)
                        return;
                    if (!item.IsShow)
                    {
                        item.IsShow = true;
                        currentWinCount += 1;
                        item.Win.ResetAlertLocationSize();
                        item.Win.Show();
                    }
                }
            }

        }

        /// <summary>
        /// 设置信息数量
        /// </summary>
        /// <param name="count"></param>
        private static void SetCount(int count)
        {
            close_ToolStripItem.Text = String.Format("关闭全部信息（{0}）条", count);
        }

        #endregion

        #region 类

        /// <summary>
        /// 提示信息
        /// </summary>
        [Description("提示信息")]
        public class AlertItem
        {
            /// <summary>
            /// 提示信息类型
            /// </summary>
            public DesktopAlert.MessageType MsgType { get; set; }
            /// <summary>
            /// 当前动画状态
            /// </summary>
            public AnimationStatuss Status { get; set; }
            /// <summary>
            /// 提示窗体句柄
            /// </summary>
            public IntPtr Handle { get; set; }
            /// <summary>
            /// 提示窗体
            /// </summary>
            public AlertFormExt Win { get; set; }
            /// <summary>
            /// 提示窗体point
            /// </summary>
            public Point Win_Location { get; set; }
            /// <summary>
            /// 提示窗体size
            /// </summary>
            public Size Win_Size { get; set; }
            /// <summary>
            /// 提示信息标题
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 提示信息
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// 提示信息图标
            /// </summary>
            public Image Image { get; set; }
            /// <summary>
            /// 提示信息背景颜色
            /// </summary>
            public Color BackColor { get; set; }
            /// <summary>
            /// 提示信息文本颜色
            /// </summary>
            public Color TextColor { get; set; }
            /// <summary>
            /// 提示信息窗体是否已显示
            /// </summary>
            public bool IsShow { get; set; }

            /// <summary>
            /// 关闭动画_动画前窗体透明度
            /// </summary>
            public double Close_origin { get; set; }
            /// <summary>
            /// 关闭动画_透明度要改变的值
            /// </summary>
            public double Close_transform { get; set; }
            /// <summary>
            /// 关闭动画_已用时间
            /// </summary>
            public double Close_usedTime { get; set; }
            /// <summary>
            /// 关闭动画_总时间
            /// </summary>
            public double Close_allTime { get; set; }

            /// <summary>
            /// 自动定位滑动动画_滑动前位置
            /// </summary>
            public double Slide_origin { get; set; }
            /// <summary>
            /// 自动定位滑动动画_要滑动的垂直距离
            /// </summary>
            public double Slide_transform { get; set; }
            /// <summary>
            /// 自动定位滑动动画_已用时间
            /// </summary>
            public double Slide_usedTime { get; set; }
            /// <summary>
            /// 自动定位滑动动画_总时间
            /// </summary>
            public double Slide_allTime { get; set; }

        }

        #endregion

        #region 枚举

        /// <summary>
        /// 提示信息类型
        /// </summary>
        [Description("提示信息类型")]
        public enum MessageType
        {
            /// <summary>
            /// 错误信息
            /// </summary>
            错误,
            /// <summary>
            /// 警告信息
            /// </summary>
            警告,
            /// <summary>
            /// 通过信息
            /// </summary>
            通过,
            /// <summary>
            /// 通知信息
            /// </summary>
            通知,
            /// <summary>
            /// 疑问信息
            /// </summary>
            疑问,
            /// <summary>
            /// 自定义信息
            /// </summary>
            自定义,
            /// <summary>
            /// 空（内部使用）
            /// </summary>
            None
        }

        /// <summary>
        /// 动画状态
        /// </summary>
        [Flags]
        [Description("动画状态")]
        public enum AnimationStatuss
        {
            /// <summary>
            /// 默认
            /// </summary>
            none = 2,
            /// <summary>
            /// 自动定位滑动动画中
            /// </summary>
            Slideing = 4,
            /// <summary>
            /// 自动定位滑动动画完成
            /// </summary>
            Slideed = 8,
            /// <summary>
            /// 关闭动画中
            /// </summary>
            Closeing = 16,
            /// <summary>
            /// 关闭动画完成
            /// </summary>
            Closeed = 32
        }

        #endregion

    }

}
