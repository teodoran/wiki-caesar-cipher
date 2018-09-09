using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaesarCipher
{
    public static class Cipher
    {
        private static char[] alphabet = new char[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g',
            'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z',
            'æ', 'ø', 'å', ' '
        };

        private static bool IsValid(this char letter)
        {
            return Array.IndexOf(alphabet, letter) > -1;
        }

        static int Modulo(int a, int b)
        {
            // % is the remainder operator, and will not calculate true modulo.
            // One example is -5 % 4 = -1 where Modulo(-5, 4) = 3
            return (Math.Abs(a * b) + a) % b;
        }
        
        private static int Shift(this int index, int offset, int direction)
        {
            return Modulo(index + (offset * direction), alphabet.Length);
        }
        
        private static char Shift(this char letter, int offset, int direction)
        {
            var index = Array.IndexOf(alphabet, letter).Shift(offset, direction);

            return alphabet[index];
        }

        private static string CryptLine(this string line, int shift, bool decrypt)
        {
            var direction = decrypt ? -1 : 1;
            
            return line.ToLowerInvariant()
                .ToCharArray()
                .Where(letter => letter.IsValid())
                .Select(letter => letter.Shift(shift, direction))
                .Aggregate(new StringBuilder(), (builder, letter) => builder.Append(letter))
                .ToString();
        }

        public static IEnumerable<string> CryptLines(this IEnumerable<string> lines, int shift, bool decrypt = false)
        {
            return lines.Select(l => l.CryptLine(shift, decrypt));
        }
    }
}
