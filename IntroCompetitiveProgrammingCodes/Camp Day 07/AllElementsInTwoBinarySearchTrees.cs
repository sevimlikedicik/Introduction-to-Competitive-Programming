using System;
using System.Collections.Generic;
using System.Linq;

using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_07
{
    class AllElementsInTwoBinarySearchTrees
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

            var list = GetAllElements(node1, node2);

            Console.ReadKey();
        }

        public static IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            int[] arr = Enumerable.Repeat(int.MaxValue, 10000).ToArray();
            int index = 0;

            AddElements(arr, ref index, root1);
            AddElements(arr, ref index, root2);

            Array.Sort(arr);

            int[] newArr = new int[index];

            Array.Copy(arr, 0, newArr, 0, index);

            return newArr.ToList();
        }

        private static void AddElements(int[] arr, ref int index, TreeNode node)
        {
            if (node == null)
                return;

            arr[index++] = node.val;

            AddElements(arr, ref index, node.left);
            AddElements(arr, ref index, node.right);
        }
    }
}
