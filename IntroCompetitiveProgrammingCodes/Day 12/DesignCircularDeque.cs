using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_12
{
    public class DesignCircularDeque
    {
        int[] arr;
        int front = 1;
        int last = 0;
        int size;
        int elementCount = 0;

        /** Initialize your data structure here. Set the size of the deque to be k. */
        public DesignCircularDeque(int k)
        {
            arr = new int[k];
            size = k;
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (!IsFull())
            {
                front--;

                if (front == -1)
                    front = size - 1;

                arr[front] = value;
                elementCount++;
                return true;
            }

            return false;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (!IsFull())
            {
                last++;

                if (last == size)
                    last = 0;

                arr[last] = value;
                elementCount++;
                return true;
            }

            return false;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (IsEmpty())
                return false;

            front++;

            if (front == size)
                front = 0;

            elementCount--;

            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (IsEmpty())
                return false;

            last--;

            if (last == -1)
                last = size - 1;

            elementCount--;

            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (IsEmpty())
                return -1;
            return arr[front];
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if (IsEmpty())
                return -1;
            return arr[last];
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            return elementCount == 0;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            return elementCount == size;
        }
    }
}
