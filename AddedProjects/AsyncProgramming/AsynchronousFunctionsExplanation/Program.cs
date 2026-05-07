namespace AsynchronousFunctionsExplanation
{
    /* the await keyword is used in asynchronous functions to pause the execution of the method until the awaited task is complete.
     * This allows the program to avoid blocking the thread while waiting for a long-running operation, such as a network call, file I/O, or database query, to finish.
     * When to Use await :
     * You should use await before calling a method or task that returns a Task or Task<TResult>, This could include:
       - Asynchronous library methods such as HttpClient.GetAsync, File.ReadAllTextAsync, etc.
       - Custom asynchronous methods that return a Task or Task<TResult>.
     * Where to Put await :
     * You place await in front of the method or task whose completion you want to wait for before proceeding further in the function.
     */
    internal class Program
    {
        static async Task Main(string[] args)
        {
            FetchData();
            Console.WriteLine("This code will wait the FetchData() function to finish its work \n \n");
            var fetchData= FetchDataAsync();// This will not block the thread because the FetchDataAsync() function is asynchronous , it starts the FetchDataAsync() function and then moves to the next line of code without waiting the FetchDataAsync() function to finish its work
            Console.WriteLine("This code will not wait the FetchDataAsync() function to finish its work \n \n");
            await fetchData; // here we are waiting the FetchDataAsync() function to finish its work before moving to the next line of code 
            // The await keyword ensures that you wait for the task’s completion before proceeding further, but this waiting does not block the thread.
        }
        // Without async and await, this would block the thread
        public static void FetchData()
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://www.google.com").Result; // Blocks thread
            var data = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(data);
        }
        // Using async and await, the code doesn't block
        public static async Task FetchDataAsync()
        {
            var client = new HttpClient();

            // Awaiting the response without blocking the thread
            var response = await client.GetAsync("https://www.google.com");

            // Awaiting the content read without blocking the thread
            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine(data);
        }

    }
}
