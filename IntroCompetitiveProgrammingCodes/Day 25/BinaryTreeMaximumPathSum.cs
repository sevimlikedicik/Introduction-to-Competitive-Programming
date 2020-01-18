using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class BinaryTreeMaximumPathSum
    {
        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(-2);
            TreeNode node2 = new TreeNode(-1);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(11);
            TreeNode node5 = new TreeNode(13);
            TreeNode node6 = new TreeNode(4);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(2);
            TreeNode node9 = new TreeNode(1);

            node1.left = node2;
            //node1.right = node3;
            //node2.left = node4;
            //node3.left = node5;
            //node3.right = node6;
            //node4.left = node7;
            //node4.right = node8;
            //node6.right = node9;

            Console.WriteLine(MaxPathSum(node1));

            Console.ReadKey();
        }

        static int max = int.MinValue;

        public static int MaxPathSum(TreeNode root)
        {
            FindMaxPathSum(root);
            return max;
        }

        private static int FindMaxPathSum(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                if (node.val > max)
                    max = node.val;
                return node.val;
            }
            else if (node.left == null)
            {
                int rightSum = FindMaxPathSum(node.right);

                if (rightSum < 0)
                {
                    if (node.val > max)
                        max = node.val;

                    return node.val;
                }
                else
                {
                    int total = node.val + rightSum;

                    if (total > max)
                        max = total;

                    return total;
                }
            }
            else if (node.right == null)
            {
                int leftSum = FindMaxPathSum(node.left);

                if (leftSum < 0)
                {
                    if (node.val > max)
                        max = node.val;

                    return node.val;
                }
                else
                {
                    int total = node.val + leftSum;

                    if (total > max)
                        max = total;

                    return total;
                }
            }
            else
            {
                int leftSum = FindMaxPathSum(node.left);
                int rightSum = FindMaxPathSum(node.right);
                int total = leftSum + rightSum + node.val;

                if (total > max)
                    max = total;

                int subSum = Math.Max(leftSum, rightSum);

                if (subSum < 0)
                {
                    if (node.val > max)
                        max = node.val;

                    return node.val;
                }
                else
                {
                    total = subSum + node.val;

                    if (total > max)
                        max = node.val + subSum;

                    return total;
                }
            }
        }
    }
}
