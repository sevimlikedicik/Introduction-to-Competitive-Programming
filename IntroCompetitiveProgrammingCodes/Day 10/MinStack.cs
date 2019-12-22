using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_10
{
    class MinStack
    {
        int[] arr;
        int stackPointer;

        /** initialize your data structure here. */
        public MinStack()
        {
            arr = new int[10000];
            stackPointer = 0;
        }

        public void Push(int x)
        {
            arr[stackPointer++] = x;
        }

        public void Pop()
        {
            stackPointer--;
        }

        public int Top()
        {
            return arr[stackPointer - 1];
        }

        public int GetMin()
        {
            int[] subArray = new int[stackPointer];
            Array.Copy(arr, subArray, stackPointer);
            return subArray.Min();
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
