using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using GC_Automatic_ToolKit.GCConfig;

namespace GC_Automatic_ToolKit.Handler
{
    internal static class GcHandleTcAccess
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger("GcHandleTcAccess");

        static GcHandleTcAccess()
        {
            DirectoryInfo dllDirectory = null;
            try
            {
                dllDirectory = new DirectoryInfo(Environment.GetEnvironmentVariable("PEN_PATH"));
            }
            catch (Exception)
            {
                foreach (var sub in new DirectoryInfo(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"PenExe\TcWS\").GetDirectories())
                {
                    if (sub.Name.Contains("Ver")) dllDirectory = new DirectoryInfo(sub.FullName + @"\Bin");
                }
            }
            DllFileInfo = new FileInfo(dllDirectory.FullName + @"\TcAccess.dll");
        }

        private static readonly FileInfo DllFileInfo;

        #region ImportDLLDynamically

        //DLL实例
        private static IntPtr _instance;

        //导入引擎dll
        // https://docs.microsoft.com/en-us/windows/desktop/api/libloaderapi/nf-libloaderapi-loadlibraryexa
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibraryExA(string lpLibFileName, IntPtr hFile, uint dwFlags);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern int GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("Kernel32.dll", EntryPoint = "FreeLibrary", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);

        //获取方法指针
        private static Delegate GetAddress(IntPtr dllModule, string functionname, Type t)
        {
            int addr = GetProcAddress(dllModule, functionname);
            return addr == 0 ? null : Marshal.GetDelegateForFunctionPointer(new IntPtr(addr), t);
        }

        //加载DLL
        public static void LoadLib()
        {
            var dllPath = DllFileInfo.FullName;
            var temPtr = new IntPtr();
            _instance = LoadLibraryExA(dllPath, temPtr, 0x00000008);
            if (_instance.ToInt32() == 0)
            {
                throw new Exception("请在Config中配置引擎DLL的路径!");
            }
        }

        //卸载DLL
        public static void FreeLib()
        {
            FreeLibrary(_instance);
        }

        private delegate bool d1();

        private delegate short d2(string s1, string s2);

        private delegate IntPtr d3(string s1);

        private delegate string d4();

        private delegate short d5(IntPtr s1, string s2, string s3);

        private delegate short d6(IntPtr s1, string s2, out IntPtr s3);

        private delegate short d7(IntPtr s1);

        private static Action TcAccessInit()
        {
            return (Action)GetAddress(_instance, "TcAccessInit", typeof(Action));
        }

        private static d1 TcAccessLoggedOn()
        {
            return (d1)GetAddress(_instance, "TcAccessLoggedOn", typeof(d1));
        }

        private static d2 VbTcAccessLogon()
        {
            return (d2) GetAddress(_instance, "VbTcAccessLogon", typeof(d2));
        }

        private static d3 VbTcAccessOpenConversation()
        {
            return (d3)GetAddress(_instance, "VbTcAccessOpenConversation", typeof(d3));
        }

        private static d4 TcAccessErrorMessage()
        {
            return (d4)GetAddress(_instance, "TcAccessErrorMessage", typeof(d4));
        }

        private static d5 VbTcAccessSet()
        {
            return (d5) GetAddress(_instance, "VbTcAccessSet", typeof(d5));
        }

        private static d6 VbTcAccessGet()
        {
            return (d6)GetAddress(_instance, "VbTcAccessGet", typeof(d6));
        }

        private static d7 VbTcAccessCloseConversation()
        {
            return (d7) GetAddress(_instance, "VbTcAccessCloseConversation", typeof(d7));
        }

        #endregion

        /*
        #region TcAccess.dll import

        [DllImport(@"C:\PenExe\TcWS\Ver6.3.2\Bin\TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        private static extern void TcAccessInit();

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool TcAccessLoggedOn();

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        private static extern short VbTcAccessLogon(string username, string password);

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr VbTcAccessOpenConversation(string Topic);

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern string TcAccessErrorMessage();

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern short VbTcAccessSet(IntPtr intPtr, string itemName, string value);

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern short VbTcAccessGet(IntPtr intPtr, string itemName, out IntPtr value);

        [DllImport("TcAccess.dll", ExactSpelling = true, SetLastError = true)]
        private static extern short VbTcAccessCloseConversation(IntPtr conv);

        #endregion
        */


        private static IntPtr TcAccessInitial(string pattern, PerkinElmerConfig config)
        {
            log.Debug("Initialing TcAccess");

            LoadLib();
            TcAccessInit().Invoke();
            if (!TcAccessLoggedOn().Invoke())
            {
                VbTcAccessLogon().Invoke(config.UserId, config.Password);
            }

            log.Info("Initialed TcAccess");

            return VbTcAccessOpenConversation().Invoke(pattern);
        }

        private static bool TcAccessCloseConversation(IntPtr conv)
        {
            return VbTcAccessCloseConversation().Invoke(conv) == 0;
        }

        private static void TcAccessSet(IntPtr handle, string item, string value)
        {
            try
            {
                if (VbTcAccessSet().Invoke(handle, item, value) != 0)
                    throw new FileNotFoundException();

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                //todo Add manually select file
            }
        }

        private static string TcAccessGet(IntPtr handle, string item)
        {
            try
            {
                if (VbTcAccessGet().Invoke(handle, item, out var value) != 0)
                {
                    log.Error("Item: " + item);
                    throw new ArgumentException("Invoking TcAccessGet failed.Please check InvokeMethod");
                }
                return Marshal.PtrToStringAnsi(value);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        internal static IEnumerable<KeyValuePair<string, double>> ReadAllPeaksAreaFromRst(string path, PerkinElmerConfig config)
        {
            var handle = TcAccessInitial("RST", config);

            TcAccessSet(handle, "FILE_NAME", path);
            if (!int.TryParse(TcAccessGet(handle, "RST_NUM_PEAKS"), out var peaknums))
                return null;

            var list = new List<KeyValuePair<string,double>>(4);

            for (var i = 0; i < peaknums; i++)
            {
                TcAccessSet(handle, "RST_PEAK_INDEX", i.ToString());
                var name = TcAccessGet(handle, "PK_NAME");
                if (!double.TryParse(TcAccessGet(handle, "PK_AREA"), out var area)) continue;
                list.Add(new KeyValuePair<string, double>(name,area));
            }
            TcAccessCloseConversation(handle);
            return list;
        }
    }
}
