using System;
using System.Threading.Tasks;

namespace CaesarCipher.WikiSearch
{
    public interface IWebClient
    {
        Task<string> GetContent(Uri url);
    }
}