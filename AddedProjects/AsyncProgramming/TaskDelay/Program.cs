namespace TaskDelay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelayUsingTaskDelay(2000);
            Console.ReadKey();
        }
        static void DelayUsingTaskDelay(int ms)
        {
            // #1
            //Task.Delay(ms);// this is a logical delay will not block the thread , it will not actually delay the thread because it is not awaited 
            //Console.WriteLine($"Completed after Task.Delay({ms})"); // it will print this line before the delay is completed

            //// #2
            //Task.Delay(ms).Wait();// it will block the thread until the delay is completed and then it will print this line after the delay is completed and any other code after this line will be executed after the delay is completed
            //Console.WriteLine($"Completed after Task.Delay({ms})");// it will print this line after the delay is completed
            // #3
            Task.Delay(ms).GetAwaiter().OnCompleted(() => 
            {
                Console.WriteLine($"Completed after Task.Delay({ms})");// it will not block the main thread and it will print this line after the delay is completed  and any other code after this line will be executed immediately without waiting for the delay to complete
            });
        }
        static void SleepUsingThread(int ms)
        {
           Thread.Sleep(ms);// this will block the thread
           Console.WriteLine($"Completed after Thread.Sleep({ms})");// it will print this line after the delay is completed
        }
    }
}
