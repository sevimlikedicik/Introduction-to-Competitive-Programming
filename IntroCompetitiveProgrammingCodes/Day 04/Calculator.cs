using System;

namespace IntroCompetitiveProgrammingCodes.Day_04
{
    class Calculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the function: (#number# #opertator# #number#)");
                string[] phrase = Console.ReadLine().Split(' ');

                double a = Convert.ToDouble(phrase[0]);
                char opt = Convert.ToChar(phrase[1]);
                double b = Convert.ToDouble(phrase[2]);

                double result = 0;

                switch (opt)
                {
                    case '+':
                        result = a + b;
                        break;
                    case '-':
                        result = a + b;
                        break;
                    case '*':
                        result = a * b;
                        break;
                    case '/':
                        result = a / b;
                        break;
                    case '%':
                        result = a % b;
                        break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
