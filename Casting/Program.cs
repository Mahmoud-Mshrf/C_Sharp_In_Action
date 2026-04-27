using System.Runtime.CompilerServices;

namespace Casting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 65;
            Console.WriteLine(Convert.ToString(i));// this print string

            string x = "10";
            Console.WriteLine(int.Parse(x));// this print int , but if the value x not really represent int it will make exception so we use TryParse is safer than parse
            if(int.TryParse(x, out int z))
            {
                Console.WriteLine(z);
            }

            // implicit and explicit casting:
            int i1 = 10;
            object o = i1; // this ok because all types inherits from object then no problem to assign it to object

            //
            int i2 =(int) o;// must put (int) because i tell the compilr that the value assigned to object o is int value i guranteed this on my responsibility
            


            ///////////////////////////////////////
            // Boxing and unboxing are type conversion operations in C#:
            // Boxing is when a value type(like int, float, struct) is converted to the object type(reference type). It involves:
            /*
             * Taking a value from the stack
             * Creating a new object on the heap
             * Copying the value into that object
             */
            int number = 42;              // Value type on stack
            object boxed = number;        // Boxes the int into an object on heap
            // Unboxing is when an object type is converted back to a value type. It involves:
            /*
             * Taking a reference type (object)
             * Extracting the value type from it
             * Placing it on the stack
             */
            object boxed2 = 42;           // Boxed value
            int unboxed = (int)boxed2;    // Unboxing back to int

        }
    }
}
