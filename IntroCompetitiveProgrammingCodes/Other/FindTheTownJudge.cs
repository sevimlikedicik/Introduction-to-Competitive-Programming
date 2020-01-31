using System;

namespace IntroCompetitiveProgrammingCodes.Other
{
    class FindTheTownJudge
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } };

            Console.WriteLine(FindJudge(3, mtr));

            Console.ReadKey();
        }

        public static int FindJudge(int N, int[][] trust)
        {
            int[] trusted = new int[N + 1];
            bool[] trustsSomeone = new bool[N + 1];

            for (int i = 0; i < trust.Length; i++)
            {
                trustsSomeone[trust[i][0]] = true;
                trusted[trust[i][1]]++;
            }

            for (int i = 1; i <= N; i++)
            {
                if (trusted[i] == N - 1 && !trustsSomeone[i])
                    return i;
            }

            return -1;
        }
    }
}
