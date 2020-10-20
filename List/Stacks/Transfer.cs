using System;
using System.IO;
using System.Collections.Generic;

namespace Stacks
{
    public class Transfer
    {
        private static readonly List<string> Operands = new List<string> {"^", ":", "*", "+", "-"};

        private static readonly Dictionary<string, int> Priorities = new Dictionary<string, int>
            {{"^", 1}, {"*", 2}, {":", 2}, {"-", 3}, {"+", 3}};

        private static readonly List<string> Functions = new List<string>() {"sqrt", "sin", "cos", "ln"};

        public static string Run(string line)
        {
            var stack = new MyStack<string>();
            var result = "";
            var lines = Parser.Parsing(line);
            foreach (var e in lines)
            {
                if (Operands.Contains(e))
                {
                    var top = stack.Top();
                    if (top == null)
                    {
                        stack.Push(e);
                        continue;
                    }
                    else if (Operands.Contains(top))
                    {
                        while (true)
                        {
                            if (Priorities[top] <= Priorities[e])
                            {
                                result += stack.Pop() + " ";
                                top = stack.Top();
                                if (top == null) break;
                            }
                            else break;
                        }
                    }

                    stack.Push(e);
                }
                else if (Functions.Contains(e)) stack.Push(e);
                else switch (e)
                {
                    case "(":
                        stack.Push(e);
                        break;
                    case ")":
                    {
                        while (stack.Top() != "(") result += stack.Pop() + " ";
                        stack.Pop();
                        if (Functions.Contains(stack.Top())) result += stack.Pop() + " ";
                        break;
                    }
                    default:
                        result += e + " ";
                        break;
                }
            }
            while (stack.Top() != null) result += stack.Pop() + " ";
            return result;
        }
    }
}