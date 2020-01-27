using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class GetWatchedVideosByYourFriends
    {
        static void Main(string[] args)
        {
            List<IList<string>> watchedVideos = new List<IList<string>>() { new List<string>() { "A", "A", "A", "A", "A", "B" }, new List<string>() { "C", "B" }, new List<string>() { "C", "B", "N" } };
            int[][] friends = new int[][] { new int[] { 1 }, new int[] { 0, 2 }, new int[] { 1 } };

            var list = (WatchedVideosByFriends(watchedVideos, friends, 0, 2));

            Console.ReadKey();
        }

        public static IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            List<int> previousLevelFriends = new List<int>() { id };
            List<int> currentLevelFriends = new List<int>();
            bool [] visited = new bool[friends.Length];
            visited[id] = true;

            for (int i = 0; i < level; i++)
            {
                currentLevelFriends = new List<int>();

                foreach (int friendId in previousLevelFriends)
                {
                    for (int j = 0; j < friends[friendId].Length; j++)
                    {
                        if (!visited[friends[friendId][j]])
                        {
                            visited[friends[friendId][j]] = true;
                            currentLevelFriends.Add(friends[friendId][j]);
                        }
                    }
                }

                previousLevelFriends = currentLevelFriends;
            }

            SortedDictionary<string, int> videosWatchedByFriendsSorted = new SortedDictionary<string, int>();

            foreach (int friendId in currentLevelFriends)
            {
                foreach (string video in watchedVideos[friendId])
                {
                    if (videosWatchedByFriendsSorted.ContainsKey(video))
                        videosWatchedByFriendsSorted[video]++;
                    else
                        videosWatchedByFriendsSorted.Add(video, 1);
                }
            }

            var sortedDict = from entry in videosWatchedByFriendsSorted orderby entry.Value ascending select entry;

            List<string> output = new List<string>();

            foreach (var kvp in sortedDict)
                output.Add(kvp.Key);

            return output;
        }
    }
}
