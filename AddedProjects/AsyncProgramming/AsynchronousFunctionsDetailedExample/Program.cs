using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynchronousFunctionsDetailedExample
{
    /*
     * How async and await Work Together :
       When you call an async method like FetchDataAsync without await, it starts executing and returns immediately as a Task. The actual work inside the method (e.g., fetching data from an API) continues in the background.
       When you later place await before the task, the program pauses and waits for the task to complete before proceeding to the next line. However, this waiting happens without blocking the thread.
       
       Key Points :
       Starting the Work:   When you call FetchDataAsync, the asynchronous process (e.g., an HTTP request) begins immediately, even if you haven't yet awaited it.
       Thread Is Not Blocked:   Unlike synchronous methods, the thread is not blocked. It is free to do other work until you explicitly await the task.
       When You await:  The code execution pauses at the await until the task completes.
                        While paused, other tasks or operations on the same thread can still execute if it's part of an asynchronous context (e.g., a UI thread or an event loop).
     */
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Calling FetchDataAsync...");

            var fetchTask = FetchDataAsync(); // Starts the work, but doesn't block the thread
            Console.WriteLine("FetchDataAsync started, now doing other work...");

            // Simulate some other work while FetchDataAsync is running
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Main method doing work {i + 1}");
                await Task.Delay(500); // Simulating work
            }

            // Now wait for FetchDataAsync to complete
            await fetchTask;

            Console.WriteLine("FetchDataAsync is complete!");
        }

        public static async Task FetchDataAsync()
        {
            Console.WriteLine("FetchDataAsync: Starting HTTP request...");
            var client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine("FetchDataAsync: Received data:");
            Console.WriteLine(data);
        }
    }

    /*
     * Explanation of the Flow:
        FetchDataAsync Starts:
            When var fetchTask = FetchDataAsync() is called, it begins executing immediately (the HTTP request starts).
            However, since it is not awaited yet, the Main method continues to the next line without waiting for FetchDataAsync to complete.
        
        Main Method Does Other Work:
            The for loop in Main executes while FetchDataAsync is still in progress.
        
        Awaiting the Task:
            Once the loop finishes, the program encounters await fetchTask.
            At this point, it pauses until the HTTP request and other work in FetchDataAsync are complete.
        
        FetchDataAsync Completes:
            Once the HTTP request finishes and the data is processed, control returns to Main, and it prints "FetchDataAsync is complete!".
     */

    /*
     * Summary
            The process inside FetchDataAsync starts immediately when you call it.
            The thread is not blocked; it can execute other code while waiting for the asynchronous process to finish.
            The await keyword ensures that you wait for the task’s completion before proceeding further, but this waiting does not block the thread.
     */


}
