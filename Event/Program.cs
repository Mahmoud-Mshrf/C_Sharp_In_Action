namespace Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock("Amazon", 100);
            stock.OnPriceChanging += Stock_OnPriceChanging;
            stock.StockPriceChangeBy(10);
        }
        private static void Stock_OnPriceChanging(Stock stock, decimal oldPrice)
        {
            if (stock.Price > oldPrice)
            {
                // for coloring
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (stock.Price < oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine($" {stock.Name} : {stock.Price}");
        }
    }
    public class Stock
    {
        public event Action<Stock,decimal> OnPriceChanging;
        public Stock(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price {  get; set; }

        public void StockPriceChangeBy(decimal Perecent)
        {
            var oldPrice = Price;
            Price += Math.Round(Price * Perecent, 2);
            if(OnPriceChanging  != null)
                OnPriceChanging(this, Perecent);
        }

    }
    // event has primary benefit :
    // - prevent direct invocation or reassignment
}
