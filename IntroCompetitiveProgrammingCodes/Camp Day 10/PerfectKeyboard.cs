using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_10
{
    class PerfectKeyboard
    {
        static void Main(string[] args)
        {
            int n = ReadInt();

            for (int i = 0; i < n; i++)
            {
                var phrase = ReadLine();

                if (phrase.Length == 1)
                {
                    Console.WriteLine("YES");
                    Console.WriteLine("abcdefghijklmnopqrstuvwxyz");
                    continue;
                }

                Dictionary<char, HashSet<char>> dict = new Dictionary<char, HashSet<char>>();

                for (int j = 0; j < 26; j++)
                    dict.Add((char)('a' + j), new HashSet<char>());

                for (int j = 0; j < phrase.Length - 1; j++)
                {
                    dict[phrase[j]].Add(phrase[j + 1]);
                    dict[phrase[j + 1]].Add(phrase[j]);
                }

                bool[] used = new bool[26];
                List<char> beginValues = new List<char>();
                List<char> twoValues = new List<char>();
                List<char> freeValues = new List<char>();
                bool imp = false;

                foreach (var kvp in dict)
                {
                    if (kvp.Value.Count == 0)
                        freeValues.Add(kvp.Key);
                    if (kvp.Value.Count == 1)
                        beginValues.Add(kvp.Key);
                    if (kvp.Value.Count == 2)
                        twoValues.Add(kvp.Key);
                    if (kvp.Value.Count > 2)
                        imp = true;
                }

                if (beginValues.Count % 2 == 1)
                    imp = true;

                if (beginValues.Count == 0 && twoValues.Count > 0)
                    imp = true;

                if (beginValues.Count / 2 > freeValues.Count + 1)
                    imp = true;

                string s = "";
                int freeIndex = 0;

                foreach (char begin in beginValues)
                {
                    if (!used[begin - 'a'])
                        Magic(used, begin, dict, ref s, ref imp);
                    if (s.Length < 26)
                        s += freeValues[freeIndex++];
                }

                while (!imp && s.Length < 26)
                    s += freeValues[freeIndex++];

                if (imp)
                    Console.WriteLine("NO");
                else
                {
                    Console.WriteLine("YES");
                    Console.WriteLine(s);
                }
            }
        }

        private static void Magic(bool[] used, char begin, Dictionary<char, HashSet<char>> dict, ref string s, ref bool imp)
        {
            s += begin;
            int index = s.Length - 2;
            used[begin - 'a'] = true;

            foreach (char c in dict[begin])
            {
                if (used[c - 'a'])
                {
                    if (c == begin)
                        continue;
                    else if (s[index] != c)
                        imp = true;
                }
                else
                    Magic(used, c, dict, ref s, ref imp);
            }
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static long ReadLong() => Convert.ToInt64(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
