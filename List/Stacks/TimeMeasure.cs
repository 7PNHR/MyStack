using System;
using System.Diagnostics;

namespace Stacks
{
    public class TimeMeasure
    {
        public static double GetMeasuredTime(string path)
        {
            Prog.Run("input.txt");
            var timer = new Stopwatch();
            timer.Start();
            Prog.Run(path);
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}