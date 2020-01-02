using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class NthDigit
    {
        static void Main(string[] args)
        {
            int k = 190;

            Console.WriteLine(FindNthDigit(k));

            Console.ReadKey();
        }

        public static int FindNthDigit(int n)
        {
            int level = 0;
            int lastLevelBorder = 0;
            long border = 9;

            while (n > border)
            {
                level++;
                lastLevelBorder = (lastLevelBorder * 10) + 9;
                border += (long)Math.Pow(10, level) * 9 * (level + 1);
            }

            long lastBorder = border - (long)Math.Pow(10, level) * 9 * (level + 1);
            long a = border - lastBorder;
            n -= (int)lastBorder;

            int number = lastLevelBorder + (n - 1) / (level + 1) + 1;
            int remainder = (n - 1) % (level + 1);

            string numberStr = "" + number.ToString();

            return Convert.ToInt32(numberStr[remainder] - '0');
        }
    }
}
