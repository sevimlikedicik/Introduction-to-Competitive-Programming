using System;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class SortArrayByParityII
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            arr = SortArrayByParity(arr);

            foreach (int num in arr)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static int[] SortArrayByParity(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if(i % 2 == 0)
                {
                    if (A[i] % 2 != 0)
                    {
                        int counter = i;
                        while (A[counter] % 2 != 0)
                            counter++;

                        int temp = A[i];
                        A[i] = A[counter];
                        A[counter] = temp;
                    }
                }
                else
                {
                    if (A[i] % 2 == 0)
                    {
                        int counter = i;
                        while (A[counter] % 2 == 0)
                            counter++;

                        int temp = A[i];
                        A[i] = A[counter];
                        A[counter] = temp;
                    }
                }
            }

            return A;
        }
    }
}
