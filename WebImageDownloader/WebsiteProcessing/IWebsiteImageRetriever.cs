using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebImageDownloader.WebsiteProcessing
{
    public interface IWebsiteImageRetriever
    {
        Task<IList<WebsiteImage>> ExtractImagesFromContentAsync( string websiteContent );
    }
}