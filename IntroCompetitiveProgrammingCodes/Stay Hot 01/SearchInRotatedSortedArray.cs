using System;

namespace IntroCompetitiveProgrammingCodes.Stay_Hot_01
{
    class SearchInRotatedSortedArray
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(Search(arr, 4));

            Console.ReadKey();
        }

        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;

            int low = 0;
            int high = nums.Length - 1;

            while (low <= high) {
                int mid = low + (high - low) / 2;

                if (target == nums[mid]) {
                    return mid;
                }

                if (nums[low] <= nums[mid]) {
                    if (target >= nums[low] && target < nums[mid]) {
                        high = mid - 1;
                    }
                    else {
                        low = mid + 1;
                    }
                }
                else {
                    if (target > nums[mid] && target <= nums[high]) {
                        low = mid + 1;
                    }
                    else {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
