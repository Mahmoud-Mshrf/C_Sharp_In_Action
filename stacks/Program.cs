namespace Stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Command> Undo = new Stack<Command>();
            Stack<Command> Redo = new Stack<Command>();


            string line;
            while (true)
            {
                Console.WriteLine("Enter the url , exit to quit");
                line = Console.ReadLine().ToLower();
                if (line == "exit")
                    break;
                else if (line == "back")
                {
                    if (Undo.Count > 0)
                    {
                        var item = Undo.Pop();
                        Redo.Push(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (line == "forward")
                {
                    if (Redo.Count > 0)
                    {
                        var item = Redo.Pop();
                        Undo.Push(item);
                    }
                    else { continue; }
                }
                else
                {
                    Undo.Push(new Command(line));
                }
                Print("Back", Undo);
                Print("Forward", Redo);
            }
            Console.WriteLine(Undo.Peek());// this will return the last value in the stack but dont delete it from the stack
        }
        static void Print(string message, Stack<Command> commands)
        {
            Console.WriteLine($"{message}, history");
            Console.BackgroundColor = message.ToLower() == "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
            foreach (Command command in commands)
            {
                Console.WriteLine(command);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
    public class Command
    {
        private readonly DateTime CreationTime;
        private readonly string url;

        public Command(string url)
        {
            CreationTime = DateTime.Now;
            this.url = url;
        }
        public override string ToString()
        {
            return $"{this.CreationTime.ToString("yyyy-MM-dd hh:mm")} {this.url}";
        }
    }
}