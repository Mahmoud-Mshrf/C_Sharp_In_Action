namespace HashCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee { Id = 1, Name = "Ahmed" };
            Employee e2 = new Employee { Id = 1, Name = "Ahmed" };
            Console.WriteLine(e1.Equals(e2)); // False because the class is reference type and the reference of e1 and e2 are different so we must override the Equals method to compare the values of the objects
            Console.WriteLine(e1.GetHashCode());// here we get the hash code of the object e1
            Console.WriteLine(e2.GetHashCode());// here we get the hash code of the object e2
            Console.WriteLine(e1.GetHashCode() == e2.GetHashCode()); // False because the hash code of the object e1 and e2 are different so we must override the GetHashCode method to compare the values of the objects
            Console.WriteLine("-------------------------------------------------");
            Customer c1 = new Customer { Id = 1, Name = "Ahmed" };
            Customer c2 = new Customer { Id = 1, Name = "Ahmed" };
            Console.WriteLine(c1.Equals(c2)); // True because the struct is value type and the value of c1 and c2 are the same
            Console.WriteLine(c1.GetHashCode());// here we get the hash code of the object c1
            Console.WriteLine(c2.GetHashCode());// here we get the hash code of the object c2
            Console.WriteLine(c1.GetHashCode() == c2.GetHashCode()); // True because the hash code of the object c1 and c2 are the same because the struct is value type and the value of c1 and c2 are the same
        }
    }
    class Employee 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    struct Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
