using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SearchWikipedia.Client
{
    public interface IWikipediaClient
    {
        string Search(string query);
        Task<string> SearchAsync(string query);
    }
}