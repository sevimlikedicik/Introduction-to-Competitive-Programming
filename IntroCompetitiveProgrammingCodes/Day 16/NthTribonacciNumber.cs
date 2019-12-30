using System;

namespace IntroCompetitiveProgrammingCodes.Day_16
{
    class NthTribonacciNumber
    {
        static int[] tri = new int[38];

        static void Main(string[] args)
        {
            Console.WriteLine(Tribonacci(Convert.ToInt32(Console.ReadLine())));

            Console.ReadKey();
        }

        public static int Tribonacci(int n)
        {
            if (tri[n] != 0)
                return tri[n];
            if (n == 0)
                return tri[n] = 0;
            if (n == 1)
                return tri[n] = 1;
            if (n == 2)
                return tri[n] = 1;

            tri[n] = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
            return tri[n];
        }
    }
}
