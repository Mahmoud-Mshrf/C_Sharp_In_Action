using System.Diagnostics.CodeAnalysis;

namespace Test_in_basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Q1 
            // it will print 3 because the evaluation of the right side [x/3] done before assignment and its value will be equal 3 then y eqaul 3 
            // Q2
            //double x = 10.5;
            //int y =(int) x; // explicit casting
            //y = Convert.ToInt32(x);// using convert class
            // Q3
            object obj = "100";
            // int x = (int)obj;// this leads to invalidCastException because explicit casting doesn't ok when converting from string(object) to int 
            // the right way using convert class
            int x = Convert.ToInt32(obj);
            Console.WriteLine(x);
            // Q4
            // the last index in arr array is arr[2] not arr[3]
            // Q5
            int[] ints = new int[5] { 5, 5, 5, 5, 5 };
            var sum = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                sum += ints[i];
            }
            Console.WriteLine(sum);
            // Q6
            int[] a = { 1, 2, 3 };
            int[] b = a;
            b[0] = 100;
            // the value of a also changes because b = a makes b points to the same place in the heap that a reference to , so any change in one of them effects the another 
            // Q7
            // const fields must have value 
            // Q8 look Person.cs
            // Q9
            // public int Age { get; set; } : is a property that do more than the traditional field , it's promote encapsulation so i can validate the age, ensure valid value , specify who can access or edit it
            // public int Age; : is a field just used for store the value of age
            // Q10
            // it will print from 0 to 2
            // Q11
            var counter = 1;
            while (counter <= 5)
            {
                Console.WriteLine(counter);
                counter++;
            }
            // Q12
            // return compile errors because the keyword break doesn't exist in the three cases
            // Q13
            // Constructor must have NO return type
            // Q14
            // Q15 : Indexer allows an object to be accessed like an array using [] notation
        }
    }
    // Q14
    class Employee
    {
        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age {  get; set; }
    }
    // Q16
    class Test
    {
        int[] arr = new int[5];

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();

                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();

                arr[index] = value;
            }
        }
    }

}
/*
 C# Entry Level Test
🎯 Level 1 – Variables & Casting
Q1
    What will be the output?
    int x = 10;
    double y = x / 3;
    Console.WriteLine(y);
    👉 Explain why
    
Q2
    Fix the problem:
    double x = 10.5;
    int y = x;
    👉 What are the 2 correct ways?

Q3 (Tricky)
    What will happen?
    object obj = "100";
    int x = (int)obj;
    👉 Explain + fix it


🧪 Level 2 – Arrays
Q4
    What is wrong here?
    int[] arr = new int[3];
    arr[0] = 10;
    arr[1] = 20;
    arr[3] = 30;

Q5
    Write code to:
    👉 Calculate sum of array using for

Q6 (Tricky)
    Difference between:
    int[] a = {1,2,3};
    int[] b = a;
    b[0] = 100;
    👉 What happens to a and why?


🧪 Level 3 – Fields, Constants, Properties
Q7
    What is wrong here?
    class Test
    {
        public const int x;
    }

Q8
    Convert this field into a property:
    
    public int Age;
    
    👉 With validation: Age must be > 0

Q9 (Important)
    
    What is the difference between:
    public int Age { get; set; }
    and
    public int Age;


🧪 Level 4 – Control Flow
Q10    
    What will be printed?
    
    for (int i = 0; i < 3; i++)
    {
        Console.Write(i);
    }

Q11
    Convert this to while:
    for (int i = 1; i <= 5; i++)
        Console.WriteLine(i);

Q12 (Tricky switch)
    What will happen?
    int x = 2;
    switch (x)
    {
        case 1:
            Console.WriteLine("One");
        case 2:
            Console.WriteLine("Two");
        default:
            Console.WriteLine("Default");
    }


🧪 Level 5 – Constructors
Q13
    What is wrong?
    class Test
    {
        public void Test()
        {
            Console.WriteLine("Hello");
        }
    }

Q14
Create a constructor that initializes:
Name, Age

🧪 Level 6 – Indexers (🔥 Important)
Q15
    What is an indexer?

Q16
    Fix this:
    class Test
    {
        int[] arr = new int[5];
    
        public int this[int index]
        {
            get { return arr[index]; }
        }
    }
    👉 Make it support set

 */
