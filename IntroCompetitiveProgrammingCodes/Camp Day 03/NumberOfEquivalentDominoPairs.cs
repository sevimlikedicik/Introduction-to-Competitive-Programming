using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_03
{
    class NumberOfEquivalentDominoPairs
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 } };

            Console.WriteLine(NumEquivDominoPairs(mtr));

            Console.ReadKey();
        }

        public static int NumEquivDominoPairs(int[][] dominoes)
        {
            int[][] numCount = new int[10][];

            for (int i = 0; i < 10; i++)
                numCount[i] = new int[10];

            for (int i = 0; i < dominoes.Length; i++)
            {
                if (dominoes[i][0] < dominoes[i][1])
                    numCount[dominoes[i][1]][dominoes[i][0]]++;
                else
                    numCount[dominoes[i][0]][dominoes[i][1]]++;
            }

            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int count = numCount[i][j];
                    total += (count * (count - 1)) / 2;
                }
            }

            return total;
        }
    }
}
