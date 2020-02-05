using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_5
{
    class ClimbingStairs
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClimbStairs(10));

            Console.ReadKey();
        }

        public static int ClimbStairs(int n)
        {
            int[] climbingWays = new int[n + 3];
            climbingWays[1] = 1;
            climbingWays[2] = 2;

            return FindClimbingWay(climbingWays, n);
        }

        private static int FindClimbingWay(int[] climbingWays, int n)
        {
            if (climbingWays[n] != 0)
                return climbingWays[n];

            climbingWays[n] = FindClimbingWay(climbingWays, n - 1) + FindClimbingWay(climbingWays, n - 2);

            return climbingWays[n];
        }
    }
}
