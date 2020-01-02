using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class Fraction
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            if (t % 2 == 0)
            {
                if (t % 4 == 0)
                    Console.WriteLine($"{t / 2 - 1} {t / 2 + 1}");
                else
                    Console.WriteLine($"{t / 2 - 2} {t / 2 + 2}");
            }
            else
                Console.WriteLine($"{t / 2} {t / 2 + 1}");
        }
    }
}
