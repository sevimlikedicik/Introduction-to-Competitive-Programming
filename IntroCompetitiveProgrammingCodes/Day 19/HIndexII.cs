using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class HIndexII
    {
        static void Main(string[] args)
        {
            int[] citations = { 2, 3, 4, 30, 89 };

            Console.WriteLine(HIndex(citations));

            Console.ReadKey();
        }

        public static int HIndex(int[] citations)
        {
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
