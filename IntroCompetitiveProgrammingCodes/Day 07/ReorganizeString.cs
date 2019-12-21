using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_07
{
    class ReorganizeString
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();

            Console.WriteLine(Reorganize(phrase));

            Console.ReadKey();
        }

        public static string Reorganize(string S)
        {
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();

            foreach (char c in S)
            {
                if (letterCounts.ContainsKey(c))
                    letterCounts[c]++;
                else
                    letterCounts.Add(c, 1);
            }

            var sortedDict = from entry in letterCounts orderby entry.Value descending select entry;

            var maxLetterCount = sortedDict.ElementAt(0).Value;

            if (maxLetterCount > (S.Length + 1) / 2)
                return "";

            char[] organizedString = new char[S.Length];
            int walk_string = 0;

            foreach (var kvp in sortedDict)
            {
                char c = kvp.Key;

                for (int i = 0; i < kvp.Value; i++)
                {
                    if (walk_string >= S.Length)
                        walk_string = 1;

                    organizedString[walk_string] = c;
                    walk_string += 2;
                }
            }

            return new string(organizedString);
        }
    }
}
