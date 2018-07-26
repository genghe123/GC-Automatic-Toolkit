using System;
using System.IO;
using GC_Automatic_ToolKit.Handler;

namespace GC_Automatic_ToolKit.GCConfig
{
    internal class PerkinElmerConfig
    {
        //Count runtimes
        private int _max;    // Max runtimes.
        private double _peroid;
        private DirectoryInfo _resultPath;


        private DirectoryInfo ResultPathAlternative()
        {
            try
            {
                ResultPath = new DirectoryInfo(GCHandleAcqClient.GetResultFilePath(InstrumentKey));
            }
            catch (Exception)
            {

            }
            return _resultPath;
        }

        public int K { get; set; } = 1;
        public int Max { get => _max; set => _max = Math.Abs(value) + _max; }
        public double Interval { get; set; }
        public double Peroid { get => _peroid; set => _peroid = Math.Max(Math.Min(value, PeroidLimit[1]), PeroidLimit[0]); }
        public double[] PeroidLimit { get; } = { 0.1, /*14.5*/ double.MaxValue };
        public double InstrumentStopPeroid { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string InstrumentKey { get; set; }
        public DirectoryInfo ResultPath { get => ResultPathAlternative(); set => _resultPath = value; }
    }
}
