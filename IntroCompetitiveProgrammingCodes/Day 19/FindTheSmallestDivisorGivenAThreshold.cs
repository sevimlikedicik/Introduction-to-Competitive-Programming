using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class FindTheSmallestDivisorGivenAThreshold
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 5, 9 };
            int threshold = 6;

            Console.WriteLine(SmallestDivisor(arr, threshold));

            Console.ReadKey();
        }

        public static int SmallestDivisor(int[] nums, int threshold)
        {
            int result = int.MaxValue;
            int l = 0;
            int r = int.MaxValue;
            int m = 0;

            while(l < r)
            {
                m = (l + r) / 2;

                result = 0;

                for (int i = 0; i < nums.Length; i++)
                    result += ((nums[i] - 1) / m) + 1;

                if (result > threshold)
                    l = m + 1;
                else
                    r = m;
            }

            if (l == r)
                m = l;

            return m;
        }
    }
}
