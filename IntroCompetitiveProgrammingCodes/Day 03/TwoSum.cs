using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_03
{
    class TwoSum
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            var solution = Solution(nums, target);

            Console.WriteLine($"[{solution[0]}, {solution[1]}]");

            Console.ReadKey();
        }

        public static int[] Solution(int[] nums, int target)
        {
            Dictionary<int, List<int>> numPlaces = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numPlaces.ContainsKey(nums[i]))
                    numPlaces[nums[i]].Add(i);
                else
                    numPlaces[nums[i]] = new List<int>() { i };
            }

            foreach (int num in nums)
            {
                if (numPlaces.ContainsKey(target - num))
                {
                    if (num != target - num)
                    {
                        int[] solution = { numPlaces[num][0], numPlaces[target - num][0] };
                        return solution;
                    }
                    else
                    {
                        if (numPlaces[num].Count > 1)
                        {
                            int[] solution = { numPlaces[num][0], numPlaces[num][1] };
                            return solution;
                        }
                    }
                }
            }

            return null;
        }
    }
}
