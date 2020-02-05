using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_04
{
    class MonotonicArray
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };
            int[] arr2 = new int[] { 1, 1, 1 };

            Console.WriteLine(IsMonotonic(arr2));

            Console.ReadKey();
        }

        public static bool IsMonotonic(int[] A)
        {
            bool inc = true;
            bool dec = true;

            for (int i = 0; i < A.Length - 1; ++i)
            {
                if (!inc && !dec)
                    return false;

                if (A[i] > A[i + 1])
                    inc = false;

                if (A[i] < A[i + 1])
                    dec = false;
            }

            return inc || dec;
        }
    }
}
