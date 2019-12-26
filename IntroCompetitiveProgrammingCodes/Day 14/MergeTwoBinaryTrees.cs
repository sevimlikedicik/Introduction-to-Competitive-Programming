using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class MergeTwoBinaryTrees
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);
            TreeNode t2 = new TreeNode(3);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            t1.left = node1;
            t1.right = node2;

            TreeNode node3 = new TreeNode(1);
            TreeNode node4 = new TreeNode(2);
            t2.left = node3;
            t2.right = node4;

            TreeNode t3 = MergeTrees(t1, t2);

            Console.ReadKey();
        }

        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            else
            {
                TreeNode newNode = new TreeNode(t1.val + t2.val);
                newNode.left = MergeTrees(t1.left, t2.left);
                newNode.right = MergeTrees(t1.right, t2.right);
                return newNode;
            }
        }
    }
}
