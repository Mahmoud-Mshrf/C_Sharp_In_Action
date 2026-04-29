namespace FinalTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(2, 3));
            Console.WriteLine(Addd(4, 3));
        }
        static Func<int,int,int> Add =( x , y) => x + y;
        static int Addd(int x , int y )=> x + y;
    }
}
/*
 🎯 Level 1 – Delegates Basics
Q1
What is a delegate?
Answer:
    -- delegate is reference to method(actually list of methods) work like a pointer so this function can be passed as a parameter and reused in different places 
    -- delegate allow passing the method as parameter without knowing what this method do and when to use just know its parameter and its return type
👉 Answer in 1–2 lines (interview style)

Q2

What will this print?

delegate int Calc(int a, int b);

class Program
{
    static int Add(int x, int y) => x + y;

    static void Main()
    {
        Calc c = Add;
        Console.WriteLine(c(2, 3));
    }
}

👉 Explain what’s happening
Answer:
    -- it will print 5 because we assign Add method to delegate calc so calling it internally calss Add method which return the sum of the two numbers passed to it
    
Q3

What is wrong here?

delegate void Print(string msg);

Print p = (int x) => Console.WriteLine(x);
Answer:
    -- the signature of the method that passed to the print delegate doesn't match , the print delegate takes one parametr its type is string and the method passed to it takes one parameter its type is int and this will give compiler error
🎯 Level 2 – Multicast Delegates
Q4

What will be the output?

delegate void Notify();

class Program
{
    static void A() => Console.Write("A");
    static void B() => Console.Write("B");

    static void Main()
    {
        Notify n = A;
        n += B;
        n();
    }
}
Answer:
    -- it will print :
    A
    B
    -- because it execute functions inside it in based on the order of subscribtion then calling it internally calls A() then calls B()
Q5 (Tricky 🔥)

What happens here?

delegate int Calc(int x);

class Program
{
    static int A(int x) => x + 1;
    static int B(int x) => x * 2;

    static void Main()
    {
        Calc c = A;
        c += B;

        int result = c(5);
        Console.WriteLine(result);
    }
}

👉 What is printed and why?
Answer:
    -- result will be equal to 10 because the delegate internally calls the two methods in order of subscribtion but only the last return value is kept

🎯 Level 3 – Lambda Expressions
Q6

Rewrite using lambda:

int Add(int x, int y)
{
    return x + y;
}
Answer:
    -- int Add (intx , int y) => x + y ;
Q7

What does this mean?

Func<int, int, int> f = (a, b) => a * b;
Answer:
    -- its a generic delegate Func represents a pointer for list of methods that return type is int and take two parameters of type int and it assigned to function f that return the multiply of the two int number 

Q8 (Important)

Difference between:

Func<int>

and

Action
Answer:
    -- Func<int> is a generice delegate that doens't take any parameters and its return type is int
    -- Action is a generic delegate that doesn't take any parameters and its return type is void
🎯 Level 4 – Events
Q9

What is an event in C#?
Answer:
    -- An event is a wrapper around a delegate that provides a controlled way to subscribe, unsubscribe, and notify listeners when something happens.
Q10

Why don’t we expose delegates directly and use event instead?
Answer:
    --Because event enforces encapsulation—it prevents external code from invoking or overwriting the delegate, allowing only subscription (+=) and unsubscription (-=).
🎯 Level 5 – EventHandler Pattern 🔥
Q11

What is:
EventHandler
    -- EventHandler is a built-in delegate in .NET that represents a method with the standard event signature
    void Handler(object sender, EventArgs e)
    -- The EventHandler<T> pattern is the standard in .NET because it enforces consistency, type safety, and clear separation between sender and event data.
Q12

What is:

EventArgs
Answer:
    -- EventArgs is the base class used to pass data with events. It represents event data and can be extended to carry custom information.
Q13 (Critical 🔥)

Why do we use:
EventHandler<TEventArgs>
instead of normal delegates?
Answer:
    -- Because it provides a strongly-typed way to pass custom event data, improving type safety and making event handling clearer and more maintainable.
🎯 Level 6 – Real Scenario
Q14

Explain what happens here:
class Button
{
    public event EventHandler Click;

    public void OnClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}

👉 Explain:
this
EventArgs.Empty
?.Invoke 
Answer:
    -- this referes to the object that fires the event in this case it will be Button object
    -- EventArgs.Empty means that no data sent with this event , this event carrying no data with it
    -- ?.Invoke means that if there are subscribers on this event invoke it if there are no subscribers don't make anything , it ckecks if event not equal null
 */
