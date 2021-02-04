using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySplitting
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintArray(Functions.SplitArrayV1(Enumerable.Range(1, 16).ToArray(), 4));
            Console.WriteLine("=====================");
            PrintJaggedArray(Functions.SplitArrayV2(Enumerable.Range(1, 12).ToArray(), 3));
            Console.WriteLine("=====================");
            PrintJaggedArray(Functions.SplitArrayV3(Enumerable.Range(1, 20).ToArray(), 5));
            Console.WriteLine("=====================");
            PrintJaggedArray(Functions.SplitArrayV4(Enumerable.Range(1, 6).ToArray(), 2));
        }

        private static void PrintArray(IEnumerable<List<int>> source)
        {
            foreach (var array in source)
            {
                foreach (var sub in array)
                {
                    Console.Write($"{sub}\t");
                }
                Console.WriteLine();
            }
        }

        private static void PrintJaggedArray(int[][] jagged)
        {
            foreach (var arr in jagged)
            {
                foreach (var item in arr)
                {
                    Console.Write($"{item}\t");
                }

                Console.WriteLine();
            }
        }
    }
}
