using System.Net;
using System.Threading.Tasks;

namespace WebImageDownloader.UrlProcessing
{
    public class HttpHeadResponseRetrivier
    {
        public int Timeout = 5000;

        public async Task<HeadResponseInformation> GetHead( string url )
        {
            var request = (HttpWebRequest) WebRequest.Create( url );
            request.Timeout = Timeout;
            request.Method = "HEAD";

            var response = await request.GetResponseAsync() as HttpWebResponse;
            var responseCode = response.StatusCode;
            response.Close();

            if (IsResponseCodeValid( responseCode ))
            {
                return new HeadResponseInformation {Size = response.ContentLength};
            }
            throw new WebException( $"Invalid response from {url}" );
        }


        private bool IsResponseCodeValid( HttpStatusCode statusCode )
        {
            var code = (int) statusCode;

            return code >= 100 && code <= 400;
        }
    }
}