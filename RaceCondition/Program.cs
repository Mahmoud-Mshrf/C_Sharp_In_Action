namespace RaceCondition
{
    // Race condition is a situation where two or more threads try to modify the same resource at the same time, which leads to unpredictable results, and it can cause data corruption, and it can also lead to security vulnerabilities.
    // in this example we have two threads trying to depit money from the same wallet, and they are trying to access the same resource at the same time, which
    // to solve this problem we can use lock keyword, which will allow only one thread to access the resource at a time, and the other thread will wait until the resource is available, which will prevent

    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet("Mahmoud", 50);
            Thread th1 = new Thread(() => wallet.Depit(40));
            Thread th2 = new Thread(() => wallet.Depit(30));

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();
            // the previous code will leads to race condition because the two threads are trying to access the same resource at the same time 
            // rece condition is a situation where two or more threads try to modify the same resource at the same time 
            // to prevent race condition we can use lock keyword and give it as parameter any refernce type so once a thread is using the resource the other thread will wait until the resource is available by the first thread(the first thread will release the resource once it finish using it)
            Console.WriteLine(wallet);
            Console.ReadKey();
        }
    }
    public class Wallet
    {
        private readonly object _lock = new object();
        public Wallet(string name, int bitconis)
        {
            Name = name;
            Bitconis = bitconis;
        }

        public string Name { get; set; }
        public int Bitconis { get; set; }

        public void Depit(int amount)
        {
            //if(Bitconis >= amount)
            //{
            //    Thread.Sleep(1000);
            //    Bitconis -= amount;
            //}
            // the previous before using lock keyword will make race condition
            lock (_lock)
            {
                if (Bitconis >= amount)
                {
                    Thread.Sleep(1000);
                    Bitconis -= amount;
                }
            }
            // the lock keyword will make the thread wait until the resource is available
        }
        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Bitconis += amount;
        }
        override public string ToString()
        {
            return $"{Name} has {Bitconis} bitconis";
        }
    }
}
