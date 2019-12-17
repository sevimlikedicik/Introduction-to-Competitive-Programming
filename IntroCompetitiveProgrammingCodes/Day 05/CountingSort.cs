using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_05
{
    class CountingSort
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            CountSort(arr);

            foreach (int num in arr)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        private static void CountSort(int[] arr)
        {
            int min = arr.Min();
            int max = arr.Max();

            int[] counterArray = new int[max - min + 1];

            foreach (int num in arr)
                counterArray[num - min] = 1;

            int walk_arr = 0;

            for (int i = 0; i < counterArray.Length; i++)
            {
                if (counterArray[i] == 1)
                    arr[walk_arr++] = i + min;
            }
        }
    }
}
