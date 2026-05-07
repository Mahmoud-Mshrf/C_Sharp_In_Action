using System.Reflection;

namespace DemoLib
{
    public static class Demo
    {
        public static void Trace()
        {
            Console.WriteLine("Tracing.....");
            Console.WriteLine($"Excuting Assembly : {Assembly.GetExecutingAssembly().FullName}");
            Console.WriteLine($"Entry Assembly : {Assembly.GetEntryAssembly().FullName}");
            Console.WriteLine($"Calling Assembly : {Assembly.GetCallingAssembly().FullName}");
        }
    }
}
