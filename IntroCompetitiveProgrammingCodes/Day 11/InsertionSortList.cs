using System;

namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class InsertionSortList
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(4);

            ListNode node2 = new ListNode(2);
            head.next = node2;

            ListNode node3 = new ListNode(1);
            node2.next = node3;

            ListNode node4 = new ListNode(3);
            node3.next = node4;

            head = InsertionSort(head);

            while (head != null)
            {
                Console.WriteLine($"{head.val} ");
                head = head.next;
            }

            Console.ReadKey();
        }

        public static ListNode InsertionSort(ListNode head)
        {
            if (head == null)
                return null;

            ListNode walk = head;
            int size = 0;

            while (walk != null)
            {
                walk = walk.next;
                size++;
            }

            for (int i = 1; i <= size - 1; i++)
            {
                walk = head;
                ListNode prev = walk;

                for (int j = 0; j < i; j++)
                {
                    prev = walk;
                    walk = walk.next;
                }

                Remove(walk, prev);
                head = Insert(walk.val, head, i);
            }

            return head;
        }

        private static void Remove(ListNode walk, ListNode prev)
        {
            prev.next = walk.next;
        }

        private static ListNode Insert(int val, ListNode head, int insertionBorder)
        {
            ListNode newNode = new ListNode(val);
            ListNode walk = head;
            int counter = 0;
            newNode.next = head;
            ListNode prevNode = walk;

            if (walk.val < val)
            {
                newNode.next = walk.next;
                walk = walk.next;
                prevNode.next = newNode;
                counter++;
            }

            while (counter < insertionBorder && walk.val < val)
            {
                newNode.next = walk.next;
                prevNode.next = walk;
                walk.next = newNode;
                prevNode = walk;
                walk = newNode.next;
                counter++;
            }

            if (counter == 0)
                return newNode;

            return head;
        }
    }
}
