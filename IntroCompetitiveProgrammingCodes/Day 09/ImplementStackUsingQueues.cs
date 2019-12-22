namespace IntroCompetitiveProgrammingCodes.Day_09
{
    class ImplementStackUsingQueues
    {
        int[] arr;
        int stackPointer = 0;

        /** Initialize your data structure here. */
        public ImplementStackUsingQueues()
        {
            arr = new int[128];
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            arr[stackPointer++] = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            stackPointer--;
            return arr[stackPointer];
        }

        /** Get the top element. */
        public int Top()
        {
            return arr[stackPointer - 1];
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return (stackPointer == 0);
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
}
