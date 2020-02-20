using System;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_14
{
    class DistributeCoinsInBinaryTree
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(6);

            TreeNode node1 = new TreeNode(0);
            TreeNode node2 = new TreeNode(0);
            TreeNode node3 = new TreeNode(0);
            TreeNode node4 = new TreeNode(0);
            TreeNode node5 = new TreeNode(0);

            t1.left = node1;
            t1.right = node2;
            t1.left.left = node3;
            t1.left.right = node4;
            t1.right.left = node5;

            Console.WriteLine(DistributeCoins(t1));

            Console.ReadKey();
        }

        public static int DistributeCoins(TreeNode root) => Dfs(root, null).Item1;

        static Tuple<int, int> Dfs(TreeNode node, TreeNode parent)
        {
            if (node == null)
                return new Tuple<int, int>(0, 0);

            var left = Dfs(node.left, node);
            var right = Dfs(node.right, node);
            var total = new Tuple<int, int>(left.Item1 + right.Item1, left.Item2 + right.Item2);
            int load = total.Item2 - (node.val - 1);

            if (parent == null)
                return total;
            else
                return new Tuple<int, int>(total.Item1 + Math.Abs(load), load);
        }
    }
}
