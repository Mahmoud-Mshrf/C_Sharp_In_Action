namespace Sequential
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet("Mahmoud", 80);

            wallet.RunRandomTransactions();
            Console.WriteLine("------------------------");
            Console.WriteLine($"{wallet}\n");

            wallet.RunRandomTransactions();
            Console.WriteLine("------------------------");
            Console.WriteLine($"{wallet}\n");

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
            Bitconis -= amount;
        }
        public void Credit(int amount)
        {
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
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}"
                +$" Processor Id: {Thread.GetCurrentProcessorId()}");
            }
        }
        override public string ToString()
        {
            return $"{Name} has {Bitconis} bitconis";
        }
    }
}
