using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;

namespace CaesarCipher
{   
    public class Program
    {
        static void RunCryptAndPrintResults(CommandLineOptions options)
        {
            if (!File.Exists(options.InputFile))
            {
                Console.WriteLine($"{ options.InputFile } is not a file");
                return;
            }

            var cryptedLines = File
                .ReadLines(options.InputFile)
                .CryptLines(options.Shift, options.Decrypt);

            foreach (var line in cryptedLines)
            {
                Console.WriteLine(line);
            }
        }
        
        static void Main(string[] args)
        {
            CommandLine.Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(RunCryptAndPrintResults);
        }
    }
}
