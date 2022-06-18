using System.Net;
using NSubstitute;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        [Test]
        public void DownloadInstaller_WhenDownloadFileSuccess_ReturnTrue()
        {
            int counter = 0; 
            var downloader = Substitute.For<IDownloader>();
            downloader.When(x => x.DownloadFile(Arg.Any<string>(), Arg.Any<string>()))
                .Do(x => counter++);

            var installHelper = new InstallerHelper(downloader);
            var result = installHelper.DownloadInstaller("customerName", "installerName");
            
            Assert.IsTrue(result);
        }

        [Test]
        public void DownloadInstaller_WhenDownloadFileException_ReturnFalse()
        {
            int counter = 0; 
            var downloader = Substitute.For<IDownloader>();
            downloader.When(x => x.DownloadFile(Arg.Any<string>(), Arg.Any<string>()))
                .Do(x => throw new WebException());

            var installHelper = new InstallerHelper(downloader);
            var result = installHelper.DownloadInstaller("customerName", "installerName");
            
            Assert.IsFalse(result);
        }
        
    }
}