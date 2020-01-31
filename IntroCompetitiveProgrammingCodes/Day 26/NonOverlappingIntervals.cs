using System;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class NonOverlappingIntervals
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 2 }, new int[] { 1, 2 }, new int[] { 1, 2 } };

            Console.WriteLine(EraseOverlapIntervals(mtr));

            Console.ReadKey();
        }

        public static int EraseOverlapIntervals(int[][] intervals)
        {
            var sorted = Sort(intervals);

            int count = 0;
            int rightBorder = int.MinValue; 

            for(int i=0; i<sorted.Length; i++)
            {
                if (sorted[i].Item2 >= rightBorder)
                {
                    count++;
                    rightBorder = sorted[i].Item1;
                }
            }

            return intervals.Length - count;
        }

        private static Tuple<int, int>[] Sort(int[][] intervals)
        {
            Tuple<int, int>[] sorted = new Tuple<int, int>[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
                sorted[i] = new Tuple<int, int>(intervals[i][1], intervals[i][0]);

            Array.Sort(sorted);

            return sorted;
        }
    }
}
