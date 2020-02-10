using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class _2KeysKeyboard
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinSteps(5));

            Console.ReadKey();
        }

        public static int MinSteps(int n)
        {
            int total = 0;
            int div = 2;

            while (n != 1)
            {
                if (n % div == 0)
                {
                    total += div;
                    n /= div;
                }
                else
                    div++;
            }

            return total;
        }
    }
}
