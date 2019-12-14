using System;

namespace IntroCompetitiveProgrammingCodes.Day_02
{
    class MultiplyBigNumbers
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');

            string n1 = phrase[0];
            string n2 = phrase[1];
            string result = "";

            if (n1[0] == '-' && n2[0] == '-')
                result = Multiply(n1.Substring(1), n2.Substring(1));
            else
            {
                if (n1[0] == '-')
                    result = "-" + Multiply(n2, n1.Substring(1));
                else if (n2[0] == '-')
                    result = "-" + Multiply(n1, n2.Substring(1));
                else
                    result = Multiply(n1, n2);
            }

            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static string Multiply(string n1, string n2)
        {
            string multiplication = "";

            string n2Reverse = Reverse(n2);

            // n2 is randomly chosen
            for (int i = 0; i < n2Reverse.Length; i++)
            {
                string row = MultiplyWithSingleDigit(n1, n2Reverse[i] - '0');
                for (int j = 0; j < i; j++)
                    row += "0";

                multiplication = SumTwoPositives(multiplication, row);
            }

            return multiplication;
        }

        private static string MultiplyWithSingleDigit(string n1, int multiplier)
        {
            string result = "";

            int carry = 0;

            for (int i = 0; i < n1.Length; i++)
            {
                int multi = (n1[i] - '0') * multiplier + carry;

                if(multi > 9)
                {
                    carry = multi / 10;
                    multi /= 10;
                }

                result += multi;
            }

            if (carry != 0)
                result += carry;

            return result;
        }

        private static string SumTwoPositives(string n1, string n2)
        {
            string total = "";

            string n1Reverse = Reverse(n1);
            string n2Reverse = Reverse(n2);

            int smallerNumberDigits = Math.Min(n1Reverse.Length, n2Reverse.Length);
            int carry = 0;

            for (int i = 0; i < smallerNumberDigits; i++)
            {
                int totalOfColumn = (n1Reverse[i] - '0') + (n2Reverse[i] - '0') + carry;
                carry = totalOfColumn / 10;
                int mode = totalOfColumn % 10;
                total += mode;
            }

            if (smallerNumberDigits == n1Reverse.Length)
            {
                for (int i = smallerNumberDigits; i < n2Reverse.Length; i++)
                {
                    int totalOfColumn = (n2Reverse[i] - '0') + carry;
                    carry = totalOfColumn / 10;
                    int mode = totalOfColumn % 10;
                    total += mode;
                }
            }
            else
            {
                for (int i = smallerNumberDigits; i < n1Reverse.Length; i++)
                {
                    int totalOfColumn = (n1Reverse[i] - '0') + carry;
                    carry = totalOfColumn / 10;
                    int mode = totalOfColumn % 10;
                    total += mode;
                }
            }

            if (carry == 1)
                total += "1";

            return Reverse(total);
        }
        private static string Reverse(string s)
        {
            string reverse = "";

            for (int i = s.Length - 1; i >= 0; i--)
                reverse += s[i];

            return reverse;
        }

    }
}
