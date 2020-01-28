using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class ShortestPathInBinaryMatrix
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
            int[][] mtr = new int[][] { new int[] { 0, 0, 0, 0 }, new int[] { 1, 0, 0, 1 }, new int[] { 0, 1, 0, 0 }, new int[] { 0, 0, 0, 0 } };

            Console.WriteLine(ShortestPathBinaryMatrix(mtr));

            Console.ReadKey();
        }

        public static int ShortestPathBinaryMatrix(int[][] grid)
        {
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int[,] shortestPaths = new int[grid.Length, grid[0].Length];
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { 1, 1 } };

            if (grid[grid.Length - 1][grid[0].Length - 1] == 1)
                return -1;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                    shortestPaths[i, j] = int.MaxValue;
            }

            FindPaths(grid, visited, shortestPaths, neighbors, grid.Length - 1, grid[0].Length - 1, 1);
            //int shortestPath = FindShortestPath(grid, 0, 0, neighbors, visited);

            return shortestPaths[0, 0];
        }

        private static void FindPaths(int[][] grid, bool[,] visited, int[,] shortestPaths, int[][] neighbors, int iCoord, int jCoord, int path)
        {
            shortestPaths[iCoord, jCoord] = 1;
            visited[iCoord, jCoord] = true;
            Queue<Coordinate> queue = new Queue<Coordinate>();
            queue.Enqueue(new Coordinate(iCoord, jCoord));

            while(queue.Count != 0)
            {
                Coordinate cd = queue.Dequeue();

                for (int i = 0; i < neighbors.Length; i++)
                {
                    int nx = cd.I + neighbors[i][0];
                    int ny = cd.J + neighbors[i][1];

                    if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length && !visited[nx, ny] && grid[nx][ny] == 0)
                    {
                        queue.Enqueue(new Coordinate(nx, ny));
                        shortestPaths[nx, ny] = shortestPaths[cd.I, cd.J] + 1;
                        visited[nx, ny] = true;
                    }
                }
            }
        }

        private static int FindShortestPath(int[][] grid, int iCoord, int jCoord, int[][] neighbors, bool[,] visited)
        {
            if (iCoord == grid.Length - 1 && jCoord == grid[0].Length - 1)
                return 1;

            visited[iCoord, jCoord] = true;
            bool noWayOut = true;
            int minPath = int.MaxValue;

            for (int i = 0; i < neighbors.Length; i++)
            {
                int nx = iCoord + neighbors[i][0];
                int ny = jCoord + neighbors[i][1];

                if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length && !visited[nx, ny] && grid[nx][ny] == 0)
                {
                    int patio = FindShortestPath(grid, nx, ny, neighbors, visited) + 1;

                    if (patio < minPath)
                        minPath = patio;

                    if (patio <= int.MaxValue - grid.Length * grid[0].Length * 2)
                        noWayOut = false;
                }
            }

            visited[iCoord, jCoord] = false;

            if (noWayOut)
                return int.MaxValue - grid.Length * grid[0].Length * 2;

            return minPath;
        }
    }
}
