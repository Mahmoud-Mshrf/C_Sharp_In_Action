namespace Yield_Keyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using GenerateV1()");
            foreach (var number in GenerateV1())
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            Console.WriteLine("Using GenerateV2()");
            foreach (var number in GenerateV2())
            {
                Console.WriteLine(number);
            }
        }
        static IEnumerable<int> GenerateV1() 
        {
            var result = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(i);
            }
            return result;
        }
        static IEnumerable<int> GenerateV2() 
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }// this is how the yield keyword works under the hood , it's a state machine that keeps track of the state of the method and the current value of the iteration 
        // it's a more efficient way to generate sequences of values
        // in the first method we are creating a list and adding the values to it and then returning the list
        // in the second method we are using the yield keyword to return the values one by one 
        // the second method is more efficient because it doesn't create a list and add the values to it , it just returns the values one by one
    }

}
