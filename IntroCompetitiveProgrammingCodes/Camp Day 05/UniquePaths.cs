using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class UniquePaths
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindUniquePaths(10, 4));

            Console.ReadKey();
        }

        public static int FindUniquePaths(int m, int n)
        {
            int[] res = Enumerable.Repeat(1, m).ToArray();

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                    res[j] += res[j - 1];
            }

            return res[res.Length - 1];
        }
    }
}
