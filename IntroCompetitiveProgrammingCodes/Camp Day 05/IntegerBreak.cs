using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class IntegerBreak
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BreakInteger(5));

            Console.ReadKey();
        }

        public static int BreakInteger(int n)
        {
            if (n == 2)
                return 1;

            if (n == 3)
                return 2;

            if (n % 3 == 0)
                return (int)Math.Pow(3, n / 3);

            if (n % 3 == 1)
                return (int)Math.Pow(3, n / 3 - 1) * 4;

            return (int)Math.Pow(3, n / 3) * 2;
        }
    }
}
