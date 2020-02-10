using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class DeleteAndEarn
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(DeleteEarn(arr));

            Console.ReadKey();
        }

        public static int DeleteEarn(int[] nums)
        {
            SortedDictionary<int, int> numberCounts = new SortedDictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numberCounts.ContainsKey(nums[i]))
                    numberCounts[nums[i]]++;
                else
                    numberCounts.Add(nums[i], 1);
            }

            // Convert this into House Robber question with a twist.
            int[] numbers = new int[numberCounts.Count];
            int[] robber = new int[numberCounts.Count];
            int index = 0;

            foreach (var kvp in numberCounts)
            {
                numbers[index] = kvp.Key;
                robber[index++] = kvp.Key * kvp.Value;
            }

            if (robber.Length == 0)
                return 0;

            if (robber.Length == 1)
                return robber[0];

            if (numbers[1] - 1 != numbers[0])
                robber[1] += robber[0];

            if (robber.Length == 2)
                return Math.Max(robber[0], robber[1]);

            if (numbers[2] - 1 != numbers[1])
                robber[2] += Math.Max(robber[0], robber[1]);
            else
                robber[2] += robber[0];

            for (int i = 3; i < robber.Length; i++)
            {
                if (numbers[i - 1] != numbers[i] - 1)
                    robber[i] += Math.Max(robber[i - 1], Math.Max(robber[i - 2], robber[i - 3]));
                else
                    robber[i] += Math.Max(robber[i - 2], robber[i - 3]);
            }

            return Math.Max(robber[robber.Length - 2], robber[robber.Length - 1]);
        }
    }
}
