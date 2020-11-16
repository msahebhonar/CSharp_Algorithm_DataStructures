using System;
using System.Linq;
using System.Text;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "Madam";
            Console.WriteLine($"Solution 1:{IsPalindromeV1(str)}");
            Console.WriteLine($"Solution 2:{IsPalindromeV2(str)}");
            Console.WriteLine($"Solution 3:{IsPalindromeV3(str)}");
        }

        public static bool IsPalindromeV1(string str)
        {
            var reversed = new StringBuilder();
            for (var i = str.Length - 1; i >= 0; i--)
            {
                reversed.Append(str[i]);
            }
            var s = str.Equals(reversed.ToString(), StringComparison.InvariantCultureIgnoreCase);
            return s;
        }

        public static bool IsPalindromeV2(string str)
        {
            var forward = 0;
            var backward = str.Length - 1;
            while (backward > forward)
            {
                if (char.ToLower(str[forward]) != char.ToLower(str[backward])) return false;
                forward++;
                backward--;
            }
            return true;
        }

        public static bool IsPalindromeV3(string str)
        {
            return !str.Where((c, i) => char.ToLower(c) != char.ToLower(str[str.Length - i - 1])).Any();
        }
    }
}
