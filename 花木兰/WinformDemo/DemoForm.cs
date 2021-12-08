
/**版权******************************************************************

            版权：  唧唧复唧唧木兰当户织
            作者：  唧唧复唧唧木兰当户织
            博客：  https://www.cnblogs.com/tlmbem/
     源码地址：  https://www.cnblogs.com/tlmbem/
            描述：  授权使用在 https://www.cnblogs.com/tlmbem/ 上有介绍，禁止删除下面的木兰诗。
            日期：  2020-10-28
	
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class DemoForm : FormExt
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void DemoForm_Load(object sender, EventArgs e)
        {
            this.Bind(this.menuExt1.MenuPanel);
            this.menuExt1.PatternChanged += this.menuExt1_PatternChanged;
            this.menuExt1.MenuPanel.Drag.Draging += Draw_Drawing;
            this.menuExt1.MenuPanel.SelectedChanged += MenuPanel_SelectedChanged;
            this.menuExt1.MenuPanel.NodeClick += this.MenuPanel_NodeClick;
        }

        private void Draw_Drawing(object sender, SlideMenuPanelExt.DragingEventArgs e)
        {
            this.menuExt1.MenuWidth += e.X;
            this.panel1.Width = this.ClientRectangle.Width - this.menuExt1.Width - this.BorderWidth * 2;
            this.panel1.Location = new Point(this.menuExt1.Right, this.panel1.Location.Y);
        }

        private void menuExt1_PatternChanged(object sender, SlideMenuExt.PatternChangedEventArgs e)
        {
            this.panel1.Width = this.ClientRectangle.Width - this.menuExt1.Width - this.BorderWidth * 2;
            this.panel1.Location = new Point(this.menuExt1.Right, this.panel1.Location.Y);
        }

        private void MenuPanel_SelectedChanged(object sender, SlideMenuPanelExt.SelectedChangedEventArgs e)
        {

        }

        private void MenuPanel_NodeClick(object sender, SlideMenuPanelExt.NodeClickEventArgs e)
        {
            if (e.Node.ItemType == SlideMenuPanelExt.NodeTypes.MenuTab)
            {
                ConstructorInfo _constructor = ((Type)e.Node.Data).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] { }, null);
                Form _constructor_obj = (Form)_constructor.Invoke(new object[] { });
                _constructor_obj.Dock = DockStyle.Fill;
                if (_constructor_obj is IFormExt)
                {
                    FormExt fe = (FormExt)_constructor_obj;
                    fe.Padding =new Padding(0);
                    fe.BorderEnabled = false;
                    fe.CaptionEnabled = false;
                    fe.ResizeType = ResizeTypes.NoResize;
                    fe.SizeGripStyle = SizeGripStyle.Hide;
                }
                _constructor_obj.TopLevel = false;
                _constructor_obj.FormBorderStyle = FormBorderStyle.None;
                foreach (Form form in this.panel1.Controls)
                {
                    form.Dispose();
                }
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(_constructor_obj);
                _constructor_obj.Show();
            }
        }

        private void Bind(SlideMenuPanelExt menuPanel)
        {
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem1 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "菜单" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem11 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "GDI不规则圆弧", Data = typeof(RadianMenuExtComponentForm), Image = global::WinformDemo.Properties.Resources.demomenu_radianmenu };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem12 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "MAC鱼眼效果", Data = typeof(FisheyeMenuExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_fisheyebar };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem13 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Menu左侧", Data = typeof(SlideMenuExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_menupanel };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem14 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "面包屑导航栏", Data = typeof(NavigationBarExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_navigationbar };
            menuItem1.Children.Add(menuItem11);
            menuItem1.Children.Add(menuItem12);
            menuItem1.Children.Add(menuItem13);
            menuItem1.Children.Add(menuItem14);
            menuPanel.Nodes.Add(menuItem1);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "表单", Data = "9" };

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem210 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Date日期选择美化", Data = typeof(DatePickerExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_date };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem211 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Color颜色选择美化", Data = typeof(ColorExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_color };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem212 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "多点滑块滑杆", Data = typeof(MultidropSlideBarExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_multidropslidebar };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem213 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "CheckBox美化", Data = typeof(CheckBoxExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_checkbox };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem214 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "RadioButton美化", Data = typeof(RadioButtonExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_radio };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem215 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Switch开关按钮", Data = typeof(SwitchButtonExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_toggleswitch };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2151 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "ListBox列表", Data = typeof(ListBoxExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_listbox };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem216 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Button动画", Data = typeof(ButtonExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_button };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem217 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "百分比进度", Data = typeof(PercentageProgressExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_percentagebar };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem218 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "水波纹进度", Data = typeof(WaveProgressExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_waveprogress };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem219 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "渐变进度", Data = typeof(GradualProgressExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_progress };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2110 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "数字时间", Data = typeof(NumberTimeExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_numbertime };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2111 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "温度计", Data = typeof(ThermometerExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_thermometer };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2112 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "TabControl美化", Data = typeof(TabControlExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_tabcontrol };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2113 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "GroupPanel美化", Data = typeof(GroupPanelExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_grouppanel };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2114 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "步骤流程", Data = typeof(ProcedureExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_sepprocess };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2115 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "动态图片", Data = typeof(ImageExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_image };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem21151 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "验证码", Data = typeof(ValidCodeExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_validcode };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2116 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "分割线", Data = typeof(HalvingLineExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_halvingline };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2117 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "雷达扫描", Data = typeof(RadarScanExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_radar };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2118 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "加载等待", Data = typeof(LoadExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_loadprogress };
            menuItem2.Children.Add(menuItem210);
            menuItem2.Children.Add(menuItem211);
            menuItem2.Children.Add(menuItem212);
            menuItem2.Children.Add(menuItem213);
            menuItem2.Children.Add(menuItem214);
            menuItem2.Children.Add(menuItem215);
            menuItem2.Children.Add(menuItem2151);
            menuItem2.Children.Add(menuItem216);
            menuItem2.Children.Add(menuItem217);
            menuItem2.Children.Add(menuItem218);
            menuItem2.Children.Add(menuItem219);
            menuItem2.Children.Add(menuItem2110);
            menuItem2.Children.Add(menuItem2111);
            menuItem2.Children.Add(menuItem2112);
            menuItem2.Children.Add(menuItem2113);
            menuItem2.Children.Add(menuItem2114);
            menuItem2.Children.Add(menuItem2115);
            menuItem2.Children.Add(menuItem21151);
            menuItem2.Children.Add(menuItem2116);
            menuItem2.Children.Add(menuItem2117);
            menuItem2.Children.Add(menuItem2118);
            menuPanel.Nodes.Add(menuItem2);



            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem3 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "播放" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem31 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "图片旋转播放", Data = typeof(ImageWhirligigExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_imagewhirligig };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem32 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "走马灯图片轮播", Data = typeof(ImageCarouselExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_imagecarousel };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem33 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "文本跑马灯特效", Data = typeof(TextCarouselExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_textcarousel };
            menuItem3.Children.Add(menuItem31);
            menuItem3.Children.Add(menuItem32);
            menuItem3.Children.Add(menuItem33);
            menuPanel.Nodes.Add(menuItem3);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem4 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "验证" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem41 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem4) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "图案滑屏解锁", Data = typeof(PatternLockExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_patternlock };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem42 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem4) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "拼图滑块验证", Data = typeof(JigsawValidExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_jigsawslide };
            menuItem4.Children.Add(menuItem41);
            menuItem4.Children.Add(menuItem42);
            menuPanel.Nodes.Add(menuItem4);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem5 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "组件" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem51 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem5) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "右下角弹窗美化", Data = typeof(AlertWindowExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_windowalert };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem52 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem5) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "提示框美化", Data = typeof(MessageBoxExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_message };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem53 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem5) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "加载等待蒙版", Data = typeof(MaskingExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_masking };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem54 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem5) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "ToolTip美化", Data = typeof(ToolTipExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_tooltip };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem55 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem5) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "毫秒级别计时器", Data = typeof(TimerExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_timer };
            menuItem5.Children.Add(menuItem51);
            menuItem5.Children.Add(menuItem52);
            menuItem5.Children.Add(menuItem53);
            menuItem5.Children.Add(menuItem54);
            menuItem5.Children.Add(menuItem55);
            menuPanel.Nodes.Add(menuItem5);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem5a = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "工具栏" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem5a1 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "右键菜单", Data = typeof(ContextMenuStripExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_contextmenustrip };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem5a2 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "菜单栏", Data = typeof(MenuStripExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_contextmenustrip };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem5a3 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "工具栏", Data = typeof(ToolStripExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_contextmenustrip };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem5a4 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "状态栏", Data = typeof(StatusStripExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_contextmenustrip };
            menuItem5a.Children.Add(menuItem5a1);
            menuItem5a.Children.Add(menuItem5a2);
            menuItem5a.Children.Add(menuItem5a3);
            menuItem5a.Children.Add(menuItem5a4);
            menuPanel.Nodes.Add(menuItem5a);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem6 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "分析" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem61 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem6) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "仪表", Data = typeof(MeterExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_meterbar };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem62 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem6) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "雷达分析图", Data = typeof(RadarChartExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_radarchart };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem63 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem6) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Chart分析", Data = typeof(ChartExtForm), Image = global::WinformDemo.Properties.Resources.demomenu_chart };
            menuItem6.Children.Add(menuItem61);
            menuItem6.Children.Add(menuItem62);
            menuItem6.Children.Add(menuItem63);
            menuPanel.Nodes.Add(menuItem6);


            menuPanel.RestMenuNodes();
        }

    }
}
