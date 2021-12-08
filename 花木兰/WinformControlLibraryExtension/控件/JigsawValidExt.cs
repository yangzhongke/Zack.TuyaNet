
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
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    ///  拼图滑块验证控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("拼图滑块验证控件")]
    [DefaultProperty("ValidImage")]
    [DefaultEvent("Valided")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class JigsawValidExt : Control
    {
        #region 新增事件

        public delegate void ValidedEventHandler(object sender, ValidedEventArgs e);

        private event ValidedEventHandler valided;

        /// <summary>
        /// 拼图验证事件
        /// </summary>
        [Description("拼图验证事件")]
        public event ValidedEventHandler Valided
        {
            add { this.valided += value; }
            remove { this.valided -= value; }
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

        private SlideTypes slideType = SlideTypes.One;
        /// <summary>
        /// 滑块类型
        /// </summary>
        [DefaultValue(SlideTypes.One)]
        [Description("滑块类型")]
        public SlideTypes SlideType
        {
            get { return this.slideType; }
            set
            {
                this.slideType = value;
                this.ResetJigsaw();
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int slideSize = 36;
        /// <summary>
        /// 滑块大小
        /// </summary>
        [DefaultValue(36)]
        [Description("滑块大小")]
        public int SlideSize
        {
            get { return this.slideSize; }
            set
            {
                if (this.slideSize == value || value < 0)
                    return;
                this.slideSize = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color validBlackColor = Color.FromArgb(60, 0, 0, 0);
        /// <summary>
        /// 验证拼图背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "60, 0, 0, 0")]
        [Description("验证拼图背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ValidBlackColor
        {
            get { return this.validBlackColor; }
            set
            {
                if (this.validBlackColor == value)
                    return;
                this.validBlackColor = value;
                this.Invalidate();
            }
        }

        private Color slideBorderColor = Color.FromArgb(60, 0, 0, 0);
        /// <summary>
        /// 滑块拼图边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "60, 0, 0, 0")]
        [Description("滑块拼图边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SlideBorderColor
        {
            get { return this.slideBorderColor; }
            set
            {
                if (this.slideBorderColor == value)
                    return;
                this.slideBorderColor = value;
                this.Invalidate();
            }
        }

        private bool pass = false;
        /// <summary>
        /// 验证结果
        /// </summary>
        [Browsable(false)]
        [Description("验证结果")]
        public bool Pass
        {
            get { return this.pass; }
        }

        private Image validImage = (Image)null;
        /// <summary>
        /// 验证图片
        /// </summary>
        [Description("验证图片")]
        public Image ValidImage
        {
            get { return this.validImage; }
            set
            {
                if (this.validImage == value)
                    return;
                this.validImage = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

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
                return new Size(300, 200); ;
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

        #region 验证滑块
        /// <summary>
        /// 验证滑块rectf
        /// </summary>
        private RectangleF valid_rectf = RectangleF.Empty;
        private GraphicsPath valid_gp = new GraphicsPath();
        private PointF valid_start_pointf = PointF.Empty;
        #endregion

        #region 滑块一
        /// <summary>
        /// 滑块一rectf
        /// </summary>
        private RectangleF one_rectf = RectangleF.Empty;
        /// <summary>
        /// 滑块一形状路径
        /// </summary>
        private GraphicsPath one_gp = new GraphicsPath();
        /// <summary>
        /// 滑块一开始坐标
        /// </summary>
        private PointF one_start_pointf = new PointF(10, 0);
        /// <summary>
        /// 滑块一移动距离
        /// </summary>
        private PointF one_move_pointf = PointF.Empty;
        /// <summary>
        /// 滑块一图片
        /// </summary>
        private Bitmap one_bmp = null;
        #endregion

        #region 滑块二
        /// <summary>
        /// 滑块二rectf
        /// </summary>
        private RectangleF two_rectf = RectangleF.Empty;
        /// <summary>
        /// 滑块二形状路径
        /// </summary>
        private GraphicsPath two_gp = new GraphicsPath();
        /// <summary>
        /// 滑块二开始坐标
        /// </summary>
        private PointF two_start_pointf = new PointF(10, 0);
        /// <summary>
        /// 滑块二移动距离
        /// </summary>
        private PointF two_move_pointf = PointF.Empty;
        /// <summary>
        /// 滑块二图片
        /// </summary>
        private Bitmap two_bmp = null;
        #endregion

        #region 滑块三
        /// <summary>
        /// 滑块三rectf
        /// </summary>
        private RectangleF three_rectf = RectangleF.Empty;
        /// <summary>
        /// 滑块三形状路径
        /// </summary>
        private GraphicsPath three_gp = new GraphicsPath();
        /// <summary>
        /// 滑块三开始坐标
        /// </summary>
        private PointF three_start_pointf = new PointF(10, 0);
        /// <summary>
        /// 滑块三移动距离
        /// </summary>
        private PointF three_move_pointf = PointF.Empty;
        /// <summary>
        /// 滑块三图片
        /// </summary>
        private Bitmap three_bmp = null;
        #endregion

        #region 拼图所有的图案(16种)
        //6为凸
        //8为平
        //9为凹
        /// <summary>
        /// 拼图所有的图案(16种)
        /// </summary>
        [Description("拼图所有的图案(16种)")]
        private static Dictionary<int, int[]> JigsawAllShape = new Dictionary<int, int[]> {
        {1,new int[]{6,6,6,6}},
        {2,new int[]{6,6,8,6}},
        {3,new int[]{6,9,9,9}},
        {4,new int[]{9,9,9,9}},
        {5,new int[]{6,9,8,9}},
        {6,new int[]{6,9,8,6}},
        {7,new int[]{6,8,8,6}},
        {8,new int[]{6,9,6,9}},
        {9,new int[]{9,9,8,9}},
        {10,new int[]{9,8,8,9}},
        {11,new int[]{6,8,8,9}},
        {12,new int[]{6,9,6,6}},
        {13,new int[]{9,9,8,6}},
        {14,new int[]{6,6,8,9}},
        {15,new int[]{9,8,8,6}},
        {16,new int[]{9,6,8,9}},
        };
        #endregion

        /// <summary>
        /// 拼图形状索引列表
        /// </summary>
        private List<int> shapeIndexList = new List<int>();
        /// <summary>
        /// 可以通过验证的滑块索引
        /// </summary>
        private int passSlideIndex = -1;
        /// <summary>
        /// 鼠标是否按下
        /// </summary>
        private bool moveDown = false;
        /// <summary>
        /// 鼠标按下坐标
        /// </summary>
        private Point moveDownPoint = Point.Empty;
        /// <summary>
        /// 鼠标选中滑块索引
        /// </summary>
        private int moveDownSlideIndex = -1;

        #endregion

        public JigsawValidExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.shapeIndexList = this.GetSlideIndex(this.SlideType);
            this.InitializeRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.ValidImage == null || this.shapeIndexList.Count < 1)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rect = this.ClientRectangle;

            #region  绘制背景
            g.DrawImage(this.ValidImage, new System.Drawing.PointF(0, 0));
            #endregion

            #region  绘制拼图

            SolidBrush sb_valid = new SolidBrush(this.ValidBlackColor);
            g.FillPath(sb_valid, this.valid_gp);
            sb_valid.Dispose();

            if (this.slideType == SlideTypes.One || this.slideType == SlideTypes.Two || this.slideType == SlideTypes.Three)
            {
                if (this.one_bmp != null)
                {
                    g.DrawImage(this.one_bmp, this.one_gp.GetBounds().Location);
                }
                float x = this.one_start_pointf.X + this.one_move_pointf.X;
                if (x < this.valid_start_pointf.X - this.one_gp.GetBounds().Width / 5f || x > this.valid_start_pointf.X + this.one_gp.GetBounds().Width / 5f)
                {
                    Pen pen_one = new Pen(this.SlideBorderColor);
                    g.DrawPath(pen_one, this.one_gp);
                    pen_one.Dispose();
                }
            }
            if (this.slideType == SlideTypes.Two || this.slideType == SlideTypes.Three)
            {
                if (this.two_bmp != null)
                {
                    g.DrawImage(this.two_bmp, this.two_gp.GetBounds().Location);
                }
                float x = this.two_start_pointf.X + this.two_move_pointf.X;
                if (x < this.valid_start_pointf.X - this.two_gp.GetBounds().Width / 5f || x > this.valid_start_pointf.X + this.two_gp.GetBounds().Width / 5f)
                {
                    Pen pen_two = new Pen(this.SlideBorderColor);
                    g.DrawPath(pen_two, this.two_gp);
                    pen_two.Dispose();
                }
            }
            if (this.slideType == SlideTypes.Three)
            {
                if (this.three_bmp != null)
                {
                    g.DrawImage(this.three_bmp, this.three_gp.GetBounds().Location);
                }
                float x = this.three_start_pointf.X + this.three_move_pointf.X;
                if (x < this.valid_start_pointf.X - this.three_gp.GetBounds().Width / 5f || x > this.valid_start_pointf.X + this.three_gp.GetBounds().Width / 5f)
                {
                    Pen pen_three = new Pen(this.SlideBorderColor);
                    g.DrawPath(pen_three, this.three_gp);
                    pen_three.Dispose();
                }
            }
            #endregion

            #region 边框
            if (this.BorderShow)
            {
                Pen border_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(border_pen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

                if (border_pen != null)
                    border_pen.Dispose();
            }

            #endregion

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (this.pass == true)
                return;

            if (!this.moveDown)
            {
                if (this.slideType == SlideTypes.One)
                {
                    if (this.one_gp.IsVisible(e.Location))
                    {
                        this.moveDownSlideIndex = 1;
                        this.moveDown = true;
                        this.moveDownPoint = e.Location;
                    }
                }
                else if (this.slideType == SlideTypes.Two)
                {
                    if (this.one_gp.IsVisible(e.Location))
                    {
                        this.moveDownSlideIndex = 1;
                        this.moveDown = true;
                        this.moveDownPoint = e.Location;
                    }
                    else if (this.two_gp.IsVisible(e.Location))
                    {
                        this.moveDownSlideIndex = 2;
                        this.moveDown = true;
                        this.moveDownPoint = e.Location;
                    }
                }
                else if (this.slideType == SlideTypes.Three)
                {
                    if (this.one_gp.IsVisible(e.Location))
                    {
                        this.moveDownSlideIndex = 1;
                        this.moveDown = true;
                        this.moveDownPoint = e.Location;
                    }
                    else if (this.two_gp.IsVisible(e.Location))
                    {
                        this.moveDownSlideIndex = 2;
                        this.moveDown = true;
                        this.moveDownPoint = e.Location;
                    }
                    else if (this.three_gp.IsVisible(e.Location))
                    {
                        this.moveDownSlideIndex = 3;
                        this.moveDown = true;
                        this.moveDownPoint = e.Location;
                    }
                }

            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (this.pass == true)
                return;

            if (this.moveDown)
            {
                this.moveDown = false;
                this.ValidJigsaw();
                if (!this.pass)
                {
                    this.one_move_pointf = new PointF(0, 0);
                    this.two_move_pointf = new PointF(0, 0);
                    this.three_move_pointf = new PointF(0, 0);

                    float radius = this.SlideSize / 4f;
                    #region
                    if (this.moveDownSlideIndex == 1)
                    {
                        RectangleF rectf_one = new RectangleF(this.one_start_pointf.X + this.one_move_pointf.X, this.one_start_pointf.Y + (this.one_move_pointf.X * (this.valid_start_pointf.Y - this.one_start_pointf.Y) / (this.valid_start_pointf.X - this.one_start_pointf.X)), this.SlideSize + radius * 2f, this.SlideSize + radius * 2f);
                        this.one_gp.Reset();
                        this.GetPath(this.shapeIndexList[0], this.one_gp, rectf_one);
                    }
                    else if (this.moveDownSlideIndex == 2)
                    {
                        RectangleF rectf_two = new RectangleF(this.two_start_pointf.X + this.two_move_pointf.X, this.two_start_pointf.Y - (this.two_move_pointf.X * (this.valid_start_pointf.Y - this.two_start_pointf.Y) / (this.valid_start_pointf.X - this.two_start_pointf.X)), this.SlideSize + radius * 2f, this.SlideSize + radius * 2f);
                        this.two_gp.Reset();
                        this.GetPath(this.shapeIndexList[1], this.two_gp, rectf_two);
                    }
                    else if (this.moveDownSlideIndex == 3)
                    {
                        RectangleF rectf_three = new RectangleF(this.three_start_pointf.X, this.three_start_pointf.Y, this.SlideSize + radius * 2f, this.SlideSize + radius * 2f);
                        this.three_gp.Reset();
                        this.GetPath(this.shapeIndexList[2], this.three_gp, rectf_three);
                    }
                    this.moveDownSlideIndex = -1;
                    #endregion
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            if (this.pass == true)
                return;

            this.moveDown = false;
            this.moveDownSlideIndex = -1;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.pass == true)
                return;

            if (this.moveDown)
            {
                #region 更新选中滑块移动距离
                PointF p = new PointF(e.Location.X - this.moveDownPoint.X, e.Location.Y - this.moveDownPoint.Y);
                if (this.moveDownSlideIndex == 1)
                {
                    if (this.one_start_pointf.X + p.X < this.one_start_pointf.X)
                        p.X = this.one_start_pointf.X;
                    if (this.one_start_pointf.X + p.X > this.ClientRectangle.Right - this.one_rectf.Width)
                        p.X = this.ClientRectangle.Right - this.one_rectf.Width;
                    this.one_move_pointf = p;
                }
                else if (this.moveDownSlideIndex == 2)
                {
                    if (this.two_start_pointf.X + p.X < this.two_start_pointf.X)
                        p.X = this.two_start_pointf.X;
                    if (this.two_start_pointf.X + p.X > this.ClientRectangle.Right - this.two_rectf.Width)
                        p.X = this.ClientRectangle.Right - this.two_rectf.Width;
                    this.two_move_pointf = p;
                }
                else if (this.moveDownSlideIndex == 3)
                {
                    if (this.three_start_pointf.X + p.X < this.three_start_pointf.X)
                        p.X = this.three_start_pointf.X;
                    if (this.three_start_pointf.X + p.X > this.ClientRectangle.Right - this.three_rectf.Width)
                        p.X = this.ClientRectangle.Right - this.three_rectf.Width;
                    this.three_move_pointf = p;
                }
                #endregion

                #region 更新滑块GraphicsPath

                float radius = this.SlideSize / 4f;
                if (this.SlideType == SlideTypes.One)
                {
                    if (this.moveDownSlideIndex == 1)
                    {
                        RectangleF rectf_one = new RectangleF(this.one_start_pointf.X + this.one_move_pointf.X, this.one_start_pointf.Y, this.SlideSize + radius * 2, this.SlideSize + radius * 2);
                        this.one_gp.Reset();
                        this.GetPath(this.shapeIndexList[0], this.one_gp, rectf_one);
                    }
                }
                if (this.SlideType == SlideTypes.Two)
                {
                    if (this.moveDownSlideIndex == 1)
                    {
                        RectangleF rectf_one = new RectangleF(this.one_start_pointf.X + this.one_move_pointf.X, this.one_start_pointf.Y + (this.one_move_pointf.X * (this.valid_start_pointf.Y - this.one_start_pointf.Y) / (this.valid_start_pointf.X - this.one_start_pointf.X)), this.SlideSize + radius * 2, this.SlideSize + radius * 2);
                        this.one_gp.Reset();
                        this.GetPath(this.shapeIndexList[0], this.one_gp, rectf_one);
                    }
                    else if (this.moveDownSlideIndex == 2)
                    {
                        RectangleF rectf_two = new RectangleF(this.two_start_pointf.X + this.two_move_pointf.X, this.two_start_pointf.Y + (this.two_move_pointf.X * (this.valid_start_pointf.Y - this.two_start_pointf.Y) / (this.valid_start_pointf.X - this.two_start_pointf.X)), this.SlideSize + radius * 2, this.SlideSize + radius * 2);
                        this.two_gp.Reset();
                        this.GetPath(this.shapeIndexList[1], this.two_gp, rectf_two);
                    }
                }
                if (this.SlideType == SlideTypes.Three)
                {
                    if (this.moveDownSlideIndex == 1)
                    {
                        RectangleF rectf_one = new RectangleF(this.one_start_pointf.X + this.one_move_pointf.X, this.one_start_pointf.Y + (this.one_move_pointf.X * (this.valid_start_pointf.Y - this.one_start_pointf.Y) / (this.valid_start_pointf.X - this.one_start_pointf.X)), this.SlideSize + radius * 2, this.SlideSize + radius * 2);
                        this.one_gp.Reset();
                        this.GetPath(this.shapeIndexList[0], this.one_gp, rectf_one);
                    }
                    else if (this.moveDownSlideIndex == 2)
                    {
                        RectangleF rectf_two = new RectangleF(this.two_start_pointf.X + this.two_move_pointf.X, this.two_start_pointf.Y + (this.two_move_pointf.X * (this.valid_start_pointf.Y - this.two_start_pointf.Y) / (this.valid_start_pointf.X - this.two_start_pointf.X)), this.SlideSize + radius * 2, this.SlideSize + radius * 2);
                        this.two_gp.Reset();
                        this.GetPath(this.shapeIndexList[1], this.two_gp, rectf_two);
                    }
                    else if (this.moveDownSlideIndex == 3)
                    {
                        RectangleF rectf_three = new RectangleF(this.three_start_pointf.X + this.three_move_pointf.X, this.three_start_pointf.Y + (this.three_move_pointf.X * (this.valid_start_pointf.Y - this.three_start_pointf.Y) / (this.valid_start_pointf.X - this.three_start_pointf.X)), this.SlideSize + radius * 2, this.SlideSize + radius * 2);
                        this.three_gp.Reset();
                        this.GetPath(this.shapeIndexList[2], this.three_gp, rectf_three);
                    }


                }

                #endregion

                this.Invalidate();
            }
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (valid_gp != null)
                    valid_gp.Dispose();

                if (this.one_gp != null)
                    this.one_gp.Dispose();
                if (this.one_bmp != null)
                    this.one_bmp.Dispose();

                if (this.two_gp != null)
                    this.two_gp.Dispose();
                if (this.two_bmp != null)
                    this.two_bmp.Dispose();

                if (this.three_gp != null)
                    this.three_gp.Dispose();
                if (this.three_bmp != null)
                    this.three_bmp.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnValided(ValidedEventArgs e)
        {
            if (this.valided != null)
            {
                this.valided(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化拼图滑块信息
        /// </summary>
        protected void InitializeRectangle()
        {
            if (this.ValidImage == null || this.shapeIndexList.Count < 1)
                return;

            this.pass = false;

            if (this.one_bmp != null)
                this.one_bmp.Dispose();
            if (this.two_bmp != null)
                this.two_bmp.Dispose();
            if (this.three_bmp != null)
                this.three_bmp.Dispose();

            Rectangle rect = this.ClientRectangle;
            float radius = this.SlideSize / 4f;

            #region 滑块信息
            if (this.SlideType == SlideTypes.One)//一个滑块
            {
                this.one_start_pointf.Y = (float)(rect.Height - this.SlideSize) / 2f;
            }
            else if (this.SlideType == SlideTypes.Two)//二个滑块
            {
                float height = (float)(rect.Height - this.SlideSize * 2);
                this.one_start_pointf.Y = height / 3f;
                this.two_start_pointf.Y = height / 3f + this.SlideSize + height / 3f;
            }
            else if (this.SlideType == SlideTypes.Three)//三个滑块
            {
                float height = (float)(rect.Height - this.SlideSize * 3);
                this.one_start_pointf.Y = height / 4f;
                this.two_start_pointf.Y = height / 4f + this.SlideSize + height / 4f;
                this.three_start_pointf.Y = height / 4f + this.SlideSize + height / 4f + this.SlideSize + height / 4f;
            }

            Random rd = new Random();
            this.valid_start_pointf = new PointF(((float)rect.Width - this.SlideSize * 3f) + (float)rd.Next(0, this.SlideSize), (float)(rect.Height - this.SlideSize) / 2f);
            this.valid_rectf = new RectangleF(this.valid_start_pointf.X, this.valid_start_pointf.Y, this.SlideSize + radius * 2, this.SlideSize + radius * 2);
            this.valid_gp.Reset();
            this.GetPath(this.shapeIndexList[this.passSlideIndex - 1], this.valid_gp, this.valid_rectf);

            #endregion

            #region
            if (this.SlideType == SlideTypes.One || this.SlideType == SlideTypes.Two || this.SlideType == SlideTypes.Three)
            {
                this.one_rectf = new RectangleF(this.one_start_pointf.X, this.one_start_pointf.Y, this.SlideSize + radius * 2f, this.SlideSize + radius * 2f);

                this.one_gp.Reset();
                this.GetPath(this.shapeIndexList[0], this.one_gp, this.one_rectf);
                GraphicsPath gp_one_tmp = (GraphicsPath)this.one_gp.Clone();
                Matrix matrix = new Matrix();
                matrix.Translate(this.valid_rectf.Left - this.one_rectf.Left, this.valid_rectf.Top - this.one_rectf.Top);
                gp_one_tmp.Transform(matrix);
                this.one_bmp = CutBitmap((Bitmap)this.ValidImage, gp_one_tmp);
                gp_one_tmp.Dispose();
                matrix.Dispose();
            }
            if (this.SlideType == SlideTypes.Two || this.SlideType == SlideTypes.Three)
            {
                this.two_rectf = new RectangleF(this.two_start_pointf.X, this.two_start_pointf.Y, this.SlideSize + radius * 2f, this.SlideSize + radius * 2f);

                this.two_gp.Reset();
                this.GetPath(this.shapeIndexList[1], this.two_gp, this.two_rectf);
                GraphicsPath gp_two_tmp = (GraphicsPath)this.two_gp.Clone();
                Matrix matrix = new Matrix();
                matrix.Translate(this.valid_rectf.Left - this.two_rectf.Left, this.valid_rectf.Top - this.two_rectf.Top);
                gp_two_tmp.Transform(matrix);
                this.two_bmp = CutBitmap((Bitmap)this.ValidImage, gp_two_tmp);
                gp_two_tmp.Dispose();
                matrix.Dispose();
            }
            if (this.SlideType == SlideTypes.Three)
            {
                this.three_rectf = new RectangleF(this.three_start_pointf.X, this.three_start_pointf.Y, this.SlideSize + radius * 2, this.SlideSize + radius * 2);

                this.three_gp.Reset();
                this.GetPath(this.shapeIndexList[2], this.three_gp, this.three_rectf);
                GraphicsPath gp_three_tmp = (GraphicsPath)this.three_gp.Clone();
                Matrix matrix = new Matrix();
                matrix.Translate(this.valid_rectf.Left - this.three_rectf.Left, this.valid_rectf.Top - this.three_rectf.Top);
                gp_three_tmp.Transform(matrix);
                this.three_bmp = CutBitmap((Bitmap)this.ValidImage, gp_three_tmp);
                gp_three_tmp.Dispose();
                matrix.Dispose();
            }
            #endregion

        }

        /// <summary>
        /// 更新验证码
        /// </summary>
        public void ResetJigsaw()
        {
            this.pass = false;

            this.one_move_pointf = new PointF(20, 0);
            this.two_move_pointf = new PointF(10, 0);
            this.three_move_pointf = new PointF(10, 0);

            this.passSlideIndex = -1;
            this.moveDown = false;
            this.moveDownPoint = Point.Empty;
            this.moveDownSlideIndex = -1;

            this.shapeIndexList = this.GetSlideIndex(this.SlideType);
            this.InitializeRectangle();
            this.Invalidate();
        }

        /// <summary>
        /// 通过验证
        /// </summary>
        /// <returns></returns>
        private void ValidJigsaw()
        {
            if (this.moveDownSlideIndex > -1)
            {
                ValidedEventArgs data = new ValidedEventArgs();
                if (this.moveDownSlideIndex == 1 && this.passSlideIndex == 1)
                {
                    PointF p = new PointF(this.one_start_pointf.X + this.one_move_pointf.X, this.one_start_pointf.Y + this.one_move_pointf.Y);
                    this.pass = (Math.Abs(this.valid_start_pointf.X - p.X) < 2);
                    data.Pass = this.pass;
                }
                else if (this.moveDownSlideIndex == 2 && this.passSlideIndex == 2)
                {
                    PointF p = new PointF(this.two_start_pointf.X + this.two_move_pointf.X, this.two_start_pointf.Y + this.two_move_pointf.Y);
                    this.pass = (Math.Abs(this.valid_start_pointf.X - p.X) < 2);
                    data.Pass = this.pass;
                }
                else if (this.moveDownSlideIndex == 3 && this.passSlideIndex == 3)
                {
                    PointF p = new PointF(this.three_start_pointf.X + this.three_move_pointf.X, this.three_start_pointf.Y + this.three_move_pointf.Y);
                    this.pass = (Math.Abs(this.valid_start_pointf.X - p.X) < 2);
                    data.Pass = this.pass;
                }
                else
                {
                    this.pass = false;
                }

                if (!this.DesignMode)
                {
                    this.OnValided(data);
                }
            }

        }

        /// <summary>
        /// 截取图片
        /// </summary>
        /// <param name="bmp">原图</param>
        /// <param name="gp">截取路径</param>
        /// <returns></returns>
        private Bitmap CutBitmap(Bitmap bmp, GraphicsPath gp)
        {
            RectangleF rect = gp.GetBounds();
            int top = (int)rect.Top;
            int left = (int)rect.Left; ;
            int width = (int)rect.Width;
            int height = (int)rect.Height;

            Bitmap bmp_result = new Bitmap(width, height);
            Color transparent = Color.FromArgb(0, 255, 255, 255);
            for (int i = left; i < left + width; i++)
            {
                for (int j = top; j < top + height; j++)
                {
                    if (i < bmp.Width && j < bmp.Height && gp.IsVisible(i, j))
                    {
                        bmp_result.SetPixel(i - left, j - top, bmp.GetPixel(i, j));
                    }
                    else
                    {
                        bmp_result.SetPixel(i - left, j - top, transparent);
                    }
                }
            }
            return bmp_result;
        }

        /// <summary>
        /// 获取拼图形状索引列表
        /// </summary>
        /// <param name="slideType">拼图滑块类型</param>
        /// <returns></returns>
        private List<int> GetSlideIndex(SlideTypes slideType)
        {
            int length = 0;
            switch (slideType)
            {
                case SlideTypes.One:
                    length = 1;
                    break;
                case SlideTypes.Two:
                    length = 2;
                    break;
                case SlideTypes.Three:
                    length = 3;
                    break;
            }

            List<int> indexList = new List<int>();
            int index = 0;
            for (int i = 0; i < length; i++)
            {
                while (true)
                {
                    Random rd_index = new Random();
                    index = rd_index.Next(JigsawAllShape.Keys.First(), JigsawAllShape.Keys.Last());
                    if (indexList.IndexOf(index) == -1)
                    {
                        indexList.Add(index);
                        break;
                    }
                }
            }

            Random rd_valid = new Random();
            this.passSlideIndex = rd_valid.Next(1, indexList.Count);

            return indexList;
        }

        /// <summary>
        /// 获取拼图路径
        /// </summary>
        /// <param name="shapeIndex">拼图所有的图案(16种)索引</param>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        /// <returns></returns>
        private GraphicsPath GetPath(int shapeIndex, GraphicsPath gp, RectangleF rectf)
        {
            rectf = new RectangleF(rectf.Left + rectf.Width / 8, rectf.Top + rectf.Height / 8, rectf.Width / 4f * 3f, rectf.Height / 4f * 3f);
            this.Draw_Jiao_LtftTop(gp, rectf);
            this.DrawSlide(SlideOrientation.Top, JigsawAllShape[shapeIndex][0], gp, rectf);
            this.Draw_Jiao_RightTop(gp, rectf);
            this.DrawSlide(SlideOrientation.Right, JigsawAllShape[shapeIndex][1], gp, rectf);
            this.Draw_Jiao_RightBottom(gp, rectf);
            this.DrawSlide(SlideOrientation.Bottom, JigsawAllShape[shapeIndex][2], gp, rectf);
            this.Draw_Jiao_LeftBottom(gp, rectf);
            this.DrawSlide(SlideOrientation.Left, JigsawAllShape[shapeIndex][3], gp, rectf);
            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// 绘制拼图四边的形状
        /// </summary>
        /// <param name="orientation">拼图指定方向形状</param>
        /// <param name="shapeType">填充拼图指定边的指定形状（6、8、9）</param>
        /// <param name="gp"></param>
        /// <param name="rectf">拼图rectf</param>
        private void DrawSlide(SlideOrientation orientation, int shapeType, GraphicsPath gp, RectangleF rectf)
        {
            switch (orientation)
            {
                #region
                case SlideOrientation.Top:
                    {
                        switch (shapeType)
                        {
                            case 6:
                                {
                                    this.Draw_TU_Top(gp, rectf);
                                    break;
                                }
                            case 8:
                                {
                                    break;
                                }
                            case 9:
                                {
                                    this.Draw_AO_Top(gp, rectf);
                                    break;
                                }
                        }
                        break;
                    }
                #endregion
                #region
                case SlideOrientation.Right:
                    {
                        switch (shapeType)
                        {
                            case 6:
                                {
                                    this.Draw_TU_Right(gp, rectf);
                                    break;
                                }
                            case 8:
                                {
                                    break;
                                }
                            case 9:
                                {
                                    this.Draw_AO_Right(gp, rectf);
                                    break;
                                }
                        }
                        break;
                    }
                #endregion
                #region
                case SlideOrientation.Bottom:
                    {
                        switch (shapeType)
                        {
                            case 6:
                                {
                                    this.Draw_TU_Bottom(gp, rectf);
                                    break;
                                }
                            case 8:
                                {
                                    break;
                                }
                            case 9:
                                {
                                    this.Draw_AO_Bottom(gp, rectf);
                                    break;
                                }
                        }
                        break;
                    }
                #endregion
                #region
                case SlideOrientation.Left:
                    {
                        switch (shapeType)
                        {
                            case 6:
                                {
                                    this.Draw_TU_Left(gp, rectf);
                                    break;
                                }
                            case 8:
                                {
                                    break;
                                }
                            case 9:
                                {
                                    this.Draw_AO_Left(gp, rectf);
                                    break;
                                }
                        }
                        break;
                    }
                    #endregion
            }
        }

        #region  绘制拼图角
        /// <summary>
        ///  绘制拼图左上角
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_Jiao_LtftTop(GraphicsPath gp, RectangleF rectf)
        {
            gp.AddLine(new PointF(rectf.Left, rectf.Top), new PointF(rectf.Left, rectf.Top));
        }
        /// <summary>
        /// 绘制拼图右上角
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_Jiao_RightTop(GraphicsPath gp, RectangleF rectf)
        {
            gp.AddLine(new PointF(rectf.Right, rectf.Top), new PointF(rectf.Right, rectf.Top));
        }
        /// <summary>
        /// 绘制拼图右下角
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_Jiao_RightBottom(GraphicsPath gp, RectangleF rectf)
        {
            gp.AddLine(new PointF(rectf.Right, rectf.Bottom), new PointF(rectf.Right, rectf.Bottom));
        }
        /// <summary>
        /// 绘制拼图左下角
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_Jiao_LeftBottom(GraphicsPath gp, RectangleF rectf)
        {
            gp.AddLine(new PointF(rectf.Left, rectf.Bottom), new PointF(rectf.Left, rectf.Bottom));
        }
        #endregion

        #region 绘制拼图凸线
        /// <summary>
        /// 绘制拼图顶部凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rect"></param>
        private void Draw_TU_Top(GraphicsPath gp, RectangleF rect)
        {
            gp.AddArc(new RectangleF(rect.Left + rect.Width / 3f, (rect.Top - rect.Width / 3f / 2f), rect.Width / 3f, rect.Width / 3f), 180, 180);
        }
        /// <summary>
        /// 绘制拼图右边凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rect"></param>
        private void Draw_TU_Right(GraphicsPath gp, RectangleF rect)
        {
            gp.AddArc(new RectangleF(rect.Right - rect.Width / 3f / 2f, rect.Top + rect.Height / 3f, rect.Width / 3f, rect.Width / 3f), 270, 180);
        }
        /// <summary>
        /// 绘制拼图底部凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rect"></param>
        private void Draw_TU_Bottom(GraphicsPath gp, RectangleF rect)
        {
            gp.AddArc(new RectangleF(rect.Left + rect.Width / 3f, (rect.Bottom - rect.Width / 3f / 2f), rect.Width / 3f, rect.Width / 3f), 0, 180);
        }
        /// <summary>
        /// 绘制拼图左边凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rect"></param>
        private void Draw_TU_Left(GraphicsPath gp, RectangleF rect)
        {
            gp.AddArc(new RectangleF(rect.Left - rect.Width / 3f / 2f, rect.Top + rect.Height / 3f, rect.Width / 3f, rect.Width / 3f), 90, 180);
        }
        #endregion

        #region 绘制拼图凹线
        /// <summary>
        /// 绘制拼图顶部凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_AO_Top(GraphicsPath gp, RectangleF rectf)
        {
            GraphicsPath gp_tmp = new GraphicsPath();
            gp_tmp.AddArc(new RectangleF(rectf.Left + rectf.Width / 3f, (rectf.Top - rectf.Width / 3f / 2f), rectf.Width / 3f, rectf.Width / 3f), 0, 180);
            gp_tmp.Reverse();
            gp.AddPath(gp_tmp, true);
        }
        /// <summary>
        /// 绘制拼图右边凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_AO_Right(GraphicsPath gp, RectangleF rectf)
        {
            GraphicsPath gp_tmp = new GraphicsPath();
            gp_tmp.AddArc(new RectangleF(rectf.Right - rectf.Width / 3f / 2f, rectf.Top + rectf.Height / 3f, rectf.Width / 3f, rectf.Width / 3f), 90, 180);
            gp_tmp.Reverse();
            gp.AddPath(gp_tmp, true);
        }
        /// <summary>
        /// 绘制拼图底部凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_AO_Bottom(GraphicsPath gp, RectangleF rectf)
        {

            GraphicsPath gp_tmp = new GraphicsPath();
            gp_tmp.AddArc(new RectangleF(rectf.Left + rectf.Width / 3f, (rectf.Bottom - rectf.Width / 3f / 2f), rectf.Width / 3f, rectf.Width / 3f), 180, 180);
            gp_tmp.Reverse();
            gp.AddPath(gp_tmp, true);
        }
        /// <summary>
        /// 绘制拼图左边凹线
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="rectf"></param>
        private void Draw_AO_Left(GraphicsPath gp, RectangleF rectf)
        {
            GraphicsPath gp_tmp = new GraphicsPath();
            gp_tmp.AddArc(new RectangleF(rectf.Left - rectf.Width / 3f / 2f, rectf.Top + rectf.Height / 3f, rectf.Width / 3f, rectf.Width / 3f), 270, 180);
            gp_tmp.Reverse();
            gp.AddPath(gp_tmp, true);
        }
        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 拼图验证事件参数
        /// </summary>
        [Description("拼图验证事件参数")]
        public class ValidedEventArgs : EventArgs
        {
            /// <summary>
            /// 验证结果
            /// </summary>
            [Description("验证结果")]
            public bool Pass { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 拼图滑块类型
        /// </summary>
        [Description("拼图滑块类型")]
        public enum SlideTypes
        {
            /// <summary>
            /// 一个拼图滑块
            /// </summary>
            One,
            /// <summary>
            /// 两个拼图滑块
            /// </summary>
            Two,
            /// <summary>
            /// 三个拼图滑块
            /// </summary>
            Three,
            /// <summary>
        }

        /// <summary>
        /// 拼图四边方向
        /// </summary>
        [Description("拼图四边方向")]
        public enum SlideOrientation
        {
            /// <summary>
            /// 顶部
            /// </summary>
            Top,
            /// <summary>
            /// 右边
            /// </summary>
            Right,
            /// <summary>
            /// 底部
            /// </summary>
            Bottom,
            /// <summary>
            /// 左边
            /// </summary>
            Left
        }

        #endregion

    }

}
