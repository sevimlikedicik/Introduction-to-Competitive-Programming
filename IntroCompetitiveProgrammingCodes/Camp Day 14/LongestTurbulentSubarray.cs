using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_14
{
    class LongestTurbulentSubarray
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(MaxTurbulenceSize(arr));

            Console.ReadKey();
        }

        public static int MaxTurbulenceSize(int[] A)
        {
            int max = 1;

            for (int i = 0; i < A.Length - 1; i++)
            {
                bool increasing = true;

                if (A[i + 1] == A[i])
                    continue;

                if (A[i + 1] > A[i])
                    increasing = false;

                int index = i + 1;
                int counter = 2;
                max = Math.Max(counter, max);

                while (index < A.Length - 1)
                {
                    if (increasing && A[index + 1] <= A[index])
                        break;
                    else if (!increasing && A[index + 1] >= A[index])
                        break;
                    else
                    {
                        increasing = !increasing;
                        counter++;
                        index++;
                        max = Math.Max(counter, max);
                    }
                }

                i = index - 1;
            }

            return max;
        }
    }
}
