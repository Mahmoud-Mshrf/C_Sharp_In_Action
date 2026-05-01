namespace Generics01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Names = new Any<string>();
            Names.FirstAdd("Mahmoud");
            Names.FirstAdd("Mohamed");
            Names.FirstAdd("Ahmed");
            Names.Display();
            Names.RemoveAt(0);
            Console.WriteLine();
            Names.Display();

        }
    }
    public class Any<T>
    {
        private T[] _items;

        public void FirstAdd(T item)
        {
            if (_items == null)
            {
                _items = [item];
            }
            else
            {
                var length = _items.Length;
                var temp = new T[length + 1];
                for (int i = 0; i < length; i++)
                {
                    temp[i] = _items[i];
                }
                temp[length] = item;
                _items = temp;
            }
        }
        // the difference between Add and Addd is the way of copying _items into temp
        // in both each item addition we copy the existing item and its bad for performance 
        public void SecondAdd(T item)
        {
            if (_items == null)
            {
                _items = new T[] { item };
            }
            else
            {
                var length = _items.Length;
                var temp = new T[length + 1];
                Array.Copy(_items, temp, length);
                temp[length] = item;
                _items = temp;
            }
        }


        public void RemoveAt(int position)
        {
            if (position < 0 || position > _items.Length - 1)
                return;
            var index = 0;
            var temp = new T[_items.Length - 1];
            for (int i = 0; i < _items.Length; i++)
            {
                if (i == position)
                    continue;
                temp[index++] = _items[i];
            }
            _items = temp;
        }

        public bool IsEmpty => _items.Length == 0 || _items is null;
        public int Count => _items is null ? 0 : _items.Length;

        public void Display()
        {
            Console.Write("[");
            for ( int i = 0; i < _items.Length; i++)
            {
                Console.Write(_items[i]);
                if(i < _items.Length - 1)
                    Console.Write(" , ");
            }
            Console.Write("]");

        }
    }
}
