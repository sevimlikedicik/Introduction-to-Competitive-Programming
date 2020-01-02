using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class PrimeSubtraction
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            List<int[]> pairs = new List<int[]>();

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');

                long l = Convert.ToInt64(phrase[0]);
                long r = Convert.ToInt64(phrase[1]);

                if (l != r + 1)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}
