
namespace AsyncFunctionExamble
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(await ReadContentAsync("https://www.google.com"));// 
            
        }
        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();
            var task =  client.GetStringAsync(url);
            DoSomething();
            var content = await task;
            return content;
        }

        private static void DoSomething()
        {
            Console.WriteLine("Do something");
        }
    }
}
