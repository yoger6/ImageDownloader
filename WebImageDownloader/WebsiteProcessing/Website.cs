using System.Collections.ObjectModel;

namespace WebImageDownloader.WebsiteProcessing
{
    public class Website
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public ObservableCollection<WebsiteImage> Images { get; set; }
        
        public void SetImagePath( string path )
        {
            foreach (var image in Images)
            {
                image.LocalPath = path;
            }
        }
    }
}