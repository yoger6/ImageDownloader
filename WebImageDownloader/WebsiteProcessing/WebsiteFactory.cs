using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebImageDownloader.UrlProcessing;

namespace WebImageDownloader.WebsiteProcessing
{
    public static class WebsiteFactory
    {
        private const string UnnamedWebsiteTitle = "Unnamed";

        public static async Task<Website> GetWebsite( string url )
        {
            var validator = new UrlValidator();
            var confirmer = new AddressConfirmer();

            var validUrl = validator.GetValidatedUrl( url );
            if (!await confirmer.DoesUrlExist( validUrl ))
            {
                throw new WebException( $"Couldn't retrieve website: {url}" );
            }
            var website = new Website {Url = validUrl};
            var webRetriever = new WebsiteContentRetriever();
            var webContent = await webRetriever.GetSite( validUrl );

            website.Name = await GetTitle( webContent );
            var websiteImageFiller = new WebsiteImageFiller();

            await websiteImageFiller.FillWebsiteWithImages(website, webContent);

            return website;
        }


        private async static Task<string> GetTitle( string content )
        {
            var pattern = "<title>(.*?)</title>";

            return await Task.Run( () =>
            {
                var match = Regex.Match( content, pattern ).ToString();

                if (string.IsNullOrWhiteSpace( match ))
                {
                    return UnnamedWebsiteTitle;
                }
                
                return ExtractTitle( match );
            } );
        }

        private static string ExtractTitle( string match )
        {
            var titleStartIndex = match.LastIndexOf( "<title>", StringComparison.OrdinalIgnoreCase ) + 1;
            var titleEndIndex = match.IndexOf( "</title>", StringComparison.OrdinalIgnoreCase ) - 1;
            var titleLength = titleEndIndex - titleStartIndex;

            return match.Substring( titleStartIndex, titleLength );
        }
    }

    public class WebsiteImageFiller
    {
        public async Task FillWebsiteWithImages( Website website, string webContent )
        {
            var retriever = new WebsiteImageRetriever();
            var images = await retriever.ExtractImagesFromContentAsync( webContent );
            var urlValidator = new ImageUrlValidator();

            foreach (var image in images)
            {
                if ( await urlValidator.IsValid( image, website ))
                {
                    website.Images.Add( image );
                }    
            }
        }
     }
}