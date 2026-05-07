namespace TaskCombinators
{
    internal class Program
    {
        /*
         * Task.WhenAll
            Executes multiple tasks concurrently and completes when all the tasks have completed. It returns a task that represents the completion of all provided tasks.

            Use Case
            When you want to run multiple independent tasks concurrently and wait for all of them to finish.
         */
        /*
         * Task.WhenAny
            Executes multiple tasks concurrently and completes when any one of the tasks has completed. It returns a task that represents the first completed task.
            
            Use Case
            When you are only interested in the result of the first task that completes.
         */
        static async Task Main(string[] args)
        {
            var has1000SubscribersTask = Task.Run(() => Has1000Subscribers());
            var has4000HoursViewsTask = Task.Run(() => Has4000HoursViews());

            Console.WriteLine("---- Using WhenAny ----");
            var whenAnyTask =await Task.WhenAny(has1000SubscribersTask, has4000HoursViewsTask);
            Console.WriteLine(whenAnyTask.Result);

            Console.WriteLine("---- Using WhenAll ----");
            var whenAllTask = await Task.WhenAll(has1000SubscribersTask, has4000HoursViewsTask);
            foreach (var result in whenAllTask)
            {
                Console.WriteLine(result);
            }

        }
        static Task<string> Has1000Subscribers()
        {
            return Task.Run(() =>
            {
                Task.Delay(3000).Wait();
                return Task.FromResult("You have acheived 1000 Subscribers");
            });
        }
        static Task<string> Has4000HoursViews()
        {
            return Task.Run(() =>
            {
                Task.Delay(3000).Wait();
                return Task.FromResult("You have acheived 4000 Hours views");
            });
        }
    }
}
