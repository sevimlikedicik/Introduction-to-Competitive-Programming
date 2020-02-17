using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class LongestPalindromicSubsequence
    {
        static void Main(string[] args)
        {
            LongestPalindromeSubseq("bbbab");

            Console.ReadKey();
        }

        public static int LongestPalindromeSubseq(string s)
        {
            var chars = s.ToCharArray();
            int[,] dp = new int[s.Length, s.Length];
            bool[,] visited = new bool[s.Length, s.Length];

            int max = int.MinValue;

            //One element centers
            for (int i = 0; i < s.Length; i++)
            {
                int val = SearchTheArray(i, dp, chars, visited);
                max = Math.Max(max, val);
            }

            //Two elements centers
            for (int i = 0; i < s.Length; i++)
            {
                int val = SearchTheArray(i, i + 1, dp, chars, visited);
                max = Math.Max(max, val);
            }

            return max;
        }

        static int SearchTheArray(int index, int[,] dp, char[] chars, bool[,] visited)
        {
            int currValue = 1;
            currValue += SearchTheArray(index - 1, index + 1, dp, chars, visited);
            return currValue;
        }

        static int SearchTheArray(int index1, int index2, int[,] dp, char[] chars, bool[,] visited)
        {
            int currValue = 0;

            if (index1 < 0 || index2 >= chars.Length)
                return 0;

            if (visited[index1, index2])
                return dp[index1, index2];

            bool isPalindromic = false;

            if (chars[index1] == chars[index2])
            {
                isPalindromic = true;
                currValue += 2;
            }

            if (isPalindromic)
                currValue += SearchTheArray(index1 - 1, index2 + 1, dp, chars, visited);
            else
                currValue += Math.Max(SearchTheArray(index1 - 1, index2, dp, chars, visited), SearchTheArray(index1, index2 + 1, dp, chars, visited));

            visited[index1, index2] = true;
            dp[index1, index2] = currValue;

            return currValue;
        }
    }
}
