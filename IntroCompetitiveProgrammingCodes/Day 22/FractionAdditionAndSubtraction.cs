using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class FractionAdditionAndSubtraction
    {
        static void Main(string[] args)
        {
            string expression = "5/3+1/3";

            Console.WriteLine(FractionAddition(expression));

            Console.ReadKey();
        }

        public static string FractionAddition(string expression)
        {
            if (expression == null)
                return null;

            var fractions = expression.Split(new char[] { '+', '-' });

            char[] signs = new char[fractions.Length];

            if (expression[0] != '-')
                signs[0] = '+';
            else
                signs[0] = '-';

            int signsIndex = 1;

            for (int i = 1; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '-')
                    signs[signsIndex++] = expression[i];
            }

            int startingIndex = 0;
            if (signs[0] == '-')
                startingIndex++;

            int[] numerators = new int[fractions.Length - startingIndex];
            int[] denominators = new int[fractions.Length - startingIndex];

            for (int i = startingIndex; i < fractions.Length; i++)
            {
                var numbers = fractions[i].Split('/');

                numerators[i- startingIndex] = Convert.ToInt32(numbers[0]);
                denominators[i - startingIndex] = Convert.ToInt32(numbers[1]);
            }

            var result = AddFractions(numerators, denominators, signs);

            if (result == null)
                return null;

            return result[0] + "/" + result[1];
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }

        public static int LCM(int a, int b) => a * b / GCD(a, b);

        public static int[] AddFractions(int[] numerators, int[] denominators, char[] signs)
        {
            if (numerators.Length == 0)
                return null;

            if (numerators.Length == 1)
            {
                if (signs[0] == '+')
                    return new int[] { numerators[0], denominators[0] };
                else
                    return new int[] { -numerators[0], denominators[0] };
            }

            int denominator = LCM(denominators[0], denominators[1]);

            for (int i = 2; i < denominators.Length; i++)
                denominator = LCM(denominator, denominators[i]);

            int numerator = 0;

            for (int i = 0; i < denominators.Length; i++)
            {
                if (signs[i] == '+')
                    numerator += (denominator / denominators[i] * numerators[i]);
                else
                    numerator -= (denominator / denominators[i] * numerators[i]);
            }

            return Reduce(numerator, denominator);
        }

        private static int[] Reduce(int numerator, int denominator)
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));

            return new int[] { numerator / gcd, denominator / gcd };
        }
    }
}
