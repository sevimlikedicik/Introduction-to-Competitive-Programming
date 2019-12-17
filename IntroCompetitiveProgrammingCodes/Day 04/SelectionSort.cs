using System;

namespace IntroCompetitiveProgrammingCodes.Day_04
{
    class SelectionSort
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
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = arr[i];
                int minInd = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minInd = j;
                    }
                }

                // switch the ith and minIndth position
                int temp = arr[i];
                arr[i] = min;
                arr[minInd] = temp;
            }
        }
    }
}
