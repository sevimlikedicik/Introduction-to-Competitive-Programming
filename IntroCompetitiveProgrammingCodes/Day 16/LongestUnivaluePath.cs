using System;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_16
{
    class LongestUnivaluePath
    {
        static int maxPath = 0;

        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(4);

            TreeNode node1 = new TreeNode(4);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(4);

            t1.left = node1;
            t1.left.left = node2;
            t1.left.left.left= node3;
            t1.left.right = node4;
            t1.left.right.right = node5;

            Console.WriteLine(LongestPath(t1));

            Console.ReadKey();
        }

        public static int LongestPath(TreeNode root)
        {
            if (root == null)
                return 0;

            Magic(root);
            return maxPath;
        }

        private static int Magic(TreeNode node)
        {
            int path = 0;

            if (node.left != null && node.right != null)
            {
                if (node.left.val != node.val && node.right.val != node.val)
                {
                    int leftPath = Magic(node.left);
                    int rightPath = Magic(node.right);

                    path = Math.Max(leftPath, rightPath);
                    if (path > maxPath)
                        maxPath = path;

                    return 0;
                }
                else if (node.left.val == node.val && node.right.val == node.val)
                {
                    int leftPath = Magic(node.left);
                    int rightPath = Magic(node.right);

                    path = leftPath + rightPath + 2;
                    if (path > maxPath)
                        maxPath = path;

                    return Math.Max(leftPath, rightPath) + 1;
                }
                else if (node.left.val == node.val)
                {
                    int leftPath = Magic(node.left);
                    int rightPath = Magic(node.right);

                    path = leftPath + 1;
                    if (path > maxPath)
                        maxPath = path;

                    return path;
                }
                else
                {
                    int leftPath = Magic(node.left);
                    int rightPath = Magic(node.right);

                    path = rightPath + 1;
                    if (path > maxPath)
                        maxPath = path;

                    return path;
                }
            }
            else if (node.left == null && node.right == null)
                return 0;
            else if (node.right == null)
            {
                path = Magic(node.left);
                if (node.left.val == node.val)
                {
                    path++;
                    if (path > maxPath)
                        maxPath = path;

                    return path;
                }
                else
                {
                    if (path > maxPath)
                        maxPath = path;

                    return 0;
                }
            }
            else
            {
                path = Magic(node.right);
                if (node.right.val == node.val)
                {
                    path++;
                    if (path > maxPath)
                        maxPath = path;

                    return path;
                }
                else
                {
                    if (path > maxPath)
                        maxPath = path;

                    return 0;
                }
            }
        }
    }
}
