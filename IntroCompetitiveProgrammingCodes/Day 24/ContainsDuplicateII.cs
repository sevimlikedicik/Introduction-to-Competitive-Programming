using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class ContainsDuplicateII
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 1 };

            Console.WriteLine(ContainsNearbyDuplicate(nums, 3));

            Console.ReadKey();
        }

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, List<int>> equalsIndexes = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                if (equalsIndexes.ContainsKey(num))
                    equalsIndexes[num].Add(i);
                else
                    equalsIndexes[num] = new List<int>() { i };
            }

            foreach (var kvp in equalsIndexes)
            {
                var list = kvp.Value;

                if (list.Count > 1)
                {
                    for(int i=0; i<list.Count - 1; i++)
                    {
                        if (list[i + 1] - list[i] <= k)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
