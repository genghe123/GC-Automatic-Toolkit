using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace GC_Automatic_ToolKit.Handler
{
    class ProcessWindowOperation
    {
        #region user32.dll import

            [DllImport("user32.dll")]
            internal static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);
            public struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;

            }

            [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
            internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll", EntryPoint = "mouse_event", SetLastError = true)]
            internal static extern int mouse_event(int dwFlags, int dx, int dy, int cButtions, int dwExtraInfo);
            const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
            const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
            const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
            const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
            const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
            const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
            const int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
            const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

            [DllImport("user32.dll", EntryPoint = "SetCursorPos", SetLastError = true)]
            internal  static extern int SetCursorPos(int x, int y);

            [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
            internal  static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
            const int SW_HIDE = 0;
            const int SW_SHOWNORMAL = 1;
            const int SW_SHOWMINIMIZED = 2;
            const int SW_SHOWMAXIMIZED = 3;
            const int SW_MAXIMIZE = 3;
            const int SW_SHOWNOACTIVATE = 4;
            const int SW_SHOW = 5;
            const int SW_MINIMIZE = 6;
            const int SW_SHOWMINNOACTIVE = 7;
            const int SW_SHOWNA = 8;
            const int SW_RESTORE = 9;

            [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
            private static extern bool SetForegroundWindow(IntPtr hWnd);


        #endregion

        internal void GetWindowPosition(string lpWindowName,out Rect rect)
        {
            //IntPtr hwnd = FindWindow(null, lpWindowName);
            Process[] p = Process.GetProcessesByName(lpWindowName);
            //IntPtr hwnd2=p[0].Handle;
            IntPtr hwnd3 = p[0].MainWindowHandle;
            GetWindowRect(hwnd3,out rect);
            ShowWindow(hwnd3,1);
            SetForegroundWindow(hwnd3);
        }
        
        internal void SimMouse_LeftClick(int x_relative,int y_relative,Rect windowLocation)
        {
            SetCursorPos(windowLocation.Left+x_relative,windowLocation.Top+y_relative);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }

    class GC_Operation
    {
        private ProcessWindowOperation process = new ProcessWindowOperation();
        private ProcessWindowOperation.Rect rect = new ProcessWindowOperation.Rect();
        private string proName;

        internal GC_Operation(string proName)
        {
            this.proName = proName;
            process.GetWindowPosition(proName, out rect);
        }

        private void RunButton()
        {
            //Relocate Process Window Location.
            process.GetWindowPosition(proName, out rect);

            //Run Button
            Thread.Sleep(100);
            int x = 460; int y = 415;
            process.SimMouse_LeftClick(x, y, rect);
        }
         
        internal void Start_Run()
        {
            //Start Run Item
            //RunButton();
            Thread.Sleep(100);
            //int x = 500;int y = 395;
            int x = 24, y = 104;
            process.SimMouse_LeftClick(x, y, rect);
        } 
        
        internal void Stop_Run()
        {
            //Stop Run Item
            //RunButton();
            Thread.Sleep(100);
            //int x = 500;int y = 420;
            int x = 48, y = 104;
            process.SimMouse_LeftClick(x, y, rect);
            Thread.Sleep(100);
            //x = 415;y = 355;
            //process.SimMouse_LeftClick(x, y, rect);
        }  
    }
}
