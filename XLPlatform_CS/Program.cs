using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using dotNetLab.Common;

namespace XLPlatform
{
    public delegate void BegineDownloadCallback(string strAddr);
    static class Program
    {
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            WinFormApp.BegineInvokeApp();
            R.mainPage = new MainPage();
            WinFormApp.EndInvokeApp(R.mainPage);
        }
    }
}
