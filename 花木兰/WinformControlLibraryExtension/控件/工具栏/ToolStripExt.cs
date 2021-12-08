
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// ToolStripExt工具栏
    /// </summary>
    [Description("ToolStripExt工具栏")]
    [ToolboxItem(true)]
    public class ToolStripExt : ToolStrip
    {
        #region 重写属性

        /// <summary>
        ///  的前景色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Browsable(true)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (base.ForeColor == value)
                    return;

                base.ForeColor = value;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ToolStripRenderMode RenderMode
        {
            get
            {
                return ToolStripRenderMode.Professional;
            }
            set
            {
                base.RenderMode = ToolStripRenderMode.Professional;
            }
        }

        #endregion

        public ToolStripExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.ForeColor = Color.FromArgb(255, 255, 255);
            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ToolStripExtRenderer(new ToolStripExtColorTable());
        }

    }

    /// <summary>
    /// ToolStripExt渲染器
    /// </summary>
    [Description("ToolStripExt渲染器")]
    public class ToolStripExtRenderer : ToolStripProfessionalRenderer
    {
        #region 属性

        private ToolStripExtColorTable colorTable;
        /// <summary>
        /// 用于绘制的调色板
        /// </summary>
        [Description("用于绘制的调色板")]
        public new ToolStripExtColorTable ColorTable
        {
            get
            {
                if (this.colorTable == null)
                    this.colorTable = new ToolStripExtColorTable();

                return this.colorTable;
            }
            set
            {
                if (this.colorTable == value)
                    return;

                this.colorTable = value;
            }
        }

        #endregion

        #region 构造器

        public ToolStripExtRenderer() : base()
        {

        }

        public ToolStripExtRenderer(ToolStripExtColorTable customColorTable) : base(customColorTable)
        {
            this.colorTable = customColorTable;
            this.RoundedEdges = false;
        }

        #endregion

        #region 重写

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = this.colorTable.ArrowColor;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            bool istop = ((e.ToolStrip is MenuStripExt) || (e.ToolStrip is ToolStripExt) || (e.ToolStrip is StatusStripExt));
            if ((!istop) || (istop && e.Item.Pressed))
            {
                e.TextColor = this.colorTable.MenuItemText;
            }

            base.OnRenderItemText(e);
        }

        #endregion
    }

    /// <summary>
    /// ToolStripExt调色板
    /// </summary>
    [Description("ToolStripExt调色板")]
    public class ToolStripExtColorTable : ProfessionalColorTable
    {
        public ToolStripExtColorTable() : base()
        {

        }

        #region MenuStrip 

        /// <summary>
        /// System.Windows.Forms.MenuStrip 上使用的边框颜色。
        /// </summary>
        public override Color MenuBorder { get { return Color.FromArgb(137, 158, 136); } }

        /// <summary>
        /// System.Windows.Forms.MenuStrip 中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color MenuStripGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.MenuStrip 中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color MenuStripGradientEnd { get { return Color.Empty; } }

        #endregion

        #region  ToolStrip 

        /// <summary>
        /// System.Windows.Forms.ToolStrip 的下边缘使用的边框颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripBorder { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.ToolStrip 背景中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.ToolStrip 背景中使用的渐变的中间颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripGradientMiddle { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.ToolStrip 背景中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripGradientEnd { get { return Color.Empty; } }

        #endregion

        #region ToolStripPanel 

        /// <summary>
        /// System.Windows.Forms.ToolStripPanel 中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripPanelGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.ToolStripPanel 中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripPanelGradientEnd { get { return Color.Empty; } }

        #endregion

        #region ToolStripContentPanel 

        /// <summary>
        /// System.Windows.Forms.ToolStripContentPanel 中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripContentPanelGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.ToolStripContentPanel 中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ToolStripContentPanelGradientEnd { get { return Color.Empty; } }

        #endregion

        #region  ToolStripContainer 

        /// <summary>
        /// System.Windows.Forms.ToolStripContainer 中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color RaftingContainerGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.ToolStripContainer 中使用的渐变的结束颜色
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color RaftingContainerGradientEnd { get { return Color.Empty; } }

        #endregion

        #region ToolStripSeparator 

        /// <summary>
        /// System.Windows.Forms.ToolStripSeparator 上的阴影效果的颜色。
        /// </summary>
        public override Color SeparatorDark { get { return Color.FromArgb(140, 140, 140); } }

        /// <summary>
        /// System.Windows.Forms.ToolStripSeparator 上的突出显示效果的颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color SeparatorLight { get { return Color.Transparent; } }

        #endregion

        #region ToolStripOverflowButton 

        /// <summary>
        /// System.Windows.Forms.ToolStripOverflowButton 中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color OverflowButtonGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripOverflowButton 中使用的渐变的中间颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color OverflowButtonGradientMiddle { get { return Color.Empty; } }

        /// <summary>
        ///  获取在 System.Windows.Forms.ToolStripOverflowButton 中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color OverflowButtonGradientEnd { get { return Color.Empty; } }

        #endregion

        #region ToolStripMenuItem 

        /// <summary>
        /// ToolStripMenuItem边框颜色(选中)
        /// </summary>
        public override Color MenuItemBorder { get { return Color.FromArgb(176, 197, 175); } }

        /// <summary>
        /// 选中除顶级 ToolStripMenuItem背景颜色(选中)
        /// </summary>
        public override Color MenuItemSelected { get { return Color.FromArgb(189, 208, 188); } }

        /// <summary>
        /// ToolStripMenuItem控件背景色渐变的开始颜色(选中)
        /// </summary>
        public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(100, 255, 255, 255); } }

        /// <summary>
        /// ToolStripMenuItem控件背景色渐变的结束颜色(选中)
        /// </summary>
        public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(100, 255, 255, 255); } }


        /// <summary>
        /// 获取顶级 System.Windows.Forms.ToolStripMenuItem 被按下时使用的渐变的开始颜色。
        /// </summary>
        public override Color MenuItemPressedGradientBegin { get { return Color.FromArgb(255, 255, 255); } }

        /// <summary>
        /// 顶级 System.Windows.Forms.ToolStripMenuItem 被按下时使用的渐变的中间颜色。
        /// </summary>
        public override Color MenuItemPressedGradientMiddle { get { return Color.FromArgb(255, 255, 255); } }

        /// <summary>
        /// 顶级 System.Windows.Forms.ToolStripMenuItem 被按下时使用的渐变的结束颜色。
        /// </summary>
        public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(255, 255, 255); } }


        /// <summary>
        ///  ToolStripMenuItem 文本颜色
        /// </summary>
        public virtual Color MenuItemText { get { return Color.FromArgb(109, 109, 109); } }

        #endregion

        #region ToolStripDropDown 

        /// <summary>
        /// System.Windows.Forms.ToolStripDropDown 的纯色背景色。
        /// </summary>
        public override Color ToolStripDropDownBackground { get { return Color.FromArgb(240, 240, 240); } }

        #endregion

        #region ToolStripDropDownMenu图像背景色 

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的中间颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginGradientMiddle { get { return Color.Empty; } }

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginGradientEnd { get { return Color.Empty; } }

        #endregion

        #region ToolStripDropDownMenu图像边距背景色 

        /// <summary>
        /// 在显示项时在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginRevealedGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// 在显示项时在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的中间颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginRevealedGradientMiddle { get { return Color.Empty; } }

        /// <summary>
        /// 在显示项时在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginRevealedGradientEnd { get { return Color.Empty; } }

        #endregion

        #region StatusStrip 

        /// <summary>
        /// System.Windows.Forms.StatusStrip 上使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color StatusStripGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// System.Windows.Forms.StatusStrip 上使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color StatusStripGradientEnd { get { return Color.Empty; } }

        #endregion

        #region 移动句柄圆点背景色 

        /// <summary>
        /// 获取用于手柄（移动句柄）上的阴影效果的颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color GripDark { get { return Color.Empty; } }

        /// <summary>
        /// 获取用于手柄（移动句柄）上的突出显示效果的颜色。
        /// </summary>
        public override Color GripLight { get { return Color.FromArgb(255, 255, 255); } }

        #endregion

        #region ButtonSelected鼠标进入 

        /// <summary>
        /// ToolStripMenuItem控件边框颜色(选中)
        /// </summary>
        public override Color ButtonSelectedHighlightBorder { get { return Color.FromArgb(50, 109, 109, 109); } }

        /// <summary>
        /// 获取按钮被选定时使用的纯色
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonSelectedHighlight { get { return Color.FromArgb(100, 255, 255, 255); } }

        /// <summary>
        /// 获取按钮被选定时使用的渐变的开始颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonSelectedGradientBegin { get { return Color.FromArgb(100, 255, 255, 255); } }

        /// <summary>
        /// 获取按钮被选定时使用的渐变的中间颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonSelectedGradientMiddle { get { return Color.FromArgb(100, 255, 255, 255); } }

        /// <summary>
        /// 获取按钮被选定时使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonSelectedGradientEnd { get { return Color.FromArgb(100, 255, 255, 255); } }

        #endregion

        #region ButtonPressed鼠标按下 

        /// <summary>
        /// 获取用于 System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight 的边框颜色。
        /// </summary>
        public override Color ButtonPressedHighlightBorder { get { return Color.FromArgb(150, 255, 255, 255); } }

        /// <summary>
        /// 获取按钮被按下时使用的纯色。
        /// </summary>
        public override Color ButtonPressedHighlight { get { return Color.FromArgb(50, 109, 109, 109); } }

        /// <summary>
        /// 获取用于 System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin、System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle和 System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd 颜色的边框颜色。
        /// </summary>
        public override Color ButtonPressedBorder { get { return Color.FromArgb(50, 109, 109, 109); } }

        /// <summary>
        /// 获取按钮被按下时使用的渐变的开始颜色。
        /// </summary>
        public override Color ButtonPressedGradientBegin { get { return Color.FromArgb(50, 109, 109, 109); } }

        /// <summary>
        /// 获取按钮被按下时使用的渐变的中间颜色。
        /// </summary>
        public override Color ButtonPressedGradientMiddle { get { return Color.FromArgb(50, 109, 109, 109); } }

        /// <summary>
        /// 获取按钮被按下时使用的渐变的结束颜色。
        /// </summary>
        public override Color ButtonPressedGradientEnd { get { return Color.FromArgb(50, 109, 109, 109); } }

        #endregion

        #region ButtonChecked选中 

        /// <summary>
        /// 获取用于 System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight 的边框颜色。
        /// </summary>
        public override Color ButtonCheckedHighlightBorder { get { return Color.FromArgb(137, 158, 136); } }

        /// <summary>
        /// 获取按钮被选中时使用的纯色。
        /// </summary>
        public override Color ButtonCheckedHighlight { get { return Color.FromArgb(137, 158, 136); } }

        /// <summary>
        /// 获取按钮被选中时使用的渐变的开始颜色。
        /// </summary>
        public override Color ButtonCheckedGradientBegin { get { return Color.FromArgb(137, 158, 136); } }

        /// <summary>
        /// 获取按钮被选中时使用的渐变的中间颜色。
        /// </summary>
        public override Color ButtonCheckedGradientMiddle { get { return Color.FromArgb(137, 158, 136); } }

        /// <summary>
        /// 获取按钮被选中时使用的渐变的结束颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonCheckedGradientEnd { get { return Color.FromArgb(137, 158, 136); } }

        #endregion

        #region 下拉列表左边选项状态Checked、UnCheck  

        /// <summary>
        /// 获取用于 System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin、System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle和 System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd 颜色的边框颜色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonSelectedBorder { get { return Color.Empty; } }

        /// <summary>
        /// 获取按钮被选中并且正在使用渐变时使用的纯色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color CheckBackground { get { return Color.Empty; } }

        /// <summary>
        /// 获取按钮被选中和选定并且正在使用渐变时使用的纯色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color CheckSelectedBackground { get { return Color.Empty; } }

        /// <summary>
        /// 获取按钮被选中和选定并且正在使用渐变时使用的纯色。
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color CheckPressedBackground { get { return Color.Empty; } }

        #endregion

        #region Arrow 

        /// <summary>
        ///  获取 System.Windows.Forms.ToolStrip 箭头的颜色。
        /// </summary>
        public virtual Color ArrowColor { get { return Color.FromArgb(109, 109, 109); } }

        #endregion

        /// <summary>
        /// 获取或设置一个值，该值指示是否使用 System.Drawing.SystemColors，而不是使用与当前视觉样式匹配的颜色。
        /// </summary>
        public bool UseSystemColors { get { return false; } set { base.UseSystemColors = false; } }

    }

}
