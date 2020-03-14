using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class HouseRobberII
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(Rob(arr));

            Console.ReadKey();
        }

        public static int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int[] maxProfit = new int[nums.Length];
            int max = 0;

            maxProfit[0] = nums[0];
            maxProfit[1] = nums[1];
            maxProfit[2] = nums[0] + nums[2];

            if (nums.Length == 3)
                return Math.Max(Math.Max(nums[1], nums[2]), nums[0]);

            // Start from 0
            for (int i = 3; i < nums.Length - 1; i++)
                maxProfit[i] = Math.Max(maxProfit[i - 3], maxProfit[i - 2]) + nums[i];

            max = Math.Max(maxProfit[nums.Length - 2], maxProfit[nums.Length - 3]);

            for (int i = 0; i < maxProfit.Length; i++)
                maxProfit[i] = 0;

            maxProfit[1] = nums[1];
            maxProfit[2] = nums[2];

            // Start from 1
            for (int i = 3; i < nums.Length; i++)
                maxProfit[i] = Math.Max(maxProfit[i - 3], maxProfit[i - 2]) + nums[i];

            max = Math.Max(Math.Max(maxProfit[nums.Length - 2], maxProfit[nums.Length - 1]), max);

            return max;
        }
    }
}
