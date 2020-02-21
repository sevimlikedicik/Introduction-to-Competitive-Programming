using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_14
{
    class SquaresOfASortedArray
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(SortedSquares(arr));

            Console.ReadKey();
        }

        public static int[] SortedSquares(int[] A)
        {
            int[] squares = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
                squares[i] = (int)Math.Pow(A[i], 2);

            Array.Sort(squares);
            return squares;
        }
    }
}
