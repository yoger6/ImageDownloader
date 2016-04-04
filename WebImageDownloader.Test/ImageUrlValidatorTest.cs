using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebImageDownloader.UrlProcessing;
using WebImageDownloader.WebsiteProcessing;

namespace WebsiteImageDownloaderTests
{
    [TestClass]
    public class ImageUrlValidatorTest
    {
        private ImageUrlValidator validator = new ImageUrlValidator();

        [TestMethod]
        public async Task ReturnsValidUrl()
        {
            var website = new Website() {Url = "http://google.com"};
            var image = new WebsiteImage() {OriginalUrl = "/images/nav_logo242.png" };
            var expectedValidationResult = "http://google.com/images/nav_logo242.png";

            var conf = await new AddressConfirmer().DoesUrlExist( expectedValidationResult );

            var validationResult = await validator.IsValid( image, website );
            Assert.IsTrue( conf );
            Assert.AreEqual( expectedValidationResult, image.OriginalUrl );
        }
    }
}