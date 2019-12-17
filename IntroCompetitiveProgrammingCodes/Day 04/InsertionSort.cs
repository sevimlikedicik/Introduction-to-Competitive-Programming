using System;

namespace IntroCompetitiveProgrammingCodes.Day_04
{
    class InsertionSort
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
            for (int i = 1; i < arr.Length; i++)
            {
                int index = i;
                while (index > 0 && arr[index-1] > arr[index])
                {
                    int temp = arr[index];
                    arr[index] = arr[index - 1];
                    arr[index - 1] = temp;
                    index--;
                }
            }
        }
    }
}
