using System;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class PeakIndexInMountainArray
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] mountainPeaks = new int[phrase.Length];

            for (int i = 0; i < mountainPeaks.Length; i++)
                mountainPeaks[i] = Convert.ToInt32(phrase[i]);

            Console.WriteLine(PeakIndex(mountainPeaks));

            Console.ReadKey();
        }

        public static int PeakIndex(int[] A)
        {
            for(int i=1; i<A.Length - 1; i++)
            {
                if (A[i] > A[i - 1])
                    return i;
            }

            return -1;
        }
    }
}
