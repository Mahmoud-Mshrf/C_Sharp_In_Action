namespace SyncVsAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, 7);
            CallSynchronous();

            ShowThreadInfo(Thread.CurrentThread, 10);
            CallAsynchronous();

            ShowThreadInfo(Thread.CurrentThread, 13);
            Console.ReadLine();

        }
        static void CallSynchronous()
        {
            Thread.Sleep(4000);// this will block the thread , it will wait the thread to finish its job before moving to another job
            ShowThreadInfo(Thread.CurrentThread, 20);
            Task.Run(()=> Console.WriteLine("----- Synchronous -----")).Wait(); // this will block the thread until the task is completed so its a synchronous call and it will print this line after the delay is completed and any other code after this line will be executed after the delay is completed
        }
        static void CallAsynchronous()
        {
            ShowThreadInfo(Thread.CurrentThread, 25);
            Task.Delay(4000).GetAwaiter().OnCompleted(() =>// the thread will not be blocked because it is asynchronous , while the delay is happening the thread will do other jobs (in this case in the main method it will go to do the line 13 so the ShowThreadInfo will be processeced before the one in line 28)
            {
                ShowThreadInfo(Thread.CurrentThread, 28);
                Console.WriteLine("----- Asynchronous -----");
            });
        }
        // Asynchronous  will not block the thread , it will not wait the thread to finish its job before moving to another job
        // Synchronous will block the thread , it will wait the thread to finish its job before moving to another job

        private static void ShowThreadInfo(Thread th,int line)
        {
            Console.WriteLine($"Line:{line} Thread Id: {th.ManagedThreadId}, Is Pooled: {th.IsThreadPoolThread}, Is Background: {th.IsBackground}");
        }
    }
    /*
     * Synchronous Programming
        Definition: In synchronous programming, tasks are executed one at a time in a sequential order. The program waits for each task to complete before moving to the next one.
        Blocking: Execution is blocked until the current task is finished.
        Usage: Suitable for simpler tasks where waiting doesn't significantly impact performance.
     */

    /*
     * Asynchronous Programming
        Definition: In asynchronous programming, tasks can start and run concurrently without waiting for each task to complete before proceeding to the next one. The program can continue executing other code while waiting for a task to finish.
        Non-blocking: Execution is not blocked, making it suitable for tasks that involve I/O operations, long computations, or anything that takes time.
        Usage: Improves performance and responsiveness in applications, especially for UI or server-based tasks.
     */

    /*
     * Feature	         Synchronous	                                 Asynchronous
       Execution         OrderTasks execute sequentially.	             Tasks can execute concurrently.
       Blocking	         Blocks the thread until task ends.	             Does not block; allows other tasks.
       Complexity	     Simpler to implement and debug.	             Requires understanding of async/await.
       Performance	     Can cause slowdowns if tasks are long.	         Better performance for I/O-bound or long-running tasks.
       Thread Usage	     Uses one thread at a time.	                     Can use multiple threads.
     */

     // synchronous operation is an operation that blocks the thread until it is completed and doesn't return control to the caller until it is finished, while asynchronous operation is an operation that doesn't block the thread and returns control to the caller immediately, allowing the caller to continue executing other code while waiting for the operation to complete.
}
