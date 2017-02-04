using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCross
{
    class Coder
    {

        //lookup table for decryption, inverse is used for encryption
        public Dictionary<char, char> lookup = new Dictionary<char, char>();

        public Coder()
        {
            lookup[' '] = 'm';
            lookup['q'] = 'n';
            lookup['w'] = 'b';
            lookup['e'] = 'v';
            lookup['r'] = 'c';
            lookup['t'] = 'x';
            lookup['y'] = 'z';
            lookup['u'] = '1';
            lookup['i'] = '2';
            lookup['o'] = '3';
            lookup['p'] = '4';
            lookup['a'] = '5';
            lookup['s'] = '6';
            lookup['d'] = '7';
            lookup['f'] = '8';
            lookup['g'] = '9';
            lookup['h'] = '0';
            lookup['j'] = 'a';
            lookup['k'] = 's';
            lookup['l'] = 'd';
            lookup['z'] = 'f';
            lookup['x'] = 'g';
            lookup['c'] = 'h';
            lookup['v'] = 'j';
            lookup['b'] = 'k';
            lookup['n'] = 'l';
            lookup['m'] = 'q';
            lookup['1'] = 'w';
            lookup['2'] = 'e';
            lookup['3'] = 'r';
            lookup['4'] = 't';
            lookup['5'] = 'y';
            lookup['6'] = 'u';
            lookup['7'] = 'i';
            lookup['8'] = 'o';
            lookup['9'] = 'p';
            lookup['0'] = ' ';

            lookup['Q'] = 'Z';
            lookup['W'] = 'A';
            lookup['E'] = 'Q';
            lookup['R'] = 'C';
            lookup['T'] = 'D';
            lookup['Y'] = 'E';
            lookup['U'] = 'V';
            lookup['I'] = 'F';
            lookup['O'] = 'R';
            lookup['P'] = 'B';
            lookup['A'] = 'G';
            lookup['S'] = 'T';
            lookup['D'] = 'N';
            lookup['F'] = 'H';
            lookup['H'] = 'Y';
            lookup['J'] = 'M';
            lookup['K'] = 'J';
            lookup['L'] = 'U';
            lookup['Z'] = 'K';
            lookup['X'] = 'I';
            lookup['C'] = 'L';
            lookup['V'] = 'O';
            lookup['B'] = 'P';
            lookup['N'] = 'X';
            lookup['M'] = 'S';
            lookup['G'] = 'W';
        }

        public string decrypt(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input.ToArray())
            {
                if (lookup.ContainsKey(c))
                    result.Append(lookup[c]);
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        public string encrypt(string input)
        {
            var lookup = invert(this.lookup);
            StringBuilder result = new StringBuilder();
            foreach (char c in input.ToArray())
            {
                if (lookup.ContainsKey(c))
                    result.Append(lookup[c]);
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        private Dictionary<char, char> invert(Dictionary<char, char> orig)
        {
            Dictionary<char, char> inverse = new Dictionary<char, char>();
            foreach(var entry in orig)
            {
                if (!inverse.ContainsKey(entry.Value))
                    inverse.Add(entry.Value, entry.Key);
            }
            return inverse;
        }
        
    }
}
