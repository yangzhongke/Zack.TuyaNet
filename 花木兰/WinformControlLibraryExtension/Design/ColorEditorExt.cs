
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

using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace System.ComponentModel.Design
{
    /// <summary>
    /// 选取颜色(可选透明度)
    /// </summary>
    [Description("选取颜色(可选透明度)")]
  public class ColorEditorExt : ColorEditor
  {
    private ColorEditorUIWrapper colorEditorUIWrapper;

    public ColorEditorExt()
    {

    }

    /// <summary>
    /// 编辑给定的对象值
    /// </summary>
    /// <param name="context">可用于获取附加上下文信息</param>
    /// <param name="provider">通过它可能获得编辑服务</param>
    /// <param name="value">正在编辑的值的实例</param>
    /// <returns>对象的新值</returns>
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (provider != null)
      {
        IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        if (edSvc != null)
        {
          if (this.colorEditorUIWrapper == null)
          {
            this.colorEditorUIWrapper = new ColorEditorUIWrapper(this);
          }
          this.colorEditorUIWrapper.Start(edSvc, value);
          edSvc.DropDownControl(this.colorEditorUIWrapper.Control);
          if ((colorEditorUIWrapper.Value != null) && ((Color)this.colorEditorUIWrapper.Value != Color.Empty))
          {
            value = this.colorEditorUIWrapper.Value;
          }
          this.colorEditorUIWrapper.End();
        }
      }
      return value;
    }

    /// <summary>
    /// 绘制代表提供的画布上的给定对象的值。
    /// </summary>
    /// <param name="e">绘制内容和绘制位置。 </param>
    public override void PaintValue(PaintValueEventArgs e)
    {
      if (!(e.Value is Color))
        return;
      Color color = (Color)e.Value;
      Pen pen = new Pen(Color.Gray);
      SolidBrush solidBrush1 = new SolidBrush((color == Color.Empty || color == Color.Transparent) ? Color.Empty : Color.FromArgb(color.R, color.G, color.B));
      SolidBrush solidBrush2 = new SolidBrush(color);
      e.Graphics.FillRectangle(solidBrush1, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width / 2, e.Bounds.Height));
      if (!(color == Color.Empty || color == Color.Transparent))
        e.Graphics.DrawLine(pen, e.Bounds.Width / 2 + 1, e.Bounds.Y, e.Bounds.Width / 2 + 1, e.Bounds.Bottom - 2);
      e.Graphics.FillRectangle(solidBrush2, new Rectangle(e.Bounds.Width / 2, e.Bounds.Y, e.Bounds.Width / 2, e.Bounds.Height));
      solidBrush1.Dispose();
      solidBrush2.Dispose();
      pen.Dispose();
    }

    /// <summary>
    /// 颜色编辑器面板
    /// </summary>
    [Description("颜色编辑器面板")]
    public class ColorEditorUIWrapper
    {
      private Control ower;
      private Panel alphaPanel;
      private Label alphadesLabel;
      private TrackBar alphaTrackBar;
      private Label alphaLabel;
      private Label alphacolorLabel;
      private MethodInfo startMethodInfo;
      private MethodInfo endMethodInfo;
      private PropertyInfo valuePropertyInfo;

      public ColorEditorUIWrapper(ColorEditorExt _ower)
      {
        Type colorUiType = typeof(ColorEditor).GetNestedType("ColorUI", BindingFlags.CreateInstance | BindingFlags.NonPublic);
        ConstructorInfo constructorInfo = colorUiType.GetConstructor(new Type[] { typeof(ColorEditor) });
        this.ower = (Control)constructorInfo.Invoke(new object[] { _ower });
        this.startMethodInfo = this.ower.GetType().GetMethod("Start");
        this.endMethodInfo = this.ower.GetType().GetMethod("End");
        this.valuePropertyInfo = this.ower.GetType().GetProperty("Value");

        this.alphaPanel = new Panel();
        this.alphadesLabel = new Label();
        this.alphaTrackBar = new TrackBar();
        this.alphaLabel = new Label();
        this.alphacolorLabel = new Label();
        // 
        // alphaPanel
        // 
        this.alphaPanel.BackColor = this.ower.BackColor;
        this.alphaPanel.Dock = DockStyle.Right;
        this.alphaPanel.Width = 45;
        this.alphaPanel.Controls.Add(this.alphaTrackBar);
        this.alphaPanel.Controls.Add(this.alphadesLabel);
        this.alphaPanel.Controls.Add(this.alphaLabel);
        this.alphaPanel.Controls.Add(this.alphacolorLabel);
        // 
        // alphaTrackBar
        // 
        this.alphaTrackBar.BackColor = this.ower.BackColor;
        this.alphaTrackBar.Dock = DockStyle.Fill;
        this.alphaTrackBar.Orientation = Orientation.Vertical;
        this.alphaTrackBar.TickStyle = TickStyle.Both;
        this.alphaTrackBar.Maximum = byte.MaxValue;
        this.alphaTrackBar.Minimum = byte.MinValue;
        this.alphaTrackBar.SmallChange = 1;
        this.alphaTrackBar.LargeChange = 1;
        this.alphaTrackBar.ValueChanged += new EventHandler(this.alphaTrackBar_ValueChanged);
        // 
        // alphadesLabel
        // 
        this.alphadesLabel.BackColor = this.ower.BackColor;
        this.alphadesLabel.Dock = DockStyle.Top;
        this.alphadesLabel.Text = "透明度";
        this.alphadesLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // alphaLabel
        // 
        this.alphaLabel.BackColor = this.ower.BackColor;
        this.alphaLabel.Dock = DockStyle.Bottom;
        this.alphaLabel.Text = "0";
        this.alphaLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // alphacolorLabel
        // 
        this.alphacolorLabel.BackColor = this.ower.BackColor;
        this.alphacolorLabel.Dock = DockStyle.Bottom;
        this.alphacolorLabel.AutoSize = false;
        this.alphacolorLabel.Height = 24;
        this.alphacolorLabel.Text = "";
        this.alphacolorLabel.TextAlign = ContentAlignment.MiddleCenter;
        this.alphacolorLabel.Paint += new PaintEventHandler(this.alphacolorLabel_Paint);

        this.ower.Controls.Add(this.alphaPanel);
      }

      /// <summary>
      /// 编辑颜色时显示的控件
      /// </summary>
      public Control Control
      {
        get { return this.ower; }
      }

      /// <summary>
      /// 获取具有透明度颜色值
      /// </summary>
      public object Value
      {
        get
        {
          object result = this.valuePropertyInfo.GetValue(ower, new object[0]);
          if (result is Color)
          {
            if ((Color)result != Color.Transparent)
            {
              if (this.alphaTrackBar.Value == 0)
              {
                this.alphaTrackBar.Value = byte.MaxValue;
              }
              result = Color.FromArgb(this.alphaTrackBar.Value, (Color)result);
            }
          }
          return result;
        }
      }

      /// <summary>
      ///启动编辑过程
      /// </summary>
      /// <param name="service">编辑服务</param>
      /// <param name="value">要编辑的值</param>
      public void Start(IWindowsFormsEditorService service, object value)
      {
        if (value is Color)
          this.alphaTrackBar.Value = ((Color)value).A;

        this.startMethodInfo.Invoke(ower, new object[] { service, value });
      }

      /// <summary>
      ///结束编辑过程
      /// </summary>
      public void End()
      {
        this.endMethodInfo.Invoke(ower, new object[0]);
      }

      /// <summary>
      /// 透明度更改事件
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void alphaTrackBar_ValueChanged(object sender, EventArgs e)
      {
        this.alphaLabel.Text = this.alphaTrackBar.Value.ToString();
        this.alphacolorLabel.Invalidate();
      }

      /// <summary>
      /// 颜色预览面板
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void alphacolorLabel_Paint(object sender, PaintEventArgs e)
      {
        object result = this.valuePropertyInfo.GetValue(ower, new object[0]);
        if (result != null && result is Color)
        {
          Color color = (Color)this.Value;
          Graphics g = e.Graphics;
          Pen pen = new Pen(Color.Silver);
          SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(color.R, color.G, color.B));
          SolidBrush solidBrush2 = new SolidBrush(color);
          g.FillRectangle(solidBrush1, new RectangleF(g.ClipBounds.X, g.ClipBounds.Y, g.ClipBounds.Width / 2 - 1, g.ClipBounds.Height - 3));
          g.FillRectangle(solidBrush2, new RectangleF(g.ClipBounds.Width / 2 - 1, g.ClipBounds.Y, g.ClipBounds.Width / 2 - 1, g.ClipBounds.Height - 3));
          g.DrawRectangle(pen, g.ClipBounds.X, g.ClipBounds.Y, g.ClipBounds.Width - 3, g.ClipBounds.Height - 4);
          solidBrush1.Dispose();
          solidBrush2.Dispose();
          pen.Dispose();
        }
      }

    }
  }
}
