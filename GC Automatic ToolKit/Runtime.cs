using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using GC_Automatic_ToolKit.GCConfig;
using GC_Automatic_ToolKit.Handler;
using GC_Automatic_ToolKit.UserInterface;
using Timer = System.Timers.Timer;

namespace GC_Automatic_ToolKit
{
    internal static class Runtime
    {
        private static ExcelHandle _excelhandle;
        private static Task _posthandle;
        private static CancellationTokenSource _cancellation;
        private static Timer _timer;
        private static Timer bartimer;
        private static MainForm form;



        static Runtime()
        {
            form = Program.form;
            _excelhandle = new ExcelHandle();
            _excelhandle.CreateExcel();
            _cancellation = new CancellationTokenSource();
            _timer = new Timer();
            bartimer = new Timer();

            _timer.AutoReset = true;
            _timer.Elapsed += Timer_Elapsed;

            bartimer.AutoReset = true;
            bartimer.Elapsed += Bartimer_Elapsed;
        }

        internal static PerkinElmerConfig Gc { get; set; }

        internal static void Run(PerkinElmerConfig config)
        {
            Gc = config;
            Check();
            //_cancellation.CancelAfter(TimeSpan.FromMilliseconds((Gc.Peroid + Gc.Interval) * 60000));
            _timer.Interval = Gc.Peroid * 60000;
            bartimer.Interval = _timer.Interval / 100;
            Start();
        }

        private static void Start()
        {
            GCHandleAcqClient.StartRun(Gc.InstrumentKey);
            _timer.Start();
            bartimer.Start();
        }

        internal static void Tick()
        {
            Thread.Sleep(5000);
            GCHandleAcqClient.StopRun(Gc.InstrumentKey);
            _posthandle = Task.Factory.StartNew(() => ReadDataFromRstFile(Gc.ResultPath, _cancellation.Token));
            //_posthandle = Task.Run(() => ReadDataFromRstFile(Gc.ResultPath, _cancellation.Token));
            //ReadDataFromRstFile(Gc.ResultPath, cancellation.Token);

            if (++Gc.K <= Gc.Max)
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
            catch (SecurityException e)
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

            var result = GcHandleTcAccess.ReadAllPeaksAreaFromRst(lastestFile[0].FullName, Gc);
            _excelhandle.AddStringDoublePair(result, Gc.K, 2);
            return true;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            bartimer.Stop();
            form.ProgressBarReset();
            form.Output(Convert.ToString(Gc.K) + " times completed.");
            Tick();

        }

        public static void Bartimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            form.ProgressBarChange();
        }

        private static void Check()
        {
            if (Gc == null)
            {
                throw new MethodAccessException();
            }
        }
    }
}
