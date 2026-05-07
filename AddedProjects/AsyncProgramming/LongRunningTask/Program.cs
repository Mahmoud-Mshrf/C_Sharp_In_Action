namespace LongRunningTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // to create a long running task
            Task task = Task.Factory.StartNew(RunLongTask, TaskCreationOptions.LongRunning);
            // in this case the task will run on a separate thread and not on the thread pool but it will be a background thread
            Console.ReadKey();
        }
        static void RunLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }
        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"Thread Id: {th.ManagedThreadId}, Is Pooled: {th.IsThreadPoolThread}, Is Background: {th.IsBackground}");
        }
    }
}
