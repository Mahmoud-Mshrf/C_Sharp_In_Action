using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Polymorphism
{
    internal class SalariedEmployee:Employee
    {
        public decimal BasicSalary { get; set; }
        public decimal Transportation { get; set; }
        public decimal Housing { get; set; }

        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return BasicSalary + Transportation + Housing;
        }

        public decimal GetSalary(int taxPercentage)
        {
            return GetSalary() - (BasicSalary * taxPercentage / 100);
        }

        public decimal GetSalary(int taxPercentage,int bonus)
        {
            return GetSalary(taxPercentage) + bonus;
        }
    }
}
