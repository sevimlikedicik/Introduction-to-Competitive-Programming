using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_12
{
    class ConstructTargetArrayWithMultipleSums
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(IsPossible(arr));

            Console.ReadKey();
        }

        public static bool IsPossible(int[] target)
        {
            long total = 0;

            for (int i = 0; i < target.Length; i++)
                total += target[i];
            int count = 1;
            while (count != 0)
            {
                count = 0;
                for (int i = 0; i < target.Length; i++)
                {
                    int restTotal = (int)total - target[i];
                    while (target[i] > restTotal)
                    {
                        target[i] -= restTotal;
                        total -= restTotal;
                        count++;
                    }
                }
            }

            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] != 1)
                    return false;
            }

            return true;
        }
    }
}
