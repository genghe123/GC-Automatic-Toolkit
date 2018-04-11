using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using GC_Automatic_ToolKit.GCConfig;
using GC_Automatic_ToolKit.Handler;
using GC_Automatic_ToolKit.UserInterface;

namespace GC_Automatic_ToolKit
{
    internal static class Runtime
    {
        private static PerkinElmerConfig gc = null;
        private static ExcelHandle excelhandle = null;
        private static Task posthandle = null;
        private static CancellationTokenSource cancellation = null;
        private static System.Timers.Timer timer = null;
        private static System.Timers.Timer bartimer = null;
        private static MainForm form;



        static Runtime()
        {
            form = Program.form;
            excelhandle = new ExcelHandle();
            excelhandle.CreateExcel();
            cancellation = new CancellationTokenSource();
            timer = new System.Timers.Timer();
            bartimer = new System.Timers.Timer();

            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);

            bartimer.AutoReset = true;
            bartimer.Elapsed += new ElapsedEventHandler(Bartimer_Elapsed);
        }

        internal static PerkinElmerConfig Gc { get => gc; set => gc = value; }

        internal static void Run(PerkinElmerConfig config)
        {
            Gc = config;
            Check();
            cancellation.CancelAfter(TimeSpan.FromMilliseconds(Gc.Peroid + Gc.Interval));
            Start();
        }

        private static void Start()
        {
            GCHandleAcqClient.StartRun(Gc.Key);
            timer.Interval = Gc.Peroid;
            bartimer.Interval = Gc.Peroid / 100;
            timer.Start();
            bartimer.Start();
        }

        internal static void Tick()
        {
            Thread.Sleep(5000);
            GCHandleAcqClient.StopRun(Gc.Key);
            posthandle = Task.Run(() => ReadDataFromRstFile(Gc.ResultPath, cancellation.Token));
            //ReadDataFromRstFile(Gc.ResultPath, cancellation.Token);

            if (++Gc.K < Gc.Max)
            {
                Thread.Sleep((int)(Gc.Interval));
                Start();
            }
        }

        private static bool ReadDataFromRstFile(DirectoryInfo rstdirinfo, CancellationToken token)
        {
            form.Output(rstdirinfo.ToString());
            Thread.Sleep(15000);
            FileInfo[] files = null;
            try
            {
                files = rstdirinfo.GetFiles("*.rst", SearchOption.AllDirectories);
            }
            catch (ArgumentException e)
            {
                form.Output(e.ToString());
            }
            catch (DirectoryNotFoundException e)
            {
                form.Output(e.ToString());
            }
            catch (System.Security.SecurityException e)
            {
                form.Output(e.ToString());
            }

            if (files is null || files.Length == 0)
            {
                return false;
            }

            var lastestFile = (from f in files
                         orderby f.CreationTime descending
                         select f).Take(1).ToArray();

            var result = GcHandleTcAccess.ReadAllPeaksAreaFromRst(lastestFile[0].FullName);
            excelhandle.AddStringDoublePair(result, Gc.K, 2);
            return true;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            bartimer.Stop();
            form.ProgressBarReset();
            form.Output(Convert.ToString(Gc.K) + " times completed.");
            Tick();
            timer.Start();
            bartimer.Start();
        }

        public static void Bartimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            form.ProgressBarChange();
        }

        private static void Check()
        {
            if (gc == null)
            {
                throw new MethodAccessException();
            }
        }
    }
}
