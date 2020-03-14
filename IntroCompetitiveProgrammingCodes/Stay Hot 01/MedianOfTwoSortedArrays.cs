using System;

namespace IntroCompetitiveProgrammingCodes.Stay_Hot_01
{
    class MedianOfTwoSortedArrays
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };
            int[] arr2 = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(FindMedianSortedArrays(arr, arr2));

            Console.ReadKey();
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] fullArray = new int[nums1.Length + nums2.Length];
            int index = 0;
            int left = 0;
            int right = 0;

            while (left < nums1.Length && right < nums2.Length) {
                bool leftSmaller = nums1[left] < nums2[right];
                fullArray[index++] = leftSmaller ? nums1[left++] : nums2[right++];
            }

            if (left == nums1.Length) {
                while (right < nums2.Length) {
                    fullArray[index++] = nums2[right++];
                }
            }
            else {
                while (left < nums1.Length) {
                    fullArray[index++] = nums1[left++];
                }
            }

            if (fullArray.Length % 2 == 1) {
                return (double)fullArray[fullArray.Length / 2];
            }

            return (fullArray[fullArray.Length / 2] * 1.0 + fullArray[fullArray.Length / 2 - 1]) / 2;
        }
    }
}
