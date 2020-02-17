using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_12
{
    class MaximumNumberOfEventsThatCanBeAttended
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[100000][];

            for (int i = 0; i < mtr.Length; i++)
                mtr[i] = new int[] { 1, i };

            Console.WriteLine(MaxEvents(mtr));

            Console.ReadKey();
        }

        public static int MaxEvents(int[][] events)
        {
            Tuple<int, int>[] tuples = new Tuple<int, int>[events.Length];

            for (int i = 0; i < events.Length; i++)
                tuples[i] = new Tuple<int, int>(events[i][1], events[i][0]);

            Array.Sort(tuples);

            bool[] invaded = new bool[100001];
            int count = 0;
            int lastPoint = 0;
            int prevStart = 0;

            for (int i = 0; i < events.Length; i++)
            {
                int start = tuples[i].Item2;
                int end = tuples[i].Item1;

                if (prevStart == start)
                {
                    if (start > lastPoint)
                        lastPoint = start;

                    while (lastPoint <= end && invaded[lastPoint])
                        lastPoint++;

                    if (lastPoint <= end)
                    {
                        invaded[lastPoint++] = true;
                        count++;
                    }
                }
                else
                {
                    while (start <= end && invaded[start])
                        start++;

                    if (start <= end)
                    {
                        count++;
                        invaded[start] = true;
                        lastPoint = start;
                    }
                }

                prevStart = start;
            }

            return count;
        }
    }
}
