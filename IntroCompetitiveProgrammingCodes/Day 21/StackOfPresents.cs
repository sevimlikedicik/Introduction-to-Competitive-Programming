using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_21
{
    class StackOfPresents
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            long[] results = new long[t];

            for (int i = 0; i < t; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(phrase[0]);
                int m = Convert.ToInt32(phrase[1]);

                phrase = Console.ReadLine().Split(' ');
                Dictionary<int, int> presentPlaces = new Dictionary<int, int>();

                for (int j = 0; j < n; j++)
                    presentPlaces.Add(Convert.ToInt32(phrase[j]), j);

                phrase = Console.ReadLine().Split(' ');
                int[] order = new int[m];
                bool[] saved = new bool[m];

                for (int j = 0; j < m; j++)
                    order[j] = Convert.ToInt32(phrase[j]);

                long moves = 0;

                for (int j = 0; j < m; j++)
                {
                    if (saved[j])
                        moves++;
                    else
                    {
                        moves += (presentPlaces[order[j]] - j) * 2 + 1;
                        int index = j + 1;
                        while (index < m && presentPlaces[order[index]] < presentPlaces[order[j]])
                            saved[index++] = true;
                    }
                }

                results[i] = moves;
            }

            foreach (var result in results)
                Console.WriteLine(result);
        }
    }
}
