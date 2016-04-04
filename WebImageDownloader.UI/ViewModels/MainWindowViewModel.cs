using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebImageDownloader;
using WebImageDownloader.Annotations;
using WebImageDownloader.UrlProcessing;
using WebImageDownloader.WebsiteProcessing;

namespace WebsiteImageDownload.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string SavePath { get; set; } = "D:\\Websites\\";
        public ObservableCollection<WebsiteDownloader> Websites => DownloadManager.Instance.Downloaders;

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                if (value == _url) return;
                _url = value;
                OnPropertyChanged();
            }
        }

        private ICommand _downloadCommand;
        private ICommand _addWebsiteCommand;
        public ICommand DownloadCommand {
            get
            {
                if (_downloadCommand == null)
                {
                    _downloadCommand = new DownloadCommand();
                }
                return _downloadCommand;
            }
        }
        public ICommand AddWebsiteCommand
        {
            get
            {
                if (_addWebsiteCommand == null)
                {
                    _addWebsiteCommand = new RelayCommand( AddWebsite);
                }
                return _addWebsiteCommand;
            }
        }
        
        private void AddWebsite( object o )
        {
            Task.Run( async () =>
            {
                try
                {
                    var website = await WebsiteFactory.GetWebsite( Url );
                    website.SetImagePath( SavePath );
                    var downloader = new WebsiteDownloader( website );

                    Application.Current.Dispatcher.Invoke( () =>
                    {
                        DownloadManager.Instance.AddDownloader( downloader );
                    } );
                }
                catch (Exception e)
                {
                    MessageBox.Show( e.Message );
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
