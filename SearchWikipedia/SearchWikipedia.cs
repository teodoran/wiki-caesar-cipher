using System;
using SearchWikipedia.Model;
using SearchWikipedia.Client;

namespace SearchWikipedia
{
    public class SearchWikipedia
    {
        private IWikipediaClient _client;

        public SearchWikipedia(IWikipediaClient client)
        {
            _client = client;
        }

        public void ReadSearchPrint(Func<string> read, Action<string> print, Func<string, bool> quit)
        {
            var input = read();
            
            if (quit(input))
            {
                return;
            }

            print(SearchingFor(input));
                        
            var json = _client.Search(input);
            var results = new SearchResultCollection(json);

            print(results.ToString());

            ReadSearchPrint(read, print, quit);
        }

        private string SearchingFor(string query)
        {
            return $"Searching for { query }...";
        }
    }
}