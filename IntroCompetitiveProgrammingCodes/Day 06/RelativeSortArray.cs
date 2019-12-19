using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class RelativeSortArray
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr1 = new int[phrase.Length];

            for (int i = 0; i < arr1.Length; i++)
                arr1[i] = Convert.ToInt32(phrase[i]);

            phrase = Console.ReadLine().Split(' ');
            int[] arr2 = new int[phrase.Length];

            for (int i = 0; i < arr2.Length; i++)
                arr2[i] = Convert.ToInt32(phrase[i]);

            arr1 = SortArray(arr1, arr2);

            foreach (int num in arr1)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static int[] SortArray(int[] arr1, int[] arr2)
        {
            int arr2ElementsIndex = 0;

            for(int i=0; i<arr2.Length; i++)
            {
                for(int j = 0; j<arr1.Length; j++)
                {
                    if(arr2[i] == arr1[j])
                    {
                        int temp = arr1[arr2ElementsIndex];
                        arr1[arr2ElementsIndex++] = arr1[j];
                        arr1[j] = temp;
                    }
                }
            }

            int[] remainingElementsCopy = new int[arr1.Length - arr2ElementsIndex];

            Array.Copy(arr1, arr2ElementsIndex, remainingElementsCopy, 0, remainingElementsCopy.Length);
            Array.Sort(remainingElementsCopy);
            Array.Copy(remainingElementsCopy, 0, arr1, arr2ElementsIndex, remainingElementsCopy.Length);

            return arr1;
        }
    }
}
