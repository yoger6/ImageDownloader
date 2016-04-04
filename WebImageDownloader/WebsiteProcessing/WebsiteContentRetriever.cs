using System.IO;
using System.Threading.Tasks;

namespace WebImageDownloader.WebsiteProcessing
{
    public class WebsiteContentRetriever : IWebsiteContentRetriever
    {
        public async Task<string> GetSite( string url )
        {
            using (var streamRetriever = new WebStreamRetriever())
            {
                using (var stream = await streamRetriever.GetStream( url ))
                {
                    using (var reader = new StreamReader( stream ))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }
    }
}