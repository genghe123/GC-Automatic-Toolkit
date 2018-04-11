using System;
using System.Windows.Forms;
using GC_Automatic_ToolKit.UserInterface;

namespace GC_Automatic_ToolKit
{
    static class Program
    {
        internal static MainForm form;

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
            form = new MainForm();
            Application.Run(form);

        }
    }
}
