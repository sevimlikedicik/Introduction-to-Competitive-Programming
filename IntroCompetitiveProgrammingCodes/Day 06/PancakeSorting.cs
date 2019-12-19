using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class PancakeSorting
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            var list = PancakeSort(arr);

            foreach (int num in list)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static IList<int> PancakeSort(int[] A)
        {
            List<int> flips = new List<int>();

            for (int i = 1; i <= A.Length; i++)
            {
                int flipIndex = 0;
                int truePosition = A.Length - i;
                for (int j = 0; j <= A.Length - i; j++)
                {
                    if (A[j] == i)
                        flipIndex = j;
                }
                
                if(flipIndex != truePosition)
                {
                    Flip(A, flipIndex);
                    Flip(A, truePosition);
                    flips.Add(flipIndex + 1);
                    flips.Add(truePosition + 1);
                }
            }

            Flip(A, A.Length - 1);
            flips.Add(A.Length);

            return flips;
        }

        private static void Flip(int[] a, int flipIndex)
        {
            for(int i=0; i<= flipIndex / 2; i++)
            {
                int temp = a[i];
                a[i] = a[flipIndex - i];
                a[flipIndex - i] = temp;
            }
        }
    }
}
