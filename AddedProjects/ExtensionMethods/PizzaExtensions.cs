namespace ExtensionMethods
{
    public static class PizzaExtensions
    {
        public static Pizza AddDough(this Pizza pizza, string type)
        {
            pizza.Content += $"\n{type} Dough was Added, 3$";
            pizza.TotalPrice += 3m;
            return pizza;
        }
        public static Pizza AddSouace(this Pizza pizza)
        {
            pizza.Content += $"\nTomato Soauce was Added, 2$";
            pizza.TotalPrice += 2m;
            return pizza;
        }
        public static Pizza AddCheeze(this Pizza pizza, string type)
        {
            pizza.Content += $"\n{type} Cheeze was Added, 4$";
            pizza.TotalPrice += 4m;
            return pizza;
        }
        public static Pizza AddSallade(this Pizza pizza, decimal price)
        {
            pizza.Content += $"\nSallade was Added, {price}$";
            pizza.TotalPrice += price;
            return pizza;
        }
    }
}
