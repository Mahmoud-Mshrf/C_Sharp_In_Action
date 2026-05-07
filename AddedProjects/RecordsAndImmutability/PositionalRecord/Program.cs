namespace PositionalRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(10, 20);
            //p1.X = 30;// it will give combile time error because positional record is immutable by default
            Console.WriteLine(p1);
            var (x, y) = p1;// Deconstructing a record into individual variables means that you can use the record as a tuple
            Console.WriteLine($"x = {x}, y = {y}");
            var p2 = new Point { X = 10, Y = 20 };// to create a record using this way must have a this constructor in record
        }
    }
    // record point (int X, int Y); // this is a positional record and it is immutable by default and it has a deconstruct method that allows us to deconstruct the record into individual variables and add init accessors to the properties make it have initial values 
    record Point(int X, int Y) // the same as the previous record but with the availability to initialize the properties using object initializer and it is also immutable by default
    {
        public Point():this(0,0) // this constructor is required to create a record and initialize it using object initializer
        {
            
        }
    }
}
