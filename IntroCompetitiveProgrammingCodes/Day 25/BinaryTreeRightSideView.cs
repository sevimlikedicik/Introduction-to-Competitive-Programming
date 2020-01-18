using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class BinaryTreeRightSideView
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
            node1.right = node3;
            node2.left = node4;
            node3.left = node5;
            node3.right = node6;
            node4.left = node7;
            node4.right = node8;
            node6.right = node9;

            var list = RightSideView(node1);

            Console.ReadKey();
        }

        public static IList<int> RightSideView(TreeNode root)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            RightSideView(root, dict, 0);

            return dict.Values.ToList();
        }

        private static void RightSideView(TreeNode node, Dictionary<int, int> dict, int depth)
        {
            if (node == null)
                return;

            if (!dict.ContainsKey(depth))
                dict.Add(depth, node.val);

            RightSideView(node.right, dict, depth + 1);
            RightSideView(node.left, dict, depth + 1);
        }
    }
}
