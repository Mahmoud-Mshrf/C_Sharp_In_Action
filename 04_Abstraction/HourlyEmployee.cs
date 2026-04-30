using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Abstraction
{
    internal class HourlyEmployee:Employee
    {
        public decimal HourRate { get; set; }
        public int TotalWorkingHours { get; set; }

        public override IEnumerable<PayItem> GetPayItems()
        {
            return new[] { new PayItem("Total Hours",GetSalary())  };
        }

        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return HourRate * TotalWorkingHours;
        }
    }
}
