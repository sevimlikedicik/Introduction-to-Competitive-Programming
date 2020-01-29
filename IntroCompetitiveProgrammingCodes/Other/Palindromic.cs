using System;

namespace IntroCompetitiveProgrammingCodes.Other
{
    class Palindromic
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSubstrings("aaa"));

            Console.ReadKey();
        }

        static int countPalindroms = 0;

        public static int CountSubstrings(string s)
        {
            var chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                CountPalindroms(chars, i, i);
                CountPalindroms(chars, i, i + 1);
            }

            return countPalindroms;
        }

        private static void CountPalindroms(char[] chars, int left, int right)
        {
            while (left >= 0 && right < chars.Length)
            {
                if (chars[left--] != chars[right++]) break;
                countPalindroms++;
            }
        }
    }
}
