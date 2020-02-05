using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_03
{
    class MaximumOfAbsoluteValueExpression
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, -2, -5, 0, 10 };
            int[] arr2 = new int[] { 0, -2, -1, -7, -4 };

            Console.WriteLine(MaxAbsValExpr(arr, arr2));

            Console.ReadKey();
        }

        public static int MaxAbsValExpr(int[] arr1, int[] arr2)
        {
            int firstState = FindMax(arr1, arr2, true, true);
            int secondState = FindMax(arr1, arr2, true, false);
            int thirdState = FindMax(arr1, arr2, false, true);
            int fourthState = FindMax(arr1, arr2, false, false);

            return Math.Max(Math.Max(firstState, secondState), Math.Max(thirdState, fourthState));
        }

        private static int FindMax(int[] arr1, int[] arr2, bool onePositive, bool twoPositive)
        {
            // true is '+', false is '-'.
            bool[] iSideOperators = new bool[3];
            bool[] jSideOperators = new bool[3];

            iSideOperators[0] = false;
            jSideOperators[0] = true;
            iSideOperators[1] = onePositive;
            jSideOperators[1] = !onePositive;
            iSideOperators[2] = twoPositive;
            jSideOperators[2] = !twoPositive;

            int maxISide = int.MinValue;
            int maxJSide = int.MinValue;

            for (int k = 0; k < arr1.Length; k++)
            {
                int iSide = Calculate(arr1, arr2, k, iSideOperators);
                int jSide = Calculate(arr1, arr2, k, jSideOperators);

                maxISide = iSide > maxISide ? iSide : maxISide;
                maxJSide = jSide > maxJSide ? jSide : maxJSide;
            }

            return maxISide + maxJSide;
        }

        private static int Calculate(int[] arr1, int[] arr2, int index, bool[] operators)
        {
            int sum = operators[0] ? index : -index;
            sum += operators[1] ? arr1[index] : -arr1[index];
            sum += operators[2] ? arr2[index] : -arr2[index];

            return sum;
        }
    }
}
