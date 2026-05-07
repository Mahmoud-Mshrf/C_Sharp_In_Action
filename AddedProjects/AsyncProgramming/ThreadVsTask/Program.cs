
namespace ThreadVsTask
{
    // Thread vs Task:
    // 1- Thread is a low-level construct that represents a single thread of execution, while Task is a higher-level abstraction that represents an asynchronous operation that can be executed on a thread pool thread.
    // 2- Thread is created and managed by the developer, while Task is created and managed by the .NET runtime.
    // 3- Thread is more expensive to create and manage than Task, as it requires more resources and has a higher overhead, while Task is more lightweight and efficient.
    // 4- Thread is more suitable for long-running operations that require a dedicated thread, while Task is more suitable for short-running operations that can be executed on a thread pool thread.
    // 5- Thread can be used for both synchronous and asynchronous operations, while Task is primarily designed for asynchronous operations.
    // 6- Thread can be pooled or non-pooled, while Task is always pooled.
    // 7- Thread can be background or foreground, while Task is always background.
    // 8- Thread by default does not return a value, while Task can return a value using Task<T>.
    // 9- Thread by default does not support cancellation, while Task supports cancellation using CancellationToken.
    // 10- Thread by default does not support excetion propagation, while Task supports exception propagation using AggregateException.
    // 11- Thread by default does not support chaining, while Task supports chaining using ContinueWith method or async/await keywords.
    // 
    internal class Program
    {
        static void Main(string[] args)
        {
            var th = new Thread(() => Display("Using Thread"));
            th.Start();
            th.Join();
            Task.Run(() => Display("Using Task")).Wait();// Wait() in task is equivelant to thread.Join() in thread , both block the thread (wait the thread to finish its job before moving to another job)
            Console.ReadLine();
        }
        static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"Thread Id: {th.ManagedThreadId}, Is Pooled: {th.IsThreadPoolThread}, Is Background: {th.IsBackground}");
        }
    }
}
