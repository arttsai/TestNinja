using System.Net;

namespace TestNinja.Mocking
{
    public interface IDownloader
    {
        void DownloadFile(string customerName, string installerName);
    }

    public class Downloader : IDownloader
    {
        private string _setupDestinationFile;

        public void DownloadFile(string customerName, string installerName)
        {
            var client = new WebClient();
            client.DownloadFile(
                string.Format("http://example.com/{0}/{1}", customerName, installerName),
                _setupDestinationFile
            );
        }
    }

    public class InstallerHelper 
    {
        private readonly IDownloader _downloader;
        
        public InstallerHelper(IDownloader downloader)
        {
            _downloader = downloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _downloader.DownloadFile(customerName, installerName);
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}