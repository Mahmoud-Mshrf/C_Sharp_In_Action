using System.Collections;

namespace Enumerator_step_by_step
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new ThreeIntegers(1,2,3);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            // internally compiler translated foreach to the following code :
            var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        
    }
    public class ThreeIntegers : IEnumerable
    {
        private int[] _values;

        public ThreeIntegers(int num1,int num2, int num3)
        {
            _values = [num1,num2,num3];
        }

        public IEnumerator GetEnumerator()
        {
            foreach (int i in _values)
            {
                yield return i;
            }
        }
    }
    public class FourIntegers: IEnumerable
    {
        private int[] _values;
        public FourIntegers(int num1, int num2, int num3,int num4)
        {
            _values = [num1, num2, num3,num4];
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        class Enumerator : IEnumerator
        {
            private int _currentIndex=-1;
            FourIntegers _integers;

            public Enumerator(FourIntegers integers)
            {
                _integers = integers;
            }
            public object Current
            {
                get
                {
                    if (_currentIndex == -1)
                        throw new InvalidOperationException("Enumeration not started");
                    if (_currentIndex > _integers._values.Length - 1)
                        throw new InvalidOperationException("Enumeration has ended");
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
