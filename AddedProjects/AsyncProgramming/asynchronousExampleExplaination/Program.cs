namespace asynchronousExampleExplanation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task = Task.Run(() => DoSomething());
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Task completed!");
            });
            Console.WriteLine("Task Task");// this will be printed before the task is completed because the task is running asynchronously so the main thread is not blocked and can continue executing other code while the task is running
        }

        static void DoSomething()
        {
            // simulate some expensive operation
            for (int i = 0; i < 1000; i++)
            {
                var x = Math.Sqrt(i);
                var x2 = Math.Sqrt(i);
            }
            Console.WriteLine("Doing something...");

        }
    }
}