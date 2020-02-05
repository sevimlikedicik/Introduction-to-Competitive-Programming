using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_2
{
    class MostStonesRemovedWithSameRowOrColumn
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 3, 2 }, new int[] { 3, 1 }, new int[] { 4, 4 }, new int[] { 1, 1 }, new int[] { 0, 2 }, new int[] { 4, 0 } };

            Console.WriteLine(RemoveStones(mtr));

            Console.ReadKey();
        }

        public static int RemoveStones(int[][] stones)
        {
            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> dict = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();
            Tuple<int, int>[] coords = new Tuple<int, int>[stones.Length];
            Dictionary<Tuple<int, int>, bool> visited = new Dictionary<Tuple<int, int>, bool>();

            for (int i = 0; i < stones.Length; i++)
            {
                coords[i] = new Tuple<int, int>(stones[i][0], stones[i][1]);
                visited.Add(coords[i], false);
            }

            for (int i = 0; i < stones.Length; i++)
            {
                for (int j = i + 1; j < stones.Length; j++)
                {
                    if (coords[i].Item1 == coords[j].Item1 || coords[i].Item2 == coords[j].Item2)
                    {
                        AddItem(dict, coords[i], coords[j]);
                        AddItem(dict, coords[j], coords[i]);
                    }
                }
            }

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            Tuple<int, int> start = coords[0];
            int totalCount = 0;

            for (int i = 0; i < coords.Length; i++)
            {
                if (visited[coords[i]])
                    continue;

                queue.Enqueue(coords[i]);
                visited[coords[i]] = true;
                int count = -1;

                while (queue.Count != 0)
                {
                    Tuple<int, int> cd = queue.Dequeue();
                    count++;

                    if (dict.ContainsKey(cd))
                    {
                        foreach (var adj in dict[cd])
                        {
                            if (!visited[adj])
                            {
                                queue.Enqueue(adj);
                                visited[adj] = true;
                            }
                        }
                    }
                }

                totalCount += count;
            }

            return totalCount;
        }

        private static void AddItem(Dictionary<Tuple<int, int>, List<Tuple<int, int>>> coords, Tuple<int, int> key, Tuple<int, int> value)
        {
            if (coords.ContainsKey(key))
            {
                coords[key].Add(value);
                return;
            }

            coords.Add(key, new List<Tuple<int, int>>() { value });
        }
    }
}
