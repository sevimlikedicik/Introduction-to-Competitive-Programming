using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class VideoStitching
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(VideoStitch(mtr, 10));

            Console.ReadKey();
        }

        public static int VideoStitch(int[][] clips, int T)
        {
            Tuple<int, int>[] tuples = new Tuple<int, int>[clips.Length];

            for (int i = 0; i < clips.Length; i++)
                tuples[i] = new Tuple<int, int>(clips[i][0], clips[i][1]);

            Array.Sort(tuples);

            bool isPossible = true;
            int startingPoint = 0;
            int count = 0;
            int index = 0;
            int prevIndex = -1;

            while (index < tuples.Length && startingPoint < T)
            {
                int max = int.MinValue;

                while (index < tuples.Length && tuples[index].Item1 <= startingPoint)
                {
                    if (tuples[index].Item2 > max)
                        max = tuples[index].Item2;

                    index++;
                }

                count++;
                startingPoint = max;

                if (max == int.MinValue)
                    isPossible = false;

                if (index == prevIndex)
                    break;

                prevIndex = index;
            }

            if (startingPoint < T)
                isPossible = false;

            return !isPossible ? -1 : count;
        }
    }
}
