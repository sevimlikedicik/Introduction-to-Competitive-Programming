using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class MinCostClimbingStairs
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(MinCostClimbing(arr));

            Console.ReadKey();
        }

        public static int MinCostClimbing(int[] cost)
        {
            for (int i = 2; i < cost.Length; i++)
                cost[i] = Math.Min(cost[i - 1], cost[i - 2]) + cost[i];

            return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
        }
    }
}
