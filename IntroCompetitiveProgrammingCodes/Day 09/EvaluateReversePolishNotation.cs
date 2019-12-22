using System;

namespace IntroCompetitiveProgrammingCodes.Day_09
{
    class EvaluateReversePolishNotation
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');

            Console.WriteLine(EvalRPN(phrase));

            Console.ReadKey();
        }

        public static int EvalRPN(string[] tokens)
        {
            int[] stack = new int[tokens.Length];
            int stackPointer = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Length > 1)
                {
                    int num = Convert.ToInt32(tokens[i]);
                    stack[stackPointer++] = num;
                }
                else
                {
                    int num;
                    bool isNumber = int.TryParse(tokens[i], out num);

                    if (!isNumber)
                    {
                        char c = tokens[i][0];

                        switch (c)
                        {
                            case '+':
                                stackPointer--;
                                stack[stackPointer - 1] += stack[stackPointer];
                                break;
                            case '-':
                                stackPointer--;
                                stack[stackPointer - 1] -= stack[stackPointer];
                                break;
                            case '*':
                                stackPointer--;
                                stack[stackPointer - 1] *= stack[stackPointer];
                                break;
                            case '/':
                                stackPointer--;
                                stack[stackPointer - 1] /= stack[stackPointer];
                                break;
                        }
                    }
                    else
                        stack[stackPointer++] = num;
                }
            }

            return stack[0];
        }
    }
}
