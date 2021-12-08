
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinformControlLibraryExtension.Design
{
    /// <summary>
    /// ImageCarousel控件设计模式行为
    /// </summary>
    [Description("ImageCarousel控件设计模式行为")]
    public class ImageCarouselExtDesigner : ControlDesigner
    {
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
            this.DrawTipText(pe.Graphics);
            this.DrawBorder(pe.Graphics);
        }

        /// <summary>
        /// 绘制虚线边框
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawBorder(Graphics graphics)
        {
            ImageCarouselExt control = (ImageCarouselExt)this.Control;
            Rectangle clientRectangle = control.ClientRectangle;
            Pen pen = new Pen((double)control.BackColor.GetBrightness() >= 0.5 ? ControlPaint.Dark(control.BackColor) : ControlPaint.Light(control.BackColor));
            pen.DashStyle = DashStyle.Dash;
            --clientRectangle.Width;
            --clientRectangle.Height;
            graphics.DrawRectangle(pen, clientRectangle);

            #region
            RectangleF rectf = control.GetDisplayRectangle();
            pen.DashStyle = DashStyle.Solid;
            pen.Color = Color.OliveDrab;
            graphics.DrawRectangle(pen, rectf.X, rectf.Y, rectf.Width, rectf.Height);
            #endregion

            pen.Dispose();
        }

        /// <summary>
        /// 绘制提示文本
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawTipText(Graphics graphics)
        {
            ImageCarouselExt _control = (ImageCarouselExt)this.Control;
            Control control = this.Control;
            if (_control.Images.Count < 1)
            {
                string text = "请添加图片";
                SizeF text_size = graphics.MeasureString(text, _control.Font);
                SolidBrush text_sb = new SolidBrush((double)control.BackColor.GetBrightness() >= 0.5 ? ControlPaint.Dark(control.BackColor) : ControlPaint.Light(control.BackColor));
                graphics.DrawString(text, _control.Font, text_sb, new RectangleF(control.ClientRectangle.X + (control.ClientRectangle.Width - text_size.Width) / 2f, control.ClientRectangle.Y + (control.ClientRectangle.Height - text_size.Height) / 2f, text_size.Width, text_size.Height));
                text_sb.Dispose();
            }
        }

    }
}
