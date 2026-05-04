namespace Lists
{
    // Here we learn more about List<>

    internal class Program
    {
        static void Main(string[] args)
        {
            Country[] countriesArray1 = { new Country { IsoCode = "EGY", Name = "Egypt" },
                                       new Country { IsoCode = "IRQ", Name = "Iraq" },
                                       new Country { IsoCode = "JOR", Name = "Jordan" } };
            Country[] countriesArray2 = { new Country { IsoCode = "KSA", Name = "Saudi Arabia" },
                                       new Country { IsoCode = "ARG", Name = "Argentina" },
                                       new Country { IsoCode = "POR", Name = "Portugal" } };
            Country country1 = new Country { IsoCode = "UAE", Name = "Emirates" };
            Country country2 = new Country { IsoCode = "US", Name = "United States" };
            Country country3 = new Country { IsoCode = "UK", Name = "England" };
            // constructors
            List<Country> countries = new List<Country>(5)
            {
                country1
            };
            // List<Country> countries = new List<Country>();// here this constructor will set the initial capacity of this list automatically 
            // List<Country> countries = new List<Country>(3); // here this constructor will set the initial capcity of this list equal 3 and it will doubled if there are need
            // List<Country> countries = new List<Country>(countiesArray1);// here this constructor will set the initial capcity of this list equal to number of items in the assigned array and it will doubled if there are need
            // Methods
            countries.AddRange(countriesArray1);// here we add a range of items to the end of the list
            countries.Add(country2);// here we add an item to the end of the list
            countries.Insert(0, country3);// here we insert an item to the list at the given index, this is a costly operation
            countries.InsertRange(0, countriesArray2);// here we insert a range of items to the list it will be inserted at the given index and the items will be inserted in the same order as they are in the array, this is a costly operation
            foreach (Country country in countries)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine("///////");
            countries.Remove(country3);
            foreach (Country country in countries)
            {
                Console.WriteLine(country);
            }
            countries.RemoveAt(2);
            countries.RemoveRange(1, 4);
            countries.RemoveAll(x => x.IsoCode == "");// here will remove all countries that isocode equal to the given value
            countries.RemoveAll(x => x.Name.EndsWith("a"));// will remove all countries that its name endswith a
            // this item will not remove becuase we must override GetHashCode and Equals methods
            countries.Remove(new Country { IsoCode = "IRQ", Name = "Iraq" });// after we override GetHashCode and Equals, this method will remove the passed item to it from the list
            Console.WriteLine(countries.Count);// the current number of items in the list 
            Console.WriteLine(countries.Capacity);// capacity represent the current capacity of this list that always bigger than or equal to the list.count and the capacity will extend automatically to fit list elements need
            countries.Clear();// this method will remove all items from the list
            countries.TrimExcess();// this method will set the capacity of the list equal to the number of items in the list
            countries.Contains(country1);// this method will return true if the list contains the passed item to it

        }
    }
    public class Country
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public override bool Equals(object? obj)
        {
            var country = obj as Country;
            if (country is null) return false;
            return this.Name.Equals(country.Name, StringComparison.OrdinalIgnoreCase)
                && this.IsoCode.Equals(country.IsoCode, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + IsoCode.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return $"{IsoCode}:({Name})";
        }
    }
}