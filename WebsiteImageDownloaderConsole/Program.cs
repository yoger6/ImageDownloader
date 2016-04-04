using System;
using System.Threading.Tasks;

namespace WebsiteImageDownloaderConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            var task = Task.Run( () => InputReader() );

            while ( true )
            {
            }
        }

        private static async void InputReader()
        {
            while ( true )
            {
                var url = ReadUrl();

                if (url == string.Empty)
                {
                    break;
                }

                try
                {
                    var website = await WebsiteFactory.GetWebsite( url );
                    ListImages( website );
                }
                catch (Exception e)
                {
                    Console.WriteLine( $"Invalid Url, try another one, here's the error: {e.Message}" );
                }
            }
        }

        private static void ListImages( Website website )
        {
            Console.WriteLine( $"Website found: {website.Name} with following images in it:" );

            foreach (var image in website.Images)
            {
                Console.WriteLine($"Name: {image.FileName}, Url: {image.OriginalUrl}, Path: {image.LocalPath}, Size: {image.Size}");
            }
        }

        private static string ReadUrl()
        {
            return Console.ReadLine();
        }
    }
}
