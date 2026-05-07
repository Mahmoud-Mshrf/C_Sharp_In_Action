namespace Attributes
{
    public class UpdateProcessor 
    {
        // Here we mark Download Method as obsolete this mean that this method is no longer in use and mark it with the above message
        [Obsolete("This Method will be Unsupported In The Next Realease Because Will Replaced By DownloadAndInstall Method")]
        public static void Download(Update[] updates)
        {
            foreach (Update update in updates)
            {
                Console.WriteLine($"Downloading {update}");
            }
        }
        public static void Install(Update[] updates)
        {
            foreach (Update update in updates)
            {
                Console.WriteLine($"Instaling {update}");
            }
        }
        public static void DownloadAndInstall(Update[] updates)
        {
            foreach (Update update in updates)
            {
                Console.WriteLine($"Downloading {update}");
                Console.WriteLine($"Instaling {update}");

            }
        }
    }
}