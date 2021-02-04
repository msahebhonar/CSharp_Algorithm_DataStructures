using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySplitting
{
    public class Functions
    {

        public static List<List<int>> SplitArrayV1(int[] source, int size)
        {
            var subArray = new List<List<int>>();

            foreach (var item in source)
            {
                var last = subArray.Count == 0 ? null : subArray[^1];
                if (last == null || last.Count == size)
                {
                    subArray.Add(new List<int> { item });
                }
                else
                {
                    last.Add(item);
                }
            }

            return subArray;
        }

        public static int[][] SplitArrayV2(int[] source, int size)
        {
            var subArray = new List<List<int>>();

            foreach (var item in source)
            {
                var last = subArray.Count == 0 ? null : subArray[^1];
                if (last == null || last.Count == size)
                {
                    subArray.Add(new List<int> { item });
                }
                else
                {
                    last.Add(item);
                }
            }

            return subArray.Select(x => x.ToArray()).ToArray();
        }

        public static int[][] SplitArrayV3(int[] source, int size)
        {
            // Number of sub-arrays, round up to the nearest integer.
            var dim1 = (int)Math.Ceiling(source.Length / (float)size);

            // Declare the source.
            var subArray = new int[dim1][];

            var index = 0;
            for (var i = 0; i < dim1; i++)
            {
                // Number of elements left in the original source.
                var remainItems = source.Length - index;

                // Number of elements in each sub-arrays.
                var dim2 = remainItems >= size ? size : remainItems;

                subArray[i] = new int[dim2];

                // Copy from original source to sub-source
                Array.Copy(source, index, subArray[i], 0, dim2);
                index += dim2;
            }

            return subArray;
        }

        public static int[][] SplitArrayV4(int[] source, int size)
        {
            return source
                .Select((x, i) => new { Value = x, Index = i })
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value).ToArray())
                .ToArray();
        }
    }
}