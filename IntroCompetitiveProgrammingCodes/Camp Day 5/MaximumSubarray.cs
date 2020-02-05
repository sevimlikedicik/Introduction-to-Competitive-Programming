using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_5
{
    class MaximumSubarray
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(MaxSubArray(arr));

            Console.ReadKey();
        }

        public static int MaxSubArray(int[] nums)
        {
            int total = 0;
            int max = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];

                if (total > max)
                    max = total;

                if (total < 0)
                    total = 0;
            }

            return max;
        }
    }
}
