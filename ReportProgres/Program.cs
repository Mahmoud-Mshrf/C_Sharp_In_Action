namespace ReportProgres
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Copy((i) => { Console.Clear(); Console.WriteLine($"Progress: {i}%"); });
            Console.ReadKey();
        }
        static async Task Copy(Action<int> Progress)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Task.Delay(50).Wait();// simulate delay
                    if (i % 10 == 0)
                        Progress(i);
                }
            });

        }
    }
}
