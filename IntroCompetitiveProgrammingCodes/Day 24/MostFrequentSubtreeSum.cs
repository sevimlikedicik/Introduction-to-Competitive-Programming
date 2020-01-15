using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class MostFrequentSubtreeSum
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(2);
            root.right = new TreeNode(-5);

            Console.WriteLine(FindFrequentTreeSum(root));

            Console.ReadKey();
        }

        static Dictionary<int, int> subTreeSums = new Dictionary<int, int>();

        public static int[] FindFrequentTreeSum(TreeNode root)
        {
            TreeSum(root);

            int max = int.MinValue;
            List<int> maxKeys = new List<int>();

            foreach (var kvp in subTreeSums)
            {
                if (kvp.Value > max)
                {
                    max = kvp.Value;
                    maxKeys = new List<int>() { kvp.Key };
                }
                else if (kvp.Value == max)
                    maxKeys.Add(kvp.Key);
            }

            return maxKeys.ToArray();
        }

        private static int TreeSum(TreeNode node)
        {
            if (node == null)
                return 0;

            int sum = TreeSum(node.left) + TreeSum(node.right) + node.val;

            if (subTreeSums.ContainsKey(sum))
                subTreeSums[sum]++;
            else
                subTreeSums.Add(sum, 1);

            return sum;
        }
    }
}
