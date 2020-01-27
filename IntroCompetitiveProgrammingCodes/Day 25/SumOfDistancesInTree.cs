using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class SumOfDistancesInTree
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[10000][];

            for (int i = 0; i < 10000; i++)
                mtr[i] = new int[] { i, i + 1 };

            int[][] mtr2 = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 4, 5 } };

            var root = SumOfDistances(6, mtr2);

            Console.ReadKey();
        }

        public static int[] SumOfDistances(int N, int[][] edges)
        {
            int[] totaldistances = new int[N];
            int[] nodeCount = new int[N];
            bool[] visited = new bool[N];
            List<int>[] adjList = new List<int>[N];

            for (int i = 0; i < N; i++)
            {
                adjList[i] = new List<int>();
                nodeCount[i] = 1;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int node1 = edges[i][0];
                int node2 = edges[i][1];
                adjList[node1].Add(node2);
                adjList[node2].Add(node1);
            }

            Magic(0, adjList, visited, totaldistances, nodeCount);

            for (int i = 1; i < N; i++)
                visited[i] = false;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                visited[node] = true;

                foreach (int adj in adjList[node])
                {
                    if (!visited[adj])
                    {
                        queue.Enqueue(adj);
                        totaldistances[adj] += N - nodeCount[adj] + totaldistances[node] - (totaldistances[adj] + nodeCount[adj]);
                    }
                }
            }

            return totaldistances;
        }

        private static void Magic(int node, List<int>[] adjList, bool[] visited, int[] totaldistances, int[] nodeCount)
        {
            visited[node] = true;

            foreach (int adj in adjList[node])
            {
                if (!visited[adj])
                {
                    Magic(adj, adjList, visited, totaldistances, nodeCount);
                    nodeCount[node] += nodeCount[adj];
                    totaldistances[node] += nodeCount[adj] + totaldistances[adj];
                }
            }
        }
    }
}
