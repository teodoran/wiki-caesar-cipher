using CommandLine;

namespace CaesarCipher
{
    public class CommandLineOptions
    {
        [Value(0, MetaName = "caesar shift", Required = true, HelpText = "The number of letters each letter should be shifted down the alphabet when encoding or decoding.")]
        public int Shift { get; set; }
        
        [Value(1, MetaName = "input file", Required = true, HelpText = "Input file with plaintext to encode or ciphertext to decode.")]
        public string InputFile { get; set; }
        
        [Option('d', "decrypt", Default = false, HelpText = "Decrypt the input file. If not set, the program will default to encrypt the input file.")]
        public bool Decrypt { get; set; }
    }
}
