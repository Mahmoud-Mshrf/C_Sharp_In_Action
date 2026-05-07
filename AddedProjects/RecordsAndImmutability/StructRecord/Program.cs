namespace StructRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(10, 20);
            //p1.X = 30;// it will work because the struct positional record is mutable by default to make it immutable use readonly keyword
            Console.WriteLine(p1);
        }
    }
    public readonly record struct Point(int X, int Y);// this is a struct record and it is mutable by default to make it immutable use readonly keyword on the declaration of the record and on its properties

    public readonly record struct Point1 // to make it immutable use readonly keyword on the declaration of the record and on its properties
    {
        public Point1(int x, int y)
        {
            X = x;
            Y = y;
        }
        public readonly int X;
        public readonly int Y;
    }
}
