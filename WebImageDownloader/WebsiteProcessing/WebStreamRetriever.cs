using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebImageDownloader.WebsiteProcessing
{
    public class WebStreamRetriever : IDisposable
    {
        private WebClient client = new WebClient();

        public async Task<Stream> GetStream( string websiteUrl )
        {
            return await client.OpenReadTaskAsync( websiteUrl );
        }
        
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}