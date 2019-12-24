using System;

namespace IntroCompetitiveProgrammingCodes.Day_11
{
    // This is a simple copy of ReverseNodesInKGroup class.
    class SwapNodesInPairs
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            ListNode walk = head;

            for (int i = 2; i < 15; i++)
            {
                ListNode newNode = new ListNode(i);
                walk.next = newNode;
                walk = newNode;
            }

            head = SwapPairs(head);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.ReadKey();
        }

        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
                return head;

            int size = 1;

            ListNode walk = head.next;
            ListNode prev = head;

            while (walk != null)
            {
                walk = walk.next;
                size++;
            }

            if (size < 2)
                return head;

            walk = head;

            ListNode prevStartNode = walk;
            ListNode startNode = walk;

            for (int i = 0; i < size / 2; i++)
            {
                startNode = walk;
                prev = walk;
                walk = walk.next;

                for (int j = 0; j < 1; j++)
                {
                    ListNode next = walk.next;

                    walk.next = prev;
                    prev = walk;
                    walk = next;
                }

                if (i > 0)
                {
                    prevStartNode.next = prev;
                    prevStartNode = startNode;
                }
                else
                    head = prev;
            }

            prevStartNode.next = walk;

            return head;
        }
    }
}
