namespace MultiThreading
{
    // thread.start() will start the thread and execute the method that is passed to it, and it will return immediately, which means that the main thread will continue executing the next lines of code without waiting for the thread to finish.
    // thread.join() will block the main thread until the thread that is calling it finishes executing, which means that the main thread will wait for the thread to finish before continuing to execute the next lines of code.

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine($"Background Thread: {Thread.CurrentThread.IsBackground}");
            var wallet = new Wallet("Mahmoud", 80);
            Thread thread1 = new Thread(wallet.RunRandomTransactions);
            thread1.Name = "Thread 1";
            Console.WriteLine($"Thread1 Background Thread: {thread1.IsBackground}");
            Console.WriteLine($"after declaration {thread1.Name} , state is {thread1.ThreadState}");
            thread1.Start();
            thread1.Join();// wait for thread1 to finish before continuing the main thread
            Console.WriteLine($"after start {thread1.Name} , state is {thread1.ThreadState}");
            Thread thread2 = new Thread(new ThreadStart(wallet.RunRandomTransactions));// another way to create thread
            thread2.Name = "Thread 2";
            thread2.Start();
            Console.ReadKey();
        }
    }
    public class Wallet
    {
        public Wallet(string name, int bitconis)
        {
            Name = name;
            Bitconis = bitconis;
        }

        public string Name { get; set; }
        public int Bitconis { get; set; }
        public void Depit(int amount)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"[ Thread Id: {Thread.CurrentThread.ManagedThreadId}," +
                    $" Thread Name: {Thread.CurrentThread.Name},"
                + $" Processor Id: {Thread.GetCurrentProcessorId()} ] -{amount}");
            Bitconis -= amount;
        }
        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"[ Thread Id: {Thread.CurrentThread.ManagedThreadId}," +
                    $" Thread Name: {Thread.CurrentThread.Name},"
                + $" Processor Id: {Thread.GetCurrentProcessorId()} ] +{amount}");
            Bitconis += amount;
        }

        public void RunRandomTransactions()
        {
            int[] amounts = [10, 20, 30, -20, 10, -10, 30, -10, 40, -20];
            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);
                if (amount > 0)
                {
                    Credit(absValue);
                }
                else
                {
                    Depit(absValue);
                }
                
            }
        }
        override public string ToString()
        {
            return $"{Name} has {Bitconis} bitconis";
        }
    }
}
