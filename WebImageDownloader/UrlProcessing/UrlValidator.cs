using System;
using System.Linq;

namespace WebImageDownloader.UrlProcessing
{
    public class UrlValidator
    {
        private string[] _optionalPrefixes = { "http://", "https://" };

        public UrlValidator()
        {
            
        }

        public UrlValidator(params string[] optionalPrefixes)
        {
            _optionalPrefixes = optionalPrefixes;
        }

        public string GetValidatedUrl( string url )
        {
            
            var containsPrefix = DoesUrlContainPrefixes(url);

            if (containsPrefix && IsUrlFrormatValid( url ))
            {
                return url;
            }

            return TryPrefixes(url);
        }

        private string TryPrefixes( string url )
        {
            foreach (var prefix in _optionalPrefixes)
            {
                var variant = prefix + url;
                if (IsUrlFrormatValid( variant ))
                {
                    return variant;
                }
            }

            throw new UriFormatException( $"{url} is not correct url" );
        }

        private bool IsUrlFrormatValid( string url )
        {
            Uri uri;

            if (Uri.TryCreate( url, UriKind.Absolute, out uri ))
            {
                return uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps;
            }

            return false;
        }

        private bool DoesUrlContainPrefixes(string url)
        {
            if (_optionalPrefixes.Any( url.Contains ))
            {
                return true;
            }

            return false;
        }
    }
}