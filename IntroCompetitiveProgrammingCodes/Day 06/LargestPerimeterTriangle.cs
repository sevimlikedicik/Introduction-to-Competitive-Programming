using System;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class LargestPerimeterTriangle
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            Console.WriteLine(LargestPerimeter(arr));

            Console.ReadKey();
        }

        public static int LargestPerimeter(int[] A)
        {
            int maxPerimeter = 0;

            Array.Sort(A);

            for (int i = A.Length - 1; i > 1; i--)
            {
                if (IsTriangle(A[i], A[i - 1], A[i - 2]))
                {
                    maxPerimeter = A[i] + A[i - 1] + A[i - 2];
                    break;
                }
            }

            return maxPerimeter;
        }

        private static bool IsTriangle(int v1, int v2, int v3)
        {
            if (v1 + v2 <= v3)
                return false;
            if (v1 + v3 <= v2)
                return false;
            if (v2 + v3 <= v1)
                return false;
            return true;
        }
    }
}
