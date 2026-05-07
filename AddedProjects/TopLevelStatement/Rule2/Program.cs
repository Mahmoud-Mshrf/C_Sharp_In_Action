void IsEven(int number)
{
    if (number % 2 == 0)
    {
        Console.WriteLine("The number is even.");
    }
    else
    {
        Console.WriteLine("The number is odd.");
    }
} // it is allowed but it becomes a local function it declared inside the Main method , it can't have access modifier

Console.WriteLine("Hello, World!");

void IsOdd(int number)
{
    if (number % 2 != 0)
    {
        Console.WriteLine("The number is even.");
    }
    else
    {
        Console.WriteLine("The number is odd.");
    }
} // it is allowed but it becomes a local function it declared inside the Main method , it can't have access modifier
