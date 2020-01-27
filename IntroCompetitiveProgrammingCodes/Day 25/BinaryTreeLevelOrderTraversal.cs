using System;
using System.Collections.Generic;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class BinaryTreeLevelOrderTraversal
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

            var list = LevelOrder(node1);

            Console.ReadKey();
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            LevelOrder(root, dict, 0);

            IList<IList<int>> lists = new List<IList<int>>();

            for (int i = 0; i < dict.Count; i++)
                lists.Add(dict[i]);

            return lists;
        }

        private static void LevelOrder(TreeNode node, Dictionary<int, List<int>> dict, int depth)
        {
            if (node == null)
                return;

            if (!dict.ContainsKey(depth))
                dict[depth] = new List<int>() { node.val };
            else
                dict[depth].Add(node.val);

            LevelOrder(node.left, dict, depth + 1);
            LevelOrder(node.right, dict, depth + 1);
        }
    }
}
