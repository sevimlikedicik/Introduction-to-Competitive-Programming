using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class ValidateBinarySearchTree
    {
        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(10);
            TreeNode node2 = new TreeNode(5);
            TreeNode node3 = new TreeNode(15);
            TreeNode node4 = new TreeNode(6);
            TreeNode node5 = new TreeNode(20);

            node1.left = node2;
            node1.right = node3;
            node3.left = node4;
            node3.right = node5;

            Console.WriteLine(IsValidBST(node1));

            Console.ReadKey();
        }

        public static bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;

            return IsValid(root, long.MinValue, long.MaxValue);
        }

        private static bool IsValid(TreeNode node, long min, long max)
        {
            if (node.val <= min || node.val >= max)
                return false;

            if (node.left == null && node.right == null)
                return true;
            else if (node.left == null)
                return node.right.val > node.val && IsValid(node.right, node.val, max);
            else if (node.right == null)
                return node.left.val < node.val && IsValid(node.left, min, node.val);
            else
                return node.left.val < node.val && node.right.val > node.val && IsValid(node.left, min, node.val) && IsValid(node.right, node.val, max);
        }
    }
}
