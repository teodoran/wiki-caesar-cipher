using System.Threading.Tasks;

namespace CaesarCipher.WikiSearch
{
    public interface IWikipediaClient
    {
        Task<string> SearchAsync(string query);
    }
}