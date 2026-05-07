namespace ImmutableRecordsUsingInit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point { X = 10, Y = 20 };
            var p2 = new Point { X = 10, Y = 20 };
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            //p1.X = 30;// it will give combile time error because X is init property and it can be set only once while creating object (immutable)
            Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}");
            Console.WriteLine($"p1 == p2 = {p1 == p2}");
        }
    }
    record Point
    {
        public int X { get; init; }
        public int Y { get; init; }
    }

}
