using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebImageDownloader.Annotations;
using WebImageDownloader.WebsiteProcessing;

namespace WebImageDownloader
{
    public class ImageDownloader : IDownloader, INotifyPropertyChanged
    {
        private WebsiteImage _image;
        private int _progress;

        public event EventHandler ProgressChanged;

        public int Progress
        {
            get { return _progress; }
            private set
            {
                if (value == _progress) return;
                _progress = value;
                OnPropertyChanged();
            }
        }


        public ImageDownloader(WebsiteImage image)
        {
            _image = image;
        }
        
        private void DownloadProgressChanged( object sender, DownloadProgressChangedEventArgs e )
        {
            Progress = e.ProgressPercentage;

            UpdateFileSize( e.TotalBytesToReceive );
        }
        
        private void UpdateFileSize( long size )
        {
            if (_image.Size == 0)
            {
                _image.Size = size;
            }
        }

        public async Task Download()
        {
            if(Progress < 100)
            {
                var client = new WebClient();
                    client.DownloadProgressChanged += DownloadProgressChanged;
                    await client.DownloadFileTaskAsync( _image.OriginalUrl, GetPath() );
                
            }
        }

        private string GetPath()
        {
            var path = Path.Combine( _image.LocalPath, _image.FileName );
            if (!Directory.Exists( _image.LocalPath ))
            {
                Directory.CreateDirectory( _image.LocalPath );
            }

            return path;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
