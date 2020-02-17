using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class LengthOfLongestFibonacciSubsequence
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4 };

            Console.WriteLine(LenLongestFibSubseq(arr));

            Console.ReadKey();
        }

        public static int LenLongestFibSubseq(int[] A)
        {
            // Originally I used a dp multi-dimentional int array, turns out it's not necessary.
            // Investigate the reason behind.
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < A.Length; i++)
                dict.Add(A[i], i);

            int max = 2;

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                    LongestFibonacci(dict, A, i, j, ref max);
            }

            return max == 2 ? 0 : max;
        }

        static int LongestFibonacci(Dictionary<int, int> dict, int[] A, int left, int right, ref int max)
        {
            int total = A[left] + A[right];
            int val;

            if (dict.ContainsKey(total))
                val = LongestFibonacci(dict, A, right, dict[total], ref max) + 1;
            else
                val = 2;

            max = Math.Max(max, val);

            return val;
        }
    }
}
