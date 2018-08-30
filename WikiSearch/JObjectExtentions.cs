using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WikiSearch
{
    internal static class JObjectExtentions
    {
        public static int TotalHits(this JObject parsedJson)
        {
            try
            {
                return parsedJson["query"]["searchinfo"]["totalhits"].ToObject<int>();
            }
            catch (System.Exception)
            {
                throw new ArgumentException("Number query.searchinfo.totalhits is missing from parsed JObject.");
            }
        }

        public static List<SearchResult> SearchResults(this JObject parsedJson)
        {
            try
            {
                return parsedJson["query"]["search"].Select(qs => qs.ToObject<SearchResult>()).ToList();
            }
            catch (System.Exception)
            {
                throw new ArgumentException("List query.search is missing from parsed JObject.");
            }
        }
    }
}