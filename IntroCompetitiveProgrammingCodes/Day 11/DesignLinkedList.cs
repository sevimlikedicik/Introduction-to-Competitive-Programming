namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class DesignLinkedList
    {
        int[] arr;
        int tail = 0;

        /** Initialize your data structure here. */
        public DesignLinkedList()
        {
            arr = new int[1000];
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (tail == 0 || index >= tail)
                return -1;
            return arr[index];
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            AddAtIndex(0, val);
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            arr[tail++] = val;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            for (int i = tail; i > index; i--)
                arr[i] = arr[i - 1];
            tail++;
            arr[index] = val;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < tail)
            {
                for (int i = index; i < tail - 1; i++)
                    arr[i] = arr[i + 1];
                tail--;
            }
        }
    }
}
