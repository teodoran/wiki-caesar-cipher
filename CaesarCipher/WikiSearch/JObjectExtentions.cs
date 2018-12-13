using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CaesarCipher.WikiSearch
{
    internal static class JObjectExtentions
    {
        public static int TotalHits(this JObject parsedJson)
        {
            return parsedJson["query"]["searchinfo"]["totalhits"].ToObject<int>();
        }

        public static List<SearchResult> SearchResults(this JObject parsedJson)
        {
            return parsedJson["query"]["search"].Select(qs => qs.ToObject<SearchResult>()).ToList();
        }
    }
}