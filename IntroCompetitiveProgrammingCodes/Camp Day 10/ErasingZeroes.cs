using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_10
{
    class ErasingZeroes
    {
        static void Main(string[] args)
        {
            int n = ReadInt();

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                int firstOne, lastOne;
                int index = 0;

                while (index < s.Length && s[index] == '0')
                    index++;

                firstOne = index;

                index = s.Length - 1;

                while (index >= 0 && s[index] == '0')
                    index--;

                lastOne = index;

                int count = 0;
                for (int j = firstOne; j < lastOne; j++)
                {
                    if (s[j] == '0')
                        count++;
                }

                Console.WriteLine(count);
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
