global using System.Text;// global using directive to avoid writing the using directive in each file , it will be available in all files in the project
using Namespaces.Hr;
using CRAC = Continent.Region.Area.Country;// using alias directive to avoid long namespaces
using EGY = Continent.Region.Area.Country.Egypt;// using alias directive to avoid long namespaces
using static System.Math; // using static directive to avoid writing the class name before the method 
namespace Namespaces
    // namespace role is to organize the code and the classes to avoid naming conflicts and to make the code more readable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();// Hr.OrderS
            var employee = new Employee();// Hr.Employee , here we don't need to write it as Hr.Employee because we have used the using Namespaces.Hr; at the top of the file
            var customer = new Customer();// Hr.Customer, here we don't need to write it as Hr.Customer because we have used the using Namespaces.Hr; at the top of the file
            var employee1 = new Sales.Employee();// Sales.Employee
            var customer1 = new Sales.Customer();// Sales.Customer
            var manager = new Sales.Manager();// Sales.Manager
            // we can use the using alias directive to avoid long namespaces
            var egypt = new CRAC.Egypt(); // Continent.Region.Area.Country.Egypt
            var egypt1 = new EGY(); // Continent.Region.Area.Country.Egypt
            Console.WriteLine(Cos(90));// using static directive to avoid writing the class name before the method

            // each class is in its own namespace to avoid naming conflicts
        }
    }
}
