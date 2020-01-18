using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class LowestCommonAncestorOfDeepestLeaves
    {
        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(12);
            TreeNode node2 = new TreeNode(-1);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(11);
            TreeNode node5 = new TreeNode(13);
            TreeNode node6 = new TreeNode(4);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(2);
            TreeNode node9 = new TreeNode(1);
            TreeNode node10 = new TreeNode(1);
            TreeNode node11 = new TreeNode(31);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node3.left = node5;
            node3.right = node6;
            node4.left = node7;
            node4.right = node8;
            node6.right = node9;
            node6.left = node10;
            node10.left = node11;

            Console.WriteLine(LcaDeepestLeaves(node1).val);

            Console.ReadKey();
        }

        static TreeNode answer;

        public static TreeNode LcaDeepestLeaves(TreeNode root)
        {
            int maxDepth = FindMaxDepth(root, 0);
            int maxDepthElementCount = FindMaxDepthElementCount(root, 0, maxDepth);
            LcaDeepestLeaves(root, 0, maxDepth, maxDepthElementCount);

            return answer;
        }

        private static int LcaDeepestLeaves(TreeNode node, int depth, int maxDepth, int maxDepthElementCount)
        {
            if (node == null)
                return 0;
            if (depth == maxDepth)
            {
                if (maxDepthElementCount == 1)
                    answer = node;
                return 1;
            }

            int leftSum = LcaDeepestLeaves(node.left, depth + 1, maxDepth, maxDepthElementCount);
            int rightSum = LcaDeepestLeaves(node.right, depth + 1, maxDepth, maxDepthElementCount);

            if(leftSum + rightSum == maxDepthElementCount)
            {
                if(answer == null)
                    answer = node;
            }

            return leftSum + rightSum;
        }

        private static int FindMaxDepthElementCount(TreeNode node, int depth, int maxDepth)
        {
            if (node == null)
                return 0;
            else if (depth == maxDepth)
                return 1;
            else
                return FindMaxDepthElementCount(node.left, depth + 1, maxDepth) + FindMaxDepthElementCount(node.right, depth + 1, maxDepth);
        }

        private static int FindMaxDepth(TreeNode node, int depth)
        {
            if (node.left == null && node.right == null)
                return depth;
            else if (node.left == null)
                return FindMaxDepth(node.right, depth + 1);
            else if (node.right == null)
                return FindMaxDepth(node.left, depth + 1);
            else
                return Math.Max(FindMaxDepth(node.left, depth + 1), FindMaxDepth(node.right, depth + 1));
        }
    }
}
