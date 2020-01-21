using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class IsGraphBipartite
    {
        internal class ListIndex
        {
            public int I = -1;
            public int J;

            public ListIndex()
            {
            }

            public ListIndex(int i, int j)
            {
                I = i;
                J = j;
            }
        }

        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 2, 3 }, new int[] { 0, 2 }, new int[] { 0, 1, 3 }, new int[] { 0, 2 } };

            Console.WriteLine(IsBipartite(mtr));

            Console.ReadKey();
        }

        public static bool IsBipartite(int[][] graph)
        {
            List<int>[][] lists = new List<int>[50][];

            for (int i = 0; i < lists.Length; i++)
                lists[i] = new List<int>[2] { new List<int>(), new List<int>() };

            int availableIndex = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    int adjNode = graph[i][j];

                    if (adjNode > i)
                    {
                        ListIndex iIndex = Find(lists, i);
                        ListIndex adjNodeIndex = Find(lists, adjNode);

                        if (iIndex.I == -1 && adjNodeIndex.I == -1)
                        {
                            lists[availableIndex][0] = new List<int>() { i };
                            lists[availableIndex++][1] = new List<int>() { adjNode };
                        }
                        else if (adjNodeIndex.I == -1)
                        {
                            if (iIndex.J == 1)
                                lists[iIndex.I][0].Add(adjNode);
                            else
                                lists[iIndex.I][1].Add(adjNode);
                        }
                        else if (iIndex.I == -1)
                        {
                            if (adjNodeIndex.J == 1)
                                lists[adjNodeIndex.I][0].Add(i);
                            else
                                lists[adjNodeIndex.I][1].Add(i);
                        }
                        else
                        {
                            if (iIndex.I == adjNodeIndex.I && iIndex.J == adjNodeIndex.J)
                                return false;
                            else if (iIndex.I != adjNodeIndex.I)
                                Merge(lists, iIndex, adjNodeIndex);
                        }
                    }
                }
            }

            return true;
        }

        private static void Merge(List<int>[][] lists, ListIndex iIndex, ListIndex adjNodeIndex)
        {
            if (iIndex.J == 1)
            {
                foreach (int num in lists[adjNodeIndex.I][adjNodeIndex.J])
                    lists[iIndex.I][0].Add(num);
            }
            else
            {
                foreach (int num in lists[adjNodeIndex.I][adjNodeIndex.J])
                    lists[iIndex.I][1].Add(num);
            }

            lists[adjNodeIndex.I][adjNodeIndex.J].Clear();
        }

        private static ListIndex Find(List<int>[][] lists, int num)
        {
            for (int i = 0; i < lists.Length; i++)
            {
                for (int j = 0; j < lists[i].Length; j++)
                {
                    if (lists[i][j].Contains(num))
                        return new ListIndex(i, j);
                }
            }

            return new ListIndex();
        }
    }
}
