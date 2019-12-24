namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class DeleteNodeInALinkedList
    {
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
