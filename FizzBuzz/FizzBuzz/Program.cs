using System;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            const int number = 15;

            // Iterate from 1 to number
            for (var i = 1; i <= number; i++)
            {
                Console.WriteLine(FizzBuzzV1(i));
            }

            //FizzBuzzV4(number);
        }

        public static string FizzBuzzV1(int n)
        {
            // If the number is a multiple of 3 or 5
            if (n % 3 == 0 && n % 5 == 0)
            {
                return "FizzBuzz";
            }
            if (n % 3 == 0)
            {
                // If the number is a multiple of 3
                return "Fizz";
            }
            if (n % 5 == 0)
            {
                // If the number is a multiple of 5
                return "Buzz";
            }
            return $"{n}";
        }

        public static string FizzBuzzV2(int n)
        {
            Math.DivRem(n, 3, out var fizz);
            Math.DivRem(n, 5, out var buzz);
            if (fizz == 0 & buzz == 0)
            {
                return "FizzBuzz";
            }
            if (fizz == 0)
            {
                return "Fizz";
            }
            if (buzz == 0)
            {
                return "Buzz";
            }
            return $"{n}";
        }

        public static string FizzBuzzV3(int n)
        {
            Math.DivRem(n, 3, out var fizz);
            Math.DivRem(n, 5, out var buzz);

            var output = (fizz, buzz) switch
            {
                (0, 0) => "FizzBuzz",
                (0, _) => "Fizz",
                (_, 0) => "Buzz",
                (_, _) => $"{n}"
            };

            return output;
        }

        public static void FizzBuzzV4(int n)
        {
            Enumerable.Range(1, n)
                .Select(x =>
                    x % 15 == 0 ? "FizzBuzz"
                    : x % 3 == 0 ? "Fizz"
                    : x % 5 == 0 ? "Buzz"
                    : $"{x}"
                )
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
