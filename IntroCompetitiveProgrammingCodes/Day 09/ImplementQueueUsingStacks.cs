namespace IntroCompetitiveProgrammingCodes.Day_09
{
    class ImplementQueueUsingStacks
    {
        int[] arr;
        int head = 0;
        int tail = 0;

        /** Initialize your data structure here. */
        public ImplementQueueUsingStacks()
        {
            arr = new int[128];
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            arr[tail++] = x;
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return arr[head++];
        }

        /** Get the front element. */
        public int Peek()
        {
            return arr[head];
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return (tail - head == 0);
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */

}
