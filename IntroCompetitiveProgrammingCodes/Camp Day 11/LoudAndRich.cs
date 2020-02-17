using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_11
{
    class LoudAndRich
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            LoudRich(mtr, arr);

            Console.ReadKey();
        }

        public static int[] LoudRich(int[][] richer, int[] quiet)
        {
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
            bool[] visited = new bool[quiet.Length];
            int[] answer = new int[quiet.Length];

            for (int i = 0; i < richer.Length; i++)
            {
                if (edges.ContainsKey(richer[i][1]))
                    edges[richer[i][1]].Add(richer[i][0]);
                else
                    edges.Add(richer[i][1], new List<int>() { richer[i][0] });
            }
            for (int i = 0; i < answer.Length; i++)
            {
                Dfs(edges, i, answer, quiet, visited);
            }
            return answer;
        }

        static int Dfs(Dictionary<int, List<int>> edges, int index, int[] answer, int[] quiet, bool[] visited)
        {
            if (visited[index])
            {
                return answer[index];
            }
            if (!edges.ContainsKey(index))
            {
                answer[index] = index;
                visited[index] = true;
                return index;
            }

            int minIndex = index;

            foreach (int adj in edges[index])
            {
                int newInd = Dfs(edges, adj, answer, quiet, visited);
                if (quiet[minIndex] > quiet[newInd])
                {
                    minIndex = newInd;
                }
            }

            answer[index] = minIndex;
            visited[index] = true;
            return minIndex;
        }
    }
}
