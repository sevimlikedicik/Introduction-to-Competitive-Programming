using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_07
{
    class FindNUniqueIntegersSumUpToZero
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumZero(5));

            Console.ReadKey();
        }

        public static int[] SumZero(int n)
        {
            int[] arr = new int[n];
            arr[0] = -1 * (((n - 1) * n) / 2);
            for (int i = 1; i < n; i++)
                arr[i] = i;

            return arr;
        }
    }
}
