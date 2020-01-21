using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class Minesweeper
    {
        static void Main(string[] args)
        {
            char[][] mtr = new char[][] { new char[] { 'B', '1', 'E', '1', 'B' }, new char[] { 'B', '1', 'M', '1', 'B' },
                new char[] { 'B', '1', '1', '1', 'B' }, new char[] { 'B', 'B', 'B', 'B', 'B' } };

            var newMtr = UpdateBoard(mtr, new int[] { 0, 2 });

            for (int i = 0; i < newMtr.Length; i++)
            {
                for (int j = 0; j < newMtr[0].Length; j++)
                    Console.Write(newMtr[i][j] + " ");

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static char[][] UpdateBoard(char[][] board, int[] click)
        {
            if (board[click[0]][click[1]] == 'M')
            {
                board[click[0]][click[1]] = 'X';
                return board;
            }

            int[][] neighbors = new int[][] { new int[] { -1, -1 }, new int[] { -1, 0 }, new int[] { -1, 1 }, new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, -1 }, new int[] { 1, 0 }, new int[] { 1, 1 } };
            bool[,] visited = new bool[board.Length, board[0].Length];

            UpdateBoard(board, visited, click[0], click[1], neighbors);

            return board;
        }

        private static void UpdateBoard(char[][] board, bool[,] visited, int iCoord, int jCoord, int[][] neighbors)
        {
            char c = board[iCoord][jCoord];
            visited[iCoord, jCoord] = true;
            int mineCount = 0;

            for (int i = 0; i < neighbors.Length; i++)
            {
                int nx = iCoord + neighbors[i][0];
                int ny = jCoord + neighbors[i][1];

                if (!(nx < 0 || nx >= board.Length || ny < 0 || ny >= board[0].Length) && !visited[nx, ny])
                {
                    if (board[nx][ny] == 'M')
                        mineCount++;
                }
            }

            if (mineCount > 0)
                board[iCoord][jCoord] = (char)('0' + mineCount);
            else
            {
                board[iCoord][jCoord] = 'B';

                for (int i = 0; i < neighbors.Length; i++)
                {
                    int nx = iCoord + neighbors[i][0];
                    int ny = jCoord + neighbors[i][1];

                    if (!(nx < 0 || nx >= board.Length || ny < 0 || ny >= board[0].Length) && !visited[nx, ny])
                        UpdateBoard(board, visited, nx, ny, neighbors);
                }
            }
        }
    }
}
