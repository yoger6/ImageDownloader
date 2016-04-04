using System.Threading.Tasks;

namespace WebImageDownloader.WebsiteProcessing
{
    public interface IWebsiteContentRetriever
    {
        Task<string> GetSite( string url );
    }
}