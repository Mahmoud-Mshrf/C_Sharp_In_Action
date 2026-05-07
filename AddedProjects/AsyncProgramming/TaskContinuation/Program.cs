namespace TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(CountPrimesInRange(1,2_000_000));
            Task<int> task = Task.Run(() => CountPrimesInRange(1, 3_000_000));
            // #1
            Console.WriteLine(task.Result);// this will block the main thread until the task is completed so it is bad
            
            // #2
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());// block the thread but it is better than #1 because the task is completed , the blocking will be for just printing the result
            });
            // #3
            task.ContinueWith(t =>
            {
                Console.WriteLine(t.Result);// after the task is completed it will continue with this action and print the result , this is the best way to handle the result of the task because it will not block the main thread at all
            });

        }
        static int CountPrimesInRange(int start, int end)
        {
            int count = 0;

            for (int i = Math.Max(start, 2); i <= end; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    count++;
            }

            return count;
        }
    }

}
