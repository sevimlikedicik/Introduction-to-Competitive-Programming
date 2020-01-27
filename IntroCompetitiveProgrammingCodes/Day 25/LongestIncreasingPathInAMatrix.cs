using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class LongestIncreasingPathInAMatrix
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 3, 4, 5 }, new int[] { 3, 2, 6 }, new int[] { 2, 2, 7 } };

            Console.WriteLine(LongestIncreasingPath(mtr));

            Console.ReadKey();
        }

        public static int LongestIncreasingPath(int[][] matrix)
        {
            int[,] longestPath = new int[matrix.Length, matrix[0].Length];
            bool[,] pathFound = new bool[matrix.Length, matrix[0].Length];
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            int max = int.MinValue;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int path = Dfs(i, j, matrix, neighbors, pathFound, longestPath);
                    if (path > max)
                        max = path;
                }
            }

            return max;
        }

        private static int Dfs(int iCoord, int jCoord, int[][] matrix, int[][] neighbors, bool[,] pathFound, int[,] longestPath)
        {
            int max = 1;

            for (int i = 0; i < 4; i++)
            {
                int nx = neighbors[i][0] + iCoord;
                int ny = neighbors[i][1] + jCoord;

                if (!(nx < 0 || nx >= matrix.Length || ny < 0 || ny >= matrix[0].Length) && matrix[nx][ny] > matrix[iCoord][jCoord])
                {
                    int path;
                    if (pathFound[nx, ny])
                        path = longestPath[nx, ny];
                    else
                        path = Dfs(nx, ny, matrix, neighbors, pathFound, longestPath) + 1;

                    if (path > max)
                        max = path;
                }

            }

            pathFound[iCoord, jCoord] = true;
            longestPath[iCoord, jCoord] = max;
            return max;
        }
    }
}
