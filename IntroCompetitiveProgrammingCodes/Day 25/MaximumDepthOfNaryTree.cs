using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    class MaximumDepthOfNaryTree
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);

            node1.children = new List<Node>() { node3, node2, node4 };
            node3.children = new List<Node>() { node5, node6 };

            Console.WriteLine(MaxDepth(node1));

            Console.ReadKey();
        }

        public static int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            return FindMaxDepth(root, 1);
        }

        private static int FindMaxDepth(Node node, int depth)
        {
            if (node.children == null)
                return depth;

            int max = int.MinValue;

            foreach (var child in node.children)
            {
                int childDepth = FindMaxDepth(child, depth + 1);

                if (childDepth > max)
                    max = childDepth;
            }

            return max;
        }
    }
}
