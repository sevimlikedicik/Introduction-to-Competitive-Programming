using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_02
{
    class BagOfTokens
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 100 };
            int[] arr2 = new int[] { 4, 3, 5, 1, 2 };

            Console.WriteLine(BagOfTokensScore(arr, 50));

            Console.ReadKey();
        }

        public static int BagOfTokensScore(int[] tokens, int P)
        {
            Array.Sort(tokens);
            int points = 0;
            int left = 0;
            int right = tokens.Length - 1;
            int maxPoints = 0;

            while (left <= right)
            {
                while (left <= right && P >= tokens[left])
                {
                    P -= tokens[left++];
                    points++;
                }

                if (points >= maxPoints)
                    maxPoints = points;
                else
                    break;

                if (points > 0)
                {
                    P += tokens[right--];
                    points--;
                }
                else
                    break;
            }

            return maxPoints;
        }
    }
}
