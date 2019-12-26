using System;

namespace IntroCompetitiveProgrammingCodes.Day_14
{
    public class LevelValuePair
    {
        public int Level;
        public int Value;

        public LevelValuePair(int level, int value)
        {
            Level = level;
            Value = value;
        }
    }

    class FindBottomLeftTreeValue
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(0);

            TreeNode node1 = new TreeNode(-1);
            t1.left = node1;

            Console.WriteLine(FindBottomLeftValue(t1));

            Console.ReadKey();
        }

        public static int FindBottomLeftValue(TreeNode root)
        {
            return Magic(root, 1).Value;
        }

        private static LevelValuePair Magic(TreeNode node, int level)
        {
            if (node == null)
                return null;

            var leftPair = Magic(node.left, level + 1);
            var rightPair = Magic(node.right, level + 1);

            if (leftPair == null && rightPair == null)
                return new LevelValuePair(level, node.val);
            else if (leftPair == null)
                return rightPair;
            else if (rightPair == null)
                return leftPair;
            else
            {
                if (leftPair.Level >= rightPair.Level)
                    return leftPair;
                return rightPair;
            }
        }
    }
}
