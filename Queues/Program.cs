using System.Diagnostics.CodeAnalysis;

namespace Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintingJob[] printingJobbss = { new PrintingJob("something1", 1), new PrintingJob("something2", 2), new PrintingJob("something3", 3) };
            Queue<PrintingJob> printingJobs = new Queue<PrintingJob>(printingJobbss);
            Console.WriteLine(printingJobs.Count);
            printingJobs.Enqueue(new PrintingJob("something1.pdf", 8));
            printingJobs.Enqueue(new PrintingJob("something2.pdf", 7));
            printingJobs.Enqueue(new PrintingJob("something3.pdf", 6));
            printingJobs.Enqueue(new PrintingJob("something4.pdf", 5));
            printingJobs.Enqueue(new PrintingJob("something5.pdf", 4));
            printingJobs.Enqueue(new PrintingJob("something6.pdf", 3));
            printingJobs.Enqueue(new PrintingJob("something7.pdf", 2));
            Console.WriteLine($"current elements in queue {printingJobs.Count()}");

            Random rnd = new Random();
            while (printingJobs.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                var job = printingJobs.Dequeue();
                Console.WriteLine($"Printing .... {job}");
                System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);
            }
            Console.WriteLine($"current elements in queue {printingJobs.Count()}");
        }
    }
    public class PrintingJob
    {
        private readonly string file;
        private readonly int copies;

        public PrintingJob(string file, int copies)
        {
            this.file = file;
            this.copies = copies;
        }
        public override string ToString()
        {
            return $"{file} X {copies}";
        }
    }
}