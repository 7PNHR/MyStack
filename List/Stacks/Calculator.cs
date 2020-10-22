using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Globalization;

namespace List
{
    public class Calculator
    {
        private readonly Dictionary<string, double> _values = new Dictionary<string, double>();
        private readonly string _reversePolishNotation;

        private readonly Dictionary<string, Func<double, double, double>> _operands = new Dictionary<string, Func<double, double, double>>
        {
            {"+", (y, x) => x + y},
            {"-", (y, x) => x - y},
            {"*", (y, x) => x * y},
            {":", (y, x) => x / y},
            {"^", (y, x) =>Math.Pow(x, y)}
        };

        private readonly Dictionary<string, Func<double, double>> _funcs = new Dictionary<string, Func<double, double>>
        {
            {"ln", Math.Log},
            {"sin", Math.Sin},
            {"cos", Math.Cos},
            {"sqrt", x => Math.Pow(x, 0.5)}
        };

        public Calculator(string path)
        {
            var line = File.ReadAllText(path).Split('\r', '\n').Where(x => x != "").ToList();
            _reversePolishNotation = Transfer.Run(line[0]);
            line.RemoveAt(0);
            foreach (var split in line.Select(e => e.Split('=')))
                _values.Add(split[0], double.Parse(split[1]));
        }

        public double Calculate()
        {
            var stack = new MyStack<string>();
            foreach (var e in _reversePolishNotation.Split(' '))
            {
                if (_operands.ContainsKey(e))
                {
                    var firstValue = stack.Pop();
                    var secondValue = stack.Pop();
                    stack.Push(_operands[e](
                        _values.ContainsKey(firstValue) ? _values[firstValue] : double.Parse(firstValue),
                        _values.ContainsKey(secondValue) ? _values[secondValue] : double.Parse(secondValue)
                    ).ToString(CultureInfo.CurrentCulture));
                }
                else if (_funcs.ContainsKey(e))
                {
                    var value = stack.Pop();
                    stack.Push(_funcs[e](
                        _values.ContainsKey(value) ? _values[value] : double.Parse(value)
                    ).ToString(CultureInfo.CurrentCulture));
                }
                else if (_values.ContainsKey(e) || double.TryParse(e, out var per))
                    stack.Push(e);
            }
            return double.Parse(stack.Pop());
        }
    }
}