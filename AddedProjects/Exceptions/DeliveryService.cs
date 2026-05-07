namespace Exceptions
{
    public class DeliveryService 
    {
        private readonly static Random random = new Random();
        public void Start(Delivery delivery)
        {
            try
            {
                Process(delivery);
                Ship(delivery);
                Transit(delivery);
                Deliver(delivery);
            }
            catch (Exception ex) when (ex is InvalidAddressException || ex is AccidentException)// this is a filter exception by applying a condition to the catch block
            {
                
                Console.WriteLine(ex.Message);
                delivery.DeliverStatus = DeliveryStatus.Unknown;
            }
            catch (Exception ex)// this is a general exception handler that will catch any exception that is not caught by the previous catch block , and it is must be the last catch block
            {
                // if we want to rethrow the exception we can use the throw keyword without any argument like this throw; and this called ducking the exception
                // throw;// this will rethrow the exception to the caller of the method (ducking the exception)
                // if we comment what is below and don't make anything inside the catch block this is called swallowing the exception and it is a bad practice
                Console.WriteLine(ex.Message);
                delivery.DeliverStatus = DeliveryStatus.Unknown;
            }
            finally
            {// This block will always execute regardless of whether an exception is thrown or not and it is optional.
                Console.WriteLine("End");
            }
            
        }

        private void Deliver(Delivery delivery)
        {
            FakeIt("Delivering");
            if(random.Next(1, 5) == 1)
            {
                throw new InvalidAddressException("Invalid address, delivery failed");
            }
            delivery.DeliverStatus = DeliveryStatus.Delivered;
        }

        private void Transit(Delivery delivery)
        {
            FakeIt("Transiting");
            if(random.Next(1, 5) == 1)
            {
                throw new AccidentException("I-95", "Accident on I-95, delivery delayed");
            }
            delivery.DeliverStatus = DeliveryStatus.Transit;
        }

        private void Ship(Delivery delivery)
        {
            FakeIt("Shipping");
            if(random.Next(1, 5) == 1)
            {
                throw new Exception("Shipping failed");
            }
            delivery.DeliverStatus = DeliveryStatus.Shipped;
        }

        private void Process(Delivery delivery)
        {
            FakeIt("Processing");
            if(random.Next(1, 5) == 1)
            {
                throw new Exception("Processing failed");
            }
            delivery.DeliverStatus = DeliveryStatus.Processed;
        }
        private void FakeIt(string title)
        {
            Thread.Sleep(300);
            Console.Write(title);
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.WriteLine(".");
        }
    }
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message) : base(message)
        {
        }
    }
    public class AccidentException : Exception
    {
        public string Location { get; set; }
        public AccidentException(string location,string message) : base(message)
        {
            Location = location;
        }
    }
}
