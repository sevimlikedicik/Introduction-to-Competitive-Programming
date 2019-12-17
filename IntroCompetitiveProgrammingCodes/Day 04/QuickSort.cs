using System;

namespace IntroCompetitiveProgrammingCodes.Day_04
{
    class QuickSort
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            Sort(arr, 0, arr.Length - 1);

            foreach (int num in arr)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        private static void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partitioning index
                int pi = Partition(arr, low, high);

                Sort(arr, low, pi - 1);  // Before pi
                Sort(arr, pi + 1, high); // After pi
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int j = low;

            for (int i = low; i<high; i++)
            {
                if(arr[i] < pivot)
                {
                    int tempo = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempo;
                    j++;
                }
            }

            int temp = arr[j];
            arr[j] = pivot;
            arr[high] = temp;

            return j;
        }
    }
}
