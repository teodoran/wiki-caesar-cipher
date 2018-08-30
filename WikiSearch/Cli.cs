using System;

namespace WikiSearch
{
    public class Cli
    {
        public static void PromptWelcomeMessage()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Search Wikipedia! (Enter on blank line to quit)");
            Console.WriteLine("===============================================");
            Console.WriteLine();
        }
        
        public static void Main()
        {
            PromptWelcomeMessage();
            
            var client = new WikipediaClient();
            var wikiSearch = new WikiSearch(client);

            wikiSearch.ReadSearchPrint(
                read: () => Console.ReadLine().Trim(),
                print: s => Console.WriteLine(s),
                quit: s => string.IsNullOrEmpty(s)
            );
        }
    }
}