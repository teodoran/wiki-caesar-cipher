using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using CommandLine;
using CaesarCipher.WikiSearch;

namespace CaesarCipher
{
    public class WikiCrypt
    {
        private readonly IWebClient _client;

        public WikiCrypt(IWebClient client)
        {
            _client = client;
        }

        public async Task CryptWikiSearchResult(string[] args, Action<string> print)
        {
            await CommandLine.Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .MapResult(options =>
                {
                    return CryptWikiSearchResult(options, print);
                }, err => Task.CompletedTask);
        }

        private async Task CryptWikiSearchResult(CommandLineOptions options, Action<string> print)
        {
            var query = options.Query;
            print($"Searching for { query }...");

            var url = SearchUrl(query);
            var json = await _client.GetContent(url);
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

        private Uri SearchUrl(string query)
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