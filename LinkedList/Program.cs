namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YVideo[] yVideos = { new YVideo("YTV1", "Stack", new TimeSpan(00, 30, 00)),
                                 new YVideo("YTV2", "Queue", new TimeSpan(00, 25, 00)),
                                 new YVideo("YTV3", "List", new TimeSpan(00, 28, 00)),
                                 new YVideo("YTV4", "Dictionary", new TimeSpan(00, 20, 00)),
                                 new YVideo("YTV5", "LinkedList", new TimeSpan(00, 40, 00))
                               };
            LinkedList<YVideo> PlayList = new LinkedList<YVideo>(yVideos);// this is the first way to add elements to the LinkedList
            Print("DataStructures", PlayList);
            var v1 = new YVideo("YTV4", "Dictionary", new TimeSpan(00, 20, 00));
            var v2 = new YVideo("YTV5", "LinkedList", new TimeSpan(00, 40, 00));
            var v3 = new YVideo("YTV1", "Stack", new TimeSpan(00, 30, 00));
            var v4 = new YVideo("YTV2", "Queue", new TimeSpan(00, 25, 00));
            var v5 = new YVideo("YTV3", "List", new TimeSpan(00, 28, 00));
            LinkedList<YVideo> yVideos1 = new LinkedList<YVideo>();
            yVideos1.AddFirst(v1);// adding elements to the LinkedList using AddFirst at the beginning of the LinkedList
            yVideos1.AddAfter(yVideos1.First, v2);// adding elements to the LinkedList using AddAfter after the specified node
            var node3 = new LinkedListNode<YVideo>(v3);// creating a node to add it to the LinkedList
            yVideos1.AddAfter(yVideos1.First.Next, node3);// adding elements to the LinkedList using AddAfter after the specified node
            yVideos1.AddLast(v5);// adding elements to the LinkedList using AddLast at the end of the LinkedList
            yVideos1.AddBefore(yVideos1.Last, v4);// adding elements to the LinkedList using AddBefore before the specified node
            yVideos1.Remove(v3);// removing the specified element from the LinkedList
            yVideos1.RemoveFirst();// removing the first element from the LinkedList
            yVideos1.RemoveLast();// removing the last element from the LinkedList
        }
        static void Print(string Title, LinkedList<YVideo> list)
        {
            Console.WriteLine($"┌{Title}");
            foreach (YVideo video in list)
            {
                Console.WriteLine(video);
            }
            Console.WriteLine("└");
        }
    }
    public class YVideo
    {
        private string id;
        private string name;
        private TimeSpan duration;

        public YVideo(string id, string name, TimeSpan duration)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
        }
        public override string ToString()
        {
            return $"├── {name} ({duration}) \n│\twww.youtube.com/{id}";
        }
    }
}