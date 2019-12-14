using System;

// Sum Positive Only and Sum With Negatives
namespace IntroCompetitiveProgrammingCodes.Day_01
{
    class SumBigNumbers
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');

            string n1 = phrase[0];
            string n2 = phrase[1];
            string total = "";

            if (n1[0] == '-' && n2[0] == '-')
                total = SumTwoNegatives(n1, n2);
            else
            {
                if (n1[0] == '-')
                    total = Subtract(n2, n1.Substring(1));
                else if (n2[0] == '-')
                    total = Subtract(n1, n2.Substring(1));
                else
                    total = SumTwoPositives(n1, n2);
            }

            Console.WriteLine(total);

            Console.ReadKey();
        }

        private static string SumTwoNegatives(string n1, string n2) => "-" + SumTwoPositives(n1.Substring(1), n2.Substring(1));

        private static string Subtract(string n1, string n2)
        {
            if (!IsFirstNumberBigger(n1, n2))
                return "-" + Subtract(n2, n1);

            string n1Reverse = Reverse(n1);
            string n2Reverse = Reverse(n2);
            string total = "";

            int carry = 0;

            for (int i = 0; i < n2.Length; i++)
            {
                int n1Digit = n1Reverse[i] - '0';
                int n2Digit = n2Reverse[i] - '0';

                int sub = n1Digit - n2Digit - carry;

                if (sub < 0)
                {
                    sub += 10;
                    carry = 1;
                }
                else
                    carry = 0;

                total += sub;
            }

            for (int i = n2.Length; i < n1.Length; i++)
            {
                int n1Digit = n1Reverse[i] - '0';

                int sub = n1Digit - carry;

                if (sub < 0)
                {
                    sub += 10;
                    carry = 1;
                }
                else
                    carry = 0;

                total += sub;
            }

            total = Reverse(total);

            int counter = 0;

            while (total[counter] == '0')
                counter++;

            return total.Substring(counter);
        }

        private static bool IsFirstNumberBigger(string n1, string n2)
        {
            if (n1.Length > n2.Length)
            {
                return true;
            }
            else if (n1.Length < n2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < n1.Length; i++)
                {
                    if (n1[i] > n2[i])
                        return true;
                    if (n2[i] > n1[i])
                        return false;
                }
            }
            return true;
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
