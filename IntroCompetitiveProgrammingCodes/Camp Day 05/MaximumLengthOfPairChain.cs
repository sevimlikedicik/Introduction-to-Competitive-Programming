using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class MaximumLengthOfPairChain
    {

        public int FindLongestChain(int[][] pairs)
        {
            Tuple<int, int>[] sortedPairs = new Tuple<int, int>[pairs.Length];

            for (int i = 0; i < sortedPairs.Length; i++)
                sortedPairs[i] = new Tuple<int, int>(pairs[i][1], pairs[i][0]);

            Array.Sort(sortedPairs);
            int count = 0;
            int border = int.MinValue;

            for (int i = 0; i < sortedPairs.Length; i++)
            {
                if (sortedPairs[i].Item2 > border)
                {
                    count++;
                    border = sortedPairs[i].Item1;
                }
            }

            return count;
        }
    }
}
