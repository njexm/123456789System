using Branch;
using sorteSystem.com.proem.sorte.util;
using sorteSystem.com.proem.sorte.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace sorteSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BranchLogin login = new BranchLogin();
            //窗口居中
            login.StartPosition = FormStartPosition.CenterScreen;
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                //if (ConstantUtil.UserRole.Equals(ConstantUtil.AMDIN_ROLE))
                //{
                    Main main = new com.proem.sorte.window.Main();
                    //窗口居中
                    main.StartPosition = FormStartPosition.CenterScreen;
                    Application.Run(main);
                //}
                //else {
                //    ScanCode main = new ScanCode();
                //    main.StartPosition = FormStartPosition.CenterScreen;
                //    Application.Run(main);
                //}
            }
        }

        
    }
}
