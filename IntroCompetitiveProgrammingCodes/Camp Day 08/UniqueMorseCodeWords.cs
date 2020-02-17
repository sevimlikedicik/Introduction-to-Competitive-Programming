using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_08
{
    class UniqueMorseCodeWords
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "abc", "dbc", "cda" };

            Console.WriteLine(UniqueMorseRepresentations(arr));

            Console.ReadKey();
        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            string[] morsWords = new string[words.Length];
            string[] mors = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            HashSet<string> hs = new HashSet<string>();

            for (int i = 0; i < words.Length; i++)
            {
                foreach (char c in words[i])
                    morsWords[i] += mors[(int)(c - 'a')];

                hs.Add(morsWords[i]);
            }

            return hs.Count;
        }
    }
}
