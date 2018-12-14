using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaesarCipher.WikiSearch
{
    public class WebClient : IWebClient
    {
        private HttpClient _client;

        public WebClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetContent(Uri url)
        {
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}