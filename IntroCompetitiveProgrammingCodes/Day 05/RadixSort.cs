using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_05
{
    class RadixSort
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            Sort(arr);

            foreach (int num in arr)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        private static void Sort(int[] arr)
        {
            int max = arr.Max();
            int maxDigits = (int)Math.Floor(Math.Log10(max) + 1);

            for (int i = 1; i <= maxDigits; i++)
                CountingSort(arr, i);
        }

        private static void CountingSort(int[] arr, int digit)
        {
            Dictionary<int, List<int>> counterDict = new Dictionary<int, List<int>>();

            for (int i = 0; i < 10; i++)
                counterDict[i] = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int digitValue = (arr[i] / ((int)Math.Pow(10, digit - 1))) % 10;
                counterDict[digitValue].Add(arr[i]);
            }

            int walk_arr = 0;

            for (int i = 0; i < 10; i++)
            {
                foreach (int num in counterDict[i])
                    arr[walk_arr++] = num;
            }
        }
    }
}
