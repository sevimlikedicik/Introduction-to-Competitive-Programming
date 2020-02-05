using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_1
{
    class GetEqualSubstringsWithinBudget
    {
        static void Main(string[] args)
        {
            string a = "abcd";
            string b = "acde";

            Console.WriteLine(EqualSubstring(a, b, 0));

            Console.ReadKey();
        }

        public static int EqualSubstring(string s, string t, int maxCost)
        {
            int[] costs = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
                costs[i] = Math.Abs(s[i] - t[i]);

            int left = 0;
            int right = 0;
            int total = 0;
            int maxLength = int.MinValue;
            int length = 0;

            while (left < costs.Length && right < costs.Length)
            {
                while (right < costs.Length && total <= maxCost)
                {
                    total += costs[right++];
                    length++;
                }

                if (right == costs.Length)
                {
                    if (total <= maxCost)
                    {
                        if (length > maxLength)
                            maxLength = length;
                    }
                    else
                    {
                        if (length - 1 > maxLength)
                            maxLength = length - 1;
                    }
                }
                else
                {
                    if (length - 1 > maxLength)
                        maxLength = length - 1;
                }

                while (left < costs.Length && total > maxCost)
                {
                    total -= costs[left++];
                    length--;
                }

                if (length - 1 > maxLength)
                    maxLength = length - 1;
            }

            return maxLength;
        }
    }
}
