using System;
using System.Linq;
using System.Text;

namespace StringReversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "Hello There!";
            Console.WriteLine(ReverseStringV1(str));
            Console.WriteLine(ReverseStringV2(str));
            Console.WriteLine(ReverseStringV3(str));
            Console.WriteLine(ReverseStringV4(str));

        }

        public static string ReverseStringV1(string str)
        {
            // Create an empty string.
            var reversed = string.Empty;

            // Loop through all of the characters of the string.
            foreach (var chr in str)
            {
                // Add the character to the start of the reversed string.
                reversed = chr + reversed;
            }
            return reversed;
        }

        public static string ReverseStringV2(string str)
        {
            // Create a StringBuilder.
            var reversed = new StringBuilder();

            // Read character from the end of the string.
            for (var i = str.Length - 1; i >= 0; i--)
            {
                // Append the character to the StringBuilder object.
                reversed.Append(str[i]);
            }
            return reversed.ToString();
        }


        public static string ReverseStringV3(string str)
        {
            //Turn the string to a char[].
            var charArray = str.ToCharArray();

            //Reverses the sort of the char[]. 
            Array.Reverse(charArray);

            //Creating a string from the char[].
            return new string(charArray);
        }

        public static string ReverseStringV4(string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}
