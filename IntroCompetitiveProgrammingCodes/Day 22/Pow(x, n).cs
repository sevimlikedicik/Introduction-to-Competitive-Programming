using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class Pow_x__n_
    {
        static void Main(string[] args)
        {
            double a = 1.00000;
            int b = -2147483648;

            Console.WriteLine(MyPow(a, b));

            Console.ReadKey();
        }

        public static double MyPow(double x, int n)
        {
            double result = 1;
            long absN = Math.Abs((long)n);

            if (absN > 3)
            {
                int closestPowTwo = 1;
                long nCopy = absN;

                while (nCopy / 2 > 1)
                {
                    nCopy /= 2;
                    closestPowTwo++;
                }

                result = x;

                if (absN - Math.Pow(2, closestPowTwo) > Math.Pow(2, closestPowTwo + 1) - absN)
                {
                    closestPowTwo++;

                    for (long i = 0; i < closestPowTwo; i++)
                        result *= result;

                    for (long i = (long)Math.Pow(2, closestPowTwo); i > absN; i--)
                        result /= x;
                }
                else
                {
                    for (long i = 0; i < closestPowTwo; i++)
                        result *= result;

                    for (long i = (long)Math.Pow(2, closestPowTwo); i < absN; i++)
                        result *= x;
                }
            }
            else
            {
                for (int i = 0; i < absN; i++)
                    result *= x;
            }

            if (n > 0)
                return result;
            else
                return 1.0 / result;
        }
    }
}
