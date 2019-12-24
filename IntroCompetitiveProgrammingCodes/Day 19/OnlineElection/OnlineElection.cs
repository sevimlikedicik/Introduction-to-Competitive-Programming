using System;

namespace IntroCompetitiveProgrammingCodes.Day_19.OnlineElection
{
    class OnlineElection
    {
        static void Main(string[] args)
        {
            int[] persons = { 0, 1, 1, 0, 0, 1, 0 };
            int[] times = { 0, 5, 10, 15, 20, 25, 30 };

            TopVotedCandidate tvc = new TopVotedCandidate(persons, times);

            int winner = tvc.Q(25);

            Console.ReadKey();
        }
    }
}
