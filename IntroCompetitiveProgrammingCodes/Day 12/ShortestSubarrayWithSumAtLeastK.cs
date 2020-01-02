using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_12
{
    class ShortestSubarrayWithSumAtLeastK
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 86396, 74204, 24861, 72405, 30809, 40710, 47892, -48882, -9084, 59464, 29389, 1510, 16521, 38996, 98830, 15183, 38241, 90465, -10717, 81061, -40387, -23424, 74146, -24051, 56847, 44278, 41403, -763, 50836, 6482, 44225, 16178, -48529, -36193, 28857, -16654, 48188, 54971, -29822, 25959, 90144, -23182, -9464, 65609, 99248, -26248, 47993, -20085, 75072, 70400 };
            int sum = 209110;

            int shortestSubarrayLength = ShortestSubarray(array, sum);

            Console.WriteLine(shortestSubarrayLength);

            Console.ReadKey();
        }

        private static int ShortestSubarray(int[] A, int K)
        {
            int end = A.Length - 1;
            int start = end;
            int shortest = int.MaxValue;
            int total = 0;

            while (end >= 0 && start >= 0)
            {
                total += A[start];

                if (total >= K)
                {
                    if (end - start + 1 < shortest)
                        shortest = end - start + 1;

                    total -= A[end--];

                    if (total >= K)
                    {
                        if (end - start + 1 < shortest)
                            shortest = end - start + 1;
                        while (end >= 0 && start >= 0 && total >= K)
                        {
                            if (end - start + 1 < shortest)
                                shortest = end - start + 1;
                            total -= A[end--];
                        }
                    }
                    else
                    {
                        while(end >= 0 && start >= 0 && total + A[end] < K)
                        {
                            total += A[start--];
                            total -= A[end--];
                        }
                    }

                    start = end;
                    total = 0;
                }
                else if (total < 0)
                {
                    start--;
                    end = start;
                    total = 0;
                }
                else
                    start--;
            }

            if (shortest != int.MaxValue)
                return shortest;

            return -1;
        }
    }
}
