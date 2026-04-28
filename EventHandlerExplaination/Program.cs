namespace EventHandlerExplaination
{
    // *important*:Although Action or custom delegates can be used for events, the recommended .NET pattern is EventHandler and EventHandler<T> with EventArgs because they provide consistency, extensibility, and clear intent.

    internal class Program
    {

        static void Main(string[] args)
        {
            var channel = new YoutubeChannel();
            var sub1 = new Subscriber();
            var sub2 = new Subscriber();    
            sub1.Subscribe(channel);
            sub2.Subscribe(channel);
            channel.UploadVideo("First video on the channel");
            // channel.videoUploaded = null; // wrong in case of using delegate , but corrected by using event 
            // channel.videoUploaded("Second video on the channel");// wrong in case of using delegate , but corrected by using event 
        }
    }
    public class YoutubeChannel
    {
        public event  EventHandler<string> videoUploaded;
        public void UploadVideo(string title)
        {
            Console.WriteLine($"Video :{title} Uploaded");
            videoUploaded?.Invoke(this,title);
        }
    }
    public class Subscriber
    {
        public void Subscribe(YoutubeChannel channel)
        {
            channel.videoUploaded += Watch;
        }

        public void Watch(object sender ,string title)// sender represents the class that invoke the eventhandler in this case the channel
        {
            Console.WriteLine($"user watched {title}");
        }
    }


    /* using non-generic EventHandler that has no data
     internal class Program
    {
        static void Main(string[] args)
        {
            var channel = new YoutubeChannel();
            var sub1 = new Subscriber();
            var sub2 = new Subscriber();    
            sub1.Subscribe(channel);
            sub2.Subscribe(channel);
            channel.UploadVideo("First video on the channel");
            // channel.videoUploaded = null; // wrong in case of using delegate , but corrected by using event 
            // channel.videoUploaded("Second video on the channel");// wrong in case of using delegate , but corrected by using event 
        }
    }
    public class YoutubeChannel
    {
        public event  EventHandler videoUploaded;
        public void UploadVideo(string title)
        {
            Console.WriteLine($"Video :{title} Uploaded");
            videoUploaded?.Invoke(this,EventArgs.Empty);
        }
    }
    public class Subscriber
    {
        public void Subscribe(YoutubeChannel channel)
        {
            channel.videoUploaded += Watch;
        }

        public void Watch(object sender ,EventArgs e)// sender represents the class that invoke the eventhandler in this case the channel
        {
            Console.WriteLine($"user watched ");
        }
    }
     */
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    /* using event based on delegate i had created
         internal class Program
    {
        static void Main(string[] args)
        {
            var channel = new YoutubeChannel();
            var sub1 = new Subscriber();
            var sub2 = new Subscriber();    
            sub1.Subscribe(channel);
            sub2.Subscribe(channel);
            channel.UploadVideo("First video on the channel");
            // channel.videoUploaded = null; // wrong in case of using delegate , but corrected by using event 
            // channel.videoUploaded("Second video on the channel");// wrong in case of using delegate , but corrected by using event 
        }
    }
    public delegate void VideoUploaded(string title);
    public class YoutubeChannel
    {
        public event  VideoUploaded videoUploaded;
        public void UploadVideo(string title)
        {
            Console.WriteLine($"Video :{title} Uploaded");
            videoUploaded?.Invoke(title);
        }
    }
    public class Subscriber
    {
        public void Subscribe(YoutubeChannel channel)
        {
            channel.videoUploaded += Watch;
        }

        public void Watch(string title)
        {
            Console.WriteLine($"user watched {title}");
        }
    }
     */
}

