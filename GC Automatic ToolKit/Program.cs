﻿using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm();
            Application.Run(form);
        }
    }
}
