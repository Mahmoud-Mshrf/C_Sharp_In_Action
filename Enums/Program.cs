namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // converting between enum and integer 
            Status s = Status.Proccessing;
            int value = (int)s; // 2
            Status status = (Status)2; // Processing
            //
            // converting between enum and string
            string n = s.ToString();// Processing as string 
            Status status1 =(Status) Enum.Parse(typeof(Status), n);
            // safer version
            Enum.TryParse(n, out Status status2);
            Console.WriteLine(value);//2
            Console.WriteLine(status);//Processing
            Console.WriteLine(n);//Processing
            Console.WriteLine(status1);//Processing
            Console.WriteLine(status2);//Processing
            //////////////////
            string n1 = "Finished";
            if (Enum.TryParse(n1, out Status status3))
            {
                Console.WriteLine(status3);
            }

            if(Enum.IsDefined(typeof(Status), n1))
            {
                Console.WriteLine(Enum.Parse(typeof(Status),n1));
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
            // looping over enum items
            foreach (var statu in Enum.GetNames(typeof(Status)))
            {
                Console.WriteLine($"{statu} = {(int)Enum.Parse(typeof(Status), statu)}");
            }
            foreach (var statu in Enum.GetValues(typeof(Status)))
            {
                Console.WriteLine($"{statu} = {(int)statu}");
            }

        }
    }
    public enum Status // by default Enums are backed by an integral type (default = int) , First value = 0, then increments by 1
    {
        Pending=1,
        Proccessing,
        Finished
    }
    /*
     * An enum is a value type that defines a set of named constants, improving readability, type safety, and maintainability in code
       Enum = named constants
       Default = int starting from 0
       Can cast to/from int
       Use Flags for combinations
       Use Enum.TryParse for safety
     */

}
