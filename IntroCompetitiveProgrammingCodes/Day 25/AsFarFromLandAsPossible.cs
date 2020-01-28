using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class AsFarFromLandAsPossible
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
            int[][] mtr = new int[][] { new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 }, new int[] { 1, 0, 1 } };

            Console.WriteLine(MaxDistance(mtr));

            Console.ReadKey();
        }

        public static int MaxDistance(int[][] grid)
        {
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int[,] distances = new int[grid.Length, grid[0].Length];
            
            List<Coordinate> currentCoordinates = new List<Coordinate>();
            int remainingZeros = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        visited[i, j] = true;

                        for (int k = 0; k < neighbors.Length; k++)
                        {
                            int nx = i + neighbors[k][0];
                            int ny = j + neighbors[k][1];

                            if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length && !visited[nx, ny] && grid[nx][ny] == 0)
                            {
                                visited[nx, ny] = true;
                                currentCoordinates.Add(new Coordinate(nx, ny));
                                remainingZeros--;
                            }
                        }
                    }
                    else
                        remainingZeros++;
                }
            }

            if (remainingZeros == grid.Length * grid[0].Length || remainingZeros == 0)
                return -1;

            return FillAll(grid, visited, neighbors, currentCoordinates,remainingZeros, 2);
        }

        private static int FillAll(int[][] grid, bool[,] visited, int[][] neighbors, List<Coordinate> previousCoordinates, int remainingZeros, int distance)
        {
            if (remainingZeros == 0)
                return distance - 1;

            List<Coordinate> currentCoordinates = new List<Coordinate>();

            foreach(var coord in previousCoordinates)
            {
                for (int k = 0; k < neighbors.Length; k++)
                {
                    int nx = coord.I + neighbors[k][0];
                    int ny = coord.J + neighbors[k][1];

                    if (nx >= 0 && nx < grid.Length && ny >= 0 && ny < grid[0].Length && !visited[nx, ny] && grid[nx][ny] == 0)
                    {
                        visited[nx, ny] = true;
                        currentCoordinates.Add(new Coordinate(nx, ny));
                        remainingZeros--;
                    }
                }
            }

            return FillAll(grid, visited, neighbors, currentCoordinates, remainingZeros, distance + 1);
        }
    }
}
