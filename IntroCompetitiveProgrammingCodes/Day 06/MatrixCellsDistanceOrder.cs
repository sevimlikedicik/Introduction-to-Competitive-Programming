using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class MatrixCellsDistanceOrder
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int R = Convert.ToInt32(phrase[0]);
            int C = Convert.ToInt32(phrase[1]);
            int r0 = Convert.ToInt32(phrase[2]);
            int c0 = Convert.ToInt32(phrase[3]);

            var allDistances = AllCellsDistOrder(R, C, r0, c0);

            foreach (var nums in allDistances)
            {
                foreach (int num in nums)
                    Console.Write($"{num} ");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            Dictionary<List<int>, int> allDistancesDict = new Dictionary<List<int>, int>();

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    allDistancesDict[new List<int>() { i, j }] = Math.Abs(i - r0) + Math.Abs(j - c0);
                }
            }

            var sortedDict = from entry in allDistancesDict orderby entry.Value ascending select entry;

            int[][] allDistances = new int[allDistancesDict.Count][];

            int iterator = 0;

            foreach(var distance in sortedDict)
            {
                allDistances[iterator] = new int[2];
                allDistances[iterator][0] = distance.Key[0];
                allDistances[iterator++][1] = distance.Key[1];
            }

            return allDistances;
        }
    }
}
