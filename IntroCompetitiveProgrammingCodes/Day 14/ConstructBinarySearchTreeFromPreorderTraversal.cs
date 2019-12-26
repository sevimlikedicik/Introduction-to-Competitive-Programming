using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    class ConstructBinarySearchTreeFromPreorderTraversal
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 2, 1, 6, 0, 5 };

            TreeNode root = BstFromPreorder(arr);

            Console.ReadKey();
        }

        public static TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = new TreeNode(preorder[0]);

            for (int i = 1; i < preorder.Length; i++)
            {
                int val = preorder[i];
                TreeNode walk = root;
                TreeNode prev = root;
                bool isLeft = false;

                while (walk != null)
                {
                    if (val < walk.val)
                    {
                        prev = walk;
                        walk = walk.left;
                        isLeft = true;
                    }
                    else
                    {
                        prev = walk;
                        walk = walk.right;
                        isLeft = false;
                    }
                }

                TreeNode newNode = new TreeNode(val);
                if (isLeft)
                    prev.left = newNode;
                else
                    prev.right = newNode;
            }

            return root;
        }
    }
}
