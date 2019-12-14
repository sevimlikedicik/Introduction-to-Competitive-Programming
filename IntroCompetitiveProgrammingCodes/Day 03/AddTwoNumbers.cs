public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        bool remainder = false;
        int total = l1.val + l2.val;
        if (total > 9)
        {
            remainder = true;
            total %= 10;
        }

        ListNode newList = new ListNode(total);
        ListNode previousNode = newList;
        l1 = l1.next;
        l2 = l2.next;

        while (l1 != null && l2 != null)
        {
            total = l1.val + l2.val;
            total = (remainder) ? total + 1 : total;
            remainder = false;

            if (total > 9)
            {
                remainder = true;
                total %= 10;
            }

            ListNode currentNode = new ListNode(total);
            previousNode.next = currentNode;
            previousNode = currentNode;
            l1 = l1.next;
            l2 = l2.next;
        }

        if (l1 == null)
        {
            while (l2 != null)
            {
                total = l2.val;
                total = (remainder) ? total + 1 : total;
                remainder = false;

                if (total > 9)
                {
                    remainder = true;
                    total %= 10;
                }

                ListNode currentNode = new ListNode(total);
                previousNode.next = currentNode;
                previousNode = currentNode;
                l2 = l2.next;
            }
        }
        else
        {
            while (l1 != null)
            {
                total = l1.val;
                total = (remainder) ? total + 1 : total;
                remainder = false;

                if (total > 9)
                {
                    remainder = true;
                    total %= 10;
                }

                ListNode currentNode = new ListNode(total);
                previousNode.next = currentNode;
                previousNode = currentNode;
                l1 = l1.next;
            }
        }

        if (remainder)
        {
            ListNode currentNode = new ListNode(1);
            previousNode.next = currentNode;
        }

        return newList;
    }
}