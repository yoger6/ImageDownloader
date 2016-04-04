using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebImageDownloader.Annotations;
using WebImageDownloader.WebsiteProcessing;

namespace WebImageDownloader
{
    public class WebsiteDownloader : IDownloader, INotifyPropertyChanged
    {
        public event EventHandler ProgressChanged;

        public int Progress
        {
            get
            {
                var sum = ImageDownloaders.Sum( x => x.Progress );
                return sum / ImageDownloaders.Count;
            }
        }
        public Website Website { get; }

        public ObservableCollection<ImageDownloader> ImageDownloaders { get; }


        public WebsiteDownloader( Website website )
        {
            Website = website;
            ImageDownloaders = new ObservableCollection<ImageDownloader>();
            AssignImageDownloaders();
        }


        private void AssignImageDownloaders()
        {
            foreach (var image in Website.Images)
            {
                var downloader = new ImageDownloader( image );
                ImageDownloaders.Add( downloader );
                downloader.ProgressChanged += ( sender, i ) => OnProgressChanged();
            }
        }

        public async Task Download()
        {
            foreach (var downloader in ImageDownloaders)
            {
                await downloader.Download();
            }
        }

        protected virtual void OnProgressChanged( )
        {
            OnPropertyChanged( nameof( Progress ) );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}