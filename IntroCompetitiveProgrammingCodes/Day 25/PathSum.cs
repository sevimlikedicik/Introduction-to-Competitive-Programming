using System;
using System.Collections.Generic;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class PathSum
    {
        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(5);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(8);
            TreeNode node4 = new TreeNode(11);
            TreeNode node5 = new TreeNode(13);
            TreeNode node6 = new TreeNode(4);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(2);
            TreeNode node9 = new TreeNode(1);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node3.left = node5;
            node3.right = node6;
            node4.left = node7;
            node4.right = node8;
            node6.right = node9;

            Console.WriteLine(HasPathSum(node1, 22));

            Console.ReadKey();
        }

        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            return LookSum(root, sum, 0);
        }

        private static bool LookSum(TreeNode node, int sum, int subTotal)
        {
            subTotal += node.val;

            if (node.left == null && node.right == null)
                return subTotal == sum;
            else if (node.left != null && node.right != null)
                return LookSum(node.left, sum, subTotal) || LookSum(node.right, sum, subTotal);
            else if (node.left != null)
                return LookSum(node.left, sum, subTotal);
            else
                return LookSum(node.right, sum, subTotal);
        }
    }
}
