using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class TwoCityScheduling
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 259, 770 }, new int[] { 448, 54 }, new int[] { 926, 667 }, new int[] { 184, 139 }, new int[] { 840, 118 }, new int[] { 577, 469 } };

            Console.WriteLine(TwoCitySchedCost(mtr));

            Console.ReadKey();
        }

        public static int TwoCitySchedCost(int[][] costs)
        {
            SortedDictionary<int, List<Tuple<int, bool>>> distanceIndex = new SortedDictionary<int, List<Tuple<int, bool>>>();
            int[] distances = new int[costs.Length];
            int total = 0;
            int aCount = 0;
            int bCount = 0;

            for (int i = 0; i < costs.Length; i++)
            {
                if (distanceIndex.ContainsKey(Math.Abs(costs[i][0] - costs[i][1])))
                    distanceIndex[Math.Abs(costs[i][0] - costs[i][1])].Add(new Tuple<int, bool>(i, costs[i][0] > costs[i][1]));
                else
                    distanceIndex.Add(Math.Abs(costs[i][0] - costs[i][1]), new List<Tuple<int, bool>>() { new Tuple<int, bool>(i, costs[i][0] > costs[i][1]) });
            }

            foreach (var kvp in distanceIndex.Reverse())
            {
                foreach (var tuple in kvp.Value)
                {
                    if (aCount == costs.Length / 2 || bCount == costs.Length / 2)
                    {
                        if (aCount == costs.Length / 2)
                            total += costs[tuple.Item1][1];
                        else
                            total += costs[tuple.Item1][0];
                    }
                    else
                    {
                        if (tuple.Item2)
                        {
                            total += costs[tuple.Item1][1];
                            bCount++;
                        }
                        else
                        {
                            total += costs[tuple.Item1][0];
                            aCount++;
                        }
                    }
                }
            }

            return total;
        }
    }
}
