using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class WordBreak
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "leet", "code" };

            Console.WriteLine(Solve("leetcode", list));

            Console.ReadKey();
        }

        public static bool Solve(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            bool[] dp = new bool[s.Length];

            foreach (string str in wordDict) {
                hs.Add(str);
            }

            for (int i = 0; i < s.Length; i++) {
                if (hs.Contains(s.Substring(0, i + 1))) {
                    dp[i] = true;
                    continue;
                }

                for (int j = 0; j < i; j++) {
                    if (dp[j] && hs.Contains(s.Substring(j + 1, i - j))) {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length - 1];
        }
    }
}
