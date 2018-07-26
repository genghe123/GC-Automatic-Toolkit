using System;
using System.Windows.Forms;

namespace GC_Automatic_ToolKit
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            if (DateTime.Now > new DateTime(2019, 9, 13))
                return;

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            

            //GCHandle.GCHandleAcqClient.StopRun("GC680");
            //GCHandle.XmlHandle.XmlRead("instrumentStopPeroid");
        }
    }
}
