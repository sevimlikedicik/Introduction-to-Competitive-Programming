using System;

namespace IntroCompetitiveProgrammingCodes.Day_16
{
    class PartitionToKEqualSumSubsets
    {
        internal class GroupInfo
        {
            public int Total;
            public int MemberCount;

            public GroupInfo(int total, int memberCount)
            {
                Total = total;
                MemberCount = memberCount;
            }
        }

        static void Main(string[] args)
        {
            int[] nums = { 730, 580, 401, 659, 5524, 405, 1601, 3, 383, 4391, 4485, 1024, 1175, 1100, 2299, 3908 };
            int[] nums2 = { 4, 3, 2, 3, 5, 2, 1 };
            int[] nums3 = { 1739, 5391, 8247, 236, 5581, 11, 938, 58, 1884, 823, 686, 1760, 6498, 6513, 6316, 2867 };
            int[] nums4 = { 1, 2, 3, 4 };
            int[] nums5 = { 960, 3787, 1951, 5450, 4813, 752, 1397, 801, 1990, 1095, 3643, 8133, 893, 5306, 8341, 5246 };
            int[] nums6 = { 5, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3 };

            Console.WriteLine(CanPartitionKSubsets(nums6, 15));

            Console.ReadKey();
        }

        public static bool CanPartitionKSubsets(int[] nums, int k)
        {
            int total = 0;
            for (int i = 0; i < nums.Length; i++)
                total += nums[i];

            if (total % k != 0)
                return false;

            Array.Sort(nums);
            Array.Reverse(nums);

            var groups = new GroupInfo[k];
            for (int i = 0; i < k; i++)
                groups[i] = new GroupInfo(0, 0);

            return AllCombinations(nums, groups, 0, 0, nums.Length - k + 1, total / k);
        }

        private static bool AllCombinations(int[] nums, GroupInfo[] groups, int index, int groupIndex, int largestGroupSize, int requiredTotal)
        {
            if (index == nums.Length)
                return true;

            if (groups[groupIndex].MemberCount == largestGroupSize || groups[groupIndex].Total + nums[index] > requiredTotal)
                return false;

            groups[groupIndex].Total += nums[index];
            groups[groupIndex].MemberCount++;
            bool groupingSuccessful = false;

            for (int i = 0; i < groups.Length; i++)
                groupingSuccessful = groupingSuccessful || AllCombinations(nums, groups, index + 1, i, largestGroupSize, requiredTotal);

            groups[groupIndex].MemberCount--;
            groups[groupIndex].Total -= nums[index];

            return groupingSuccessful;
        }
    }
}
