using System;

namespace IntroCompetitiveProgrammingCodes.Day_03
{
    class TheatreSquare
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');

            long n = Convert.ToInt64(phrase[0]);
            long m = Convert.ToInt64(phrase[1]);
            long a = Convert.ToInt64(phrase[2]);

            Console.WriteLine(((n - 1) / a + 1) * ((m - 1) / a + 1));
        }
    }
}
