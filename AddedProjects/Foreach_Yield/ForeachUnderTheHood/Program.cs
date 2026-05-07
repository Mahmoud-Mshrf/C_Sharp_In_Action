namespace ForeachUnderTheHood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the foreach loop is better than the for loop in terms of performance when it comes to iterating over collections (especially when it comes to lists (dealing with LINQ) )
            // the for loop is better when it comes to arrays
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Using for");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Using foreach");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            Console.WriteLine("Using foreach under the hood");
            ForEach(numbers);

        }
        // this is how the foreach loop is implemented under the hood
        static void ForEach<T>(IEnumerable<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();// this is how the foreach loop gets the enumerator
            IDisposable disposable;// this is to dispose the enumerator after it's done
            try
            {
                T item;
                while (enumerator.MoveNext())// this is how the foreach loop checks if there are more items
                {
                    item = enumerator.Current;// this is how the foreach loop gets the current item
                    Console.WriteLine(item);
                }
            }
            finally
            {
                disposable = enumerator as IDisposable;// here we cast the enumerator to IDisposable
                disposable.Dispose();// this is how the foreach loop disposes the enumerator
            }
            
        }
    }
}
