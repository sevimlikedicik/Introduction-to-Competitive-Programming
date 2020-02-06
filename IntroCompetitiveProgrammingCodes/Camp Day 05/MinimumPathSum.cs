using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class MinimumPathSum
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 2 }, new int[] { 1, 1 } };

            Console.WriteLine(MinPathSum(mtr));

            Console.ReadKey();
        }

        public static int MinPathSum(int[][] grid)
        {
            int[,] shortestPaths = new int[grid.Length, grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    int nx = i - 1;
                    int ny = j - 1;
                    int left = int.MaxValue, top = int.MaxValue;

                    if (nx >= 0 && nx < grid.Length)
                        top = shortestPaths[nx, j];

                    if (ny >= 0 && ny < grid[0].Length)
                        left = shortestPaths[i, ny];

                    if (left == int.MaxValue && top == int.MaxValue)
                        shortestPaths[i, j] = grid[i][j];
                    else
                        shortestPaths[i, j] = Math.Min(left, top) + grid[i][j];
                }
            }

            return shortestPaths[grid.Length - 1, grid[0].Length - 1];
        }
    }
}
