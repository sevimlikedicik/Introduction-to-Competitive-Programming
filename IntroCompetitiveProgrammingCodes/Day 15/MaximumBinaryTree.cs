using System;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_15
{
    class MaximumBinaryTree
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 2, 1, 6, 0, 5 };

            TreeNode root = ConstructMaximumBinaryTree(arr);

            Console.ReadKey();
        }

        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums.Length == 0)
                return null;

            int max = int.MinValue;
            int maxInd = -1;

            for(int i=0; i<nums.Length; i++)
            {
                if(nums[i] > max)
                {
                    max = nums[i];
                    maxInd = i;
                }
            }

            int[] leftArr = new int[maxInd];
            int[] rightArr = new int[nums.Length - maxInd - 1];

            Array.Copy(nums, leftArr, maxInd);
            Array.Copy(nums, maxInd + 1, rightArr, 0, rightArr.Length);

            TreeNode root = new TreeNode(max);

            root.left = ConstructMaximumBinaryTree(leftArr);
            root.right = ConstructMaximumBinaryTree(rightArr);

            return root;
        }
    }
}
