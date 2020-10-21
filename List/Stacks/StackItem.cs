namespace List
{
    public class StackItem<T>
    {
        public T Value { get; set; }
        public StackItem<T> Previous { get; set; }
    }
}