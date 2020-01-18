using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class NumberOfClosedIslands
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] {0,0,1,1,0,1,0,0,1,0 },new int[] {1,1,0,1,1,0,1,1,1,0 }, new int[] {1,0,1,1,1,0,0,1,1,0 },
               new int[] {0,1,1,0,0,0,0,1,0,1 },new int[] {0,0,0,0,0,0,1,1,1,0}, new int[] {0,1,0,1,0,1,0,1,1,1 }, new int[] { 1,0,1,0,1,1,0,0,0,1 }, new int[] { 1,1,1,1,1,1,0,0,0,0 }, new int[] {1,1,1,0,0,1,0,1,0,1}, new int[] {1,1,1,0,1,1,0,1,1,0 }};

            Console.WriteLine(ClosedIsland(mtr));

            Console.ReadKey();
        }

        public static int ClosedIsland(int[][] grid)
        {
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int islandsCount = 0;
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                        visited[i, j] = true;
                    else if (!visited[i, j])
                    {
                        visited[i, j] = true;

                        if (IslandIsClosed(grid, visited, i, j, neighbors))
                            islandsCount++;
                    }
                }
            }

            return islandsCount;
        }

        private static bool IslandIsClosed(int[][] grid, bool[,] visited, int iCoord, int jCoord, int[][] neighbors)
        {
            int nx, ny;
            visited[iCoord, jCoord] = true;
            bool ret = true;

            for (int i = 0; i < 4; i++)
            {
                nx = iCoord + neighbors[i][0];
                ny = jCoord + neighbors[i][1];

                if ((nx < 0 || nx >= grid.Length || ny < 0 || ny >= grid[0].Length) || grid[nx][ny] != 1 && !visited[nx, ny] && !IslandIsClosed(grid, visited, nx, ny, neighbors))
                    ret = false;
            }

            return ret;
        }
    }
}
