using System;
using System.Diagnostics;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_08
{
    class SplitArrayWithSameAverage
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
            int[] arr3 = new int[] { 60, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 };
            int[] arr4 = new int[] { 2, 0, 5, 6, 16, 12, 15, 12, 4 };
            int[] arr5 = new int[] { 3863, 703, 1799, 327, 3682, 4330, 3388, 6187, 5330, 6572, 938, 6842, 678, 9837, 8256, 6886, 2204, 5262, 6643, 829, 745, 8755, 3549, 6627, 1633, 4290, 7 };
            int[] arr6 = new int[] { 2, 12, 18, 16, 19, 3 };
            int[] arr7 = new int[] { 4, 4, 4, 4, 4, 4, 5, 4, 4, 4, 4, 4, 4, 5 };
            int[] arr8 = new int[] { 6, 8, 18, 3, 1 };

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(SplitArraySameAverage(arr8));

            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.ReadKey();
        }

        public static bool SplitArraySameAverage(int[] A)
        {
            int[][] dp = new int[A.Length * 10000][];
            bool[][] visited = new bool[A.Length * 10000][];
            long visitedIndexes = 0;
            int total = 0;

            for (int i = 0; i < A.Length; i++)
                total += A[i];

            neededAverage = (total * 1.0) / A.Length;

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[(A.Length / 2) + 1];

                for (int j = 0; j < dp[i].Length; j++)
                    dp[i][j] = -1;
            }

            return Magic(dp, A, 0, 0, visitedIndexes, total) >= 1 ? true : false;
        }

        static double neededAverage;

        private static int Magic(int[][] dp, int[] a, int sum, int size, long visitedIndexes, int total)
        {
            if (sum >= dp.Length || size >= dp[0].Length)
                return 0;

            if (dp[sum][size] != -1)
                return dp[sum][size];

            if (size != 0 && sum == Math.Round((size * neededAverage), 3))
                return 1;

            if (size == (a.Length / 2) + 1)
                return 0;

            int ret = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if ((visitedIndexes >> i) % 2 == 0)
                    ret = ret + Magic(dp, a, (sum + a[i]), size + 1, visitedIndexes + (long)Math.Pow(2, i), total);
            }

            return dp[sum][size] = ret;
        }
    }
}
