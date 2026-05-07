using DemoLib;
using System.Reflection;

namespace Assemblies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// to return the name of the current assembly
            //var assembly = Assembly.GetExecutingAssembly();
            //Console.WriteLine(assembly.FullName);
            //// to return the name of the assembly that contains the Employee class
            //var type = typeof(Employee);
            //var assembly2 = type.Assembly;
            //Console.WriteLine(assembly2.FullName);
            Demo.Trace();

            // *********************************** //
            var type = typeof(Program);
            var assembly = type.Assembly;
            // or
            var obj = new Program();
            assembly = obj.GetType().Assembly;
            
            Console.WriteLine($"Assembly Name : {assembly.GetName().Name}");
            Console.WriteLine($"Assembly Version : {assembly.GetName().Version}");
            Console.WriteLine($"Assembly Culture Name : {assembly.GetName().CultureName}");
            Console.WriteLine($"Assembly Public Key Token Length : {assembly.GetName().GetPublicKeyToken().Length}");

            var stream = assembly.GetManifestResourceStream("Assemblies.Countries.json");
            var streamm = assembly.GetManifestResourceStream(type,"Countries.json");
            var data = new StreamReader(stream).ReadToEnd();
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i]);
            }
            Console.ReadKey();

        }
    }
    public class Employee
    {

    }
}
