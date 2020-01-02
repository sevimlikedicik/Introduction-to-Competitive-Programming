using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class SmallestIntegerDivisibleByK
    {
        static void Main(string[] args)
        {
            int k = 57;

            Console.WriteLine(SmallestRepunitDivByK(k));

            Console.ReadKey();
        }

        public static int SmallestRepunitDivByK(int K)
        {
            int n = 1;
            int len = 1;

            while (len < 100000 && n % K != 0)
            {
                n = (n % K) * 10 + 1;
                len++;
            }

            if (len == 100000)
                return -1;

            return len;
        }
    }
}
