using System;

namespace IntroCompetitiveProgrammingCodes.Day_08
{
    class ValidParantheses
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();

            Console.WriteLine(IsValid(phrase));

            Console.ReadKey();
        }

        public static bool IsValid(string s)
        {
            char[] stack = new char[s.Length];

            int stackPointer = 0;

            foreach(char c in s)
            {
                switch (c)
                {
                    case '(':
                        stack[stackPointer++] = c;
                        break;
                    case '{':
                        stack[stackPointer++] = c;
                        break;
                    case '[':
                        stack[stackPointer++] = c;
                        break;
                    case ')':
                        if (stackPointer > 0 && stack[stackPointer - 1] == '(')
                            stackPointer--;
                        else
                            return false;
                        break;
                    case '}':
                        if (stackPointer > 0 && stack[stackPointer - 1] == '{')
                            stackPointer--;
                        else
                            return false;
                        break;
                    case ']':
                        if (stackPointer > 0 && stack[stackPointer - 1] == '[')
                            stackPointer--;
                        else
                            return false;
                        break;
                }
            }

            if (stackPointer == 0)
                return true;

            return false;
        }
    }
}
