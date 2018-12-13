using CommandLine;

namespace CaesarCipher
{
    public class CommandLineOptions
    {
        [Value(0, MetaName = "caesar shift", Required = true, HelpText = "The number of letters each letter should be shifted down the alphabet when encoding or decoding.")]
        public int Shift { get; set; }
        
        [Value(1, MetaName = "query", Required = true, HelpText = "The querystring to search wikipedia with.")]
        public string Query { get; set; }
        
        [Option('d', "decrypt", Default = false, HelpText = "Decrypt the Wikipedia result. If not set, the program will default to encrypt the Wikipedia result.")]
        public bool Decrypt { get; set; }
    }
}
