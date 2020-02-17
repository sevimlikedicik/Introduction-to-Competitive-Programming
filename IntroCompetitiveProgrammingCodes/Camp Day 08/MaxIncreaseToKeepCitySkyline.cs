using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_08
{
    class MaxIncreaseToKeepCitySkyline
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            MaxIncreaseKeepingSkyline(mtr);

            Console.ReadKey();
        }

        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int[] topSkylines = new int[grid.Length];
            int[] leftSkylines = new int[grid.Length];

            for (int i = 0; i < grid.Length; i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < grid.Length; j++)
                    max = Math.Max(grid[i][j], max);

                leftSkylines[i] = max;

                max = int.MinValue;
                for (int j = 0; j < grid.Length; j++)
                    max = Math.Max(grid[j][i], max);

                topSkylines[i] = max;
            }

            int totalDif = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                    totalDif += Math.Min(leftSkylines[i], topSkylines[j]) - grid[i][j];
            }

            return totalDif;
        }
    }
}
