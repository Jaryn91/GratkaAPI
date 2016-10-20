using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.Extension
{
    public static class StringExtension
    {
        public static string RemovePolishLetters(this string word)
        {
            return word.Aggregate("", (current, t) => current + NormalizeLetter(t));
        }

        private static char NormalizeLetter(char letter)
        {
            switch (letter)
            {
                case 'ą':
                    return 'a';
                case 'ć':
                    return 'c';
                case 'ę':
                    return 'e';
                case 'ł':
                    return 'l';
                case 'ń':
                    return 'n';
                case 'ó':
                    return 'o';
                case 'ś':
                    return 's';
                case 'ż':
                case 'ź':
                    return 'z';
            }
            return letter;
        }
    }
}
