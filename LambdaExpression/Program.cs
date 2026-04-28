namespace LambdaExpression
{
    // A lambda expression is a short way to write an anonymous method (function without a name).
    // (parameters) => expression_or_block
    // A lambda expression is a concise way to represent an anonymous function that can be assigned to a delegate or passed as a parameter
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> predicate = x => x % 2 == 0; // takes one parameter returns bool
            Func<int,int> Mutliply2 = x => x * 2;// takes one parameter returns int
            Func<int,int,int> Sum = (x, y) => x + y;// takes two parameters returns int

            Console.WriteLine(predicate(10));
            Console.WriteLine(Mutliply2(2));
            Console.WriteLine(Sum(2,3));
            // about parameters :
            //  x => x + 1        // single param → no ()
            // (x, y) => x + y   // multiple → need ()
            // () => 5           // none → ()
        }
    }
}
