using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class CountPrimes
    {
        static void Main(string[] args)
        {
            int n = 11;

            Console.WriteLine(CountPrime(n));

            Console.ReadKey();
        }

        public static int CountPrime(int n)
        {
            if (n == 0 || n == 1)
                return 0;

            bool[] prime = new bool[n + 1];
            Array.Fill(prime, true);
            prime[0] = false;
            prime[1] = false;
            int m = (int)Math.Sqrt(n);
            int primeCount = 0;

            for (int i = 2; i <= m; i++)
            {
                if (prime[i])
                {
                    for (int k = i * i; k <= n; k += i)
                    {
                        prime[k] = false;
                    }
                    primeCount++;
                }
            }

            for (int i = m + 1; i < n; i++)
            {
                if (prime[i])
                    primeCount++;
            }

            return primeCount;
        }

    }
}
