namespace OverrideEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            Console.WriteLine(p1.Equals(p2)); // True because we have override the Equals method to compare the values of the objects
            Console.WriteLine($"p1.GetHashCode() = {p1.GetHashCode()}");
            Console.WriteLine($"p2.GetHashCode() = {p2.GetHashCode()}");
            var points = new Dictionary<Point, string>();
            points.Add(p1, "A");
            points.Add(p2, "A");// if we override the Equals method and the GetHashCode method the dictionary will not add the second point because the hash code of the two points are the same


        }
    }
    // Implementing the IEquatable interface to override the Equals method is not important in class but it is important in struct because its effect on the performance
    class Point:IEquatable<Point> // here we implement the IEquatable interface to override the Equals method
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(object? obj)
        {
            var p = obj as Point;
            return this.Equals(p);
        }

        public bool Equals(Point? other)
        {
            if (other is null)
                return false;
            return other.X == X && other.Y == Y;
        }

        //public override int GetHashCode()
        //{
        //    int hash = 17;
        //    hash = hash * 23 + X.GetHashCode();
        //    hash = hash * 23 + Y.GetHashCode();
        //    return hash;
        //}
        // the previous implementation of the GetHashCode method is the same as the following implementation
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);// here we combine the hash code of the X and Y
        }
    }
}
