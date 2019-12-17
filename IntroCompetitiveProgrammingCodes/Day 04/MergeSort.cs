using System;

namespace IntroCompetitiveProgrammingCodes.Day_04
{
    class MergeSort
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

        private static void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                Sort(arr, l, m);
                Sort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            int[] leftArray = new int[m - l + 1];
            int[] rightArray = new int[r - m];
            int[] newSubArray = new int[r - l + 1];

            Array.Copy(arr, l, leftArray, 0, m - l + 1);
            Array.Copy(arr, m + 1, rightArray, 0, r - m);

            int walk_l = 0;
            int walk_r = 0;
            int walk_s = 0;

            while (walk_l < leftArray.Length && walk_r < rightArray.Length)
            {
                if (leftArray[walk_l] < rightArray[walk_r])
                    newSubArray[walk_s++] = leftArray[walk_l++];
                else
                    newSubArray[walk_s++] = rightArray[walk_r++];
            }

            while (walk_l < leftArray.Length)
                newSubArray[walk_s++] = leftArray[walk_l++];
            while (walk_r < rightArray.Length)
                newSubArray[walk_s++] = rightArray[walk_r++];

            for (int i = l; i <= r; i++)
                arr[i] = newSubArray[i - l];
        }
    }
}
