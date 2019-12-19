using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class IntersectionOfTwoArrays
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

            arr1 = Intersection(arr1, arr2);

            foreach (int num in arr1)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> intersection = new List<int>();

            for(int i=0; i<nums1.Length; i++)
            {
                if(!intersection.Contains(nums1[i]))
                {
                    bool intersects = false;

                    for (int j = 0; j < nums2.Length; j++)
                    {
                        if (nums2[j] == nums1[i])
                        {
                            intersects = true;
                            break;
                        }
                    }

                    if (intersects)
                        intersection.Add(nums1[i]);
                }
            }

            return intersection.ToArray();
        }
    }
}
