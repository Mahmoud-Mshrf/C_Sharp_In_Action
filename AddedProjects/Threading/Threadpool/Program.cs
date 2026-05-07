

namespace Threadpool
{
    // creating threads has overhead in time and memory 
    // so we will use threadpool
    // thread pool is a pool of pre-created recyclable threads
    // this helps mitigate the issue of performance by reducing the number of threads
    // keep in mind that :
    // you cant name a thread in the thread pool (actually you can but it is not a preferd thing because )
    // While you can set a name (Thread.CurrentThread.Name) for a thread from the thread pool, it is not recommended because thread pool threads are reused. Once the thread finishes executing your task, the name you set might no longer be relevant to the next task the thread executes.
    // you cant set the priority of the thread in the thread pool
    // pooled threads is always background threads
    // ideal for short running processes
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1 using thread pool
            ThreadPool.QueueUserWorkItem(new WaitCallback(Print));
            ////
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Print), "Hello");
            ////
            //ThreadPool.QueueUserWorkItem(Print, "Hello");
            // #2 using task
            Task.Run(() => Print());
            //Task.Run(Print);
            //Task.Run(()=> Print("Hello"));
            var employee = new Employee
            {
                TotalHours = 160,
                Rate = 10
            };

            Task.Run(()=> CalculateSalary(employee));
            ThreadPool.QueueUserWorkItem(CalculateSalary, employee);
            Console.ReadKey();
        }

        private static void CalculateSalary(object? state)
        {
            var emp = state as Employee;
            if(emp is null)
                return;
            emp.TotalSalary = emp.TotalHours * emp.Rate;
            Console.WriteLine($"Total Salary :{emp.TotalSalary}");
        }

        private static void Print()
        {
            Console.WriteLine($"Thread Id :{Thread.CurrentThread.ManagedThreadId} , Thread Name :{Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread :{Thread.CurrentThread.IsThreadPoolThread} ");
            Console.WriteLine($"Background :{Thread.CurrentThread.IsBackground}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void Print(object? state)
        {
            Console.WriteLine($"Thread Id :{Thread.CurrentThread.ManagedThreadId} , Thread Name :{Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread :{Thread.CurrentThread.IsThreadPoolThread} ");
            Console.WriteLine($"Background :{Thread.CurrentThread.IsBackground}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    public class Employee
    {
        public decimal TotalSalary { get; set; }
        public decimal TotalHours { get; set; }
        public decimal Rate { get; set; }
    }
}
