using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Abstraction
{
    internal class InternEmployee:Employee
    {
        public override IEnumerable<PayItem> GetPayItems()
        {
            return new[] { new PayItem("Basic Salary ", GetSalary()) };
        }
        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return 2000;
        }
    }
}
