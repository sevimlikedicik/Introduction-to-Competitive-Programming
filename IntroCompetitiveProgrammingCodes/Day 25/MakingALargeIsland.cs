using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class MakingALargeIsland
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 } };

            int[][] mtr2 = new int[][] { new int[] {0,0,1,1,0,1,0,0,1,0 },new int[] {1,1,0,1,1,0,1,1,1,0 }, new int[] {1,0,1,1,1,0,0,1,1,0 },
               new int[] {0,1,1,0,0,0,0,1,0,1 },new int[] {0,0,0,0,0,0,1,1,1,0}, new int[] {0,1,0,1,0,1,0,1,1,1 }, new int[] { 1,0,1,0,1,1,0,0,0,1 }, new int[] { 1,1,1,1,1,1,0,0,0,0 }, new int[] {1,1,1,0,0,1,0,1,0,1}, new int[] {1,1,1,0,1,1,0,1,1,0 }};

            Console.WriteLine(LargestIsland(mtr));

            Console.ReadKey();
        }

        public static int LargestIsland(int[][] grid)
        {
            // Key is index, Value is size of the island.
            Dictionary<int, int> islands = new Dictionary<int, int>();

            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int[,] newGrid = new int[grid.Length, grid[0].Length];
            int islandCount = 1;
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            int max = int.MinValue;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                        visited[i, j] = true;
                    else if (!visited[i, j])
                    {
                        int size = ExploreIsland(grid, newGrid, visited, i, j, neighbors, islands, islandCount);
                        islands.Add(islandCount++, size);
                        if (size + 1 > max)
                            max = size + 1;
                    }
                }
            }

            int mergeSize;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 0)
                    {
                        mergeSize = Merge(newGrid, i, j, neighbors, islands);
                        if (mergeSize > max)
                            max = mergeSize;
                    }
                }
            }

            if (max == grid.Length * grid[0].Length + 1)
                return max - 1;

            if (max == int.MinValue)
                return 1;

            return max;
        }

        private static int Merge(int[,] newGrid, int iCoord, int jCoord, int[][] neighbors, Dictionary<int, int> islands)
        {
            int mergeVal;
            int max = int.MinValue;

            for (int i = 0; i < 4; i++)
            {
                int nx1 = iCoord + neighbors[i][0];
                int ny1 = jCoord + neighbors[i][1];

                if (!(nx1 < 0 || nx1 >= newGrid.GetLength(0) || ny1 < 0 || ny1 >= newGrid.GetLength(1) || newGrid[nx1, ny1] != 0))
                {
                    mergeVal = islands[newGrid[iCoord, jCoord]] + 1;
                    List<int> islandsToMerge = new List<int>();

                    for (int j = 0; j < 4; j++)
                    {
                        int nx2 = nx1 + neighbors[j][0];
                        int ny2 = ny1 + neighbors[j][1];

                        if (!(nx2 < 0 || nx2 >= newGrid.GetLength(0) || ny2 < 0 || ny2 >= newGrid.GetLength(1) || newGrid[nx2, ny2] == 0))
                        {
                            if (newGrid[nx2, ny2] != newGrid[iCoord, jCoord])
                            {
                                if (!islandsToMerge.Contains(newGrid[nx2, ny2]))
                                    islandsToMerge.Add(newGrid[nx2, ny2]);
                            }
                        }
                    }

                    foreach (int island in islandsToMerge)
                        mergeVal += islands[island];

                    if (mergeVal > max)
                        max = mergeVal;
                }
            }

            return max;
        }

        private static int ExploreIsland(int[][] grid, int[,] newGrid, bool[,] visited, int iCoord, int jCoord, int[][] neighbors, Dictionary<int, int> islands, int islandCount)
        {
            int nx, ny;
            visited[iCoord, jCoord] = true;
            newGrid[iCoord, jCoord] = islandCount;
            int size = 1;

            for (int i = 0; i < 4; i++)
            {
                nx = iCoord + neighbors[i][0];
                ny = jCoord + neighbors[i][1];

                if (!(nx < 0 || nx >= grid.Length || ny < 0 || ny >= grid[0].Length || grid[nx][ny] == 0 || visited[nx, ny]))
                    size += ExploreIsland(grid, newGrid, visited, nx, ny, neighbors, islands, islandCount);
            }

            return size;
        }
    }
}
