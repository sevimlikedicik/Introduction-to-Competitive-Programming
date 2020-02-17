using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_08
{
    class NumberOfLinesToWriteString
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(NumberOfLines(arr, "abc"));

            Console.ReadKey();
        }

        public static int[] NumberOfLines(int[] widths, string S)
        {
            int total = 0;
            int line = 1;
            foreach (char c in S)
            {
                int width = widths[(int)(c - 'a')];

                if (total + width > 100)
                {
                    total = width;
                    line++;
                }
                else
                    total += width;
            }

            return new int[] { line, total };
        }
    }
}
