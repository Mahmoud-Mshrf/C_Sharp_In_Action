namespace ExceptionPropagation
{
    // exception propagation in threads •	Means that if the thread runs a function that causes throwing an exception , the exception will be propagated to the thread that started the thread and if it is not handled there it will crash the program so the try catch block should be on the thread that started the thread and not on the thread that runs the function that causes throwing the exception because the exception will not be propagated to the thread that runs the function that causes throwing the exception but it will be propagated to the thread that started the thread
    // exception propagation in tasks •	When a task throws an exception, the exception is captured and stored in the Task object. When you wait for the task to complete (using Wait() or accessing the Result property), the stored exception is re-thrown on the calling thread. This allows you to catch and handle exceptions that occur within tasks, even if they are running on different threads.
    internal class Program
    {
        static void Main(string[] args)
        {
            //// #1
            //try
            //{
            //    var thread = new Thread(ThrowException);
            //    thread.Start();
            //    thread.Join();
            //    // the exception will be thrown on the thread that started the thread
            //    // not on the main thread so the exception will not be caught here and the program will crash
            //    // to catch the exception we need to catch it on the thread that started the thread (see #2)
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception is thrown !!");
            //}
            //Console.ReadKey();

            // #2
            //var thread = new Thread(ThrowExceptionWithTryCatch);
            //thread.Start();
            //thread.Join();
            //Console.ReadKey();

            // #3 using Task 
            try
            {
                Task.Run(() => ThrowException()).Wait();
            }
            catch (Exception)
            {

                Console.WriteLine("Exception is thrown !!");
            }
            Console.ReadKey();

        }
        static void ThrowException()
        {
            throw new NullReferenceException();
        }
        // this is a part of #2 solution
        // where we catch the exception on the thread that started the thread
        static void ThrowExceptionWithTryCatch()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is thrown !!");
            }
        }
    }
}
