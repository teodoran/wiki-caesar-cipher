using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaesarCipher.WikiSearch;

namespace CaesarCipher
{
    public class SearchCryptAndPrintResult
    {
        private readonly IWikipediaClient _client;

        public SearchCryptAndPrintResult(IWikipediaClient client)
        {
            _client = client;
        }

        public async Task Run(CommandLineOptions options, Action<string> print)
        {
            var query = options.Query;
            print($"Searching for { query }...");

            var json = await _client.SearchAsync(query);
            print(json);
            var results = new SearchResultCollection(json);

            print(results.ToString());
            
            var topSnippet = results.TopResult().Snippet;
            var lines = new List<string> { topSnippet };
            var cryptedLines = lines.CryptLines(options.Shift, options.Decrypt);

            print("Encrypted:");
            foreach (var line in cryptedLines)
            {
                print(line);
            }
        }
    }
}