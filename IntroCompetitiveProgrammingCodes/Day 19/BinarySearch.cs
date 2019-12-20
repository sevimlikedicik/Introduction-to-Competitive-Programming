using System;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 4, 30, 89 };
            int target = 30;

            Console.WriteLine(Search(nums, target));

            Console.ReadKey();
        }

        public static int Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            int m = -1;

            while (l <= r)
            {
                m = (l + r) / 2;

                if (nums[m] == target)
                    return m;
                if (nums[m] < target)
                    l = m + 1;
                if (nums[m] > target)
                    r = m - 1;
            }

            return -1;
        }
    }
}
