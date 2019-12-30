using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_13
{
    class BeautifulString
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] results = new string[n];

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();

                if (CanBeBeautiful(s))
                {
                    char[] arr = s.ToCharArray();

                    for (int j = 0; j < arr.Length; j++)
                    {
                        char prev = (j == 0) ? '?' : arr[j - 1];
                        char curr = s[j];
                        char next = (j == s.Length - 1) ? '?' : arr[j + 1];

                        if (arr[j] == '?')
                            arr[j] = AvailableCharacter(prev, curr, next);
                    }

                    results[i] = new string(arr);
                }
                else
                    results[i] = "-1";
            }

            foreach (var result in results)
                Console.WriteLine(result);
        }

        private static bool CanBeBeautiful(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1] && s[i] != '?')
                    return false;
            }

            return true;
        }

        private static char AvailableCharacter(char prev, char curr, char next)
        {
            List<char> availableCharacters = new List<char>() { 'a', 'b', 'c' };

            if (availableCharacters.Contains(prev))
                availableCharacters.Remove(prev);
            if (availableCharacters.Contains(next))
                availableCharacters.Remove(next);

            return availableCharacters[0];
        }
    }
}
