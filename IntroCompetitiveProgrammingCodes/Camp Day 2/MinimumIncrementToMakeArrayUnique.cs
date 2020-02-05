using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_2
{
    class MinimumIncrementToMakeArrayUnique
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 2 };

            Console.WriteLine(MinIncrementForUnique(arr));

            Console.ReadKey();
        }

        public static int MinIncrementForUnique(int[] A)
        {
            // Given in the question
            int[] count = new int[80001];
            bool[] full = new bool[80001];
            int total = 0;
            int lastIndex = 0;

            for (int i = 0; i < A.Length; i++)
                count[A[i]]++;

            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] != 0)
                {
                    if (full[i])
                    {
                        total += lastIndex - i;
                        full[lastIndex++] = true;
                    }
                    else
                    {
                        full[i] = true;
                        lastIndex = i + 1;
                    }
                    count[i]--;
                }
            }

            return total;
        }
    }
}
