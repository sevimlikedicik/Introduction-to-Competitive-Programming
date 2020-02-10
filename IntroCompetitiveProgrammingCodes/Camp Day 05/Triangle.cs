using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class Triangle
    {
        static void Main(string[] args)
        {
            List<IList<int>> lists = new List<IList<int>>();

            Console.WriteLine(MinimumTotal(lists));

            Console.ReadKey();
        }

        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            for (int i = triangle.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < triangle[i].Count - 1; j++)
                    triangle[i - 1][j] += Math.Min(triangle[i][j], triangle[i][j + 1]);
            }

            return triangle[0][0];
        }
    }
}
