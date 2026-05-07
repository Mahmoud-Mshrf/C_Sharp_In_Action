namespace OverrideToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "John";
            person.Age = 30;
            Console.WriteLine(person);
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
