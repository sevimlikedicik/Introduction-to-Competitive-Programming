using System;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class FindTheDuplicateNumber
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 2, 2, 2, 2 };

            Console.WriteLine(FindDuplicate(arr));

            Console.ReadKey();
        }

        public static int FindDuplicate(int[] nums)
        {
            int l = 1;
            int r = nums.Length;

            while (l < r)
            {
                int m = (l + r) / 2;
                int smallerThanM = 0;
                int equalsToM = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < m)
                        smallerThanM++;
                    if (nums[i] == m)
                    {
                        if (equalsToM == 1)
                            return m;
                        else
                            equalsToM++;
                    }
                }

                if (smallerThanM < m)
                    l = m + 1;
                else
                    r = m - 1;
            }

            return l;
        }
    }
}
