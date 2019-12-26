using System;
using System.Collections.Generic;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_15
{
    class BinaryTreePostorderTraversal
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(5);
            TreeNode node5 = new TreeNode(6);
            TreeNode node6 = new TreeNode(7);
            TreeNode node7 = new TreeNode(8);
            TreeNode node8 = new TreeNode(9);
            TreeNode node9 = new TreeNode(10);
            TreeNode node10 = new TreeNode(11);
            TreeNode node11 = new TreeNode(12);
            TreeNode node12 = new TreeNode(13);
            TreeNode node13 = new TreeNode(14);
            TreeNode node14 = new TreeNode(15);

            t1.left = node1;
            t1.right = node2;
            t1.left.left = node3;
            t1.left.right = node4;
            t1.right.left = node5;
            t1.right.right = node6;
            t1.left.left.left = node7;
            t1.left.left.right = node8;
            t1.left.right.left = node9;
            t1.left.right.right = node10;
            t1.right.left.left = node11;
            t1.right.left.right = node12;
            t1.right.right.left = node13;
            t1.right.right.right = node14;

            var list = PostorderTraversal(t1);

            foreach (int a in list)
                Console.Write($"{a} ");

            Console.ReadKey();
        }

        public static IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            Magic(list, root);

            return list;
        }

        private static void Magic(List<int> list, TreeNode node)
        {
            if (node == null)
                return;

            // first recur on left subtree 
            Magic(list, node.left);

            // then recur on right subtree 
            Magic(list, node.right);

            list.Add(node.val);
        }
    }
}
