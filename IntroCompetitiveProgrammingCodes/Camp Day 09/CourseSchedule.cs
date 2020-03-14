using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_09
{
    class CourseSchedule
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(CanFinish(3, mtr));

            Console.ReadKey();
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
            bool[] visited = new bool[numCourses];
            bool[] recStack = new bool[numCourses];

            for (int i = 0; i < prerequisites.Length; i++) {
                if (edges.ContainsKey(prerequisites[i][1]))
                    edges[prerequisites[i][1]].Add(prerequisites[i][0]);
                else
                    edges.Add(prerequisites[i][1], new List<int>() { prerequisites[i][0] });
            }

            bool isCyclic = false;

            for (int i = 0; i < numCourses; i++)
                isCyclic = isCyclic || Dfs(i, visited, recStack, edges);

            return !isCyclic;
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
