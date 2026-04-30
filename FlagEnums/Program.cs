namespace FlagEnums
{
    /*
     use the [Flags] attribute to indicate combinable values; always define a None = 0 value as the default;
     assign values as powers of two (1, 2, 4, 8, 16…) so each flag occupies a unique bit; 
     combine values using the bitwise OR | operator; 
     check for a flag using & (AND) comparison or HasFlag;
     remove a flag using & ~ (AND with NOT); toggle a flag using ^ (XOR);
     expect readable string output (e.g., "Read, Write") only when [Flags] is applied;
     remember that without [Flags] combined values print as numbers;
     avoid overlapping values or non-power-of-two assignments unless intentional;
     and prefer bitwise checks over HasFlag in performance-critical code.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Permissions userPermissions = Permissions.Read | Permissions.Write;
            /*
             0001 (Read)
             0010 (Write)
             -----------
             0011 (Read + Write)
             */
            Console.WriteLine(userPermissions);// Read , Write
            // check if a permission exists
            if (userPermissions.HasFlag(Permissions.Read))
            {
                Console.WriteLine("User can read");
            }
            // do the same as following also check if a permission exists
            if ((userPermissions & Permissions.Write) == Permissions.Write)
            {
                Console.WriteLine("User can write");
            }
            // add a permission
            userPermissions |= Permissions.Execute;
            Console.WriteLine(userPermissions);// Read , Write , Execute
            // remove a permission
            userPermissions &= ~Permissions.Write;// Read , Execute

            // Toggle permission
            userPermissions ^= Permissions.Execute; // if has the permission remove it , if not have add it

            // reset all permissions
            userPermissions = Permissions.None;


        }
    }
    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,   // 0001
        Write = 2,   // 0010
        Execute = 4,   // 0100
        Delete = 8    // 1000
    }
}
