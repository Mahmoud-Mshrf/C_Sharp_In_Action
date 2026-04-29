namespace SmallNote
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(2, 3));
            Console.WriteLine(Addd(4, 3));
        }
        static Func<int, int, int> Add = (x, y) => x + y;
        static int Addd(int x, int y) => x + y;
    }
}
/*
 Good question—this hits an important distinction.

🔍 Your Code
static Func<int,int,int> Add = (x, y) => x + y;
static int Addd(int x, int y) => x + y;
🎯 Core Difference
✅ Add → Delegate (variable holding a function)
✅ Addd → Method (real function)
🧠 Detailed Explanation
🔹 Add
Func<int,int,int> Add
This is a delegate instance
It’s a variable that stores a function
Uses lambda expression
Can be:
reassigned
passed as parameter
combined (multicast)

👉 Think:

“function stored in a variable”

🔹 Addd
static int Addd(int x, int y)
This is a method
Compiled as part of the class
Fixed behavior (cannot be reassigned)

👉 Think:

“normal function defined in class”

⚖️ Comparison Table
Feature	Add (Func)	Addd (Method)
Type	Delegate variable	Method
Can reassign	✔ Yes	❌ No
Can pass as parameter	✔ Yes	✔ Yes (via delegate)
Can combine (multicast)	✔ Yes	❌ No
Syntax	Lambda	Method syntax
🔥 Important Insight

Even though both do the same:

Add(2,3)
Addd(2,3)

👉 Internally:

Add → invokes a delegate (Invoke)
Addd → direct method call (faster)
⚠️ Performance Note (Advanced)
Addd is slightly faster
Add has delegate invocation overhead

👉 Usually negligible, but matters in high-performance scenarios

🧪 Key Interview Line

“Func is a delegate instance that holds a method, while a method is a member of a class. Delegates provide flexibility, while methods provide structure.”

🚀 Bonus

You can even do this:

Func<int,int,int> f = Addd;

👉 Now method becomes delegate
 */
