using System;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_06
{
    class MaximumProductOfSplittedBinaryTree
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(4);

            t1.left = node1;
            t1.right = node2;
            t1.left.left = node3;

            Console.WriteLine(MaxProduct(t1));

            Console.ReadKey();
        }

        public static int MaxProduct(TreeNode root)
        {
            TreeTotal(root);

            long maxTotal = long.MinValue;
            int total = root.val;

            FindMax(root, ref maxTotal, total);

            return (int)(maxTotal % (Math.Pow(10, 9) + 7));
        }

        private static void FindMax(TreeNode node, ref long maxTotal, int total)
        {
            if (node == null)
                return;

            long multi = node.val * (long)(total - node.val);
            maxTotal = maxTotal < multi ? multi : maxTotal;

            FindMax(node.left, ref maxTotal, total);
            FindMax(node.right, ref maxTotal, total);
        }

        private static int TreeTotal(TreeNode node)
        {
            if (node == null)
                return 0;

            node.val += TreeTotal(node.left) + TreeTotal(node.right);

            return node.val;
        }
    }
}
