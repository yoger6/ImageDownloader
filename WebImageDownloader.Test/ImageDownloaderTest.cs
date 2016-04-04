using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebImageDownloader;
using WebImageDownloader.WebsiteProcessing;

namespace WebsiteImageDownloaderTests
{
    [TestClass]
    public class ImageDownloaderTest
    {
        private const string Url = "http://www.gry-online.pl/i/w/h1/186656674.jpg";
        private const string Path = "D:";
        private const string ExpectedPath = "D:\\186656674.jpg";
        private ImageDownloader downloader;

        
    }
}
