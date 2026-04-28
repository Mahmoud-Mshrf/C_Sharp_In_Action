namespace MulticastDelegate
{
    // A multicast delegate is a delegate that maintains an invocation list of multiple methods and invokes them sequentially in the order they were added. All delegates in C# support multicast behavior using += and -= operators
    // A multicast delegate is a delegate that can hold references to multiple methods, and when invoked, it calls all of them in order.
    // *Important rule* : If delegate returns a value: Only the last method’s return value is kept
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            RectangleHelper rectangle = new RectangleHelper();
            Action<decimal,decimal> action = rectangle.GetArea;
            action += rectangle.GetPerimeter;
            action(2, 4);
        }
    }
    public class RectangleHelper
    {
        public void GetArea(decimal width, decimal height)
        {
            var result = width * height;
            Console.WriteLine($"AREA ={width} * {height}= {result} ");
        }
        public void GetPerimeter(decimal width, decimal height)
        {
            var result = 2 * (width * height);
            Console.WriteLine($"PERIMETER = 2 * ({width} * {height})= {result} ");

        }
    }
}
