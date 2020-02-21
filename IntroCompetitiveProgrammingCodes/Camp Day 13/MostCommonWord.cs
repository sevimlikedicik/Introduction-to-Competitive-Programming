using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_13
{
    class MostCommonWord
    {
        static void Main(string[] args)
        {
            string paragraph = "a,b,c  ?c?c?a";
            string[] banned = new string[1] { "a" };

            Console.WriteLine(FindMostCommonWord(paragraph, banned));

            Console.ReadKey();
        }

        public static string FindMostCommonWord(string paragraph, string[] banned)
        {
            char[] puncs = new char[] { '!', '?', ';', '.', '\'', ' ', ',' };
            var tmpList = paragraph.Split(puncs);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            HashSet<string> bannedWords = new HashSet<string>();

            foreach (string bannedWord in banned)
                bannedWords.Add(bannedWord);

            int max = 0;

            foreach (string word in tmpList)
            {
                string lWord = word.ToLower();
                if (!bannedWords.Contains(lWord))
                {
                    if (dict.ContainsKey(lWord))
                        dict[lWord]++;
                    else
                        dict.Add(lWord, 1);
                }
            }

            string ret = "";

            foreach (var kvp in dict)
            {
                if (kvp.Value > max && string.Compare(kvp.Key, "") != 0)
                {
                    max = kvp.Value;
                    ret = kvp.Key;
                }
            }

            return ret;
        }
    }
}
