using System.Threading.Tasks;
using WebImageDownloader.WebsiteProcessing;

namespace WebImageDownloader.UrlProcessing
{
    public class ImageUrlValidator : IImageValidator
    {
        HttpHeadResponseRetrivier retrivier = new HttpHeadResponseRetrivier();

        public async Task<bool> IsValid( WebsiteImage image, Website origin )
        {
            return await ValidateUrl( image,origin );
        }

        protected async virtual Task<bool> ValidateUrl( WebsiteImage image, Website origin )
        {
            var validator = new UrlValidator(origin.Url);
            var url = validator.GetValidatedUrl( image.OriginalUrl );
            var header = await retrivier.GetHead( url );
            image.Size = header.Size;

            return header.Size > 0;
        }
    }

    public interface IImageValidator
    {
        Task<bool> IsValid( WebsiteImage image, Website origin);
    }
}
