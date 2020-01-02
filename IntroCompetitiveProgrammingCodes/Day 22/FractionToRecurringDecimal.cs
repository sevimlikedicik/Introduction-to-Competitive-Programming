using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class FractionToRecurringDecimal
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FractionToDecimal(-1, -2147483648));

            Console.ReadKey();
        }

        public static string FractionToDecimal(int numerator, int denominator)
        {
            if ((numerator <= 0 && denominator <= 0) || (numerator >= 0 && denominator >= 0))
            {
                long numeratorLong = Math.Abs((long)numerator);
                long denominatorLong = Math.Abs((long)denominator);

                if ((numeratorLong % denominatorLong) == 0)
                    return "" + (numeratorLong / denominatorLong);

                return (numeratorLong / denominatorLong) + "." + FindFractionalPart(numeratorLong % denominatorLong, denominatorLong);
            }
            else
            {
                long numeratorLong = Math.Abs((long)numerator);
                long denominatorLong = Math.Abs((long)denominator);

                if (numeratorLong % denominatorLong == 0)
                    return "-" + (numeratorLong / denominatorLong);

                return "-" + (Math.Abs(numeratorLong / denominatorLong)) + "." + FindFractionalPart(Math.Abs((long)numeratorLong % denominatorLong), Math.Abs((long)denominatorLong));
            }
        }

        private static string FindFractionalPart(long numerator, long denominator)
        {
            int[] fractionPart = new int[1000];
            Dictionary<long, int> numerators = new Dictionary<long, int>();

            int len = 0;

            numerator *= 10;
            numerators.Add(numerator, 0);

            int number = (int)(numerator / denominator);

            while (true)
            {
                fractionPart[len++] = number;
                numerator = 10 * (numerator % denominator);

                if (numerators.ContainsKey(numerator) || numerator == 0)
                    break;

                numerators.Add(numerator, len);
                number = (int)(numerator / denominator);
            }

            string s = "";
            int startingIndex = 0;

            if (numerator == 0)
                startingIndex = len;
            else
                startingIndex = numerators[numerator];

            for (int i = 0; i < startingIndex; i++)
                s += fractionPart[i];

            if (numerator != 0)
            {
                s += "(";

                for (int i = startingIndex; i < len; i++)
                    s += fractionPart[i];

                s += ")";
            }

            return s;
        }
    }
}
