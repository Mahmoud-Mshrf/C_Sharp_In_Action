namespace Properties
{
    // properties is a way to promote encapsulation
    //A property in C# is a class member that provides a controlled way to access and modify data through get and set accessors,
    // acting as a safe interface over an internal value, while a field is simply a variable that directly stores data without any control or logic;
    // properties offer key benefits such as encapsulation (hiding internal data), validation (ensuring only valid values are assigned), flexibility (allowing implementation changes without affecting external code),
    // and access control (read-only or write-only behavior),
    // whereas fields lack these capabilities and are typically used only for private internal storage, making the core difference that a field holds data directly while a property manages and protects access to that data.
    internal class Program
    {
        static void Main(string[] args)
        {
            var card = new Card("123456", "MahmoudMshrf", 20.00m);
            card.SetAmount(30);
            Console.WriteLine(card);
            Console.WriteLine();
            var card2 = new Card2("123456", "MahmoudMshrf", 20.00m);
            card2.CardAmount = 30;
            Console.WriteLine(card2);
        }
    }
    public class Card
    {
        public Card(string cardId, string cardHolderName, decimal cardAmount)
        {
            CardId = cardId;
            CardHolderName = cardHolderName;
            CardAmount = ProcessAmount(cardAmount);
        }

        public string CardId { get; set; }
        public string CardHolderName { get; set; }
        public decimal CardAmount { get; private set; }
        private decimal ProcessAmount(decimal amount) => amount <= 0 ? 0 : amount; 
        public void SetAmount(decimal amount)
        {
            CardAmount = ProcessAmount(amount);
        }
        public override string ToString()
        {
            return $"Card Holder Name : {CardHolderName} \nCard Id : {CardId} \nCard Amount : {CardAmount} \n";
        }
    }
    public class Card2
    {
        public Card2(string cardId, string cardHolderName, decimal cardAmount)
        {
            CardId = cardId;
            CardHolderName = cardHolderName;
            this.cardAmount = ProcessAmount(cardAmount);
        }

        public string CardId { get; set; }
        public string CardHolderName { get; set; }
        private decimal cardAmount;
        public decimal CardAmount { get { return cardAmount; } set { cardAmount = ProcessAmount(value); }  }
        private decimal ProcessAmount(decimal amount) => amount <= 0 ? 0 : amount;
        //public void SetAmount(decimal amount)
        //{
        //    CardAmount = ProcessAmount(amount);
        //} // don't need this
        public override string ToString()
        {
            return $"Card Holder Name : {CardHolderName} \nCard Id : {CardId} \nCard Amount : {CardAmount} \n";
        }
    }
}
