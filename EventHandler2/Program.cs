namespace EventHandler2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channel = new YoutubeChannel("MrBeast");
            var sub1 = new Subscriber();
            var sub2 = new Subscriber();
            sub1.Subscribe(channel);
            sub2.Subscribe(channel);
            channel.UploadVideo("#01-ASP.Net_Core",10);
            // channel.videoUploaded = null; // wrong in case of using delegate , but corrected by using event 
            // channel.videoUploaded("Second video on the channel");// wrong in case of using delegate , but corrected by using event 
        }
    }
    public class YoutubeChannel
    {
        public string ChannelName { get; set; }

        public YoutubeChannel(string channelName)
        {
            ChannelName = channelName;
        }

        public event EventHandler<VideoInfo> videoUploaded;
        public void UploadVideo(string title,int durationInMinutes)
        {
            Console.WriteLine($"Video :{title} Uploaded in legnth={durationInMinutes} minutes");
            videoUploaded?.Invoke(this, new VideoInfo {Title=title,DurationInMinutes=durationInMinutes});
        }
    }
    public class VideoInfo:EventArgs// its a best-practice that the class we created to store the data inherit from EventArgs
    {
        public string Title {  get; set; }
        public int DurationInMinutes { get; set; }
    }
    public class Subscriber
    {
        public void Subscribe(YoutubeChannel channel)
        {
            channel.videoUploaded += Watch;
        }

        public void Watch(object sender,VideoInfo info)// sender represents the class that invoke the eventhandler in this case the channel
        {
            Console.WriteLine($"user watched {info.Title} its duration in minutes = {info.DurationInMinutes} that uploaded by {((YoutubeChannel) sender).ChannelName}");
        }
    }

}
