using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_09
{
    class CourseScheduleII
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(FindOrder(3, mtr));

            Console.ReadKey();
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            bool[] recStack = new bool[numCourses];
            bool[] visited = new bool[numCourses];
            int[] arr = new int[numCourses];
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

            for (int i = 0; i < prerequisites.Length; i++) {
                if (edges.ContainsKey(prerequisites[i][1]))
                    edges[prerequisites[i][1]].Add(prerequisites[i][0]);
                else
                    edges.Add(prerequisites[i][1], new List<int>() { prerequisites[i][0] });
            }

            bool isCyclic = false;

            for (int i = 0; i < numCourses; i++)
                isCyclic = isCyclic || Dfs(i, visited, recStack, edges);

            if (isCyclic)
                return new int[] { };
            else {
                // Here comes the Bfs
                int[] incomingEdges = new int[numCourses];
                int lastIndex = 0;

                for (int i = 0; i < numCourses; i++)
                    visited[i] = false;

                for (int i = 0; i < prerequisites.Length; i++)
                    incomingEdges[prerequisites[i][0]]++;

                Queue<int> queue = new Queue<int>();

                for (int i = 0; i < numCourses; i++) {
                    if (incomingEdges[i] == 0) {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }

                while (queue.Count != 0) {
                    int curr = queue.Dequeue();
                    arr[lastIndex++] = curr;

                    if (edges.ContainsKey(curr)) {
                        foreach (int child in edges[curr]) {
                            incomingEdges[child]--;

                            if (incomingEdges[child] == 0) {
                                queue.Enqueue(child);
                                visited[child] = true;
                            }
                        }
                    }
                }

                return arr;
            }
        }

        static bool Dfs(int index, bool[] visited, bool[] recStack, Dictionary<int, List<int>> edges)
        {
            if (recStack[index])
                return true;

            if (visited[index])
                return false;

            recStack[index] = true;
            visited[index] = true;

            if (edges.ContainsKey(index)) {
                foreach (int child in edges[index]) {
                    if (Dfs(child, visited, recStack, edges))
                        return true;
                }
            }

            recStack[index] = false;

            return false;
        }
    }
}
