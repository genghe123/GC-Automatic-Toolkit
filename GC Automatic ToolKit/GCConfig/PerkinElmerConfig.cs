using System;
using System.IO;
using GC_Automatic_ToolKit.Handler;
using GC_Automatic_ToolKit.UserInterface;

namespace GC_Automatic_ToolKit.GCConfig
{
    internal class PerkinElmerConfig
    {
        //Count runtimes
        private int k = 1;  // Indicate it's k times run.
        private int max;    // Max runtimes.
        private double interval;    // Waitingtime after a routine
        private double peroid;
        private readonly double[] peroidLimit = { 0.1 * 60000, 14.5 * 60000 };  //[0]: LowerLimit   [1]: UpperLimit  Unit: milliSeconds
        private const double peroidProgram = 15 * 60000;    //Server port settings, indicates peroid    Unit:milliSecond
        private string key = "GC680";
        private DirectoryInfo resultPath;
        

        public PerkinElmerConfig(string key)
        {
            Key = key;
            ResultPath = new DirectoryInfo(GCHandleAcqClient.GetResultFilePath(Key));
            if (!ResultPath.Exists)
            {
                GlobalSettings globalSettings = new GlobalSettings();
                globalSettings.ShowDialog();
                ResultPath = new DirectoryInfo(globalSettings.Rstfilepath);
            }
        }

        public int K { get => k; set => k = value; }
        public int Max { get => max; set => max = Math.Abs(value) + max; }
        public double Interval { get => interval; set => interval = value * 60000; }
        public double Peroid { get => peroid; set => peroid = Math.Max(Math.Min(value * 60000, peroidLimit[1]), peroidLimit[0]); }
        public string Key { get => key; set => key = value; }
        public DirectoryInfo ResultPath { get => resultPath; set => resultPath = value; }
    }
}
