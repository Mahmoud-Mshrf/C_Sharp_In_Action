namespace OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet1 = new Wallet(1000);
            Wallet wallet2 = new Wallet(2000);

            Wallet wallet3 = wallet1 + wallet2;
            Wallet wallet4 = wallet2 - wallet1;
            Console.WriteLine(wallet3.Balance);
            Console.WriteLine(wallet4.Balance);
        }
    }
    public class Wallet
    {
        public Wallet(decimal balance)
        {
            Balance = balance;
        }
        public decimal Balance { get; private set; }
        // operator overloading :
        public static Wallet operator +(Wallet left, Wallet right) => new Wallet(left.Balance + right.Balance);
        public static Wallet operator -(Wallet left, Wallet right) => new Wallet(left.Balance - right.Balance);
        public static bool operator <(Wallet left, Wallet right) => left.Balance < right.Balance;
        public static bool operator >(Wallet left, Wallet right) => left.Balance > right.Balance;
        public static bool operator ==(Wallet left, Wallet right) => left.Balance == right.Balance;
        public static bool operator !=(Wallet left, Wallet right) => left.Balance != right.Balance;
        public static Wallet operator ++ (Wallet wallet) => new Wallet(++wallet.Balance);
        public static Wallet operator -- (Wallet wallet) => new Wallet(--wallet.Balance);
    }
}
/*
 Operator overloading is a C# feature that lets you define custom behavior for operators (like +, -, ==, etc.) when they’re used with your own types (classes/structs).

🎯 Simple Definition (Interview-ready)

Operator overloading allows you to redefine how operators work for user-defined types.

🧠 Why we need it

By default, operators work with built-in types:

int a = 5 + 3; // works

But with custom objects:

Point p1, p2;
// p1 + p2 ❌ not allowed by default

👉 Operator overloading lets you make this possible.

🧪 Example
class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Point operator +(Point p1, Point p2)
    {
        return new Point(p1.X + p2.X, p1.Y + p2.Y);
    }
}
✅ Usage:
Point p1 = new Point(1, 2);
Point p2 = new Point(3, 4);

Point result = p1 + p2; // works now!
⚠️ Rules (Important)
Must be:
public static
At least one parameter must be the containing type
You cannot create new operators, only overload existing ones
🔥 Common Operators You Can Overload
Arithmetic: + - * / %
Comparison: == != > < >= <=
Unary: ++ -- !
Others: true, false
⚠️ Special Note (Important)

If you overload:

== 

👉 You must also overload:

!=
🧠 When to use it

Use operator overloading when it makes code:

more readable ✔
more natural ✔

👉 Example:

Math objects (Vector, Complex)
Money, Distance, Time
❌ When NOT to use it

If it makes behavior confusing:

user1 + user2 // ❌ unclear meaning
🎯 Interview Tip

“Operator overloading improves readability when the operator meaning is intuitive and consistent with its natural behavior.”
 */
