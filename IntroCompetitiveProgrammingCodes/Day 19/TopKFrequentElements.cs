using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class TopKFrequentElements
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 5, 9, 9 };
            int k = 2;

            var list = TopKFrequent(arr, k);

            foreach (int num in list)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            foreach(int num in nums)
            {
                if (!numberCounts.ContainsKey(num))
                    numberCounts.Add(num, 1);
                else
                    numberCounts[num]++;
            }

            var sortedDict = from entry in numberCounts orderby entry.Value descending select entry;

            List<int> mostFrequentNumbers = new List<int>();
            int walk = 0;

            foreach(var kvp in sortedDict)
            {
                if (walk == k)
                    break;

                mostFrequentNumbers.Add(kvp.Key);
                walk++;
            }

            return mostFrequentNumbers;
        }
    }
}
