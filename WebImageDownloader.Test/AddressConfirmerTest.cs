using System;
using System.CodeDom;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebImageDownloader.UrlProcessing;

namespace WebsiteImageDownloaderTests
{
    [TestClass]
    public class AddressConfirmerTest
    {
        private const string EmptyAddress = "";
        private const string InvalidAddress = "http://.com";
        private const string NotExistingAddress = "http://www.notme.com";
        private const string CorrectAddress = "http://google.com";
        private const string CorrectAddressWhenFixed = "google.com";

        private AddressConfirmer _confirmer;


        [TestInitialize]
        public void Initialize()
        {
            _confirmer = new AddressConfirmer();
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )]
        public async Task EmptyAddressThrowsException()
        {
            await _confirmer.DoesUrlExist( EmptyAddress );
        }

        [TestMethod]
        [ExpectedException( typeof( UriFormatException ) )]
        public async Task InvalidAddressThrowsException()
        {
            await _confirmer.DoesUrlExist( InvalidAddress );
        }

        [TestMethod]
        public async Task NotExistingAddressReturnsFalse()
        {
            var result = await _confirmer.DoesUrlExist( NotExistingAddress );

            Assert.IsFalse( result );
        }

        [TestMethod]
        public async Task CorrectAddressReturnsTrue()
        {
            var result = await _confirmer.DoesUrlExist( CorrectAddress );

            Assert.IsTrue( result );
        }

        [TestMethod]
        public async Task AdresCanBeFixedIfMissingPrefix()
        {
            var validator = new UrlValidator();
            var validUrl = validator.GetValidatedUrl( CorrectAddressWhenFixed );
            var result = await _confirmer.DoesUrlExist( validUrl );

            Assert.IsTrue( result );
        }
    }
}
