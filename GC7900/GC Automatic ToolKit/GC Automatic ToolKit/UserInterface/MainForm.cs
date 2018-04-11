using System;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace GC_Automatic_ToolKit
{
    public partial class MainForm : Form
    {
        //Count runtimes
        private int k = 1;  // Indicate it's k times run.
        private int max;    // Max runtimes.
        private int interval;    // Waitingtime after a routine
        private double peroid;
        private string proName;     // Program Name
        private readonly double[] peroidlimit = {0.1*60000, 14.5*60000};  //[0]: LowerLimit   [1]: UpperLimit  Unit: milliSeconds
        private const double peroidProgram=15*60000;    //Server port settings, indicates peroid    Unit:milliSecond

        private GC_Operation GC1;

        private System.Timers.Timer timer = new System.Timers.Timer();
        private System.Timers.Timer bartimer = new System.Timers.Timer();
        //private Task posthandle = null;
        //private CancellationTokenSource cancellation = new CancellationTokenSource();
        //private ExcelHandle excelhandle = new ExcelHandle();

        delegate void StringDelegate(string strings);
        delegate void TextBoxDelegate(TextBox textbox);
        delegate void VoidDelegate();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            //Prevent Input after Run
            Peroid_textbox.ReadOnly = true;
            RunTimes_textbox.ReadOnly = true;
            WaitingTime.ReadOnly = true;

            #region Check validity of data input
            try
            {
                proName = ProgramName_textbox.Text;
                GC1 = new GC_Operation(proName);
            }
            catch (Exception)
            {
                Log.AppendText("Please input Program Name.");
            }

            try
            { peroid = double.Parse(Peroid_textbox.Text) * 60000; }
            catch
            { peroid = 60000 * 15; }

            try
            { interval = (int)(double.Parse(WaitingTime.Text) * 60000); }
            catch
            { interval = 60000 * 3; }

            try
            { max = int.Parse(RunTimes_textbox.Text); }
            catch
            { max = 1; }
            #endregion

            if (peroid > peroidlimit[1])
            {
                timer.Interval = peroidProgram;
            }
            else
            {
                timer.Interval = (peroid > peroidlimit[0]) ? peroid : peroidlimit[0];
            }
            timer.AutoReset = true;
            bartimer.Interval = timer.Interval / 100;
            bartimer.AutoReset = true;

            //cancellation.CancelAfter(TimeSpan.FromMilliseconds(peroid));

            GC1.Start_Run();
            //GCHandle.GCHandleAcqClient.StartRun("GC680");

            timer.Start();
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);

            bartimer.Start();
            bartimer.Elapsed += new ElapsedEventHandler(Bartimer_Elapsed);

            //excelhandle.CreateExcel();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (k < max)
            {
                Output(Convert.ToString(k++) + " times completed.");
                timer.Stop();
                bartimer.Stop();
                if (timer.Interval != peroidProgram)
                {
                    GC1.Stop_Run();
                    //GCHandle.GCHandleAcqClient.StopRun("GC680");
                }
                ProgressBarReset();

                //this.posthandle= Task.Run(() => ReadDataFromRstFile(UserInterface.GlobalSettings._rstfilepath,cancellation.Token),cancellation.Token);
                Thread.Sleep(15000);
                //ReadDataFromRstFile(UserInterface.GlobalSettings._rstfilepath, cancellation.Token);

                Thread.Sleep(interval-15000);
                timer.Start();
                GC1.Start_Run();
                //GCHandle.GCHandleAcqClient.StartRun("GC680");
                bartimer.Start();
            }
            else
            {
                Output(Convert.ToString(k++) + " times completed.");
                k = 1;
                timer.Close();
                bartimer.Close();
                ProgressBarReset();
                TextBoxChangeLockState(Peroid_textbox);
                TextBoxChangeLockState(RunTimes_textbox);
                TextBoxChangeLockState(WaitingTime);

                Thread.Sleep(15000);
                //ReadDataFromRstFile(UserInterface.GlobalSettings._rstfilepath, cancellation.Token);
            }
        }

        private void Bartimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ProgressBarChange();
        }

        private void Output(string log)
        {
            if (this.Log.InvokeRequired)
            {
                var logadd = new StringDelegate(Output);
                this.Invoke(logadd, new object[] { log });
            }
            else
            {
                this.Log.AppendText(DateTime.Now.ToString("HH:mm:ss  ") + log + "\r\n");
            }
        }

        private void ProgressBarChange()
        {
            if (this.TimeProgressBar.InvokeRequired)
            {
                var changeprogressbar = new VoidDelegate(ProgressBarChange);
                this.Invoke(changeprogressbar, new object[] { });
            }
            else
            {
                TimeProgressBar.PerformStep();
            }
        }

        private void ProgressBarReset()
        {
            if (this.TimeProgressBar.InvokeRequired)
            {
                var resetprogressbar = new VoidDelegate(ProgressBarReset);

                this.Invoke(resetprogressbar, new object[] { });
            }
            else
            {
                this.TimeProgressBar.Value = 0;
            }
        }

        private void TextBoxChangeLockState(TextBox textbox)
        {
            if (textbox.InvokeRequired)
            {
                var t = new TextBoxDelegate(TextBoxChangeLockState);

                this.Invoke(t, new object[] { textbox });
            }
            else
            {
                textbox.ReadOnly = !textbox.ReadOnly;
            }
        }

        private void Sequence_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)8) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                Output("Sequence:Please input number");
            }
        }

        private void Peroid_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)8) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                Output("Peroid:Please input number");
            }
        }

        private void RunTimes_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
                Output("RunTimes:Please input number");
            }
        }

        private void Lock_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Lock_checkBox.Checked == true)
            { ProgramName_textbox.ReadOnly = true; }
            else
            { ProgramName_textbox.ReadOnly = false; }
        }

        public bool ReadDataFromRstFile(string rstdirpath,Object token)
        {
            Thread.Sleep(15000);
            string[] files=null;
            try
            {
                files = Directory.GetFiles(rstdirpath, "*.rst", SearchOption.AllDirectories);
            }
            catch (ArgumentException e)
            {
                Output("Path is null");
            }
            catch (PathTooLongException e)
            {
                Output("The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters. ");
            }
            catch (DirectoryNotFoundException e)
            {
                Output("The specified path is not found or is invalid (for example, it is on an unmapped drive). ");
            }
            catch (IOException e)
            {
                Output("path is a file name or a network error has occurred.");
            }
            catch (UnauthorizedAccessException e)
            {
                Output("The caller does not have the required permission");
            }

            if (files == null || files.Length == 0)
            {
                return false;
            }
            string lastestFile = null;
            DateTime lastestTime = DateTime.MinValue;
            foreach (string file in files)
            {
                DateTime fileCreationTime = new FileInfo(file).CreationTimeUtc;
                if (fileCreationTime >= lastestTime)
                {
                    lastestFile = file;
                    lastestTime = fileCreationTime;
                }
            }
            var result = GCHandle.GcHandleTcAccess.ReadAllPeaksAreaFromRst(lastestFile);
            //excelhandle.AddStringDoublePair(result,k,2);
            return true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInterface.GlobalSettings globalSettings = new UserInterface.GlobalSettings();
            globalSettings.ShowDialog();
        }
    }
}
