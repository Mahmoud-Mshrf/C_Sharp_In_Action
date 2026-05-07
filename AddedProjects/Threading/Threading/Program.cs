
namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProcessPatch1();
            //ProcessPatch2(); // this way these will run sequentially so it will print them with the right order 
            Thread th1 = new Thread(ProcessPatch1);
            Thread th2 = new Thread(ProcessPatch2);
            th1.Start();
            th2.Start(); // that way it will be an unexpected behaviour 
            th1.Priority = ThreadPriority.Highest;// this make it have highest priority over other threads
            th1.IsBackground = true;// this will make it background thread so so the app will be closed if there are only background threads and there is no foreground threads

            var ct = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(ProcessPatch1,ct.Token);
            ThreadPool.QueueUserWorkItem(ProcessPatch2,ct.Token);
            ct.Cancel();// here we send a request to cancel the thread , not canceling the request directly just sending request because canceling the request depends on the method being operated
            
            
        }
        private static object _lock = new ();
        private static void ProcessPatch1(object? state)// we added object? state as paramater to use it in ThreadPool cause it accept functions that has object as parameter
        {
            var cts = (CancellationToken)state;

            for (int i = 1; i < 1000; i++)
            {
                if (cts.IsCancellationRequested)
                    return; // here we define where the thread can be cancelled 
                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
            // using lock prevent the unexpected behaviour
        }
        private static void ProcessPatch2(object? state)
        {
            for (int i = 1001; i < 2000; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(i);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
