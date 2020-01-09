using System;

namespace IntroCompetitiveProgrammingCodes.Day_18
{
    class AandB
    {
        static void Main(string[] args)
        {
            int n = ReadInt();

            for (int i = 0; i < n; i++)
            {
                var phrase = ReadLineAsArray();

                int a = ConvertInt(phrase[0]);
                int b = ConvertInt(phrase[1]);

                int dif = Math.Abs(a - b);

                Console.WriteLine(Solve(dif));
            }
        }

        private static int Solve(int dif)
        {
            int res = (int)Math.Sqrt(dif);
            long total = ((res + 1) * res) / 2;

            while (total < dif || total % 2 != dif % 2)
            {
                res++;
                total = ((res + 1) * res) / 2;
            }

            return res;
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
