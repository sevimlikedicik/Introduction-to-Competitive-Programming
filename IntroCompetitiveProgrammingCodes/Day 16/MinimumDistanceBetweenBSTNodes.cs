using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_16
{
    class MinimumDistanceBetweenBSTNodes
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);

            TreeNode node1 = new TreeNode(3);
            TreeNode node2 = new TreeNode(6);

            t1.left = node1;
            t1.right = node2;

            Console.WriteLine(MinDiffInBST(t1));

            Console.ReadKey();
        }

        public static int MinDiffInBST(TreeNode root)
        {
            Dfs(root);

            int[] arr = list.ToArray();
            Array.Sort(arr);
            int minDiff = int.MaxValue;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] < minDiff)
                    minDiff = arr[i] - arr[i - 1];
            }

            return minDiff;
        }

        public static void Dfs(TreeNode node)
        {
            if (node != null)
            {
                list.Add(node.val);
                Dfs(node.left);
                Dfs(node.right);
            }
        }

    }
}
