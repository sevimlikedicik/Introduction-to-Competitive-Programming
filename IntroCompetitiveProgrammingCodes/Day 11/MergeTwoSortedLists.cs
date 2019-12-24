namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode walk_l1 = l1;
            ListNode walk_l2 = l2;

            if (walk_l1 != null && walk_l2 != null)
            {
                ListNode head = new ListNode(0);
                ListNode walk = head;

                if (walk_l1.val < walk_l2.val)
                {
                    head.val = walk_l1.val;
                    walk = head;
                    walk_l1 = walk_l1.next;
                }
                else
                {
                    head.val = walk_l2.val;
                    walk = head;
                    walk_l2 = walk_l2.next;
                }

                while (walk_l1 != null && walk_l2 != null)
                {
                    if (walk_l1.val < walk_l2.val)
                    {
                        ListNode newNode = new ListNode(walk_l1.val);
                        walk.next = newNode;
                        walk = walk.next;
                        walk_l1 = walk_l1.next;
                    }
                    else
                    {
                        ListNode newNode = new ListNode(walk_l2.val);
                        walk.next = newNode;
                        walk = walk.next;
                        walk_l2 = walk_l2.next;
                    }
                }

                while (walk_l1 != null)
                {
                    ListNode newNode = new ListNode(walk_l1.val);
                    walk.next = newNode;
                    walk = walk.next;
                    walk_l1 = walk_l1.next;
                }

                while (walk_l2 != null)
                {
                    ListNode newNode = new ListNode(walk_l2.val);
                    walk.next = newNode;
                    walk = walk.next;
                    walk_l2 = walk_l2.next;
                }

                walk.next = null;

                return head;

            }
            else
            {
                if (walk_l1 != null)
                {
                    ListNode head = new ListNode(walk_l1.val);
                    ListNode walk = head;
                    walk_l1 = walk_l1.next;

                    while (walk_l1 != null)
                    {
                        ListNode newNode = new ListNode(walk_l1.val);
                        walk.next = newNode;
                        walk = walk.next;
                        walk_l1 = walk_l1.next;
                    }

                    walk.next = null;

                    return head;

                }
                else if (walk_l2 != null)
                {
                    ListNode head = new ListNode(walk_l2.val);
                    ListNode walk = head;
                    walk_l2 = walk_l2.next;

                    while (walk_l2 != null)
                    {
                        ListNode newNode = new ListNode(walk_l2.val);
                        walk.next = newNode;
                        walk = walk.next;
                        walk_l2 = walk_l2.next;
                    }

                    walk.next = null;

                    return head;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
