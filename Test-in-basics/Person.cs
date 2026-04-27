namespace Test_in_basics
{
    // Q8
    class Person 
    {
        // way 1:
        public Person()
        {
            
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("invalid value (age must be more than 0)");
                age = value;
            }
        }

        //////////////////////////////////////////////////////
        // way 2:
        //public Person(int age)
        //{
        //    SetAge(age);
        //}
        //public int Age { get; private set; }


        //public void SetAge(int age)
        //{
        //    if(age <= 0)
        //        throw new ArgumentException("invalid value (age must be more than 0)");
        //    Age = age;
        //}

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
