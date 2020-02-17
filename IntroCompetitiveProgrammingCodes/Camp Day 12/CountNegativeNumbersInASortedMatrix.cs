using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_12
{
    class CountNegativeNumbersInASortedMatrix
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(CountNegatives(mtr));

            Console.ReadKey();
        }

        public static int CountNegatives(int[][] grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] < 0)
                        count++;
                }
            }

            return count;
        }
    }
}
