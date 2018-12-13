using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CaesarCipher.WikiSearch
{
    public class WikipediaClient : IWikipediaClient
    {
        private HttpClient _client;

        public WikipediaClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            var url = SearchUrl(query);
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        private static Uri SearchUrl(string query)
        {
            var queryParams = HttpUtility.ParseQueryString("action=query&format=json&list=search&utf8=1");
            queryParams["srsearch"] = query;

            var builder = new UriBuilder
            {
                Scheme = "https",
                Host = "www.wikipedia.org",
                Path = "/w/api.php",
                Query = queryParams.ToString()
            };

            return builder.Uri;
        }
    }
}