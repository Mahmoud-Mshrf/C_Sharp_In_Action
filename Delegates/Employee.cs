namespace Delegates
{
    internal class Employee
    {
        public string Name { get; set; }
        public decimal TotalSales { get; set; }

        public override string ToString()
        {
            return $"\t{Name} Achieved : {TotalSales}$ ";
        }
    }
}