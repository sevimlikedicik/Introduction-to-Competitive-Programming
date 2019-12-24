using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class ReverseNodesInKGroup
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

            head = ReverseKGroup(head, 4);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.ReadKey();
        }

        public static ListNode ReverseKGroup(ListNode head, int k)
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

            if (size < k)
                return head;

            walk = head;

            ListNode prevStartNode = walk;
            ListNode startNode = walk;

            for (int i = 0; i < size / k; i++)
            {
                startNode = walk;
                prev = walk;
                walk = walk.next;

                for (int j = 0; j < k - 1; j++)
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
