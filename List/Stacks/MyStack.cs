using System;

namespace Stacks
{
    public class MyStack<T>
    {
        private StackItem<T> _tail;

        public void Push(T value)
        {
            if (_tail == null)
                _tail = new StackItem<T> {Value = value, Previous = null};
            else
            {
                var item = new StackItem<T> {Value = value, Previous = _tail};
                _tail = item;
            }
        }

        public T Pop()
        {
            if (_tail == null) return default(T);
            var value = _tail.Value;
            _tail = _tail.Previous;
            return value;
        }

        public T Top()
        {
            if (_tail == null) return default(T);
            var value = _tail.Value;
            return value;
        }

        public bool IsEmpty()
        {
            return _tail == null ? true : false;
        }

        public void Print()
        {
            var oldTail = _tail;
            while (_tail != null)
            {
                Console.WriteLine(_tail.Value);
                _tail = _tail.Previous;
            }

            _tail = oldTail;
        }
    }
}