using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    class SearchInBinarySearchTree
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(5);
            t1.left = node3;
            t1.right = node4;
            t1.left.left = node1;
            t1.left.right = node2;

            TreeNode t3 = SearchBST(t1, 3);

            Console.ReadKey();
        }

        public static TreeNode SearchBST(TreeNode root, int val)
        {
            while (root != null && root.val != val)
            {
                if (root.val > val)
                    root = root.left;
                else
                    root = root.right;
            }

            return root;
        }
    }
}
