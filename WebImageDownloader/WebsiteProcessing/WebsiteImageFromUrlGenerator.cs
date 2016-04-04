using System.Collections.Generic;
using System.Linq;

namespace WebImageDownloader.WebsiteProcessing
{
    public class WebsiteImageFromUrlGenerator
    {
        public static IEnumerable<WebsiteImage> Generate( List<string> urls )
        {
            return urls.Select( url => new WebsiteImage
            {
                OriginalUrl = url,
                LocalPath = string.Empty,
                FileName = GetName( url ),
                Size = -1
            } );
        }

        private static string GetName( string url )
        {
            return url.LastElementFromSplit( '/' );
        }
    }
}