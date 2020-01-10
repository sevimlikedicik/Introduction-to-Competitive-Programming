using System;

namespace IntroCompetitiveProgrammingCodes.Day_23
{
    class JustEatIt
    {
        static void Main(string[] args)
        {
            int t = ReadInt();

            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                var phrase = ReadLineAsArray();
                bool yasserHappy = true;

                long lTotal = ConvertInt(phrase[0]);
                long rTotal = ConvertInt(phrase[n - 1]);
                int index = 1;

                while (index < n && lTotal > 0)
                    lTotal += ConvertInt(phrase[index++]);

                if (lTotal <= 0)
                    yasserHappy = false;

                index = n - 2;

                while (index >= 0 && rTotal > 0)
                    rTotal += ConvertInt(phrase[index--]);

                if (rTotal <= 0)
                    yasserHappy = false;

                if (yasserHappy)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
