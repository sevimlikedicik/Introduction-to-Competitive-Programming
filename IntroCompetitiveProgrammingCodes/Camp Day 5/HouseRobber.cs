using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_5
{
    class HouseRobber
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
            maxProfit[0] = nums[0];
            maxProfit[1] = nums[1];
            maxProfit[2] = nums[2] + nums[0];

            for (int i = 3; i < nums.Length; i++)
                maxProfit[i] = Math.Max(maxProfit[i - 3], maxProfit[i - 2]) + nums[i];

            return Math.Max(maxProfit[nums.Length - 1], maxProfit[nums.Length - 2]);
        }
    }
}
