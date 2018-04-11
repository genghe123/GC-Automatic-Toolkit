using System;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using PnwAcqClient;

namespace GC_Automatic_ToolKit.GCHandle
{
    internal static class GCHandleAcqClient
    {
        private static IPnwAcqClient acqClient = null;
        private static object data = null;
        private static Regex regex = null;

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern uint CallWindowProc(int lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, uint lParam);

        private static void ConnectToAcqClient()
        {
            try
            {
                acqClient = (IPnwAcqClient)Interaction.GetObject(null, "TCAcqClient.Server");
            }
            catch (Exception)
            {
                acqClient = (IPnwAcqClient)Interaction.CreateObject("TcAcqClient.Server");
            }
        }

        internal static bool StartRun(string bstInstKey)
        {
            ConnectToAcqClient();

            return acqClient.SendCommand(bstInstKey, (int)PnwInstCmdTypes.ePnwInstCmdStartRun, ref data);
        }

        internal static bool StopRun(string bstInstKey)
        {
            ConnectToAcqClient();

            return acqClient.SendCommand(bstInstKey, (int)PnwInstCmdTypes.ePnwInstCmdStopRun, ref data);
        }

        
        internal static PnwGcStates GetGCStatus(string bstInstKey)
        {
            ConnectToAcqClient();

            var status = acqClient.GetStatusData(bstInstKey, (int)PnwStatusDataTypes.ePnwStatusDataGc, ref data);
            // To Newcomers,
            // I tried to use bulit-in structs (e.g. PnwStatusDataGcPub...) to parse retrived object "data" into these structs,
            // using "ByteToStruct()" method. Unfortunately, all these attempts failed in the end. It seems that retrived data
            // are different in length with all structs.
            // Luckly there has several way to decrypt information from these shits.
            // First but inelegantly, parse all the retrived data to string, trim this string and receive useful data. For example, you may get a string 
            // containing "Ready" substrings if GC instrument is in ready status.
            // Second but also brutely, you could check file "AcqClientCom.h" in subdirectory "C:\PenExe\TcWS\Ver6.3.2\Examples\AcqClient_Interface_Info\",
            // this header file defines all the structs with "Pub" suffix, you need a bit of luck to "guess" the relationship between byte[] retrived and 
            // struct structure. For example, when using "PnwStatusDataTypes.ePnwStatusDataGc" as parameter passes to "GetStatusData()" method, you will
            // retrive a 381-length byte[] array, corresponding to "PnwStatusDataGcPub" struct, "data[0]=16" means  this is an enum 
            // "PnwStatusDataTypes.ePnwStatusDataGc" which it's integer value is 16, data[1] to data[4] means an integer (4byte*8bit=32bit, 1int=32bit),
            // this means the status of GC instrument. if "data[1-4]=6" that means GC instrument is running(enum PnwGcStates.ePnwGcStateRun=6).
            // As for later bytes? who cares, I don't know... I just wanna get status of instrument.
            // @ Author: HermanGeng
            // @ E-mail: genghe123@sina.com
            // @ Date:   2017-12-21 
            return (PnwGcStates)Enum.ToObject(typeof(PnwGcStates), Convert.ToInt32(((byte[])data)[4]));

            //var statusstrings = System.Text.Encoding.ASCII.GetString((byte[])data);
            //var temp = BytesToStruct<PnwStatusDataGcPub>((byte[])data);   //Always fails...
        }

        internal static string GetResultFilePath(string bstInstKey)
        {
            ConnectToAcqClient();
            var status = acqClient.GetSequenceData(bstInstKey, (int)PnwSeqDataTypes.ePnwSeqDataParams, ref data);

            //var result =
            //@"\u0001 D:\\GC_Data\\Sequence\\20171221.seq\u0001\0\0\0$D:\\GC_Data\\Method\\Herman\\H2S+CH4.mthHD:\\GC_Data\\Data\\Wanghao\\Mo catalyst\\alumina cluster\\molar ratio CH4\\1-4\\HF:\\GC_Data\\Data\\Result\\\f20171221_###\0\0\0\u0001\amanager\u0001\0\0\0\u0001\0\0\0\0/\0\0\0\0\0\0?\u001e;Z\u0006\u001f;Z\0\0\0\0";
            //@"\u00010D:\\GC_Data\\Sequence\\20171221-20171221-230634.seq\u0001\0\0\0%D:\\GC_Data\\Method\\Herman\\shutdown.mth\u0010D:\\GC_Data\\Data\\\u0010D:\\GC_Data\\Data\\\f20171221_###\0\0\0\u0001\amanager\u0001\0\0\0\u0001\0\0\0\0\0\0\0\0\0\0\0??;Z??;Z\0\0\0\0"
            //@"\u0001\"D:\\GC_Data\\Sequence\\2017-12-22.seq\u0001\0\0\0$D:\\GC_Data\\Method\\Herman\\H2S+CH4.mth\u0010D:\\GC_Data\\Data\\\u0010D:\\GC_Data\\Data\\\n2017-12-22\0\0\0\u0001\amanager\u0001\0\0\0\u0001\0\0\0\0\0\0\0\0\0\0\0?`<Z?`<Z\0\0\0\0"
            var resultstring = System.Text.Encoding.ASCII.GetString((byte[])data);
            const string pattern = @"^.*\.mth.*(?<RawFile>\w{1}:[^:]*)(?<ResultFile>\w{1}:.*)\\f.*$";
            regex = new Regex(pattern);
            var match = regex.Match(resultstring);
            string path=match.Groups["ResultFile"].Value;
            return match.Groups["ResultFile"].Value;
        }

        /*
        internal static bool RegisterInstReadyEvent(string bstInstKey, bool status)
        {
            return acqClient.RegisterForInstEvents(Program.mainForm.Handle.ToInt32(), bstInstKey, (int)PnwInstEventTypes.ePnwInstEventInstStateChanged);
        }
        */
        

        /*
        private static TStruct BytesToStruct<TStruct>(byte[] bytes)
        {
            var size = Math.Min(Marshal.SizeOf(typeof(TStruct)),bytes.Length);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure<TStruct>(buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        */

    }
}
