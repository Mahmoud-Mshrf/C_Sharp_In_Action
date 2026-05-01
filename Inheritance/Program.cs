using System.Xml.Linq;

namespace Inheritance
{
    // Inheritance—A class can inherit from another class and take advantage of the attributes and methods defined by the superclass.
    //**************************************
    // Inheritance allows a class to reuse and extend the behavior of another class.
    // In C#, you use the : symbol to inherit from a base class. The derived class gets all accessible members of the base class and can add new functionality or modify existing behavior.
    // This promotes code reuse and reduces duplication. You can also use protected members to allow derived classes to access certain internal details of the base class.
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee();
            emp.BirthDate = new DateOnly(2000, 01, 01);
            Console.WriteLine(emp.BirthDate);
            emp.SetName("Mahmoud", "Mshrf");
            PrintPersonDetails(emp);
            Console.WriteLine();
            ////////////////////////////////
            var applicant = new Applicant();
            applicant.SetName("Ahmed", "Mshrf");
            applicant.BirthDate = new DateOnly(2005, 01, 01);
            PrintPersonDetails(applicant);

        }
        public static void PrintPersonDetails(Person person)
        {
            Console.WriteLine($"Name : {person.FirstName} {person.LastName} \tBirthDate : {person.BirthDate}");
        }
    }
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private DateOnly _BirthDate;
        public DateOnly BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if (value < new DateOnly(1970, 1, 1))
                    throw new ArgumentException("Invalid BirthDate");
                _BirthDate = value;
            }
        }
        public void SetName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Invalid Name");
            FirstName = firstName;
            LastName = lastName;
        }
        
    }
    public class Employee : Person
    {
        // we apply encapsulation in employee class to protect BasicSalary and TaxPercintage from being invalid state
        private decimal basicSalary;
        private int taxPercentage;
        
        public decimal BasicSalary { get => basicSalary; set 
            {
                if (value < 1000)
                    throw new ArgumentException("Invalid Basic Salary");
                basicSalary = value;
            } }
        public int TaxPercentage { get => taxPercentage; set 
            {
                if(value > 20)
                    throw new ArgumentException("Invalid Tax Percentage , must be less than 20%");
                taxPercentage = value; 
            } }
    }
    public class Applicant : Person
    {

    }
}
