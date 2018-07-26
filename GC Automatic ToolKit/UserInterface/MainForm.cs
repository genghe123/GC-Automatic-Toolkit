using System;
using System.Timers;
using System.Windows.Forms;

namespace GC_Automatic_ToolKit.UserInterface
{
    public partial class MainForm : Form
    {
        //private GC_Operation GC1;
        private GCConfig.PerkinElmerConfig GC;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            GC = new GCConfig.PerkinElmerConfig("GC680");

            #region Check validity of data input
            GC.Peroid = double.TryParse(Peroid_textbox.Text, out double peroid) ? peroid : 15;
            GC.Interval = double.TryParse(WaitingTime.Text, out double interal) ? interal : 0.5;
            GC.Max = int.TryParse(RunTimes_textbox.Text, out int max) ? max : 1;
            #endregion

            //GC1.Start_Run();
            Runtime.Run(GC);
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }

        public void Output(string log)
        {
            if (Log.InvokeRequired)
            {
                var logadd = new Action<String>(Output);
                Invoke(logadd, new object[] { log });
            }
            else
            {
                Log.AppendText(DateTime.Now.ToString("HH:mm:ss  ") + log + "\r\n");
            }
        }

        public void ProgressBarChange()
        {
            if (TimeProgressBar.InvokeRequired)
            {
                
                var changeprogressbar = new Action(ProgressBarChange);
                Invoke(changeprogressbar, new object[] { });
            }
            else
            {
                TimeProgressBar.PerformStep();
            }
        }

        public void ProgressBarReset()
        {
            if (TimeProgressBar.InvokeRequired)
            {
                var resetprogressbar = new Action(ProgressBarReset);

                Invoke(resetprogressbar, new object[] { });
            }
            else
            {
                TimeProgressBar.Value = 0;
            }
        }

        private void TextBoxChangeLockState(TextBox textbox)
        {
            if (textbox.InvokeRequired)
            {
                var t = new Action<TextBox>(TextBoxChangeLockState);

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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ShowDialog();
        }
    }
}
