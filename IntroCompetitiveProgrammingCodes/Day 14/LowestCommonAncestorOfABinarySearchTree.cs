using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    class LowestCommonAncestorOfABinarySearchTree
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(6);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(8);
            TreeNode node3 = new TreeNode(0);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(7);
            TreeNode node6 = new TreeNode(9);
            TreeNode node7 = new TreeNode(3);
            TreeNode node8 = new TreeNode(5);
            t1.left = node1;
            t1.right = node2;
            t1.left.left = node3;
            t1.left.right = node4;
            t1.right.left = node5;
            t1.right.right = node6;
            node4.left = node7;
            node4.right = node8;

            var ancestor = LowestCommonAncestor(t1, node1, node4);

            Console.ReadKey();
        }

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode[] pPath = FindPath(root, p);
            TreeNode[] qPath = FindPath(root, q);
            int border = Math.Min(pPath.Length, qPath.Length);

            // Doesn't matter which path we choose as for ending.
            for (int i = 0; i < border; i++)
            {
                if (pPath[i].val != qPath[i].val)
                    return pPath[i - 1];
            }

            return qPath[border - 1];
        }

        private static TreeNode[] FindPath(TreeNode root, TreeNode q)
        {
            List<TreeNode> path = new List<TreeNode>();
            TreeNode walk = root;

            while (walk != q)
            {
                path.Add(walk);
                if (walk.val < q.val)
                    walk = walk.right;
                else
                    walk = walk.left;
            }

            path.Add(walk);

            return path.ToArray();
        }
    }
}
