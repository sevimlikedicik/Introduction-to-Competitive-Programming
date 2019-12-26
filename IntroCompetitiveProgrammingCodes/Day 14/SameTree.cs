using System;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    class SameTree
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            t1.left = node1;
            t1.right = node2;

            TreeNode t2 = new TreeNode(1);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(5);

            t2.left = node3;
            t2.right = node4;

            Console.WriteLine(IsSameTree(t1, t2));

            Console.ReadKey();
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null)
                return false;
            else if (q == null)
                return false;
            else if (p.val != q.val)
                return false;

            bool left = IsSameTree(p.left, q.left);
            bool right = IsSameTree(p.right, q.right);

            return (left && right);
        }
    }
}
