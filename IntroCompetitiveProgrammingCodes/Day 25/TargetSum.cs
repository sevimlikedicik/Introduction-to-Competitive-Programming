using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_16;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class TargetSum
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 1, 1, 1, 1 };

            Console.WriteLine(FindTargetSumWays(arr, 3));

            Console.ReadKey();
        }

        static int ways = 0;

        public static int FindTargetSumWays(int[] nums, int S)
        {
            int total = 0;

            for (int i = 0; i < nums.Length; i++)
                total += nums[i];

            if (total == S)
                ways++;

            for (int i = 0; i < nums.Length; i++)
                Combinations(nums, i, 0, total - S);

            return ways;

        }

        private static void Combinations(int[] nums, int index, int subTotal, int target)
        {
            subTotal += 2 * nums[index];

            if (subTotal == target)
                ways++;

            for (int i = index + 1; i < nums.Length; i++)
                Combinations(nums, i, subTotal, target);
        }
    }
}
