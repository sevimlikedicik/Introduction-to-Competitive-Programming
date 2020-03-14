using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_15
{
    class FindTheCityWithTheSmallestNumberOfNeighborsAtAThresholdDistance
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(FindTheCity(3, mtr, 4));

            Console.ReadKey();
        }

        public static int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            Dictionary<int, List<Tuple<int, int>>> edgeDict = new Dictionary<int, List<Tuple<int, int>>>();

            for (int i = 0; i < n; i++) {
                edgeDict.Add(i, new List<Tuple<int, int>>());
            }

            for (int i = 0; i < edges.Length; i++) {
                edgeDict[edges[i][0]].Add(new Tuple<int, int>(edges[i][1], edges[i][2]));
                edgeDict[edges[i][1]].Add(new Tuple<int, int>(edges[i][0], edges[i][2]));
            }

            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < n; i++) {
                Bfs(edgeDict, i, distanceThreshold, ref min, ref minIndex);
            }

            return minIndex;
        }

        static void Bfs(Dictionary<int, List<Tuple<int, int>>> edges, int index, int distanceThreshold, ref int min, ref int minIndex)
        {
            int[] shortestDistance = new int[edges.Count];
            for (int i = 0; i < shortestDistance.Length; i++) {
                shortestDistance[i] = int.MaxValue;
            }

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(index, 0));
            shortestDistance[index] = 0;

            while ((queue.Count != 0)) {
                var curr = queue.Dequeue();

                foreach (var edge in edges[curr.Item1]) {
                    int distance = curr.Item2 + edge.Item2;

                    if (distance <= distanceThreshold && distance < shortestDistance[edge.Item1]) {
                        shortestDistance[edge.Item1] = distance;
                        queue.Enqueue(new Tuple<int, int>(edge.Item1, distance));
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < shortestDistance.Length; i++) {
                count += shortestDistance[i] != int.MaxValue ? 1 : 0;
            }

            if (count <= min) {
                min = count;
                minIndex = index;
            }
        }
    }
}
