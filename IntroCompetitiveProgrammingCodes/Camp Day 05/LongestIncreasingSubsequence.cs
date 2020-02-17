using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4 };

            Console.WriteLine(LengthOfLIS(arr));

            Console.ReadKey();
        }

        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int[] dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
                FindLongestIncreasingSubsequence(dp, nums, i);

            return dp.Max();
        }

        static void FindLongestIncreasingSubsequence(int[] dp, int[] nums, int index)
        {
            int max = 0;
            for (int i = index - 1; i >= 0; i--)
            {
                if (nums[i] < nums[index])
                    max = Math.Max(dp[i], max);
            }

            dp[index] = max + 1;
        }
    }
}
