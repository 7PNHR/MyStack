using System.Diagnostics;

namespace List
{
    public static class TimeMeasure
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