using System.ComponentModel;
using System.Numerics;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Sum(new int[]{ 1, 2, 3, 4 });
            Console.WriteLine(result);
            result = Summ([1, 2, 3, 4],(x,y)=> x+y);
            Console.WriteLine(result);
        }
        static T Sum<T>(T[] values) where T : INumber<T>// where T : INumbers<T> allows using + 
        {
            T result = default(T);
            foreach (T value in values)
            {
                result = result + value;
            }
            return result;
        }

        static T Summ<T>(T[] values, Func<T, T, T> factory)
        {
            var result = default(T);
            foreach (T value in values)
            {
                result = factory(result, value);
            }
            return result;
        }
    }
    public class Collection<T>
    {
        private T[] _items;

        public void Add(T item)
        {
            if(this._items == null)
            {
                _items = [item];
            }
            else
            {
                var length = this._items.Length;
                var temp = new T[_items.Length+1];
                for (int i = 0; i < length; i++)
                {
                    temp[i] = _items[i];
                }
                temp[temp.Length-1] = item;
                _items = temp;
            }
        }
        /*
        Add implementation (manual loop copy) creates a new array every time you insert an element,
        then copies all existing elements one by one using a for loop before adding the new item.
        While this is logically correct, it is inefficient because each call to Add performs an O(n) copy operation,
        where n is the current number of elements. Over multiple insertions,
        this becomes O(n²) total work (because you repeatedly copy growing arrays: 1 element, then 2, then 3, etc.). On top of that,
        the manual loop runs in managed code, adding per-iteration overhead compared to optimized memory operations. So although it works,
        it scales poorly and becomes slow as the collection grows .
         */

        public void Adds(T item)
        {
            if (_items == null)
            {
                _items = new T[] { item };
                return;
            }

            var temp = new T[_items.Length + 1];
            Array.Copy(_items, temp, _items.Length);
            temp[_items.Length] = item;
            _items = temp;
        }
        /*
        Adds implementation (using Array.Copy) improves slightly by replacing the manual loop with a built-in optimized copying method,
        which is faster at the micro level because it uses highly optimized internal routines.
        However, it still suffers from the same fundamental problem: you are resizing the array on every single insertion.
        That means allocating a new array and copying all elements every time you call Add. Even though Array.Copy is faster than a loop,
        the overall algorithm is still O(n²) for multiple insertions, and frequent memory allocations also increase pressure on the garbage collector.
        So this version is better than the first in implementation detail, but not in overall design.
         */
    }
    class MyList<T>
    {
        private T[] _items;
        private int _count;

        public MyList(int capacity = 4)
        {
            _items = new T[capacity];
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count++] = item;
        }

        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
            var newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }
    }
    /*
    The correct and efficient approach is to separate capacity from count and only resize the array occasionally,
    typically by doubling its size when it becomes full.
    In this version, most Add operations simply place the new element into an already allocated slot in constant time O(1),
    and resizing (which is O(n)) happens rarely.
    This results in an amortized O(1) complexity for insertion, which is exactly how List<T> works internally.
    The key improvement is that you avoid repeated allocations and copying on every insert, dramatically improving performance for large datasets.
     */
}
