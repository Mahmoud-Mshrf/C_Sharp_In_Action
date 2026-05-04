namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var article = "Dot Net is a free cross-platform and open source developer platform " +
                          "for building many different types of applications " +
                          "With Dot Net you can use multiple languages and libraries " +
                          "to build for Web and IoT ";
            // here we make a dictionary that define each letter and the words that contain it
            Dictionary<char, List<string>> lettersDictionary = new Dictionary<char, List<string>>();
            foreach (var word in article.Split())
            {
                foreach (var ch in word)
                {
                    char c = char.ToLower(ch);
                    if (!lettersDictionary.ContainsKey(c))
                    {
                        lettersDictionary.Add(c, new List<string> { word });
                    }
                    else
                    {
                        lettersDictionary[c].Add(word);
                    }
                }
            }
            foreach (var entry in lettersDictionary)
            {
                Console.Write($"'{entry.Key}':");
                foreach (var word in entry.Value)
                {
                    Console.WriteLine($"\t\t \"{word}\"");
                }
                Console.WriteLine();
            }
            Employee[] employees = { new Employee {Id =1, Name="Mahmoud",ReportTo =null },
                                     new Employee {Id =2, Name="Mshrf",ReportTo =1 },
                                     new Employee {Id =3, Name="Mogahed",ReportTo =1 },
                                     new Employee {Id =4, Name="Mohamed",ReportTo =2 },
                                     new Employee {Id =5, Name="Hossam",ReportTo =2 },
                                     new Employee {Id =6, Name="Badawy",ReportTo =3 }
                                   };
            var groupbyManagers = employees.GroupBy(x => x.ReportTo);
            var managers = groupbyManagers.ToDictionary(x => x.Key ?? -1, x => x.ToList());
            //var managers = employees.ToLookup(x => x.ReportTo).ToDictionary(x => x.Key ?? -1, x => x.ToList());
            foreach (var manager in managers)
            {
                if (manager.Key == -1)
                    continue;
                Console.WriteLine(manager.Key);
                foreach (var emp in manager.Value)
                {
                    Console.WriteLine(emp);
                }
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ReportTo { get; set; }// ? make it nullable
        public override string ToString()
        {
            return $"Employee Name:{Name}, Employee Id:{Id} ";
        }
    }
}
