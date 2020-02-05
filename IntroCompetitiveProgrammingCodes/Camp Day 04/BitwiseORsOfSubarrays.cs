using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_04
{
    class BitwiseORsOfSubarrays
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };
            int[] arr2 = new int[] { 4, 1, 2, 3 };

            Console.WriteLine(SubarrayBitwiseORs(arr2));

            Console.ReadKey();
        }

        public static int SubarrayBitwiseORs(int[] A)
        {
            HashSet<int> prev = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < A.Length; i++)
            {
                HashSet<int> temp = new HashSet<int>() { A[i] };
                result.Add(A[i]);

                foreach (int num in prev)
                {
                    temp.Add(A[i] | num);
                    result.Add(A[i] | num);
                }

                prev = temp;
            }

            return result.Count;
        }
    }
}
