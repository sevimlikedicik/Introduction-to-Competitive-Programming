using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class LargestSumOfAverages
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(LargestSum(arr, 3));

            Console.ReadKey();
        }

        public static double LargestSum(int[] A, int K)
        {
            double[,] results = new double[A.Length, A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                int total = 0;
                for (int j = i; j < A.Length; j++)
                {
                    total += A[j];
                    results[i, j] = total / (1.0 * (j - i + 1));
                }
            }

            double[,] dp = new double[A.Length, K + 1];
            bool[,] visited = new bool[A.Length, K + 1];

            return Magic(results, 0, K, A.Length, dp, visited);
        }

        static double Magic(double[,] results, int startingIndex, int k, int size, double[,] dp, bool[,] visited)
        {
            if (k == 1)
                return results[startingIndex, dp.GetLength(0) - 1];

            double localMax = double.MinValue;

            for (int i = 1; i <= size - k + 1; i++)
            {
                double val;
                if (startingIndex + i < dp.GetLength(0) && k > 0)
                {
                    if (visited[startingIndex + i, k - 1])
                        val = dp[startingIndex + i, k - 1] + results[startingIndex, startingIndex + i - 1];
                    else
                        val = Magic(results, startingIndex + i, k - 1, size - i, dp, visited) + results[startingIndex, startingIndex + i - 1];
                }
                else
                    val = 0;
                localMax = Math.Max(localMax, val);
            }

            visited[startingIndex, k] = true;
            dp[startingIndex, k] = localMax;
            return localMax;
        }
    }
}
