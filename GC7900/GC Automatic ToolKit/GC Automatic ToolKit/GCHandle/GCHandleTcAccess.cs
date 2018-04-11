using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GC_Automatic_ToolKit.GCHandle
{
    internal static class GcHandleTcAccess
    {
        private static string _user = "manager";
        private static string _password = "123456";

        internal static string User { set => _user = value; }
        internal static string Password { set => _password = value; }

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

        private static IntPtr TcAccessInitial(string pattern)
        {
            TcAccessInit();
            if (!TcAccessLoggedOn())
            {
                VbTcAccessLogon(_user, _password);
            }
            return VbTcAccessOpenConversation(pattern);
        }

        private static bool TcAccessCloseConversation(IntPtr conv)
        {
            return VbTcAccessCloseConversation(conv) == 0;
        }

        private static void TcAccessSet(IntPtr handle, string item, string value)
        {
            try
            {
                if (VbTcAccessSet(handle, item, value) != 0)
                    throw new System.IO.FileNotFoundException();

            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                //todo Add manually select file
            }
        }

        private static string TcAccessGet(IntPtr handle, string item)
        {
            try
            {
                if (VbTcAccessGet(handle, item, out var value) != 0)
                    throw new ArgumentException("Invoking TcAccessGet failed.Please check method");
                return Marshal.PtrToStringAnsi(value);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        internal static IEnumerable<KeyValuePair<string, double>> ReadAllPeaksAreaFromRst(string path)
        {
            var handle = TcAccessInitial("RST");


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
