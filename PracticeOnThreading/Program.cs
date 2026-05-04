using System.Diagnostics;

namespace PracticeOnThreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thread thread = new Thread(PrintNumbers);
            Console.WriteLine("Numbers From 1 to 10");
            Thread thread1 = new Thread(new ThreadStart(PrintNumbers));
            thread1.Start();
            thread1.Join();
            Console.WriteLine("Within printing");
            Console.WriteLine(Process.GetCurrentProcess().Id);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(Thread.GetCurrentProcessorId());

        }
    
       static void PrintNumbers()
       {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(200);
            }

        }
    } 
}
