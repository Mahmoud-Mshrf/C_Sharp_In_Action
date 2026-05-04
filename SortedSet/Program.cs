namespace SortedSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>  {
                                     new Customer("aya", "011"),
                                     new Customer("Mohamed", "01143128894"),
                                     new Customer("Mshrf", "011"),
                                     new Customer("abo Mogahed", "01d1"),
                                     new Customer("hossam", "011"),
                                     new Customer("ali", "011")
                                    };
            Console.WriteLine("Sorted Set");
            Console.WriteLine();
            var sortedCustomersSet = new SortedSet<Customer>(customers);
            foreach (var item in sortedCustomersSet)
            {
                Console.WriteLine(item);
            }

        }
        public class Customer : IComparable<Customer>
        {
            public Customer(string name, string telephone)
            {
                Name = name;
                Telephone = telephone;
            }

            public string Name { get; set; }
            public string Telephone { get; set; }

            public override int GetHashCode()
            {
                var hash = 17;
                hash = hash * 23 + Telephone.GetHashCode();
                return hash;
            }
            public override bool Equals(object? obj)
            {
                var other = obj as Customer;
                if (other == null) return false;

                return this.Telephone.Equals(other.Telephone);

            }
            public override string ToString()
            {
                return $"{Name}  ({Telephone})";
            }

            public int CompareTo(Customer? other)
            {
                if (object.ReferenceEquals(this, other)) return 0;
                if (other == null) return -1;
                return this.Name.CompareTo(other.Name);// this will sort the elements in the sortedset by the name of the customer alphabetically
            }
        }
    }
}