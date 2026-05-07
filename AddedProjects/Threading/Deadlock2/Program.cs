namespace DeadLock2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this is the happy path
            var wallet1 = new Wallet("Mahmoud", 100);
            var wallet2 = new Wallet("Aya", 50);
            Console.WriteLine("\nBefore Transaction");
            Console.WriteLine("\n********************");
            Console.Write(wallet1 + " ,  ");
            Console.Write(wallet2);
            Console.WriteLine("\nAfter Transaction");
            Console.WriteLine("\n********************");
            // this is the happy path
            //var transfermanager = new TransferManager(wallet1,wallet2,50);
            //transfermanager.Transfer();
            //Console.Write(wallet1 + " ,  ");
            //Console.Write(wallet2);
            // this will lead to deadlock
            var transfermanager1 = new TransferManager(wallet1, wallet2, 50);
            var transfermanager2 = new TransferManager(wallet2, wallet1, 30);
            var t1 = new Thread(transfermanager1.Transfer);
            var t2 = new Thread(transfermanager2.Transfer);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.Write(wallet1 + " ,  ");
            Console.Write(wallet2);


        }
    }
    public class TransferManager
    {
        private Wallet from { get; set; }
        private Wallet to { get; set; }
        private decimal amountToTransfer { get; set; }
        public TransferManager(Wallet from, Wallet to, decimal amountToTransfer)
        {
            this.from = from;
            this.to = to;
            this.amountToTransfer = amountToTransfer;
        }
        public void Transfer()
        {
            // in this case it lead to deadlock
            //Console.WriteLine($"{Thread.CurrentThread.Name} Trying to lock {from}");
            //lock (from)
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.Name} Acquired {from}");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"{Thread.CurrentThread.Name} Trying to lock {to}");
            //    lock (to)
            //    {
            //        from.Debit(amountToTransfer);
            //        to.Credit(amountToTransfer);
            //    }
            //}
            // this the true workflow for this should at least do one of the two processes and the another it fails
            Console.WriteLine($"{Thread.CurrentThread.Name} Trying to lock {from}");
            lock (from)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Acquired {from}");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} Trying to lock {to}");

                if (Monitor.TryEnter(to, 1000))
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} Acquired {to}");
                    try
                    {
                        from.Debit(amountToTransfer);
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
                    Console.WriteLine($"{Thread.CurrentThread.Name} unable to Acquire lock on   {to}");

                }
            }
        }
    }
    public class Wallet
    {
        public string name { get; set; }
        public decimal Balance { get; set; }
        public Wallet(string name, decimal balance)
        {
            Thread.Sleep(1000);
            this.name = name;
            this.Balance = balance;
        }
        public void Debit(decimal amount)
        {
            Thread.Sleep(1000);
            if (Balance > amount)
                Balance -= amount;
        }
        public void Credit(decimal amount)
        {
            Thread.Sleep(1000);
            Balance += amount;
        }

        public override string ToString()
        {
            return $"{name} ->  Balance: {Balance}";
        }
    }
}