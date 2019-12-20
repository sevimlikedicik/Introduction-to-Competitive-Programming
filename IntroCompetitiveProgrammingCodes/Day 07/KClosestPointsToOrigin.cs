using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_07
{
    class KClosestPointsToOrigin
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[][] points = new int[10000][];

            for (int i = 0; i < 10000; i++)
                points[i] = new int[2] { i, i };

            var closestPoints = KClosest(points, 2000);

            foreach (var point in closestPoints)
                Console.WriteLine($"{point[0]} {point[1]}");

            Console.ReadKey();
        }

        public static int[][] KClosest(int[][] points, int K)
        {
            Dictionary<int[], double> distances = new Dictionary<int[], double>();

            for (int i = 0; i < points.Length; i++)
            {
                double distance = Math.Sqrt(Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2));
                distances.Add(new int[2] { points[i][0], points[i][1] }, distance);
            }

            var sortedDict = from entry in distances orderby entry.Value ascending select entry;

            int[][] closestPoints = new int[K][];
            int counter = 0;

            foreach(var kvp in sortedDict)
            {
                if (counter == K)
                    break;

                closestPoints[counter] = new int[2];
                closestPoints[counter++] = kvp.Key;
            }

            return closestPoints;
        }

    }
}
