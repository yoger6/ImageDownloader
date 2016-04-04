using System;
using System.Threading.Tasks;

namespace WebImageDownloader
{
    public interface IDownloader
    {
        event EventHandler ProgressChanged; 
        int Progress { get; }
        Task Download();
    }
}