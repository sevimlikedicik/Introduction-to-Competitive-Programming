using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class GreatestSumDivisibleByThree
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(MaxSumDivThree(arr));

            Console.ReadKey();
        }

        public static int MaxSumDivThree(int[] nums)
        {
            int total = 0;
            int[] min2mod1 = new int[2];
            int[] min2mod2 = new int[2];

            for (int i = 0; i < 2; i++) {
                min2mod1[i] = int.MaxValue / 2;
                min2mod2[i] = int.MaxValue / 2;
            }

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] % 3 == 1) {
                    if (min2mod1[1] > nums[i]) {
                        min2mod1[1] = nums[i];
                    }
                    if (min2mod1[0] > nums[i]) {
                        min2mod1[1] = min2mod1[0];
                        min2mod1[0] = nums[i];
                    }
                }
                else if (nums[i] % 3 == 2) {
                    if (min2mod2[1] > nums[i]) {
                        min2mod2[1] = nums[i];
                    }
                    if (min2mod2[0] > nums[i]) {
                        min2mod2[1] = min2mod2[0];
                        min2mod2[0] = nums[i];
                    }
                }

                total += nums[i];
            }

            if (total % 3 == 0) {
                return total;
            }
            else if (total % 3 == 1) {
                return total - Math.Min(min2mod1[0], min2mod2[0] + min2mod2[1]);
            }
            return total - Math.Min(min2mod1[0] + min2mod1[1], min2mod2[0]);
        }
    }
}
