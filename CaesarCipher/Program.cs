using System;
using CommandLine;
using CaesarCipher.WikiSearch;

namespace CaesarCipher
{
    public class Program
    {   
        static void Main(string[] args)
        {
            var client = new WebClient();
            var runner = new WikiCrypt(client);
            
            CommandLine.Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(options =>
                {
                    runner
                        .CryptWikiSearchResult(options, s => Console.WriteLine(s))
                        .GetAwaiter().GetResult();
                });
        }
    }
}
