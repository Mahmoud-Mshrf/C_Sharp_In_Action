namespace Deadlock
{
    // deadlock is a situation where two or more threads are blocked forever, waiting for each other to release a resource.
    // in this example we have two threads trying to transfer money from one wallet to another, and they are trying to lock the same resources in different order, which leads to a deadlock.
    // in this case thread one is trying to lock wallet1 and then wallet2, while thread two is trying to lock wallet2 and then wallet1, which leads to a deadlock.
    // thread one will lock wallet2 and at the same time thread two will lock wallet1, and both threads will be waiting for each other to release the lock, which will never happen.
    // to solve this problem we can use Monitor.TryEnter method, which will try to acquire the lock on the resource and if it fails it will return false, which will allow the thread to continue without waiting for the lock to be released.
    // so in this case if thread one fails to acquire the lock on wallet2, it will continue without waiting for the lock to be released, and it will print a message indicating that it was unable to acquire the lock, and the same thing will happen for thread two if it fails to acquire the lock on wallet1.
    // at least one of the two threads will be able to complete the transaction, and the other thread will be able to continue without waiting for the lock to be released, which will prevent the deadlock from happening.
    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet1 = new Wallet("Issam", 100);
            var wallet2 = new Wallet("Reem", 50);
            Console.WriteLine("\n Before Transaction");
            Console.WriteLine("\n -------------------");
            Console.Write(wallet1 + ", "); Console.Write(wallet2); Console.WriteLine();
            Console.WriteLine("\n After Transaction");
            Console.WriteLine("\n -------------------");
            var transferManager1 = new TransferManager(wallet1, wallet2,50);
            var transferManager2 = new TransferManager(wallet2, wallet1,30);

            Thread thread1 = new Thread(transferManager1.Transfer);
            thread1.Name = "Thread 1";
            Thread thread2 = new Thread(transferManager2.Transfer);
            thread2.Name = "Thread 2";

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            Console.Write(wallet1 + ", "); Console.Write(wallet2); Console.WriteLine();
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
    public class TransferManager
    {
        private Wallet from;
        private Wallet to;
        private int amountToTransfer;

        public TransferManager(Wallet from, Wallet to, int amountToTransfer)
        {
            this.from = from;
            this.to = to;
            this.amountToTransfer = amountToTransfer;
        }

        public void Transfer()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock .... {from}");
            lock (from)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} lock acquried .... {from}");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock .... {to}");
                //lock (to)
                //{
                //    from.Depit(amountToTransfer);
                //    to.Credit(amountToTransfer);
                //}
                // the previous code will lead to deadlock 
                // to solve this we will use Monitor
                // this the true workflow for this should at least do one of the two processes and the another it fails
                if (Monitor.TryEnter(to, 1000))
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} lock acquried .... {to}");
                    try
                    {
                        from.Depit(amountToTransfer);
                        to.Credit(amountToTransfer);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        Monitor.Exit(to);
                    }
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} unable to acquire lock on .... {to}");
                }
            }
        }
    }
}
