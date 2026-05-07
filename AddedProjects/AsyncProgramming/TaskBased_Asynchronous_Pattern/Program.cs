namespace TaskBased_Asynchronous_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        private static object _lock = new();
        private static void ProcessPatch1(CancellationToken cancellationToken)
        {
            for (int i = 1; i < 100; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    return; 
                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            
        }
        private static void ProcessPatch2(CancellationToken cancellationToken)
        {
            for (int i = 101; i < 200; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;
                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
