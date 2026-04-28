using System.Collections.Generic;
namespace Delegates
{
    // Delegate is a type that represents a reference to a method, allows you to store method and call it , allows method to be treated like data
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = new List<Employee> {new Employee { Name = "Mahmoud", TotalSales = 20000.00m },
                                                                  new Employee { Name = "Mohamed", TotalSales = 30000.00m },
                                                                  new Employee { Name = "Hossam", TotalSales = 40000.00m },
                                                                  new Employee { Name = "Amr", TotalSales = 50000.00m },};

            ShowData(employees,"Employees have achieved more than 30000$ : ",(Employee e) => e.TotalSales > 30000);
        }
        static void ShowData(IEnumerable<Employee> employees,string title,Criteria criteria)
        {
            Console.WriteLine(title);
            foreach(Employee employee in employees)
            {
                if(criteria(employee))
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public delegate bool Criteria(Employee e);
    }
}
