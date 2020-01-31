using System;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class BestTimeToBuyAndSellStockII
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(MaxProfit(arr));

            Console.ReadKey();
        }

        public static int MaxProfit(int[] prices)
        {
            int total = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                    total += prices[i + 1] - prices[i];
            }

            return total;
        }
    }
}
