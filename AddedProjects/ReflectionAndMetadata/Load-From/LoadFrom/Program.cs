namespace LoadFrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the LoadFromLib class library assume that i have deleted the reference to it and i want to load it at runtime using the LoadFrom method of the Assembly class
            // so i put the LoadFromLib.dll in the output folder of the LoadFrom project and then i can load it at runtime using the following code
            var path = @"C:\Users\Mahmoud-PC\source\repos\Mahmoud-Mshrf\CSharp_Reference\LoadFrom\LoadFromLib.dll";
            var assembly = System.Reflection.Assembly.LoadFrom(path);
            Type[] type = assembly.GetTypes();
            foreach (Type t in type)
            {
                Console.WriteLine(t.FullName);
            }
        }
    }
}
