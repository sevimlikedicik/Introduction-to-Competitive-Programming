using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_13
{
    class LinkedListComponents
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(0);
            ListNode one = new ListNode(1);
            ListNode two = new ListNode(2);
            ListNode three = new ListNode(3);
            ListNode four = new ListNode(4);

            head.next = one;
            one.next = two;
            two.next = three;
            three.next = four;

            int[] G = new int[] { 0, 3, 1, 4 };

            Console.WriteLine(NumComponents(head, G));

            Console.ReadKey();
        }

        public static int NumComponents(ListNode head, int[] G)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < G.Length; i++)
                hs.Add(G[i]);

            bool onStreak = false;
            int counter = 0;
            while (head != null)
            {
                int num = head.val;
                if (hs.Contains(num))
                {
                    if (!onStreak)
                        counter++;
                    onStreak = true;
                }
                else
                    onStreak = false;

                head = head.next;
            }

            return counter;
        }
    }
}
