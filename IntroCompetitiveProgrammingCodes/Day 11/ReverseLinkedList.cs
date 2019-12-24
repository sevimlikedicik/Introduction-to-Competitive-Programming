namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
                return head;

            ListNode walk = head.next;
            ListNode prev = head;

            while (walk.next != null)
            {
                ListNode next = walk.next;

                walk.next = prev;
                prev = walk;
                walk = next;
            }

            walk.next = prev;
            head.next = null;

            return walk;
        }
    }
}
