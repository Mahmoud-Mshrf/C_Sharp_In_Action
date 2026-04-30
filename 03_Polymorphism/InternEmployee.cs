using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Polymorphism
{
    internal class InternEmployee:Employee
    {
        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return 2000;
        }
    }
}
