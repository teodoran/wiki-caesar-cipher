using System;
using CommandLine;
using CaesarCipher.WikiSearch;

namespace CaesarCipher
{
    public class Program
    {   
        static void Main(string[] args)
        {
            var client = new WikipediaClient();
            var runner = new SearchCryptAndPrintResult(client);
            
            CommandLine.Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(options =>
                {
                    runner
                        .Run(options, s => Console.WriteLine(s))
                        .GetAwaiter().GetResult();
                });
        }
    }
}
