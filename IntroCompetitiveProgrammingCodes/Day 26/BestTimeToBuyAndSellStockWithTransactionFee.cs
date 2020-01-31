using System;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class BestTimeToBuyAndSellStockWithTransactionFee
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 2, 8, 4, 9 };

            Console.WriteLine(MaxProfit(arr, 2));

            Console.ReadKey();
        }

        public static int MaxProfit(int[] prices, int fee)
        {
            int total = 0;
            int min = prices[0];
            int max = int.MinValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                    min = prices[i];

                if (prices[i] > min + 2)
                {
                    max = prices[i];
                    int index = i + 1;
                    while (index < prices.Length && prices[index] > max - fee)
                    {
                        if (prices[index] > max)
                            max = prices[index];
                        index++;
                    }

                    total += max - min - fee;
                    if (index == prices.Length)
                        break;

                    min = prices[index];
                    max = int.MinValue;

                    i = index;
                }
            }

            return total;
        }

    }
}
