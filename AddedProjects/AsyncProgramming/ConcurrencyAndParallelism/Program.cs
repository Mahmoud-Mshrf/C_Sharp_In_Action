namespace ConcurrencyAndParallelism
{
    internal class Program
    {
        // concurrency is the ability to run multiple tasks at the same time but not necessarily simultaneously 
        // parallelism is the ability to run multiple tasks simultaneously
        static async Task Main(string[] args)
        {
            var things = new List<DailyDuty> 
            {
                new DailyDuty("Task 1"),
                new DailyDuty("Task 2"),
                new DailyDuty("Task 3"),
                new DailyDuty("Task 4"),
                new DailyDuty("Task 5"),
                new DailyDuty("Task 6"),
                new DailyDuty("Task 7"),
                new DailyDuty("Task 8")
            };
            Console.WriteLine("Processing things in parallel");
            await ProcessThingsInParallel(things);
            Console.WriteLine("Processing things in concurrent");
            await ProcessThingsInConcurrent(things);
            Console.ReadKey();
        }
        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things,thing => thing.Process());
            return Task.CompletedTask;
        }
        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }
            return Task.CompletedTask;
        }
    }
    class DailyDuty
    {
        public DailyDuty(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
        public bool Processed { get; private set; }
        
        public void Process()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Processor Id: {Thread.GetCurrentProcessorId()}");
            Task.Delay(1000).Wait(); // Simulate some work by blocking the thread for 1 second , this mean that this line is not asynchronous and it will block the thread until the delay is completed
            Processed = true;
        }
    }
}
