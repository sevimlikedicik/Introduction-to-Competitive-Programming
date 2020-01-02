using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class PerfectNumbercs
    {
        static void Main(string[] args)
        {
            int n = 6;

            Console.WriteLine(CheckPerfectNumber(n));

            Console.ReadKey();
        }

        public static bool CheckPerfectNumber(int num)
        {
            if (num == 1)
                return false;

            int edge = (int)Math.Sqrt(num);
            int total = 1;

            for (int i = 2; i <= edge; i++)
            {
                if(num % i == 0)
                    total += (num / i) + i;
            }

            return total == num;
        }
    }
}
