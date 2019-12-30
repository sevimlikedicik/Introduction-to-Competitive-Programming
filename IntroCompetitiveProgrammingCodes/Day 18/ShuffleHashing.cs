using System;

namespace IntroCompetitiveProgrammingCodes.Day_18
{
    class ShuffleHashing
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            bool[] results = new bool[n];

            for (int i = 0; i < n; i++)
            {
                string p = Console.ReadLine();
                string h = Console.ReadLine();

                if (HashPossible(p, h))
                    results[i] = true;
                else
                    results[i] = false;
            }

            foreach (bool b in results)
            {
                if (b)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }

        private static bool HashPossible(string p, string h)
        {
            if (h.Length < p.Length)
                return false;

            int[] pChars = new int[26];

            foreach (char c in p)
                pChars[c - 'a']++;

            for (int i = 0; i <= h.Length - p.Length; i++)
            {
                int[] hChars = new int[26];

                for (int j = i; j < i + p.Length; j++)
                {
                    char c = h[j];
                    hChars[c - 'a']++;
                }


                bool anagram = true;

                for (int j = 0; j < 26; j++)
                {
                    if (hChars[j] != pChars[j])
                        anagram = false;
                }

                if (anagram)
                    return true;
            }

            return false;
        }
    }
}
