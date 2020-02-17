using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_10
{
    class NationalProject
    {
        static void Main(string[] args)
        {
            int n = ReadInt();

            for (int i = 0; i < n; i++)
            {
                var phrase = ReadLineAsArray();
                long[] vars = new long[3];

                for (int j = 0; j < 3; j++)
                    vars[j] = ConvertInt(phrase[j]);

                long road = vars[0];
                long good = vars[1];
                long bad = vars[2];

                long requiredGoodRoad = (road + 1) / 2;
                long requiredDay = ((requiredGoodRoad - 1) / good) * (good + bad) + (requiredGoodRoad % good);
                if (requiredGoodRoad % good == 0)
                    requiredDay += good;

                long count = requiredDay < road ? road : requiredDay;

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
