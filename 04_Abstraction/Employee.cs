namespace _04_Abstraction
{
    public abstract class Employee : Person
    {
        public string Email { get; internal set; }

        public abstract decimal GetSalary();
        public abstract IEnumerable<PayItem> GetPayItems();
    }

}
