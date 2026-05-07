namespace ReflectionObtainTypeInfo
{
    // Reflection is the ability of a program to examine and manipulate itself at runtime. It lets your code look at its own structure — types, methods, properties, fields — and even invoke them dynamically, without knowing them at compile time.
    // Metadata is the information about the structure of your code that the compiler generates. It includes details about types, members, attributes, and more. This metadata is what reflection uses to inspect and interact with your code at runtime.
    internal class Program
    {
        static void Main(string[] args)
        {
            // Optaining Type Information
            Type t1 = DateTime.Now.GetType(); // at runtime which is means that the type information is obtained during the execution of the program. This allows for dynamic behavior, as you can work with types that may not be known until the program is running.
            Console.WriteLine(t1);
            Type t2 = typeof(DateTime);// at compile time which means that the type information is determined during the compilation of the program. This is more efficient and allows for better performance, as the type information is already known and can be optimized by the compiler.
            Console.WriteLine(t2);
            Console.WriteLine($"FullName: {t1.FullName}");// namespace and class name
            Console.WriteLine($"Namesapce: {t1.Namespace}");// namespace
            Console.WriteLine($"Name : {t1.Name}");// class name
            Console.WriteLine($"BaseType : {t1.BaseType}");// the base class of the type
            Console.WriteLine($"Is Public : {t1.IsPublic}");// whether the type is public or not
            Console.WriteLine($"Assembly : {t1.Assembly}");// the assembly in which the type is defined
            Type t3 = typeof(int[]);// array type
            Console.WriteLine($"t3 Type : {t3.Name}");// the name of the type, which in this case is "Int32[]"

            var nestedTypes = typeof(Employee).GetNestedTypes();
            foreach (var nestedType in nestedTypes)
            {
                Console.WriteLine(nestedType);
            }
            var typeint = typeof(int);
            var Interfaces = typeint.GetInterfaces();
            foreach (var i in Interfaces)
            {
                Console.WriteLine(i);
            }
        }
        public class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public class FullTimeEmployee : Employee
            {
                public decimal Salary { get; set; }
            }
            public class PartTimeEmployee : Employee
            {
                public decimal HourlyRate { get; set; }
            }
        }
    }
}
