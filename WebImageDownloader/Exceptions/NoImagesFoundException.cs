using System;

namespace WebImageDownloader.Exceptions
{
    public class NoImagesFoundException : Exception
    {
        public NoImagesFoundException( string message )
        : base( message )
        {
        }
    }
}
