using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_06
{
    class ReduceArraySizeToTheHalf
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 9 };

            Console.WriteLine(MinSetSize(arr));

            Console.ReadKey();
        }

        public static int MinSetSize(int[] arr)
        {
            Dictionary<int, int> sizes = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (sizes.ContainsKey(arr[i]))
                    sizes[arr[i]]++;
                else
                    sizes.Add(arr[i], 1);
            }

            var ordered = sizes.OrderBy(x => x.Value);

            int total = arr.Length;
            int steps = 0;

            foreach (var kvp in ordered.Reverse())
            {
                if (total <= arr.Length / 2)
                    break;

                total -= kvp.Value;
                steps++;
            }

            return steps;
        }
    }
}
