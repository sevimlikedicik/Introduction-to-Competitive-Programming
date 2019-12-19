using System;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class ValidAnagram
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            Console.WriteLine(IsAnagram(s, t));

            Console.ReadKey();
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] sChars = new int[26];
            int[] tChars = new int[26];

            foreach(char c in s)
                sChars[c - 'a']++;

            foreach (char c in t)
                tChars[c - 'a']++;

            for (int i=0; i<sChars.Length; i++)
            {
                if(sChars[i] != tChars[i])
                    return false;
            }

            return true;
        }
    }
}
