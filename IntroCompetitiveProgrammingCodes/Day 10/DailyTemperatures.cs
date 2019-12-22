using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_10
{
    class DailyTemperatures
    {
        static void Main(string[] args)
        {
            int[] temps = new int[8] { 73, 74, 75, 71, 69, 72, 76, 73 };

            var happyNews = NextWarmerDay(temps);

            foreach (int day in happyNews)
                Console.Write($"{day} ");

            Console.ReadKey();
        }

        public static int[] NextWarmerDay(int[] T)
        {
            int[] happyNews = new int[T.Length];
            int[] nextIndex = new int[101];

            Array.Fill(nextIndex, int.MaxValue);

            for (int i = T.Length - 1; i >= 0; i--)
            {
                int temp = T[i];
                int warmerIndex = int.MaxValue;

                for (int j = temp + 1; j <= 100; j++)
                {
                    if (nextIndex[j] < warmerIndex)
                        warmerIndex = nextIndex[j];
                }

                if (warmerIndex == int.MaxValue)
                    happyNews[i] = 0;
                else
                    happyNews[i] = warmerIndex - i;

                nextIndex[temp] = i;
            }

            return happyNews;
        }
    }
}
