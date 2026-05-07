namespace ReferenceBasedEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var p1 = new Point { X = 1, Y = 2 };
            //var p2 = new Point { X = 1, Y = 2 };
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            Console.WriteLine(p1.Equals(p2)); // False becuase the class is reference type and the reference of p1 and p2 are different so we must override the Equals method to compare the values of the objects
            Console.WriteLine(object.ReferenceEquals(p1,p2)); // False becuase the reference of p1 and p2 are different
            p1 = p2;// here we make the reference of p1 equal to the reference of p2
            Console.WriteLine(p1.Equals(p2)); // True becuase the reference of p1 and p2 are the same
            Console.WriteLine(object.ReferenceEquals(p1, p2)); // True becuase the reference of p1 and p2 are the same

        }
    }
    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
    /*
     * --Aspect--	          --Value Type--	                           --Reference Type--
        Storage  	           Stored on the stack.	                        Stored on the heap (reference on stack).
        Copying Behavior 	   Creates a new copy of the data.	            Copies the reference, not the data.
        Lifetime 	           Scoped to the block in which it’s defined.	Controlled by the garbage collector.
        Performance  	       Faster for small, simple data.	            May be slower due to heap allocation.
        Examples 	           int, bool, struct	                        string, class, array
     */
}
