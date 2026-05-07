using System.Security.Cryptography;

namespace Records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point { X = 10, Y = 20 };
            var p2 = new Point { X = 10, Y = 20 };
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}");
            Console.WriteLine($"p1 == p2 = {p1 == p2}");

        }
    }
    record Point
    {
        // Records provide the following:
        // a built-in override of ToString
        // a built-in override of Equals
        // a built-in override of GetHashCode
        // a built-in implementation of IEquatable<T>
        // a built-in override of == and !=
        public int X;
        public int Y;
    }
}
