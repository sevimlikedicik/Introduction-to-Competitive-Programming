namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class RemoveDuplicatesFromSortedList
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;

            ListNode walk = head;

            while (walk.next != null)
            {
                if (walk.next.val == walk.val)
                    walk.next = walk.next.next;
                else
                    walk = walk.next;
            }

            return head;
        }
    }
}
