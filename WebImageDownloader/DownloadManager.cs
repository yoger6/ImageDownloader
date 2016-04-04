using System.Collections.ObjectModel;

namespace WebImageDownloader
{
    public class DownloadManager
    {
        private static DownloadManager _instance;
        public static DownloadManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DownloadManager();
                }
                return _instance;
            }
        }
        
        public ObservableCollection<WebsiteDownloader> Downloaders { get; }


        private DownloadManager()
        {
            Downloaders = new ObservableCollection<WebsiteDownloader>();
        }


        public void AddDownloader( WebsiteDownloader downloader )
        {
            Downloaders.Add( downloader );
        }
    }
}
