using System;
using System.Diagnostics;

namespace IntegerReversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stopwatch();

            st.Start();
            Console.WriteLine(ReverseInteger(short.MaxValue));
            Console.WriteLine($"Time Elapsed: {st.Elapsed}");

            st.Reset();
            st.Start();
            Console.WriteLine(ReverseIntegerV2(short.MaxValue));
            Console.WriteLine($"Time Elapsed: {st.Elapsed}");
        }

        public static int ReverseInteger(int number)
        {
            var str = Math.Abs(number).ToString().ToCharArray();
            Array.Reverse(str);
            return int.Parse(str) * Math.Sign(number);
        }

        public static int ReverseIntegerV2(int number)
        {
            var sign = Math.Sign(number);
            var reverse = 0;
            while (number > 0)
            {
                // Find the last digit
                reverse = reverse * 10 + number % 10;

                // Remove the last digit
                number /= 10;
            }

            return reverse * sign;
        }
    }
}
