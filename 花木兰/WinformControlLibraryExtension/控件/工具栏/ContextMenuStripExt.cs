
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

namespace WinformControlLibraryExtension
{

    /// <summary>
    /// ContextMenuStripExt右键菜单
    /// </summary>
    [Description("ContextMenuStripExt右键菜单")]
    [ToolboxItem(true)]
    public class ContextMenuStripExt : ContextMenuStrip
    {
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

        public ContextMenuStripExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ContextMenuStripExtRenderer(new ContextMenuStripExtColorTable());
        }

    }

    /// <summary>
    /// ContextMenuStripExt渲染器
    /// </summary>
    [Description("ContextMenuStripExt渲染器")]
    public class ContextMenuStripExtRenderer : ToolStripProfessionalRenderer
    {
        #region 属性

        private ContextMenuStripExtColorTable colorTable;
        /// <summary>
        /// 用于绘制的调色板
        /// </summary>
        [Description("用于绘制的调色板")]
        public new ContextMenuStripExtColorTable ColorTable
        {
            get
            {
                if (this.colorTable == null)
                    this.colorTable = new ContextMenuStripExtColorTable();

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

        public ContextMenuStripExtRenderer() : base()
        {

        }

        public ContextMenuStripExtRenderer(ContextMenuStripExtColorTable _colorTable) : base(_colorTable)
        {
            this.colorTable = _colorTable;
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
            if (e.Item.Selected)
            {
                e.TextColor = this.colorTable.MenuItemSelectedText;
            }
            else if (e.Item.Pressed)
            {
                e.TextColor = this.colorTable.MenuItemPressedText;
            }
            else
            {
                e.TextColor = this.colorTable.MenuItemText;
            }
            base.OnRenderItemText(e);
        }

        #endregion
    }

    /// <summary>
    /// ContextMenuStripExt调色板
    /// </summary>
    [Description("ContextMenuStripExt调色板")]
    public class ContextMenuStripExtColorTable : ProfessionalColorTable
    {
        public ContextMenuStripExtColorTable() : base()
        {

        }

        #region MenuStrip 

        /// <summary>
        /// ContextMenuStripExt边框颜色
        /// </summary>
        public override Color MenuBorder { get { return Color.FromArgb(137, 158, 136); } }

        /// <summary>
        /// ContextMenuStripExt背景色
        /// </summary>
        public override Color ToolStripDropDownBackground { get { return Color.FromArgb(240, 240, 240); } }

        /// <summary>
        ///  ContextMenuStripExt箭头的颜色
        /// </summary>
        public virtual Color ArrowColor { get { return Color.FromArgb(109, 109, 109); } }

        #endregion

        #region ToolStripMenuItem 

        /// <summary>
        /// ToolStripMenuItem边框颜色(选中)
        /// </summary>
        public override Color MenuItemBorder { get { return Color.FromArgb(176, 197, 175); } }
        /// <summary>
        /// ToolStripMenuItem背景颜色(选中)
        /// </summary>
        public override Color MenuItemSelected { get { return Color.FromArgb(189, 208, 188); } }

        /// <summary>
        /// ToolStripMenuItem控件边框颜色(选中)
        /// </summary>
        public override Color ButtonSelectedHighlightBorder { get { return Color.FromArgb(50, 109, 109, 109); } }
        /// <summary>
        /// ToolStripMenuItem控件背景色渐变的开始颜色(选中)
        /// </summary>
        public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(240, 240, 240); } }
        /// <summary>
        /// ToolStripMenuItem控件背景色渐变的结束颜色(选中)
        /// </summary>
        public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(240, 240, 240); } }

        /// <summary>
        ///  ToolStripMenuItem 文本颜色
        /// </summary>
        public virtual Color MenuItemText { get { return Color.FromArgb(109, 109, 109); } }
        /// <summary>
        ///  ToolStripMenuItem 文本颜色(选中)
        /// </summary>
        public virtual Color MenuItemSelectedText { get { return Color.FromArgb(109, 109, 109); } }
        /// <summary>
        ///  ToolStripMenuItem 文本颜色(按下)
        /// </summary>
        public virtual Color MenuItemPressedText { get { return Color.FromArgb(109, 109, 109); } }

        #endregion

        #region 下拉列表选项左边状态Checked、UnCheck  

        /// <summary>
        /// 下拉列表选项左边状态边框颜色
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ButtonSelectedBorder { get { return Color.Empty; } }

        /// <summary>
        /// 下拉列表选项左边状态背景颜色
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color CheckBackground { get { return Color.Empty; } }

        /// <summary>
        /// 下拉列表选项左边状态背景颜色(选中)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color CheckSelectedBackground { get { return Color.Empty; } }

        /// <summary>
        /// 下拉列表选项左边状态背景颜色(按下)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color CheckPressedBackground { get { return Color.Empty; } }

        #endregion

        #region ToolStripDropDownMenu图像背景色 

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的开始颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginGradientBegin { get { return Color.Empty; } }

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的中间颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginGradientMiddle { get { return Color.Empty; } }

        /// <summary>
        /// 获取在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的结束颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginGradientEnd { get { return Color.Empty; } }

        #endregion

        #region ToolStripDropDownMenu图像边距背景色 

        /// <summary>
        /// 在显示项时在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的开始颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginRevealedGradientBegin { get { return Color.Empty; } } 

        /// <summary>
        /// 在显示项时在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的中间颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginRevealedGradientMiddle { get { return Color.Empty; } } 

        /// <summary>
        /// 在显示项时在 System.Windows.Forms.ToolStripDropDownMenu 的图像边距中使用的渐变的结束颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ImageMarginRevealedGradientEnd { get { return Color.Empty; } } 

        #endregion

        #region 分割线ToolStripSeparator 

        /// <summary>
        /// 分割线上的阴影效果的颜色。
        /// </summary>
        public override Color SeparatorDark { get { return Color.FromArgb(140, 140, 140); } }

        /// <summary>
        /// 分割线上的突出显示效果的颜色。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color SeparatorLight { get { return Color.Transparent; } }

        #endregion

        /// <summary>
        /// 获取或设置一个值，该值指示是否使用 System.Drawing.SystemColors，而不是使用与当前视觉样式匹配的颜色。
        /// </summary>
        public bool UseSystemColors { get { return false; } set { base.UseSystemColors = false; } }

    }
}
