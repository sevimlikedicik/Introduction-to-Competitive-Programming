using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class RottingOranges
    {
        internal class Coordinate
        {
            public int I;
            public int J;

            public Coordinate(int i, int j)
            {
                I = i;
                J = j;
            }
        }

        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 0, 1 } };

            Console.WriteLine(OrangesRotting(mtr));

            Console.ReadKey();
        }

        public static int OrangesRotting(int[][] grid)
        {
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            List<Coordinate> rottenCoordinates = new List<Coordinate>();
            int freshCount = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                        freshCount++;

                    if (grid[i][j] == 2)
                        rottenCoordinates.Add(new Coordinate(i, j));
                }
            }

            int totalTime = OrangesRotting(grid, visited, neighbors, rottenCoordinates, freshCount);

            if (freshForever)
                return -1;

            return totalTime;
        }

        static bool freshForever;

        private static int OrangesRotting(int[][] grid, bool[,] visited, int[][] neighbors, List<Coordinate> rottenCoordinates, int freshCount)
        {
            if (freshCount == 0)
                return 0;

            int oldFreshCount = freshCount;
            List<Coordinate> newRottenCoordinates = new List<Coordinate>();

            foreach (var coord in rottenCoordinates)
            {
                for (int i = 0; i < neighbors.Length; i++)
                {
                    int nx = coord.I + neighbors[i][0];
                    int ny = coord.J + neighbors[i][1];

                    if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length && !visited[nx, ny] && grid[nx][ny] == 1)
                    {
                        visited[nx, ny] = true;
                        freshCount--;
                        newRottenCoordinates.Add(new Coordinate(nx, ny));
                    }
                }
            }

            if (freshCount == oldFreshCount)
            {
                freshForever = true;
                return 0;
            }

            return OrangesRotting(grid, visited, neighbors, newRottenCoordinates, freshCount) + 1;
        }
    }
}
