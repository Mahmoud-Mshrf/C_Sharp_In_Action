namespace Indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ip = new IP("192.168.1.1");
            var ip2 = new IP(192, 168, 1, 1);
            Console.WriteLine(ip.Address);
            ip[1] = 193;
            Console.WriteLine(ip.Address);
        }
        
    }
    public class IP
    {
        
        private int[] segments = new int[4];
        public int this[int index]
        {
            get { return segments[index]; }
            set { segments[index] = value; }
        }
        public IP(string Address)
        {
            var segs = Address.Split(".");
            for(int i = 0; segments.Length > i; i++)
            {
                segments[i] = Convert.ToInt32(segs[i]);
            }
        }
        public IP(int segment1,int segment2,int segment3 , int segment4)
        {
            segments[0] = segment1;
            segments[1] = segment2;
            segments[2] = segment3;
            segments[3] = segment4;
        }
        public string Address => string.Join(".",segments);
    }
}
