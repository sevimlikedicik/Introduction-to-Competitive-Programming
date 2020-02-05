using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_3
{
    class MinimumCostTreeFromLeafValues
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };
            int[] arr2 = new int[] { 7, 12, 8, 10 };

            Console.WriteLine(MctFromLeafValues(arr2));

            Console.ReadKey();
        }

        public static int MctFromLeafValues(int[] arr)
        {
            int total = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minInd = FindMin(arr);
                int left = minInd - 1;
                int right = minInd + 1;

                while (left >= 0 && arr[left] == int.MaxValue)
                    left--;

                while (right < arr.Length && arr[right] == int.MaxValue)
                    right++;

                if (left >= 0 && right < arr.Length)
                {
                    if (arr[left] < arr[right])
                    {
                        total += arr[minInd] * arr[left];
                        arr[minInd] = int.MaxValue;
                    }
                    else
                    {
                        total += arr[minInd] * arr[right];
                        arr[minInd] = int.MaxValue;
                    }
                }
                else if (left >= 0)
                {
                    total += arr[minInd] * arr[left];
                    arr[minInd] = int.MaxValue;
                }
                else
                {
                    total += arr[minInd] * arr[right];
                    arr[minInd] = int.MaxValue;
                }
            }

            return total;
        }

        private static int FindMin(int[] arr)
        {
            int min = int.MaxValue;
            int minInd = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minInd = i;
                }
            }

            return minInd;
        }

        private static int FindMax(int[] arr, int start, int end)
        {
            int max = int.MinValue;

            for (int i = start; i <= end; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            return max;
        }
    }
}
