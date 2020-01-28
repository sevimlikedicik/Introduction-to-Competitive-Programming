using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class MinimumNumberOfFlipsToConvertBinaryMatrixToZeroMatrix
    {
        internal class Pair
        {
            public int X;
            public int Y;

            public Pair(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 0,0 }, new int[] { 1, 0, 0} };

            Console.WriteLine(MinFlips(mtr));

            Console.ReadKey();
        }

        static int combIndex = 0;

        public static int MinFlips(int[][] mat)
        {
            bool allZeros = true;

            Pair[] pairs = new Pair[mat.Length * mat[0].Length];

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    pairs[i * mat[0].Length + j] = new Pair(i, j);
                    if (mat[i][j] == 1)
                        allZeros = false;
                }
            }

            if (allZeros)
                return 0;

            Pair[][] combinations = new Pair[(int)Math.Pow(2, pairs.Length)][];

            for (int i = 1; i <= pairs.Length; i++)
                GetCombination(pairs, pairs.Length, i, combinations);

            for (int i = 0; i < combinations.Length - 1; i++)
            {
                int[][] copy = new int[mat.Length][];

                for (int a = 0; a < mat.Length; a++)
                {
                    copy[a] = new int[mat[0].Length];
                    for (int b = 0; b < mat[0].Length; b++)
                        copy[a][b] = mat[a][b];
                }

                if (Flip(copy, combinations[i]))
                    return combinations[i].Length;
            }

            return -1;
        }

        private static bool Flip(int[][] mtr, Pair[] path)
        {
            int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, 0 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            for (int i = 0; i < path.Length; i++)
            {
                for (int j = 0; j < neighbors.Length; j++)
                {
                    int nx = path[i].X + neighbors[j][0];
                    int ny = path[i].Y + neighbors[j][1];

                    if (nx >= 0 && nx < mtr.Length && ny >= 0 && ny < mtr[0].Length)
                    {
                        if (mtr[nx][ny] == 0)
                            mtr[nx][ny] = 1;
                        else
                            mtr[nx][ny] = 0;
                    }
                }
            }

            for (int i = 0; i < mtr.Length; i++)
            {
                for (int j = 0; j < mtr[0].Length; j++)
                {
                    if (mtr[i][j] == 1)
                        return false;
                }
            }

            return true;
        }

        static void combinationUtil(Pair[] arr, int n, int r, int index, Pair[] data, int i, Pair[][] combinations)
        {
            if (index == r)
            {
                combinations[combIndex] = new Pair[r];

                for (int j = 0; j < r; j++)
                    combinations[combIndex][j] = data[j];

                combIndex++;
                return;
            }

            if (i >= n)
                return;

            data[index] = arr[i];
            combinationUtil(arr, n, r, index + 1, data, i + 1, combinations);
            combinationUtil(arr, n, r, index, data, i + 1, combinations);
        }

        static void GetCombination(Pair[] arr, int n, int r, Pair[][] combinations)
        {
            Pair[] data = new Pair[r];
            combinationUtil(arr, n, r, 0, data, 0, combinations);
        }
    }
}
