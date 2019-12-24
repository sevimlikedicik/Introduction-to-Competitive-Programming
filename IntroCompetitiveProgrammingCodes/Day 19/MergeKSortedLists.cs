namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class MergeKSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            int min = int.MaxValue;
            int minInd = -1;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null && lists[i].val < min)
                {
                    min = lists[i].val;
                    minInd = i;
                }
            }

            if (min == int.MaxValue)
                return null;

            ListNode head = new ListNode(min);
            ListNode walk = head;
            lists[minInd] = lists[minInd].next;

            bool allListsAreFinished = true;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    allListsAreFinished = false;
                    break;
                }
            }

            while (!allListsAreFinished)
            {
                allListsAreFinished = true;
                min = int.MaxValue;
                minInd = -1;

                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null && lists[i].val < min)
                    {
                        min = lists[i].val;
                        minInd = i;
                    }
                }

                lists[minInd] = lists[minInd].next;
                ListNode newNode = new ListNode(min);
                walk.next = newNode;
                walk = newNode;

                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        allListsAreFinished = false;
                        break;
                    }
                }
            }

            return head;
        }
    }
}
