using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_5
{
    class RangeSumQueryImmutable
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            NumArray na = new NumArray(arr);

            Console.WriteLine(na.SumRange(0, 2));

            Console.ReadKey();
        }

        public class NumArray
        {
            int[] prefixSum;

            public NumArray(int[] nums)
            {
                if (nums.Length != 0)
                {
                    prefixSum = new int[nums.Length + 1];
                    prefixSum[0] = nums[0];

                    for (int i = 0; i < nums.Length; i++)
                        prefixSum[i + 1] = prefixSum[i] + nums[i];
                }
            }

            public int SumRange(int i, int j) => prefixSum[j + 1] - prefixSum[i];
        }
    }
}
