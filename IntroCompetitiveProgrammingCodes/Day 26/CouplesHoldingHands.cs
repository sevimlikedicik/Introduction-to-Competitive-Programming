using System;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class CouplesHoldingHands
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 4, 5, 6, 7, 2, 1, 3 };

            Console.WriteLine(MinSwapsCouples(arr));

            Console.ReadKey();
        }

        public static int MinSwapsCouples(int[] row)
        {
            int totalMoves = 0;

            for (int i = 0; i < row.Length; i += 2)
            {
                int firstLover = row[i] / 2;
                int index = i + 1;

                while (index < row.Length && row[index] / 2 != firstLover)
                    index++;

                if (index - i != 1)
                {
                    int temp = row[i + 1];
                    row[i + 1] = row[index];
                    row[index] = temp;
                    totalMoves++;
                }
            }

            return totalMoves;
        }
    }
}
