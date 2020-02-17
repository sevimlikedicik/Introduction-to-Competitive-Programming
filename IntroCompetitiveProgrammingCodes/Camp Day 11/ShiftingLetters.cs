using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_11
{
    class ShiftingLetters
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(Shifting("abc", arr));

            Console.ReadKey();
        }

        public static string Shifting(string S, int[] shifts)
        {
            long[] totalShifts = new long[shifts.Length];
            totalShifts[shifts.Length - 1] = shifts[shifts.Length - 1];

            for (int i = shifts.Length - 2; i >= 0; i--)
                totalShifts[i] = shifts[i] + totalShifts[i + 1];

            var chars = S.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] + (totalShifts[i] % 26));
                if (chars[i] > 'z')
                    chars[i] -= (char)(26);
            }

            return new string(chars);
        }
    }
}
