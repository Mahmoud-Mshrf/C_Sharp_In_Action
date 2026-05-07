using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace AsynchronousFunctionsDetailedExample2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Calling FetchDataAsync...");

            var fetchTask = FetchDataAsync(); // Start FetchDataAsync but don't await it yet
            Console.WriteLine("FetchDataAsync started, now doing other work...");

            // Simulate some work while waiting
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Main method doing work {i + 1}");
                await Task.Delay(500); // Simulating asynchronous work
            }

            // Await FetchDataAsync to get the result
            string result = await fetchTask;
            Console.WriteLine("FetchDataAsync returned the following data:");
            Console.WriteLine(result);

            Console.WriteLine("Main method is complete!");
        }

        public static async Task<string> FetchDataAsync()
        {
            Console.WriteLine("FetchDataAsync: Starting HTTP request...");
            var client = new HttpClient();

            // Await the HTTP response
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

            // Await and return the content as a string
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine("FetchDataAsync: Received data.");

            return data; // Return the result to the caller
        }
    }
    /*
     * Explanation of the Flow
        Starting FetchDataAsync:
            When FetchDataAsync is called, it starts executing and begins the HTTP request. The method immediately returns a Task<string> to the caller (fetchTask).
        
        Continuing Work in Main:
            The Main method continues executing the loop while FetchDataAsync performs its HTTP request in the background.
        
        Awaiting the Result:
            When await fetchTask is encountered, the program pauses and waits for the Task<string> to complete and return its result.
        
        Returning the Value:
            Once the HTTP request completes, FetchDataAsync returns the response content as a string, which is stored in result in the Main method.
     */
    /*
     * Key Points
        Return Type of FetchDataAsync:
            The method FetchDataAsync is marked async and returns a Task<string>.
            This means the method will eventually produce a string, but since it’s asynchronous, it first returns a Task<string> to the caller.
        
        Getting the Result:           
            To get the result of the asynchronous method, the caller uses await. This ensures the program pauses until the task is complete and retrieves the returned value.
        
        Non-Blocking Behavior:
            While FetchDataAsync waits for the HTTP response, the Main method can continue doing other work (like the for loop).
     */
    /*
     * Summary
        An async method can return a value using Task<TResult>.
        You use await to get the value once the task is complete.
        This pattern allows you to write asynchronous code that behaves like synchronous code in terms of flow, but without blocking threads.
     */
}


