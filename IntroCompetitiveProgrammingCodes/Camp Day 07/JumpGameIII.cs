using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_07
{
    class JumpGameIII
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 0, 2, 1, 2 };

            Console.WriteLine(CanReach(arr, 2));

            Console.ReadKey();
        }

        public static bool CanReach(int[] arr, int start)
        {
            bool[] visited = new bool[arr.Length];

            return TryZero(arr, start, visited);
        }

        private static bool TryZero(int[] arr, int index, bool[] visited)
        {
            if (index < 0 || index >= arr.Length)
                return false;

            if (visited[index])
                return false;

            if (arr[index] == 0)
                return true;

            visited[index] = true;

            return TryZero(arr, index + arr[index], visited) || TryZero(arr, index - arr[index], visited);
        }
    }
}
