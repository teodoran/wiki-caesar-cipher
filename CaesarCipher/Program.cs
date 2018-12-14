using System;
using System.Threading.Tasks;
using CaesarCipher.WikiSearch;

namespace CaesarCipher
{
    public class Program
    {   
        /*
         * Async main is only available in C# v7.1 or greater
         * You can get this by setting <LangVersion>latest</LangVersion> in a <PropertyGroup>
         */
        static async Task Main(string[] args)
        {
            var client = new WebClient();
            var wikiCrypt = new WikiCrypt(client);
            await wikiCrypt.CryptWikiSearchResult(args, s => Console.WriteLine(s));
        }
    }
}
