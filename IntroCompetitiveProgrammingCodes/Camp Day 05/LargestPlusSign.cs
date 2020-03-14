using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class LargestPlusSign
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(OrderOfLargestPlusSign(10, mtr));

            Console.ReadKey();
        }

        public static int OrderOfLargestPlusSign(int N, int[][] mines)
        {
            int[,] mtr = new int[N, N];
            int leftTop = 0;
            int rightBottom = N - 1;
            int counter = 1;

            while (leftTop <= rightBottom) {
                //Fill Rows and columns with counter
                for (int i = leftTop; i <= rightBottom; i++) {
                    mtr[leftTop, i] = counter;
                    mtr[i, leftTop] = counter;
                    mtr[rightBottom, i] = counter;
                    mtr[i, rightBottom] = counter;
                }

                leftTop++;
                rightBottom--;
                counter++;
            }

            for (int i = 0; i < mines.Length; i++)
                DesolateTheMatrix(i, mines, mtr, N);

            int max = 0;
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++)
                    max = Math.Max(mtr[i, j], max);
            }

            return max;
        }

        static void DesolateTheMatrix(int index, int[][] mines, int[,] mtr, int n)
        {
            int x = mines[index][0];
            int y = mines[index][1];
            mtr[x, y] = 0;

            int nx = x - 1;
            int explosion = 1;
            while (nx >= 0)
                mtr[nx, y] = Math.Min(explosion++, mtr[nx--, y]);

            nx = x + 1;
            explosion = 1;
            while (nx < n)
                mtr[nx, y] = Math.Min(explosion++, mtr[nx++, y]);

            int ny = y - 1;
            explosion = 1;
            while (ny >= 0)
                mtr[x, ny] = Math.Min(explosion++, mtr[x, ny--]);

            ny = y + 1;
            explosion = 1;
            while (ny < n)
                mtr[x, ny] = Math.Min(explosion++, mtr[x, ny++]);
        }
    }
}
