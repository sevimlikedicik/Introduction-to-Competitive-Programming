using System;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class FloodFill
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(FillFlood(mtr, 1, 1, 1));

            Console.ReadKey();
        }

        static int[][] neighbors = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        static bool[,] visited;

        public static int[][] FillFlood(int[][] image, int sr, int sc, int newColor)
        {
            visited = new bool[image.Length, image[0].Length];
            FillTheMatris(image, sr, sc, newColor);
            return image;
        }

        private static void FillTheMatris(int[][] image, int sr, int sc, int newColor)
        {
            int oldColor = image[sr][sc];
            image[sr][sc] = newColor;
            visited[sr, sc] = true;

            for (int i = 0; i < neighbors.Length; i++)
            {
                int nx = sr + neighbors[i][0];
                int ny = sc + neighbors[i][1];

                if (nx >= 0 && nx < image.Length && ny >= 0 && ny < image[0].Length && image[nx][ny] == oldColor && !visited[nx, ny])
                    FillTheMatris(image, nx, ny, newColor);
            }
        }
    }
}
