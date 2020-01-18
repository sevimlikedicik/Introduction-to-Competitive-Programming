using System;
using System.Collections.Generic;
using System.Text;
using IntroCompetitiveProgrammingCodes.Day_14;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class SumOfNodesWithEvenValuedGrandparent
    {
        public enum NodeType
        {
            Parent,

            Child,
        }

        internal class AdvancedNode
        {
            public TreeNode Node;
            public AdvancedNode Left;
            public AdvancedNode Right;
            public List<NodeType> NodeTypes = new List<NodeType>();

            public AdvancedNode(TreeNode node)
            {
                Node = node;
            }
        }

        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(12);
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

            Console.WriteLine(SumEvenGrandparent(node1));

            Console.ReadKey();
        }

        public static int SumEvenGrandparent(TreeNode root)
        {
            var newRoot = MakeAdvancedNodes(root);

            return Bfs(newRoot);
        }

        private static AdvancedNode MakeAdvancedNodes(TreeNode node)
        {
            if(node != null)
            {
                AdvancedNode newNode = new AdvancedNode(node);
                newNode.Left = MakeAdvancedNodes(node.left);
                newNode.Right = MakeAdvancedNodes(node.right);

                return newNode;
            }

            return null;
        }

        private static int Bfs(AdvancedNode root)
        {
            Queue<AdvancedNode> queue = new Queue<AdvancedNode>();
            queue.Enqueue(root);
            int total = 0;

            while (queue.Count != 0)
            {
                AdvancedNode advancedNode = queue.Dequeue();

                if (advancedNode.NodeTypes.Contains(NodeType.Child))
                    total += advancedNode.Node.val;

                if (advancedNode.Node.val % 2 == 0)
                {
                    if(advancedNode.Left != null)
                        advancedNode.Left.NodeTypes.Add(NodeType.Parent);
                    if(advancedNode.Right != null)
                        advancedNode.Right.NodeTypes.Add(NodeType.Parent);
                }

                if (advancedNode.NodeTypes.Contains(NodeType.Parent))
                {
                    if (advancedNode.Left != null)
                        advancedNode.Left.NodeTypes.Add(NodeType.Child);
                    if (advancedNode.Right != null)
                        advancedNode.Right.NodeTypes.Add(NodeType.Child);
                }

                if (advancedNode.Left != null)
                    queue.Enqueue(advancedNode.Left);

                if (advancedNode.Right != null)
                    queue.Enqueue(advancedNode.Right);
            }

            return total;
        }
    }
}
