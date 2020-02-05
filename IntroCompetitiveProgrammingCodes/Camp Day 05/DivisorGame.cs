using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class DivisorGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Divisor(10));

            Console.ReadKey();
        }

        public static bool Divisor(int N) => N % 2 == 0;
    }
}
