using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_3
{
    class ShortestPathWithAlternatingColors
    {
        internal class PathInfo
        {
            public int City;
            public int TotalDistance;
            public bool LastEdgeWasRed;

            public PathInfo(int city, int distance, bool lastEdgeWasRed)
            {
                City = city;
                TotalDistance = distance;
                LastEdgeWasRed = lastEdgeWasRed;
            }
        }

        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } };
            int[][] mtr2 = new int[][] { new int[] { 1, 0 } };

            Console.WriteLine(ShortestAlternatingPaths(5, mtr, mtr2));

            Console.ReadKey();
        }

        public static int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
        {
            int[] shortestDistances = new int[n];

            var redEdges = CreateEdgeDictionary(red_edges);
            var blueEdges = CreateEdgeDictionary(blue_edges);

            for (int i = 0; i < shortestDistances.Length; i++)
                shortestDistances[i] = int.MaxValue;

            Queue<PathInfo> queue = new Queue<PathInfo>();
            queue.Enqueue(new PathInfo(0, 0, true));
            queue.Enqueue(new PathInfo(0, 0, false));
            shortestDistances[0] = 0;

            while (queue.Count != 0)
            {
                PathInfo city = queue.Dequeue();
                ProcessEdges(city, redEdges, blueEdges, queue, shortestDistances);
            }

            for (int i = 0; i < shortestDistances.Length; i++)
            {
                if (shortestDistances[i] == int.MaxValue)
                    shortestDistances[i] = -1;
            }

            return shortestDistances;
        }

        private static Dictionary<int, List<int>> CreateEdgeDictionary(int[][] edgeArray)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < edgeArray.Length; i++)
            {
                int key = edgeArray[i][0];
                int val = edgeArray[i][1];

                if (dict.ContainsKey(key))
                    dict[key].Add(val);
                else
                    dict.Add(key, new List<int>() { val });
            }

            return dict;
        }

        private static void ProcessEdges(PathInfo city, Dictionary<int, List<int>> redEdges, Dictionary<int, List<int>> blueEdges, Queue<PathInfo> queue, int[] shortestDistances)
        {
            var edges = city.LastEdgeWasRed ? blueEdges : redEdges;

            if (edges.ContainsKey(city.City))
            {
                foreach (var edge in edges[city.City])
                {
                    int destCity = edge;
                    int distance = city.TotalDistance + 1;
                    queue.Enqueue(new PathInfo(destCity, distance, !city.LastEdgeWasRed));

                    if (distance < shortestDistances[destCity])
                        shortestDistances[destCity] = distance;
                }

                edges[city.City].Clear();
            }
        }
    }
}
