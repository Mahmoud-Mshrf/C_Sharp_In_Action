using System.Runtime.InteropServices;

namespace GenericDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = new List<Employee> {new Employee { Name = "Mahmoud", TotalSales = 20000.00m },
                                                                  new Employee { Name = "Mohamed", TotalSales = 30000.00m },
                                                                  new Employee { Name = "Hossam", TotalSales = 40000.00m },
                                                                  new Employee { Name = "Amr", TotalSales = 50000.00m },};
            var num = 30000;
            ShowData2(employees, () => Console.WriteLine($"Employees whit total sales more than {num}"),(Employee e) => Console.WriteLine(e), (Employee e)=> e.TotalSales>30000);
        }
        // Way 1:
        //static void ShowData1<T>(IEnumerable<T> List,Action action,Predicate<T> predicate)
        //{
        //    action();
        //    foreach (var item in List)
        //    {
        //        if (predicate(item))
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }
        //}
        static void ShowData2<T>(IEnumerable<T> values,Action title, Action<T> action, Func<T, bool> predicate)
        {
            title();
            foreach (var item in values)
            {
                if (predicate(item))
                {
                    action(item);
                }
            }
        }
        // there are three types of the generic delegates in Microsoft .net core :
        // Action<> this delegate take as parameters 16 parameter there datatypes may vary, Enable me to take Functions that haven't return type as a parameter and i put it where i want 
        // Func<> this delegate take as parameters 17 parameter there datatypes may vary and one of them represent the return datatype, enable me to aplly somethings on elements there datatypes may vary 
        // Predicate<> can take one parameter, check if a condition or criteria is satisfied and return datatype is bool  
        // func<T, bool>  And  Predicate<T>  are equals

    }
}
