using System;
using System.Collections.Generic;
using System.Numerics;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class KnightProbabiltyInChessboard
    {
        internal class BoardState
        {
            public List<Tuple<int, int>> Neighbors;
            public long ValidMoves;

            public BoardState(List<Tuple<int, int>> neighbors, long validMoves)
            {
                Neighbors = neighbors;
                ValidMoves = validMoves;
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(KnightProbability(3, 2, 1, 1));
            Console.WriteLine(KnightProbability(3, 100, 0, 0));

            Console.ReadKey();
        }
        public static double KnightProbability(int N, int K, int r, int c)
        {
            if (K == 0)
                return 1;

            int[][] neighbors = new int[][] { new int[] { -1, -2 }, new int[] { -2, -1 }, new int[] { -2, 1 }, new int[] { -1, 2 }, new int[] { 1, -2 }, new int[] { 2, -1 }, new int[] { 1, 2 }, new int[] { 2, 1 } };

            BoardState[,] dp = new BoardState[N, N];
            BigInteger[] validMoves = new BigInteger[K];
            BigInteger[] possibleMoves = new BigInteger[K];
            int maxDepth = 0;
            BigInteger[,] prevCoordinates = new BigInteger[N, N];
            BigInteger[,] currCoordinates = new BigInteger[N, N];

            BigInteger a = 2;
            a += 2 * 5;

            prevCoordinates[r, c] = 1;

            int elementCount = 1;

            for (int i = 0; i < K && elementCount != 0; i++)
            {
                elementCount = 0;

                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        if (prevCoordinates[j, k] != 0)
                        {
                            elementCount++;
                            if (dp[j, k] != null)
                            {
                                foreach (var coord in dp[j, k].Neighbors)
                                    currCoordinates[coord.Item1, coord.Item2] += prevCoordinates[j, k];

                                validMoves[i] += dp[j, k].ValidMoves * prevCoordinates[j, k];
                                possibleMoves[i] += 8 * prevCoordinates[j, k];
                            }
                            else
                            {
                                List<Tuple<int, int>> nb = new List<Tuple<int, int>>();
                                int valid = 0;

                                // Look for neighbors
                                for (int m = 0; m < neighbors.Length; m++)
                                {
                                    int nx = j + neighbors[m][0];
                                    int ny = k + neighbors[m][1];

                                    if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                                    {
                                        nb.Add(new Tuple<int, int>(nx, ny));
                                        valid++;
                                    }
                                }

                                validMoves[i] += valid * prevCoordinates[j, k];
                                possibleMoves[i] += 8 * prevCoordinates[j, k];
                                foreach (var coord in nb)
                                    currCoordinates[coord.Item1, coord.Item2] += prevCoordinates[j, k];
                                dp[j, k] = new BoardState(nb, valid);
                            }
                        }
                    }
                }

                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        prevCoordinates[j, k] = currCoordinates[j, k];
                        currCoordinates[j, k] = 0;
                    }
                }
                maxDepth = i + 1;
            }

            double possibility = 1;
            maxDepth = elementCount == 0 ? maxDepth - 1 : maxDepth;

            for (int i = 0; i < maxDepth; i++)
            {
                Console.WriteLine(validMoves[i] + " " + possibleMoves[i]);
                possibility *= ((double)((validMoves[i] * 1000000000000) / possibleMoves[i]) / 1000000000000);
            }

            return Math.Round(possibility, 5);
        }
    }
}
