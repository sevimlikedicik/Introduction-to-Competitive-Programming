using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class UniquePathsII
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(UniquePathsWithObstacles(mtr));

            Console.ReadKey();
        }

        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1)
                return 0;

            int[][] res = new int[obstacleGrid.Length][];

            bool zeroFound = false;

            for (int i = 0; i < obstacleGrid.Length; i++)
            {
                res[i] = new int[obstacleGrid[0].Length];
                if (obstacleGrid[i][0] == 1)
                {
                    res[i][0] = 0;
                    zeroFound = true;
                }
                else
                {
                    if (!zeroFound)
                        res[i][0] = 1;
                }
            }

            zeroFound = false;

            for (int i = 0; i < obstacleGrid[0].Length; i++)
            {
                if (obstacleGrid[0][i] == 1)
                {
                    res[0][i] = 0;
                    zeroFound = true;
                }
                else
                {
                    if (!zeroFound)
                        res[0][i] = 1;
                }
            }

            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                for (int j = 1; j < obstacleGrid[0].Length; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                        res[i][j] = 0;
                    else
                        res[i][j] = res[i][j - 1] + res[i - 1][j];
                }
            }

            return res[res.Length - 1][res[0].Length - 1];
        }
    }
}
