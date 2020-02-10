using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class NumberOfDiceRollsWithTargetSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumRollsToTarget(3, 6, 15));

            Console.ReadKey();
        }

        public static int NumRollsToTarget(int d, int f, int target)
        {
            if (target > d * f)
                return 0;

            int sizePrev = f;
            long[] prev = new long[30 * f];
            long[] curr = new long[30 * f];
            int size = f;

            for (int i = 0; i < f; i++)
                prev[i] = 1;

            Array.Copy(prev, curr, size);

            for (int i = 1; i < d; i++)
                AddUpNextLevel(prev, curr, ref size, f);

            return (int)(curr[target - d] % (Math.Pow(10, 9) + 7));
        }

        private static void AddUpNextLevel(long[] prev, long[] curr, ref int size, int f)
        {
            int beginningIndex = -1 * f + 1;
            size += f - 1;

            for (int i = 0; i < size; i++)
            {
                long total = 0;
                for (int j = 0; j < f; j++)
                {
                    if (beginningIndex + j >= 0)
                        total += prev[beginningIndex + j] % (long)(Math.Pow(10, 9) + 7);
                }
                beginningIndex++;
                curr[i] = total;
            }

            Array.Copy(curr, prev, size);
        }
    }
}
