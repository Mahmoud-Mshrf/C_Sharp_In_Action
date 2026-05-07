namespace AsyncFunctions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // #1
            string url = "https://www.google.com";
            var task = Task.Run(() => ReadContent(url));
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());
            });

            // #2
            Console.WriteLine(await ReadContentAsync("https://www.google.com"));// 
            Console.ReadLine();
        }
        // #1
        static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(url);
            return task;
        }
        // #2
        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync(url);

            return content;
        }

    }
}
// how to use async functions without blocking the main thread:
// #1 /// you can use the GetAwaiter method to get an awaiter for the task and then use the OnCompleted method to specify a callback that will be called when the task is completed. This way, you can handle the result of the task without blocking the main thread.
// #2 /// you can use the async and await keywords to create an asynchronous method that returns a Task. This way, you can call the asynchronous method and await its result without blocking the main thread.

// how to use async and await keywords to create an asynchronous method that returns a Task:
// 1- You can define an asynchronous method by using the async keyword in the method signature. This indicates that the method contains asynchronous operations and can be awaited.
// 2- The asynchronous method can return a Task or Task<T> depending on whether it returns a value or not. In this example, the ReadContentAsync method returns a Task<string> because it returns a string value.
// 3- Inside the asynchronous method, you can use the await keyword to await the completion of asynchronous operations. In this example, the client.GetStringAsync(url) method is awaited, which means that the method will pause at that point until the operation is completed and the result is available.
// 4- When you call the asynchronous method, you can use the await keyword to await its result. In this example, the ReadContentAsync method is called and awaited in the Main method, which means that the Main method will pause at that point until the ReadContentAsync method is completed and the result is available. This allows you to handle the result of the asynchronous operation without blocking the main thread.
// Note: When using async and await, it's important to ensure that the calling code is also asynchronous or can handle the asynchronous nature of the method. In this example, the Main method is defined as async Task, which allows it to use await and handle the asynchronous operations properly.

// we put await before the client.GetStringAsync(url) because we want to wait for the completion of the GetStringAsync method before proceeding to the next line of code. The GetStringAsync method is an asynchronous operation that retrieves the content of the specified URL. By using await, we can pause the execution of the ReadContentAsync method until the GetStringAsync method completes and returns the result. This allows us to handle the result of the asynchronous operation without blocking the main thread and ensures that we have the content available before returning it from the ReadContentAsync method.
// In summary, using async and await allows us to write asynchronous code that is more readable and maintainable, while also ensuring that we can handle the results of asynchronous operations without blocking the main thread.
// await putted before any non -blocking operation that returns a Task or Task<T> to indicate that we want to wait for the completion of that operation before proceeding to the next line of code. This allows us to write asynchronous code that is more readable and maintainable, while also ensuring that we can handle the results of asynchronous operations without blocking the main thread.