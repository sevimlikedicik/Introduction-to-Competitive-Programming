using System;
using System.Collections.Generic;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class RecoverATreeFromPreorderTraversal
    {
        static void Main(string[] args)
        {
            string graphString = "1-2--3--4-5--6--7";

            var root = RecoverFromPreorder(graphString);

            Console.ReadKey();
        }

        public static TreeNode RecoverFromPreorder(string S)
        {
            if (S.Length == 0)
                return null;

            // 1000 is given in the question
            TreeNode[] depthNodes = new TreeNode[1000];
            char[] chars = S.ToCharArray();

            var x = S.Split('-');
            int[] nums = new int[1000];
            int len = 0;
            int counter = 1;
            int num;

            foreach (string s in x)
            {
                if (int.TryParse(s, out num))
                    nums[len++] = num;
            }

            TreeNode root = new TreeNode(nums[0]);
            depthNodes[0] = root;

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (c == '-')
                {
                    int depth = -1;

                    while (c == '-')
                    {
                        depth++;
                        c = chars[++i];
                    }

                    TreeNode node = new TreeNode(nums[counter++]);

                    if (depthNodes[depth].left == null)
                        depthNodes[depth].left = node;
                    else
                        depthNodes[depth].right = node;

                    depthNodes[depth + 1] = node;
                }
            }

            return root;
        }
    }
}
