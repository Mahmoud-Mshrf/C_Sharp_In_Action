using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Null conditional operator
            string s1 = null;
            s1?.ToUpper(); // if not null make it uppercase else do nothing
            // Null coealising operator 
            string s2 = null;
            string s3 = s2 ?? "Default value"; // if s2 is null make s3 equal "Default value" else make it equal s2
            ///////////////////////////////////
            // Ternary operator
            string s4 = s3 is not null ? s3 : "Default value"; // if s3 is not null make s4 equal s3 else make it equal "Default value"
            ///////////////////////////////////////////////////
            // switch case 
            var mark = 90;
            switch(mark)
            {
                case 90:
                    Console.WriteLine("Excellent");
                    break;
                case 80:
                    Console.WriteLine("Very Good");
                    break;
                default:
                    Console.WriteLine("fail");
                    break;
            }
            var number = 0;
            switch(number)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("5 or less");
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Console.WriteLine("more than 5");
                    break;
            }
            object o = 3;
            switch(o)
            {
                case int i:
                    Console.WriteLine("int value = "+i);
                    break;
                case long l:
                    Console.WriteLine("Long value = "+l);
                    break;
                case float f:
                    Console.WriteLine("Float value = "+f);
                    break;
            }
            bool x = true;
            // predicit switch i till him that if the variable is bool and when its value equal true do something and he itself know because that its bool that the other case when it equal false and i havent to type it , just type case bool i
            switch (x)
            {
                case bool i when x == true:
                    Console.WriteLine("True value");
                    break;
                case bool i :
                    Console.WriteLine("False value");
                    break;
            }
            int cardNumber = 0;
            string cardName = cardNumber switch
            {
                1 => "Ace",
                2 => "King",
                3 => "Queen",
                _=> cardNumber.ToString()// means any other value
            };
            ////////////////////////////////
            // loops
            for (int i = 0; i< 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            /////////////////
            var v = 0;
            while (v < 10)
            {
                Console.WriteLine(v);
                v++;
            }
            Console.WriteLine();
            do
            {
                Console.WriteLine(v);
                v++;
            }
            while (v<10);
        }
    }
}
