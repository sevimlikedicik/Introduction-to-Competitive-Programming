using System;

namespace IntroCompetitiveProgrammingCodes.Day_20
{
    class KForThePriceOfOne_Easy_
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            int[] results = new int[t];

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(phrase[0]);
                int p = Convert.ToInt32(phrase[1]);
                int k = Convert.ToInt32(phrase[2]);

                phrase = Console.ReadLine().Split(' ');
                int[] arr = new int[n];

                for (int j = 0; j < n; j++)
                    arr[j] = Convert.ToInt32(phrase[j]);

                results[i] = MaxGifts(arr, p, k);
            }

            foreach (int result in results)
                Console.WriteLine(result);
        }

        private static int MaxGifts(int[] arr, int p, int k)
        {
            Array.Sort(arr);
            int maxGitfs = 0;

            for (int i = 0; i < k; i++)
            {
                int gifts = 0;
                int money = p;
                for (int j = 0; j < i && money >= arr[j]; j++)
                {
                    money -= arr[j];
                    gifts++;
                }

                for (int j = i + k - 1; j < arr.Length && money >= arr[j]; j += k)
                {
                    money -= arr[j];
                    gifts += 2;
                }

                if (gifts > maxGitfs)
                    maxGitfs = gifts;
            }

            return maxGitfs;
        }
    }
}
