using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class PowerfulIntegers
    {
        static void Main(string[] args)
        {
            var list = PowerfulInts(2, 1, 17);

            foreach (int num in list)
                Console.WriteLine(num);

            Console.ReadKey();
        }

        public static IList<int> PowerfulInts(int x, int y, int bound)
        {
            if (x == 1)
                return PowerfulInts(y, bound);

            if (y == 1)
                return PowerfulInts(x, bound);

            List<int> powerful = new List<int>();

            int xPowMax = (int)Math.Ceiling(Math.Log(bound) / Math.Log(x));
            int yPowMax = (int)Math.Ceiling(Math.Log(bound) / Math.Log(y));

            for (int i = 0; i < xPowMax; i++)
            {
                for (int j = 0; j < yPowMax; j++)
                {
                    int total = (int)Math.Pow(x, i) + (int)Math.Pow(y, j);

                    if (total <= bound && !powerful.Contains(total))
                        powerful.Add(total);
                }
            }

            return powerful;
        }

        private static IList<int> PowerfulInts(int num, int bound)
        {
            if (num == 1)
                return bound >= 2 ? new List<int>() { 2 } : new List<int>();

            List<int> powerful = new List<int>();

            int numPowMax = (int)Math.Ceiling(Math.Log(bound) / Math.Log(num));

            for (int i = 0; i < numPowMax; i++)
            {
                int total = (int)Math.Pow(num, i) + 1;

                if (total <= bound && !powerful.Contains(total))
                    powerful.Add(total);
            }

            return powerful;
        }
    }
}
