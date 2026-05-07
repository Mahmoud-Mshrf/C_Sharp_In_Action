namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var delivery = new Delivery
            {
                Id = 1,
                CustomerName = "John Doe",
                Address = "123 Elm St."
            };

            var deliveryService = new DeliveryService();
            deliveryService.Start(delivery);

            Console.WriteLine(delivery);
            Console.ReadLine();
        }
    }
}
