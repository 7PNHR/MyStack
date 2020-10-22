using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace List
{
    public static class TimeMeasure
    {
        public static string GetMeasuredTime(string path)
        {
            Prog.Run(File.ReadAllText("input.txt").Split(' '));
            var array = File.ReadAllText(path).Split('\n').Where(x=>x!="");
            var count = 0;
            var timer = new Stopwatch();
            var line = new StringBuilder();
            foreach (var e in array)
            {
                foreach (var t in e.Split('_'))
                {
                    count++;
                    if (count == 1)
                    {
                        line.Append(t+" ");
                        continue;
                    }
                    timer.Start();
                    Prog.Run(t.Split(' '));
                    timer.Stop();
                    line.Append(timer.ElapsedMilliseconds.ToString()+" ");
                    timer.Reset();
                }

                count = 0;
                line.Append("\n");
            }
            return line.ToString();
        }
    }
}