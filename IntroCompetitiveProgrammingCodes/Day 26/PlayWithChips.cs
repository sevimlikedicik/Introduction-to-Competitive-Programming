using System;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class PlayWithChips
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 3, 5, 1, 2 };

            Console.WriteLine(MinCostToMoveChips(arr));

            Console.ReadKey();
        }

        public static int MinCostToMoveChips(int[] chips)
        {
            int evenCount = 0;
            int oddCount = 0;

            for (int i = 0; i < chips.Length; i++)
            {
                if (chips[i] % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }

            return Math.Min(evenCount, oddCount);
        }
    }
}
