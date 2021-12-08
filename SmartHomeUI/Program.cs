using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHomeUI
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static async Task Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            await ServiceLocator.LoadAsync();
            Application.Run(new FormMain());
        }
    }
}
