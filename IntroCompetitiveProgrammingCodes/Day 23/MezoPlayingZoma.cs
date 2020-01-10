using System;

namespace IntroCompetitiveProgrammingCodes.Day_23
{
    class MezoPlayingZoma
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = ReadInt();
                string s = ReadLine();

                Console.WriteLine(n + 1);
            }

            private static string ReadLine() => Console.ReadLine();

            private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

            private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

            private static int ConvertInt(string s) => Convert.ToInt32(s);

            private static long ConvertLong(string s) => Convert.ToInt64(s);

            private static char ConvertChar(string s) => Convert.ToChar(s);
        }
    }
}
