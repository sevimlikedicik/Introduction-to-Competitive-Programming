using System;

namespace IntroCompetitiveProgrammingCodes.Day_08
{
    class PrefixCalculator
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');

            int[] stack = new int[2];
            int stackPointer = 0;

            for (int i = phrase.Length - 1; i >= 0; i--)
            {
                if(phrase[i].Length > 1)
                {
                    int num = Convert.ToInt32(phrase[i]);
                    stack[stackPointer++] = num;
                }
                else
                {
                    int num;
                    bool isNumber = int.TryParse(phrase[i], out num);

                    if (!isNumber)
                    {
                        char c = phrase[i][0];

                        switch (c)
                        {
                            case '+':
                                stack[0] += stack[1];
                                stackPointer--;
                                break;
                            case '-':
                                stack[0] -= stack[1];
                                stackPointer--;
                                break;
                            case '*':
                                stack[0] *= stack[1];
                                stackPointer--;
                                break;
                            case '/':
                                stack[0] /= stack[1];
                                stackPointer--;
                                break;
                        }
                    }
                    else
                        stack[stackPointer++] = num;
                }
            }

            Console.WriteLine(stack[0]);

            Console.ReadKey();
        }
    }
}
