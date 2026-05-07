namespace CancellationTokenExplanation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            //await DoCheck01(cancellationTokenSource);
            //await DoCheck02(cancellationTokenSource);
            await DoCheck03(cancellationTokenSource);
            Console.ReadKey();
        }
        static async Task DoCheck01(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() => 
            {
                var input = Console.ReadKey();
                if(input.Key== ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            while (!cancellationTokenSource.Token.IsCancellationRequested) 
            {
                Console.Write("Checking ...");
                await Task.Delay(4000);
                Console.Write($"Completed on {DateTime.Now}");
                Console.WriteLine();
            }// in this case the cancellation will be done after waiting the 4 seconds then cancel the task
            Console.WriteLine("Check has been terminated");
            cancellationTokenSource.Dispose();
        }
        static async Task DoCheck02(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            while (true)
            {
                Console.Write("Checking ...");
                await Task.Delay(4000,cancellationTokenSource.Token);
                Console.Write($"Completed on {DateTime.Now}");
                Console.WriteLine();
            }// in this case the cancellation will be done before waiting the 4 seconds because the cancellation token is passed to the delay method
            Console.WriteLine("Check has been terminated");
            cancellationTokenSource.Dispose();
        }
        static async Task DoCheck03(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            try
            {
                while (true)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Console.Write("Checking ...");
                    await Task.Delay(4000);
                    Console.Write($"Completed on {DateTime.Now}");
                    Console.WriteLine();
                } // in this way we can check the cancellation token in the loop and throw an exception if the cancellation has been requested
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Check has been terminated");
            cancellationTokenSource.Dispose();
        }
    }
}
