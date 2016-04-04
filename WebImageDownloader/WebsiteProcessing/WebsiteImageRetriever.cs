using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebImageDownloader.Exceptions;

namespace WebImageDownloader.WebsiteProcessing
{
    public class WebsiteImageRetriever : IWebsiteImageRetriever
    {
        public string[] ValidExtensions { get; set; } = {"jpg", "gif", "png"};
    
        public async Task<IList<WebsiteImage>> ExtractImagesFromContentAsync( string websiteContent )
        {
            var urls = await GetUrlsFromDataAsync( websiteContent );
            var list = urls.ToList();
            if (!list.Any())
            {
                throw new NoImagesFoundException( "Website contains no images" );
            }

            return WebsiteImageFromUrlGenerator.Generate( list ).ToList();
        } 
        
        private async Task<IEnumerable<string>> GetUrlsFromDataAsync( string websiteContent )
        {
            var pattern = "src=\"(.*?)\"";

            return await Task.Run( () =>
            {
                var regex = Regex.Matches( websiteContent, pattern );

                return from object match
                       in regex
                       where IsImage(match)
                       select ExtractUrl( match );
            } );
        }

        private bool IsImage( object match )
        {
            var extensionPart = match.ToString().LastElementFromSplit( '.' );

            if (ValidExtensions.Any( validExtension => extensionPart.Contains( validExtension ) ))
            {
                return true;
            }

            return false;
        }

        private string ExtractUrl( object match )
        {
            var matchString = match.ToString();
            var urlBeginsAt = matchString.IndexOf( '"' ) + 1;
            var charsToTrimAtEnd = 1;
            var urlLength = matchString.Length - urlBeginsAt - charsToTrimAtEnd;

            return matchString.Substring( urlBeginsAt, urlLength );
        }
    }
}
