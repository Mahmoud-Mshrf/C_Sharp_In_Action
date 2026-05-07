namespace StructExplanation
{
    internal class Program
    {
        // ***  Comparison Between Struct And Class :
        // [1]  Both is user defined type
        // [2]  Both can have a Constructor
        // [3]  Class can have a Parameterless Constructor(constructor with no parameters)
        // [4]  Struct can't have a Parameterless Constructor(should have parameters on the constructor) *
        // [5]  Both can have Fields
        // [6]  Class can have initial values to its fields
        // [7]  Struct can't have initial values to its fields , can have constant values only so it will have values *
        // [8]  Both can have Methods 
        // [9]  Both can have Properties
        // [10] Both can have Indexers
        // [11] Both can have Events
        // [12] Both can have Operator Overlaoding
        // [13] Class can have Finalizer(Destroyer)
        // [14] Struct can't have Finalizer(Destroyer) *
        // [15] Class support Inheritance
        // [16] Struct doesn't support Inheritance *
        // [17] Both Implicitly inherit from Object Class
        // [18] Class is recommended for large data
        // [19] Struct isn't recommended for large data *
        // [20] Struct has a maximum size 16 Byte so its not favorable to use string in it  *
        // [21] Class is a Reference Type
        // [22] Struct is a Value Type *
        // [23] Class To make an object from it new() is Mandatory(ضرورى)
        // [24] Struct to make an object from in new() is Optional if it doesn't have fields in it *
        // [25] if Struct have fields on it so we must use new() Or we must give a value to this fields (initialize the fields) *
        // [26] Class is Mutable 
        // [27] Struct is Immuatable  *
        // sumarry:
        // when you change the value of fields of the struct you this is doesn't change in fact this ignore the old value and make a new instance of this field contain the new value
        // all the value type like int , double , float its in fact a struct *

        static void Main(string[] args)
        {
            DigitalSize digitalSize = new DigitalSize(1005022347264);
            Console.WriteLine(digitalSize.Byte);
            Console.WriteLine(digitalSize.KB);
            Console.WriteLine(digitalSize.MB);
            Console.WriteLine(digitalSize.GB);
            Console.WriteLine(digitalSize.TB);
            //digitalSize.AddByte(8);// this isn't make any change because the struct is immutable 
            digitalSize = digitalSize.AddByte(8);// this make digitalsize from zero with the new value and don't edit the old value
            Console.WriteLine(digitalSize.Byte);
            DigitalSize digitalSize2 = digitalSize.AddByte(8);
            Console.WriteLine(digitalSize2.Byte);
            Console.WriteLine(digitalSize2.MB);
            Console.WriteLine(digitalSize2.KB);

        }

    }
    struct DigitalSize
    {
        private long bit;
        // here i make properties that return the number of (mb,kb,gb,tb) that equal to the number of given bits 
        public string Bit => $"{(bit / bitsInBit):N0}  Bit";
        public string Byte => $"{(bit / bitsInByte):N0}  Byte";
        public string KB => $"{(bit / bitsInKB):N0}  KB";
        public string MB => $"{(bit / bitsInMB):N0}  MB";
        public string GB => $"{(bit / bitsInGB):N0}  GB";
        public string TB => $"{(bit / bitsInTB):N0}  TB";

        // here we declare some constants 
        private const long bitsInBit = 1;
        private const long bitsInByte = 8;
        private const long bitsInKB = bitsInByte * 1024;
        private const long bitsInMB = bitsInKB * 1024;
        private const long bitsInGB = bitsInMB * 1024;
        private const long bitsInTB = bitsInGB * 1024;
        // this Methods to 
        public DigitalSize(long initialValue)
        {
            this.bit = initialValue;
        }
        public DigitalSize AddBit(long bit)
        {
            return Add(bit, bitsInBit);
        }
        public DigitalSize AddByte(long Byte)
        {
            return Add(Byte, bitsInByte);
        }
        public DigitalSize AddKB(long KB)
        {
            return Add(KB, bitsInKB);
        }
        public DigitalSize AddMB(long MB)
        {
            return Add(MB, bitsInMB);
        }
        public DigitalSize AddGB(long GB)
        {
            return Add(GB, bitsInGB);
        }
        public DigitalSize AddTB(long TB)
        {
            return Add(TB, bitsInTB);
        }
        private DigitalSize Add(long value, long scale)
        {
            return new DigitalSize(value * scale);
        }

    }
    readonly struct Age
    {
        public readonly int Years;
        public readonly int Months;
        public readonly int Days;
        public Age(int years, int months, int days)
        {
            this.Years = years;
            this.Months = months;
            this.Days = days;
        }
    }
    /*
     * Structs are not necessarily immutable, but mutable structs are evil.
       Creating mutable structs can lead to all kinds of strange behavior in your application and, therefore,
       they are considered a very bad idea (stemming from the fact that they look like a reference type but are actually a value type and will be copied whenever you pass them around).
     */
    /* Summary:
     * Struct is not recommended to use it with mutable fields
     * struct can be mutable but it's not recommended , so we assume that the struct is immutable
     */
}