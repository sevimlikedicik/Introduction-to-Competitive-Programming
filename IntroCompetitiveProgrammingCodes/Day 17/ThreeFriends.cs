using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_17
{
    class ThreeFriends
    {
        public static void Main()
        {
            string phase = Console.ReadLine();
            int q = Convert.ToInt32(phase);

            List<int> results = new List<int>();

            for (int i = 0; i < q; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                int a = Convert.ToInt32(numbers[0]);
                int b = Convert.ToInt32(numbers[1]);
                int c = Convert.ToInt32(numbers[2]);

                int totalPairwiseDistance = Math.Abs(a - b) + Math.Abs(a - c) + Math.Abs(b - c);
                totalPairwiseDistance = (totalPairwiseDistance - 4 < 0) ? 0 : (totalPairwiseDistance - 4);

                results.Add(totalPairwiseDistance);
            }

            foreach (int result in results)
                Console.WriteLine(result);

        }
    }
}
