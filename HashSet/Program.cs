namespace HashSets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer("Mahmoud", "011");
            var customer11 = new Customer("Mahmoud", "011");
            var customer2 = new Customer("Mohamed", "01143128894");
            var customer3 = new Customer("Aya", "012");
            Console.WriteLine(customer1.Equals(customer11));// true
            Console.WriteLine(object.ReferenceEquals(customer1, customer11));// false
            var customers = new List<Customer>  {
                                     new Customer("Mahmoud", "011"),
                                     new Customer("Mohamed", "01143128894"),
                                     new Customer("Mahmoud", "011"),
                                     new Customer("Mahmoud", "011"),
                                     new Customer("Mahmoud", "011"),
                                     new Customer("Mahmoud", "011")
                                    };
            Console.WriteLine("HashSet");
            Console.WriteLine("────────");
            var CustomersHashSet = new HashSet<Customer>(customers);// as you see the elements in customers list not all will be added to the hashset because not all are distinct and the distinct values only one will be added, the hashset have only distnict values
            CustomersHashSet.Add(customer1);// this will not be added because it have the same values of an element inside this hashset and the hashset have only distnict values
            foreach (var item in CustomersHashSet)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var customers2 = new List<Customer>  {
                                     new Customer("Mahmoud", "011"),
                                     new Customer("Mohamed", "01143128899"),
            };
            var Customers2Hash = new HashSet<Customer>(customers2);
            Customers2Hash.UnionWith(CustomersHashSet);// as you see this will only add the distinct items to customer2hash
            // there are many methods like union, intersect and many others methods 
            foreach (var item in Customers2Hash)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Customer
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
    }
}