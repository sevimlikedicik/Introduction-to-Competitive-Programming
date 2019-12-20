using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    public class TopVotedCandidate
    {
        int[] times;
        int[] totalVotes;
        int[] winners;

        public TopVotedCandidate(int[] persons, int[] times)
        {
            this.times = new int[times.Length];
            this.times = times;
            totalVotes = new int[persons.Length];
            winners = new int[persons.Length];
            int lastRoundMostVote = 0;
            int lastRoundWinner = -1;

            for (int i = 0; i < persons.Length; i++)
            {
                totalVotes[persons[i]]++;

                if (totalVotes[persons[i]] == lastRoundMostVote)
                {
                    winners[i] = persons[i];
                    lastRoundWinner = persons[i];
                }

                if (totalVotes[persons[i]] > lastRoundMostVote)
                {
                    winners[i] = persons[i];
                    lastRoundMostVote = totalVotes[persons[i]];
                    lastRoundWinner = persons[i];
                }

                if (totalVotes[persons[i]] < lastRoundMostVote)
                    winners[i] = lastRoundWinner;
            }
        }

        public int Q(int t)
        {
            return winners[BinarySearch(t)];
        }

        public int BinarySearch(int time)
        {
            int l = 0;
            int r = times.Length - 1;
            int m = -1;
            int bestValue = -1;
            int bestIndex = -1;

            while (l <= r)
            {
                m = (l + r) / 2;

                if (time >= times[m])
                {
                    if (time - times[m] < time - bestValue)
                    {
                        bestValue = times[m];
                        bestIndex = m;
                    }

                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return bestIndex;
        }
    }
}
