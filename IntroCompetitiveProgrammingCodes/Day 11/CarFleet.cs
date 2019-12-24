using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_11
{
    class CarFleet
    {
        static void Main(string[] args)
        {
            int target = 10;

            int[] position = { 6, 8 };
            int[] speed = { 3, 2 };

            Console.WriteLine(Solution(target, position, speed));

            Console.ReadKey();
        }

        public static int Solution(int target, int[] position, int[] speed)
        {
            if (position.Length == 0)
                return 0;

            SortedDictionary<int, List<int>> positionSpeedPairs = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < position.Length; i++)
            {
                if (positionSpeedPairs.ContainsKey(position[i]))
                    positionSpeedPairs[position[i]].Add(speed[i]);
                else
                    positionSpeedPairs[position[i]] = new List<int>() { speed[i] };
            }

            double[] arrivalTimes = new double[position.Length];
            int walk_arrivalTimes = 0;

            foreach (var kvp in positionSpeedPairs)
            {
                int startingPosition = kvp.Key;

                foreach (int v in kvp.Value)
                    arrivalTimes[walk_arrivalTimes++] = (1.0 * (target - startingPosition)) / v;
            }

            bool[] hasFleet = new bool[position.Length];
            int fleetCount = 0;

            for (int i = arrivalTimes.Length - 1; i > 0; i--)
            {
                if (arrivalTimes[i] >= arrivalTimes[i - 1])
                {
                    if (!hasFleet[i])
                    {
                        hasFleet[i] = true;
                        fleetCount++;
                    }
                    hasFleet[i - 1] = true;
                    arrivalTimes[i - 1] = arrivalTimes[i];
                }
                else
                {
                    if (!hasFleet[i])
                    {
                        fleetCount++;
                        hasFleet[i] = true;
                    }
                }
            }

            if (!hasFleet[0])
                fleetCount++;

            return fleetCount;
        }
    }
}
