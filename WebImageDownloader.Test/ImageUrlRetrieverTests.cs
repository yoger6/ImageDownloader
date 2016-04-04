using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebImageDownloader.Exceptions;
using WebImageDownloader.WebsiteProcessing;

namespace WebsiteImageDownloaderTests
{
    [TestClass]
    public class ImageUrlRetrieverTests
    {
        private WebsiteImageRetriever retriever;
        private WebsiteRetrieverStub webRetrieverStub;

        public ImageUrlRetrieverTests()
        {
            webRetrieverStub = new WebsiteRetrieverStub();
            retriever = new WebsiteImageRetriever( );
        }
        [TestMethod]
        [ExpectedException(typeof(NoImagesFoundException))]
        public async Task NoImageUrlToRetrieveThrowsException() {
            await retriever.ExtractImagesFromContentAsync( WebsiteRetrieverStub.PageWithNoImages );
        }
        
        [TestMethod]
        public async Task ImageUrlsFoundReturnListOfThoseUrls()
        {
            var data = await webRetrieverStub.GetSite( WebsiteRetrieverStub.PageWithOneImage );
            var urls = await retriever.ExtractImagesFromContentAsync( data );

            Assert.AreEqual( 1, urls.Count );
        }
    }
}
