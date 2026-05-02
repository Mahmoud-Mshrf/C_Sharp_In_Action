using System.Collections;
using System.Diagnostics;

namespace _02_Enumerators_Iterators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var four = new FourIntegers(1,2,3,4);
            foreach (var x in four)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            var five = new FiveIntegers(1, 2, 3, 4,5);
            foreach (var x in five)
            {
                Console.WriteLine(x);
            }
        }
    }
    public class FourIntegers:IEnumerable 
    {
        private int[] _values;
        public FourIntegers(int num1, int num2, int num3, int num4)
        {
            _values = [num1, num2, num3, num4];
        }

        public IEnumerator GetEnumerator()
        {
            foreach (int i in _values)
            {
                yield return i;
            }
        }
    }
    //  foreach works by using an enumerator.
    //  You can either let the compiler generate this enumerator using yield,
    //  or you can implement it manually by creating a class that tracks the current position and moves through the collection.

    public class FiveIntegers : IEnumerable
    {
        private int[] _values;
        public FiveIntegers(int num1, int num2, int num3, int num4,int num5)
        {
            _values = [num1, num2, num3, num4,num5];
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        class Enumerator : IEnumerator
        {
            private int _currentIndex = -1;
            private FiveIntegers _integers;

            public Enumerator(FiveIntegers integers)
            {
                _integers = integers;
            }

            public object Current
            {
                get
                {
                    if (_currentIndex == -1)
                        throw new InvalidOperationException("Enumeration not started");
                    if (_currentIndex == _integers._values.Length)
                        throw new InvalidOperationException("Enumeration ended");
                    return _integers._values[_currentIndex];
                }
            }

            public bool MoveNext()
            {
                if(_currentIndex >= _integers._values.Length-1)
                    return false;
                return ++_currentIndex < _integers._values.Length;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }
}
