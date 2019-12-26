using System;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    class RangeSumOfBST
    {
        static int ans = 0;

        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(5);

            t1.left = node1;
            t1.right = node2;
            t1.left.left = node3;
            t1.left.right = node4;

            Console.WriteLine(RangeSumBST(t1, 2, 5));

            Console.ReadKey();
        }

        public static int RangeSumBST(TreeNode root, int L, int R)
        {
            Dfs(root, L, R);
            return ans;
        }

        public static void Dfs(TreeNode node, int L, int R)
        {
            if (node != null)
            {
                if (L <= node.val && node.val <= R)
                    ans += node.val;
                Dfs(node.left, L, R);
                Dfs(node.right, L, R);
            }
        }
    }
}
