using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_13
{
    class BeautifulRegionalContest
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                Dictionary<int, int> indexes = new Dictionary<int, int>();

                int n = Convert.ToInt32(Console.ReadLine());
                string[] phrase = Console.ReadLine().Split(' ');

                int[] solvedProblems = new int[n];
                for (int j = 0; j < n; j++)
                    solvedProblems[j] = Convert.ToInt32(phrase[j]);

                AwardMedals(solvedProblems);
            }
        }

        private static void AwardMedals(int[] solvedProblems)
        {
            bool possible = true;
            StringBuilder result = new StringBuilder();

            int index = 1;

            while (index < solvedProblems.Length / 2 && solvedProblems[index] == solvedProblems[index - 1])
                index++;

            int gold = index++;
            result.Append(gold);

            int silver = 0;

            while (silver <= gold)
            {
                while (index < solvedProblems.Length / 2 && solvedProblems[index] == solvedProblems[index - 1])
                    index++;

                silver = index++ - gold;
            }

            result.Append(" " + silver);

            int bronzeIndex = solvedProblems.Length / 2 - 1;

            while (bronzeIndex >= 0 && solvedProblems[bronzeIndex] == solvedProblems[bronzeIndex + 1])
                bronzeIndex--;

            int bronze = bronzeIndex - index + 2;

            result.Append(" " + bronze);

            if (silver <= gold)
                possible = false;

            if (bronze <= 1 || bronze <= gold)
                possible = false;

            if (gold + silver + bronze > solvedProblems.Length / 2)
                possible = false;

            if (!possible)
                Console.WriteLine("0 0 0");
            else
                Console.WriteLine(result);
        }
    }
}
