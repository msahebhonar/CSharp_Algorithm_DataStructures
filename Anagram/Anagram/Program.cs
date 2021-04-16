using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Is 'Anagram' an anagram of 'Nag A Ram!'? {Anagrams("Anagram", "Nag A Ram!")}");
            Console.WriteLine($"Is 'School master' an anagram of 'The classroom'? {AnagramsLinq("Anagram", "Nag A Ram!")}");
        }

        public static bool Anagrams(string strA, string strB)
        {
            if (strA.Equals(strB))
            {
                return true;
            }

            var strACharDic = BuildCharDic(strA);
            var strBCharDic = BuildCharDic(strB);

            if (strACharDic.Keys.Count != strBCharDic.Keys.Count)
            {
                return false;
            }

            foreach (var character in strACharDic.Keys)
            {
                if (!strBCharDic.ContainsKey(character) ||
                    strACharDic[character] != strBCharDic[character])
                {
                    return false;
                }
            }

            return true;
        }

        private static Dictionary<char, int> BuildCharDic(string str)
        {
            var charDic = new Dictionary<char, int>();
            var refinedStr = Regex.Replace(str, @"\W", "").ToLower();

            foreach (var character in refinedStr)
            {
                if (!charDic.TryGetValue(character, out var i))
                {
                    charDic.Add(character, 1);
                }
                else
                {
                    charDic[character] = ++i;
                }
            }

            return charDic;
        }

        public static bool AnagramsLinq(string strA, string strB)
        {
            return RefineString(strA)
                .OrderBy(a => a)
                .SequenceEqual(
                    RefineString(strB)
                        .OrderBy(b => b)
                );
        }
        
        private static string RefineString(string str)
        {
            return Regex.Replace(str, @"\W", "").ToLower();
        }
    }
}
