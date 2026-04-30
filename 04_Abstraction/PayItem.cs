using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Abstraction
{
    // this class is immutable so once its value is initialized can't be changed again 
    public class PayItem
    {
        public PayItem (string name , decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public decimal Value { get; }
    }
}
