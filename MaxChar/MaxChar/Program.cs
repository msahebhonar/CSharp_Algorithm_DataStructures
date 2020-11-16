using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxChar
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "simple dummy phrase!";
            Console.WriteLine(MaxCharV1(str));
            Console.WriteLine(MaxCharV2(str));
            Console.WriteLine(MaxCharV3(str));
        }

        public static (char, int) MaxCharV1(string str)
        {
            // Create a new dictionary of integers, with character keys.
            var dictionary = new Dictionary<char, int>();

            // Loop over all the characters.
            foreach (var c in str)
            {
                // If a key exists, update the value and add one to it.
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c] += 1;
                }
                else
                {
                    // If a key does not exist, add a new key with value of one.
                    dictionary.Add(c, 1);
                }
            }

            // Sort the dictionary descending based on the values
            var (chr, count) = dictionary
                .OrderByDescending(x => x.Value)
                .First();
            return (chr, count);
        }

        public static (char, int) MaxCharV2(string str)
        {
            var dictionary = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (!dictionary.TryGetValue(c, out var i))
                {
                    dictionary.Add(c, 1);
                }
                else
                {
                    dictionary[c] = ++i;
                }
            }

            var (chr, count) = dictionary
                .OrderByDescending(x => x.Value)
                .First();
            return (chr, count);
        }

        public static (char, int) MaxCharV3(string str)
        {
            var result = str
                .GroupBy(c => c)
                .Select(x => new { Key = x.Key, Value = x.Count() })
                .OrderByDescending(x => x.Value)
                .First();
            return (result.Key, result.Value);
        }
    }
}
