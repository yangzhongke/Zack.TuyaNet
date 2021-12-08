
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
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;
using System.ComponentModel.Design;
using System.Collections.Generic;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 雷达扫描控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("雷达扫描控件")]
    [DefaultProperty("Items")]
    [DefaultEventAttribute("RadarScanChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class RadarScanExt : Control, IAnimationStaticTimer
    {
        #region 新增事件

        public delegate void RadarScanChangedEventHandler(object sender, RadarScanChangedEventArgs e);

        private event RadarScanChangedEventHandler radarScanChanged;
        /// <summary>
        /// 是否启动雷达扫描更改事件
        /// </summary>
        [Description("是否启动雷达扫描更改事件")]
        public event RadarScanChangedEventHandler RadarScanChanged
        {
            add { this.radarScanChanged += value; }
            remove { this.radarScanChanged -= value; }
        }

        public delegate void PointFlickerChangedEventHandler(object sender, PointFlickerChangedEventArgs e);

        private event PointFlickerChangedEventHandler pointFlickerChanged;
        /// <summary>
        /// 是否启动坐标闪烁更改事件
        /// </summary>
        [Description("是否启动坐标闪烁更改事件")]
        public event PointFlickerChangedEventHandler PointFlickerChanged
        {
            add { this.pointFlickerChanged += value; }
            remove { this.pointFlickerChanged -= value; }
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

        private bool radarScanActive = true;
        /// <summary>
        /// 是否启动雷达扫描
        /// </summary>
        [DefaultValue(true)]
        [Description("是否启动雷达扫描")]
        public bool RadarScanActive
        {
            get { return this.radarScanActive; }
            set
            {
                if (this.radarScanActive == value)
                    return;
                this.radarScanActive = value;


                if (!this.Enabled)
                    return;

                if (this.radarScanActive)
                {
                    if (!this.DesignMode)
                    {
                        AnimationStaticTimer.AnimationStart(this);
                    }
                }
                else
                {
                    if (this.RadarScanActive == false && this.pointFlickerActive == false)
                    {
                        AnimationStaticTimer.AnimationStop(this);
                    }
                }
                this.Invalidate();
                if (!this.DesignMode)
                {
                    this.OnRadarScanChanged(new RadarScanChangedEventArgs() { Active = this.radarScanActive });
                }
            }
        }

        private Color areaColor = Color.LawnGreen;
        /// <summary>
        /// 雷达区域背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "LawnGreen")]
        [Description("雷达区域背景颜色")]
        public Color AreaColor
        {
            get { return this.areaColor; }
            set
            {
                if (this.areaColor == value)
                    return;
                this.areaColor = value;
                this.Invalidate();
            }
        }

        private Color scanColor = Color.Coral;
        /// <summary>
        /// 雷达扫描背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Coral")]
        [Description("雷达扫描背景颜色")]
        public Color ScanColor
        {
            get { return this.scanColor; }
            set
            {
                if (this.scanColor == value)
                    return;
                this.scanColor = value;
                this.Invalidate();
            }
        }

        private bool areaCross = true;
        /// <summary>
        /// 雷达区域是否显示十字线
        /// </summary>
        [DefaultValue(true)]
        [Description("雷达区域是否显示十字线")]
        public bool AreaCross
        {
            get { return this.areaCross; }
            set
            {
                if (this.areaCross == value)
                    return;
                this.areaCross = value;
                this.Invalidate();
            }
        }

        private Color areaCrossColor = Color.YellowGreen;
        /// <summary>
        /// 雷达区域十字线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "YellowGreen")]
        [Description("雷达区域十字线颜色")]
        public Color AreaCrossColor
        {
            get { return this.areaCrossColor; }
            set
            {
                if (this.areaCrossColor == value)
                    return;
                this.areaCrossColor = value;
                this.Invalidate();
            }
        }

        private bool pointFlickerActive = true;
        /// <summary>
        /// 数据坐标是否闪烁
        /// </summary>
        [DefaultValue(true)]
        [Description("数据坐标是否闪烁")]
        public bool PointFlickerActive
        {
            get { return this.pointFlickerActive; }
            set
            {
                if (this.pointFlickerActive == value)
                    return;
                this.pointFlickerActive = value;

                if (!this.Enabled)
                    return;

                if (this.pointFlickerActive)
                {
                    if (!this.DesignMode)
                    {
                        AnimationStaticTimer.AnimationStart(this);
                    }
                }
                else
                {
                    if (this.RadarScanActive == false && this.pointFlickerActive == false)
                    {
                        AnimationStaticTimer.AnimationStop(this);
                    }
                }
                this.Invalidate();

                if (!this.DesignMode)
                {
                    this.OnPointFlickerChanged(new PointFlickerChangedEventArgs() { Active = this.pointFlickerActive });
                }
            }
        }

        private int pointFlickerInterval = 300;
        /// <summary>
        /// 否闪烁时间间隔(毫秒)
        /// </summary>
        [DefaultValue(300)]
        [Description("否闪烁时间间隔(毫秒)")]
        public int PointFlickerInterval
        {
            get { return this.pointFlickerInterval; }
            set
            {
                if (this.pointFlickerInterval == value)
                    return;
                this.pointFlickerInterval = value;
            }
        }
        private Color pointColor = Color.DeepSkyBlue;
        /// <summary>
        /// 数据坐标颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DeepSkyBlue")]
        [Description("数据坐标颜色")]
        public Color PointColor
        {
            get { return this.pointColor; }
            set
            {
                if (this.pointColor == value)
                    return;
                this.pointColor = value;
                this.Invalidate();
            }
        }

        private int pointRadius = 2;
        /// <summary>
        /// 数据坐标圆点半径（单位像素）
        /// </summary>
        [DefaultValue(2)]
        [Description("数据坐标圆点半径（单位像素）")]
        public int PointRadius
        {
            get { return this.pointRadius; }
            set
            {
                if (this.pointRadius == value)
                    return;
                this.pointRadius = value;
                this.Invalidate();
            }
        }

        private DataPointItemCollection dataPointItemCollection;
        /// <summary>
        /// 数据实际坐标选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("数据实际坐标选项集合")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataPointItemCollection DataPointItems
        {
            get
            {
                if (this.dataPointItemCollection == null)
                    this.dataPointItemCollection = new DataPointItemCollection(this);
                return this.dataPointItemCollection;
            }
        }

        private float practicalRadius = 100;
        /// <summary>
        /// 雷达的实际半径值（例如100代表雷达的实际半径为100，那么DataPointItems的X Y 的值必须在100至100之间才会出现在雷达范围）
        /// </summary>
        [DefaultValue(100f)]
        [Description("雷达的实际半径值（例如100代表雷达的实际半径为100，那么DataPointItems的X Y 的值必须在100至100之间才会出现在雷达范围）")]
        public float PracticalRadius
        {
            get { return this.practicalRadius; }
            set
            {
                if (this.practicalRadius == value)
                    return;
                this.practicalRadius = value;
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
                return new Size(100, 100);
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
        /// 雷达扫描当前角度
        /// </summary>
        private int current_angle = 0;
        /// <summary>
        /// 数据实际坐标是否显示
        /// </summary>
        private bool dataPointShow = false;

        /// <summary>
        /// 闪烁动画累加时间
        /// </summary>
        private double flickerAccumulationTime = 0;

        #endregion

        public RadarScanExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (!this.DesignMode)
            {
                if (this.RadarScanActive == true || this.pointFlickerActive == true)
                {
                    AnimationStaticTimer.AnimationStart(this);
                }
            }
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle; ;

            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rect);

            #region 圆形背景
            PathGradientBrush area_pgb = new PathGradientBrush(graphicsPath);
            area_pgb.CenterColor = this.AreaColor;
            area_pgb.CenterPoint = new PointF(rect.Width / 2, rect.Height / 2);
            area_pgb.SurroundColors = new Color[] { Color.FromArgb(30, this.AreaColor) };
            g.FillEllipse(area_pgb, rect);
            area_pgb.Dispose();
            #endregion

            #region 是否启动雷达扫描
            if (this.RadarScanActive)
            {
                PathGradientBrush scan_pgb = new PathGradientBrush(graphicsPath);
                scan_pgb.CenterColor = this.ScanColor;
                scan_pgb.CenterPoint = new PointF(rect.Width / 2, rect.Height / 2);
                scan_pgb.SurroundColors = new Color[] { Color.Transparent };
                g.FillPie(scan_pgb, rect, this.current_angle, 90);
                scan_pgb.Dispose();
            }
            #endregion

            #region 雷达区域是否显示十字线
            if (this.AreaCross)
            {
                PathGradientBrush cross_pgb = new PathGradientBrush(graphicsPath);
                cross_pgb.CenterColor = this.AreaCrossColor;
                cross_pgb.CenterPoint = new PointF(rect.Width / 2, rect.Height / 2);
                cross_pgb.SurroundColors = new Color[] { Color.Transparent };
                Pen cross_pen = new Pen(cross_pgb);
                g.DrawLine(cross_pen, 0, rect.Height / 2, rect.Width, rect.Height / 2);
                g.DrawLine(cross_pen, rect.Width / 2, 0, rect.Width / 2, rect.Height);
                cross_pgb.Dispose();
                cross_pen.Dispose();
            }
            #endregion

            #region 坐标是否闪烁
            if (!this.PointFlickerActive || (this.PointFlickerActive && this.dataPointShow))
            {
                SolidBrush point_sb = new SolidBrush(this.PointColor);
                PointF point = new PointF(rect.Width / 2f, rect.Height / 2f);
                for (int i = 0; i < DataPointItems.Count; i++)
                {
                    float x = point.X + (rect.Width / 2f) * DataPointItems[i].X / this.PracticalRadius;
                    float y = point.Y + (rect.Height / 2f) * DataPointItems[i].Y / this.PracticalRadius;
                    if (graphicsPath.IsVisible(x, y))
                    {
                        g.FillEllipse(point_sb, new RectangleF(x - this.PointRadius, y - this.PointRadius, this.PointRadius * 2, this.PointRadius * 2));
                    }
                }
                point_sb.Dispose();
            }
            #endregion

            graphicsPath.Dispose();

            #region 边框
            if (this.BorderShow)
            {
                Rectangle border_rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                Pen border_pen = new Pen(this.BorderColor, 1);
                g.DrawEllipse(border_pen, border_rect);
                border_pen.Dispose();
            }
            #endregion

        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.DesignMode)
                return;

            if (this.Enabled)
            {
                if (this.Visible == true && this.RadarScanActive == true || this.pointFlickerActive == true)
                {
                    AnimationStaticTimer.AnimationStart(this);
                }
            }
            else
            {
                AnimationStaticTimer.AnimationStop(this);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.DesignMode)
                return;

            if (this.Visible)
            {
                if (this.Enabled == true && this.RadarScanActive == true || this.pointFlickerActive == true)
                {
                    AnimationStaticTimer.AnimationStart(this);
                }
            }
            else
            {
                AnimationStaticTimer.AnimationStop(this);
            }
        }

        #endregion

        #region 虚方法

        protected virtual void OnRadarScanChanged(RadarScanChangedEventArgs e)
        {
            if (this.radarScanChanged != null)
            {
                this.radarScanChanged(this, e);
            }
        }

        protected virtual void OnPointFlickerChanged(PointFlickerChangedEventArgs e)
        {
            if (this.pointFlickerChanged != null)
            {
                this.pointFlickerChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 动画中(禁止手动调用)
        /// </summary>
        [Description("动画中(禁止手动调用)")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Animationing()
        {
            #region 扫描
            this.current_angle += 10;
            if (this.current_angle > 360)
                this.current_angle = this.current_angle - 360;
            #endregion

            #region 闪烁
            this.flickerAccumulationTime += AnimationStaticTimer.timer.Interval;
            if (this.flickerAccumulationTime > this.PointFlickerInterval)
            {
                this.flickerAccumulationTime = 0;
                this.dataPointShow = !this.dataPointShow;
                this.Invalidate();
            }
            #endregion

            this.Invalidate();
        }

        #endregion

        #region 类

        /// <summary>
        /// 数据实际坐标选项集合
        /// </summary>
        [Description("数据实际坐标选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class DataPointItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList dataPointItemList = new ArrayList();
            private RadarScanExt owner;

            public DataPointItemCollection(RadarScanExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                DataPointItem[] listArray = new DataPointItem[this.dataPointItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (DataPointItem)this.dataPointItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.dataPointItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.dataPointItemList.Count;
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
                if (!(value is DataPointItem))
                {
                    throw new ArgumentException("DataPointItem");
                }
                return this.Add((DataPointItem)value);
            }

            public int Add(DataPointItem item)
            {
                this.dataPointItemList.Add(item);
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.dataPointItemList.Clear();
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
                if (item is DataPointItem)
                {
                    return this.Contains((DataPointItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is DataPointItem)
                {
                    return this.dataPointItemList.IndexOf(item);
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
                if (!(value is DataPointItem))
                {
                    throw new ArgumentException("DataPointItem");
                }
                this.Remove((DataPointItem)value);
            }

            public void Remove(DataPointItem item)
            {
                this.dataPointItemList.Remove(item);
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.dataPointItemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public DataPointItem this[int index]
            {
                get
                {
                    return (DataPointItem)this.dataPointItemList[index];
                }
                set
                {
                    this.dataPointItemList[index] = (DataPointItem)value;
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.dataPointItemList[index];
                }
                set
                {
                    this.dataPointItemList[index] = (DataPointItem)value;
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 数据实际坐标选项
        /// </summary>
        [Description("数据实际坐标选项")]
        public class DataPointItem
        {
            /// <summary>
            /// X实际坐标
            /// </summary>
            [DefaultValue(0f)]
            [Description("X实际坐标")]
            public float X { get; set; }

            /// <summary>
            /// Y实际坐标
            /// </summary>
            [DefaultValue(0f)]
            [Description("Y实际坐标")]
            public float Y { get; set; }
        }

        /// <summary>
        /// 是否启动雷达扫描更改事件参数
        /// </summary>
        [Description("是否启动雷达扫描更改事件参数")]
        public class RadarScanChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 是否显示雷达扫描
            /// </summary>
            [Description("是否显示雷达扫描")]
            public bool Active { get; set; }
        }

        /// <summary>
        /// 是否启动坐标闪烁更改事件参数
        /// </summary>
        [Description("是否启动坐标闪烁更改事件参数")]
        public class PointFlickerChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 坐标是否闪烁
            /// </summary>
            [Description("坐标是否闪烁")]
            public bool Active { get; set; }
        }

        #endregion

    }
}
