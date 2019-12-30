using System;

namespace IntroCompetitiveProgrammingCodes.Day_12
{
    class TaskScheduler
    {
        static void Main(string[] args)
        {
            char[] arr = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int k = 2;

            Console.WriteLine(LeastInterval(arr, k));

            Console.ReadKey();
        }

        public static int LeastInterval(char[] tasks, int k)
        {
            int[] letterCounter = new int[26];

            foreach (char c in tasks)
                letterCounter[c - 'A']++;

            Array.Sort(letterCounter);
            Array.Reverse(letterCounter);

            int total = 0;

            foreach (int num in letterCounter)
                total += num;

            if (total / (k + 1) > letterCounter[0])
                return total;
            else
            {
                int walk = 1;

                while (walk < 26 && letterCounter[walk] == letterCounter[0])
                    walk++;

                return letterCounter[0] * k + walk;
            }
        }
    }
}
