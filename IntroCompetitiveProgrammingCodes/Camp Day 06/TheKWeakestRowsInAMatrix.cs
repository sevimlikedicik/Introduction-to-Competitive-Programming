using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_06
{
    class TheKWeakestRowsInAMatrix
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 }, new int[] { 0, 1, 0 } };

            var x = (KWeakestRows(mtr, 2));

            Console.ReadKey();
        }

        public static int[] KWeakestRows(int[][] mat, int k)
        {
            SortedDictionary<int, List<int>> rows = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < mat.Length; i++)
            {
                int oneCount = 0;

                for (int j = 0; j < mat[0].Length; j++)
                    oneCount += mat[i][j];

                if (rows.ContainsKey(oneCount))
                    rows[oneCount].Add(i);
                else
                    rows.Add(oneCount, new List<int>() { i });
            }

            List<int> weakestRows = new List<int>();

            foreach (var kvp in rows)
            {
                foreach (int row in kvp.Value)
                {
                    if (k == 0)
                        break;

                    weakestRows.Add(row);
                }
            }

            return weakestRows.ToArray();
        }
    }
}
