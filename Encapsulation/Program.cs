using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Encapsulation
{
    // Encapsulation : refers to the concept of protecting all the internal mechanics of a program in order to shield the information from unwanted access or being invalid state (has wrong logically value)
    // Getters and setters support concept of data hiding from an authorized access(encapsulation) : Because other objects should not directly manipulate data within another object 
    // the getters and setters provide controlled access to an object’s data.Getters and setters are sometimes called accessor methods and mutator methods, respectively.
    /**************************************/
    // Encapsulation means hiding internal data and exposing only what’s necessary.
    // In C#, this is achieved using access modifiers (private, public, protected) and properties.
    // Instead of allowing direct access to fields, you wrap them in properties to control reading/writing and enforce validation.
    // This protects your object’s state and prevents invalid data.
    // For example, making a field private and exposing it via a public property ensures that any assignment can be validated before being accepted.

    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee();
            emp.BirthDate = new DateOnly(2000, 01, 01);
            Console.WriteLine(emp.BirthDate);
            emp.SetName("Mahmoud", "Mshrf");
            Console.WriteLine(emp.FirstName);
            Console.WriteLine(emp.LastName);
        }

    }
    public class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private DateOnly _BirthDate;
        public DateOnly BirthDate {
            get { return _BirthDate; }
            set 
            {
                if (value < new DateOnly(1970, 1, 1))
                    throw new ArgumentException("Invalid BirthDate");
                _BirthDate = value;
            } }
        public decimal BasicSalary { get; set; }
        public int TaxPercentage { get; set; }
        public void SetName(string firstName ,string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Invalid Name");
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
