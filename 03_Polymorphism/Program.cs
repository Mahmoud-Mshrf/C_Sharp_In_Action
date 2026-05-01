namespace _03_Polymorphism
{
    // Polymorphism is a Greek word that literally means many shapes. Although polymorphism is tightly coupled to inheritance, it is often cited separately as one of the most powerful advantages to object-oriented technologies.
    //**************************************************//
    //Polymorphism means one interface, multiple implementations.
    //In C#, it appears in two main forms: method overriding (runtime polymorphism) and method overloading (compile-time polymorphism).
    //With overriding, a derived class provides a specific implementation of a virtual method from the base class using override.
    //This allows you to treat different objects uniformly while each behaves differently depending on its actual type.
    internal class Program
    {
        static void Main(string[] args)
        {
            var salEmp = new SalariedEmployee();
            salEmp.SetName("Mahmoud", "Mogahed");
            salEmp.BasicSalary = 3000;
            salEmp.Transportation = 500;
            salEmp.Housing = 200;
            Console.WriteLine($"{salEmp.FirstName} ({typeof(SalariedEmployee).Name}) , salary = {salEmp.GetSalary()}");
            var TaxPercentage = 10;
            var bonus = 200;
            Console.WriteLine($"{salEmp.FirstName} ({typeof(SalariedEmployee).Name}) with ({TaxPercentage} % tax) , salary = {salEmp.GetSalary(TaxPercentage)}");
            Console.WriteLine($"{salEmp.FirstName} ({typeof(SalariedEmployee).Name}) with ({TaxPercentage} % tax and {bonus} bonus) , salary = {salEmp.GetSalary(TaxPercentage,bonus)}");
            Console.WriteLine();
            ////////////////////////////////
            var internEmp = new InternEmployee();
            internEmp.SetName("Mohamed", "Mogahed");
            Console.WriteLine($"{internEmp.FirstName} ({typeof(InternEmployee).Name}) , salary = {internEmp.GetSalary()}");
            Console.WriteLine();
            ////////////////////////////////
            var hourlyEmployee = new HourlyEmployee();
            hourlyEmployee.SetName("Ali", "Mogahed");
            hourlyEmployee.HourRate = 18;
            hourlyEmployee.TotalWorkingHours = 170;
            Console.WriteLine($"{hourlyEmployee.FirstName} ({typeof(HourlyEmployee).Name}) , salary = {hourlyEmployee.GetSalary()}");
            Console.WriteLine();

        }
        public static void PrintPersonDetails(Person person)
        {
            Console.WriteLine($"Name : {person.FirstName} {person.LastName} \tBirthDate : {person.BirthDate}");
        }
    }
    // polymorphism applied through :
    // Method Overriding : Dynamic polymorphism ( runtime polymorphism)
    // Method Overloading :Static polymorphism ( static polymorphism)

}
