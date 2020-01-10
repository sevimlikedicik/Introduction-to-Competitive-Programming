using System;

namespace IntroCompetitiveProgrammingCodes.Day_23
{
    class FadiAndLCM
    {
        static void Main(string[] args)
        {
            long n = ReadLong();

            long a = (long)Math.Sqrt(n);

            for (long i = a; i >= 1; i--)
            {
                if (n % i == 0 && Gcd((n / i), i) == 1)
                {
                    Console.WriteLine($"{i} {n / i}");
                    break;
                }
            }
        }

        private static long Gcd(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
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
