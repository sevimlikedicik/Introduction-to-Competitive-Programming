using System;
using System.Collections.Generic;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_16
{
    class AllPossibleFullBinaryTrees
    {
        static void Main(string[] args)
        {
            int n = 7;

            var trees = AllPossibleFBT(n);

            Console.ReadKey();
        }

        public static IList<TreeNode> AllPossibleFBT(int N)
        {
            List<TreeNode> allTrees = new List<TreeNode>();

            if (N % 2 == 0)
                return allTrees;

            return FindAllTrees(N - 1);
        }

        public static List<TreeNode> FindAllTrees(int remaining)
        {
            if (remaining == 0)
                return new List<TreeNode>() { new TreeNode(0) };

            List<TreeNode> allTrees = new List<TreeNode>();
            List<TreeNode> leftTrees = new List<TreeNode>(), rightTrees = new List<TreeNode>();

            for (int i = 0; i <= remaining - 2; i = i + 2)
            {
                leftTrees = FindAllTrees(i);
                rightTrees = FindAllTrees(remaining - i - 2);

                // Merge all combinations of trees from left and right
                foreach (var leftTree in leftTrees)
                {
                    foreach (var rightTree in rightTrees)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = leftTree;
                        root.right = rightTree;
                        allTrees.Add(root);
                    }
                }
            }

            return allTrees;
        }
    }
}
