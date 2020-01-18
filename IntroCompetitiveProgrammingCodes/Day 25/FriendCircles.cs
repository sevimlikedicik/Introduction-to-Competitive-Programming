using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class FriendCircles
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1,0,0,0,1,0,1,0,0,0 }, new int[] { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0 }, new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0 }
            , new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 } , new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0 } , new int[] { 0, 1, 1, 0, 0, 1, 1, 0, 0, 0 } , new int[] { 1, 0, 0, 0, 0, 1, 1, 0, 1, 0 }
            , new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 } , new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 1, 0 } , new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 } };

            Console.WriteLine(FindCircleNum(mtr));

            Console.ReadKey();
        }

        public static int FindCircleNum(int[][] M)
        {
            Dictionary<int, int> groupLeaderAffiliation = new Dictionary<int, int>();
            Dictionary<int, int> groups = new Dictionary<int, int>();

            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M[0].Length; j++)
                {
                    if (M[i][j] == 1)
                    {
                        bool iExists = groups.ContainsKey(i);
                        bool jExists = groups.ContainsKey(j);

                        if (iExists && jExists)
                            AffiliateLeader(groups[i], groups[j], groupLeaderAffiliation);
                        else if (iExists)
                            groups.Add(j, groups[i]);
                        else if (jExists)
                            groups.Add(i, groups[j]);
                        else
                        {
                            groups.Add(i, i);
                            if (i != j)
                                groups.Add(j, i);
                            groupLeaderAffiliation.Add(i, i);
                        }
                    }
                }
            }

            bool[] groupExists = new bool[200];
            int groupCount = 0;

            foreach (var kvp in groupLeaderAffiliation)
            {
                if (!groupExists[kvp.Value])
                {
                    groupExists[kvp.Value] = true;
                    groupCount++;
                }
            }

            return groupCount;
        }

        private static void AffiliateLeader(int i, int j, Dictionary<int, int> groupLeaderAffiliation)
        {
            int newLeader = groupLeaderAffiliation[j];
            int oldLeader = groupLeaderAffiliation[i];

            groupLeaderAffiliation[i] = newLeader;

            List<int> list = new List<int>();

            foreach(var kvp in groupLeaderAffiliation)
            {
                if (kvp.Value == oldLeader)
                    list.Add(kvp.Key);
            }

            foreach (int key in list)
                groupLeaderAffiliation[key] = newLeader;
        }
    }
}
