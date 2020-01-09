using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_18
{
    class BerryJam
    {
        public enum Direction
        {
            Left,

            Right
        }

        public enum ExtraJarType
        {
            Strawberry,

            Blueberry
        }

        static void Main(string[] args)
        {
            int t = ReadInt();
            int[] arr = new int[200000];

            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                var phrase = ReadLineAsArray();

                for (int j = 0; j < 2 * n; j++)
                    arr[j] = ConvertInt(phrase[j]);

                Console.WriteLine(Solve(arr, n));
            }
        }

        private static int Solve(int[] arr, int n)
        {
            int strawberries = 0;
            int blueberries = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                if (arr[i] == 1)
                    strawberries++;
                else
                {
                    blueberries++;
                    arr[i] = -1;
                }
            }

            int[] leftSideCheckPoints = Enumerable.Repeat(int.MaxValue / 2, 2 * n + 1).ToArray();
            int[] rightSideCheckPoints = Enumerable.Repeat(int.MaxValue / 2, 2 * n + 1).ToArray();

            leftSideCheckPoints[0] = 0;
            rightSideCheckPoints[0] = 0;

            if (strawberries > blueberries)
            {
                FindCheckpoint(arr, n, leftSideCheckPoints, ExtraJarType.Strawberry, Direction.Left);
                FindCheckpoint(arr, n, rightSideCheckPoints, ExtraJarType.Strawberry, Direction.Right);
            }
            else
            {
                FindCheckpoint(arr, n, leftSideCheckPoints, ExtraJarType.Blueberry, Direction.Left);
                FindCheckpoint(arr, n, rightSideCheckPoints, ExtraJarType.Blueberry, Direction.Right);
            }

            int minJars = int.MaxValue;
            int diff = Math.Abs(strawberries - blueberries);

            for (int i = 0; i <= diff; i++)
            {
                int totalJars = leftSideCheckPoints[i] + rightSideCheckPoints[diff - i];

                if (totalJars < minJars)
                    minJars = totalJars;
            }

            return minJars;
        }

        private static void FindCheckpoint(int[] arr, int n, int[] checkPoints, ExtraJarType jarType, Direction direction)
        {
            int profit = 0;

            for (int i = direction == Direction.Left ? n - 1 : n; i >= 0 && i < 2 * n; i += direction.Equals(Direction.Left) ? -1 : 1)
            {
                if (jarType == ExtraJarType.Strawberry)
                {
                    profit += arr[i];
                }
                else
                {
                    profit -= arr[i];
                }

                if (profit > 0)
                {
                    if (checkPoints[profit] == int.MaxValue / 2)
                        checkPoints[profit] = direction.Equals(Direction.Left) ? n - i : i - n + 1;
                }
            }
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
