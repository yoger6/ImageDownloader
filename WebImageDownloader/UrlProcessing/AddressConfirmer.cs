using System;
using System.Threading.Tasks;

namespace WebImageDownloader.UrlProcessing
{
    public class AddressConfirmer
    {
        private HttpHeadResponseRetrivier _responseRetrivier = new HttpHeadResponseRetrivier();

        public async Task<bool> DoesUrlExist( string url )
        {
            if (string.IsNullOrWhiteSpace( url ))
            {
                throw new ArgumentException( $"{nameof(url)} parameter must contain some address to check" );
            }

            var result = await CanPageBeReached( url );

            return result;
        }

        private async Task<bool> CanPageBeReached( string url )
        {
            var head = await _responseRetrivier.GetHead( url );
            return head.Size > 0;
        }
    }

    public class HeadResponseInformation
    {
        private static EmptyHeadResponseInformation _empty;

        public static EmptyHeadResponseInformation Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new EmptyHeadResponseInformation();
                }
                return _empty;
            }
        }

        public long Size { get; set; }
    }

    public sealed class EmptyHeadResponseInformation : HeadResponseInformation
    {
        internal EmptyHeadResponseInformation()
        {
            Size = 0;
        }
    }
}