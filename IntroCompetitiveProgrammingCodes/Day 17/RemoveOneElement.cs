using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_17
{
    internal class ArrayBorders
    {
        public int Left;
        public int Right;

        public ArrayBorders(int l, int r)
        {
            Left = l;
            Right = r;
        }
    }

    class RemoveOneElement
    {
        static void Main(string[] args)
        {
            int n = ReadInt();
            var phrase = ReadLineAsArray();

            List<ArrayBorders> strictlyIncreasingArrays = new List<ArrayBorders>();
            int start = 0;
            int end = 0;
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
                arr[i] = ConvertInt(phrase[i]);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    start = i - 1;
                    end = i++;

                    while (i < phrase.Length && arr[i] > arr[i - 1])
                        end = i++;

                    strictlyIncreasingArrays.Add(new ArrayBorders(start, end));
                }
            }

            int max = 1;

            foreach (var arrayBorders in strictlyIncreasingArrays)
            {
                if (Length(arrayBorders) > max)
                    max = Length(arrayBorders);
            }

            for (int i = 0; i < strictlyIncreasingArrays.Count - 1; i++)
            {
                if (Length(strictlyIncreasingArrays[i]) + Length(strictlyIncreasingArrays[i + 1]) - 1 > max)
                {
                    if (CanMergeArrays(arr, strictlyIncreasingArrays[i], strictlyIncreasingArrays[i + 1]))
                        max = Length(strictlyIncreasingArrays[i]) + Length(strictlyIncreasingArrays[i + 1]) - 1;
                }
            }

            Console.WriteLine(max);
        }

        private static bool CanMergeArrays(int[] arr, ArrayBorders arrayBorders1, ArrayBorders arrayBorders2)
        {
            if (arrayBorders1.Right != arrayBorders2.Left - 1)
                return false;

            if (arr[arrayBorders1.Right - 1] < arr[arrayBorders2.Left])
                return true;

            if (arr[arrayBorders1.Right] < arr[arrayBorders2.Left + 1])
                return true;

            return false;
        }

        private static int Length(ArrayBorders arrayBorders) => arrayBorders.Right - arrayBorders.Left + 1;

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}
