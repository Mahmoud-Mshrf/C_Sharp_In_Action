namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Emp1 = new Employee("Mahmoud", "Mshrf", 20, "Cairo-Egypt", "30207232502396");
            var Emp2 = new Employee("Mahmoud", "Cairo-Egypt", "30207232502396");
            var Emp3 = new Employee { FirstName = "Mohamed", Address = "Cairo-Egypt",Age=22,LastName="Mshrf",NationalId="3000904050239" };
            var test = Test.GetTest("Mahmoud", 20);
        }
    }
    public class Employee
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Address;
        public string NationalId;
        public Employee()
        {
            
        }

        public Employee(string firstName, string lastName, int age, string address, string nationalId)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            NationalId = nationalId;
        }
        public Employee(string firstName,string address, string nationalId):this(firstName,"",20,address,nationalId) {}

    }
    public class Test
    {
        public string Name;
        public int Age;

        private Test(string name, int age)
        {
            Name = name;
            Age = age;
        }
        // called factory method
        public static Test GetTest(string  name,int age)
        {
            return new Test(name, age);
        }
    }
}
