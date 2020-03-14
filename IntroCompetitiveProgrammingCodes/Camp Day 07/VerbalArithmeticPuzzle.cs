using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_07
{
    class VerbalArithmeticPuzzle
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "SEND", "MORE" };
            string[] arr2 = new string[] { "AB", "AB" };
            string[] arr3 = new string[] { "A", "B", "B" };
            string[] arr4 = new string[] { "LEET", "CODE" };
            string[] arr5 = new string[] { "THIS", "IS", "TOO" };

            string result = "POINT";

            Console.WriteLine(IsSolvable(arr4, result));

            Console.ReadKey();
        }

        public static bool IsSolvable(string[] words, string result)
        {
            int[] nums = new int[10];
            int[][] combinations = new int[10000][];
            Words = words;
            Result = result;

            for (int i = 0; i < Words.Length; i++)
            {
                foreach (char c in Words[i])
                    hs.Add(c);
            }

            foreach (char c in Result)
                hs.Add(c);

            for (int i = 0; i < 10; i++)
                nums[i] = i;

            foreach (char c in hs)
                Values.Add(c, 0);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine(sw.ElapsedMilliseconds);

            Prunning();

            GetCombination(nums, nums.Length, hs.Count, combinations);
            Console.WriteLine(sw.ElapsedMilliseconds);

            for (int i = 0; i < combinations.Length; i++)
                prnPermut(combinations[i], 0, hs.Count - 1);

            Console.WriteLine(sw.ElapsedMilliseconds);

            return IsPossible;
        }

        private static void Prunning()
        {
            prune = new Dictionary<char, int>[7];

            for (int i = 0; i < 7; i++)
                prune[i] = new Dictionary<char, int>();

            int pow;

            for (int i = 0; i < Words.Length; i++)
            {
                pow = 0;
                for (int j = Words[i].Length - 1; j >= 0; j--)
                {
                    if (prune[pow].ContainsKey(Words[i][j]))
                        prune[pow][Words[i][j]]++;
                    else
                        prune[pow].Add(Words[i][j], 1);
                    pow++;
                }
            }

            pow = 0;
            for (int j = Result.Length - 1; j >= 0; j--)
            {
                if (prune[pow].ContainsKey(Result[j]))
                    prune[pow][Result[j]]--;
                else
                    prune[pow].Add(Result[j], -1);
                pow++;
            }
        }

        static Dictionary<char, int>[] prune;
        static int combIndex = 0;
        static bool IsPossible = false;
        static string[] Words;
        static string Result;
        static Dictionary<char, int> Values = new Dictionary<char, int>();
        static HashSet<char> hs = new HashSet<char>();

        static void combinationUtil(int[] arr, int n, int r, int index, int[] data, int i, int[][] combinations)
        {
            if (index == r)
            {
                combinations[combIndex] = new int[r];

                for (int j = 0; j < r; j++)
                    combinations[combIndex][j] = data[j];

                combIndex++;
                return;
            }

            if (i >= n)
                return;

            data[index] = arr[i];
            combinationUtil(arr, n, r, index + 1, data, i + 1, combinations);
            combinationUtil(arr, n, r, index, data, i + 1, combinations);
        }

        static void GetCombination(int[] arr, int n, int r, int[][] combinations)
        {
            int[] data = new int[r];
            combinationUtil(arr, n, r, 0, data, 0, combinations);
        }

        public static void swapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void prnPermut(int[] list, int k, int m)
        {
            int i;
            if (k == m)
            {
                if (list == null)
                    return;

                int index = 0;

                foreach (char c in hs)
                    Values[c] = list[index++];

                IsPossible = IsPossible || Try();
            }
            else
                for (i = k; i <= m; i++)
                {
                    if (list == null)
                        return;

                    swapTwoNumber(ref list[k], ref list[i]);
                    prnPermut(list, k + 1, m);
                    swapTwoNumber(ref list[k], ref list[i]);
                }
        }

        private static bool Try()
        {
            int carry = 0;

            foreach (var level in prune)
            {
                int total = carry;
                foreach (var kvp in level)
                    total += Values[kvp.Key] * kvp.Value;

                if (total % 10 != 0)
                    return false;

                carry = total / 10;
            }

            return true;
        }
    }
}
