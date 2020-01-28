using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    public class DirectedGraph
    {
        public int NodeCount = 0;
        public int EdgeCount = 0;
        public List<int> Values = new List<int>();
        public List<int>[] AdjacentNodes;

        public DirectedGraph(int n)
        {
            AdjacentNodes = new List<int>[n];
            NodeCount = n;

            for (int i = 0; i < n; i++)
                AdjacentNodes[i] = new List<int>();
        }

        public void AddEdge(int a, int b)
        {
            if (!Values.Contains(a))
                Values.Add(a);

            if (!Values.Contains(b))
                Values.Add(b);

            AdjacentNodes[a].Add(b);
            EdgeCount++;
        }

        private bool IsCyclicUtil(int i, bool[] visited, bool[] recStack)
        {
            // Mark the current node as visited and 
            // part of recursion stack 
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = AdjacentNodes[i];

            foreach (int c in children)
                if (IsCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

        public bool IsCyclic()
        {

            // Mark all the vertices as not visited and 
            // not part of recursion stack 
            bool[] visited = new bool[NodeCount];
            bool[] recStack = new bool[NodeCount];


            // Call the recursive helper function to 
            // detect cycle in different DFS trees 
            for (int i = 0; i < NodeCount; i++)
                if (IsCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }
    }

    class CourseSchedule_II
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 0 }, new int[] { 0, 3 }, new int[] { 0, 2 }, new int[] { 3, 2 }, new int[] { 2, 5 }, new int[] { 4, 5 }, new int[] { 5, 6 }, new int[] { 2, 4 } };

            var arr = (FindOrder(7, mtr));

            Console.ReadKey();
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] level = new int[numCourses];
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            DirectedGraph graph = new DirectedGraph(numCourses);

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int post = prerequisites[i][0];
                int pre = prerequisites[i][1];

                graph.AddEdge(pre, post);

                level[post]++;

                if (dict.ContainsKey(pre))
                    dict[pre].Add(post);
                else
                    dict[pre] = new List<int>() { post };
            }

            if (graph.IsCyclic())
                return new int[] { };

            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();
            bool[] contains = new bool[numCourses];

            for (int i = 0; i < level.Length; i++)
            {
                if (level[i] == 0)
                {
                    queue.Enqueue(i);
                    list.Add(i);
                    contains[i] = true;
                }
            }

            while (queue.Count != 0)
            {
                int lesson = queue.Dequeue();

                if (dict.ContainsKey(lesson))
                {
                    foreach (int post in dict[lesson])
                    {
                        if (!queue.Contains(post))
                            queue.Enqueue(post);

                        int preIndex = list.FindIndex(num => num == lesson);

                        if (contains[post])
                        {
                            int postIndex = list.FindIndex(num => num == post);

                            if (postIndex < preIndex)
                                list.Insert(preIndex + 1, post);
                        }
                        else
                        {
                            list.Insert(preIndex + 1, post);
                            contains[post] = true;
                        }
                    }
                }
            }

            return list.ToArray();
        }
    }
}
