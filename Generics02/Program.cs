namespace Generics02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Names = new Any<string>();
            Names.ThirdAdd("Mahmoud");
            Names.ThirdAdd("Mohamed");
            Names.ThirdAdd("Ahmed");
            Names.Display();
            Names.RemoveAt(0);
            Console.WriteLine();
            Names.Display();
        }
    }
    public class Any<T>
    {
        private T[] _items;
        private int _count;
        private void Resize()
        {
            var newCapacity = _items.Length == 0 ? 0 : _items.Length * 2;
            var newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }
        public Any(int capacity = 4)
        {
            _items = new T[capacity];
        }

        public void ThirdAdd(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count++] = item;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position > _count) return;

            for (int i = position; i < _count - 1; ++i)
            {
                _items[i] = _items[i + 1];
            }
            _count--;

            // optional this make the last element equal the default for the datataype because we shifting it so it doesn't mean anything in our list
            _items[_count] = default;
        }

        public bool IsEmpty => _count == 0 || _items == null;
        public decimal Count { get { return _count; } }
        public void Display()
        {
            Console.Write("[");
            for (int i = 0; i < _count; i++)
            {
                Console.Write(_items[i]);
                if(i < _count - 1)
                    Console.Write(" , ");
            }
            Console.Write("]");

        }
    }
}
