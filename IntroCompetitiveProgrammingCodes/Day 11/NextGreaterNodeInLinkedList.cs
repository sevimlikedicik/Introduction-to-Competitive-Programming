using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class NextGreaterNodeInLinkedList
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(5);

            ListNode node2 = new ListNode(2);
            head.next = node2;

            ListNode node3 = new ListNode(5);
            node2.next = node3;

            var arr = NextLargerNodes(head);

            foreach (int num in arr)
                Console.WriteLine($"{num} ");

            Console.ReadKey();
        }

        public static int[] NextLargerNodes(ListNode head)
        {
            List<int> list = new List<int>();
            ListNode walk = head;

            if (head == null)
                return null;

            while (walk != null)
            {
                list.Add(walk.val);
                walk = walk.next;
            }

            int[] arr = list.ToArray();

            int[] nextLargerValues = new int[arr.Length];

            nextLargerValues[arr.Length - 1] = 0;

            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i - 1] < arr[i])
                    nextLargerValues[i - 1] = arr[i];
                else
                {
                    if (nextLargerValues[i] == 0)
                        nextLargerValues[i - 1] = 0;
                    else
                    {
                        int walk_arr = i;
                        while (walk_arr < arr.Length && nextLargerValues[walk_arr] <= arr[i - 1])
                            walk_arr++;

                        if (walk_arr == arr.Length)
                            nextLargerValues[i - 1] = 0;
                        else
                            nextLargerValues[i - 1] = nextLargerValues[walk_arr];
                    }
                }
            }

            return nextLargerValues;
        }
    }
}
