using static PassionateCodersProject.Program;

namespace PassionateCodersProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new ();
            for (int i = 0; i < 100; i++)
            {
                list.Add (new Employee
                {
                    Name = $"Employee #{i}",
                    BasicSalary = Random.Shared.Next (1000, 5001),
                    Deductions= Random.Shared.Next (0, 501),
                    Bonus = Random.Shared.Next (0, 1001),
                });
            }
            var calculator = new SalaryCalculator();
            calculator.CalculateSalary(list,(Employee e) => e.BasicSalary>2000);
        }
    }
}
