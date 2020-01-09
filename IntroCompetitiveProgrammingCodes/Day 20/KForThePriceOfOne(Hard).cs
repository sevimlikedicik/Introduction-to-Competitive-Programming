using System;

namespace IntroCompetitiveProgrammingCodes.Day_20
{
    class KForThePriceOfOne_Hard_
    {
        static void Main(string[] args)
        {
            int t = ReadInt();

            int[] results = new int[t];

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');

                int n = ConvertInt(phrase[0]);
                long p = ConvertLong(phrase[1]);
                int k = ConvertInt(phrase[2]);

                phrase = ReadLineAsArray();
                int[] arr = new int[n];

                for (int j = 0; j < n; j++)
                    arr[j] = ConvertInt(phrase[j]);

                results[i] = MaxGifts(arr, p, k);
            }

            foreach (int result in results)
                Console.WriteLine(result);
        }

        private static int MaxGifts(int[] arr, long p, int k)
        {
            Array.Sort(arr);
            int maxGitfs = 0;
            int[] s = new int[k + 1];

            for (int i = 1; i < k + 1; i++)
            {
                int gifts = 0;
                long money = p;

                if (i == k)
                    s[i] = arr[i - 1];
                else
                    s[i] = s[i - 1] + arr[i - 1];

                if (s[i] <= money)
                {
                    gifts += i;
                    money -= s[i];

                    if (maxGitfs < gifts)
                        maxGitfs = gifts;
                }

                for (int j = i + k - 1; j < arr.Length && money >= arr[j]; j += k)
                {
                    money -= arr[j];
                    gifts += k;
                }

                if (gifts > maxGitfs)
                    maxGitfs = gifts;
            }

            return maxGitfs;
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
