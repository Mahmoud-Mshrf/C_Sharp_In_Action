namespace _01_Enumerators_Iterators
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        /*
         public override int GetHashCode()
        {
            var hash = 17;
            hash = (hash * 23) + Id.GetHashCode();
            hash = (hash * 23) + Name.GetHashCode();
            hash = (hash * 23) + Salary.GetHashCode();
            hash = (hash * 23) + Department.GetHashCode();
            return hash;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Employee)) return false;
            var emp = (Employee)obj;

            return emp.Id == this.Id
                && emp.Name == this.Name
                && emp.Salary == this.Salary
                && emp.Department == this.Department;

        }
        public static bool operator ==(Employee a, Employee b) { return a.Equals(b); }
        public static bool operator !=(Employee a, Employee b) { return !a.Equals(b); } 
        */


        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Salary,Department);// Handle null safety and better distribution
        }
        public override bool Equals(object? obj)
        {
            if(obj is not Employee emp) return false; // cleaner and safer 

            return Id == emp.Id
                && Name == emp.Name
                && Salary == emp.Salary
                && Department == emp.Department;
        }
        public static bool operator == (Employee left, Employee right)
        {
            if(ReferenceEquals(left, right)) return true;// if both null or same reference
            if(left is null || right is null ) return false;
            return left.Equals(right);
        }
        public static bool operator != (Employee left, Employee right) => !(left == right);
    }
}
