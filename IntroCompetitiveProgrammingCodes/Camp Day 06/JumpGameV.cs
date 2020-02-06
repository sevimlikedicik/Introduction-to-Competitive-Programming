using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_06
{
    class JumpGameV
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 39, 1, 1, 19, 40, 34, 87, 44, 30, 3, 89, 55, 81, 97, 84, 52, 10, 8, 96, 69, 17, 48, 93, 84, 10, 48, 1, 93, 65, 24, 100, 26, 24, 33, 52, 17, 15, 26, 8, 87, 69, 47, 61, 58, 78, 52, 2, 72, 23, 9, 3, 27, 36, 38, 88, 20, 21, 79, 5, 67, 22, 24, 39, 7, 17, 29, 3, 97, 36, 51, 91, 53, 98, 48, 83, 52, 14, 71, 91, 46, 42, 88, 44, 52, 74, 8, 39, 11, 48, 59, 98, 34, 43, 94, 46, 20, 26, 62, 6, 36, 59, 77, 23, 93, 6, 93, 64, 18, 33, 69, 56, 48, 54, 98, 98, 53, 14, 97, 47, 50, 33, 87, 10, 51, 92, 1, 14, 27, 19, 34, 83, 65, 48, 44, 82, 51, 81, 83, 23, 8, 63, 70, 76, 83, 46, 84, 20, 7, 37, 4, 69, 63, 84, 71, 91, 78, 58, 25, 63, 85, 98, 78, 21 };

            Console.WriteLine(MaxJumps(arr, 62));

            Console.ReadKey();
        }

        public static int MaxJumps(int[] arr, int d)
        {
            Dictionary<int, List<int>> adjDict = new Dictionary<int, List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];
                int max = int.MinValue;
                adjDict.Add(i, new List<int>());

                for (int j = 1; j <= d && i - j >= 0; j++)
                {
                    int index = i - j;

                    if (index >= 0 && val > max && arr[index] < val)
                        adjDict[i].Add(index);

                    if (index >= 0 && arr[index] > max)
                        max = arr[index];
                }

                max = int.MinValue;
                for (int j = 1; j <= d; j++)
                {
                    int index = i + j;

                    if (index < arr.Length && val > max && arr[index] < val)
                        adjDict[i].Add(index);

                    if (index < arr.Length && arr[index] > max)
                        max = arr[index];
                }
            }

            int[] reach = new int[arr.Length];
            bool[] visited = new bool[arr.Length];

            // DFS
            for (int i = 0; i < arr.Length; i++)
                FindMaxPath(reach, i, visited, adjDict);

            return reach.Max();
        }

        private static int FindMaxPath(int[] reach, int index, bool[] visited, Dictionary<int, List<int>> adjDict)
        {
            if (visited[index])
                return reach[index];

            int max = 0;

            foreach (int adj in adjDict[index])
            {
                int path = FindMaxPath(reach, adj, visited, adjDict);
                if (path > max)
                    max = path;
            }

            visited[index] = true;
            reach[index] = max + 1;
            return max + 1;
        }
    }
}
