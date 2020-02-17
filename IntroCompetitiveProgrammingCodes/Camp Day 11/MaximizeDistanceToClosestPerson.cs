using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_11
{
    class MaximizeDistanceToClosestPerson
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(MaxDistToClosest(arr));

            Console.ReadKey();
        }

        public static int MaxDistToClosest(int[] seats)
        {
            int longestZeroSubArraySize = 1;

            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 0)
                {
                    int startIndex = i;
                    int count = 0;
                    while (i < seats.Length && seats[i] == 0)
                    {
                        i++;
                        count++;
                    }
                    if (startIndex == 0 || i == seats.Length)
                        longestZeroSubArraySize = Math.Max(longestZeroSubArraySize, count);
                    else
                        longestZeroSubArraySize = Math.Max(longestZeroSubArraySize, (count + 1) / 2);
                }
            }

            return longestZeroSubArraySize;
        }
    }
}
