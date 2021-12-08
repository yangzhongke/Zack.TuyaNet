using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class AlertWindowExtForm : Form
    {
        private string text = @"唧唧复唧唧，木兰当户织。不闻机杼声，唯闻女叹息。 
问女何所思，问女何所忆。女亦无所思，女亦无所忆。昨夜见军帖，可汗大点兵，军书十二卷，卷卷有爷名。阿爷无大儿，木兰无长兄，愿为市鞍马，从此替爷征。 
东市买骏马，西市买鞍鞯，南市买辔头，北市买长鞭。旦辞爷娘去，暮宿黄河边，不闻爷娘唤女声，但闻黄河流水鸣溅溅。旦辞黄河去，暮至黑山头，不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
万里赴戎机，关山度若飞。朔气传金柝，寒光照铁衣。将军百战死，壮士十年归。 
归来见天子，天子坐明堂。策勋十二转，赏赐百千强。可汗问所欲，木兰不用尚书郎，愿驰千里足，送儿还故乡。";

        public AlertWindowExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
            button3_Click(null, null);
            button4_Click(null, null);
            button5_Click(null, null);
            button6_Click(null, null);
            button9_Click(null, null);
        }

        private void DesktopAlertTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            DesktopAlert.Notify.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowAlert(DesktopAlert.MessageType.通知.ToString(), text, DesktopAlert.MessageType.通知);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowAlert(DesktopAlert.MessageType.错误.ToString(), text, DesktopAlert.MessageType.错误);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowAlert(DesktopAlert.MessageType.警告.ToString(), text, DesktopAlert.MessageType.警告);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowAlert(DesktopAlert.MessageType.疑问.ToString(), text, DesktopAlert.MessageType.疑问);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowAlert(DesktopAlert.MessageType.通过.ToString(), text, DesktopAlert.MessageType.通过);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowAlert(DesktopAlert.MessageType.自定义.ToString(), text, DesktopAlert.MessageType.自定义, Color.MediumPurple, ColorTranslator.FromHtml("#cddc39"));
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DesktopAlert.ShowNotify();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DesktopAlert.HideNotify();
        }

    }
}
