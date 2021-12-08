
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 渐变进度控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("渐变进度控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class GradualProgressExt : Control
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 进度值更改事件
        /// </summary>
        [Description("进度值更改事件")]
        public event ValueChangedEventHandler ValueChanged
        {
            add { this.valueChanged += value; }
            remove { this.valueChanged -= value; }
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

        private Orientation orientation = Orientation.Horizontal;
        /// <summary>
        /// 控件方向
        /// </summary>
        [DefaultValue(Orientation.Horizontal)]
        [Description("控件方向")]
        public Orientation Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation == value)
                    return;
                this.orientation = value;
                this.Invalidate();
            }
        }

        private int gridsOpacity = 255;
        /// <summary>
        /// 网格透明度
        /// </summary>
        [DefaultValue(255)]
        [Description("网格透明度")]
        public int GridsOpacity
        {
            get { return this.gridsOpacity; }
            set
            {
                if (this.gridsOpacity == value || value < 0 || value > 255)
                    return;
                this.gridsOpacity = value;
                this.Invalidate();
            }
        }

        private int gridsDistance = 6;
        /// <summary>
        /// 网格距离
        /// </summary>
        [DefaultValue(6)]
        [Description("网格距离")]
        public int GridsDistance
        {
            get { return this.gridsDistance; }
            set
            {
                if (this.gridsDistance == value || value < 1)
                    return;
                this.gridsDistance = value;
                this.Invalidate();
            }
        }

        private Color gridsColor = Color.YellowGreen;
        /// <summary>
        /// 网格颜色
        /// </summary>
        [DefaultValue(typeof(Color), "YellowGreen")]
        [Description("网格颜色")]
        public Color GridsColor
        {
            get { return this.gridsColor; }
            set
            {
                if (this.gridsColor == value)
                    return;
                this.gridsColor = value;
                this.Invalidate();
            }
        }

        private bool valueShow = false;
        /// <summary>
        /// 是否显示进度值
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示进度值")]
        public bool ValueShow
        {
            get { return this.valueShow; }
            set
            {
                if (this.valueShow == value)
                    return;
                this.valueShow = value;
                this.Invalidate();
            }
        }

        private float value = 0.0f;
        /// <summary>
        /// 进度值(0-1)
        /// </summary>
        [DefaultValue(0.0f)]
        [Description("进度值")]
        public float Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value)
                    return;
                if (value > 1)
                    value = 1;
                if (value < 0)
                    value = 0;
                this.value = value;
                this.Invalidate();

                this.OnValueChanged(new ValueChangedEventArgs() { Value = this.value });

            }
        }

        private ColorDrawType progressColorType = ColorDrawType.Level;
        /// <summary>
        /// 进度颜色类型
        /// </summary>
        [DefaultValue(ColorDrawType.Level)]
        [Description("进度颜色类型")]
        public ColorDrawType ProgressColorType
        {
            get { return this.progressColorType; }
            set
            {
                if (this.progressColorType == value)
                    return;
                this.progressColorType = value;
                this.Invalidate();
            }
        }

        private ColorItemCollection colorItemCollection;
        /// <summary>
        /// 颜色级别配置集合
        /// </summary>
        [Description("颜色级别配置集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorItemCollection ColorItems
        {
            get
            {
                if (this.colorItemCollection == null)
                    this.colorItemCollection = new ColorItemCollection(this);
                return this.colorItemCollection;
            }
        }

        #endregion

        #region 重写属性

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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(150, 35); ;
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

        public GradualProgressExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region 重写

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.ClientRectangle.Width < 2 || this.ClientRectangle.Height < 2)
                return;

            Graphics g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            SizeF text_sizef = g.MeasureString("100%", this.Font);

            RectangleF rectf = new RectangleF(0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            PointF text_point = new PointF(0, 0);
            if (this.ValueShow)
            {
                if (this.Orientation == Orientation.Horizontal)
                {
                    rectf = new RectangleF(0, 0, this.ClientRectangle.Width - text_sizef.Width - 1, this.ClientRectangle.Height - 1);
                    text_point = new PointF(rectf.Width, (rectf.Height - text_sizef.Height) / 2);
                }
                else
                {
                    rectf = new RectangleF(0, text_sizef.Height, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - text_sizef.Height - 1);
                    text_point = new PointF((rectf.Width - text_sizef.Width) / 2, 0);
                }
            }

            Pen grids_pen = new Pen(Color.FromArgb(this.GridsOpacity, this.gridsColor));
            #region 生成画笔
            Brush grids_sb = null;
            if (this.ProgressColorType == ColorDrawType.Level)
            {
                Color color = Color.FromArgb(255 - this.BackColor.R, 255 - this.BackColor.G, 255 - this.BackColor.B);
                for (int i = this.ColorItems.Count - 1; i > -1; i--)
                {
                    if (this.Value >= this.ColorItems[i].Position)
                    {
                        color = this.ColorItems[i].Color;
                        break;
                    }
                }
                grids_sb = new SolidBrush(Color.FromArgb(this.GridsOpacity, color));
            }
            else
            {
                grids_sb = this.GetLinearGradientBrush(this.ColorItems, rectf, this.Orientation == Orientation.Horizontal ? 0.0f : -90.0f);
            }
            #endregion

            if (this.Orientation == Orientation.Horizontal)
            {
                float realityValue = rectf.Width * this.Value;
                if (grids_sb != null)
                {
                    g.FillRectangle(grids_sb, 0.0f, 0.0f, realityValue, rectf.Height);
                }
                g.DrawLine(grids_pen, 0, rectf.Height / 2, rectf.Width, rectf.Height / 2);
                int count = (int)Math.Ceiling(rectf.Width / (float)this.GridsDistance);
                for (int i = 0; i < count; i++)
                {
                    float x = this.GridsDistance * i;
                    g.DrawLine(grids_pen, x, 0, x, rectf.Height);
                }
            }
            else
            {
                float realityValue = rectf.Height * this.value;
                if (grids_sb != null)
                {
                    g.FillRectangle(grids_sb, 0.0f, rectf.Bottom - realityValue, rectf.Width, realityValue);//进度值背景
                }
                g.DrawLine(grids_pen, rectf.Width / 2, rectf.Y, rectf.Width / 2, rectf.Bottom);//中线
                int count = (int)Math.Ceiling(rectf.Height / (float)this.GridsDistance);
                for (int i = count - 1; i > -1; i--)
                {
                    int y = (int)(rectf.Bottom - this.GridsDistance * i);
                    g.DrawLine(grids_pen, 0, y, rectf.Width, y);
                }
            }
            g.DrawRectangle(grids_pen, rectf.X, rectf.Y, rectf.Width, rectf.Height);//外边框

            #region 进度值
            if (this.ValueShow)
            {
                SolidBrush text_sb = new SolidBrush(Color.FromArgb(this.GridsOpacity, this.ForeColor));
                string str = ((int)(this.Value * 100)).ToString().PadLeft(3, ' ') + "%";
                g.DrawString(str, this.Font, text_sb, text_point.X, text_point.Y);
                text_sb.Dispose();
            }
            #endregion

            grids_sb.Dispose();
            grids_pen.Dispose();
        }

        #endregion

        #region 虚方法

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            if (this.valueChanged != null)
            {
                this.valueChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取渐变画笔
        /// </summary>
        /// <param name="list"></param>
        /// <param name="rectf"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private LinearGradientBrush GetLinearGradientBrush(ColorItemCollection list, RectangleF rectf, float angle)
        {
            LinearGradientBrush lgb = null;
            if (list == null || list.Count < 0)
                return lgb;

            if (list.Count == 1)
            {
                Color[] colors = new Color[list.Count + 1];
                float[] positions = new float[list.Count + 1];

                for (int i = 0; i <= list.Count; i++)
                {
                    colors[i] = list[i].Color;
                    positions[i] = i;
                }
                ColorBlend blend = new ColorBlend() { Positions = positions, Colors = colors };
                lgb = new LinearGradientBrush(rectf, Color.Transparent, Color.Transparent, angle, true) { InterpolationColors = blend };
            }
            else
            {
                if (list[0].Position != 0)
                    list[0].Position = 0;
                if (list[list.Count - 1].Position != 1)
                    list[list.Count - 1].Position = 1;

                Color[] colors = new Color[list.Count];
                float[] positions = new float[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    colors[i] = list[i].Color;
                    positions[i] = list[i].Position;
                }
                ColorBlend blend = new ColorBlend() { Positions = positions, Colors = colors };
                lgb = new LinearGradientBrush(rectf, Color.Transparent, Color.Transparent, angle, true) { InterpolationColors = blend };
            }
            return lgb;
        }

        #endregion

        #region 类

        /// <summary>
        /// 颜色级别配置集合
        /// </summary>
        [Description("颜色级别配置集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ColorItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList colorItemList = new ArrayList();
            private GradualProgressExt owner;

            public ColorItemCollection(GradualProgressExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ColorItem[] listArray = new ColorItem[this.colorItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ColorItem)this.colorItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.colorItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.colorItemList.Count;
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
                if (!(value is ColorItem))
                {
                    throw new ArgumentException("ColorItem");
                }
                return this.Add((ColorItem)value);
            }

            public int Add(ColorItem item)
            {
                this.colorItemList.Add(item);
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.colorItemList.Clear();
                this.owner.Invalidate();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is ColorItem)
                {
                    return this.Contains((ColorItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ColorItem)
                {
                    return this.colorItemList.IndexOf(item);
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
                if (!(value is ColorItem))
                {
                    throw new ArgumentException("ColorItem");
                }
                this.Remove((ColorItem)value);
            }

            public void Remove(ColorItem item)
            {
                this.colorItemList.Remove(item);
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.colorItemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public ColorItem this[int index]
            {
                get
                {
                    return (ColorItem)this.colorItemList[index];
                }
                set
                {
                    this.colorItemList[index] = (ColorItem)value;
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.colorItemList[index];
                }
                set
                {
                    this.colorItemList[index] = (ColorItem)value;
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 颜色级别配置
        /// </summary>
        [Description("颜色级别配置")]
        public class ColorItem
        {
            private float position = 0f;
            /// <summary>
            /// 渐变值0-1
            /// </summary>
            [DefaultValue(0f)]
            [Description("渐变值0-1")]
            public float Position
            {
                get { return this.position; }
                set
                {
                    if (this.position == value || value < 0 || value > 1)
                        return;
                    this.position = value;
                }
            }

            private Color color = Color.FromArgb(255, 128, 128);
            /// <summary>
            /// 渐变值对应渐变颜色
            /// </summary>
            [DefaultValue(typeof(Color), "255, 128, 128")]
            [Description("渐变值对应渐变颜色")]
            public Color Color
            {
                get { return this.color; }
                set
                {
                    if (this.color == value)
                        return;
                    this.color = value;
                }
            }
        }

        /// <summary>
        /// 进度值更改事件参数
        /// </summary>
        [Description("进度值更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 进度值(0-1)
            /// </summary>
            [Description("进度值(0-1)")]
            public float Value { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 进度颜色绘制类型
        /// </summary>
        [Description("进度颜色绘制类型")]
        public enum ColorDrawType
        {
            /// <summary>
            /// 渐变
            /// </summary>
            Gradient,
            /// <summary>
            /// 级别
            /// </summary>
            Level
        }

        #endregion
    }
}
