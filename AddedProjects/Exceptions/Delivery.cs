namespace Exceptions
{
    public class Delivery
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DeliveryStatus DeliverStatus { get; set; }
        override public string ToString()
        {
            return $"{{\n   Id: {Id}\n   CustomerName: {CustomerName}\n   Address: {Address}\n   DeliverStatus: {DeliverStatus}\n}}";
        }
    }
}
