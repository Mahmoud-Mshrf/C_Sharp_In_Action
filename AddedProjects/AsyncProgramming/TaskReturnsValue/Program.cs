namespace TaskReturnsValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(() => GetCurrentDateTime());
            // Task<DateTime> task = Task.Run(GetCurrentDateTime); // This is also valid
            Console.WriteLine(task.Result);// Result is a blocking call, it will block the thread until the task is finished
            Console.WriteLine(task.GetAwaiter().GetResult());// GetAwaiter().GetResult() is also a blocking call

            Console.ReadLine();
        }
        static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
