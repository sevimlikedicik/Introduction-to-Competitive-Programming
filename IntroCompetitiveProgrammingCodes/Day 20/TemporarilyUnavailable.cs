using System;

namespace IntroCompetitiveProgrammingCodes.Day_20
{
    class TemporarilyUnavailable
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            int[] results = new int[t];

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');

                int a = Convert.ToInt32(phrase[0]);
                int b = Convert.ToInt32(phrase[1]);
                int c = Convert.ToInt32(phrase[2]);
                int r = Convert.ToInt32(phrase[3]);

                results[i] = OutOfRange(a, b, c, r);
            }

            foreach (int result in results)
                Console.WriteLine(result);
        }

        private static int OutOfRange(int a, int b, int c, int r)
        {
            int rightBorder = c + r;
            int leftBorder = c - r;
            int coverageArea = 2 * r;

            if (leftBorder >= Math.Min(a, b) && leftBorder <= Math.Max(a, b))
            {
                if (leftBorder + coverageArea <= Math.Max(a, b))
                    return Math.Abs(b - a) - coverageArea;
                else
                    return Math.Abs(b - a) - (Math.Max(a, b) - leftBorder);
            }
            else if (rightBorder >= Math.Min(a, b) && rightBorder <= Math.Max(a, b))
            {
                if (rightBorder - coverageArea >= Math.Min(a, b))
                    return Math.Abs(b - a) - coverageArea;
                else
                    return Math.Abs(b - a) - (rightBorder - Math.Min(a, b));
            }
            else if (rightBorder >= Math.Max(a, b) && leftBorder <= Math.Min(a, b))
                return 0;
            else
                return Math.Abs(b - a);
        }
    }
}
