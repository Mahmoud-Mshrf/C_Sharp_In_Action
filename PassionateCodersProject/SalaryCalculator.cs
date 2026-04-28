namespace PassionateCodersProject
{
    public class SalaryCalculator
    {
        public delegate bool ShouldCalculate(Employee employee);
        public void CalculateSalary(List<Employee> list, ShouldCalculate predicate)
        {
            foreach (var emp in list)
            {
                var TotalSalary = emp.BasicSalary + emp.Bonus - emp.Deductions;
                Console.WriteLine($"Total salary for employee `{emp.Name}` with basic salary `{emp.BasicSalary}` = {TotalSalary}");
            }
        }
    }
}
