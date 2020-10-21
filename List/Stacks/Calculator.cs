using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace List
{
    public class Calculator
    {
        private readonly Dictionary<string, int> _values = new Dictionary<string, int>();
        private readonly string _reversePolishNotation;

        private readonly Dictionary<string, Func<int, int, int>> _operands = new Dictionary<string, Func<int, int, int>>
        {
            {"+", (y, x) => x + y},
            {"-", (y, x) => x - y},
            {"*", (y, x) => x * y},
            {":", (y, x) => x / y},
            {"^", (y, x) => (int) Math.Pow(x, y)}
        };

        private readonly Dictionary<string, Func<int, int>> _funcs = new Dictionary<string, Func<int, int>>
        {
            {"ln", x => (int) Math.Log(x)},
            {"sin", x => (int) Math.Sin(x)},
            {"cos", x => (int) Math.Cos(x)},
            {"sqrt", x => (int) Math.Pow(x, 0.5)}
        };

        public Calculator(string path)
        {
            var line = File.ReadAllText(path).Split('\r', '\n').Where(x => x != "").ToList();
            _reversePolishNotation = Transfer.Run(line[0]);
            line.RemoveAt(0);
            foreach (var split in line.Select(e => e.Split('=')))
                _values.Add(split[0], int.Parse(split[1]));
        }

        public int Calculate()
        {
            var stack = new MyStack<string>();
            foreach (var e in _reversePolishNotation.Split(' '))
            {
                if (_operands.ContainsKey(e))
                {
                    var firstValue = stack.Pop();
                    var secondValue = stack.Pop();
                    stack.Push(_operands[e](
                        _values.ContainsKey(firstValue) ? _values[firstValue] : int.Parse(firstValue),
                        _values.ContainsKey(secondValue) ? _values[secondValue] : int.Parse(secondValue)
                    ).ToString());
                }
                else if (_funcs.ContainsKey(e))
                {
                    var value = stack.Pop();
                    stack.Push(_funcs[e](
                        _values.ContainsKey(value) ? _values[value] : int.Parse(value)
                    ).ToString());
                }
                else if (_values.ContainsKey(e) || int.TryParse(e, out var per))
                    stack.Push(e);
            }

            return int.Parse(stack.Pop());
        }
    }
}