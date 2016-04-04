using System;
using System.Net;
using System.Threading.Tasks;
using WebImageDownloader.WebsiteProcessing;

namespace WebsiteImageDownloaderTests
{
    public class WebsiteRetrieverStub : IWebsiteContentRetriever
    {
        public const string InvalidUrl = "Htsp://something,notevencom/";
        public const string PageWithNoImages = "http://noimageshere.com/";
        public const string PageWithOneImage= "http://herearesome.com/";

        public async Task<string> GetSite( string url )
        {
            switch (url)
            {
                default:
                    throw new ArgumentException("Stub doesn't support this yet.");
                case InvalidUrl:
                    throw new WebException("Url is invalid or doesn't exist");
                case PageWithNoImages:
                    return await Task.Run( () => "<body></body>" );
                case PageWithOneImage:
                    return await Task.Run( () => "<img src=\"imageurlhere.png\"/>" );
            }
        }
    }
}