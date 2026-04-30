using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Abstraction
{
    public class PayslipGenerator
    {
        // here is abstraction the payslip generator doesn't know how the notification will be sent and if we change the way that we send notifications by it , it will not know anything , payslip generator it just know that he use an object that implement Inotifer interface doesn't know anything else
        public readonly INotifier _notifier;
        public PayslipGenerator(INotifier notifier)
        {
            _notifier = notifier;
        }

        // here is the abstraction the method generate take object from type employee and doesn't know how the method employee.GetPayItems() implemented it just use it without knowing its inner implementation and doesn't know the subclass the inherit from employee it just know that may be employee or one of its subclasses
        public void Generate(Employee employee)
        {
            var payItems = employee.GetPayItems();
            var message = new StringBuilder();
            message.AppendLine($"Dear {employee.FirstName} {employee.LastName},");
            message.AppendLine($"Please find below your payslip details:");
            foreach (var item in payItems)
                message.AppendLine($"{item.Name}\t\t{item.Value}");
            _notifier.Notify(employee.Email, "Payslip Generated !",message.ToString());
        }
    }
}
