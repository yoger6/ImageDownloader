using System;
using System.Windows.Input;
using WebImageDownloader;

namespace WebsiteImageDownload
{
    public class DownloadCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return true;
            return GetDownloader( parameter ).Progress < 100;
        }

        public virtual void Execute( object parameter )
        {
            GetDownloader( parameter ).Download();
        }

        private IDownloader GetDownloader(object parameter)
        {
            var downloader = parameter as IDownloader;
            if (downloader == null)
            {
                throw new ArgumentException("Parameter must be of type IDownloader");
            }

            return downloader;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }
    }
}
