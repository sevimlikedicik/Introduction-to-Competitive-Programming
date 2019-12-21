using System;

namespace IntroCompetitiveProgrammingCodes.Day_07
{
    class SortColors
    {
        static void Main(string[] args)
        {
            int[] arr = new int[6] { 2, 0, 2, 1, 1, 0 };

            Sort(arr);

            Console.ReadKey();
        }

        public static void Sort(int[] nums)
        {
            int zeros = 0, ones = 0, twos = 0;

            foreach(int num in nums)
            {
                switch (num)
                {
                    case 0:
                        zeros++;
                        break;
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                        break;
                }
            }

            int walk_arr = 0;

            for (int i = 0; i < zeros; i++)
                nums[walk_arr++] = 0;
            for (int i = 0; i < ones; i++)
                nums[walk_arr++] = 1;
            for (int i = 0; i < twos; i++)
                nums[walk_arr++] = 2;

            foreach (int num in nums)
                Console.Write($"{num} ");
        }
    }
}
