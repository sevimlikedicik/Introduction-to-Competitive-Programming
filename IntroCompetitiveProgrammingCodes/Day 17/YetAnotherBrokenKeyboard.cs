using System;

namespace IntroCompetitiveProgrammingCodes.Day_17
{
    class YetAnotherBrokenKeyboard
    {
        static void Main(string[] args)
        {
            string[] phrase = ReadLineAsArray();

            int n = ConvertInt(phrase[0]);
            int k = ConvertInt(phrase[1]);

            string s = ReadLine();
            var charArray = s.ToCharArray();

            bool[] availableLetters = new bool[26];
            phrase = ReadLineAsArray();

            for (int i = 0; i < phrase.Length; i++)
                availableLetters[ConvertChar(phrase[i]) - 'a'] = true;

            long total = 0;
            int startingIndex = 0;
            long substringLen = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (!availableLetters[charArray[i] - 'a'])
                {
                    substringLen = i - startingIndex;
                    total += (substringLen * (substringLen + 1)) / 2;
                    startingIndex = i + 1;
                }
            }

            substringLen = charArray.Length - startingIndex;
            total += (substringLen * (substringLen + 1)) / 2;

            Console.WriteLine(total);
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
