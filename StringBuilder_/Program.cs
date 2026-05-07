namespace StringBuilder_
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Mahmoud",
                TotalSales = 25000,
                Department = "Sales"
            },

            new Employee
            {
                Id = 2,
                Name = "Mohamed",
                TotalSales = 42000,
                Department = "Marketing"
            },

            new Employee
            {
                Id = 3,
                Name = "Hossam",
                TotalSales = 31000,
                Department = "Sales"
            }
        };

            string report = GenerateReport(employees);

            Console.WriteLine(report);
        }

        static string GenerateReport(List<Employee> employees)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=================================");
            sb.AppendLine("      EMPLOYEE SALES REPORT      ");
            sb.AppendLine("=================================");
            sb.AppendLine();

            decimal totalCompanySales = 0;

            foreach (var emp in employees)
            {
                sb.AppendLine($"Employee Id   : {emp.Id}");
                sb.AppendLine($"Name          : {emp.Name}");
                sb.AppendLine($"Department    : {emp.Department}");
                sb.AppendLine($"Total Sales   : {emp.TotalSales:C}");
                sb.AppendLine("---------------------------------");

                totalCompanySales += emp.TotalSales;
            }

            sb.AppendLine();
            sb.AppendLine("=================================");
            sb.AppendLine($"Company Total Sales: {totalCompanySales:C}");
            sb.AppendLine("=================================");

            return sb.ToString();
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSales { get; set; }
        public string Department { get; set; }
    }
}
/*
 🔥 Why StringBuilder is Perfect Here

Inside this loop:

foreach (var emp in employees)

we append many lines.

❌ If we used string concatenation
report += $"Employee Id : {emp.Id}\n";

Every iteration would:

1. Create new string
2. Copy old content
3. Add new content
4. Destroy old string later

For huge reports:

VERY expensive
✅ With StringBuilder

Internally:

same character buffer reused

Much more efficient.

🔹 Important Real-World Insight

This pattern is extremely common in:

logging frameworks
ASP.NET HTML rendering
SQL generation
CSV exports
JSON serializers
code generators
🔹 Internal Visualization

Imagine this internally:

Initial
Capacity = 64

[_ _ _ _ _ _ _ _ ...]
After many AppendLine calls
[E m p l o y e e ...]

Same buffer reused repeatedly.

🔹 Optimization Improvement

If you know report may be large:

StringBuilder sb = new StringBuilder(5000);

This avoids multiple internal resizes.

🔥 Very Important Design Lesson

Use:

string → final immutable result
StringBuilder → temporary construction tool

That’s why we finally do:

return sb.ToString();
🧠 Final Mental Model
StringBuilder builds text efficiently,
then produces one final immutable string.
 */
