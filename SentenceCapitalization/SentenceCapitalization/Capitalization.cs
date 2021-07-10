using System.Globalization;
using System.Text;

namespace SentenceCapitalization
{
    public class Capitalization
    {
        public static string CapitalizeV1(string sentence)
        {
            return CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(sentence);
        }
        public static string CapitalizeV2(string sentence)
        {
            var words = sentence.Split(' ');
            var builder = new string[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                builder[i] = $"{word.Substring(0, 1).ToUpper()}{word.Substring(1).ToLower()}";
            }

            return string.Join(' ', builder);
        }
        public static string CapitalizeV3(string sentence)
        {
            var words = sentence.Split(' ');
            var builder = new string[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                builder[i] = $"{char.ToUpper(word[0])}{word[1..].ToLower()}";
            }

            return string.Join(' ', builder);
        }
        public static string CapitalizeV4(string sentence)
        {
            var builder = new StringBuilder();

            // Capitalize the very first character
            builder.Append(char.ToUpper(sentence[0]));

            // Iterate from 1 to the length of the sentence
            for (var i = 1; i < sentence.Length; i++)
            {
                // Check the left character of the current character
                builder.Append(sentence[i - 1] == ' ' ?
                    char.ToUpper(sentence[i]) :
                    char.ToLower(sentence[i]));
            }

            return builder.ToString();
        }
    }
}