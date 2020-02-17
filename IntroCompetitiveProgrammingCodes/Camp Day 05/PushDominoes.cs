using System;
using System.Diagnostics;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class PushDominoes
    {
        static void Main(string[] args)
        {
            var s = Solve(".LRRRRL..L.L..L...R..");

            Console.ReadKey();
        }

        public static string Solve(string dominoes)
        {
            int[] numberRepresentation = new int[dominoes.Length];

            for (int i = 0; i < numberRepresentation.Length; i++)
            {
                if (dominoes[i] == 'R')
                    numberRepresentation[i] = 100002;
                else if (dominoes[i] == 'L')
                    numberRepresentation[i] = 100001;
                else
                    numberRepresentation[i] = 0;
            }

            for (int i = 0; i < numberRepresentation.Length; i++)
            {
                if (numberRepresentation[i] == 100002)
                {
                    int count = 1;
                    i++;
                    while (i < numberRepresentation.Length && numberRepresentation[i] == 0)
                        numberRepresentation[i++] = count++;
                    i--;
                }
            }

            for (int i = numberRepresentation.Length - 1; i >= 0; i--)
            {
                if (numberRepresentation[i] == 100001)
                {
                    if (i >= 1)
                    {
                        if (numberRepresentation[i - 1] > 0 && numberRepresentation[i - 1] < 100001)
                        {
                            i--;
                            int startingIndex = i;
                            int convertToLSize = numberRepresentation[startingIndex] / 2;
                            bool DoesMiddleStayStill = numberRepresentation[startingIndex] % 2 == 1;
                            int middleIndex = startingIndex - convertToLSize;
                            while(i > middleIndex)
                                numberRepresentation[i--] = -1;
                            numberRepresentation[middleIndex] = DoesMiddleStayStill ? 0 : numberRepresentation[middleIndex];
                        }
                        else if (numberRepresentation[i - 1] == 0)
                        {
                            while (i - 1 >= 0 && numberRepresentation[i - 1] == 0)
                                numberRepresentation[(i--) - 1] = -1;
                        }
                    }
                }
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numberRepresentation.Length; i++)
            {
                if (numberRepresentation[i] == 100001 || numberRepresentation[i] == -1)
                    result.Append("L");
                else if (numberRepresentation[i] == 0)
                    result.Append(".");
                else
                    result.Append("R");
            }

            return result.ToString();
        }
    }
}
