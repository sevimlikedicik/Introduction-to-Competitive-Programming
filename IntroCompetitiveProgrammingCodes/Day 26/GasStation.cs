using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class GasStation
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 8, 2, 8 };
            int[] arr2 = new int[] { 6, 5, 6, 6 };

            Console.WriteLine(CanCompleteCircuit(arr, arr2));

            Console.ReadKey();
        }

        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int[] travel = new int[gas.Length];
            int len = travel.Length;

            for (int i = 0; i < len; i++)
                travel[i] = gas[i] - cost[i];

            int startingIndex = 0;
            int index = 1 % len;
            int total = travel[0];
            int elementCount = 0;

            while (elementCount < 2 * len)
            {
                while (elementCount < 2 * len && total >= 0 && index != startingIndex)
                {
                    total += travel[index];
                    index = (index + 1) % len;
                    elementCount++;
                }

                if (startingIndex == index && total >= 0)
                    break;

                startingIndex = index;
                total = travel[index];
                index = (index + 1) % len;
                elementCount++;
            }

            if (startingIndex == index)
                return index;

            return -1;
        }
    }
}
