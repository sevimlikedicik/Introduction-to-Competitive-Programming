using System;

namespace IntroCompetitiveProgrammingCodes.Day_06
{
    class HIndex
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');
            int[] arr = new int[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                arr[i] = Convert.ToInt32(phrase[i]);

            Console.WriteLine(FindHIndex(arr));

            Console.ReadKey();
        }

        public static int FindHIndex(int[] citations)
        {
            Array.Sort(citations);

            int indexCounter = 1;

            for (int i = citations.Length - 1; i >= 0; i--)
            {
                if (citations[i] >= indexCounter)
                    indexCounter++;
                else
                    break;
            }

            return indexCounter - 1;
        }
    }
}
