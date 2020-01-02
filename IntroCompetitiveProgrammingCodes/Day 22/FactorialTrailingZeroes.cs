using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class FactorialTrailingZeroes
    {
        static void Main(string[] args)
        {
            int n = 125;

            Console.WriteLine(TrailingZeroes(n));

            Console.ReadKey();
        }

        public static int TrailingZeroes(int n)
        {
            int pow = 1;
            int zeros = 0;

            while(Math.Pow(5, pow) <= n)
            {
                zeros += n / (int)Math.Pow(5, pow++);
            }

            return zeros;
        }
    }
}
