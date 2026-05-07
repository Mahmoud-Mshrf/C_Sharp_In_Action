namespace PropertyInitSetter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point { X = 1, Y = 2 };
            var p2 = new Point { X = 1, Y = 2 };
            var p3 = new Point(1, 2);
            var p4 = new Point(1, 2);
            
        }
        // here we use the init keyword to make the property setter only in the initialization , so we can't change the value of the property after the initialization(immutable)
    }
    class Point
    {
        public Point()
        {
            
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; init; }
        public int Y { get; init; }
    }
}
