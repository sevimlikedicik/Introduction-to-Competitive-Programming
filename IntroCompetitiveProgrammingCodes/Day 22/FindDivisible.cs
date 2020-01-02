using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class FindDivisible
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            List<int[]> pairs = new List<int[]>();

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');

                int l = Convert.ToInt32(phrase[0]);
                int r = Convert.ToInt32(phrase[1]);

                Console.WriteLine($"{l} {(r / l) * l}");
            }
        }

        private static bool PairExists(List<int[]> pairs, int a, int b)
        {
            foreach (var pair in pairs)
            {
                if (pair[0] == a && pair[1] == b)
                    return true;
            }
            return false;
        }
    }
}
