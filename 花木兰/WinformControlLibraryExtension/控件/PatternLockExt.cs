
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
    ///  图案滑屏解锁控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("图案滑屏解锁控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("UnLock")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class PatternLockExt : Control
    {
        #region 新增事件

        public delegate void UnLockEventHandler(object sender, UnLockEventArgs e);

        private event UnLockEventHandler unLock;

        /// <summary>
        /// 图案滑屏解锁事件
        /// </summary>
        [Description("图案滑屏解锁事件")]
        public event UnLockEventHandler UnLock
        {
            add { this.unLock += value; }
            remove { this.unLock -= value; }
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

        private FunctionTypes type = FunctionTypes.Valid;
        /// <summary>
        /// 功能类型
        /// </summary>
        [DefaultValue(FunctionTypes.Valid)]
        [Description("功能类型")]
        public FunctionTypes Type
        {
            get { return this.type; }
            set
            {
                if (this.type == value)
                    return;
                this.type = value;
                this.Invalidate();
            }
        }

        private UnLockPatternTypes unLockType = UnLockPatternTypes.Pattern;
        /// <summary>
        /// 解锁类型
        /// </summary>
        [DefaultValue(UnLockPatternTypes.Pattern)]
        [Description("解锁类型")]
        public UnLockPatternTypes UnLockType
        {
            get { return this.unLockType; }
            set
            {
                if (this.unLockType == value)
                    return;
                this.unLockType = value;
                this.Invalidate();
            }
        }

        private bool showLine = true;
        /// <summary>
        /// 显示解锁路径
        /// </summary>
        [DefaultValue(true)]
        [Description("显示解锁路径")]
        public bool ShowLine
        {
            get { return this.showLine; }
            set
            {
                if (this.showLine == value)
                    return;
                this.showLine = value;
                this.Invalidate();
            }
        }

        private string value = "";
        /// <summary>
        /// 解锁正确值
        /// </summary>
        [DefaultValue("")]
        [Description("解锁正确值")]
        public string Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value)
                    return;
                this.value = value;
            }
        }

        private Font unLockFont = new Font("宋体", 20f);
        /// <summary>
        /// 解锁数字字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 20pt")]
        [Description("解锁数字字体")]
        public Font UnLockFont
        {
            get { return this.unLockFont; }
            set
            {
                if (this.unLockFont == value)
                    return;
                this.unLockFont = value;
                this.Invalidate();
            }
        }

        private Color normalColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 解锁颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("解锁颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color NormalColor
        {
            get { return this.normalColor; }
            set
            {
                if (this.normalColor == value)
                    return;
                this.normalColor = value;
                this.Invalidate();
            }
        }

        private Color passColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 解锁颜色（通过）
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("解锁颜色（通过）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PassColor
        {
            get { return this.passColor; }
            set
            {
                if (this.passColor == value)
                    return;
                this.passColor = value;
                this.Invalidate();
            }
        }

        private Color errorColor = Color.FromArgb(255, 128, 128);
        /// <summary>
        /// 解锁颜色（错误）
        /// </summary>
        [DefaultValue(typeof(Color), "255, 128, 128")]
        [Description("解锁颜色（错误）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ErrorColor
        {
            get { return this.errorColor; }
            set
            {
                if (this.errorColor == value)
                    return;
                this.errorColor = value;
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

        /// <summary>
        /// 重写背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("内圆背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// 重写默认Size
        /// </summary>
        [Description("重写默认Size")]
        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 300);
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

        /// <summary>
        /// 鼠标是否按下
        /// </summary>
        private bool moveDown = false;
        /// <summary>
        /// 鼠标按下坐标
        /// </summary>
        private Point moveDownPoint = Point.Empty;
        /// <summary>
        /// 解锁状态
        /// </summary>
        private UnLockStatus unLockStatus = UnLockStatus.Normal;
        /// <summary>
        /// 选中解锁选项
        /// </summary>
        private Dictionary<int, string> selectList = new Dictionary<int, string>();
        /// <summary>
        /// 解锁选项列表
        /// </summary>
        private List<UnLockItem> unLockItemList = new List<UnLockItem>() {
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="1"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="2"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="3"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="4"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="5"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="6"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="7"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="8"},
        new UnLockItem(){ out_rectf= RectangleF.Empty, gp=new GraphicsPath(), status= UnLockItemStatuss.Normal, value="9"},
        };

        #endregion

        public PatternLockExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.FromArgb(64, 64, 64);

            this.InitializeUnLockRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            StringFormat sf = (this.UnLockType == UnLockPatternTypes.Pattern) ? null : new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            #region
            if (!this.ShowLine)
            {
                SolidBrush Normal_sb_inBackColor = new SolidBrush(this.NormalColor);
                for (int i = 0; i < this.unLockItemList.Count; i++)
                {
                    if (this.UnLockType == UnLockPatternTypes.Pattern)
                    {
                        g.FillEllipse(Normal_sb_inBackColor, this.unLockItemList[i].in_rectf);
                    }
                    else
                    {
                        g.DrawString(this.unLockItemList[i].value, this.UnLockFont, Normal_sb_inBackColor, this.unLockItemList[i].out_rectf, sf);
                    }
                }
                Normal_sb_inBackColor.Dispose();
            }
            #endregion
            #region
            else
            {
                #region 画笔
                float lineSize = this.unLockItemList[0].in_rectf.Width;

                SolidBrush Normal_sb_inBackColor = new SolidBrush(this.NormalColor);
                SolidBrush Normal_sb_outBackColor = new SolidBrush(Color.FromArgb(50, this.NormalColor));
                Pen Normal_pen_outLineColor = new Pen(this.NormalColor, lineSize / 3f);
                Normal_pen_outLineColor.Alignment = PenAlignment.Outset;
                Pen Normal_pen_lineColor = new Pen(Color.FromArgb(150, this.NormalColor), lineSize);
                Normal_pen_lineColor.Alignment = PenAlignment.Center;
                Normal_pen_lineColor.StartCap = LineCap.Round;
                Normal_pen_lineColor.EndCap = LineCap.Round;

                SolidBrush Pass_sb_inBackColor = null;
                SolidBrush Pass_sb_outBackColor = null;
                Pen Pass_pen_outLineColor = null;
                Pen Pass_pen_lineColor = null;
                if (this.unLockStatus == UnLockStatus.Pass)
                {
                    Pass_sb_inBackColor = new SolidBrush(this.PassColor);
                    Pass_sb_outBackColor = new SolidBrush(Color.FromArgb(50, this.PassColor));
                    Pass_pen_outLineColor = new Pen(this.PassColor, lineSize / 3f);
                    Pass_pen_outLineColor.Alignment = PenAlignment.Outset;
                    Pass_pen_lineColor = new Pen(Color.FromArgb(150, this.PassColor), lineSize);
                    Pass_pen_lineColor.Alignment = PenAlignment.Center;
                    Pass_pen_lineColor.StartCap = LineCap.Round;
                    Pass_pen_lineColor.EndCap = LineCap.Round;
                }

                SolidBrush Error_sb_inBackColor = null;
                SolidBrush Error_sb_outBackColor = null;
                Pen Error_pen_outLineColor = null;
                Pen Error_pen_lineColor = null;
                if (this.unLockStatus == UnLockStatus.Error)
                {
                    Error_sb_inBackColor = new SolidBrush(this.ErrorColor);
                    Error_sb_outBackColor = new SolidBrush(Color.FromArgb(50, this.ErrorColor));
                    Error_pen_outLineColor = new Pen(this.ErrorColor, lineSize / 3f);
                    Error_pen_outLineColor.Alignment = PenAlignment.Outset;
                    Error_pen_lineColor = new Pen(Color.FromArgb(150, this.ErrorColor), lineSize);
                    Error_pen_lineColor.Alignment = PenAlignment.Center;
                    Error_pen_lineColor.StartCap = LineCap.Round;
                    Error_pen_lineColor.EndCap = LineCap.Round;
                }
                #endregion

                #region 绘制
                switch (this.unLockStatus)
                {
                    case UnLockStatus.Normal:
                        {
                            #region
                            for (int i = 0; i < this.unLockItemList.Count; i++)
                            {
                                if (this.UnLockType == UnLockPatternTypes.Pattern)
                                {
                                    g.FillEllipse(Normal_sb_inBackColor, this.unLockItemList[i].in_rectf);
                                }
                                else
                                {
                                    g.DrawString(this.unLockItemList[i].value, this.UnLockFont, Normal_sb_inBackColor, this.unLockItemList[i].out_rectf, sf);
                                }
                            }
                            break;
                            #endregion
                        }
                    case UnLockStatus.UnLock:
                    case UnLockStatus.Finish:
                        {
                            #region
                            for (int i = 0; i < this.unLockItemList.Count; i++)
                            {
                                if (this.unLockItemList[i].status == UnLockItemStatuss.Select)
                                {
                                    g.FillEllipse(Normal_sb_outBackColor, this.unLockItemList[i].out_rectf);
                                    g.DrawEllipse(Normal_pen_outLineColor, this.unLockItemList[i].out_rectf);
                                }
                                if (this.UnLockType == UnLockPatternTypes.Pattern)
                                {
                                    g.FillEllipse(Normal_sb_inBackColor, this.unLockItemList[i].in_rectf);
                                }
                                else
                                {
                                    g.DrawString(this.unLockItemList[i].value, this.UnLockFont, Normal_sb_inBackColor, this.unLockItemList[i].out_rectf, sf);
                                }
                            }
                            this.DrawUnLockLine(g, Normal_pen_lineColor);
                            break;
                            #endregion
                        }
                    case UnLockStatus.Pass:
                        {
                            #region
                            for (int i = 0; i < this.unLockItemList.Count; i++)
                            {
                                if (this.unLockItemList[i].status == UnLockItemStatuss.Select)
                                {
                                    g.FillEllipse(Pass_sb_outBackColor, this.unLockItemList[i].out_rectf);
                                    g.DrawEllipse(Pass_pen_outLineColor, this.unLockItemList[i].out_rectf);
                                    if (this.UnLockType == UnLockPatternTypes.Pattern)
                                    {
                                        g.FillEllipse(Pass_sb_inBackColor, this.unLockItemList[i].in_rectf);
                                    }
                                    else
                                    {
                                        g.DrawString(this.unLockItemList[i].value, this.UnLockFont, Pass_sb_inBackColor, this.unLockItemList[i].out_rectf, sf);
                                    }
                                }
                                else
                                {
                                    g.FillEllipse(Normal_sb_inBackColor, this.unLockItemList[i].in_rectf);
                                }
                            }
                            this.DrawUnLockLine(g, Pass_pen_lineColor);
                            break;
                            #endregion
                        }
                    case UnLockStatus.Error:
                        {
                            #region
                            for (int i = 0; i < this.unLockItemList.Count; i++)
                            {
                                if (this.unLockItemList[i].status == UnLockItemStatuss.Select)
                                {
                                    g.FillEllipse(Error_sb_outBackColor, this.unLockItemList[i].out_rectf);
                                    g.DrawEllipse(Error_pen_outLineColor, this.unLockItemList[i].out_rectf);
                                    if (this.UnLockType == UnLockPatternTypes.Pattern)
                                    {
                                        g.FillEllipse(Error_sb_inBackColor, this.unLockItemList[i].in_rectf);
                                    }
                                    else
                                    {
                                        g.DrawString(this.unLockItemList[i].value, this.UnLockFont, Error_sb_inBackColor, this.unLockItemList[i].out_rectf, sf);
                                    }
                                }
                                else
                                {
                                    g.FillEllipse(Normal_sb_inBackColor, this.unLockItemList[i].in_rectf);
                                }
                            }
                            this.DrawUnLockLine(g, Error_pen_lineColor);
                            break;
                            #endregion
                        }
                }
                #endregion

                #region 释放
                if (Normal_sb_inBackColor != null)
                    Normal_sb_inBackColor.Dispose();
                if (Normal_sb_outBackColor != null)
                    Normal_sb_outBackColor.Dispose();
                if (Normal_pen_outLineColor != null)
                    Normal_pen_outLineColor.Dispose();
                if (Normal_pen_lineColor != null)
                    Normal_pen_lineColor.Dispose();

                if (Pass_sb_inBackColor != null)
                    Pass_sb_inBackColor.Dispose();
                if (Pass_sb_outBackColor != null)
                    Pass_sb_outBackColor.Dispose();
                if (Pass_pen_outLineColor != null)
                    Pass_pen_outLineColor.Dispose();
                if (Pass_pen_lineColor != null)
                    Pass_pen_lineColor.Dispose();

                if (Error_sb_inBackColor != null)
                    Error_sb_inBackColor.Dispose();
                if (Error_sb_outBackColor != null)
                    Error_sb_outBackColor.Dispose();
                if (Error_pen_outLineColor != null)
                    Error_pen_outLineColor.Dispose();
                if (Error_pen_lineColor != null)
                    Error_pen_lineColor.Dispose();
                #endregion
            }
            #endregion

            if (sf != null)
                sf.Dispose();

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (this.unLockStatus == UnLockStatus.Normal)
            {
                this.moveDown = true;
                this.unLockStatus = UnLockStatus.UnLock;

                for (int i = 0; i < this.unLockItemList.Count; i++)
                {
                    if (this.unLockItemList[i].gp.IsVisible(e.Location))
                    {
                        if (this.unLockItemList[i].status == UnLockItemStatuss.Normal)
                        {
                            this.unLockItemList[i].status = UnLockItemStatuss.Select;
                            this.selectList.Add(i, this.unLockItemList[i].value);
                            this.moveDownPoint = e.Location;
                            this.Invalidate();
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            this.moveDown = false;
            if (this.unLockStatus == UnLockStatus.UnLock)
            {
                this.unLockStatus = UnLockStatus.Finish;
                if (this.selectList.Count > 0)
                {
                    this.UnLockValid();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.moveDown = false;
            if (this.unLockStatus == UnLockStatus.UnLock)
            {
                this.unLockStatus = UnLockStatus.Finish;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.moveDown)
            {
                if (this.unLockStatus == UnLockStatus.UnLock)
                {
                    for (int i = 0; i < this.unLockItemList.Count; i++)
                    {
                        if (this.unLockItemList[i].gp.IsVisible(e.Location))
                        {
                            if (this.unLockItemList[i].status == UnLockItemStatuss.Normal)
                            {
                                this.unLockItemList[i].status = UnLockItemStatuss.Select;
                                this.selectList.Add(i, this.unLockItemList[i].value);
                            }
                            this.moveDownPoint = e.Location;
                            this.Invalidate();
                            return;
                        }
                    }
                    this.moveDownPoint = e.Location;
                    this.Invalidate();
                }
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, width, specified);
            this.InitializeUnLockRectangle();
            this.Invalidate();
        }

        #endregion

        #region 虚方法

        protected virtual void OnUnLock(UnLockEventArgs e)
        {
            if (this.unLock != null)
            {
                this.unLock(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 重置解锁
        /// </summary>
        public void UnLockReset()
        {
            this.unLockStatus = UnLockStatus.Normal;
            this.selectList.Clear();
            for (int i = 0; i < this.unLockItemList.Count; i++)
            {
                this.unLockItemList[i].status = UnLockItemStatuss.Normal;
            }
            if (this.Type == FunctionTypes.Create)
            {
                this.Value = String.Empty;
            }
            this.Invalidate();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化所有解锁选项Rectangle
        /// </summary>
        private void InitializeUnLockRectangle()
        {
            /*解锁圆形的直径自动计算方式（解锁圆形包括内圆、外圆、外圆边厚度）
            1.解锁圆形的内圆直径=解锁圆形的外圆直径五分之一
            2.解锁圆形之间间距=解锁圆形的外圆直径十分之七
            3.解锁圆形的外圆边厚度=解锁圆形的内圆直径三分之一
             
             控件工作区的矩形宽度=内边距*2+外圆直径*3+圆形之间间距*2+外圆边厚度*2
            */

            float rect_width = (float)this.ClientRectangle.Width;
            float draw_padding = 2f;//绘图区内边距
            float draw_width = rect_width - draw_padding * 2f;//绘图区宽度
            float circle_out_diameter = draw_width * 15f / 68f;//外圆直径  公式原型：rect_width=(draw_padding*2)+(circle_out_diameter*3)+(circle_out_diameter*0.7*2)+(circle_out_diameter/5/3*2)
            float circle_in_diameter = circle_out_diameter / 5f;//内圆直径
            float circle_interval = circle_out_diameter * 0.7f;//圆形间距
            float circle_border = circle_out_diameter / (5f * 3f);//外圆边厚度
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int index = x * 3 + y;
                    RectangleF out_rectf = new RectangleF(draw_padding + circle_border + y * circle_out_diameter + circle_interval * y, draw_padding + circle_border + x * circle_out_diameter + circle_interval * x, circle_out_diameter, circle_out_diameter);
                    RectangleF in_rectf = new RectangleF(out_rectf.Left + circle_in_diameter * 2f, out_rectf.Top + circle_in_diameter * 2f, circle_in_diameter, circle_in_diameter);
                    this.unLockItemList[index].out_rectf = out_rectf;
                    this.unLockItemList[index].in_rectf = in_rectf;
                    this.unLockItemList[index].pointf = new PointF(out_rectf.Left + out_rectf.Width / 2f, out_rectf.Top + out_rectf.Height / 2f);
                    this.unLockItemList[index].gp.Reset();
                    this.unLockItemList[index].gp.AddEllipse(out_rectf);
                }
            }
        }

        /// <summary>
        /// 解锁验证
        /// </summary>
        /// <returns></returns>
        private void UnLockValid()
        {
            string str = String.Concat(this.selectList.Values.ToList<string>());
            UnLockEventArgs data = new UnLockEventArgs();
            data.Value = str;
            if (this.Type == FunctionTypes.Valid)
            {
                data.Result = (this.Value == str);
                this.unLockStatus = data.Result ? UnLockStatus.Pass : UnLockStatus.Error;
            }
            else
            {
                data.Result = true;
            }
            this.Invalidate();

            this.OnUnLock(data);
        }

        /// <summary>
        /// 绘制解锁路径线条
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        private void DrawUnLockLine(Graphics g, Pen pen)
        {
            for (int j = 0; j < this.selectList.Count - 1; j++)
            {
                g.DrawLine(pen, this.unLockItemList[this.selectList.ElementAt(j).Key].pointf, this.unLockItemList[this.selectList.ElementAt(j + 1).Key].pointf);
            }
            if (this.selectList.Count > 0 && this.unLockStatus == UnLockStatus.UnLock)
            {
                g.DrawLine(pen, this.unLockItemList[this.selectList.ElementAt(this.selectList.Count - 1).Key].pointf, this.moveDownPoint);
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 解锁选项
        /// </summary>
        [Description("解锁选项")]
        public class UnLockItem
        {
            /// <summary>
            /// 图案外rectf
            /// </summary>
            public RectangleF out_rectf { get; set; }
            /// <summary>
            /// 图案内rectf
            /// </summary>
            public RectangleF in_rectf { get; set; }
            /// <summary>
            /// 图案path
            /// </summary>
            public GraphicsPath gp { get; set; }
            /// <summary>
            /// 图案中心point
            /// </summary>
            public PointF pointf { get; set; }
            /// <summary>
            /// 图案选项状态
            /// </summary>
            public UnLockItemStatuss status { get; set; }
            /// <summary>
            /// 值
            /// </summary>
            public string value { get; set; }
        }

        /// <summary>
        /// 解锁事件参数
        /// </summary>
        [Description("解锁事件参数")]
        public class UnLockEventArgs : EventArgs
        {
            /// <summary>
            /// 解锁验证结果
            /// </summary>
            [Description("解锁结果")]
            public bool Result { get; set; }
            /// <summary>
            /// 解锁生成结果
            /// </summary>
            [Description("解锁生成结果")]
            public string Value { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 功能类型
        /// </summary>
        [Description("功能类型")]
        public enum FunctionTypes
        {
            /// <summary>
            /// 验证
            /// </summary>
            Valid,
            /// <summary>
            /// 生成
            /// </summary>
            Create
        }

        /// <summary>
        /// 解锁图案类型
        /// </summary>
        [Description("解锁图案类型")]
        public enum UnLockPatternTypes
        {
            /// <summary>
            /// 数字
            /// </summary>
            Number,
            /// <summary>
            /// 图案
            /// </summary>
            Pattern
        }

        /// <summary>
        /// 解锁状态
        /// </summary>
        [Description("解锁状态")]
        public enum UnLockStatus
        {
            /// <summary>
            /// 正常(默认)
            /// </summary>
            Normal,
            /// <summary>
            /// 解锁中
            /// </summary>
            UnLock,
            /// <summary>
            /// 完成中
            /// </summary>
            Finish,
            /// <summary>
            /// 通过
            /// </summary>
            Pass,
            /// <summary>
            /// 错误
            /// </summary>
            Error
        }

        /// <summary>
        /// 解锁选项状态
        /// </summary>
        [Description("解锁选项状态")]
        public enum UnLockItemStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 选中
            /// </summary>
            Select
        }

        #endregion

    }

}
