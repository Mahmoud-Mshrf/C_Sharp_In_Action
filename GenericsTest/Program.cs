namespace GenericsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Any<T>
    {
        private T[] _items;
        private int _count;
        public decimal Count { get { return _count; } }

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
                _items =new T[] {  item };
            }
            else
            {
                var length = _items.Length;
                var temp = new T[length + 1];
                Array.Copy(_items, temp, length);
                temp[length] = item;
                _items=temp;
            }
        }

        private void Resize()
        {
            var newCapacity = _items.Length == 0 ? 0 : _items.Length * 2;
            var newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }
        public Any(int capacity=4)
        {
            _items = new T[capacity];
        }

        public void ThirdAdd(T item)
        {
            if(_count == _items.Length)
            {
                Resize();
            }
            _items[_count++] = item;
        }

        public void FirstRemoveAt(int position)
        {
            if (position < 0 || position > _items.Length - 1)
                return;
            var index = 0;
            var temp = new T[_items.Length-1];
            for(int i=0; i < _items.Length; i++ )
            {
                if (i == position)
                    continue;
                temp[index++] = _items[i];
            }
            _items = temp;
        }

        public void SecondRemoveAt(int position)
        {
            if(position < 0 || position > _count) return;
            
            for(int i = position ; i < _count - 1; ++i)
            {
                _items[i] = _items[i + 1];
            }
            _count--;

            // optional this make the last element equal the default for the datataype because we shifting it so it doesn't mean anything in our list
            _items[_count] = default;
        }
    }
}
