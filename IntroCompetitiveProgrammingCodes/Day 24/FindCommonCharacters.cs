using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class FindCommonCharacters
    {
        static void Main(string[] args)
        {
            string[] A = new string[] { "cool", "lock", "cook" };

            var x = CommonChars(A);

            foreach (string s in x)
                Console.WriteLine(s);

            Console.ReadKey();
        }

        public static IList<string> CommonChars(string[] A)
        {
            if (A.Length == 0)
                return null;

            int[] common = new int[26];
            int[] current = new int[26];

            for (int i = 0; i < 26; i++)
                common[i] = int.MaxValue;

            foreach (string s in A)
            {
                for (int i = 0; i < 26; i++)
                    current[i] = 0;

                foreach (char c in s)
                    current[c - 'a']++;

                for (int i = 0; i < 26; i++)
                    common[i] = Math.Min(common[i], current[i]);
            }

            List<string> commonChars = new List<string>();

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < common[i]; j++)
                    commonChars.Add(new string("" + (char)('a' + i)));
            }

            return commonChars;
        }
    }
}
