using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SearchWikipedia.Model
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

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .AppendFormat("Total number of hits: {0}, showing top 10:", _totalHits)
                .AppendLine().AppendLine();
            
            foreach (var result in _searchResults)
            {
                builder
                    .AppendFormat("{0}:", result.Title)
                    .AppendLine()
                    .AppendLine(HorizontalLine);

                AppendSnippet(builder, result.Snippet);
            }

            return builder.ToString();
        }

        private void AppendSnippet(StringBuilder builder, string snippet)
        {
            var lineWidth = HorizontalLine.Length;
            var lineBuilder = new StringBuilder();
            var words = snippet
                .Replace("<span class=\"searchmatch\">", "")
                .Replace("</span>", "")
                .Split(" ");
            
            foreach (var word in words)
            {
                lineBuilder.Append(word).Append(" ");
                if (lineBuilder.Length > lineWidth)
                {
                    builder.AppendLine(lineBuilder.ToString());
                    lineBuilder.Clear();
                }
            }

            if (lineBuilder.Length > 0)
            {
                builder.AppendLine(lineBuilder.ToString());
            }

            builder.AppendLine();
        }
    }
}