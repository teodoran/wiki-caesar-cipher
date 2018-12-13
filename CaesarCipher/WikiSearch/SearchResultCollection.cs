using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CaesarCipher.WikiSearch
{
    public class SearchResultCollection
    {
        private const string HorizontalLine = "-----------------------------------------------";
        private int _totalHits;
        private List<SearchResult> _searchResults;

        public SearchResultCollection(string jsonSearchResults)
        {
            var parsedJson = JObject.Parse(jsonSearchResults);

            _totalHits = parsedJson.TotalHits();
            _searchResults = parsedJson.SearchResults();
        }

        public SearchResult TopResult() => _searchResults.FirstOrDefault();

        public override string ToString()
        {
            var snippet = TopResult().Snippet
                .Replace("<span class=\"searchmatch\">", "")
                .Replace("</span>", "");
            
            var builder = new StringBuilder();
            builder
                .AppendFormat("Total number of hits: {0}, showing top result:", _totalHits)
                .AppendLine().AppendLine();
            
            builder
                .AppendFormat("{0}:", TopResult().Title)
                .AppendLine()
                .AppendLine(HorizontalLine)
                .AppendLine(snippet);

            return builder.ToString();
        }
    }
}