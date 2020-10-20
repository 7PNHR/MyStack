using System;
using System.IO;

namespace Stacks
{
    public class Prog
    {
        private static void Push(MyStack<string> stack, string value)
        {
            stack.Push(value);
            Console.WriteLine("В стек добавлен элемент - " + value + " (Push)");
        }

        private static string Pop(MyStack<string> stack)
        {
            var value = stack.Pop();
            Console.WriteLine(value != null
                ? "Из стека удалён элемент: " + value + "(Pop) "
                : "Стек пустой (Pop)");
            return value;
        }

        private static string Top(MyStack<string> stack)
        {
            var value = stack.Top();
            Console.WriteLine(value != null
                ? "Верщина стека: " + value + "(Top) "
                : "Стек пустой (Top)");
            return value;
        }

        private static bool IsEmpty(MyStack<string> stack)
        {
            var isempty = stack.IsEmpty();
            Console.WriteLine(isempty == true
                ? "Стек пустой(IsEmpty)"
                : "Стек не пустой(IsEmpty)");
            return isempty;
        }

        private static void Print(MyStack<string> stack)
        {
            stack.Print();
            Console.WriteLine("Стек выведен(Print)");
        }

        public static void Run(string path)
        {
            var stack = new MyStack<string>();
            var commands = File.ReadAllText(path).Split(' ');
            foreach (var command in commands)
            {
                if (command.Contains("1"))
                    Push(stack, command.Split(',')[1]);
                else if (command.Contains("2"))
                    Pop(stack);
                else if (command.Contains("3"))
                    Top(stack);
                else if (command.Contains("4"))
                    IsEmpty(stack);
                else if (command.Contains("5"))
                    Print(stack);
            }
        }
    }
}