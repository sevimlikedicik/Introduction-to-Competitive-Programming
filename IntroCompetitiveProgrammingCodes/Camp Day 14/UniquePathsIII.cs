using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_14
{
    class UniquePathsIII
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(UniquePaths(mtr));

            Console.ReadKey();
        }

        public static int UniquePaths(int[][] grid)
        {
            int requiredZeros = 0;
            Tuple<int, int> start = new Tuple<int, int>(0, 0);
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    start = grid[i][j] == 1 ? new Tuple<int, int>(i, j) : start;
                    requiredZeros += grid[i][j] == 0 ? 1 : 0;
                }
            }

            return Dfs(start, visited, neighbors, grid, 0, requiredZeros);
        }

        static int Dfs(Tuple<int, int> coordinate, bool[,] visited, int[][] neighbors, int[][] grid, int currZeros, int requiredZeros)
        {
            if (grid[coordinate.Item1][coordinate.Item2] == 2)
                return currZeros == requiredZeros ? 1 : 0;

            visited[coordinate.Item1, coordinate.Item2] = true;
            int totalPaths = 0;

            for (int i = 0; i < neighbors.Length; i++)
            {
                int nx = coordinate.Item1 + neighbors[i][0];
                int ny = coordinate.Item2 + neighbors[i][1];

                // All the edge cases for a new coordinate.
                if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length && !visited[nx, ny] && grid[nx][ny] != -1)
                {
                    Tuple<int, int> newCoord = new Tuple<int, int>(nx, ny);
                    totalPaths += Dfs(newCoord, visited, neighbors, grid, (grid[nx][ny] == 0) ? currZeros + 1 : currZeros, requiredZeros);
                }
            }

            visited[coordinate.Item1, coordinate.Item2] = false;
            return totalPaths;
        }
    }
}
