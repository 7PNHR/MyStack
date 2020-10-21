using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace List
{
    static class Program
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine();
            var time = TimeMeasure.GetMeasuredTime(path);
            File.WriteAllText(File.ReadAllText(path).Split(' ').Length-1 + "_"
                              +DateTime.Now.Millisecond+ "_"
                              +".txt",time.ToString(CultureInfo.InvariantCulture));
            var calc = new Calculator("inf.txt");
            var result = calc.Calculate();
            Console.WriteLine();
            Console.WriteLine(result);
        }
    }
}