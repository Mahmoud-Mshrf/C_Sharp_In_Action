using static System.Net.Mime.MediaTypeNames;
// Abstraction refers to the concept of representing only the necessary features by hiding the irrelevant details to reduce complexity of an application thereby increasing efficiency.
// hiding implementation details from the client it just know how to use it but doesn't know how it implemented 
// abstraction applied using : abstarct class , interface , and encapsulation bassicaly support abstraction by using access modifiers 
// abstraction means to reduce the details that classes or system parts knows about each other 
// 
namespace _04_Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var salEmp = new SalariedEmployee();
            salEmp.SetName("Mahmoud", "Mogahed");
            salEmp.BasicSalary = 3000;
            salEmp.Transportation = 500;
            salEmp.Housing = 200;
            salEmp.Email = "MahmoudMogahed@example.com";
            Console.WriteLine($"{salEmp.FirstName} ({typeof(SalariedEmployee).Name}) , salary = {salEmp.GetSalary()}");
            var TaxPercentage = 10;
            var bonus = 200;
            Console.WriteLine($"{salEmp.FirstName} ({typeof(SalariedEmployee).Name}) with ({TaxPercentage} % tax) , salary = {salEmp.GetSalary(TaxPercentage)}");
            Console.WriteLine($"{salEmp.FirstName} ({typeof(SalariedEmployee).Name}) with ({TaxPercentage} % tax and {bonus} bonus) , salary = {salEmp.GetSalary(TaxPercentage, bonus)}");
            Console.WriteLine();
            ////////////////////////////////
            var internEmp = new InternEmployee();
            internEmp.SetName("Mohamed", "Mogahed");
            internEmp.Email = "MohamedMogahed@example.com";
            Console.WriteLine($"{internEmp.FirstName} ({typeof(InternEmployee).Name}) , salary = {internEmp.GetSalary()}");
            Console.WriteLine();
            ////////////////////////////////
            var hourlyEmployee = new HourlyEmployee();
            hourlyEmployee.SetName("Ali", "Mogahed");
            hourlyEmployee.HourRate = 18;
            hourlyEmployee.TotalWorkingHours = 170;
            hourlyEmployee.Email = "AliMogahed@example.com";
            Console.WriteLine($"{hourlyEmployee.FirstName} ({typeof(HourlyEmployee).Name}) , salary = {hourlyEmployee.GetSalary()}");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();
            var notifier = new Notifier("gmail.com", 23, "noreplay@gmail.com","ABC@123");
            var payslipGenerator = new PayslipGenerator(notifier);
            payslipGenerator.Generate(salEmp);
            payslipGenerator.Generate(hourlyEmployee);
            payslipGenerator.Generate(internEmp);

        }
    }
}
