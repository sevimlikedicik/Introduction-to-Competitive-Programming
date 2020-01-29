using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Contest_02
{
    class ValidateStackSequences
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 1 };
            int[] arr2 = new int[] { 0, 1 };

            Console.WriteLine(ValidateStack(arr, arr2));

            Console.ReadKey();
        }

        public static bool ValidateStack(int[] pushed, int[] popped)
        {
            if (pushed.Length == 0)
                return true;

            Stack<int> stack = new Stack<int>();
            int index = 0;

            for (int i = 0; i < popped.Length; i++)
            {
                int pop = popped[i];
                int peek;

                if (stack.TryPeek(out peek) && peek == pop)
                    stack.Pop();
                else
                {
                    while (index < pushed.Length && pushed[index] != pop)
                        stack.Push(pushed[index++]);

                    if (index++ == pushed.Length)
                        return false;
                }
            }

            return true;
        }
    }
}
