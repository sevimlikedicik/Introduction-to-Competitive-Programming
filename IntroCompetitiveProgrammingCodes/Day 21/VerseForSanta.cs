using System;

namespace IntroCompetitiveProgrammingCodes.Day_21
{
    class VerseForSanta
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int[] results = new int[t];

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(phrase[0]);
                int s = Convert.ToInt32(phrase[1]);

                phrase = Console.ReadLine().Split(' ');
                int[] arr = new int[phrase.Length];

                for (int j = 0; j < phrase.Length; j++)
                    arr[j] = Convert.ToInt32(phrase[j]);

                int total = 0;
                int max = int.MinValue;
                int maxInd = int.MinValue;
                int giftCount = 0;

                for (int j = 0; total <= s && j < phrase.Length; j++)
                {
                    total += arr[j];
                    giftCount++;

                    if (arr[j] > max)
                    {
                        max = arr[j];
                        maxInd = j;
                    }
                }

                if (total > s)
                    results[i] = maxInd + 1;
                else
                    results[i] = 0;
            }

            foreach (var result in results)
                Console.WriteLine(result);
        }
    }
}
