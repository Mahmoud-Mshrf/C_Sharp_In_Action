namespace FinalExample
{
    // Usage
    class Program
    {
        static void Main()
        {
            Employee e1 = new Manager { Name = "Mahmoud", Salary = 10000 };
            Employee e2 = new Developer { Name = "Ali", Salary = 8000 };

            Console.WriteLine($"{e1.Name} Bonus: {e1.CalculateBonus()}");
            Console.WriteLine($"{e2.Name} Bonus: {e2.CalculateBonus()}");
        }
    }

    // Abstraction
    public abstract class Employee
    {
        // Encapsulation
        private decimal salary;

        public decimal Salary
        {
            get => salary;
            set
            {
                if (value >= 0)
                    salary = value;
            }
        }

        public string Name { get; set; }

        // Polymorphism (virtual method)
        public abstract decimal CalculateBonus();
    }

    // Inheritance + Polymorphism
    public class Manager : Employee
    {
        public override decimal CalculateBonus()
        {
            return Salary * 0.2m;
        }
    }

    public class Developer : Employee
    {
        public override decimal CalculateBonus()
        {
            return Salary * 0.1m;
        }
    }
    /*
     Encapsulation → Salary is protected via property validation
     Abstraction → Employee defines a contract (CalculateBonus)
     Inheritance → Manager and Developer reuse Employee
     Polymorphism → CalculateBonus() behaves differently per type
     */
    /*
     Encapsulation = protect data
     Abstraction   = hide complexity
     Inheritance   = reuse code
     Polymorphism  = same call, different behavior
     */

}
