namespace WithExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(10, 20);
            var p2 = new Point(30, p1.Y);// this is a bad practice to create a new object with some properties of the old object
            var p3 = p1 with { X = 30 };// with expression is used to create a new object with some properties of the old object , here we put just the properties that we want to change and the rest will be copied from the old object
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
        }
    }
    record Point(int X,int Y);
}
