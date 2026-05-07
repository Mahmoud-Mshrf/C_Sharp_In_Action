namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To Display The Current Time We can use:
            // DateTime.Now this show the current time in current region ,
            // DateTimeOfsset.Now this show the current time with GMT Difference,
            // DateTimeOfsset.UtcNow this show the current Unevirsal Time mean Global Time
            DateTime dateTime = DateTime.Now;
            DateTimeOffset GMTdatetime = DateTimeOffset.Now;
            DateTimeOffset UTCdatetime = DateTimeOffset.UtcNow;
            Console.WriteLine(dateTime);
            Console.WriteLine(GMTdatetime);
            Console.WriteLine(UTCdatetime);
            TimeSpan timeSpan = new TimeSpan(3, 12, 0);
            dateTime = dateTime.Add(timeSpan);
            Console.WriteLine(dateTime);
            ////////////////////////////////////////////////////////////////////////////////////
            DateTime dateTime1 = DateTime.Now;
            // here we use the basic way that we call the IsWeekEnd from the TimeHelper class 
            Console.WriteLine(TimeHelper.IsWeekEnd(dateTime1));
            Console.WriteLine(TimeHelper.IsWeekDay(dateTime1));
            // here we use extension methods that we call the IsWeekEnd from the instance itself
            Console.WriteLine(dateTime1.IsWeekEnd());
            Console.WriteLine(dateTime1.IsWeekDay());
            ////////////////////////////////////////////////////////////////////////////////////
            Pizza pizza = new Pizza();
            // here we use method chaining with the old way
            //pizza= PizzaExtensions.AddDough(PizzaExtensions.AddCheeze(PizzaExtensions.AddSouace(PizzaExtensions.AddSallade(pizza,3m)), "Mozzarilla"),"regular");
            // here we use method chanining with the new way by extension methods
            pizza.AddCheeze("Mozzarialla")
                .AddSouace()
                .AddDough("someKind")
                .AddSallade(2m);
            Console.WriteLine(pizza);
        }
    }
}
