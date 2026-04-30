using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Abstraction
{
    // differences between interface and abstract class :
    // all interface members be public members , abstract class members can have all access modifiers
    // a class can implement multiple interfaces but can inherit from one abstract class
    // interfaces functions can't have implementation , abstract class can have abstract methods(no implementation) and concrete methods(have implementation)
    public interface INotifier
    {
        void Notify(string email,string subject , string body);
    }
}
