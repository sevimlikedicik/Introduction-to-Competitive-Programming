using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class MinimumAddToMakeParenthesesValid
    {
        static void Main(string[] args)
        {
            string a = "(((";

            Console.WriteLine(MinAddToMakeValid(a));

            Console.ReadKey();
        }

        public static int MinAddToMakeValid(string S)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                char c = S[i];
                char stackTop;

                if (c == ')')
                {
                    if (stack.TryPeek(out stackTop))
                    {
                        if (stackTop == '(')
                            stack.Pop();
                        else
                            stack.Push(c);
                    }
                    else
                        stack.Push(c);
                }
                else
                    stack.Push(c);
            }

            return stack.Count;
        }
    }
}
