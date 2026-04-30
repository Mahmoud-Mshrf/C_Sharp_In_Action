namespace FlagEnumExample
{
    using System;

    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        Delete = 8
    }

    class Program
    {
        static void Main()
        {
            Permissions user = Permissions.Read | Permissions.Write;

            Console.WriteLine($"Initial: {user}");

            // Check
            if ((user & Permissions.Read) == Permissions.Read)
                Console.WriteLine("Can Read");

            // Add
            user |= Permissions.Execute;
            Console.WriteLine($"After Add Execute: {user}");

            // Remove
            user &= ~Permissions.Write;
            Console.WriteLine($"After Remove Write: {user}");

            // Toggle
            user ^= Permissions.Execute;
            Console.WriteLine($"After Toggle Execute: {user}");

            // Reset
            user = Permissions.None;
            Console.WriteLine($"After Reset: {user}");
        }
    }
}
