using System;
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
            int[] chars = new int[26];

            foreach (char c in S)
                chars[c - 'a']++;

            int maxAppearingLetter = chars.Max();

            if (maxAppearingLetter > chars.Length / 2)
                return "";

            return null;
        }
    }
}
